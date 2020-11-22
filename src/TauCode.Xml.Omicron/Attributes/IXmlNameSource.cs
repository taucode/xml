namespace TauCode.Xml.Omicron.Attributes
{
    public interface IXmlNameSource
    {
        string XmlName { get; set; }
        bool IsCamelCase { get; set; }
    }
}
