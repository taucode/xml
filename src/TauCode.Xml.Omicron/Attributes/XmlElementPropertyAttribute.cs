using System;

namespace TauCode.Xml.Omicron.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class XmlElementPropertyAttribute : Attribute, IXmlNameSource
    {
        public string XmlName { get; set; }
        public bool IsCamelCase { get; set; }
    }
}
