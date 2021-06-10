using System.Xml.Serialization;
using TauCode.Xml.Unbound;

namespace TauCode.Xml
{
    public abstract class ElementBase : IElement
    {
        private readonly AttributeCollection _unboundAttributes;

        protected ElementBase()
        {
            _unboundAttributes = new AttributeCollection();
        }

        [XmlIgnore]
        public virtual IUnboundSchema UnboundSchema => null;

        [XmlIgnore]
        public IAttributeCollection UnboundAttributes => _unboundAttributes;
    }
}
