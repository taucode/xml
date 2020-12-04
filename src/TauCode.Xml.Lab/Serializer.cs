using System;
using System.Linq;
using System.Reflection;
using System.Xml;

namespace TauCode.Xml.Lab
{
    public class Serializer
    {
        public IComplexElement Deserialize(IElementSchema schema, XmlDocument document)
        {
            // todo checks
            var documentElement = document.DocumentElement;

            var element = this.DeserializeComplexElement(schema, documentElement);
            return element;
        }

        private IComplexElement DeserializeComplexElement(IElementSchema schema, XmlElement xmlElement)
        {
            if (typeof(ComplexElement).IsAssignableFrom(schema.ElementType))
            {
                var ctor = schema.ElementType.GetConstructor(new[] { typeof(IElementSchema) });
                if (ctor == null)
                {
                    throw new NotImplementedException();
                }

                IComplexElement element = (IComplexElement)ctor.Invoke(new object[] { schema });

                // attributes
                foreach (XmlAttribute xmlElementAttribute in xmlElement.Attributes)
                {
                    element.SetAttribute(xmlElementAttribute.Name, xmlElementAttribute.Value);
                }

                // child elements
                foreach (var xmlChildNode in xmlElement.ChildNodes)
                {
                    if (xmlChildNode is XmlComment)
                    {
                        continue;
                    }

                    if (xmlChildNode is XmlElement xmlChildElement)
                    {
                        var childSchema = schema.GetChildElement(xmlChildElement.Name);

                        if (childSchema.ContainsTextNode())
                        {
                            ITextNodeElement childElement = this.DeserializeTextNodeElement(childSchema, xmlChildElement);

                            ((ElementList)(element.Children)).Add(childElement, false);
                        }
                        else
                        {
                            var childElement = this.DeserializeComplexElement(childSchema, xmlChildElement);
                            ((ElementList)(element.Children)).Add(childElement, false);
                        }
                    }
                    else
                    {
                        throw new NotImplementedException();
                    }
                }

                return element;
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        private ITextNodeElement DeserializeTextNodeElement(IElementSchema schema, XmlElement xmlElement)
        {
            var childXmlNodes = xmlElement.ChildNodes.Cast<XmlNode>().ToList();

            // todo: copy-pasting; merge cases 'count == 0' and 'count == 1'

            if (childXmlNodes.Count == 0)
            {
                ITextNodeElement textNodeElement = new TextNodeElement(schema);
                
                foreach (XmlAttribute xmlElementAttribute in xmlElement.Attributes)
                {
                    textNodeElement.SetAttribute(xmlElementAttribute.Name, xmlElementAttribute.Value);
                }

                return textNodeElement;
            }

            if (childXmlNodes.Count != 1)
            {
                throw new NotImplementedException();
            }

            if (childXmlNodes.Single() is XmlText xmlText)
            {
                ITextNodeElement textNodeElement = new TextNodeElement(schema);
                textNodeElement.Value = xmlText.Value;

                foreach (XmlAttribute xmlElementAttribute in xmlElement.Attributes)
                {
                    textNodeElement.SetAttribute(xmlElementAttribute.Name, xmlElementAttribute.Value);
                }

                return textNodeElement;
            }
            else
            {
                throw new NotImplementedException();
            }
        }

        public XmlDocument Serialize(IComplexElement rootElement)
        {
            // todo checks

            var xmlDocument = new XmlDocument();

            var attr = rootElement.GetType().GetCustomAttribute<XmlDocumentDeclarationAttribute>();
            if (attr != null)
            {
                var xmlDeclaration = xmlDocument.CreateXmlDeclaration("1.0", attr.Encoding, attr.Standalone);
                xmlDocument.AppendChild(xmlDeclaration);
            }

            this.SerializeComplexElement(xmlDocument, rootElement);

            return xmlDocument;
        }

        private XmlElement SerializeComplexElement(XmlNode xmlParentNode, IComplexElement element)
        {
            // todo: check element has correct schema etc

            XmlDocument ownerDocument;

            if (xmlParentNode is XmlDocument xmlDocument)
            {
                ownerDocument = xmlDocument;
            }
            else if (xmlParentNode is XmlElement xmlParentElement)
            {
                ownerDocument = xmlParentElement.OwnerDocument ?? throw new NotImplementedException();
            }
            else
            {
                throw new NotImplementedException();
            }

            var xmlElement = ownerDocument.CreateElement(element.Name);

            // deal with attributes
            foreach (var attributeName in element.GetAttributeNames())
            {
                var attributeValue = element.GetAttribute(attributeName);
                xmlElement.SetAttribute(attributeName, attributeValue);
            }
            
            // deal with child elements
            foreach (var childElement in element.Children)
            {
                // todo: check element has correct schema etc

                if (childElement is TextNodeElement childTextNodeElement)
                {
                    var textElement = ownerDocument.CreateElement(childTextNodeElement.Name);

                    if (string.IsNullOrEmpty(childTextNodeElement.Value))
                    {
                        // do nothing
                    }
                    else
                    {
                        textElement.InnerText = childTextNodeElement.Value;
                    }

                    foreach (var attributeName in childTextNodeElement.GetAttributeNames())
                    {
                        var attributeValue = childTextNodeElement.GetAttribute(attributeName);
                        textElement.SetAttribute(attributeName, attributeValue);
                    }

                    xmlElement.AppendChild(textElement);
                }
                else if (childElement is ComplexElement childComplexElement)
                {
                    var childXmlElement = this.SerializeComplexElement(xmlElement, childComplexElement);
                    xmlElement.AppendChild(childXmlElement);
                }
                else
                {
                    throw new NotImplementedException();
                }
            }

            xmlParentNode.AppendChild(xmlElement);

            return xmlElement;
        }
    }
}
