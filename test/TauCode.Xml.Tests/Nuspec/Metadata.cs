using TauCode.Xml.Attributes;

namespace TauCode.Xml.Tests.Nuspec
{
    [TauXmlElement(IsCamelCase = true)]
    public class Metadata : TauXmlElement
    {
        [TauXmlValueElement(IsCamelCase = true)]
        public string Id { get; set; }

        [TauXmlValueElement(IsCamelCase = true)]
        public string Version { get; set; }

        [TauXmlValueElement(IsCamelCase = true)]
        public string Authors { get; set; }

        [TauXmlValueElement(IsCamelCase = true)]
        public string Owners { get; set; }

        [TauXmlValueElement(IsCamelCase = true)]
        public string RequireLicenseAcceptance { get; set; }

        public License License { get; set; }

        [TauXmlValueElement(IsCamelCase = true)]
        public string ProjectUrl { get; set; }

        [TauXmlValueElement(IsCamelCase = true)]
        public string Description { get; set; }

        [TauXmlValueElement(IsCamelCase = true)]
        public string ReleaseNotes { get; set; }

        [TauXmlValueElement(IsCamelCase = true)]
        public string Tags { get; set; }

        public DependenciesElement Dependencies { get; set; }
    }
}
