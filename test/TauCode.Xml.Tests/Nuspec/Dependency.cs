using TauCode.Xml.Attributes;

namespace TauCode.Xml.Tests.Nuspec
{
    public class Dependency
    {
        [XmlAttributeProperty(IsCamelCase = true)]
        public string Id { get; set; }

        [XmlAttributeProperty(IsCamelCase = true)]
        public string Version { get; set; }
    }
}
