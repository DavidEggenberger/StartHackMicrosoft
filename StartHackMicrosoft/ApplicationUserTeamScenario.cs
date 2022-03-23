using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class ApplicationUserTeamScenario
    {
        public Guid Id { get; set; }
        public Guid ApplicationUserId { get; set; }
        public ApplicationUserTeam ApplicationUserTeam { get; set; }
        public Guid ScenarioId { get; set; }
        public Scenario Scenario { get; set; }
    }
}
