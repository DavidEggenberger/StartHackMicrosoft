using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class ScenarioStep
    {
        public Guid Id { get; set; }
        public string Message { get; set; }
        public ScenarioRole ScenarioRoleType { get; set; }
        public string AnswerUser { get; set; }
        public string ReactionPrevious { get; set; }
    }
}
