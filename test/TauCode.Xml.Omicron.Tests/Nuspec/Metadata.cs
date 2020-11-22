using TauCode.Xml.Omicron.Attributes;

namespace TauCode.Xml.Omicron.Tests.Nuspec
{
    public class Metadata
    {
        [XmlElementProperty(IsCamelCase = true)]
        public string Id { get; set; }

        [XmlElementProperty(IsCamelCase = true)]
        public string Version { get; set; }

        [XmlElementProperty(IsCamelCase = true)]
        public string Authors { get; set; }

        [XmlElementProperty(IsCamelCase = true)]
        public string Owners { get; set; }

        [XmlElementProperty(IsCamelCase = true)]
        public string RequireLicenseAcceptance { get; set; }

        [XmlElementProperty(IsCamelCase = true)]
        public License License { get; set; }

        [XmlElementProperty(IsCamelCase = true)]
        public string ProjectUrl { get; set; }

        [XmlElementProperty(IsCamelCase = true)]
        public string Description { get; set; }

        [XmlElementProperty(IsCamelCase = true)]
        public string ReleaseNotes { get; set; }

        [XmlElementProperty(IsCamelCase = true)]
        public string Tags { get; set; }

        [XmlElementProperty(IsCamelCase = true)]
        public DependenciesElement Dependencies { get; set; }
    }
}
