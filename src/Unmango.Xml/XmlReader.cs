using System;
using System.Collections.Generic;
using System.Text;

namespace Unmango.Xml
{
    public struct XmlReader
    {
        private readonly byte[] _buffer;
        private int _offset;

        public XmlReader(byte[] buffer)
            : this(buffer, 0) { }

        public XmlReader(byte[] buffer, int offset)
        {
            _buffer = buffer;
            _offset = offset;
        }
    }
}
