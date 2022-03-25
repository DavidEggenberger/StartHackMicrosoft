using Blazor.Diagrams.Core.Models;
using DTOs.Aggregates.Scenario;
using System;

namespace WebClient.Components.Diagrams.Nodes
{
    public class ScenarioMemberNode : NodeModel
    {
        public ScenarioRoleDTO Role { get; set; }
        public ScenarioMemberNode(ScenarioRoleDTO Role, Blazor.Diagrams.Core.Geometry.Point position = null) : base(position)
        {
            AddPort(PortAlignment.Bottom);
            this.Role = Role;
        }
        public event Action<string> audioForPrepretator;
    }
}
