using System.Collections.Generic;

namespace TauCode.Xml.Tests.Nuspec
{
    [ElementXmlData(
        IsCamelCase = true,
        ChildTypes = new []
        {
            typeof(Dependency),
        })]
    public class Group : ElementXmlDataNode
    {
        [XmlDataAttribute(IsCamelCase = true)]
        public string TargetFramework { get; set; }

        public IList<Dependency> Dependencies { get; set; } = new List<Dependency>();
    }
}
