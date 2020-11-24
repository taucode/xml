using System.Collections.Generic;
using TauCode.Xml.Attributes;

namespace TauCode.Xml.Tests.Nuspec
{
    public class FilesElement
    {
        [XmlElementProperty(XmlName = "file")]
        public IList<File> Files { get; } = new List<File>();
    }
}
