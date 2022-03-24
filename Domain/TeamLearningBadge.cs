using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class TeamLearningBadge
    {
        public Guid Id { get; set; }
        public Guid TeamId { get; set; }
        public Team Team { get; set; }
        public Guid LearningBadgeId { get; set; }
        public LearningBadge LearningBadge { get; set; }
    }
}
