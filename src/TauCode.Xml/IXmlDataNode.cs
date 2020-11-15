using System.Collections.Generic;

namespace TauCode.Xml
{
    public interface IXmlDataNode
    {
        IList<IXmlDataNode> ChildNodes { get; set; }
    }
}
