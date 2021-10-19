using System;
using Xunit;

namespace UnMango.Xml.Test;

[Trait("Category", "Unit")]
public class XmlConverterTests
{
    [Fact]
    public void BaseTypeToConvert_IsNull()
    {
        var converter = new TestXmlConverter();

        Assert.Null(converter.TypeToConvert);
    }

    [Fact]
    public void BaseTypeToConvert_IsGenericTypeParameter()
    {
        var converter = new TestGenerixXmlConverter();

        Assert.Equal(typeof(object), converter.TypeToConvert);
    }

    [Fact]
    public void CanConvert_GenericTypeParameter()
    {
        var converter = new TestGenerixXmlConverter();

        var result = converter.CanConvert(typeof(object));

        Assert.True(result);
    }

    [Theory]
    [InlineData(typeof(int))]
    [InlineData(typeof(uint))]
    [InlineData(typeof(float))]
    [InlineData(typeof(short))]
    [InlineData(typeof(ushort))]
    [InlineData(typeof(double))]
    [InlineData(typeof(long))]
    [InlineData(typeof(ulong))]
    [InlineData(typeof(string))]
    [InlineData(typeof(bool))]
    [InlineData(typeof(char))]
    [InlineData(typeof(byte))]
    [InlineData(typeof(sbyte))]
    [InlineData(typeof(Type))]
    public void CantConvert_NonGenericTypeParameter(Type type)
    {
        var converter = new TestGenerixXmlConverter();

        var result = converter.CanConvert(type);

        Assert.False(result);
    }

    private class TestXmlConverter : XmlConverter
    {
        public override bool CanConvert(Type typeToConvert)
        {
            throw new NotImplementedException();
        }
    }

    private class TestGenerixXmlConverter : XmlConverter<object>
    {
        public override object Read(ref XmlReader reader, Type typeToConvert, XmlSerializerOptions options)
        {
            throw new NotImplementedException();
        }

        public override void Write(ref XmlWriter writer, object value, XmlSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }
}