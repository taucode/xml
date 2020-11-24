using TauCode.Xml.Attributes;

namespace TauCode.Xml.Tests.NetFrameworkCsProj
{
    public class Content
    {
        [XmlAttributeProperty]
        public string Include { get; set; }

        [XmlElementProperty]
        public string CopyToOutputDirectory { get; set; }
    }
}
