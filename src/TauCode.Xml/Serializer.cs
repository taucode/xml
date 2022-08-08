using System.Collections;
using System.Reflection;
using System.Xml;

namespace TauCode.Xml;

public class Serializer : ISerializer
{
    public XmlDocument Serialize(object obj)
    {
        throw new NotImplementedException();
    }

    public T Deserialize<T>(XmlDocument xmlDoc)
    {
        if (xmlDoc == null)
        {
            throw new ArgumentNullException(nameof(xmlDoc));
        }

        var documentElement = xmlDoc.DocumentElement;
        if (documentElement == null)
        {
            throw new XmlException("Document element is null.");
        }

        var obj = Activator.CreateInstance<T>();

        var properties = typeof(T).GetProperties();

        this.DeserializeAttributes(obj, properties, documentElement);
        this.DeserializeChildElements(obj, properties, documentElement);
        this.DeserializeInnerText(obj, properties, documentElement);

        return obj;
    }

    private void DeserializeAttributes(object obj, PropertyInfo[] properties, XmlElement xmlElement)
    {
        var attributes = xmlElement.Attributes;
        foreach (var attribute in attributes.Cast<XmlAttribute>())
        {
            var property = properties.SingleOrDefault(x => x.Name == attribute.Name);
            if (property != null)
            {
                property.SetValue(obj, attribute.Value);
            }
        }
    }

    private void DeserializeChildElements(object obj, PropertyInfo[] properties, XmlElement xmlElement)
    {
        var childXmlElements = xmlElement
            .ChildNodes
            .Cast<XmlNode>()
            .OfType<XmlElement>();

        foreach (var childXmlElement in childXmlElements)
        {
            var property = this.FindPropertyForElement(properties, childXmlElement);
            if (property != null)
            {
                if (property.PropertyType == typeof(string))
                {
                    var attr = property.GetCustomAttribute<PropertyElementAttribute>();
                    if (attr == null)
                    {
                        throw new NotImplementedException();
                    }
                    else
                    {
                        if (attr.PropertyName == null)
                        {
                            var childXmlElementInnerText = childXmlElement.InnerText;
                            property.SetValue(obj, childXmlElementInnerText);
                        }
                        else
                        {
                            throw new NotImplementedException();
                        }
                    }
                }
                else if (property.PropertyType == typeof(bool?))
                {
                    var attr = property.GetCustomAttribute<PropertyElementAttribute>();
                    if (attr == null)
                    {
                        throw new NotImplementedException();
                    }
                    else
                    {
                        if (attr.PropertyName == null)
                        {
                            var childXmlElementInnerText = childXmlElement.InnerText;
                            var boolValue = bool.Parse(childXmlElementInnerText);

                            property.SetValue(obj, boolValue);
                        }
                        else
                        {
                            throw new NotImplementedException();
                        }
                    }
                }
                else if (typeof(IList).IsAssignableFrom(property.PropertyType))
                {
                    var list = (IList)property.GetValue(obj);
                    if (list == null)
                    {
                        list = (IList)Activator.CreateInstance(property.PropertyType);
                        property.SetValue(obj, list);
                    }

                    var listElementType = property.PropertyType.GetGenericArguments().Single();
                    var listElementTypeProperties = listElementType.GetProperties();
                    var listElement = Activator.CreateInstance(listElementType);

                    this.DeserializeAttributes(listElement, listElementTypeProperties, childXmlElement);
                    this.DeserializeChildElements(listElement, listElementTypeProperties, childXmlElement);
                    this.DeserializeInnerText(listElement, listElementTypeProperties, childXmlElement);

                    list.Add(listElement);
                }
                else if (property.PropertyType.IsClass)
                {
                    var propertyValue = Activator.CreateInstance(property.PropertyType);
                    property.SetValue(obj, propertyValue);

                    var childProperties = property.PropertyType.GetProperties();

                    this.DeserializeAttributes(propertyValue, childProperties, childXmlElement);
                    this.DeserializeChildElements(propertyValue, childProperties, childXmlElement);
                    this.DeserializeInnerText(propertyValue, childProperties, childXmlElement);
                }
                else
                {
                    throw new NotImplementedException();
                }
            }
        }
    }

    private void DeserializeInnerText(object obj, PropertyInfo[] properties, XmlElement xmlElement)
    {
        var innerTextProperty = properties.SingleOrDefault(x => x.GetCustomAttribute<InnerTextAttribute>() != null);

        if (innerTextProperty != null)
        {
            if (innerTextProperty.PropertyType == typeof(string))
            {
                innerTextProperty.SetValue(obj, xmlElement.InnerText);
            }
            else
            {
                throw new NotImplementedException();
            }
        }
    }

    private PropertyInfo FindPropertyForElement(PropertyInfo[] properties, XmlElement xmlElement)
    {
        var property = properties.SingleOrDefault(x => x.Name == xmlElement.Name);

        if (property == null)
        {
            foreach (var propertyInfo in properties)
            {
                var attr = propertyInfo.GetCustomAttribute<PropertyElementAttribute>();
                if (attr != null)
                {
                    if (attr.PropertyName == xmlElement.Name)
                    {
                        property = propertyInfo;
                        break;
                    }
                }
            }
        }

        if (property == null)
        {
            throw new NotImplementedException();
        }

        return property;
    }
}