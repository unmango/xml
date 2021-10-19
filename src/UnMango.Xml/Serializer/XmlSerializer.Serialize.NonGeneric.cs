using System;
using System.IO;
using System.IO.Pipelines;

namespace UnMango.Xml;

public static partial class XmlSerializer
{
    /// <summary>
    /// Serializes <paramref name="value"/> to a UTF8 byte array.
    /// </summary>
    /// <param name="value">The value to serialize.</param>
    /// <param name="options">Options for the operation.</param>
    /// <returns>The value serialized as a UTF8 byte array.</returns>
    public static byte[] Serialize(object? value, XmlSerializerOptions? options = null)
        => value == null
            ? Serialize<object>(null!, options)
            : Serialize(value.GetType(), value, options);

    /// <summary>
    /// Serializes <paramref name="value"/> to a UTF8 byte array.
    /// </summary>
    /// <param name="type">The type of the value to serialize.</param>
    /// <param name="value">The value to serialize.</param>
    /// <param name="options">Options for the operation.</param>
    /// <returns>The value serialized as a UTF8 byte array.</returns>
    public static byte[] Serialize(
        Type type,
        object value,
        XmlSerializerOptions? options = null)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Serializes <paramref name="value"/> to <paramref name="writer"/>.
    /// </summary>
    /// <param name="writer">The <see cref="XmlWriter"/> to serialize <paramref name="value"/> to.</param>
    /// <param name="value">The value to serialize.</param>
    /// <param name="options">Options for the operation.</param>
    public static void Serialize(
        XmlWriter writer,
        object value,
        XmlSerializerOptions? options = null)
    {
        if (value == null)
        {
            Serialize<object>(writer, null!, options);

            return;
        }

        Serialize(value.GetType(), writer, value, options);
    }

    /// <summary>
    /// Serializes <paramref name="value"/> to <paramref name="writer"/>.
    /// </summary>
    /// <param name="type">The type of the value to serialize.</param>
    /// <param name="writer">The <see cref="XmlWriter"/> to serialize <paramref name="value"/> to.</param>
    /// <param name="value">The value to serialize.</param>
    /// <param name="options">Options for the operation.</param>
    public static void Serialize(
        Type type,
        XmlWriter writer,
        object value,
        XmlSerializerOptions? options = null)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Serializes <paramref name="value"/> to <paramref name="writer"/>.
    /// </summary>
    /// <param name="writer">The <see cref="PipeWriter"/> to serialize <paramref name="value"/> to.</param>
    /// <param name="value">The value to serialize.</param>
    /// <param name="options">Options for the operation.</param>
    public static void Serialize(
        PipeWriter writer,
        object value,
        XmlSerializerOptions? options = null)
    {
        if (value == null)
        {
            Serialize<object>(writer, null!, options);

            return;
        }

        Serialize(value.GetType(), writer, options);
    }

    /// <summary>
    /// Serializes <paramref name="value"/> to <paramref name="writer"/>.
    /// </summary>
    /// <param name="type">The type of the value to serialize.</param>
    /// <param name="writer">The <see cref="PipeWriter"/> to serialize <paramref name="value"/> to.</param>
    /// <param name="value">The value to serialize.</param>
    /// <param name="options">Options for the operation.</param>
    public static void Serialize(
        Type type,
        PipeWriter writer,
        object value,
        XmlSerializerOptions? options = null)
        => Serialize(type, new XmlWriter(writer), value, options);

    /// <summary>
    /// Serializes <paramref name="value"/> to <paramref name="stream"/>.
    /// </summary>
    /// <param name="stream">The <see cref="Stream"/> to serialize <paramref name="value"/> to.</param>
    /// <param name="value">The value to serialize.</param>
    /// <param name="options">Options for the operation.</param>
    public static void Serialize(
        Stream stream,
        object value,
        XmlSerializerOptions? options = null)
    {
        if (value == null)
        {
            Serialize<object>(stream, null!, options);

            return;
        }

        Serialize(value.GetType(), stream, value, options);
    }

    /// <summary>
    /// Serializes <paramref name="value"/> to <paramref name="stream"/>.
    /// </summary>
    /// <param name="type">The type of the value to serialize.</param>
    /// <param name="stream">The <see cref="Stream"/> to serialize <paramref name="value"/> to.</param>
    /// <param name="value">The value to serialize.</param>
    /// <param name="options">Options for the operation.</param>
    public static void Serialize(
        Type type,
        Stream stream,
        object value,
        XmlSerializerOptions? options = null)
        => Serialize(type, PipeWriter.Create(stream), value, options);
}