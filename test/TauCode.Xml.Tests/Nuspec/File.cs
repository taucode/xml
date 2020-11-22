using TauCode.Xml.Attributes;

namespace TauCode.Xml.Tests.Nuspec
{
    public class File : TauXmlElement
    {
        [TauXmlAttribute(IsCamelCase = true)]
        public string Src { get; set; }

        [TauXmlAttribute(IsCamelCase = true)]
        public string Target { get; set; }
    }
}
