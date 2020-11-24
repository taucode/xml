using TauCode.Xml.Attributes;

namespace TauCode.Xml.Tests.Nuspec
{
    public class File
    {
        [XmlAttributeProperty(IsCamelCase = true)]
        public string Src { get; set; }

        [XmlAttributeProperty(IsCamelCase = true)]
        public string Target { get; set; }
    }
}
