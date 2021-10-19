using System;
using System.IO;
using System.IO.Pipelines;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UnMango.Xml;

public static partial class XmlSerializer
{
    /// <summary>
    /// Deserializes <paramref name="xml"/>.
    /// </summary>
    /// <param name="type">The type of the value to deserialize.</param>
    /// <param name="xml">The value to deserialize.</param>
    /// <param name="cancellationToken">
    /// The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.
    /// </param>
    /// <returns>
    /// A <see cref="ValueTask"/> representing the asynchronous operation, containing the deserialized object or <code>default(T)</code>.
    /// </returns>
    public static ValueTask<object> DeserializeAsync(
        Type type,
        string xml,
        CancellationToken cancellationToken = default)
        => DeserializeAsync(type, xml, null, cancellationToken);

    /// <summary>
    /// Deserializes <paramref name="xml"/>.
    /// </summary>
    /// <param name="type">The type of the value to deserialize.</param>
    /// <param name="xml">The value to deserialize.</param>
    /// <param name="options">Options for the operation.</param>
    /// <param name="cancellationToken">
    /// The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.
    /// </param>
    /// <returns>
    /// A <see cref="ValueTask"/> representing the asynchronous operation, containing the deserialized object or <code>default(T)</code>.
    /// </returns>
    public static ValueTask<object> DeserializeAsync(
        Type type,
        string xml,
        XmlSerializerOptions? options = null,
        CancellationToken cancellationToken = default)
        => DeserializeAsync(type, Encoding.UTF8.GetBytes(xml), options, cancellationToken);

    /// <summary>
    /// Deserializes <paramref name="bytes"/>.
    /// </summary>
    /// <param name="type">The type of the value to deserialize.</param>
    /// <param name="bytes">A UTF8 byte array to deserialize.</param>
    /// <param name="cancellationToken">
    /// The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.
    /// </param>
    /// <returns>
    /// A <see cref="ValueTask"/> representing the asynchronous operation, containing the deserialized object or <code>default(T)</code>.
    /// </returns>
    public static ValueTask<object> DeserializeAsync(
        Type type,
        byte[] bytes,
        CancellationToken cancellationToken = default)
        => DeserializeAsync(type, bytes.AsSpan(), null, cancellationToken);

    /// <summary>
    /// Deserializes <paramref name="bytes"/>.
    /// </summary>
    /// <param name="type">The type of the value to deserialize.</param>
    /// <param name="bytes">A UTF8 byte array to deserialize.</param>
    /// <param name="options">Options for the operation.</param>
    /// <param name="cancellationToken">
    /// The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.
    /// </param>
    /// <returns>
    /// A <see cref="ValueTask"/> representing the asynchronous operation, containing the deserialized object or <code>default(T)</code>.
    /// </returns>
    public static ValueTask<object> DeserializeAsync(
        Type type,
        byte[] bytes,
        XmlSerializerOptions? options = null,
        CancellationToken cancellationToken = default)
        => DeserializeAsync(type, bytes.AsSpan(), options, cancellationToken);

    /// <summary>
    /// Deserializes <paramref name="bytes"/>.
    /// </summary>
    /// <param name="type">The type of the value to deserialize.</param>
    /// <param name="bytes">A UTF8 byte array to deserialize.</param>
    /// <param name="offset">The offset to start at in <paramref name="bytes"/>.</param>
    /// <param name="cancellationToken">
    /// The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.
    /// </param>
    /// <returns>
    /// A <see cref="ValueTask"/> representing the asynchronous operation, containing the deserialized object or <code>default(T)</code>.
    /// </returns>
    public static ValueTask<object> DeserializeAsync(
        Type type,
        byte[] bytes,
        int offset,
        CancellationToken cancellationToken = default)
        => DeserializeAsync(type, bytes.AsSpan(offset), null, cancellationToken);

    /// <summary>
    /// Deserializes <paramref name="bytes"/>.
    /// </summary>
    /// <param name="type">The type of the value to deserialize.</param>
    /// <param name="bytes">A UTF8 byte array to deserialize.</param>
    /// <param name="offset">The offset to start at in <paramref name="bytes"/>.</param>
    /// <param name="options">Options for the operation.</param>
    /// <param name="cancellationToken">
    /// The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.
    /// </param>
    /// <returns>
    /// A <see cref="ValueTask"/> representing the asynchronous operation, containing the deserialized object or <code>default(T)</code>.
    /// </returns>
    public static ValueTask<object> DeserializeAsync(
        Type type,
        byte[] bytes,
        int offset,
        XmlSerializerOptions? options = null,
        CancellationToken cancellationToken = default)
        => DeserializeAsync(type, bytes.AsSpan(offset), options, cancellationToken);

    /// <summary>
    /// Deserializes <paramref name="span"/>.
    /// </summary>
    /// <param name="type">The type of the value to deserialize.</param>
    /// <param name="span">A <see cref="ReadOnlySpan{T}"/> to deserialize.</param>
    /// <param name="cancellationToken">
    /// The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.
    /// </param>
    /// <returns>
    /// A <see cref="ValueTask"/> representing the asynchronous operation, containing the deserialized object or <code>default(T)</code>.
    /// </returns>
    public static ValueTask<object> DeserializeAsync(
        Type type,
        ReadOnlySpan<byte> span,
        CancellationToken cancellationToken = default)
        => DeserializeAsync(type, span, null, cancellationToken);

