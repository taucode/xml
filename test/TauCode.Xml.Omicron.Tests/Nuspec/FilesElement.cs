using System.Collections.Generic;
using TauCode.Xml.Omicron.Attributes;

namespace TauCode.Xml.Omicron.Tests.Nuspec
{
    public class FilesElement
    {
        [XmlElementProperty(XmlName = "file")]
        public IList<File> Files { get; } = new List<File>();
    }
}
