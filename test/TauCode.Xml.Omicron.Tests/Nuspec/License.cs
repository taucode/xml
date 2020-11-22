using TauCode.Xml.Omicron.Attributes;

namespace TauCode.Xml.Omicron.Tests.Nuspec
{
    public class License
    {
        [XmlAttributeProperty(IsCamelCase = true)]
        public string Type { get; set; }

        [XmlInnerText]
        public string Value { get; set; }
    }
}
