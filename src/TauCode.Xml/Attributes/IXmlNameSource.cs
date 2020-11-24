namespace TauCode.Xml.Attributes
{
    public interface IXmlNameSource
    {
        string XmlName { get; set; }
        bool IsCamelCase { get; set; }
    }
}
