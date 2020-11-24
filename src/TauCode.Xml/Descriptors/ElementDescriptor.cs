using System;
using System.Collections.Generic;
using System.Reflection;

namespace TauCode.Xml.Descriptors
{
    public sealed class ElementDescriptor
    {
        private readonly Dictionary<string, AttributePropertyDescriptor> _attributeProperties;
        private readonly Dictionary<string, ElementPropertyDescriptor> _elementProperties;
        

        internal ElementDescriptor(Type type)
        {
            this.Type = type;

            _attributeProperties = new Dictionary<string, AttributePropertyDescriptor>();
            _elementProperties = new Dictionary<string, ElementPropertyDescriptor>();
        }

        public Type Type { get; }
        public IReadOnlyDictionary<string, AttributePropertyDescriptor> AttributeProperties => _attributeProperties;
        public IReadOnlyDictionary<string, ElementPropertyDescriptor> ElementProperties => _elementProperties;
        public PropertyInfo InnerTextProperty { get; internal set; }

        internal void AddAttributeProperty(string attrName, PropertyInfo property)
        {
            var propertyDescriptor = new AttributePropertyDescriptor(attrName, property);
            _attributeProperties.Add(attrName, propertyDescriptor);
        }

        internal void AddElementProperty(
            ElementPropertyKind kind,
            string elementName,
            PropertyInfo property,
            ElementDescriptor element)
        {
            var propertyDescriptor = new ElementPropertyDescriptor(kind, elementName, property, element);
            _elementProperties.Add(elementName, propertyDescriptor);
        }

        internal void SetInnerTextProperty(PropertyInfo property)
        {
            if (this.InnerTextProperty != null)
            {
                throw new NotImplementedException();
            }

            if (_elementProperties.Count > 0)
            {
                throw new NotImplementedException();
            }

            this.InnerTextProperty = property;
        }
    }
}
