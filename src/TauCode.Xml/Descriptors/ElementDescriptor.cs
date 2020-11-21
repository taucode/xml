using System;
using System.Collections.Generic;

namespace TauCode.Xml.Descriptors
{
    public sealed class ElementDescriptor
    {
        public string ElementName { get; }
        public Type ElementType { get; }
        public IReadOnlyList<ElementDescriptor> ChildElementDescriptors { get; }
        public IReadOnlyList<ValueElementDescriptor> ValueElementDescriptors { get; }
        public IReadOnlyList<AttributeDescriptor> AttributeDescriptors { get; }
    }
}
