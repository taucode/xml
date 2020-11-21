using System.Collections.Generic;

namespace TauCode.Xml.Tests.Nuspec
{
    [ElementXmlData(
        IsCamelCase = true,
        ChildTypes = new []
        {
            typeof(Group),
            typeof(Dependency)
        })]
    public class Dependencies : ElementXmlDataNode
    {
        public IList<Group> Groups { get; set; } = new List<Group>();
    }
}
