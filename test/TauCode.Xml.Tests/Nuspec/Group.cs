using System.Collections.Generic;
using TauCode.Xml.Attributes;

namespace TauCode.Xml.Tests.Nuspec
{
    public class Group
    {
        [XmlAttributeProperty(IsCamelCase = true)]
        public string TargetFramework { get; set; }

        [XmlElementProperty(XmlName = "dependency")]
        public IList<Dependency> Dependencies { get; } = new List<Dependency>();
    }
}
