using System;
using System.Buffers;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace UnMango.Xml;

/// <summary>
/// Facilitates writing Xml to a buffer.
/// </summary>
[PublicAPI]
public readonly struct XmlWriter
{
    private readonly IBufferWriter<byte> _output;

    /// <summary>
    /// Initializes a new instance of a <see cref="XmlWriter"/> with a specified <paramref name="bufferWriter"/>.
    /// </summary>
    /// <param name="bufferWriter">
    /// An instance of <see cref="IBufferWriter{Byte}" /> used as a destination for writing XML text into.
    /// </param>
    /// <exception cref="ArgumentNullException">
    /// Thrown when the instance of <see cref="IBufferWriter{Byte}" /> that is passed in is null.
    /// </exception>
    public XmlWriter(IBufferWriter<byte> bufferWriter)
    {
        _output = bufferWriter ?? throw new ArgumentNullException(nameof(bufferWriter));
    }

    /// <summary>
    /// Writes a boolean value.
    /// </summary>
    /// <param name="value">The value to write.</param>
    public void Write(bool value)
    {
        if (value)
            WriteTrue();
        else
            WriteFalse();
    }

    /// <summary>
    /// Writes a character value.
    /// </summary>
    /// <param name="value">The value to write.</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void Write(char value)
    {
        const int size = 1;
        var span = _output.GetSpan(size);
        span[0] = (byte)value;
        _output.Advance(size);
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
    /// Writes "false" to the output.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void WriteFalse()
    {
        const int size = 5;
        var span = _output.GetSpan(size);
        span[0] = (byte)'f';
        span[1] = (byte)'a';
        span[2] = (byte)'l';
        span[3] = (byte)'s';
        span[4] = (byte)'e';
        _output.Advance(size); // TODO: Flush?
    }

    /// <summary>
    /// Writes a byte directly to the output.
    /// </summary>
    /// <param name="byte"></param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void WriteRaw(byte @byte)
    {
        const int size = 1;
        _output.GetSpan(size)[0] = @byte;
        _output.Advance(size);
    }

    /// <summary>
    /// Writes bytes directly to the output.
    /// </summary>
    /// <param name="bytes"></param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void WriteRaw(byte[] bytes)
    {
        _output.Write(bytes);
    }

    /// <summary>
    /// Writes "true" to the output.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public void WriteTrue()
    {
        const int size = 4;
        var span = _output.GetSpan(size);
        span[0] = (byte)'t';
        span[1] = (byte)'r';
        span[2] = (byte)'u';
        span[3] = (byte)'e';
        _output.Advance(size); // TODO: Flush?
    }

    /// <summary>
    /// Not Supported.
    /// </summary>
    /// <param name="obj">NA</param>
    /// <returns>NA</returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override bool Equals(object? obj) => throw new NotSupportedException();

    /// <summary>
    /// Not Supported.
    /// </summary>
    /// <returns>NA</returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override int GetHashCode() => throw new NotSupportedException();

    /// <summary>
    /// Not Supported.
    /// </summary>
    /// <returns>NA</returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public override string ToString() => throw new NotSupportedException();

    /// <summary>
    /// Not Supported.
    /// </summary>
    /// <param name="left">NA</param>
    /// <param name="right">NA</param>
    /// <returns>NA</returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static bool operator ==(XmlWriter left, XmlWriter right) => throw new NotSupportedException();

    /// <summary>
    /// Not Supported.
    /// </summary>
    /// <param name="left">NA</param>
    /// <param name="right">NA</param>
    /// <returns>NA</returns>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static bool operator !=(XmlWriter left, XmlWriter right) => throw new NotSupportedException();
}