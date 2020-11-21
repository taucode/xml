using System.Collections.Generic;

namespace TauCode.Xml.Tests.Nuspec
{

    [ElementXmlData(
        IsCamelCase = true,
        ChildTypes = new []
        {
            typeof(File)
        })]
    public class Files : ElementXmlDataNode
    {
        public IList<File> FileList { get; set; } = new List<File>();
    }
}
