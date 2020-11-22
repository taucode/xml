using System.Collections.Generic;
using TauCode.Xml.Omicron.Attributes;

namespace TauCode.Xml.Omicron.Tests.Nuspec
{
    public class Group
    {
        [XmlAttributeProperty(IsCamelCase = true)]
        public string TargetFramework { get; set; }

        [XmlAttributeProperty(IsCamelCase = true)]
        public IList<Dependency> Dependencies { get; } = new List<Dependency>();
    }
}
