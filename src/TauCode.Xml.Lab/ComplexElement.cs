using System;
using System.Collections.Generic;
using System.Linq;

namespace TauCode.Xml.Lab
{
    public class ComplexElement : IComplexElement
    {
        #region Fields

        private readonly Dictionary<string, string> _attributes; // todo copy-paste
        private readonly ElementList _children;

        #endregion

        #region Constructor

        public ComplexElement(IElementSchema schema)
        {
            // todo checks

            this.Schema = schema;
            this.Name = this.Schema.ElementName;
            _attributes = new Dictionary<string, string>();
            _children = new ElementList(this);
        }

        #endregion

        #region IXmlElement Members

        public IElementSchema Schema { get; }

        public string Name { get; }

        public void SetAttribute(string attributeName, string attributeValue)
        {
            // todo checks

            _attributes[attributeName] = attributeValue;
        }

        public string GetAttribute(string attributeName)
        {
            // todo checks

            return _attributes.GetValueOrDefault(attributeName);
        }

        public IReadOnlyList<string> GetAttributeNames() => _attributes.Keys.ToList();

        #endregion

        #region IXmlElementWithChildren Members

        public IList<IElement> Children => _children;
        public IElement AddChildElement(string elementName)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
