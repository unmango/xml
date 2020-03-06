using System;
using System.ComponentModel;
using System.Text;

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

        public ReadOnlySpan<byte> ReadBeginElement()
        {
            if (_xml[_offset] != '<')
            {
                // TODO: Message
                throw new XmlParsingException("Invalid begin element");
            }

            var start = ++_offset;
            var done = false;

            for (; _offset < _xml.Length; _offset++)
            {
                switch (_xml[_offset])
                {
                    case (byte)'>':
                    case (byte)' ':
                    case (byte)'/':
                        done = true;
                        break;
                }

                if (done) break;
            }

            // TODO: Probably better validity check
            if (_offset == _xml.Length || !done)
            {
                // TODO: Message
                throw new XmlParsingException("Reached end without closing element");
            }

            return _xml.Slice(start, _offset - 1);
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
