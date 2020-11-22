using System.Reflection;

namespace TauCode.Xml.Omicron.Descriptors
{
    public sealed class AttributePropertyDescriptor
    {
        internal AttributePropertyDescriptor(string attributeName, PropertyInfo property)
        {
            this.AttributeName = attributeName;
            this.Property = property;
        }

        public string AttributeName { get; }
        public PropertyInfo Property { get; }
    }
}
