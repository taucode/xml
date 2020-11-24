using TauCode.Xml.Attributes;

namespace TauCode.Xml.Tests.NetCoreCsProj
{
    public class EmbeddedResource
    {
        [XmlAttributeProperty]
        public string Include { get; set; }
    }
}
