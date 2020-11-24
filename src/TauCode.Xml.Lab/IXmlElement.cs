using System.Collections.Generic;

namespace TauCode.Xml.Lab
{
    public interface IXmlElement
    {
        void SetAttribute(string attributeName, string attributeValue);
        string GetAttribute(string attributeName);
        IReadOnlyList<string> GetAttributeNames();
    }
}
