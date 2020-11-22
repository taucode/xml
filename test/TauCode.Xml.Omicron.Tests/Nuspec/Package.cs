using TauCode.Xml.Omicron.Attributes;

namespace TauCode.Xml.Omicron.Tests.Nuspec
{
    public class Package
    {
        [XmlElementProperty(IsCamelCase = true)]
        public Metadata Metadata { get; set; }

        [XmlElementProperty(IsCamelCase = true)]
        public FilesElement Files { get; set; }
    }
}
