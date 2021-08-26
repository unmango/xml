using System;
using System.IO;
using System.IO.Pipelines;

namespace UnMango.Xml
{
    public partial class XmlSerializer
    {
        /// <summary>
        /// Serializes <paramref name="value"/> to a UTF8 byte array.
        /// </summary>
        /// <typeparam name="T">The type to serialize.</typeparam>
        /// <param name="value">The value to serialize.</param>
        /// <param name="options">Options for the operation.</param>
        /// <returns>The value serialized as a UTF8 byte array.</returns>
        public static byte[] Serialize<T>(T value, XmlSerializerOptions? options = null)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Serializes <paramref name="value"/> to <paramref name="writer"/>.
        /// </summary>
        /// <typeparam name="T">The type to serialize.</typeparam>
        /// <param name="writer">The <see cref="XmlWriter"/> to serialize <paramref name="value"/> to.</param>
        /// <param name="value">The value to serialize.</param>
        /// <param name="options">Options for the operation.</param>
        public static void Serialize<T>(
            XmlWriter writer,
            T value,
            XmlSerializerOptions? options = null)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Serializes <paramref name="value"/> to <paramref name="writer"/>.
        /// </summary>
        /// <typeparam name="T">The type to serialize.</typeparam>
        /// <param name="writer">The <see cref="PipeWriter"/> to serialize <paramref name="value"/> to.</param>
        /// <param name="value">The value to serialize.</param>
        /// <param name="options">Options for the operation.</param>
        public static void Serialize<T>(
            PipeWriter writer,
            T value,
            XmlSerializerOptions? options = null)
            => Serialize(new XmlWriter(writer), value, options);

        /// <summary>
        /// Serializes <paramref name="value"/> to <paramref name="stream"/>.
        /// </summary>
        /// <typeparam name="T">The type to serialize.</typeparam>
        /// <param name="stream">The <see cref="Stream"/> to serialize <paramref name="value"/> to.</param>
        /// <param name="value">The value to serialize.</param>
        /// <param name="options">Options for the operation.</param>
        public static void Serialize<T>(Stream stream, T value, XmlSerializerOptions? options = null)
            => Serialize(PipeWriter.Create(stream), value, options);
    }
}
