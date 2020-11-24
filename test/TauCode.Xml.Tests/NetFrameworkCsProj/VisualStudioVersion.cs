using TauCode.Xml.Attributes;

namespace TauCode.Xml.Tests.NetFrameworkCsProj
{
    public class VisualStudioVersion
    {
        [XmlAttributeProperty]
        public string Condition { get; set; }

        [XmlInnerText]
        public string Value { get; set; }

    }
}
