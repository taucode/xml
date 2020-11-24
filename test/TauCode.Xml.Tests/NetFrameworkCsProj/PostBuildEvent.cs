using TauCode.Xml.Attributes;

namespace TauCode.Xml.Tests.NetFrameworkCsProj
{
    public class PostBuildEvent
    {
        [XmlInnerText]
        public string Value { get; set; }
    }
}
