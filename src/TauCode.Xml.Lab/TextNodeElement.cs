using System;
using System.Collections.Generic;

namespace TauCode.Xml.Lab
{
    public sealed class TextNodeElement : ITextNodeElement
    {
        #region Fields

        private readonly Dictionary<string, string> _attributes;

        #endregion

        #region Constructor

        public TextNodeElement()
        {
            _attributes = new Dictionary<string, string>();
        }

        #endregion

        #region IElement Members

        public IElementSchema Schema { get; }

        public string Name { get; }

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

        #endregion

        #region ITextNodeElement Members

        public string Value { get; set; }

        #endregion
    }
}
