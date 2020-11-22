using System;
using System.Collections.Generic;

namespace TauCode.Xml.Descriptors
{
    public sealed class TauXmlElementDescriptor
    {
        internal TauXmlElementDescriptor(string elementName, Type elementType)
        {
            this.ElementName = elementName;
            this.ElementType = elementType;
        }

        public string ElementName { get; }
        public Type ElementType { get; }
        public IReadOnlyList<TauXmlElementPropertyDescriptor> ChildElementDescriptors { get; } = new List<TauXmlElementPropertyDescriptor>();
        public IReadOnlyList<ValueElementDescriptor> ValueElementDescriptors { get; } = new List<ValueElementDescriptor>();
        public IReadOnlyList<TauXmlAttributeDescriptor> AttributeDescriptors { get; } = new List<TauXmlAttributeDescriptor>();
    }
}
