using JetBrains.Annotations;

namespace UnMango.Xml;

/// <summary>
/// Configuration for an <see cref="XmlReader"/>.
/// </summary>
[PublicAPI]
public readonly struct XmlReaderOptions
{
    internal static XmlReaderOptions From(XmlSerializerOptions? options) => new();
}