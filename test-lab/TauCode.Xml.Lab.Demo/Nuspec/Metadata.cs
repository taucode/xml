using System.Linq;

namespace TauCode.Xml.Lab.Demo.Nuspec
{
    public class Metadata : ComplexElement
    {
        public Metadata(IElementSchema schema)
            : base(schema)
        {   
        }

        public Dependencies GetDependenciesElement()
        {
            return this.Children.SingleOrDefault(x => x is Dependencies) as Dependencies;
        }
    }
}
