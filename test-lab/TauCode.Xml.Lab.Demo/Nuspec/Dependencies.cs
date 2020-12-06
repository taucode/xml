using System.Collections.Generic;
using System.Linq;

namespace TauCode.Xml.Lab.Demo.Nuspec
{
    public class Dependencies : ComplexElement
    {
        public Dependencies(IElementSchema schema)
            : base(schema)
        {
        }

        public IList<Group> GetGroups()
        {
            return this.Children
                .Where(x => x is Group)
                .Cast<Group>()
                .ToList();
        }
    }
}
