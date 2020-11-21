namespace TauCode.Xml.Tests.Nuspec
{
    public class File : ElementXmlDataNode
    {
        [XmlDataAttribute(IsCamelCase = true)]
        public string Src { get; set; }

        [XmlDataAttribute(IsCamelCase = true)]
        public string Target { get; set; }
    }
}
