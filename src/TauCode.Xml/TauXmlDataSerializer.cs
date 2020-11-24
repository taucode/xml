using System;
using System.Collections.Generic;
using System.Xml;
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

        public TElementXmlDataNode Deserialize<TElementXmlDataNode>(XmlElement xmlElement)
            where TElementXmlDataNode : TauXmlElement
        {
            var elementType = typeof(TElementXmlDataNode);
            var element = this.Deserialize(elementType, xmlElement);
            return (TElementXmlDataNode)element;
        }
    }
}
