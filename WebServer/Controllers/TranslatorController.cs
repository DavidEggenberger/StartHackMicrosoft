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

        public TranslatorController(TranslatorService translatorService)
        {
            this.translatorService = translatorService;
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
    }
}
