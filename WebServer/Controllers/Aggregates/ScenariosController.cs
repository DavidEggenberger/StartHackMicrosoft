using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Domain;
using WebServer.Data;
using DTOs.Aggregates;
using AutoMapper;

namespace WebServer.Controllers.Aggregates
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScenariosController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public ScenariosController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<ScenarioDTO>> GetScenarios()
        {
            return (await context.Scenarios.ToListAsync()).Select(s => mapper.Map<ScenarioDTO>(s));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ScenarioDTO>> GetScenario(Guid id)
        {
            var scenario = await context.Scenarios.FindAsync(id);

            if (scenario == null)
            {
                return NotFound();
            }

            return mapper.Map<ScenarioDTO>(scenario);
        }

        [HttpPost]
        public async Task PostScenario(ScenarioDTO scenarioDTO)
        {
            context.Scenarios.Add(mapper.Map<Scenario>(scenarioDTO));
            await context.SaveChangesAsync();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteScenario(Guid id)
        {
            var scenario = await context.Scenarios.FindAsync(id);
            if (scenario == null)
            {
                return NotFound();
            }

            context.Scenarios.Remove(scenario);
            await context.SaveChangesAsync();

            return NoContent();
        }
    }
}
