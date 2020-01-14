using System;
using System.Collections.Generic;
using System.Text;

namespace Unmango.Xml
{
    public struct XmlWriter
    {
        private readonly byte[] _bytes;
        private int _offset;

        public XmlWriter(byte[] bytes)
            : this(bytes, 0) { }

        public XmlWriter(byte[] bytes, int offset)
        {
            _bytes = bytes;
            _offset = offset;
        }
    }
}
