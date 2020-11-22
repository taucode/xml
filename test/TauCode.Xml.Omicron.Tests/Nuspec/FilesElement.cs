using System.Collections.Generic;
using TauCode.Xml.Omicron.Attributes;

namespace TauCode.Xml.Omicron.Tests.Nuspec
{
    public class FilesElement
    {
        [XmlElementProperty(IsCamelCase = true)]
        public IList<File> Files { get; } = new List<File>();
    }
}
