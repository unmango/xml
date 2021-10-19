using System;
using JetBrains.Annotations;

namespace UnMango.Xml;

/// <summary>
/// Converts an object or value to or from XML.
/// </summary>
[PublicAPI]
public abstract class XmlConverter
{
    internal XmlConverter() { }

    /// <summary>
    /// Determines whether the type can be converted.
    /// </summary>
    /// <param name="typeToConvert">The type to check.</param>
    /// <returns>True if the type can be converted, false otherwise.</returns>
    public abstract bool CanConvert(Type typeToConvert);

    internal virtual Type? TypeToConvert => null;
}