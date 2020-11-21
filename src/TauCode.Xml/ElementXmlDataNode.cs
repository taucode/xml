using System.Collections.Generic;

namespace TauCode.Xml
{
    public abstract class ElementXmlDataNode : IXmlDataNode
    {
        public IList<IXmlDataNode> ChildNodes { get; set; } = new List<IXmlDataNode>();
        public IDictionary<string, string> Attributes { get; set; } = new Dictionary<string, string>();
    }
}
