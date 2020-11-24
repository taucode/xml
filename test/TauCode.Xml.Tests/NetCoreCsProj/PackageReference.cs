using TauCode.Xml.Attributes;

namespace TauCode.Xml.Tests.NetCoreCsProj
{
    public class PackageReference
    {
        [XmlAttributeProperty]
        public string Include { get; set; }

        [XmlAttributeProperty]
        public string Version { get; set; }

        [XmlElementProperty]
        public string PrivateAssets { get; set; }

        [XmlElementProperty]
        public string IncludeAssets { get; set; }
    }
}
