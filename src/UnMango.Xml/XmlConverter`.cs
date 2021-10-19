using System;
using JetBrains.Annotations;

namespace UnMango.Xml;

/// <summary>
/// Converts an object or value to or from XML.
/// </summary>
/// <typeparam name="T">The <see cref="Type"/> to convert.</typeparam>
[PublicAPI]
public abstract class XmlConverter<T> : XmlConverter
{
    /// <summary>
    /// Initializes a new instance of a <see cref="XmlConverter{T}"/>.
    /// </summary>
    protected internal XmlConverter() { }

    internal override Type? TypeToConvert => typeof(T);

    /// <summary>
    /// Determines whether the type can be converted.
    /// </summary>
    /// <remarks>
    /// The default implementation is to return True when <paramref name="typeToConvert"/> equals typeof(T).
    /// </remarks>
    /// <param name="typeToConvert">The type to check.</param>
    /// <returns>True if the type can be converted, False otherwise.</returns>
    public override bool CanConvert(Type typeToConvert)
    {
        return typeToConvert == typeof(T);
    }

    /// <summary>
    /// Read and convert the XML to <typeparamref name="T"/>.
    /// </summary>
    /// <param name="reader">The <see cref="XmlReader"/> to read from.</param>
    /// <param name="typeToConvert">The <see cref="Type"/> being converted.</param>
    /// <param name="options">The <see cref="XmlSerializerOptions"/> being used.</param>
    /// <returns>The value that was converted.</returns>
    public abstract T Read(ref XmlReader reader, Type typeToConvert, XmlSerializerOptions options);

    /// <summary>
    /// Write <paramref name="value"/> as XML.
    /// </summary>
    /// <param name="writer">The <see cref="XmlWriter"/> to write to.</param>
    /// <param name="value">The value to convert.</param>
    /// <param name="options">The <see cref="XmlSerializerOptions"/> being used.</param>
    public abstract void Write(ref XmlWriter writer, T value, XmlSerializerOptions options);
}