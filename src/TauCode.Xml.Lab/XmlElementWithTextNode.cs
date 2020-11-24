using System;
using System.Collections.Generic;

namespace TauCode.Xml.Lab
{
    public sealed class XmlElementWithTextNode : IXmlElementWithTextNode
    {
        #region Fields

        private readonly Dictionary<string, string> _attributes;

        #endregion

        #region Constructor

        public XmlElementWithTextNode()
        {
            _attributes = new Dictionary<string, string>();
        }

        #endregion

        #region IXmlElementWithTextNode Members

        public void SetAttribute(string attributeName, string attributeValue)
        {
            throw new NotImplementedException();
        }

        public string GetAttribute(string attributeName)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyList<string> GetAttributeNames()
        {
            throw new NotImplementedException();
        }

        public string Value { get; set; }

        #endregion
    }
}
