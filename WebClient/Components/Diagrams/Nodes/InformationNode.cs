using Blazor.Diagrams.Core.Models;

namespace WebClient.Components.Diagrams.Nodes
{
    public class InformationNode : NodeModel
    {
        public InformationNode(Blazor.Diagrams.Core.Geometry.Point position = null) : base(position)
        {
            AddPort(PortAlignment.Top);
            AddPort(PortAlignment.Bottom);
        }
    }
}
