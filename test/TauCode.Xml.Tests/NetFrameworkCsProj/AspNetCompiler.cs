using TauCode.Xml.Attributes;

namespace TauCode.Xml.Tests.NetFrameworkCsProj
{
    public class AspNetCompiler
    {
        [XmlAttributeProperty]
        public string VirtualPath { get; set; }

        [XmlAttributeProperty]
        public string PhysicalPath { get; set; }
    }
}
