using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Team
    {
        public Guid Id { get; set; }
        public List<ApplicationUserTeam> Members { get; set; }
        public string Name { get; set; }
    }
}
