using System;
using TauCode.Xml.Bound;
using TauCode.Xml.Unbound;

namespace TauCode.Xml
{
    internal interface IElementTypeDescriptor
    {
        Type ElementType { get; }
        IBoundSchema BoundSchema { get; }
        IUnboundSchema UnboundSchema { get; }
    }
}
