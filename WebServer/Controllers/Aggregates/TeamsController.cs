using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebServer.Data;

namespace WebServer.Controllers.Aggregates
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private readonly ApplicationDbContext applicationDbContext;

        public TeamsController()
        {

        }
    }
}
