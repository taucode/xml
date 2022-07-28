using System;

namespace TauCode.Xml
{
    [AttributeUsage(AttributeTargets.Property)]
    public class AttributeAttribute : Attribute
    {
        public AttributeAttribute(string propertyName = null)
        {
            this.PropertyName = propertyName;
        }

        public string PropertyName { get; }
    }
}
