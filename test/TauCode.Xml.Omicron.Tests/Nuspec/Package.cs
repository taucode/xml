using TauCode.Xml.Omicron.Attributes;

namespace TauCode.Xml.Omicron.Tests.Nuspec
{
    [XmlDocumentDeclaration]
    public class Package
    {
        [XmlAttributeProperty(IsCamelCase = true)]
        public string Xmlns { get; set; }

        [XmlElementProperty(IsCamelCase = true)]
        public Metadata Metadata { get; set; }

        [XmlElementProperty(IsCamelCase = true)]
        public FilesElement Files { get; set; }
    }
}
