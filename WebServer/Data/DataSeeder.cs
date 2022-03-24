using Domain;
using Domain.Enums;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebServer.Data
{
    public static class DataSeeder
    {
        public static async Task SeedScenariosAsync(this ApplicationDbContext applicationDbContext)
        {
            if(applicationDbContext.Scenarios.Count() == 0)
            {
                List<Scenario> scenarios = new List<Scenario>
                {
                     new Scenario
                     {
                        Name = "Sexism",
                        ShortDescription = "Man harrasses women during the coffe break",
                        Situtation = "",
                        ScenarioType = ScenarioType.Sexism,
                        ScenarioSteps = new List<ScenarioStep>
                        {
                            new ScenarioStep
                            {
                                ScenarioRoleType = ScenarioRole.Perpretator,
                                Message = ""
                            },
                            new ScenarioStep
                            {

                            },
                            new ScenarioStep
                            {

                            }
                        }
                     },
                     new Scenario
                     {
                        Name = "Bullying",
                        ShortDescription = "2 colleagues bully a man",
                        ScenarioType = ScenarioType.Bullying
                     },
                     new Scenario
                     {
                        Name = "Subtle Sexism",
                        ShortDescription = "Men gives a women a compliment",
                        ScenarioType = ScenarioType.Sexism
                     }
                };

                applicationDbContext.Scenarios.AddRange(scenarios);
                await applicationDbContext.SaveChangesAsync();  
            }
        }
        public static async Task SeedLearningBadgesAsync(this ApplicationDbContext applicationDbContext)
        {
            if (applicationDbContext.LearningBadges.Count() == 0)
            {
                List<LearningBadge> learningBadges = new List<LearningBadge>
                {
                     new LearningBadge
                     {
                         Name = "Pioneer",
                         Description = "Simulate the first situation",
                         IconUri = "/medal.png"
                     },
                     new LearningBadge
                     {
                         Name = "Pioneer",
                         Description = "Simulate the first situation",
                         IconUri = "/trophy.png"
                     },
                     new LearningBadge
                     {
                         Name = "Pioneer",
                         Description = "Simulate the first situation",
                         IconUri = "/ribbon-badge.png"
                     }
                };

                applicationDbContext.LearningBadges.AddRange(learningBadges);
                await applicationDbContext.SaveChangesAsync();
            }
        }
    }
}
