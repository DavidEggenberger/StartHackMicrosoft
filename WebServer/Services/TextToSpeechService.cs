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
        TranslatorService translator;
        public TextToSpeechService(IOptions<AzureTranslatorOptions> azureTranslatorOptions, IWebHostEnvironment env, TranslatorService translator)
        {
            this.azureTranslatorOptions = azureTranslatorOptions.Value;
            this.env = env;
            this.translator = translator;
        }
        public async Task<string> SynthesizeAudioAsync(string language, string text)
        {
            var config = SpeechConfig.FromSubscription(azureTranslatorOptions.SubscriptionKey, azureTranslatorOptions.Location);
            
            config.SpeechSynthesisLanguage = language;

            var lang = language switch
            {
                "de-DE" => "de-DE-ConradNeural",
                "de-CH" => "de-CH-JanNeural",
                "fr-FR" => "fr-FR-HenriNeural",
                _ => "en-US-JacobNeural"
            };

            config.SpeechSynthesisVoiceName = lang;

            using var synthesizer = new SpeechSynthesizer(config);

            var result = await synthesizer.SpeakTextAsync(await translator.Translate(text, "en", language));
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
