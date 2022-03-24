using DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using WebServer.Misc;

namespace WebServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AzureSpeechAnalysisController : ControllerBase
    {
        private readonly AzureSpeechAnalysisOptions azureSpeechOptions;

        public AzureSpeechAnalysisController(IOptions<AzureSpeechAnalysisOptions> azureSpeechOptions)
        {
            this.azureSpeechOptions = azureSpeechOptions.Value;
        }

        [HttpGet]
        [Authorize]
        public async Task<TokenDTO> GetToken()
        {
            return new TokenDTO
            {
                APIKey = azureSpeechOptions.APIKey,
                Endpoint = azureSpeechOptions.Endpoint
            };
        }
    }
}
