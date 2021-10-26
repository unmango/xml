using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnMango.Xml.Converters;

namespace UnMango.Xml;

/// <summary>
/// Provides options to be used with <see cref="XmlSerializer"/>.
/// </summary>
[PublicAPI]
public sealed record XmlSerializerOptions
{
    internal static readonly Dictionary<Type, XmlConverter> DefaultConverterCache = new() {
        [typeof(int)] = Int32Converter.Instance,
        [typeof(object)] = ObjectConverter.Instance,
    };
    
    // TODO: This is order dependent due to static initialization. Kinda weird, should probably refactor
    internal static readonly XmlSerializerOptions DefaultOptions = new();

    /// <summary>
    /// Initializes a new instance of a <see cref="XmlSerializerOptions"/>.
    /// </summary>
    public XmlSerializerOptions() { }

    /// <summary>
    /// Gets the cache of converters created so far.
    /// </summary>
    public IReadOnlyDictionary<Type, XmlConverter> ConverterCache { get; init; } = DefaultConverterCache;
}
