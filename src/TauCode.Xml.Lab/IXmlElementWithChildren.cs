using System.Collections.Generic;

namespace TauCode.Xml.Lab
{
    public interface IXmlElementWithChildren : IXmlElement
    {
        IList<IXmlElement> Children { get; }
    }
}
