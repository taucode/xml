namespace TauCode.Xml.Tests.Nuspec
{
    [ElementXmlData(
        IsCamelCase = true,
        ChildTypes = new []
        {
            typeof(Id),
            typeof(Version),
            typeof(Authors),
            typeof(Owners),
            typeof(RequireLicenseAcceptance),
            typeof(License),
            typeof(ProjectUrl),
            typeof(Description),
            typeof(ReleaseNotes),
            typeof(Tags),
            typeof(Dependencies)
        })]
    public class Metadata : ElementXmlDataNode
    {
        public Id Id { get; set; }
        public Version Version { get; set; }
        public Authors Authors { get; set; }
        public Owners Owners { get; set; }
        public RequireLicenseAcceptance RequireLicenseAcceptance { get; set; }
        public License License { get; set; }
        public ProjectUrl ProjectUrl { get; set; }
        public Description Description { get; set; }
        public ReleaseNotes ReleaseNotes { get; set; }
        public Tags Tags { get; set; }
        public Dependencies Dependencies { get; set; }
    }
}
