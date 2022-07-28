using System;

namespace TauCode.Xml
{
    [AttributeUsage(AttributeTargets.Property)]
    public class PropertyElementAttribute : Attribute
    {
        public PropertyElementAttribute(string propertyName = null)
        {
            this.PropertyName = propertyName;
        }

        public string PropertyName { get; set; }
    }
}
