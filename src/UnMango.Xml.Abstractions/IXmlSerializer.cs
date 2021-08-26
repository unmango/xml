using System;
using System.IO;
using System.IO.Pipelines;
using System.Xml;
using JetBrains.Annotations;

namespace UnMango.Xml
{
    [PublicAPI]
    public interface IXmlSerializer
    {
        /// <summary>
        /// Deserializes <paramref name="xml"/> as a <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type to deserialize.</typeparam>
        /// <param name="xml">The value to deserialize.</param>
        /// <param name="options">Options for the operation.</param>
        /// <returns>The deserialized value.</returns>
        static abstract T Deserialize<T>(string xml, XmlSerializerOptions? options = null);

        /// <summary>
        /// Deserializes <paramref name="bytes"/> as a <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type to deserialize.</typeparam>
        /// <param name="bytes">A UTF8 byte array to deserialize.</param>
        /// <param name="options">Options for the operation.</param>
        /// <returns>The deserialized value.</returns>
        static abstract T Deserialize<T>(byte[] bytes, XmlSerializerOptions? options = null);

        /// <summary>
        /// Deserializes <paramref name="bytes"/> as a <typeparamref name="T"/> starting at <paramref name="offset"/>.
        /// </summary>
        /// <typeparam name="T">The type to deserialize.</typeparam>
        /// <param name="bytes">A UTF8 byte array to deserialize.</param>
        /// <param name="offset">The offset to start at in <paramref name="bytes"/>.</param>
        /// <param name="options">Options for the operation.</param>
        /// <returns>The deserialized value.</returns>
        static abstract T Deserialize<T>(byte[] bytes, int offset, XmlSerializerOptions? options = null);

        /// <summary>
        /// Deserializes <paramref name="span"/> as a <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type to deserialize.</typeparam>
        /// <param name="span">The <see cref="ReadOnlySpan{T}"/> to deserialize.</param>
        /// <param name="options">Options for the operation.</param>
        /// <returns>The deserialized value.</returns>
        static abstract T Deserialize<T>(in ReadOnlySpan<byte> span, XmlSerializerOptions? options = null);

        /// <summary>
        /// Deserializes <paramref name="reader"/> as a <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type to deserialize.</typeparam>
        /// <param name="reader">The <see cref="XmlReader"/> to deserialize.</param>
        /// <param name="options">Options for the operation.</param>
        /// <returns>The deserialized value.</returns>
        static abstract T Deserialize<T>(ref XmlReader reader, XmlSerializerOptions? options = null);

        /// <summary>
        /// Deserializes <paramref name="reader"/> as a <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type to deserialize.</typeparam>
        /// <param name="reader">The <see cref="PipeReader"/> to deserialize.</param>
        /// <param name="options">Options for the operation.</param>
        /// <returns>The deserialized value.</returns>
        static abstract T Deserialize<T>(PipeReader reader, XmlSerializerOptions? options = null);

        /// <summary>
        /// Deserializes <paramref name="stream"/> as a <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type to deserialize.</typeparam>
        /// <param name="stream">The <see cref="Stream"/> to deserialize.</param>
        /// <param name="options">Options for the operation.</param>
        /// <returns>The deserialized value.</returns>
        static abstract T Deserialize<T>(Stream stream, XmlSerializerOptions? options = null);
    }
}
