using System.Collections.Generic;
using TauCode.Xml.Attributes;

namespace TauCode.Xml.Tests.Nuspec
{
    [TauXmlElement(ElementName = "dependencies")]
    public class DependenciesElement : TauXmlElement
    {
        public IList<Group> Groups { get; set; } = new List<Group>();
        public IList<Dependency> Dependencies { get; set; } = new List<Dependency>();
    }
}
