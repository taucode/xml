using Inflector;
using System;
using System.Collections.Generic;
using System.Reflection;
using TauCode.Xml.Attributes;

namespace TauCode.Xml.Descriptors
{
    public class TauXmlElementDescriptorBuilder
    {
        private readonly Dictionary<Type, TauXmlElementDescriptor> _descriptors;

        public TauXmlElementDescriptorBuilder()
        {
            _descriptors = new Dictionary<Type, TauXmlElementDescriptor>();
        }

        public TauXmlElementDescriptor Build(Type type)
        {
            if (type == null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            if (!typeof(TauXmlElement).IsAssignableFrom(type))
            {
                throw new NotImplementedException();
            }

            if (_descriptors.ContainsKey(type))
            {
                throw new NotImplementedException();
            }

            var attr = type.GetCustomAttribute<TauXmlElementAttribute>();

            string elementName;

            if (attr == null)
            {
                throw new NotImplementedException();
            }
            else
            {
                if (attr.IsCamelCase)
                {
                    elementName = type.Name.Camelize();
                }
                else
                {
                    throw new NotImplementedException();
                }
            }

            var descriptor = new TauXmlElementDescriptor(elementName, type);

            _descriptors.Add(type, descriptor);

            var props = type.GetProperties();

            foreach (var prop in props)
            {
                if (typeof(TauXmlElement).IsAssignableFrom(prop.PropertyType))
                {
                    if (_descriptors.ContainsKey(prop.PropertyType))
                    {
                        throw new NotImplementedException();
                    }
                    else
                    {
                        var propDescriptor = this.Build(prop.PropertyType);

                        throw new NotImplementedException();
                    }

                    throw new NotImplementedException();
                }
                else if (prop.PropertyType == typeof(string))
                {
                    throw new NotImplementedException();
                }
                else
                {
                    throw new NotImplementedException();
                }

                throw new NotImplementedException();
            }

            throw new NotImplementedException();
        }
    }
}
