using System;
using JetBrains.Annotations;

namespace UnMango.Xml.Converters;

/// <summary>
/// Converts an integer value to or from XML.
/// </summary>
[PublicAPI]
public class Uint64Converter : XmlConverter<ulong>
{
    internal static Uint64Converter Instance = new();

    public override ulong Read(ref XmlReader reader, Type typeToConvert, XmlSerializerOptions options)
    {
        var charData = reader.ReadCharacterData();

        ulong value = 0;

        // Won't allocate because the enumerator is a ref struct
        // https://github.com/dotnet/runtime/blob/d2ca8e1422c95aabc797249cef296e41ca2fd14e/src/libraries/System.Private.CoreLib/src/System/ReadOnlySpan.cs#L204
        foreach (var t in charData)
        {
            value = value * 10 + (ulong)(t - '0');
        }

        return value;
    }

    public override void Write(ref XmlWriter writer, ulong value, XmlSerializerOptions options)
    {
        writer.Write(value);
    }
}
