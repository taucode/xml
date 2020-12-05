using System.Collections.Generic;
using System.Linq;

namespace TauCode.Xml.Lab.Demo.Nuspec
{
    public class Group : ComplexElement
    {
        public Group(IElementSchema schema)
            : base(schema)
        {
        }

        public IList<Dependency> GetDependencies()
        {
            return this.Children
                .Where(x => x is Dependency)
                .Cast<Dependency>()
                .ToList();
        }
    }
}
