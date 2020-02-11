using System;
using System.Collections.Generic;
using System.Text;

namespace Unmango.Xml
{
    public ref struct XmlReader
    {
        private readonly ReadOnlySpan<byte> _buffer;
        private int _offset;

        public XmlReader(ReadOnlySpan<byte> buffer)
            : this(buffer, 0) { }

        public XmlReader(ReadOnlySpan<byte> buffer, int offset)
        {
            _buffer = buffer;
            _offset = offset;
        }
    }
}
