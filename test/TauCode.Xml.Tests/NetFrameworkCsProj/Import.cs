using TauCode.Xml.Attributes;

namespace TauCode.Xml.Tests.NetFrameworkCsProj
{
    public class Import
    {
        [XmlAttributeProperty]
        public string Project { get; set; }

        [XmlAttributeProperty]
        public string Condition { get; set; }
    }
}
