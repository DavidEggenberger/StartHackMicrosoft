using System;

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
                MessageChanged?.Invoke(message);
            }
        }

        public event Action<string> MessageChanged;

    }
}
