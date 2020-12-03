using System;
using System.Collections.Generic;
using System.Linq;
using TauCode.Xml.Lab.Schemas;

namespace TauCode.Xml.Lab.Fluent
{
    public class ElementSchemaBuilder
    {
        private readonly ElementSchemaBuilder _parent;
        private readonly Dictionary<string, ElementSchemaBuilder> _children;

        public string ElementName { get; }

        public Type ElementType { get; }

        public bool IsComplex { get; }

        public IReadOnlyList<string> AttributeNames { get; set; }

        public ElementSchemaBuilder(string elementName, Type elementType, params string[] attributeNames)
        {
            // todo checks
            _children = new Dictionary<string, ElementSchemaBuilder>();

            this.ElementName = elementName;
            this.ElementType = elementType;
            this.IsComplex = true;
            this.AttributeNames = attributeNames.ToList();
        }

        internal ElementSchemaBuilder(
            ElementSchemaBuilder parent,
            string elementName,
            Type elementType,
            params string[] attributeNames)
            : this(elementName, elementType, attributeNames)
        {
            _parent = parent;
        }

        public ElementSchemaBuilder AddChildElement(
            string elementName,
            Type elementType,
            params string[] attributeNames)
        {
            // todo checks

            var child = new ElementSchemaBuilder(this, elementName, elementType, attributeNames);
            _children.Add(elementName, child);

            return child;
        }

        public ElementSchemaBuilder AddTextNodeChildElement(string elementName, params string[] attributeNames)
        {
            var textNodeSchemaBuilder = new ElementSchemaBuilder(this, elementName, typeof(TextNodeElement), attributeNames);
            _children.Add(elementName, textNodeSchemaBuilder);

            return this;
        }

        public ElementSchemaBuilder GetParent() => _parent;

        public IElementSchema Build()
        {
            if (_parent == null)
            {
                return this.BuildImpl();
            }
            else
            {
                return _parent.Build();
            }
        }

        private IElementSchema BuildImpl()
        {
            IElementSchema schema;

            if (this.ElementType == typeof(TextNodeElement))
            {
                schema = new TextNodeElementSchema(this.ElementName);
            }
            else
            {
                schema = new ComplexElementSchema(this.ElementName, this.ElementType);

                foreach (var childBuilder in _children.Values)
                {
                    var childSchema = childBuilder.BuildImpl();
                    schema.AddChildElement(childSchema);
                }
            }

            foreach (var attributeName in this.AttributeNames)
            {
                schema.AddAttribute(attributeName);
            }

            return schema;
        }
    }
}