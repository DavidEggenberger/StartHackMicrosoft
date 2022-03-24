using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebServer.Services;
using DTOs;
using System.Threading.Tasks;

namespace WebServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TranslatorController : ControllerBase
    {
        private readonly TranslatorService translatorService;
        private readonly TextToSpeechService textToSpeechService;

        public TranslatorController(TranslatorService translatorService, TextToSpeechService textToSpeechService)
        {
            this.translatorService = translatorService;
            this.textToSpeechService = textToSpeechService;
        }

        [HttpGet]
        public async Task<TranslationResultDTO> Translate([FromQuery] string name, [FromQuery] string fromLanguage)
        {
            string result = await translatorService.TranslateToEnglisch(name, fromLanguage);
            return new TranslationResultDTO
            {
                Result = result
            };
        }

        [HttpGet("speech")]
        public async Task<TranslationResultDTO> Translate([FromQuery] string language, [FromQuery] string text, [FromQuery] string goalLanguage)
        {
            string result = await textToSpeechService.SynthesizeAudioAsync("en-US", text);
            return new TranslationResultDTO
            {
                Result = result
            };
        }
    }
}
