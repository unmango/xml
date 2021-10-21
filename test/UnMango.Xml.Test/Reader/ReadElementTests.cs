using System.Text;
using Xunit;

namespace UnMango.Xml.Test.Reader;

[Trait("Category", "Unit")]
public class ReadElementTests
{
    [Theory]
    [InlineData("<")]
    [InlineData("<doesn't-matter")]
    public void ReadOpenElement(string value)
    {
        var bytes = Encoding.UTF8.GetBytes(value);
        var reader = new XmlReader(bytes);

        reader.ReadOpenElement();
    }

    [Theory]
    [InlineData(">")]
    [InlineData("69")]
    [InlineData("four-twenty")]
    public void ReadOpenElement_ThrowsWhenNotPositionedAtOpenElement(string value)
    {
        var bytes = Encoding.UTF8.GetBytes(value);

        Assert.Throws<XmlParsingException>(() => {
            var reader = new XmlReader(bytes);
            reader.ReadOpenElement();
        });
    }
    
    [Theory]
    [InlineData(">")]
    [InlineData(">doesn't-matter>")]
    public void ReadCloseElement(string value)
    {
        var bytes = Encoding.UTF8.GetBytes(value);
        var reader = new XmlReader(bytes);

        reader.ReadCloseElement();
    }

    [Theory]
    [InlineData("<")]
    [InlineData("69")]
    [InlineData("four-twenty")]
    public void ReadCloseElement_ThrowsWhenNotPositionedAtOpenElement(string value)
    {
        var bytes = Encoding.UTF8.GetBytes(value);

        Assert.Throws<XmlParsingException>(() => {
            var reader = new XmlReader(bytes);
            reader.ReadCloseElement();
        });
    }
}
