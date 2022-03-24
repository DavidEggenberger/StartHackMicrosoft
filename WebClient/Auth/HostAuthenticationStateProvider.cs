using DTOs;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WebClient.Auth
{
    public class HostAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly NavigationManager navigationManager;
        private readonly HttpClient httpClient;
        private static readonly TimeSpan UserCacheRefreshInterval = TimeSpan.FromSeconds(60);
        private DateTimeOffset userLastCheck = DateTimeOffset.FromUnixTimeSeconds(0);
        private ClaimsPrincipal cachedUser = new ClaimsPrincipal(new ClaimsIdentity());
        public HostAuthenticationStateProvider(NavigationManager navigationManager, HttpClient httpClient)
        {
            this.navigationManager = navigationManager;
            this.httpClient = httpClient;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            return new AuthenticationState(await GetUser());
        }

        private async ValueTask<ClaimsPrincipal> GetUser()
        {
            if (DateTime.Now < (userLastCheck + UserCacheRefreshInterval))
            {
                return cachedUser;
            }
            else
            {
                cachedUser = await FetchUser();
                userLastCheck = DateTime.Now;
                return cachedUser;
            }
        }

        private async Task<ClaimsPrincipal> FetchUser()
        {
            try
            {
                var response = await httpClient.GetAsync(EndpointConstants.UserClaimsPath);

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var bffUserInfoDTO = await response.Content.ReadFromJsonAsync<BFFUserInfoDTO>();

                    var identity = new ClaimsIdentity(
                        nameof(HostAuthenticationStateProvider),
                        ClaimTypes.Name,
                        ClaimTypes.Role);

                    foreach (var claim in bffUserInfoDTO.Claims)
                    {
                        identity.AddClaim(new Claim(claim.Type, claim.Value.ToString()));
                    }

                    return new ClaimsPrincipal(identity);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return new ClaimsPrincipal(new ClaimsIdentity());
        }

        public void SignIn()
        {
            navigationManager.NavigateTo(EndpointConstants.LoginPath, true);
        }
    }
}

