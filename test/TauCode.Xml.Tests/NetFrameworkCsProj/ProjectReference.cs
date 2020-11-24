using TauCode.Xml.Attributes;

namespace TauCode.Xml.Tests.NetFrameworkCsProj
{
    public class ProjectReference
    {
        [XmlAttributeProperty]
        public string Include { get; set; }

        [XmlElementProperty]
        public string Project { get; set; }

        [XmlElementProperty]
        public string Name { get; set; }
    }
}
