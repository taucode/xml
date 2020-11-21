using System;
using System.Collections.Generic;

namespace TauCode.Xml
{
    public sealed class TextXmlDataNode : IXmlDataNode
    {
        public TextXmlDataNode()
        {
        }

        public string Text { get; set; }

        public IList<IXmlDataNode> ChildNodes
        {
            get => null;
            set => throw new InvalidOperationException();
        }
    }
}
