using Inflector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Xml;
using TauCode.Xml.Attributes;
using TauCode.Xml.Descriptors;

namespace TauCode.Xml
{
    public class TauXmlDataSerializer
    {
        private readonly Dictionary<Type, TauXmlElementDescriptor> _typeDescriptors;

        public TauXmlDataSerializer()
        {
            _typeDescriptors = new Dictionary<Type, TauXmlElementDescriptor>();
        }

        private ITauXmlNode Deserialize(Type elementType, XmlElement xmlElement)
        {
            if (!_typeDescriptors.ContainsKey(elementType))
            {
                var builder = new TauXmlElementDescriptorBuilder();
                var elementDescriptor = builder.Build(elementType);

                throw new NotImplementedException();
            }

            throw new NotImplementedException();

            //var element = this.CreateElement(elementType);

            //if (typeof(ValueElementXmlDataNode).IsAssignableFrom(elementType))
            //{
            //    return this.XmlElementToValueElementXmlDataNode(elementType, xmlElement);
            //}

            //// deal with nested elements
            //var xmlChildren = xmlElement.ChildNodes;
            //foreach (var xmlChild in xmlChildren)
            //{
            //    if (xmlChild is XmlElement childXmlElement)
            //    {
            //        PropertyInfo propertyInfo;

            //        // try add 'element' property info
            //        propertyInfo = this.TryGetElementPropertyInfo(elementType, childXmlElement.Name);

            //        if (propertyInfo != null)
            //        {
            //            var propertyValue = this.Deserialize(propertyInfo.PropertyType, childXmlElement);
            //            propertyInfo.SetValue(element, propertyValue);

            //            element.ChildNodes.Add(propertyValue);
            //            continue;
            //        }

            //        // try add 'element list' property info
            //        propertyInfo = this.TryGetElementListPropertyInfo(elementType, childXmlElement.Name);
            //        if (propertyInfo != null)
            //        {
            //            var listElementType = propertyInfo.PropertyType.GetGenericArguments().Single();
            //            var listElement = this.Deserialize(listElementType, childXmlElement);

            //            var list = (IList)propertyInfo.GetValue(element);
            //            list.Add(listElement);

            //            element.ChildNodes.Add(listElement);
            //            continue;
            //        }

            //        throw new NotImplementedException();
            //    }
            //    else
            //    {
            //        throw new NotImplementedException();
            //    }
            //}

            //// deal with attributes
            //foreach (XmlAttribute attribute in xmlElement.Attributes)
            //{
            //    if (attribute.Name == "xmlns")
            //    {
            //        continue;
            //    }

            //    var propertyInfo = this.TryGetAttributePropertyInfo(elementType, attribute.Name);

            //    if (propertyInfo == null)
            //    {
            //        throw new NotImplementedException();
            //    }
            //    else
            //    {
            //        propertyInfo.SetValue(element, attribute.Value);

            //        ((ElementXmlDataNode)element).Attributes.Add(attribute.Name, attribute.Value);
            //    }
            //}


            //return element;
        }

        //private ValueElementXmlDataNode XmlElementToValueElementXmlDataNode(Type elementType, XmlElement xmlElement)
        //{
        //    var element = (ValueElementXmlDataNode)this.CreateElement(elementType);
        //    element.Value = xmlElement.ChildNodes.Cast<XmlText>().Single().Value;
        //    return element;
        //}

        public TElementXmlDataNode Deserialize<TElementXmlDataNode>(XmlElement xmlElement)
            where TElementXmlDataNode : TauXmlElement
        {
            var elementType = typeof(TElementXmlDataNode);
            var element = this.Deserialize(elementType, xmlElement);
            return (TElementXmlDataNode)element;
        }

        //private PropertyInfo TryGetElementPropertyInfo(Type elementType, string childElementName)
        //{
        //    var attr = elementType.GetCustomAttribute<ElementXmlDataAttribute>();
        //    if (attr == null)
        //    {
        //        throw new NotImplementedException();
        //    }

