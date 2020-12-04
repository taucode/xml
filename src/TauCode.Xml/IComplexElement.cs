using System.Collections.Generic;

namespace TauCode.Xml
{
    public interface IComplexElement : IElement
    {
        IList<IElement> Children { get; }
        IElement AddChildElement(string elementName);
    }
}
