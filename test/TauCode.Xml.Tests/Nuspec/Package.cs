using TauCode.Xml.Attributes;

namespace TauCode.Xml.Tests.Nuspec
{
    [TauXmlElement(IsCamelCase = true)]
    public class Package : TauXmlElement
    {
        public Metadata Metadata { get; set; }
        public Files Files { get; set; }
    }
}
