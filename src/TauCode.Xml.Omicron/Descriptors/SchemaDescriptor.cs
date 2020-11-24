using System;
using System.Collections.Generic;
using System.Linq;

namespace TauCode.Xml.Omicron.Descriptors
{
    public class SchemaDescriptor
    {
        internal SchemaDescriptor(
            Type rootType,
            string rootName,
            IDictionary<Type, ElementDescriptor> elements)
        {
            this.RootType = rootType;
            this.RootName = rootName;
            this.Elements = elements.ToDictionary(x => x.Key, x => x.Value);
        }

        public Type RootType { get; }
        public string RootName { get; }
        public IReadOnlyDictionary<Type, ElementDescriptor> Elements { get; }
    }
}
