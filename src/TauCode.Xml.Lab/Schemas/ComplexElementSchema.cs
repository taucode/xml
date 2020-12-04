using System;
using System.Collections.Generic;
using System.Linq;

namespace TauCode.Xml.Lab.Schemas
{
    internal class ComplexElementSchema : IElementSchema
    {
        private readonly HashSet<string> _attributeNames;
        private readonly Dictionary<string, IElementSchema> _childSchemas;

        internal ComplexElementSchema(string elementName, Type elementType)
        {
            // todo check args

            this.ElementName = elementName;
            this.ElementType = elementType;

            _attributeNames = new HashSet<string>();
            _childSchemas = new Dictionary<string, IElementSchema>();
        }

        public string ElementName { get; }
        public Type ElementType { get; }

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

        public IReadOnlyList<IElementSchema> GetChildElements() => _childSchemas.Values.ToList();

        public void AddChildElement(IElementSchema childElementSchema)
        {
            // todo checks

            _childSchemas.Add(childElementSchema.ElementName, childElementSchema);
        }

        public bool RemoveChildElement(string childElementName)
        {
            // todo checks

            return _childSchemas.Remove(childElementName);
        }

        public bool ContainsChildElement(string childElementName)
        {
            // todo checks

            return _childSchemas.ContainsKey(childElementName);
        }

        public IElementSchema GetChildElement(string childElementName)
        {
            // todo checks

            var childSchema = _childSchemas.GetValueOrDefault(childElementName);
            if (childSchema == null)
            {
                throw new NotImplementedException();
            }

            return childSchema;
        }

        //public bool ContainsTextNode => false;
    }
}
