using TauCode.Xml.Attributes;

namespace TauCode.Xml.Tests.NetFrameworkCsProj
{
    public class Error
    {
        [XmlAttributeProperty]
        public string Condition { get; set; }

        [XmlAttributeProperty]
        public string Text { get; set; }
    }
}
