using TauCode.Xml.Omicron.Attributes;

namespace TauCode.Xml.Omicron.Tests.Nuspec
{
    public class File
    {
        [XmlAttributeProperty(IsCamelCase = true)]
        public string Src { get; set; }

        [XmlAttributeProperty(IsCamelCase = true)]
        public string Target { get; set; }
    }
}
