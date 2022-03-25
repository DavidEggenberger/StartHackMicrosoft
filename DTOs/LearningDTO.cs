using DTOs.Aggregates.Scenario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class LearningDTO
    {
        public int PassiveAggressiveRating { get; set; }
        public List<ScenarioStepDTO> ScenarioSteps { get; set; }
    }
}
