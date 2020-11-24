using System.Collections.Generic;
using TauCode.Xml.Omicron.Attributes;

namespace TauCode.Xml.Omicron.Tests.Nuspec
{
    public class DependenciesElement
    {
        [XmlElementProperty(XmlName = "group")]
        public IList<Group> Groups { get; } = new List<Group>();

        [XmlElementProperty(XmlName = "dependency")]
        public IList<Dependency> Dependencies { get; } = new List<Dependency>();
    }
}
