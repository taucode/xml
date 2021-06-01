using System.Collections.Generic;
using TauCode.Xml.Unbound;

namespace TauCode.Xml.Tests.SampleSchemas
{
    public class BoundPerson : ComplexElementBase
    {
        public string Name { get; set; }

        public int? Age { get; set; }

        public Gender? Gender { get; set; }

        public BoundPerson Spouse { get; set; }

        public IList<BoundPerson> Kids { get; set; } = new List<BoundPerson>();

        public override IUnboundSchema UnboundSchema => null;
    }
}
