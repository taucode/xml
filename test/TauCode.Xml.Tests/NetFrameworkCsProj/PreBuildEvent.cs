using TauCode.Xml.Attributes;

namespace TauCode.Xml.Tests.NetFrameworkCsProj
{
    public class PreBuildEvent
    {
        [XmlInnerText]
        public string Value { get; set; }
    }
}
