using System.Reflection;

namespace TauCode.Xml.Bound
{
    public interface IBoundAttributeDescriptor
    {
        string AttributeName { get; }
        PropertyInfo Property { get; }
        bool IsMandatory { get; }
    }
}
