using TauCode.Xml.Attributes;

namespace TauCode.Xml.Tests.Nuspec
{
    public class Dependency : TauXmlElement
    {
        [TauXmlAttribute(IsCamelCase = true)]
        public string Id { get; set; }

        [TauXmlAttribute(IsCamelCase = true)]
        public string Version { get; set; }
    }
}
