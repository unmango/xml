using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace UnMango.Xml
{
    /// <summary>
    /// Reads XML.
    /// </summary>
    public ref struct XmlReader
    {
        private const int DEFAULT_OFFSET = 0;

        private readonly ReadOnlySpan<byte> _xml;
        private int _offset;

        /// <summary>
        /// Initializes a new instance of a <see cref="XmlReader"/> with the
        /// specified <paramref name="xml"/> starting at <paramref name="offset"/>.
        /// </summary>
        /// <param name="xml"></param>
        /// <param name="offset"></param>
        public XmlReader(ReadOnlySpan<byte> xml, int offset = DEFAULT_OFFSET)
        {
            _xml = xml;
            _offset = offset;
        }

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

        public ReadOnlySpan<byte> ReadEntityValue()
        {
            if (!TryReadLiteralDelimeter(out var literalDelimeter))
            {
                throw new XmlParsingException("Invalid start literal");
            }

            var start = ++_offset;

            for (; _offset < _xml.Length; _offset++)
            {
                if (_xml[_offset] == literalDelimeter) break;

                if (_xml[_offset] == '%')
                    throw new XmlParsingException("Invalid entity value character '%'");

                if (_xml[_offset] == '&')
                    throw new XmlParsingException("Invalid entity value character '&'");
            }

            return _xml.Slice(start, _offset - 1);
        }

        public ReadOnlySpan<byte> ReadAttributeValue()
        {
            if (!TryReadLiteralDelimeter(out var literalDelimeter))
            {
                throw new XmlParsingException("Invalid start literal");
            }

            var start = ++_offset;

            for (; _offset < _xml.Length; _offset++)
            {
                if (_xml[_offset] == literalDelimeter) break;

                if (_xml[_offset] == '<')
                    throw new XmlParsingException("Invalid attribute value character '<'");

                if (_xml[_offset] == '&')
                    throw new XmlParsingException("Invalid attribute value character '&'");
            }

            return _xml.Slice(start, _offset - 1);
        }

        public ReadOnlySpan<byte> ReadSystemLiteral()
        {
            if (!TryReadLiteralDelimeter(out var literalDelimeter))
            {
                throw new XmlParsingException("Invalid start literal");
            }

            var start = ++_offset;

            for (; _offset < _xml.Length; _offset++)
            {
                if (_xml[_offset] == literalDelimeter) break;
            }

            return _xml.Slice(start, _offset - 1);
        }

        public ReadOnlySpan<byte> ReadPubidLiteral()
        {
            if (!TryReadLiteralDelimeter(out var literalDelimeter))
            {
                throw new XmlParsingException("Invalid start literal");
            }

            var start = _offset++;

            for (; _offset < _xml.Length; _offset++)
            {
                if (_xml[_offset] == literalDelimeter) break;

                if (!XmlConstants.IsPubidCharacter(_xml[_offset]))
                    throw new XmlParsingException($"Invalid pubid literal character '{_xml[_offset]}'");
            }

            return _xml.Slice(start, _offset - 1);
        }

        // TODO: Other conditions
        // TODO: Loop exit condition
        public ReadOnlySpan<byte> ReadCharacterData()
        {
            var start = _offset++;

            for (; _offset < _xml.Length; _offset++)
            {
                if (_xml[_offset] == '<')
                    throw new XmlParsingException("Invalid character data character '<'");

                // TODO: character reference
                if (_xml[_offset] == '&')
                    throw new XmlParsingException("Invalid character data character '&'");
            }

            return _xml.Slice(start, _offset - 1);
        }

        public ReadOnlySpan<byte> ReadComment()
        {
            var start = ++_offset;

            for (; _offset < _xml.Length; _offset++)
            {
                // TODO
            }

            return _xml.Slice(start, _offset - 1);
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
        private bool TryReadLiteralDelimeter(out byte literal)
        {
            literal = _xml[_offset];

            return !XmlConstants.IsLiteralDelimeter(literal);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => throw new NotSupportedException();

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => throw new NotSupportedException();

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ToString() => throw new NotSupportedException();

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static bool operator ==(XmlReader left, XmlReader right) => throw new NotSupportedException();

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static bool operator !=(XmlReader left, XmlReader right) => throw new NotSupportedException();
    }
}
