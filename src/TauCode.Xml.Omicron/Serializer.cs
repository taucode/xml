using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using TauCode.Xml.Omicron.Descriptors;

namespace TauCode.Xml.Omicron
{
    public class Serializer
    {
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
    }
}
