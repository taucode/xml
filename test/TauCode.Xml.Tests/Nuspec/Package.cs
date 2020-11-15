namespace TauCode.Xml.Tests.Nuspec
{
    [ElementXmlData(
        IsCamelCase = true,
        ChildTypes = new []
        {
            typeof(Id),
            typeof(TauCode.Xml.Tests.Nuspec.Version),
            typeof(Authors)
        })]
    public class Package : ElementXmlDataNode
    {
    }
}
