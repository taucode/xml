using System;

namespace TauCode.Xml
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class XmlDataAttributeAttribute : Attribute
    {
        public string Name { get; set; }
        public bool IsCamelCase { get; set; }
    }
}
