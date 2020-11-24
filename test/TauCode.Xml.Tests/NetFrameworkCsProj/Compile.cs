using TauCode.Xml.Attributes;

namespace TauCode.Xml.Tests.NetFrameworkCsProj
{
    public class Compile
    {
        [XmlAttributeProperty]
        public string Include { get; set; }

        [XmlElementProperty]
        public string DependentUpon { get; set; }
    }
}
