using System;
using System.Text;
using JetBrains.Annotations;

namespace UnMango.Xml.Converters;

/// <summary>
/// Converts an integer value to or from XML.
/// </summary>
[PublicAPI]
public class Int32Converter : XmlConverter<int>
{
    internal static Int32Converter Instance = new();

    /// <inheritdoc/>
    public override int Read(ref XmlReader reader, Type typeToConvert, XmlSerializerOptions options)
    {
        var charData = reader.ReadCharacterData();

#if NETSTANDARD2_0
        var data = Encoding.UTF8.GetString(charData.ToArray());
#else
        var data = Encoding.UTF8.GetString(charData);
#endif

        return int.Parse(data);
    }

    /// <inheritdoc/>
    public override void Write(ref XmlWriter writer, int value, XmlSerializerOptions options)
    {
        writer.Write(value);
    }
}
