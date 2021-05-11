using System;

namespace TauCode.Xml
{
    [AttributeUsage(AttributeTargets.Property)]
    public class AttributeValueAttribute : Attribute
    {
        public AttributeValueAttribute(string attributeName)
        {
            this.AttributeName = attributeName;
        }

        public string AttributeName { get; }

        // todo: IsMandatory (smart)
    }
}
