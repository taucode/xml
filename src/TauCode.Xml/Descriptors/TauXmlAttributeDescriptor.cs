using System.Reflection;

namespace TauCode.Xml.Descriptors
{
    public sealed class TauXmlAttributeDescriptor
    {
        public string AttributeName { get; }
        public PropertyInfo Property { get; }
    }
}
