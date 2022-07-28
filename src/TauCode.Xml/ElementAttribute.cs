using System;

namespace TauCode.Xml
{
    [AttributeUsage(AttributeTargets.Class)]
    public class ElementAttribute : Attribute
    {
        public ElementAttribute(string elementName)
        {
            this.ElementName = elementName ?? throw new ArgumentNullException(nameof(elementName));
        }

        public string ElementName { get; set; }
    }
}
