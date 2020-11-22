using System.Reflection;

namespace TauCode.Xml.Omicron.Descriptors
{
    public sealed class ElementPropertyDescriptor
    {
        public ElementPropertyKind Kind { get; }
        public string ElementName { get; }
        public PropertyInfo Property { get; }
        public ElementDescriptor Element { get; }
    }
}
