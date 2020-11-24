using TauCode.Xml.Attributes;

namespace TauCode.Xml.Tests.NetFrameworkCsProj
{
    public class WebProjectProperties
    {
        [XmlElementProperty]
        public string UseIIS { get; set; }

        [XmlElementProperty]
        public string AutoAssignPort { get; set; }

        [XmlElementProperty]
        public string DevelopmentServerPort { get; set; }

        [XmlElementProperty]
        public string DevelopmentServerVPath { get; set; }

        [XmlElementProperty]
        public string IISUrl { get; set; }

        [XmlElementProperty]
        public string NTLMAuthentication { get; set; }

        [XmlElementProperty]
        public string UseCustomServer { get; set; }

        [XmlElementProperty]
        public string CustomServerUrl { get; set; }

        [XmlElementProperty]
        public string SaveServerSettingsInUserFile { get; set; }
    }
}
