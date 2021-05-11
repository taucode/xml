using System.Xml.Serialization;

namespace TauCode.Xml
{
    public abstract class TextNodeElementBase : ElementBase, ITextNodeElement
    {
        [XmlIgnore]
        public string Value { get; set; }
    }
}
