using System;
using System.Collections.Generic;
using System.Text;

namespace Unmango.Xml
{
    public ref struct XmlReader
    {
        private const int DEFAULT_OFFSET = 0;

        private readonly ReadOnlySpan<byte> _buffer;
        private int _offset;

        public XmlReader(ReadOnlySpan<byte> buffer)
            : this(buffer, DEFAULT_OFFSET) { }

        public XmlReader(ReadOnlySpan<byte> buffer, int offset)
        {
            _buffer = buffer;
            _offset = offset;
        }

        public static XmlReader Create(ReadOnlySpan<byte> buffer)
        {
            return new XmlReader(buffer);
        }
    }
}
