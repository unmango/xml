using System;
using System.IO;
using System.IO.Pipelines;

namespace Unmango.Xml
{
    public static partial class XmlSerializer
    {
        public static byte[] Serialize<T>(T value, XmlSerializerOptions? options = null)
        {
            throw new NotImplementedException();
        }

        public static void Serialize<T>(
            ref XmlWriter writer,
            T value,
            XmlSerializerOptions? options = null)
        {
            throw new NotImplementedException();
        }

        public static void Serialize<T>(
            PipeWriter writer,
            T value,
            XmlSerializerOptions? options = null)
        {
            throw new NotImplementedException();
        }

        public static void Serialize<T>(Stream stream, T value, XmlSerializerOptions? options = null)
            => Serialize(PipeWriter.Create(stream), value, options);
    }
}