        //    var childTypes = attr.ChildTypes;
        //    foreach (var childType in childTypes)
        //    {
        //        var childAttr = elementType.GetCustomAttribute<ElementXmlDataAttribute>();
        //        if (childAttr == null)
        //        {
        //            throw new NotImplementedException();
        //        }
        //        else
        //        {
        //            string expectedElementName;

        //            if (childAttr.ElementName == null)
        //            {
        //                if (childAttr.IsCamelCase)
        //                {
        //                    expectedElementName = childType.Name.Camelize();
        //                }
        //                else
        //                {
        //                    throw new NotImplementedException();
        //                }
        //            }
        //            else
        //            {
        //                throw new NotImplementedException();
        //            }

        //            if (expectedElementName == childElementName)
        //            {
        //                var props = elementType
        //                    .GetProperties()
        //                    .Where(x => x.PropertyType == childType)
        //                    .ToList();

        //                switch (props.Count)
        //                {
        //                    case 0:
        //                        return null;

        //                    case 1:
        //                        return props.Single();

        //                    default:
        //                        throw new NotImplementedException();
        //                }
        //            }
        //        }
        //    }

        //    return null;
        //}

        //private PropertyInfo TryGetElementListPropertyInfo(Type elementType, string childElementName)
        //{
        //    var attr = elementType.GetCustomAttribute<ElementXmlDataAttribute>();
        //    if (attr == null)
        //    {
        //        throw new NotImplementedException();
        //    }

        //    var generic = typeof(IList<>);

        //    var childTypes = attr.ChildTypes;
        //    foreach (var childType in childTypes)
        //    {
        //        var childAttr = elementType.GetCustomAttribute<ElementXmlDataAttribute>();
        //        if (childAttr == null)
        //        {
        //            throw new NotImplementedException();
        //        }
        //        else
        //        {
        //            string expectedElementName;

        //            if (childAttr.ElementName == null)
        //            {
        //                if (childAttr.IsCamelCase)
        //                {
        //                    expectedElementName = childType.Name.Camelize();
        //                }
        //                else
        //                {
        //                    throw new NotImplementedException();
        //                }
        //            }
        //            else
        //            {
        //                throw new NotImplementedException();
        //            }

        //            if (expectedElementName == childElementName)
        //            {
        //                var listType = generic.MakeGenericType(childType);

        //                var props = elementType
        //                    .GetProperties()
        //                    .Where(x => x.PropertyType == listType)
        //                    .ToList();

        //                switch (props.Count)
        //                {
        //                    case 0:
        //                        return null;

        //                    case 1:
        //                        return props.Single();

        //                    default:
        //                        throw new NotImplementedException();
        //                }
        //            }
        //        }
        //    }

        //    return null;
        //}

        private PropertyInfo TryGetAttributePropertyInfo(Type elementType, string xmlAttributeName)
        {
            var props = elementType
                .GetProperties()
                .Where(x => x.PropertyType == typeof(string))
                .ToList();

            foreach (var prop in props)
            {
                var attr = prop.GetCustomAttribute<TauXmlAttributeAttribute>();
                if (attr != null)
                {
                    if (attr.Name == xmlAttributeName)
                    {
                        throw new NotImplementedException();
                    }

                    if (attr.IsCamelCase)
                    {
                        var expectedXmlAttrName = prop.Name.Camelize();
                        if (xmlAttributeName == expectedXmlAttrName)
                        {
                            return prop;
                        }
                    }
                }
            }

            return null;
        }

        private ITauXmlNode CreateElement(Type elementType)
        {
            var ctor = elementType.GetConstructor(Type.EmptyTypes);
            if (ctor == null)
            {
                throw new NotImplementedException();
            }

            var element = (ITauXmlNode)ctor.Invoke(new object[] { });
            return element;
        }

        public XmlElement SerializeToXmlElement(XmlDocument document, ITauXmlNode dataNode)
        {
            throw new NotImplementedException();
        }
    }
}
