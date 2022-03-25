using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Scenario
    {
        public Guid Id { get; set; }
        public ScenarioType ScenarioType { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string Situation { get; set; }
        public List<ScenarioStep> ScenarioSteps { get; set; }
    }
}
