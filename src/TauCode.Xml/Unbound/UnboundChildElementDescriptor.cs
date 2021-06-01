using System;

namespace TauCode.Xml.Unbound
{
    public class UnboundChildElementDescriptor : IChildElementDescriptor
    {
        public string ElementName { get; }
        public Type ElementType { get; }
        public int MinOccurrence { get; }
        public int? MaxOccurrence { get; }
    }
}
