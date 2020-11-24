using System.Collections.Generic;
using TauCode.Xml.Attributes;

namespace TauCode.Xml.Tests.NetFrameworkCsProj
{
    [XmlDocumentDeclaration]
    public class Project
    {
        [XmlAttributeProperty]
        public string ToolsVersion { get; set; }

        [XmlAttributeProperty]
        public string DefaultTargets { get; set; }

        [XmlAttributeProperty(IsCamelCase = true)]
        public string Xmlns { get; set; }

        [XmlElementProperty]
        public IList<Import> Import { get; set; } = new List<Import>();

        [XmlElementProperty]
        public IList<PropertyGroup> PropertyGroup { get; set; } = new List<PropertyGroup>();

        [XmlElementProperty]
        public IList<ItemGroup> ItemGroup { get; set; } = new List<ItemGroup>();

        [XmlElementProperty]
        public IList<Target> Target { get; set; } = new List<Target>();

        [XmlElementProperty]
        public ProjectExtensions ProjectExtensions { get; set; }
    }
}
