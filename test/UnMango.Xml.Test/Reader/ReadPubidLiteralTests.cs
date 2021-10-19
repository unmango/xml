using System.Text;
using Xunit;

namespace UnMango.Xml.Test.Reader;

[Trait("Category", "Unit")]
public class ReadPubidLiteralTests
{
    [Theory]
    [InlineData("\"Pubid\"")]
    [InlineData("'Pubid'")]
    public void Valid_Pubid_Value(string value)
    {
        var bytes = Encoding.UTF8.GetBytes(value);
        var reader = new XmlReader(bytes);

        var resultSpan = reader.ReadPubidLiteral();

        var result = Encoding.UTF8.GetString(resultSpan);
        Assert.Equal("Pubid", result);
    }

    [Theory]
    [InlineData("!Pubid")]
    [InlineData("#Pubid")]
    [InlineData("&Pubid")]
    [InlineData("(Pubid")]
    public void Invalid_Start_Character(string value)
    {
        var bytes = Encoding.UTF8.GetBytes(value);

        Assert.Throws<XmlParsingException>(() => {
            var reader = new XmlReader(bytes);
            reader.ReadPubidLiteral();
        });
    }

    [Theory]
    [InlineData("'\x21Pubid")]
    [InlineData("'\xBPubid")]
    [InlineData("'\xCPubid")]
    [InlineData("'\xEPubid")]
    public void Invalid_Pubid_Character(string value)
    {
        var bytes = Encoding.UTF8.GetBytes(value);

        Assert.Throws<XmlParsingException>(() => {
            var reader = new XmlReader(bytes);
            reader.ReadPubidLiteral();
        });
    }

    [Theory]
    [InlineData("\"Pubid")]
    [InlineData("'Pubid")]
    [InlineData("\"Pubid'")]
    [InlineData("'Pubid\"")]
    public void Expect_Closing_Delimiter(string value)
    {
        var bytes = Encoding.UTF8.GetBytes(value);

        Assert.Throws<XmlParsingException>(() => {
            var reader = new XmlReader(bytes);
            reader.ReadPubidLiteral();
        });
    }
}