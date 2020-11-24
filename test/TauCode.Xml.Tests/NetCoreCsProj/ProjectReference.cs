using TauCode.Xml.Attributes;

namespace TauCode.Xml.Tests.NetCoreCsProj
{
    public class ProjectReference
    {
        [XmlAttributeProperty]
        public string Include { get; set; }
    }
}
