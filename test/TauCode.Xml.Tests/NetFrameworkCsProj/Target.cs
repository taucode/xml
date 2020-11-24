using System.Collections.Generic;
using TauCode.Xml.Attributes;

namespace TauCode.Xml.Tests.NetFrameworkCsProj
{
    public class Target
    {
        [XmlAttributeProperty]
        public string Name { get; set; }

        [XmlAttributeProperty]
        public string BeforeTargets { get; set; }

        [XmlAttributeProperty]
        public string AfterTargets { get; set; }

        [XmlAttributeProperty]
        public string Condition { get; set; }

        [XmlElementProperty]
        public AspNetCompiler AspNetCompiler { get; set; }

        [XmlElementProperty]
        public PropertyGroup PropertyGroup { get; set; }

        [XmlElementProperty]
        public IList<Error> Error { get; set; } = new List<Error>();
    }
}
