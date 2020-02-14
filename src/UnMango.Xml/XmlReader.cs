using System;

namespace UnMango.Xml
{
    /// <summary>
    /// Reads XML.
    /// </summary>
    public ref struct XmlReader
    {
        private const int DEFAULT_OFFSET = 0;

        private readonly ReadOnlySpan<byte> _buffer;
        private int _offset;

        /// <summary>
        /// Initializes a new instance of a <see cref="XmlReader"/> with the
        /// specified <paramref name="buffer"/>.
        /// </summary>
        /// <param name="buffer"></param>
        public XmlReader(ReadOnlySpan<byte> buffer)
            : this(buffer, DEFAULT_OFFSET) { }

        /// <summary>
        /// Initializes a new instance of a <see cref="XmlReader"/> with the
        /// specified <paramref name="buffer"/> starting at <paramref name="offset"/>.
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="offset"></param>
        public XmlReader(ReadOnlySpan<byte> buffer, int offset)
        {
            _buffer = buffer;
            _offset = offset;
        }
    }
}
