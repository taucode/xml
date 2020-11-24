using TauCode.Xml.Attributes;

namespace TauCode.Xml.Tests.NetFrameworkCsProj
{
    public class Reference
    {
        [XmlAttributeProperty]
        public string Include { get; set; }

        [XmlElementProperty]
        public string HintPath { get; set; }

        [XmlElementProperty]
        public string Private { get; set; }
    }
}
