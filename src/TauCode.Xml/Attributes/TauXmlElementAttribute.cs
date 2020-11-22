using System;

namespace TauCode.Xml.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class TauXmlElementAttribute : Attribute
    {
        public TauXmlElementAttribute()
        {   
        }

        public string ElementName { get; set; }
        public bool IsCamelCase { get; set; }
        //public Type[] ChildTypes { get; set; }
    }
}
