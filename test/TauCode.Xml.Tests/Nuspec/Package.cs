namespace TauCode.Xml.Tests.Nuspec
{
    [ElementXmlData(
        IsCamelCase = true,
        ChildTypes = new []
        {
            typeof(Metadata),
            typeof(Files),
        })]
    public class Package : ElementXmlDataNode
    {
        public Metadata Metadata { get; set; }
        public Files Files { get; set; }
    }
}
