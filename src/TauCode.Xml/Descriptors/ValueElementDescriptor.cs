using System.Reflection;

namespace TauCode.Xml.Descriptors
{
    public sealed class ValueElementDescriptor
    {
        public string ElementName { get; set; }
        public PropertyInfo Property { get; set; }
    }
}
