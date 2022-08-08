using System.Xml;

namespace TauCode.Xml;

public interface ISerializer
{
    XmlDocument Serialize(object obj);
    T Deserialize<T>(XmlDocument xmlDoc);
}