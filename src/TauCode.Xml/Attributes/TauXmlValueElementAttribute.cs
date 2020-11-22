using System;

namespace TauCode.Xml.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class TauXmlValueElementAttribute : Attribute
    {
        public bool IsCamelCase { get; set; }
    }
}
