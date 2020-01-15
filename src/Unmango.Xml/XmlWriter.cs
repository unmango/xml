using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

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
        
        public void Write(bool value)
        {
            throw new NotImplementedException();
        }

        public void Write(char value)
        {
            throw new NotImplementedException();
        }

        public void Write(char[] buffer)
        {
            throw new NotImplementedException();
        }

        public void Write(char[] buffer, int index, int count)
        {
            throw new NotImplementedException();
        }

        public void Write(decimal value)
        {
            throw new NotImplementedException();
        }

        public void Write(double value)
        {
            throw new NotImplementedException();
        }

        public void Write(int value)
        {
            throw new NotImplementedException();
        }

        public void Write(long value)
        {
            throw new NotImplementedException();
        }

        public void Write(object value)
        {
            throw new NotImplementedException();
        }

        public void Write(float value)
        {
            throw new NotImplementedException();
        }

        public void Write(string value)
        {
            throw new NotImplementedException();
        }

        public void Write(uint value)
        {
            throw new NotImplementedException();
        }

        public void Write(ulong value)
        {
            throw new NotImplementedException();
        }

        public ValueTask WriteAsync(char value)
        {
            throw new NotImplementedException();
        }

        public ValueTask WriteAsync(char[] buffer, int index, int count)
        {
            throw new NotImplementedException();
        }

        public ValueTask WriteAsync(string value)
        {
            throw new NotImplementedException();
        }
    }
}
