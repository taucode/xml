namespace TauCode.Xml.Tests;

public class PackageNuspec
{
    public class LicenseElement
    {
        public string type { get; set; }

        [InnerText]
        public string FileName { get; set; }
    }

    public class RepositoryElement
    {
        public string type { get; set; }
        public string url { get; set; }
    }

    public class DependenciesElement
    {
        [PropertyElement("group")]
        public List<GroupElement> Groups { get; set; }
    }

    public class GroupElement
    {
        public string targetFramework { get; set; }

        [PropertyElement("dependency")]
        public List<DependencyElement> Dependencies { get; set; }
    }

    public class DependencyElement
    {
        public string id { get; set; }
        public string version { get; set; }
    }

    public class MetadataElement
    {
        [PropertyElement]
        public string id { get; set; }

        [PropertyElement]
        public string version { get; set; }

        [PropertyElement]
        public string authors { get; set; }

        [PropertyElement]
        public string owners { get; set; }

        [PropertyElement]
        public bool? requireLicenseAcceptance { get; set; }

        public LicenseElement license { get; set; }

        [PropertyElement]
        public string projectUrl { get; set; }

        public RepositoryElement repository { get; set; }

        [PropertyElement]
        public string description { get; set; }

        [PropertyElement]
        public string releaseNotes { get; set; }

        [PropertyElement]
        public string tags { get; set; }

        public DependenciesElement dependencies { get; set; }
    }

    public class FilesElement
    {
        [PropertyElement("file")]
        public List<FileElement> files { get; set; }
    }

    public class FileElement
    {
        public string src { get; set; }
        public string target { get; set; }
    }

    public MetadataElement metadata { get; set; }
    public FilesElement files { get; set; }
}