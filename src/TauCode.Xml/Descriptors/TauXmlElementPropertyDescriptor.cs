using System.Reflection;

namespace TauCode.Xml.Descriptors
{
    public sealed class TauXmlElementPropertyDescriptor
    {
        public PropertyInfo Property { get; }
        public TauXmlElementDescriptor ElementDescriptor { get; }
    }
}
