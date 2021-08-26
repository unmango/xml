using System;
using System.IO;
using System.IO.Pipelines;
using System.Text;

namespace UnMango.Xml
{
    public partial class XmlSerializer
    {
        /// <summary>
        /// Deserializes <paramref name="xml"/> as a <paramref name="type"/>.
        /// </summary>
        /// <param name="type">The type of the value to deserialize.</param>
        /// <param name="xml">The value to deserialize.</param>
        /// <param name="options">Options for the operation.</param>
        /// <returns>The deserialized value.</returns>
        public static object Deserialize(Type type, string xml, XmlSerializerOptions? options = null)
            => Deserialize(type, Encoding.UTF8.GetBytes(xml), options);

        /// <summary>
        /// Deserializes <paramref name="bytes"/> as a <paramref name="type"/>.
        /// </summary>
        /// <param name="type">The type of the value to deserialize.</param>
        /// <param name="bytes">A UTF8 byte array to deserialize.</param>
        /// <param name="options">Options for the operation.</param>
        /// <returns>The deserialized value.</returns>
        public static object Deserialize(Type type, byte[] bytes, XmlSerializerOptions? options = null)
            => Deserialize(type, bytes.AsSpan(), options);

        /// <summary>
        /// Deserializes <paramref name="bytes"/> as a <paramref name="type"/> starting at <paramref name="offset"/>.
        /// </summary>
        /// <param name="type">The type of the value to deserialize.</param>
        /// <param name="bytes">A UTF8 byte array to deserialize.</param>
        /// <param name="offset">The offset to start at in <paramref name="bytes"/>.</param>
        /// <param name="options">Options for the operation.</param>
        /// <returns>The deserialized value.</returns>
        public static object Deserialize(
            Type type,
            byte[] bytes,
            int offset,
            XmlSerializerOptions? options = null)
            => Deserialize(type, bytes.AsSpan(offset), options);

        /// <summary>
        /// Deserializes <paramref name="span"/> as a <paramref name="type"/>.
        /// </summary>
        /// <param name="type">The type of the value to deserialize.</param>
        /// <param name="span">The <see cref="ReadOnlySpan{T}"/> to deserialize.</param>
        /// <param name="options">Options for the operation.</param>
        /// <returns>The deserialized value.</returns>
        public static object Deserialize(
            Type type,
            in ReadOnlySpan<byte> span,
            XmlSerializerOptions? options = null)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Deserializes <paramref name="reader"/> as a <paramref name="type"/>.
        /// </summary>
        /// <param name="type">The type of the value to deserialize.</param>
        /// <param name="reader">The <see cref="XmlReader"/> to deserialize.</param>
        /// <param name="options">Options for the operation.</param>
        /// <returns>The deserialized value.</returns>
        public static object Deserialize(
            Type type,
            ref XmlReader reader,
            XmlSerializerOptions? options = null)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Deserializes <paramref name="reader"/> as a <paramref name="type"/>.
        /// </summary>
        /// <param name="type">The type of the value to deserialize.</param>
        /// <param name="reader">The <see cref="PipeReader"/> to deserialize.</param>
        /// <param name="options">Options for the operation.</param>
        /// <returns>The deserialized value.</returns>
        public static object Deserialize(Type type, PipeReader reader, XmlSerializerOptions? options = null)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Deserializes <paramref name="stream"/> as a <paramref name="type"/>.
        /// </summary>
        /// <param name="type">The type of the value to deserialize.</param>
        /// <param name="stream">The <see cref="Stream"/> to deserialize.</param>
        /// <param name="options">Options for the operation.</param>
        /// <returns>The deserialized value.</returns>
        public static object Deserialize(Type type, Stream stream, XmlSerializerOptions? options = null)
            => Deserialize(type, PipeReader.Create(stream), options);
    }
}
