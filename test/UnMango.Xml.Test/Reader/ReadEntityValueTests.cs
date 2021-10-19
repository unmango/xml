using System.Text;
using Xunit;

namespace UnMango.Xml.Test.Reader;

[Trait("Category", "Unit")]
public class ReadEntityValueTests
{
    [Theory]
    [InlineData("\"Entity\"")]
    [InlineData("'Entity'")]
    public void Valid_Entity_Value(string value)
    {
        var bytes = Encoding.UTF8.GetBytes(value);
        var reader = new XmlReader(bytes);

        var resultSpan = reader.ReadEntityValue();

        var result = Encoding.UTF8.GetString(resultSpan);
        Assert.Equal("Entity", result);
    }

    [Theory]
    [InlineData("!Entity")]
    [InlineData("#Entity")]
    [InlineData("&Entity")]
    [InlineData("(Entity")]
    public void Invalid_Start_Character(string value)
    {
        var bytes = Encoding.UTF8.GetBytes(value);

        Assert.Throws<XmlParsingException>(() => {
            var reader = new XmlReader(bytes);
            reader.ReadEntityValue();
        });
    }

    [Theory]
    [InlineData("'&Entity")]
    [InlineData("'%Entity")]
    public void Invalid_Entity_Character(string value)
    {
        var bytes = Encoding.UTF8.GetBytes(value);

        Assert.Throws<XmlParsingException>(() => {
            var reader = new XmlReader(bytes);
            reader.ReadEntityValue();
        });
    }

    [Theory]
    [InlineData("\"Entity")]
    [InlineData("'Entity")]
    [InlineData("\"Entity'")]
    [InlineData("'Entity\"")]
    public void Expect_Closing_Delimiter(string value)
    {
        var bytes = Encoding.UTF8.GetBytes(value);

        Assert.Throws<XmlParsingException>(() => {
            var reader = new XmlReader(bytes);
            reader.ReadEntityValue();
        });
    }
}
