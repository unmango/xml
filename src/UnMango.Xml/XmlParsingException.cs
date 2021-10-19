using System;
using JetBrains.Annotations;

namespace UnMango.Xml;

/// <summary>
/// Represents an error that occurred parsing XML.
/// </summary>
[PublicAPI]
public class XmlParsingException : Exception
{
    /// <summary>
    /// Initializes a new instance of a <see cref="XmlParsingException"/>.
    /// </summary>
    public XmlParsingException() { }

    /// <summary>
    /// Initializes a new instance of a <see cref="XmlParsingException"/>
    /// with the specified message.
    /// </summary>
    /// <param name="message">A message describing the exception.</param>
    public XmlParsingException(string message)
        : base(message) { }

    /// <summary>
    /// Initializes a new instance of a <see cref="XmlParsingException"/>
    /// with the specified message and inner exception.
    /// </summary>
    /// <param name="message">A message describing the exception.</param>
    /// <param name="innerException">The exception that caused this exception.</param>
    public XmlParsingException(string message, Exception innerException)
        : base(message, innerException) { }
}