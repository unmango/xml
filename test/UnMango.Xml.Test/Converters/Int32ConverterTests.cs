using System.Text;
using UnMango.Xml.Converters;
using Xunit;

namespace UnMango.Xml.Test.Converters;

public class Int32ConverterTests
{
    private readonly Int32Converter _converter = new();

    [Theory]
    [InlineData(0)]
    [InlineData(42069)]
    public void Read(int value)
    {
        var data = value.ToString();
        var xml = Encoding.UTF8.GetBytes(data);
        var reader = new XmlReader(xml);

        var result = _converter.Read(ref reader, typeof(int), XmlSerializerOptions.DefaultOptions);
        
        Assert.Equal(value, result);
    }
}
