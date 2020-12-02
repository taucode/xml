using System;
using System.Collections.Generic;

namespace TauCode.Xml.Lab
{
    public interface IElementSchema
    {
        string ElementName { get; }
        Type ElementType { get; }
        IReadOnlyList<string> GetAttributes();
        void AddAttribute(string attributeName);
        bool RemoveAttribute(string attributeName);
        bool ContainsAttribute(string attributeName);
        IReadOnlyList<IElementSchema> GetChildElements();
        void AddChildElement(IElementSchema childElementSchema);
        bool RemoveChildElement(string childElementName);
        bool ContainsChildElement(string childElementName);
        IElementSchema GetChildElement(string childElementName);
        bool ContainsTextNode { get; }
    }
}
