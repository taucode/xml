using TauCode.Xml.Attributes;

namespace TauCode.Xml.Tests.NetFrameworkCsProj
{
    public class FlavorProperties
    {
        [XmlAttributeProperty]
        public string GUID { get; set; }

        [XmlElementProperty]
        public WebProjectProperties WebProjectProperties { get; set; }
    }

}
