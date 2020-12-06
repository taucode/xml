using System.Collections.Generic;
using System.Linq;

namespace TauCode.Xml.Lab.Demo.Nuspec
{
    public class Files : ComplexElement
    {
        public Files(IElementSchema schema)
            : base(schema)
        {
        }

        public IList<File> GetFiles => this.Children
            .Where(x => x is File)
            .Cast<File>()
            .ToList();
    }
}
