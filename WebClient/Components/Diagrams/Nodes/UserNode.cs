using Blazor.Diagrams.Core.Models;

namespace WebClient.Components.Diagrams.Nodes
{
    public class UserNode : NodeModel
    {
        public UserNode(Blazor.Diagrams.Core.Geometry.Point position = null) : base(position)
        {
            AddPort(PortAlignment.Top);
        }
    }
}
