using System;
using System.Runtime.InteropServices;
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
        return MemoryMarshal.Read<int>(charData);
    }

    /// <inheritdoc/>
    public override void Write(ref XmlWriter writer, int value, XmlSerializerOptions options)
    {
        writer.Write(value);
    }
}
