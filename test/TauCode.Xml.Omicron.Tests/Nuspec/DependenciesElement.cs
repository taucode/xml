using System.Collections.Generic;

namespace TauCode.Xml.Omicron.Tests.Nuspec
{
    public class DependenciesElement
    {
        public IList<Group> Groups { get; } = new List<Group>();
        public IList<Dependency> Dependencies { get; } = new List<Dependency>();
    }
}
