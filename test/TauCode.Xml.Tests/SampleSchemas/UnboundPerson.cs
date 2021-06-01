using TauCode.Xml.Unbound;

namespace TauCode.Xml.Tests.SampleSchemas
{
    public class UnboundPerson : ComplexElementBase
    {
        public override IUnboundSchema UnboundSchema => UnboundSchemaBase.PermissiveEmptyUnboundSchema;
    }
}
