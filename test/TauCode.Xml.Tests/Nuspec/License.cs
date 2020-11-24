using TauCode.Xml.Attributes;

namespace TauCode.Xml.Tests.Nuspec
{
    public class License
    {
        [XmlAttributeProperty(IsCamelCase = true)]
        public string Type { get; set; }

        [XmlInnerText]
        public string Value { get; set; }
    }
}
