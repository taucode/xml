using System;

namespace TauCode.Xml.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class TauXmlAttributeAttribute : Attribute
    {
        public string Name { get; set; }
        public bool IsCamelCase { get; set; }
    }
}
