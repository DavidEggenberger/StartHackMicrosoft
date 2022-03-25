using AutoMapper;
using Domain;
using Domain.Enums;
using DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebServer.Data;

namespace WebServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LearningController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IMapper mapper;
        public LearningController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            this.context = context;
            this.userManager = userManager;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<List<LearningDTO>> GetLearning()
        {
            return context.Learnings.Include(x => x.Steps).Select(s => mapper.Map<LearningDTO>(s)).ToList();
        }

        [Authorize]
        [HttpPost]
        public async Task PostLearning(LearningDTO learningDTO)
        {
            ApplicationUser applicationUser = await userManager.GetUserAsync(HttpContext.User);
            context.Learnings.Add(new Learning
            {
                UserId = new Guid(applicationUser.Id),
                Ratings = learningDTO.PassiveAggressiveRating,
                Steps = learningDTO.ScenarioSteps.Select(s => new ScenarioStep
                {
                    Message = s.Message,
                    ScenarioRoleType = (ScenarioRole)s.ScenarioRoleType
                }).ToList()
            });
            await context.SaveChangesAsync();
        }
    }
}
