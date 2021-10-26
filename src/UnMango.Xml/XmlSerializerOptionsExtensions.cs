using System;
using JetBrains.Annotations;

namespace UnMango.Xml;

/// <summary>
/// Extensions for <see cref="XmlSerializerOptions"/>.
/// </summary>
[PublicAPI]
public static class XmlSerializerOptionsExtensions
{
    internal static XmlConverter<T> ConverterFor<T>(this XmlSerializerOptions options)
    {
        return (XmlConverter<T>)options.ConverterFor(typeof(T));
    }

    internal static XmlConverter ConverterFor(this XmlSerializerOptions options, Type converterType)
    {
        if (!options.ConverterCache.TryGetValue(converterType, out var converter))
            throw new NotSupportedException($"No converter registered for {converterType}");

        return converter;
    }

    /// <summary>
    /// Adds <paramref name="converter"/> to <paramref name="options"/> converter cache.
    /// </summary>
    /// <param name="options">The source options.</param>
    /// <param name="type">The type of the converter.</param>
    /// <param name="converter">The converter to add.</param>
    /// <returns>A new <see cref="XmlSerializerOptions"/> with <paramref name="converter"/> in the cache.</returns>
    public static XmlSerializerOptions WithConverter(this XmlSerializerOptions options, Type type, XmlConverter converter)
    {
        return options with {
            ConverterCache = options.ConverterCache.With(type, converter)
        };
    }
}
