using DTOs.Aggregates.Scenario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Aggregates
{
    public class ScenarioDTO
    {
        public Guid Id { get; set; }
        public ScenarioTypeDTO ScenarioType { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string Situtation { get; set; }
        public List<ScenarioStepDTO> ScenarioSteps { get; set; }
        public bool Selected { get; set; }
        public string Language { get; set; } = "English";
    }
}
