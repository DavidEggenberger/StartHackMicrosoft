using Blazored.Modal;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebClient.Auth;
using WebClient.Services;

namespace WebClient
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddSingleton<StorageService>();
            builder.Services.AddBlazoredModal();
            builder.Services.AddScoped<AuthenticationStateProvider, HostAuthenticationStateProvider>();
            builder.Services.AddScoped(sp => (HostAuthenticationStateProvider)sp.GetRequiredService<AuthenticationStateProvider>());
            builder.Services.AddHttpClient("default", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));
            builder.Services.AddTransient(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("default"));
            builder.Services.AddScoped<HttpClientService>();
            builder.Services.AddTransient<AuthorizedHandler>();
            builder.Services.AddHttpClient("authorizedClient", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));
                //.AddHttpMessageHandler<AuthorizedHandler>();

            builder.Services.AddAuthorizationCore();

            await builder.Build().RunAsync();
        }
    }
}
