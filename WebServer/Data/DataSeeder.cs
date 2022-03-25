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
                        ShortDescription = "You are harassed during the coffee break",
                        ScenarioType = ScenarioType.Sexism,
                        ScenarioSteps = new List<ScenarioStep>
                        {
                            new ScenarioStep
                            {
                                ScenarioRoleType = ScenarioRole.Perpretator,
                                UserSender = false,
                                Message = "You look fresh and sweet, I have wild dreams!"
                            }
                        }
                     },
                     new Scenario
                     {
                        Name = "Bullying",
                        ShortDescription = "You are bullied by two colleagues",
                        ScenarioType = ScenarioType.Bullying,
                        ScenarioSteps = new List<ScenarioStep>
                        {
                            new ScenarioStep
                            {
                                ScenarioRoleType = ScenarioRole.Perpretator,
                                UserSender = false,
                                Message = "You are dumb and lazy, hahaha!"
                            }
                        }
                     },
                     new Scenario
                     {
                        Name = "Subtle Sexism",
                        ShortDescription = "You are given a bizarre compliment",
                        ScenarioType = ScenarioType.SubtleSexism,
                        ScenarioSteps = new List<ScenarioStep>
                        {
                            new ScenarioStep
                            {
                                ScenarioRoleType = ScenarioRole.Perpretator,
                                UserSender = false,
                                Message = "These trousers make you look great!"
                            }
                        }
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
                         Name = "Analyst",
                         Description = "Analyze your conversation",
                         IconUri = "/trophy.png"
                     },
                     new LearningBadge
                     {
                         Name = "Repeater",
                         Description = "Visit the platform on 7 consecutive days",
                         IconUri = "/ribbon-badge.png"
                     }
                };

                applicationDbContext.LearningBadges.AddRange(learningBadges);
                await applicationDbContext.SaveChangesAsync();
            }
        }
    }
}
