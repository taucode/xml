using System;
using System.Collections.Generic;

namespace TauCode.Xml.Lab
{
    public class ComplexElement : IComplexElement
    {
        #region Fields

        private readonly ElementList _children;

        #endregion

        #region Constructor

        public ComplexElement(IElementSchema schema)
        {
            // todo checks

            this.Schema = schema;
            this.Name = this.Schema.ElementName;
            _children = new ElementList(this);
        }

        #endregion

        #region IXmlElement Members

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

        #region IXmlElementWithChildren Members

        public IList<IElement> Children => _children;

        #endregion
    }
}
