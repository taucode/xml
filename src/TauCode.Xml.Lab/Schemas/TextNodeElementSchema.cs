using System;
using System.Collections.Generic;
using System.Linq;

namespace TauCode.Xml.Lab.Schemas
{
    internal class TextNodeElementSchema : IElementSchema
    {
        private readonly HashSet<string> _attributeNames;

        internal TextNodeElementSchema(string elementName)
        {
            _attributeNames = new HashSet<string>();
            this.ElementName = elementName ?? throw new ArgumentNullException(nameof(elementName));
        }

        public string ElementName { get; }
        public Type ElementType => typeof(TextNodeElement);

        public IReadOnlyList<string> GetAttributes() => _attributeNames.ToList();

        public void AddAttribute(string attributeName)
        {
            if (attributeName == null)
            {
                throw new ArgumentNullException(nameof(attributeName));
            }

            if (_attributeNames.Contains(attributeName))
            {
                throw new NotImplementedException();
            }

            _attributeNames.Add(attributeName);
        }

        public bool RemoveAttribute(string attributeName)
        {
            if (attributeName == null)
            {
                throw new ArgumentNullException(nameof(attributeName));
            }

            return _attributeNames.Remove(attributeName);
        }

        public bool ContainsAttribute(string attributeName)
        {
            if (attributeName == null)
            {
                throw new ArgumentNullException(nameof(attributeName));
            }

            return _attributeNames.Contains(attributeName);
        }

        public IReadOnlyList<IElementSchema> GetChildElements() => new IElementSchema[] { };

        public void AddChildElement(IElementSchema childElementSchema) => throw new NotImplementedException(); // not supported

        public bool RemoveChildElement(string childElementName) => throw new NotImplementedException();

        public bool ContainsChildElement(string childElementName) => false;
        public IElementSchema GetChildElement(string childElementName)
        {
            throw new NotImplementedException();
        }

        //public bool ContainsTextNode => true;
    }
}
