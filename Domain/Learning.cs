using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Learning
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public List<ScenarioStep> Steps { get; set; }
        public int Ratings { get; set; }
    }
}
