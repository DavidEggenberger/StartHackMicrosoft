using Blazor.Diagrams.Core.Models;

namespace WebClient.Components.Diagrams
{
    public class ScenarioPort : PortModel
    {
        public ScenarioPort(NodeModel parent, PortAlignment alignment = PortAlignment.Bottom)
            : base(parent, alignment, null, null)
        {

        }

        public override bool CanAttachTo(PortModel port)
        {
            // Avoid attaching to self port/node
            if (!base.CanAttachTo(port))
                return false;

            return true;
        }
    }
}
