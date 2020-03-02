using System;
using System.ComponentModel;
using System.Threading.Tasks;

namespace UnMango.Xml
{
    /// <summary>
    /// Facilitates writing Xml to a buffer.
    /// </summary>
    public ref struct XmlWriter
    {
        private ReadOnlySpan<byte> _buffer;
        private int _offset;

        /// <summary>
        /// Initializes a new instance of a <see cref="XmlWriter"/>.
        /// </summary>
        /// <param name="initialBuffer"></param>
        public XmlWriter(ReadOnlySpan<byte> initialBuffer)
        {
            _buffer = initialBuffer;
            _offset = 0;
        }

        /// <summary>
        /// Gets the current offset.
        /// </summary>
        public int CurrentOffset => _offset;
        
        /// <summary>
        /// Writes a boolean value.
        /// </summary>
        /// <param name="value">The value to write.</param>
        public void Write(bool value)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Writes a character value.
        /// </summary>
        /// <param name="value">The value to write.</param>
        public void Write(char value)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Writes a character array.
        /// </summary>
        /// <param name="buffer">The buffer of characters to write.</param>
        public void Write(char[] buffer)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Writes a number of characters specified by <paramref name="count"/>
        /// starting at <paramref name="index"/> from <paramref name="buffer"/>.
        /// </summary>
        /// <param name="buffer">The buffer of characters to write.</param>
        /// <param name="index">The index to start at in the buffer.</param>
        /// <param name="count">The number of characters to write.</param>
        public void Write(char[] buffer, int index, int count)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Writes a decimal value.
        /// </summary>
        /// <param name="value">The value to write.</param>
        public void Write(decimal value)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Writes a double value.
        /// </summary>
        /// <param name="value">The value to write.</param>
        public void Write(double value)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Writes an integer value.
        /// </summary>
        /// <param name="value">The value to write.</param>
        public void Write(int value)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Writes a long value.
        /// </summary>
        /// <param name="value">The value to write.</param>
        public void Write(long value)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Writes an object value.
        /// </summary>
        /// <param name="value">The value to write.</param>
        public void Write(object value)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Writes a float value.
        /// </summary>
        /// <param name="value">The value to write.</param>
        public void Write(float value)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Writes a string value.
        /// </summary>
        /// <param name="value">The value to write.</param>
        public void Write(string value)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Writes a uint value.
        /// </summary>
        /// <param name="value">The value to write.</param>
        public void Write(uint value)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Writes a ulong value.
        /// </summary>
        /// <param name="value">The value to write.</param>
        public void Write(ulong value)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Writes a character value asynchronously.
        /// </summary>
        /// <param name="value">The value to write.</param>
        /// <returns>A task representing the operation.</returns>
        public ValueTask WriteAsync(char value)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Writes a number of characters specified by <paramref name="count"/>
        /// starting at <paramref name="index"/> from <paramref name="buffer"/>
        /// asynchronously.
        /// </summary>
        /// <param name="buffer">The buffer of characters to write.</param>
        /// <param name="index">The index to start at in the buffer.</param>
        /// <param name="count">The number of characters to write.</param>
        /// <returns>A task representing the operation.</returns>
        public ValueTask WriteAsync(char[] buffer, int index, int count)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Writes a string value asynchronously.
        /// </summary>
        /// <param name="value">The value to write.</param>
        /// <returns>A task representing the operation.</returns>
        public ValueTask WriteAsync(string value)
        {
            throw new NotImplementedException();
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => throw new NotSupportedException();

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => throw new NotSupportedException();

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ToString() => throw new NotSupportedException();
    }
}
