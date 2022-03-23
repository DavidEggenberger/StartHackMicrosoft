using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class ApplicationUser : IdentityUser
    {
        public List<ApplicationUserTeam> TeamMemberships { get; set; }
        public List<ApplicationUserScenario> SolvedSingleScenarios { get; set; }
        public string AvatarName { get; set; }
        public int TabsOpen { get; set; }
        public bool IsOnline { get; set; }
        public string Motto { get; set; }
    }
}
