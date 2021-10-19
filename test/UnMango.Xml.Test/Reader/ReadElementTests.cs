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
}
