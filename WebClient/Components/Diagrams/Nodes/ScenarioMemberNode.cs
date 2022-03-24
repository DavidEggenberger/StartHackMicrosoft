using Blazor.Diagrams.Core.Models;
using DTOs.Aggregates.Scenario;

namespace WebClient.Components.Diagrams.Nodes
{
    public class ScenarioMemberNode : NodeModel
    {
        public ScenarioRoleDTO Role { get; set; }
        public ScenarioMemberNode(ScenarioRoleDTO Role, Blazor.Diagrams.Core.Geometry.Point position = null) : base(position)
        {
            AddPort(PortAlignment.Top);
            AddPort(PortAlignment.Bottom);
            this.Role = Role;
        }
    }
}
