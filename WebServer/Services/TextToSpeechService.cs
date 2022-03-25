using System.Threading.Tasks;
using WebServer.Options;
using Microsoft.CognitiveServices.Speech;
using Microsoft.CognitiveServices.Speech.Audio;
using System;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Options;

namespace WebServer.Services
{
    public class TextToSpeechService
    {
        private readonly AzureTranslatorOptions azureTranslatorOptions;
        IWebHostEnvironment env;
        public TextToSpeechService(IOptions<AzureTranslatorOptions> azureTranslatorOptions, IWebHostEnvironment env)
        {
            this.azureTranslatorOptions = azureTranslatorOptions.Value;
            this.env = env;
        }
        public async Task<string> SynthesizeAudioAsync(string language, string text, string voiceLanguage = "en-US-BrandonNeural")
        {
            var config = SpeechConfig.FromSubscription(azureTranslatorOptions.SubscriptionKey, azureTranslatorOptions.Location);
            
            config.SpeechSynthesisLanguage = language;
                                                                          
            config.SpeechSynthesisVoiceName = voiceLanguage;

            using var synthesizer = new SpeechSynthesizer(config);

            var result = await synthesizer.SpeakTextAsync(text);
            using var stream = AudioDataStream.FromResult(result);
            Guid id = Guid.NewGuid();
            try
            {
                await stream.SaveToWaveFileAsync($"{env.WebRootPath}/{id}.wav");

            }
            catch (Exception ex)
            {

            }
            return $"/{id}.wav";
        }
    }
}
