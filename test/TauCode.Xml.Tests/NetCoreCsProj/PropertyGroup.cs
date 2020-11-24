using TauCode.Xml.Attributes;

namespace TauCode.Xml.Tests.NetCoreCsProj
{
    public class PropertyGroup
    {
        [XmlElementProperty]
        public string TargetFramework { get; set; }

        [XmlElementProperty]
        public string IsPackable { get; set; }

        [XmlElementProperty]
        public string AssemblyName { get; set; }

        [XmlElementProperty]
        public string RootNamespace { get; set; }
    }
}
