using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Domain;
using WebServer.Data;
using AutoMapper;
using DTOs.Aggregates;

namespace WebServer.Controllers.Aggregates
{
    [Route("api/[controller]")]
    [ApiController]
    public class LearningBadgesController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public LearningBadgesController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<LearningBadgeDTO>> GetLearningBadge()
        {
            return (await context.LearningBadges.ToListAsync()).Select(l => mapper.Map<LearningBadgeDTO>(l));
        }
    }
}
