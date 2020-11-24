using System.Collections.Generic;
using TauCode.Xml.Attributes;

namespace TauCode.Xml.Tests.NetCoreCsProj
{
    public class Project
    {
        [XmlAttributeProperty]
        public string Sdk { get; set; }

        [XmlElementProperty]
        public IList<PropertyGroup> PropertyGroup { get; set; } = new List<PropertyGroup>(); // todo: what if there is no such initializer?

        [XmlElementProperty]
        public IList<ItemGroup> ItemGroup { get; set; } = new List<ItemGroup>();
    }
}
