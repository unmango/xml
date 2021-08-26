using System;
using System.IO;
using System.IO.Pipelines;
using System.Threading;
using System.Threading.Tasks;

namespace UnMango.Xml
{
    public partial class XmlSerializer
    {
        /// <summary>
        /// Serializes <paramref name="value"/> as XML to a UTF8 byte array.
        /// </summary>
        /// <param name="value">The value to serialize.</param>
        /// <param name="cancellationToken">
        /// The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.
        /// </param>
        /// <returns>
        /// A <see cref="ValueTask"/> representing the asynchronous operation, containing the serialized byte array or null.
        /// </returns>
        public static ValueTask<byte[]> SerializeAsync(
            object value,
            CancellationToken cancellationToken = default)
            => SerializeAsync(value, null, cancellationToken);

        /// <summary>
        /// Serializes <paramref name="value"/> as XML to a UTF8 byte array.
        /// </summary>
        /// <param name="value">The value to serialize.</param>
        /// <param name="options">Options for the operation.</param>
        /// <param name="cancellationToken">
        /// The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.
        /// </param>
        /// <returns>
        /// A <see cref="ValueTask"/> representing the asynchronous operation, containing the serialized byte array or null.
        /// </returns>
        public static ValueTask<byte[]> SerializeAsync(
            object? value,
            XmlSerializerOptions? options = null,
            CancellationToken cancellationToken = default)
            => value == null
                ? SerializeAsync<object>((object)null!, options, cancellationToken)
                : SerializeAsync(value.GetType(), options, cancellationToken);

        /// <summary>
        /// Serializes <paramref name="value"/> as XML to a UTF8 byte array.
        /// </summary>
        /// <param name="type">The type of the value to serialize.</param>
        /// <param name="value">The value to serialize.</param>
        /// <param name="cancellationToken">
        /// The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.
        /// </param>
        /// <returns>
        /// A <see cref="ValueTask"/> representing the asynchronous operation, containing the serialized byte array or null.
        /// </returns>
        public static ValueTask<byte[]> SerializeAsync(
            Type type,
            object value,
            CancellationToken cancellationToken = default)
            => SerializeAsync(type, value, null, cancellationToken);

