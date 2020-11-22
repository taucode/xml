using System.Reflection;

namespace TauCode.Xml.Omicron.Descriptors
{
    public sealed class AttributePropertyDescriptor
    {
        public string AttributeName { get; }
        public PropertyInfo Property { get; }
    }
}
