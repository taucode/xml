using System.Reflection;

namespace TauCode.Xml.Bound
{
    internal interface IBoundChildElementDescriptor : IChildElementDescriptor
    {
        PropertyInfo Property { get; }
    }
}
