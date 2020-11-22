using TauCode.Xml.Omicron.Attributes;

namespace TauCode.Xml.Omicron.Tests.Nuspec
{
    public class Dependency
    {
        [XmlAttributeProperty(IsCamelCase = true)]
        public string Id { get; set; }

        [XmlAttributeProperty(IsCamelCase = true)]
        public string Version { get; set; }
    }
}
