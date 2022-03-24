using System;
using System.Threading.Tasks;

namespace WebClient.Services
{
    public class StorageService
    {
        private string message;
        public string Message
        {
            get { return message; }
            set 
            {
                message = value;
            }
        }
        public async void ChangeMessage(string message, string lIdentifier)
        {
            await MessageChanged?.Invoke(message, lIdentifier);
        }
        public event Func<string, string, Task> MessageChanged;

    }
}
