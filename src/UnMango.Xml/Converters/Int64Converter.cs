using System;
using JetBrains.Annotations;

namespace UnMango.Xml.Converters;

/// <summary>
/// Converts an integer value to or from XML.
/// </summary>
[PublicAPI]
public class Int64Converter : XmlConverter<long>
{
    internal static Int64Converter Instance = new();

    /// <inheritdoc/>
    public override long Read(ref XmlReader reader, Type typeToConvert, XmlSerializerOptions options)
    {
        var charData = reader.ReadCharacterData();

        int sign = 1, i = 0;
        if (charData[0] == '-')
        {
            sign = -1;
            i = 1;
        }

        long value = 0;
        for (; i < charData.Length; i++)
        {
            value = value * 10 + (charData[i] - '0');
        }

        return value * sign;
    }

    /// <inheritdoc/>
    public override void Write(ref XmlWriter writer, long value, XmlSerializerOptions options)
    {
        writer.Write(value);
    }
}
