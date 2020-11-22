//using System;
//using System.Collections.Generic;

//namespace TauCode.Xml
//{
//    public abstract class ValueElementXmlDataNode : ITauXmlNode
//    {
//        protected ValueElementXmlDataNode()
//        {
//            TextNode = new TauXmlText();
//        }

//        public string Value
//        {
//            get => this.TextNode.Text;
//            set => this.TextNode.Text = value;
//        }

//        public TauXmlText TextNode { get; }

//        public IList<ITauXmlNode> ChildNodes
//        {
//            get => new List<ITauXmlNode>(new[] { this.TextNode });
//            set => throw new InvalidOperationException();
//        }
//    }
//}

// todo clean
