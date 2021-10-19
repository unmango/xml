using System.Text;
using Xunit;

namespace UnMango.Xml.Test.Reader;

[Trait("Category", "Unit")]
public class ReadElementTests
{
    [Theory]
    [InlineData("<Element></Element>")]
    public void ReadElement(string value)
    {
        var bytes = Encoding.UTF8.GetBytes(value);
        var reader = new XmlReader(bytes);
        
        var result = reader.
    }
}
