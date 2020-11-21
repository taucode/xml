namespace TauCode.Xml.Tests.Nuspec
{
    public class Dependency : ElementXmlDataNode
    {
        [XmlDataAttribute(IsCamelCase = true)]
        public string Id { get; set; }

        [XmlDataAttribute(IsCamelCase = true)]
        public string Version { get; set; }
    }
}