        /// <summary>
        /// Serializes <paramref name="value"/> as XML to a UTF8 byte array.
        /// </summary>
        /// <param name="type">The type of the value to serialize.</param>
        /// <param name="value">The value to serialize.</param>
        /// <param name="options">Options for the operation.</param>
        /// <param name="cancellationToken">
        /// The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.
        /// </param>
        /// <returns>
        /// A <see cref="ValueTask"/> representing the asynchronous operation, containing the serialized byte array or null.
        /// </returns>
        public static ValueTask<byte[]> SerializeAsync(
            Type type,
            object value,
            XmlSerializerOptions? options = null,
            CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Serializes <paramref name="value"/> to <paramref name="writer"/>.
        /// </summary>
        /// <param name="writer">The <see cref="XmlWriter"/> to serialize <paramref name="value"/> to.</param>
        /// <param name="value">The value to serialize.</param>
        /// <param name="cancellationToken">
        /// The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.
        /// </param>
        /// <returns>A <see cref="ValueTask"/> representing the asynchronous operation.</returns>
        public static ValueTask SerializeAsync(
            XmlWriter writer,
            object value,
            CancellationToken cancellationToken = default)
            => SerializeAsync(writer, value, null, cancellationToken);

        /// <summary>
        /// Serializes <paramref name="value"/> to <paramref name="writer"/>.
        /// </summary>
        /// <param name="writer">The <see cref="XmlWriter"/> to serialize <paramref name="value"/> to.</param>
        /// <param name="value">The value to serialize.</param>
        /// <param name="options">Options for the operation.</param>
        /// <param name="cancellationToken">
        /// The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.
        /// </param>
        /// <returns>A <see cref="ValueTask"/> representing the asynchronous operation.</returns>
        public static ValueTask SerializeAsync(
            XmlWriter writer,
            object value,
            XmlSerializerOptions? options = null,
            CancellationToken cancellationToken = default)
            => value == null
                ? SerializeAsync<object>(writer, null!, options, cancellationToken)
                : SerializeAsync(value.GetType(), writer, value, options, cancellationToken);

        /// <summary>
        /// Serializes <paramref name="value"/> to <paramref name="writer"/>.
        /// </summary>
        /// <param name="type">The type of the value to serialize.</param>
        /// <param name="writer">The <see cref="XmlWriter"/> to serialize <paramref name="value"/> to.</param>
        /// <param name="value">The value to serialize.</param>
        /// <param name="cancellationToken">
        /// The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.
        /// </param>
        /// <returns>A <see cref="ValueTask"/> representing the asynchronous operation.</returns>
        public static ValueTask SerializeAsync(
            Type type,
            XmlWriter writer,
            object value,
            CancellationToken cancellationToken = default)
            => SerializeAsync(type, writer, value, null, cancellationToken);

        /// <summary>
        /// Serializes <paramref name="value"/> to <paramref name="writer"/>.
        /// </summary>
        /// <param name="type">The type of the value to serialize.</param>
        /// <param name="writer">The <see cref="XmlWriter"/> to serialize <paramref name="value"/> to.</param>
        /// <param name="value">The value to serialize.</param>
        /// <param name="options">Options for the operation.</param>
        /// <param name="cancellationToken">
        /// The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.
        /// </param>
        /// <returns>A <see cref="ValueTask"/> representing the asynchronous operation.</returns>
        public static ValueTask SerializeAsync(
            Type type,
            XmlWriter writer,
            object value,
            XmlSerializerOptions? options = null,
            CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Serializes <paramref name="value"/> to <paramref name="writer"/>.
        /// </summary>
        /// <param name="writer">The <see cref="PipeWriter"/> to serialize <paramref name="value"/> to.</param>
        /// <param name="value">The value to serialize.</param>
        /// <param name="cancellationToken">
        /// The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.
        /// </param>
        /// <returns>A <see cref="ValueTask"/> representing the asynchronous operation.</returns>
        public static ValueTask SerializeAsync(
            PipeWriter writer,
            object value,
            CancellationToken cancellationToken = default)
            => SerializeAsync(writer, value, null, cancellationToken);

        /// <summary>
        /// Serializes <paramref name="value"/> to <paramref name="writer"/>.
        /// </summary>
        /// <param name="writer">The <see cref="PipeWriter"/> to serialize <paramref name="value"/> to.</param>
        /// <param name="value">The value to serialize.</param>
        /// <param name="options">Options for the operation.</param>
        /// <param name="cancellationToken">
        /// The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.
        /// </param>
        /// <returns>A <see cref="ValueTask"/> representing the asynchronous operation.</returns>
        public static ValueTask SerializeAsync(
            PipeWriter writer,
            object value,
            XmlSerializerOptions? options = null,
            CancellationToken cancellationToken = default)
        {
            return value == null
                ? SerializeAsync<object>(writer, null!, options, cancellationToken)
                : SerializeAsync(value.GetType(), writer, value, options, cancellationToken);
        }

        /// <summary>
        /// Serializes <paramref name="value"/> to <paramref name="writer"/>.
        /// </summary>
        /// <param name="type">The type of the value to serialize.</param>
        /// <param name="writer">The <see cref="PipeWriter"/> to serialize <paramref name="value"/> to.</param>
        /// <param name="value">The value to serialize.</param>
        /// <param name="cancellationToken">
        /// The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.
        /// </param>
        /// <returns>A <see cref="ValueTask"/> representing the asynchronous operation.</returns>
        public static ValueTask SerializeAsync(
            Type type,
            PipeWriter writer,
            object value,
            CancellationToken cancellationToken = default)
            => SerializeAsync(type, writer, value, null, cancellationToken);

        /// <summary>
        /// Serializes <paramref name="value"/> to <paramref name="writer"/>.
        /// </summary>
        /// <param name="type">The type of the value to serialize.</param>
        /// <param name="writer">The <see cref="XmlWriter"/> to serialize <paramref name="value"/> to.</param>
        /// <param name="value">The value to serialize.</param>
        /// <param name="options">Options for the operation.</param>
        /// <param name="cancellationToken">
        /// The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.
        /// </param>
        /// <returns>A <see cref="ValueTask"/> representing the asynchronous operation.</returns>
        public static ValueTask SerializeAsync(
            Type type,
            PipeWriter writer,
            object value,
            XmlSerializerOptions? options = null,
            CancellationToken cancellationToken = default)
            => SerializeAsync(type, new XmlWriter(writer), value, options, cancellationToken);

        /// <summary>
        /// Serializes <paramref name="value"/> to <paramref name="stream"/>.
        /// </summary>
        /// <param name="stream">The <see cref="Stream"/> to serialize <paramref name="value"/> to.</param>
        /// <param name="value">The value to serialize.</param>
        /// <param name="cancellationToken">
        /// The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.
        /// </param>
        /// <returns>A <see cref="ValueTask"/> representing the asynchronous operation.</returns>
        public static ValueTask SerializeAsync(
            Stream stream,
            object value,
            CancellationToken cancellationToken = default)
            => SerializeAsync(PipeWriter.Create(stream), value, null, cancellationToken);

        /// <summary>
        /// Serializes <paramref name="value"/> to <paramref name="stream"/>.
        /// </summary>
        /// <param name="stream">The <see cref="Stream"/> to serialize <paramref name="value"/> to.</param>
        /// <param name="value">The value to serialize.</param>
        /// <param name="options">Options for the operation.</param>
        /// <param name="cancellationToken">
        /// The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.
        /// </param>
        /// <returns>A <see cref="ValueTask"/> representing the asynchronous operation.</returns>
        public static ValueTask SerializeAsync(
            Stream stream,
            object value,
            XmlSerializerOptions? options = null,
            CancellationToken cancellationToken = default)
            => value == null
                ? SerializeAsync<object>(stream, null!, options, cancellationToken)
                : SerializeAsync(value.GetType(), stream, value, options, cancellationToken);

        /// <summary>
        /// Serializes <paramref name="value"/> to <paramref name="stream"/>.
        /// </summary>
        /// <param name="type">The type of the value to serialize.</param>
        /// <param name="stream">The <see cref="Stream"/> to serialize <paramref name="value"/> to.</param>
        /// <param name="value">The value to serialize.</param>
        /// <param name="cancellationToken">
        /// The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.
        /// </param>
        /// <returns>A <see cref="ValueTask"/> representing the asynchronous operation.</returns>
        public static ValueTask SerializeAsync(
            Type type,
            Stream stream,
            object value,
            CancellationToken cancellationToken = default)
            => SerializeAsync(type, PipeWriter.Create(stream), value, null, cancellationToken);

        /// <summary>
        /// Serializes <paramref name="value"/> to <paramref name="stream"/>.
        /// </summary>
        /// <param name="type">The type of the value to serialize.</param>
        /// <param name="stream">The <see cref="Stream"/> to serialize <paramref name="value"/> to.</param>
        /// <param name="value">The value to serialize.</param>
        /// <param name="options">Options for the operation.</param>
        /// <param name="cancellationToken">
        /// The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.
        /// </param>
        /// <returns>A <see cref="ValueTask"/> representing the asynchronous operation.</returns>
        public static ValueTask SerializeAsync(
            Type type,
            Stream stream,
            object value,
            XmlSerializerOptions? options = null,
            CancellationToken cancellationToken = default)
            => SerializeAsync(type, PipeWriter.Create(stream), value, options, cancellationToken);
    }
}
