using System;

namespace TauCode.Xml.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class XmlAttributePropertyAttribute : Attribute, IXmlNameSource
    {
        public string XmlName { get; set; }
        public bool IsCamelCase { get; set; }
    }
}
