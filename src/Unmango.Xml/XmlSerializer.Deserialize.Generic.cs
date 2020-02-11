using System;
using System.IO;
using System.IO.Pipelines;

namespace Unmango.Xml
{
    public static partial class XmlSerializer
    {
        public static T Deserialize<T>(string xml, XmlSerializerOptions? options = null)
        {
            throw new NotImplementedException();
        }

        public static T Deserialize<T>(byte[] bytes, XmlSerializerOptions? options = null)
            => Deserialize<T>(bytes.AsSpan(), options);

        public static T Deserialize<T>(byte[] bytes, int offset, XmlSerializerOptions? options = null)
            => Deserialize<T>(bytes.AsSpan(offset), options); // TODO: Safe to call bytes.Length?

        public static T Deserialize<T>(ReadOnlySpan<byte> span, XmlSerializerOptions? options = null)
        {
            throw new NotImplementedException();
        }

        public static T Deserialize<T>(ref XmlReader reader, XmlSerializerOptions? options = null)
        {
            throw new NotImplementedException();
        }

        public static T Deserialize<T>(PipeReader reader, XmlSerializerOptions? options = null)
        {
            throw new NotImplementedException();
        }

        public static T Deserialize<T>(Stream stream, XmlSerializerOptions? options = null)
        {
            throw new NotImplementedException();
        }
    }
}
