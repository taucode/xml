using System.Collections.Generic;
using System.Linq;

namespace TauCode.Xml
{
    public sealed class TextNodeElement : ITextNodeElement
    {
        #region Fields

        private readonly Dictionary<string, string> _attributes;

        #endregion

        #region Constructor

        public TextNodeElement(IElementSchema schema)
        {
            // todo checks

            _attributes = new Dictionary<string, string>();
            this.Schema = schema;
            this.Name = this.Schema.ElementName;
        }

        #endregion

        #region IElement Members

        public IElementSchema Schema { get; }

        public string Name { get; }

        public void SetAttribute(string attributeName, string attributeValue)
        {
            // todo checks

            _attributes[attributeName] = attributeValue;
        }

        public string GetAttribute(string attributeName)
        {
            // todo checks

            return _attributes.GetValueOrDefault(attributeName);
        }

        public IReadOnlyList<string> GetAttributeNames() => _attributes.Keys.ToList();
        #endregion

        #region ITextNodeElement Members

        public string Value { get; set; }

        #endregion
    }
}
