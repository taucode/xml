using System.Collections.Generic;
using TauCode.Xml.Attributes;

namespace TauCode.Xml.Tests.Nuspec
{

    [TauXmlElement(IsCamelCase = true)]
    public class Files : TauXmlElement
    {
        public IList<File> FileList { get; set; } = new List<File>();
    }
}
