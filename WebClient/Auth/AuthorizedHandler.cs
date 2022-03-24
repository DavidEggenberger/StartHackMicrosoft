using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace WebClient.Auth
{
    public class AuthorizedHandler : DelegatingHandler
    {
        private readonly HostAuthenticationStateProvider authenticationStateProvider;
        public AuthorizedHandler(HostAuthenticationStateProvider authenticationStateProvider)
        {
            this.authenticationStateProvider = authenticationStateProvider;
        }

        protected override async Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            var authState = await authenticationStateProvider.GetAuthenticationStateAsync();
            HttpResponseMessage responseMessage;
            if (!authState.User.Identity.IsAuthenticated)
            {
                responseMessage = new HttpResponseMessage(HttpStatusCode.Unauthorized);
            }
            else
            {
                responseMessage = await base.SendAsync(request, cancellationToken);
            }

            if (responseMessage.StatusCode == HttpStatusCode.Unauthorized)
            {
                authenticationStateProvider.SignIn();
            }

            return responseMessage;
        }
    }
}
