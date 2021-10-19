using System.Text;
using Xunit;

namespace UnMango.Xml.Test.Reader;

[Trait("Category", "Unit")]
public class ReadAttributeValueTests
{
    [Theory]
    [InlineData("\"Attribute\"")]
    [InlineData("'Attribute'")]
    public void Valid_Attribute_Value(string value)
    {
        var bytes = Encoding.UTF8.GetBytes(value);
        var reader = new XmlReader(bytes);

        var resultSpan = reader.ReadAttributeValue();

        var result = Encoding.UTF8.GetString(resultSpan);
        Assert.Equal("Attribute", result);
    }

    [Theory]
    [InlineData("!Attribute")]
    [InlineData("#Attribute")]
    [InlineData("&Attribute")]
    [InlineData("(Attribute")]
    public void Invalid_Start_Character(string value)
    {
        var bytes = Encoding.UTF8.GetBytes(value);

        Assert.Throws<XmlParsingException>(() => {
            var reader = new XmlReader(bytes);
            reader.ReadAttributeValue();
        });
    }

    [Theory]
    [InlineData("'&Attribute")]
    [InlineData("'<Attribute")]
    public void Invalid_Attribute_Character(string value)
    {
        var bytes = Encoding.UTF8.GetBytes(value);

        Assert.Throws<XmlParsingException>(() => {
            var reader = new XmlReader(bytes);
            reader.ReadAttributeValue();
        });
    }

    [Theory]
    [InlineData("\"Attribute")]
    [InlineData("'Attribute")]
    [InlineData("\"Attribute'")]
    [InlineData("'Attribute\"")]
    public void Expect_Closing_Delimiter(string value)
    {
        var bytes = Encoding.UTF8.GetBytes(value);

        Assert.Throws<XmlParsingException>(() => {
            var reader = new XmlReader(bytes);
            reader.ReadAttributeValue();
        });
    }
}
