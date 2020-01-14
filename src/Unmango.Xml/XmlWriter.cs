using System;
using System.Collections.Generic;
using System.Text;

namespace Unmango.Xml
{
    public struct XmlWriter
    {
        private byte[] _buffer;
        private int _offset;

        public XmlWriter(byte[] initialBuffer)
        {
            _buffer = initialBuffer;
            _offset = 0;
        }

        public int CurrentOffset => _offset;
    }
}
