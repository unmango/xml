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
    /// Deserializes <paramref name="xml"/> as a <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type to deserialize.</typeparam>
    /// <param name="xml">The value to deserialize.</param>
    /// <param name="cancellationToken">
    /// The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.
    /// </param>
    /// <returns>
    /// A <see cref="ValueTask"/> representing the asynchronous operation, containing the deserialized object or <code>default(T)</code>.
    /// </returns>
    public static ValueTask<T> DeserializeAsync<T>(
        string xml,
        CancellationToken cancellationToken = default)
        => DeserializeAsync<T>(xml, null, cancellationToken);

    /// <summary>
    /// Deserializes <paramref name="xml"/> as a <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type to deserialize.</typeparam>
    /// <param name="xml">The value to deserialize.</param>
    /// <param name="options">Options for the operation.</param>
    /// <param name="cancellationToken">
    /// The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.
    /// </param>
    /// <returns>
    /// A <see cref="ValueTask"/> representing the asynchronous operation, containing the deserialized object or <code>default(T)</code>.
    /// </returns>
    public static ValueTask<T> DeserializeAsync<T>(
        string xml,
        XmlSerializerOptions? options = null,
        CancellationToken cancellationToken = default)
        => DeserializeAsync<T>(Encoding.UTF8.GetBytes(xml), options, cancellationToken);

    /// <summary>
    /// Deserializes <paramref name="bytes"/> as a <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type to deserialize.</typeparam>
    /// <param name="bytes">A UTF8 byte array to deserialize.</param>
    /// <param name="cancellationToken">
    /// The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.
    /// </param>
    /// <returns>
    /// A <see cref="ValueTask"/> representing the asynchronous operation, containing the deserialized object or <code>default(T)</code>.
    /// </returns>
    public static ValueTask<T> DeserializeAsync<T>(
        byte[] bytes,
        CancellationToken cancellationToken = default)
        => DeserializeAsync<T>(bytes.AsSpan(), null, cancellationToken);

    /// <summary>
    /// Deserializes <paramref name="bytes"/> as a <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type to deserialize.</typeparam>
    /// <param name="bytes">A UTF8 byte array to deserialize.</param>
    /// <param name="options">Options for the operation.</param>
    /// <param name="cancellationToken">
    /// The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.
    /// </param>
    /// <returns>
    /// A <see cref="ValueTask"/> representing the asynchronous operation, containing the deserialized object or <code>default(T)</code>.
    /// </returns>
    public static ValueTask<T> DeserializeAsync<T>(
        byte[] bytes,
        XmlSerializerOptions? options = null,
        CancellationToken cancellationToken = default)
        => DeserializeAsync<T>(bytes.AsSpan(), options, cancellationToken);

    /// <summary>
    /// Deserializes <paramref name="bytes"/> as a <typeparamref name="T"/> starting at <paramref name="offset"/>.
    /// </summary>
    /// <typeparam name="T">The type to deserialize.</typeparam>
    /// <param name="bytes">The value to deserialize.</param>
    /// <param name="offset">The offset to start at in <paramref name="bytes"/>.</param>
    /// <param name="cancellationToken">
    /// The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.
    /// </param>
    /// <returns>
    /// A <see cref="ValueTask"/> representing the asynchronous operation, containing the deserialized object or <code>default(T)</code>.
    /// </returns>
    public static ValueTask<T> DeserializeAsync<T>(
        byte[] bytes,
        int offset,
        CancellationToken cancellationToken = default)
        => DeserializeAsync<T>(bytes.AsSpan(offset), null, cancellationToken);

    /// <summary>
    /// Deserializes <paramref name="bytes"/> as a <typeparamref name="T"/> starting at <paramref name="offset"/>.
    /// </summary>
    /// <typeparam name="T">The type to deserialize.</typeparam>
    /// <param name="bytes">The value to deserialize.</param>
    /// <param name="offset">The offset to start at in <paramref name="bytes"/>.</param>
    /// <param name="options">Options for the operation.</param>
    /// <param name="cancellationToken">
    /// The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.
    /// </param>
    /// <returns>
    /// A <see cref="ValueTask"/> representing the asynchronous operation, containing the deserialized object or <code>default(T)</code>.
    /// </returns>
    public static ValueTask<T> DeserializeAsync<T>(
        byte[] bytes,
        int offset,
        XmlSerializerOptions? options = null,
        CancellationToken cancellationToken = default)
        => DeserializeAsync<T>(bytes.AsSpan(offset), options, cancellationToken);

    /// <summary>
    /// Deserializes <paramref name="span"/> as a <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type to deserialize.</typeparam>
    /// <param name="span">The <see cref="ReadOnlySpan{T}"/> to deserialize.</param>
    /// <param name="cancellationToken">
    /// The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.
    /// </param>
    /// <returns>
    /// A <see cref="ValueTask"/> representing the asynchronous operation, containing the deserialized object or <code>default(T)</code>.
    /// </returns>
    public static ValueTask<T> DeserializeAsync<T>(
        ReadOnlySpan<byte> span,
        CancellationToken cancellationToken = default)
        => DeserializeAsync<T>(span, null, cancellationToken);

    /// <summary>
    /// Deserializes <paramref name="span"/> as a <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type to deserialize.</typeparam>
    /// <param name="span">The <see cref="ReadOnlySpan{T}"/> to deserialize.</param>
    /// <param name="options">Options for the operation.</param>
    /// <param name="cancellationToken">
    /// The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.
    /// </param>
    /// <returns>
    /// A <see cref="ValueTask"/> representing the asynchronous operation, containing the deserialized object or <code>default(T)</code>.
    /// </returns>
    public static ValueTask<T> DeserializeAsync<T>(
        ReadOnlySpan<byte> span,
        XmlSerializerOptions? options = null,
        CancellationToken cancellationToken = default)
    {
        var readerOptions = XmlReaderOptions.From(options);
        var reader = new XmlReader(span, readerOptions);
        return DeserializeAsync<T>(ref reader, options, cancellationToken);
    }

    /// <summary>
    /// Deserializes <paramref name="reader"/> as a <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type to deserialize.</typeparam>
    /// <param name="reader">The <see cref="XmlReader"/> to deserialize.</param>
    /// <param name="cancellationToken">
    /// The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.
    /// </param>
    /// <returns>
    /// A <see cref="ValueTask"/> representing the asynchronous operation, containing the deserialized object or <code>default(T)</code>.
    /// </returns>
    public static ValueTask<T> DeserializeAsync<T>(
        ref XmlReader reader,
        CancellationToken cancellationToken = default)
        => DeserializeAsync<T>(ref reader, null, cancellationToken);

    /// <summary>
    /// Deserializes <paramref name="reader"/> as a <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type to deserialize.</typeparam>
    /// <param name="reader">The <see cref="XmlReader"/> to deserialize.</param>
    /// <param name="options">Options for the operation.</param>
    /// <param name="cancellationToken">
    /// The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.
    /// </param>
    /// <returns>
    /// A <see cref="ValueTask"/> representing the asynchronous operation, containing the deserialized object or <code>default(T)</code>.
    /// </returns>
    public static ValueTask<T> DeserializeAsync<T>(
        ref XmlReader reader,
        XmlSerializerOptions? options = null,
        CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Deserializes <paramref name="reader"/> as a <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type to deserialize.</typeparam>
    /// <param name="reader">The <see cref="PipeReader"/> to deserialize.</param>
    /// <param name="cancellationToken">
    /// The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.
    /// </param>
    /// <returns>
    /// A <see cref="ValueTask"/> representing the asynchronous operation, containing the deserialized object or <code>default(T)</code>.
    /// </returns>
    public static ValueTask<T> DeserializeAsync<T>(
        PipeReader reader,
        CancellationToken cancellationToken = default)
        => DeserializeAsync<T>(reader, null, cancellationToken);

    /// <summary>
    /// Deserializes <paramref name="reader"/> as a <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type to deserialize.</typeparam>
    /// <param name="reader">The <see cref="PipeReader"/> to deserialize.</param>
    /// <param name="options">Options for the operation.</param>
    /// <param name="cancellationToken">
    /// The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.
    /// </param>
    /// <returns>
    /// A <see cref="ValueTask"/> representing the asynchronous operation, containing the deserialized object or <code>default(T)</code>.
    /// </returns>
    public static ValueTask<T> DeserializeAsync<T>(
        PipeReader reader,
        XmlSerializerOptions? options = null,
        CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Deserializes <paramref name="stream"/> as a <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type to deserialize.</typeparam>
    /// <param name="stream">The <see cref="Stream"/> to deserialize.</param>
    /// <param name="cancellationToken">
    /// The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.
    /// </param>
    /// <returns>
    /// A <see cref="ValueTask"/> representing the asynchronous operation, containing the deserialized object or <code>default(T)</code>.
    /// </returns>
    public static ValueTask<T> DeserializeAsync<T>(
        Stream stream,
        CancellationToken cancellationToken = default)
        => DeserializeAsync<T>(stream, null, cancellationToken);

    /// <summary>
    /// Deserializes <paramref name="stream"/> as a <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type to deserialize.</typeparam>
    /// <param name="stream">The <see cref="Stream"/> to deserialize.</param>
    /// <param name="options">Options for the operation.</param>
    /// <param name="cancellationToken">
    /// The <see cref="CancellationToken"/> used to propagate notifications that the operation should be canceled.
    /// </param>
    /// <returns>
    /// A <see cref="ValueTask"/> representing the asynchronous operation, containing the deserialized object or <code>default(T)</code>.
    /// </returns>
    public static ValueTask<T> DeserializeAsync<T>(
        Stream stream,
        XmlSerializerOptions? options = null,
        CancellationToken cancellationToken = default)
        => DeserializeAsync<T>(PipeReader.Create(stream), options, cancellationToken);
}