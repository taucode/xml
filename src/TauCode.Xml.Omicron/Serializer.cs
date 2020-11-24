using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Xml;
using TauCode.Xml.Omicron.Attributes;
using TauCode.Xml.Omicron.Descriptors;

namespace TauCode.Xml.Omicron
{
    public class Serializer
    {
        private XmlDocument _xmlDocument;
        private SchemaDescriptor _schemaDescriptor;

        public T Deserialize<T>(SchemaDescriptor schemaDescriptor, XmlElement xmlElement)
        {
            return (T)this.DeserializeImpl(schemaDescriptor, xmlElement, typeof(T));
        }

        private object DeserializeImpl(SchemaDescriptor schemaDescriptor, XmlElement xmlElement, Type type)
        {
            var elementDescriptor = schemaDescriptor.Elements[type];

            var ctor = elementDescriptor.Type.GetConstructor(Type.EmptyTypes) ?? throw new NotImplementedException();
            var element = ctor.Invoke(new object[] { });

            var gotInnerText = false;

            var processedSingleNames = new HashSet<string>();

            foreach (var childNode in xmlElement.ChildNodes)
            {
                if (childNode is XmlComment)
                {
                    continue;
                }

                if (childNode is XmlText xmlText)
                {
                    if (gotInnerText)
                    {
                        throw new NotImplementedException();
                    }

                    if (elementDescriptor.InnerTextProperty == null)
                    {
                        throw new NotImplementedException();
                    }
                    else
                    {
                        elementDescriptor.InnerTextProperty.SetValue(element, xmlText.Value);
                    }

                    gotInnerText = true;
                }

                if (childNode is XmlElement childXmlElement)
                {
                    var elementPropertyDescriptor = elementDescriptor.ElementProperties.GetValueOrDefault(childXmlElement.Name);
                    if (elementPropertyDescriptor == null)
                    {
                        throw new NotImplementedException();
                    }

                    switch (elementPropertyDescriptor.Kind)
                    {
                        case ElementPropertyKind.ValueElement:
                            // todo check hash table

                            var value = childXmlElement.InnerText;
                            elementPropertyDescriptor.Property.SetValue(element, value);
                            processedSingleNames.Add(elementPropertyDescriptor.ElementName);

                            break;

                        case ElementPropertyKind.ValueElementList:
                            throw new NotImplementedException();

                        case ElementPropertyKind.ComplexElement:
                            // todo check hash table

                            var childValue = this.DeserializeImpl(
                                schemaDescriptor,
                                childXmlElement,
                                elementPropertyDescriptor.Element.Type);


                            elementPropertyDescriptor.Property.SetValue(element, childValue);
                            processedSingleNames.Add(elementPropertyDescriptor.ElementName);

                            break;


                        case ElementPropertyKind.ComplexElementList:
                            var childListEntry = this.DeserializeImpl(
                                schemaDescriptor,
                                childXmlElement,
                                elementPropertyDescriptor.Element.Type);

                            var list = (IList)elementPropertyDescriptor.Property.GetValue(element);
                            list.Add(childListEntry);

                            break;

                        default:
                            throw new NotImplementedException();
                    }
                }
            }

            foreach (XmlAttribute attribute in xmlElement.Attributes)
            {
                var attrProp = elementDescriptor.AttributeProperties.GetValueOrDefault(attribute.Name);
                if (attrProp == null)
                {
                    throw new NotImplementedException();
                }
                else
                {
                    attrProp.Property.SetValue(element, attribute.Value);
                }
            }

            return element;
        }

        public XmlDocument Serialize(SchemaDescriptor schemaDescriptor, object obj)
        {
            // todo checks, including obj type

            var type = obj.GetType();
            var elementDescriptor = schemaDescriptor.Elements.GetValueOrDefault(type);
            if (elementDescriptor == null)
            {
                throw new NotImplementedException();
            }

            _schemaDescriptor = schemaDescriptor;
            _xmlDocument = new XmlDocument();
            var element = this.BuildElement(_schemaDescriptor.RootName, elementDescriptor, obj);

            var attr = type.GetCustomAttribute<XmlDocumentDeclarationAttribute>();
            if (attr != null)
            {
                var xmlDeclaration = _xmlDocument.CreateXmlDeclaration("1.0", attr.Encoding, attr.Standalone);
                _xmlDocument.AppendChild(xmlDeclaration);
            }

            _xmlDocument.AppendChild(element);

            return _xmlDocument;
        }

        private XmlElement BuildElement(
            string elementName,
            ElementDescriptor elementDescriptor,
            object obj)
        {
            var xmlElement = _xmlDocument.CreateElement(elementName);

            foreach (var pair in elementDescriptor.AttributeProperties)
            {
                var attributePropertyDescriptor = pair.Value;
                var property = attributePropertyDescriptor.Property;
                var propertyValue = (string)property.GetValue(obj);

                if (propertyValue == null)
                {
                    continue;
                }

                xmlElement.SetAttribute(pair.Key, propertyValue);
            }

            if (elementDescriptor.InnerTextProperty != null)
            {
                var innerText = (string)elementDescriptor.InnerTextProperty.GetValue(obj);
                var textNode = _xmlDocument.CreateTextNode(innerText);

                xmlElement.AppendChild(textNode);
            }

            foreach (var pair in elementDescriptor.ElementProperties)
            {
                var childElementName = pair.Key;
                var property = pair.Value.Property;
                var kind = pair.Value.Kind;

                switch (kind)
                {
                    case ElementPropertyKind.ValueElement:
                        var innerText = (string)property.GetValue(obj);
                        if (innerText == null)
                        {
                            throw new NotImplementedException();
                        }
                        else
                        {
                            var textHolderElement = _xmlDocument.CreateElement(childElementName);
                            var textNode = _xmlDocument.CreateTextNode(innerText);
                            textHolderElement.AppendChild(textNode);

                            xmlElement.AppendChild(textHolderElement);
                        }

                        break;

                    case ElementPropertyKind.ValueElementList:
                        throw new NotImplementedException();

                    case ElementPropertyKind.ComplexElement:
                        var complexObject = property.GetValue(obj);
                        if (complexObject == null)
                        {
                            throw new NotImplementedException();
                        }
                        else
                        {
                            var childElementDescriptor = _schemaDescriptor
                                .Elements
                                .GetValueOrDefault(property.PropertyType);

                            if (childElementDescriptor == null)
                            {
                                throw new NotImplementedException();
                            }

                            var childXmlElement = this.BuildElement(
                                childElementName,
                                childElementDescriptor,
                                complexObject);

                            xmlElement.AppendChild(childXmlElement);
                        }

                        break;

                    case ElementPropertyKind.ComplexElementList:
                        var list = (IList)property.GetValue(obj);

                        var listObjElementDescriptor = _schemaDescriptor
                            .Elements
                            .GetValueOrDefault(property.PropertyType.GetGenericArguments().Single());

                        if (listObjElementDescriptor == null)
                        {
                            throw new NotImplementedException();
                        }

                        foreach (var listObj in list)
                        {
                            if (listObj == null)
                            {
                                continue;
                            }

                            var listObjElement = this.BuildElement(
                                childElementName,
                                listObjElementDescriptor,
                                listObj);

                            xmlElement.AppendChild(listObjElement);
                        }

                        break;

                    default:
                        throw new NotImplementedException();
                }
            }

            return xmlElement;
        }
    }
}
