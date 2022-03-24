using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.JSInterop;
using System.Net.Http;
using WebClient.Services;

namespace WebClient.Shared
{
    public class BaseComponent : ComponentBase
    {
        [Inject] public HttpClient HttpClient { get; set; }
        [Inject] public NavigationManager NavigationManager { get; set; }
        [Inject] public IJSRuntime JSRuntime { get; set; }
        [Inject] public HttpClientService HttpClientService { get; set; }
        [CascadingParameter] public HubConnection HubConnection { get; set; }
    }
}