    /// <summary>
    /// Deserializes <paramref name="span"/>.
    /// </summary>
    /// <param name="type">The type of the value to deserialize.</param>
    /// <param name="span">A <see cref="ReadOnlySpan{T}"/> to deserialize.</param>
    /// <param name="options">Options for the operation.</param>
    /// <param name="cancellationToken">
    /// The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.
    /// </param>
    /// <returns>
    /// A <see cref="ValueTask"/> representing the asynchronous operation, containing the deserialized object or <code>default(T)</code>.
    /// </returns>
    public static ValueTask<object> DeserializeAsync(
        Type type,
        ReadOnlySpan<byte> span,
        XmlSerializerOptions? options = null,
        CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Deserializes <paramref name="reader"/>.
    /// </summary>
    /// <param name="type">The type of the value to deserialize.</param>
    /// <param name="reader">A <see cref="XmlReader"/> to read from.</param>
    /// <param name="cancellationToken">
    /// The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.
    /// </param>
    /// <returns>
    /// A <see cref="ValueTask"/> representing the asynchronous operation, containing the deserialized object or <code>default(T)</code>.
    /// </returns>
    public static ValueTask<object> DeserializeAsync(
        Type type,
        ref XmlReader reader,
        CancellationToken cancellationToken = default)
        => DeserializeAsync(type, ref reader, null, cancellationToken);

    /// <summary>
    /// Deserializes <paramref name="reader"/>.
    /// </summary>
    /// <param name="type">The type of the value to deserialize.</param>
    /// <param name="reader">A <see cref="XmlReader"/> to read from.</param>
    /// <param name="options">Options for the operation.</param>
    /// <param name="cancellationToken">
    /// The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.
    /// </param>
    /// <returns>
    /// A <see cref="ValueTask"/> representing the asynchronous operation, containing the deserialized object or <code>default(T)</code>.
    /// </returns>
    public static ValueTask<object> DeserializeAsync(
        Type type,
        ref XmlReader reader,
        XmlSerializerOptions? options = null,
        CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Deserializes <paramref name="reader"/>.
    /// </summary>
    /// <param name="type">The type of the value to deserialize.</param>
    /// <param name="reader">A <see cref="PipeReader"/> to read from.</param>
    /// <param name="cancellationToken">
    /// The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.
    /// </param>
    /// <returns>
    /// A <see cref="ValueTask"/> representing the asynchronous operation, containing the deserialized object or <code>default(T)</code>.
    /// </returns>
    public static ValueTask<object> DeserializeAsync(
        Type type,
        PipeReader reader,
        CancellationToken cancellationToken = default)
        => DeserializeAsync(type, reader, null, cancellationToken);

    /// <summary>
    /// Deserializes <paramref name="reader"/>.
    /// </summary>
    /// <param name="type">The type of the value to deserialize.</param>
    /// <param name="reader">A <see cref="PipeReader"/> to read from.</param>
    /// <param name="options">Options for the operation.</param>
    /// <param name="cancellationToken">
    /// The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.
    /// </param>
    /// <returns>
    /// A <see cref="ValueTask"/> representing the asynchronous operation, containing the deserialized object or <code>default(T)</code>.
    /// </returns>
    public static ValueTask<object> DeserializeAsync(
        Type type,
        PipeReader reader,
        XmlSerializerOptions? options = null,
        CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Deserializes <paramref name="stream"/>.
    /// </summary>
    /// <param name="type">The type of the value to deserialize.</param>
    /// <param name="stream">A <see cref="Stream"/> to read from.</param>
    /// <param name="cancellationToken">
    /// The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.
    /// </param>
    /// <returns>
    /// A <see cref="ValueTask"/> representing the asynchronous operation, containing the deserialized object or <code>default(T)</code>.
    /// </returns>
    public static ValueTask<object> DeserializeAsync(
        Type type,
        Stream stream,
        CancellationToken cancellationToken = default)
        => DeserializeAsync(type, stream, null, cancellationToken);

    /// <summary>
    /// Deserializes <paramref name="stream"/>.
    /// </summary>
    /// <param name="type">The type of the value to deserialize.</param>
    /// <param name="stream">A <see cref="Stream"/> to read from.</param>
    /// <param name="options">Options for the operation.</param>
    /// <param name="cancellationToken">
    /// The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.
    /// </param>
    /// <returns>
    /// A <see cref="ValueTask"/> representing the asynchronous operation, containing the deserialized object or <code>default(T)</code>.
    /// </returns>
    public static ValueTask<object> DeserializeAsync(
        Type type,
        Stream stream,
        XmlSerializerOptions? options = null,
        CancellationToken cancellationToken = default)
        => DeserializeAsync(type, PipeReader.Create(stream), options, cancellationToken);
}