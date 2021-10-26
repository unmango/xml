using System.Text;
using UnMango.Xml.Converters;
using Xunit;

namespace UnMango.Xml.Test.Converters;

public class Uint64ConverterTests
{
    private readonly Uint64Converter _converter = new();

    [Theory]
    [InlineData(ulong.MinValue)]
    [InlineData(42069)]
    [InlineData(ulong.MaxValue)]
    public void Read(ulong value)
    {
        var data = value.ToString();
        var xml = Encoding.UTF8.GetBytes(data);
        var reader = new XmlReader(xml);

        var result = _converter.Read(ref reader, typeof(int), XmlSerializerOptions.DefaultOptions);
        
        Assert.Equal(value, result);
    }
}
