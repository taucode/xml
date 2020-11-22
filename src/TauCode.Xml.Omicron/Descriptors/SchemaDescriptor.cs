using System;
using System.Collections.Generic;
using System.Linq;

namespace TauCode.Xml.Omicron.Descriptors
{
    public class SchemaDescriptor
    {
        internal SchemaDescriptor(IDictionary<Type, ElementDescriptor> elements)
        {
            // todo checks
            this.Elements = elements.ToDictionary(x => x.Key, x => x.Value);
        }

        public IReadOnlyDictionary<Type, ElementDescriptor> Elements { get; }
    }
}
