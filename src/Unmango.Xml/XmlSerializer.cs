using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipelines;
using System.Text;
using System.Threading.Tasks;

namespace Unmango.Xml
{
    /// <summary>
    /// High level serialization and deserialization of xml.
    /// </summary>
    public static class XmlSerializer
    {
        public static T Deserialize<T>(string xml)
        {
            throw new NotImplementedException();
        }

        public static T Deserialize<T>(byte[] bytes) => Deserialize<T>(bytes, 0);

        public static T Deserialize<T>(byte[] bytes, int offset)
        {
            throw new NotImplementedException();
        }

        public static T Deserialize<T>(ref XmlReader reader)
        {
            throw new NotImplementedException();
        }

        public static T Deserialize<T>(PipeReader reader)
        {
            throw new NotImplementedException();
        }

        public static T Deserialize<T>(Stream stream)
        {
            throw new NotImplementedException();
        }
        public static ValueTask<T> DeserializeAsync<T>(string xml)
        {
            throw new NotImplementedException();
        }

        public static ValueTask<T> DeserializeAsync<T>(byte[] bytes) => DeserializeAsync<T>(bytes, 0);

        public static ValueTask<T> DeserializeAsync<T>(byte[] bytes, int offset)
        {
            throw new NotImplementedException();
        }

        public static ValueTask<T> DeserializeAsync<T>(ref XmlReader reader)
        {
            throw new NotImplementedException();
        }

        public static ValueTask<T> DeserializeAsync<T>(PipeReader reader)
        {
            throw new NotImplementedException();
        }

        public static ValueTask<T> DeserializeAsync<T>(Stream stream)
        {
            throw new NotImplementedException();
        }

        public static byte[] Serialize<T>(T value)
        {
            throw new NotImplementedException();
        }

        public static void Serialize<T>(ref XmlWriter writer, T value)
        {
            throw new NotImplementedException();
        }

        public static void Serialize<T>(PipeWriter writer, T value)
        {
            throw new NotImplementedException();
        }

        public static void Serialize<T>(Stream stream, T value)
        {
            throw new NotImplementedException();
        }

        public static ValueTask<byte[]> SerializeAsync<T>(T value)
        {
            throw new NotImplementedException();
        }

        public static ValueTask SerializeAsync<T>(ref XmlWriter writer, T value)
        {
            throw new NotImplementedException();
        }

        public static ValueTask SerializeAsync<T>(PipeWriter writer, T value)
        {
            throw new NotImplementedException();
        }

        public static ValueTask SerializeAsync<T>(Stream stream, T value)
        {
            throw new NotImplementedException();
        }
    }
}
