using System;
using System.IO;
using System.IO.Pipelines;
using System.Threading;
using System.Threading.Tasks;

namespace UnMango.Xml;

public static partial class XmlSerializer
{
    /// <summary>
    /// Serializes <paramref name="value"/> as XML to a UTF8 byte array.
    /// </summary>
    /// <typeparam name="T">The type to serialize.</typeparam>
    /// <param name="value">The value to serialize.</param>
    /// <param name="cancellationToken">
    /// The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.
    /// </param>
    /// <returns>
    /// A <see cref="ValueTask"/> representing the asynchronous operation, containing the serialized byte array or null.
    /// </returns>
    public static ValueTask<byte[]> SerializeAsync<T>(
        T value,
        CancellationToken cancellationToken = default)
        => SerializeAsync(value, null, cancellationToken);

    /// <summary>
    /// Serializes <paramref name="value"/> as XML to a UTF8 byte array.
    /// </summary>
    /// <typeparam name="T">The type to serialize.</typeparam>
    /// <param name="value">The value to serialize.</param>
    /// <param name="options">Options for the operation.</param>
    /// <param name="cancellationToken">
    /// The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.
    /// </param>
    /// <returns>
    /// A <see cref="ValueTask"/> representing the asynchronous operation, containing the serialized byte array or null.
    /// </returns>
    public static ValueTask<byte[]> SerializeAsync<T>(
        T value,
        XmlSerializerOptions? options = null,
        CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Serializes <paramref name="value"/> to <paramref name="writer"/>.
    /// </summary>
    /// <typeparam name="T">The type to serialize.</typeparam>
    /// <param name="writer">The <see cref="XmlWriter"/> to serialize <paramref name="value"/> to.</param>
    /// <param name="value">The value to serialize.</param>
    /// <param name="cancellationToken">
    /// The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.
    /// </param>
    /// <returns>A <see cref="ValueTask"/> representing the asynchronous operation.</returns>
    public static ValueTask SerializeAsync<T>(
        XmlWriter writer,
        T value,
        CancellationToken cancellationToken = default)
        => SerializeAsync(writer, value, null, cancellationToken);

    /// <summary>
    /// Serializes <paramref name="value"/> to <paramref name="writer"/>.
    /// </summary>
    /// <typeparam name="T">The type to serialize.</typeparam>
    /// <param name="writer">The <see cref="XmlWriter"/> to serialize <paramref name="value"/> to.</param>
    /// <param name="value">The value to serialize.</param>
    /// <param name="options">Options for the operation.</param>
    /// <param name="cancellationToken">
    /// The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.
    /// </param>
    /// <returns>A <see cref="ValueTask"/> representing the asynchronous operation.</returns>
    public static ValueTask SerializeAsync<T>(
        XmlWriter writer,
        T value,
        XmlSerializerOptions? options = null,
        CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Serializes <paramref name="value"/> to <paramref name="writer"/>.
    /// </summary>
    /// <typeparam name="T">The type to serialize.</typeparam>
    /// <param name="writer">The <see cref="PipeWriter"/> to serialize <paramref name="value"/> to.</param>
    /// <param name="value">The value to serialize.</param>
    /// <param name="cancellationToken">
    /// The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.
    /// </param>
    /// <returns>A <see cref="ValueTask"/> representing the asynchronous operation.</returns>
    public static ValueTask SerializeAsync<T>(
        PipeWriter writer,
        T value,
        CancellationToken cancellationToken = default)
        => SerializeAsync(writer, value, null, cancellationToken);

    /// <summary>
    /// Serializes <paramref name="value"/> to <paramref name="writer"/>.
    /// </summary>
    /// <typeparam name="T">The type to serialize.</typeparam>
    /// <param name="writer">The <see cref="PipeWriter"/> to serialize <paramref name="value"/> to.</param>
    /// <param name="value">The value to serialize.</param>
    /// <param name="options">Options for the operation.</param>
    /// <param name="cancellationToken">
    /// The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.
    /// </param>
    /// <returns>A <see cref="ValueTask"/> representing the asynchronous operation.</returns>
    public static ValueTask SerializeAsync<T>(
        PipeWriter writer,
        T value,
        XmlSerializerOptions? options = null,
        CancellationToken cancellationToken = default)
        => SerializeAsync(new XmlWriter(writer), value, options, cancellationToken);

    /// <summary>
    /// Serializes <paramref name="value"/> to <paramref name="stream"/>.
    /// </summary>
    /// <typeparam name="T">The type to serialize.</typeparam>
    /// <param name="stream">The <see cref="Stream"/> to serialize <paramref name="value"/> to.</param>
    /// <param name="value">The value to serialize.</param>
    /// <param name="cancellationToken">
    /// The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.
    /// </param>
    /// <returns>A <see cref="ValueTask"/> representing the asynchronous operation.</returns>
    public static ValueTask SerializeAsync<T>(
        Stream stream,
        T value,
        CancellationToken cancellationToken = default)
        => SerializeAsync(PipeWriter.Create(stream), value, null, cancellationToken);

    /// <summary>
    /// Serializes <paramref name="value"/> to <paramref name="stream"/>.
    /// </summary>
    /// <typeparam name="T">The type to serialize.</typeparam>
    /// <param name="stream">The <see cref="Stream"/> to serialize <paramref name="value"/> to.</param>
    /// <param name="value">The value to serialize.</param>
    /// <param name="options">Options for the operation.</param>
    /// <param name="cancellationToken">
    /// The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.
    /// </param>
    /// <returns>A <see cref="ValueTask"/> representing the asynchronous operation.</returns>
    public static ValueTask SerializeAsync<T>(
        Stream stream,
        T value,
        XmlSerializerOptions? options = null,
        CancellationToken cancellationToken = default)
        => SerializeAsync(PipeWriter.Create(stream), value, options, cancellationToken);
}