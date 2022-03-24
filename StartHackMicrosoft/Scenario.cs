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

    }
}
