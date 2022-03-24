using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.Aggregates.Scenario
{
    public class ScenarioStepDTO
    {
        public Guid Id { get; set; }
        public ScenarioRoleDTO ScenarioRoleType { get; set; }
        public bool UserSender { get; set; }
        public string Message { get; set; }
        public string EnglishMessage { get; set; }
        public string OriginalLanguageIdentifier { get; set; }
    }
}
