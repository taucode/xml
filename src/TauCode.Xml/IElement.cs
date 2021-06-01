using TauCode.Xml.Unbound;

namespace TauCode.Xml
{
    public interface IElement
    {
        IUnboundSchema UnboundSchema { get; }
        IAttributeCollection UnboundAttributes { get; }
    }
}
