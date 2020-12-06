namespace TauCode.Xml.Lab.Demo.Nuspec
{
    public class Dependency : ComplexElement
    {
        public Dependency(IElementSchema schema)
            : base(schema)
        {
        }

        public string GetId()
        {
            return this.GetAttribute("id");
        }
    }
}
