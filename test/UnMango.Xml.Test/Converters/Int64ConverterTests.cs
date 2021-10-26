using System.Text;
using UnMango.Xml.Converters;
using Xunit;

namespace UnMango.Xml.Test.Converters;

public class Int64ConverterTests
{
    private readonly Int64Converter _converter = new();

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(1)]
    [InlineData(-42069)]
    [InlineData(42069)]
    [InlineData(long.MinValue)]
    [InlineData(long.MaxValue)]
    public void Read(long value)
    {
        var data = value.ToString();
        var xml = Encoding.UTF8.GetBytes(data);
        var reader = new XmlReader(xml);

        var result = _converter.Read(ref reader, typeof(int), XmlSerializerOptions.DefaultOptions);
        
        Assert.Equal(value, result);
    }
}
