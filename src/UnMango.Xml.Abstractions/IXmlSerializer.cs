using JetBrains.Annotations;

namespace UnMango.Xml
{
    [PublicAPI]
    public interface IXmlSerializer
    {
        static abstract T Deserialize<T>(string xml, XmlSerializerOptions? options = null);
    }
}
