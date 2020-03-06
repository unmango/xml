using System;

namespace UnMango.Xml
{
    public class XmlParsingException : Exception
    {
        public XmlParsingException() { }

        public XmlParsingException(string message)
            : base(message) { }

        public XmlParsingException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}
