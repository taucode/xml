using System.Collections.Generic;
using TauCode.Xml.Attributes;

namespace TauCode.Xml.Tests.NetFrameworkCsProj
{
    public class ItemGroup
    {
        [XmlElementProperty]
        public IList<Reference> Reference { get; set; } = new List<Reference>();

        [XmlElementProperty]
        public IList<Compile> Compile { get; set; } = new List<Compile>();

        [XmlElementProperty]
        public IList<Content> Content { get; set; } = new List<Content>();

        [XmlElementProperty]
        public IList<None> None { get; set; } = new List<None>();

        [XmlElementProperty]
        public IList<ProjectReference> ProjectReference { get; set; } = new List<ProjectReference>();

        [XmlElementProperty]
        public IList<WCFMetadata> WCFMetadata { get; set; } = new List<WCFMetadata>();
    }
}
