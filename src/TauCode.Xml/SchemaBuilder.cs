using Inflector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using TauCode.Xml.Attributes;
using TauCode.Xml.Descriptors;

namespace TauCode.Xml
{
    public class SchemaBuilder
    {
        private Dictionary<Type, ElementDescriptor> _elements;

        public SchemaDescriptor Build(Type rootType, string rootName)
        {
            if (rootType == null)
            {
                throw new NotImplementedException();
            }

            _elements = new Dictionary<Type, ElementDescriptor>();

            this.BuildOrGet(rootType);

            return new SchemaDescriptor(rootType, rootName, _elements);
        }

        private ElementDescriptor BuildOrGet(Type elementType)
        {
            if (_elements.ContainsKey(elementType))
            {
                return _elements[elementType];
            }

            if (elementType.IsAbstract)
            {
                throw new NotImplementedException();
            }

            if (!elementType.IsClass)
            {
                throw new NotImplementedException();
            }

            var elementDescriptor = new ElementDescriptor(elementType);
            _elements.Add(elementType, elementDescriptor);

            var props = elementType.GetProperties();

            foreach (var prop in props)
            {
                if (IsIgnoredProperty(prop))
                {
                    continue;
                }

                if (prop.PropertyType == typeof(string))
                {
                    this.AddStringProperty(elementDescriptor, prop);
                }
                else if (prop.PropertyType.IsClass)
                {
                    var childElement = this.BuildOrGet(prop.PropertyType);
                    this.AddClassProperty(elementDescriptor, prop, childElement);
                }
                else if (IsStringList(prop))
                {
                    throw new NotImplementedException();
                }
                else if (IsComplexTypeList(prop))
                {
                    var childElement = this.BuildOrGet(prop.PropertyType.GetGenericArguments().Single());
                    this.AddClassListProperty(elementDescriptor, prop, childElement);
                }
                else
                {
                    throw new NotImplementedException();
                }
            }

            return elementDescriptor;
        }

        private static bool IsIgnoredProperty(PropertyInfo property)
        {
            var ignoreAttr = property.GetCustomAttribute<XmlIgnoreAttribute>();
            return ignoreAttr != null;
        }

        private static bool IsComplexTypeList(PropertyInfo property)
        {
            var type = property.PropertyType;
            if (type.IsGenericType)
            {
                var generic = type.GetGenericTypeDefinition();
                if (generic == typeof(IList<>))
                {
                    var arg = type.GetGenericArguments().Single();
                    if (arg.IsClass && !arg.IsAbstract)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private static bool IsStringList(PropertyInfo property)
        {
            var type = property.PropertyType;
            if (type.IsGenericType)
            {
                var generic = type.GetGenericTypeDefinition();
                if (generic == typeof(IList<>))
                {
                    var arg = type.GetGenericArguments().Single();
                    if (arg == typeof(string))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private void AddClassProperty(ElementDescriptor parentElement, PropertyInfo property, ElementDescriptor childElement)
        {
            // todo: check only one attr applied
            var xmlElementPropAttr = property.GetCustomAttribute<XmlElementPropertyAttribute>();
            var elementName = property.Name;

            if (xmlElementPropAttr != null)
            {
                var valid =
                    (xmlElementPropAttr.XmlName != null ^ xmlElementPropAttr.IsCamelCase) ||
                    (xmlElementPropAttr.XmlName == null && !xmlElementPropAttr.IsCamelCase);

                if (!valid)
                {
                    throw new NotImplementedException();
                }

                if (xmlElementPropAttr.XmlName != null)
                {
                    elementName = xmlElementPropAttr.XmlName;
                }

                if (xmlElementPropAttr.IsCamelCase)
                {
                    elementName = elementName.Camelize();
                }
            }

            parentElement.AddElementProperty(ElementPropertyKind.ComplexElement, elementName, property, childElement);
        }

        private void AddClassListProperty(ElementDescriptor parentElement, PropertyInfo property, ElementDescriptor childElement)
        {
            // todo: check only one VALID attr applied

            var xmlElementPropAttr = property.GetCustomAttribute<XmlElementPropertyAttribute>();
            var elementName = property.Name;

            if (xmlElementPropAttr != null)
            {
                var valid =
                    (xmlElementPropAttr.XmlName != null ^ xmlElementPropAttr.IsCamelCase) ||
                    (xmlElementPropAttr.XmlName == null && !xmlElementPropAttr.IsCamelCase);

                if (!valid)
                {
                    throw new NotImplementedException();
                }

                if (xmlElementPropAttr.XmlName != null)
                {
                    elementName = xmlElementPropAttr.XmlName;
                }

                if (xmlElementPropAttr.IsCamelCase)
                {
                    elementName = elementName.Camelize();
                }
            }

            parentElement.AddElementProperty(ElementPropertyKind.ComplexElementList, elementName, property, childElement);
        }

        private void AddStringProperty(ElementDescriptor elementDescriptor, PropertyInfo property)
        {
            // todo: check only one attr applied
            var xmlAttrPropAttr = property.GetCustomAttribute<XmlAttributePropertyAttribute>();
            if (xmlAttrPropAttr != null)
            {
                var attrName = property.Name;
                var valid = 
                    (xmlAttrPropAttr.XmlName != null ^ xmlAttrPropAttr.IsCamelCase) ||
                    (xmlAttrPropAttr.XmlName == null && !xmlAttrPropAttr.IsCamelCase);
                if (!valid)
                {
                    throw new NotImplementedException();
                }

                if (xmlAttrPropAttr.XmlName != null)
                {
                    attrName = xmlAttrPropAttr.XmlName;
                }

                if (xmlAttrPropAttr.IsCamelCase)
                {
                    attrName = attrName.Camelize();
                }

                elementDescriptor.AddAttributeProperty(attrName, property);
            }

            var xmlInnerTextAttr = property.GetCustomAttribute<XmlInnerTextAttribute>();
            if (xmlInnerTextAttr != null)
            {
                elementDescriptor.SetInnerTextProperty(property);
            }

            var xmlElementPropAttr = property.GetCustomAttribute<XmlElementPropertyAttribute>();
            if (xmlElementPropAttr != null)
            {
                var elementName = property.Name;
                //var valid = xmlElementPropAttr.XmlName != null ^ xmlElementPropAttr.IsCamelCase;
                var valid =
                    (xmlElementPropAttr.XmlName != null ^ xmlElementPropAttr.IsCamelCase) ||
                    (xmlElementPropAttr.XmlName == null && !xmlElementPropAttr.IsCamelCase);
                if (!valid)
                {
                    throw new NotImplementedException();
                }

                if (xmlElementPropAttr.XmlName != null)
                {
                    elementName = xmlElementPropAttr.XmlName;
                }

                if (xmlElementPropAttr.IsCamelCase)
                {
                    elementName = elementName.Camelize();
                }

                elementDescriptor.AddElementProperty(ElementPropertyKind.ValueElement, elementName, property, null);
            }
        }
    }
}
