using System;

namespace TauCode.Xml
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class ElementXmlDataAttribute : Attribute
    {
        public ElementXmlDataAttribute()
        {   
        }

        public string ElementName { get; set; }
        public bool IsCamelCase { get; set; }
        public Type[] ChildTypes { get; set; }
    }
}
