using System;
using System.IO;
using System.IO.Pipelines;
using System.Threading.Tasks;

namespace Unmango.Xml
{
    /// <summary>
    /// High level serialization and deserialization of xml.
    /// </summary>
    public static class XmlSerializer
    {
        public static object Deserialize(Type type, string xml)
        {
            throw new NotImplementedException();
        }

        public static object Deserialize(Type type, byte[] bytes) => Deserialize(type, bytes, 0);

        public static object Deserialize(Type type, byte[] bytes, int offset)
        {
            throw new NotImplementedException();
        }

        public static object Deserialize(Type type, ref XmlReader reader)
        {
            throw new NotImplementedException();
        }

        public static object Deserialize(Type type, PipeReader reader)
        {
            throw new NotImplementedException();
        }

        public static object Deserialize(Type type, Stream stream)
        {
            throw new NotImplementedException();
        }
        public static ValueTask<object> DeserializeAsync(Type type, string xml)
        {
            throw new NotImplementedException();
        }

        public static ValueTask<object> DeserializeAsync(Type type, byte[] bytes)
            => DeserializeAsync(type, bytes, 0);

        public static ValueTask<object> DeserializeAsync(Type type, byte[] bytes, int offset)
        {
            throw new NotImplementedException();
        }

        public static ValueTask<object> DeserializeAsync(Type type, ref XmlReader reader)
        {
            throw new NotImplementedException();
        }

        public static ValueTask<object> DeserializeAsync(Type type, PipeReader reader)
        {
            throw new NotImplementedException();
        }

        public static ValueTask<object> DeserializeAsync(Type type, Stream stream)
        {
            throw new NotImplementedException();
        }

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

        public static byte[] Serialize(object value)
        {
            throw new NotImplementedException();
        }

        public static byte[] Serialize(Type type, object value)
        {
            throw new NotImplementedException();
        }

        public static void Serialize(ref XmlWriter writer, object value)
        {
            throw new NotImplementedException();
        }

        public static void Serialize(Type type, ref XmlWriter writer, object value)
        {
            throw new NotImplementedException();
        }

        public static void Serialize(PipeWriter writer, object value)
        {
            throw new NotImplementedException();
        }

        public static void Serialize(Type type, PipeWriter writer, object value)
        {
            throw new NotImplementedException();
        }

        public static void Serialize(Stream stream, object value)
        {
            throw new NotImplementedException();
        }

        public static void Serialize(Type type, Stream stream, object value)
        {
            throw new NotImplementedException();
        }

        public static ValueTask<byte[]> SerializeAsync(object value)
        {
            throw new NotImplementedException();
        }

        public static ValueTask<byte[]> SerializeAsync(Type type, object value)
        {
            throw new NotImplementedException();
        }

        public static ValueTask SerializeAsync(ref XmlWriter writer, object value)
        {
            throw new NotImplementedException();
        }

        public static ValueTask SerializeAsync(Type type, ref XmlWriter writer, object value)
        {
            throw new NotImplementedException();
        }

        public static ValueTask SerializeAsync(PipeWriter writer, object value)
        {
            throw new NotImplementedException();
        }

        public static ValueTask SerializeAsync(Type type, PipeWriter writer, object value)
        {
            throw new NotImplementedException();
        }

        public static ValueTask SerializeAsync(Stream stream, object value)
        {
            throw new NotImplementedException();
        }

        public static ValueTask SerializeAsync(Type type, Stream stream, object value)
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
