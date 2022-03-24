using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class ApplicationUserTeam
    {
        public Guid Id { get; set; }
        public Guid ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public Guid TeamId { get; set; }
        public Team Team { get; set; }
        public List<ApplicationUserTeamScenario> SolvedScenarios { get; set; }
    }
}
