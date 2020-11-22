using System.Collections.Generic;

namespace TauCode.Xml.Omicron.Descriptors
{
    public sealed class ElementDescriptor
    {
        public IReadOnlyDictionary<string, AttributePropertyDescriptor> AttributeProperties { get; }
        public IReadOnlyDictionary<string, ElementPropertyDescriptor> ElementProperties { get; }
    }
}
