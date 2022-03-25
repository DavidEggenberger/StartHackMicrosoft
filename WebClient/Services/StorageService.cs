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


        private bool microphoneAnalyzing;
        public bool MicrophoneAnalyzing
        {
            get
            {
                return microphoneAnalyzing;
            }
            set
            {
                microphoneAnalyzing = value;
                ChangeMicrophone(value);
            }
        }
        public async void ChangeMicrophone(bool b)
        {
            await MicrophoneChanged?.Invoke(b);
        }
        public event Func<bool, Task> MicrophoneChanged;
    }
}
