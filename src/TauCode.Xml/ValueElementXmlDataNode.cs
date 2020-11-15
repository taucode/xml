using System;
using System.Collections.Generic;

namespace TauCode.Xml
{
    public class ValueElementXmlDataNode : IXmlDataNode
    {
        public ValueElementXmlDataNode()
        {
            TextNode = new TextXmlDataNode();
        }

        public string Value
        {
            get => this.TextNode.Text;
            set => this.TextNode.Text = value;
        }

        public TextXmlDataNode TextNode { get; }

        public IList<IXmlDataNode> ChildNodes
        {
            get => new List<IXmlDataNode>(new[] { this.TextNode });
            set => throw new InvalidOperationException();
        }
    }
}
