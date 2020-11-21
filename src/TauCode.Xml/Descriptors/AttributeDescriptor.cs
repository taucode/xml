using System.Reflection;

namespace TauCode.Xml.Descriptors
{
    public sealed class AttributeDescriptor
    {
        public string AttributeName { get; }
        public PropertyInfo Property { get; }
    }
}
