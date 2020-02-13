using System;
using System.IO;
using System.IO.Pipelines;

namespace UnMango.Xml
{
    public static partial class XmlSerializer
    {
        public static object Deserialize(Type type, string xml, XmlSerializerOptions? options = null)
        {
            throw new NotImplementedException();
        }

        public static object Deserialize(Type type, byte[] bytes, XmlSerializerOptions? options = null)
            => Deserialize(type, bytes.AsSpan(), options);

        public static object Deserialize(
            Type type,
            byte[] bytes,
            int offset,
            XmlSerializerOptions? options = null)
            => Deserialize(type, bytes.AsSpan(offset), options);

        public static object Deserialize(
            Type type,
            ReadOnlySpan<byte> span,
            XmlSerializerOptions? options = null)
        {
            throw new NotImplementedException();
        }

        public static object Deserialize(
            Type type,
            ref XmlReader reader,
            XmlSerializerOptions? options = null)
        {
            throw new NotImplementedException();
        }

        public static object Deserialize(Type type, PipeReader reader, XmlSerializerOptions? options = null)
        {
            throw new NotImplementedException();
        }

        public static object Deserialize(Type type, Stream stream, XmlSerializerOptions? options = null)
            => Deserialize(type, PipeReader.Create(stream), options);
    }
}
