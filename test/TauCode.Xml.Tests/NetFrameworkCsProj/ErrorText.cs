using TauCode.Xml.Attributes;

namespace TauCode.Xml.Tests.NetFrameworkCsProj
{
    public class ErrorText
    {
        [XmlInnerText]
        public string Value { get; set; }
    }
}
