using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using WebServer.Services;

namespace WebServer.SignalR
{
    public class NotificationHub : Hub
    {
        private readonly TranslatorService translatorService;
        public NotificationHub(TranslatorService translatorService)
        {
            this.translatorService = translatorService;
        }

        //public async Task 
    }
}
