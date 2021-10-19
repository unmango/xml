using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace UnMango.Xml;

/// <summary>
/// Reads XML.
/// </summary>
[PublicAPI]
public ref struct XmlReader
{
    private const int DefaultOffset = 0;

    private readonly ReadOnlySpan<byte> _xml;
    private readonly XmlReaderOptions _options;
    private int _offset;

    /// <summary>
    /// Initializes a new instance of a <see cref="XmlReader"/> with the
    /// specified <paramref name="xml"/> starting at <paramref name="offset"/>
    /// with the specified <paramref name="options"/>.
    /// </summary>
    /// <param name="xml">XML source to read from.</param>
    /// <param name="offset">Starting offset in <paramref name="xml"/>.</param>
    /// <param name="options">XML reader options.</param>
    public XmlReader(ReadOnlySpan<byte> xml, int offset = DefaultOffset, XmlReaderOptions options = default)
    {
        _xml = xml;
        _options = options;
        _offset = offset;
    }

    /// <summary>
    /// Initializes a new instance of a <see cref="XmlReader"/> with the
    /// specified <paramref name="xml"/> starting at the default offset
    /// with the specified <paramref name="options"/>.
    /// </summary>
    /// <param name="xml">XML source to read from.</param>
    /// <param name="options">XML reader options.</param>
    public XmlReader(ReadOnlySpan<byte> xml, XmlReaderOptions options)
        : this(xml, DefaultOffset, options) { }

    /// <summary>
    /// Reads the current offset as an XML name.
    /// </summary>
    /// <returns>The name at the current offset.</returns>
    /// <remarks>
    /// Definition: https://www.w3.org/TR/2008/REC-xml-20081126/#NT-Name
    /// </remarks>
    public ReadOnlySpan<byte> ReadName()
    {
        if (!XmlConstants.IsNameStartCharacter(_xml[_offset]))
        {
            throw new XmlParsingException("Invalid name start character");
        }

        // A Name is an Nmtoken with a restricted set of initial characters
        return ReadNameToken(validate: false);
    }

    /// <summary>
    /// Reads the current offset as an XML Nmtoken
    /// </summary>
    /// <returns>The name token at the current offset.</returns>
    /// <remarks>
    /// Definition: https://www.w3.org/TR/2008/REC-xml-20081126/#NT-Nmtoken
    /// </remarks>
    public ReadOnlySpan<byte> ReadNameToken()
    {
        return ReadNameToken(validate: true);
    }

    /// <summary>
    /// Reads the current offset as an XML EntityValue.
    /// </summary>
    /// <returns>The entity value at the current offset.</returns>
    /// <remarks>
    /// Definition: https://www.w3.org/TR/2008/REC-xml-20081126/#NT-EntityValue
    /// </remarks>
    public ReadOnlySpan<byte> ReadEntityValue()
    {
        if (!TryReadLiteralDelimiter(out var literal))
        {
            throw new XmlParsingException("Invalid start literal");
        }

        var start = ++_offset;

        for (; _offset < _xml.Length; _offset++)
        {
            if (_xml[_offset] == literal) break;

            if (_xml[_offset] == '%')
                throw new XmlParsingException("Invalid entity value character '%'");

            if (_xml[_offset] == '&')
                throw new XmlParsingException("Invalid entity value character '&'");
        }

        // TODO: Scan for markup? Based on the comment about SystemLiteral
        // TODO: Second case will never be hit
        if (_offset == _xml.Length || _xml[_offset] != literal)
        {
            throw new XmlParsingException($"Invalid entity value. Expected '{literal}'");
        }

        return _xml.Slice(start, _offset - 1);
    }

    /// <summary>
    /// Reads the current offset as an XML AttValue.
    /// </summary>
    /// <returns>The attribute value at the current offset.</returns>
    /// <remarks>
    /// Definition: https://www.w3.org/TR/2008/REC-xml-20081126/#NT-AttValue
    /// </remarks>
    public ReadOnlySpan<byte> ReadAttributeValue()
    {
        if (!TryReadLiteralDelimiter(out var literal))
        {
            throw new XmlParsingException("Invalid start literal");
        }

        var start = ++_offset;

        for (; _offset < _xml.Length; _offset++)
        {
            if (_xml[_offset] == literal) break;

            if (_xml[_offset] == '<')
                throw new XmlParsingException("Invalid attribute value character '<'");

            if (_xml[_offset] == '&')
                throw new XmlParsingException("Invalid attribute value character '&'");
        }

        // TODO: Scan for markup? Based on the comment about SystemLiteral
        // TODO: Second case will never be hit
        if (_offset == _xml.Length || _xml[_offset] != literal)
        {
            throw new XmlParsingException($"Invalid attribute value. Expected '{literal}'");
        }

        return _xml.Slice(start, _offset - 1);
    }

    /// <summary>
    /// Reads the current offset as an XML SystemLiteral.
    /// </summary>
    /// <returns>The system literal at the current offset.</returns>
    /// <remarks>
    /// Definition: https://www.w3.org/TR/2008/REC-xml-20081126/#NT-SystemLiteral
    /// A SystemLiteral can be parsed without scanning for markup.
    /// </remarks>
    public ReadOnlySpan<byte> ReadSystemLiteral()
    {
        if (!TryReadLiteralDelimiter(out var literal))
        {
            throw new XmlParsingException("Invalid start literal");
        }

        var start = ++_offset;

        for (; _offset < _xml.Length; _offset++)
        {
            if (_xml[_offset] == literal) break;
        }

        return _xml.Slice(start, _offset - 1);
    }

    /// <summary>
    /// Reads the current offset as an XML PubidLiteral.
    /// </summary>
    /// <returns>The pubid literal at the current offset.</returns>
    /// <remarks>
    /// Definition: https://www.w3.org/TR/2008/REC-xml-20081126/#NT-PubidLiteral
    /// </remarks>
    public ReadOnlySpan<byte> ReadPubidLiteral()
    {
        if (!TryReadLiteralDelimiter(out var literal, out var alternate))
        {
            throw new XmlParsingException("Invalid start literal");
        }

        var start = ++_offset;

        for (; _offset < _xml.Length; _offset++)
        {
            if (_xml[_offset] == literal) break;

            if (_xml[_offset] == alternate)
                throw new XmlParsingException($"Invalid pubid literal character '{alternate}'");

            if (!XmlConstants.IsPubidCharacter(_xml[_offset]))
                throw new XmlParsingException($"Invalid pubid literal character '{_xml[_offset]}'");
        }

        // TODO: Scan for markup? Based on the comment about SystemLiteral
        // TODO: Second case will never be hit
        if (_offset == _xml.Length || _xml[_offset] != literal)
        {
            throw new XmlParsingException($"Invalid pubid literal. Expected '{literal}'");
        }

        return _xml.Slice(start, _offset - 1);
    }

    /// <summary>
    /// Reads the current offset as XML CharData.
    /// </summary>
    /// <returns>The character data at the current offset.</returns>
    /// <remarks>
    /// Definition: https://www.w3.org/TR/2008/REC-xml-20081126/#NT-CharData
    /// </remarks>
    public ReadOnlySpan<byte> ReadCharacterData()
    {
        if (_xml[_offset] == '<' || _xml[_offset] == '&')
        {
            return ReadOnlySpan<byte>.Empty;
        }

        var start = _offset;

        for (; _offset < _xml.Length; _offset++)
        {
            // TODO: These can appear as markup delimiters, or within a comment, processing instruction, or CDATA section
            if (_xml[_offset] == '<') break;
            if (_xml[_offset] == '&') break;

            if (_xml[_offset] == ']' &&
                _offset + 1 < _xml.Length && _xml[_offset + 1] == ']' &&
                _offset + 2 < _xml.Length && _xml[_offset + 2] == '>')
            {
                break;
            }
        }

        return _xml.Slice(start, _offset);
    }

    /// <summary>
    /// Reads the current offset as an XML Comment.
    /// </summary>
    /// <returns>The comment at the current offset.</returns>
    /// <remarks>
    /// Definition: https://www.w3.org/TR/2008/REC-xml-20081126/#NT-Comment
    /// </remarks>
    public ReadOnlySpan<byte> ReadComment()
    {
        var start = ++_offset;

        for (; _offset < _xml.Length; _offset++)
        {
            // TODO: Everything
        }

        return _xml.Slice(start, _offset - 1);
    }

    /// <summary>
    /// Reads the current offset as an XML close element character.
    /// </summary>
    /// <exception cref="XmlParsingException">
    /// Thrown when the current offset is not an XML close element character.
    /// </exception>
    public void ReadCloseElement()
    {
        if (_xml[_offset] != XmlConstants.CloseElement)
        {
            throw new XmlParsingException("Reader was not positioned at an element close character");
        }

        ++_offset;
    }

    /// <summary>
    /// Reads the current offset as an XML open element character.
    /// </summary>
    /// <exception cref="XmlParsingException">
    /// Thrown when the current offset is not an XML open element character.
    /// </exception>
    public void ReadOpenElement()
    {
        if (_xml[_offset] != XmlConstants.OpenElement)
        {
            throw new XmlParsingException("Reader was not positioned at an element start character");
        }

        ++_offset;
    }

    /// <summary>
    /// Reads the current offset as XML White Space.
    /// </summary>
    /// <remarks>
    /// Definition: https://www.w3.org/TR/2008/REC-xml-20081126/#NT-S
    /// </remarks>
    public void ReadWhiteSpace()
    {
        if (!XmlConstants.IsWhiteSpace(_xml[_offset]))
        {
            throw new XmlParsingException("Reader was not positioned at whitespace");
        }

        while (++_offset < _xml.Length && XmlConstants.IsWhiteSpace(_xml[_offset])) { }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private ReadOnlySpan<byte> ReadNameToken(bool validate)
    {
        if (validate && !XmlConstants.IsNameCharacter(_xml[_offset]))
        {
            throw new XmlParsingException("Invalid name token character");
        }

        var start = _offset++;

        for (; _offset < _xml.Length; _offset++)
        {
            if (!XmlConstants.IsNameCharacter(_xml[_offset])) break;
        }

        return _xml.Slice(start, _offset);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private bool TryReadLiteralDelimiter(out byte literal)
    {
        literal = _xml[_offset];

        return XmlConstants.IsLiteralDelimiter(literal);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private bool TryReadLiteralDelimiter(out byte literal, out byte alternate)
    {
        var result = TryReadLiteralDelimiter(out literal);

        alternate = XmlConstants.SwapLiteral(literal);

        return result;
    }

    /// <summary>
    /// Not Supported.
    /// </summary>
    /// <param name="obj">NA</param>
    /// <returns>NA</returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override bool Equals(object? obj) => throw new NotSupportedException();

    /// <summary>
    /// Not Supported.
    /// </summary>
    /// <returns>NA</returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override int GetHashCode() => throw new NotSupportedException();

    /// <summary>
    /// Not Supported.
    /// </summary>
    /// <returns>NA</returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override string ToString() => throw new NotSupportedException();

    /// <summary>
    /// Not Supported.
    /// </summary>
    /// <param name="left">NA</param>
    /// <param name="right">NA</param>
    /// <returns>NA</returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static bool operator ==(XmlReader left, XmlReader right) => throw new NotSupportedException();

    /// <summary>
    /// Not Supported.
    /// </summary>
    /// <param name="left">NA</param>
    /// <param name="right">NA</param>
    /// <returns>NA</returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static bool operator !=(XmlReader left, XmlReader right) => throw new NotSupportedException();
}
