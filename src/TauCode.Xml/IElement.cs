using System.Collections.Generic;

namespace TauCode.Xml
{
    public interface IElement
    {
        IElementSchema Schema { get; }
        string Name { get; }
        void SetAttribute(string attributeName, string attributeValue);
        string GetAttribute(string attributeName);
        IReadOnlyList<string> GetAttributeNames();
    }
}
