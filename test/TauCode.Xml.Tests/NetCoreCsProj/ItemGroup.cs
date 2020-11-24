using System.Collections.Generic;
using TauCode.Xml.Attributes;

namespace TauCode.Xml.Tests.NetCoreCsProj
{
    public class ItemGroup
    {
        [XmlElementProperty]
        public IList<None> None { get; set; } = new List<None>();

        [XmlElementProperty]
        public IList<EmbeddedResource> EmbeddedResource { get; set; } = new List<EmbeddedResource>();

        [XmlElementProperty]
        public IList<PackageReference> PackageReference { get; set; } = new List<PackageReference>();

        [XmlElementProperty]
        public IList<ProjectReference> ProjectReference { get; set; } = new List<ProjectReference>();
    }
}
