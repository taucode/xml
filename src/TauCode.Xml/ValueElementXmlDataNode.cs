using System;
using System.Collections.Generic;

namespace TauCode.Xml
{
    public abstract class ValueElementXmlDataNode : IXmlDataNode
    {
        protected ValueElementXmlDataNode()
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
