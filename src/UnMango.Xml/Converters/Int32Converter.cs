using System;
using JetBrains.Annotations;

namespace UnMango.Xml.Converters;

/// <summary>
/// Converts an integer value to or from XML.
/// </summary>
[PublicAPI]
public class Int32Converter : XmlConverter<int>
{
    /// <inheritdoc/>
    public override int Read(ref XmlReader reader, Type typeToConvert, XmlSerializerOptions options)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc/>
    public override void Write(ref XmlWriter writer, int value, XmlSerializerOptions options)
    {
        throw new NotImplementedException();
    }
}