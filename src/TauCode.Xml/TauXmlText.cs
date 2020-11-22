namespace TauCode.Xml
{
    public sealed class TauXmlText : ITauXmlNode
    {
        public TauXmlText()
        {
            
        }

        public string Value { get; set; }

        //public IList<ITauXmlNode> ChildNodes
        //{
        //    get => null;
        //    set => throw new InvalidOperationException();
        //}
    }
}
