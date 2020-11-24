using TauCode.Xml.Attributes;

namespace TauCode.Xml.Tests.NetFrameworkCsProj
{
    public class WCFMetadata
    {
        [XmlAttributeProperty]
        public string Include { get; set; }
    }
}
