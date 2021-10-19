using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace UnMango.Xml;

internal class XmlTextWriter : TextWriter
{
    public override Encoding Encoding => Encoding.UTF8;

    public override void Close()
    {
        throw new NotImplementedException();
    }

    //public override bool Equals(object obj) => _writer.Equals(obj);
    public override bool Equals(object? obj) => throw new NotImplementedException();

    public override void Flush()
    {
        throw new NotImplementedException();
    }

    public override Task FlushAsync()
    {
        throw new NotImplementedException();
    }

    //public override int GetHashCode() => _writer.GetHashCode();
    public override int GetHashCode() => throw new NotImplementedException();

    //public override string ToString() => _writer.ToString();
    public override string ToString() => throw new NotImplementedException();

    public override void Write(bool value)
    {
        throw new NotImplementedException();
    }

    public override void Write(char value)
    {
        throw new NotImplementedException();
    }

    public override void Write(char[]? buffer)
    {
        throw new NotImplementedException();
    }

    public override void Write(char[] buffer, int index, int count)
    {
        throw new NotImplementedException();
    }

    public override void Write(decimal value)
    {
        throw new NotImplementedException();
    }

    public override void Write(double value)
    {
        throw new NotImplementedException();
    }

    public override void Write(int value)
    {
        throw new NotImplementedException();
    }

    public override void Write(long value)
    {
        throw new NotImplementedException();
    }

    public override void Write(object? value)
    {
        throw new NotImplementedException();
    }

    public override void Write(float value)
    {
        throw new NotImplementedException();
    }

    public override void Write(string? value)
    {
        throw new NotImplementedException();
    }

    public override void Write(string format, object? arg0)
    {
        throw new NotImplementedException();
    }

    public override void Write(string format, object? arg0, object? arg1)
    {
        throw new NotImplementedException();
    }

    public override void Write(string format, object? arg0, object? arg1, object? arg2)
    {
        throw new NotImplementedException();
    }

    public override void Write(string format, params object?[] arg)
    {
        throw new NotImplementedException();
    }

    public override void Write(uint value)
    {
        throw new NotImplementedException();
    }

    public override void Write(ulong value)
    {
        throw new NotImplementedException();
    }

    public override Task WriteAsync(char value)
    {
        throw new NotImplementedException();
    }

    public override Task WriteAsync(char[] buffer, int index, int count)
    {
        throw new NotImplementedException();
    }

    public override Task WriteAsync(string? value)
    {
        throw new NotImplementedException();
    }

    public override void WriteLine()
    {
        throw new NotImplementedException();
    }

    public override void WriteLine(bool value)
    {
        throw new NotImplementedException();
    }

    public override void WriteLine(char value)
    {
        throw new NotImplementedException();
    }

    public override void WriteLine(char[]? buffer)
    {
        throw new NotImplementedException();
    }

    public override void WriteLine(char[] buffer, int index, int count)
    {
        throw new NotImplementedException();
    }

    public override void WriteLine(decimal value)
    {
        throw new NotImplementedException();
    }

    public override void WriteLine(double value)
    {
        throw new NotImplementedException();
    }

    public override void WriteLine(int value)
    {
        throw new NotImplementedException();
    }

    public override void WriteLine(long value)
    {
        throw new NotImplementedException();
    }

    public override void WriteLine(object? value)
    {
        throw new NotImplementedException();
    }

    public override void WriteLine(float value)
    {
        throw new NotImplementedException();
    }

    public override void WriteLine(string? value)
    {
        throw new NotImplementedException();
    }

    public override void WriteLine(string format, object? arg0)
    {
        throw new NotImplementedException();
    }

    public override void WriteLine(string format, object? arg0, object? arg1)
    {
        throw new NotImplementedException();
    }

    public override void WriteLine(string format, object? arg0, object? arg1, object? arg2)
    {
        throw new NotImplementedException();
    }

    public override void WriteLine(string format, params object?[] arg)
    {
        throw new NotImplementedException();
    }

    public override void WriteLine(uint value)
    {
        throw new NotImplementedException();
    }

    public override void WriteLine(ulong value)
    {
        throw new NotImplementedException();
    }

    public override Task WriteLineAsync()
    {
        throw new NotImplementedException();
    }

    public override Task WriteLineAsync(char value)
    {
        throw new NotImplementedException();
    }

    public override Task WriteLineAsync(char[] buffer, int index, int count)
    {
        throw new NotImplementedException();
    }

    public override Task WriteLineAsync(string? value)
    {
        throw new NotImplementedException();
    }

    protected override void Dispose(bool disposing)
    {
        throw new NotImplementedException();
    }
}