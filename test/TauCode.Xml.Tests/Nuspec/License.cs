using TauCode.Xml.Attributes;

namespace TauCode.Xml.Tests.Nuspec
{
    public class License : TauXmlElement
    {
        [TauXmlAttribute(IsCamelCase = true)]
        public string Type { get; set; }
    }
}
