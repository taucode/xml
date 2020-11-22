using System.Reflection;

namespace TauCode.Xml.Omicron.Descriptors
{
    public sealed class ElementPropertyDescriptor
    {
        internal ElementPropertyDescriptor(
            ElementPropertyKind kind,
            string elementName,
            PropertyInfo property,
            ElementDescriptor element)
        {
            this.Kind = kind;
            this.ElementName = elementName;
            this.Property = property;
            this.Element = element;
        }

        public ElementPropertyKind Kind { get; }
        public string ElementName { get; }
        public PropertyInfo Property { get; }
        public ElementDescriptor Element { get; }
    }
}
