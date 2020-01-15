using System;
using System.IO;
using System.IO.Pipelines;

namespace Unmango.Xml
{
    public static partial class XmlSerializer
    {
        public static byte[] Serialize(object value, XmlSerializerOptions? options = null)
        {
            throw new NotImplementedException();
        }

        public static byte[] Serialize(
            Type type,
            object value,
            XmlSerializerOptions? options = null)
        {
            throw new NotImplementedException();
        }

        public static void Serialize(
            ref XmlWriter writer,
            object value,
            XmlSerializerOptions? options = null)
        {
            throw new NotImplementedException();
        }

        public static void Serialize(
            Type type,
            ref XmlWriter writer,
            object value,
            XmlSerializerOptions? options = null)
        {
            throw new NotImplementedException();
        }

        public static void Serialize(
            PipeWriter writer,
            object value,
            XmlSerializerOptions? options = null)
        {
            throw new NotImplementedException();
        }

        public static void Serialize(
            Type type,
            PipeWriter writer,
            object value,
            XmlSerializerOptions? options = null)
        {
            throw new NotImplementedException();
        }

        public static void Serialize(
            Stream stream,
            object value,
            XmlSerializerOptions? options = null)
        {
            throw new NotImplementedException();
        }

        public static void Serialize(
            Type type,
            Stream stream,
            object value,
            XmlSerializerOptions? options = null)
        {
            throw new NotImplementedException();
        }
    }
}
