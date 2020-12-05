using System.Collections.Generic;
using System.Linq;

namespace TauCode.Xml.Lab.Demo.Nuspec
{
    [XmlDocumentDeclaration]
    public class Package : ComplexElement
    {
        public Package(IElementSchema schema) : base(schema)
        {
        }

        public Metadata GetMetadata()
        {
            return this.Children.Single(x => x is Metadata) as Metadata;
        }

        public string GetId()
        {
            return ((TextNodeElement)this.GetMetadata().Children.Single(x => x.Name == "id")).Value;
        }

        public IList<Dependency> GetAllDependencies()
        {
            return this.GetMetadata()
                .GetDependenciesElement()
                .GetGroups()
                .SelectMany(x => x.GetDependencies())
                .ToList();
        }
    }
}
