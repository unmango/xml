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
    internal static readonly XmlSerializerOptions DefaultOptions = new();

    internal static readonly Dictionary<Type, XmlConverter> DefaultConverterCache = new() {
        [typeof(int)] = new Int32Converter()
    };

    /// <summary>
    /// Initializes a new instance of a <see cref="XmlSerializerOptions"/>.
    /// </summary>
    public XmlSerializerOptions() { }

    /// <summary>
    /// Gets the cache of converters created so far.
    /// </summary>
    public IReadOnlyDictionary<Type, XmlConverter> ConverterCache { get; } = DefaultConverterCache;
}
