using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Aggregates
{
    public class LearningBadgeDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string IconUri { get; set; }
        public string Description { get; set; }
    }
}
