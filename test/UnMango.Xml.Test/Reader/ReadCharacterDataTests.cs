using System.Text;
using Xunit;

namespace UnMango.Xml.Test.Reader;

[Trait("Category", "Unit")]
public class ReadCharacterDataTests
{
    [Theory]
    [InlineData("Character Data")]
    public void Read(string data)
    {
        var bytes = Encoding.UTF8.GetBytes(data);
        var reader = new XmlReader(bytes);

        var resultSpan = reader.ReadCharacterData();

        var result = Encoding.UTF8.GetString(resultSpan);
        Assert.Equal(data, result);
    }

    [Theory]
    [InlineData("<Character Data")]
    [InlineData("&Character Data")]
    public void Invalid_Start_Character(string data)
    {
        var bytes = Encoding.UTF8.GetBytes(data);
        var reader = new XmlReader(bytes);

        var result = reader.ReadCharacterData();

        Assert.Equal(0, result.Length);
    }

    [Theory]
    [InlineData("Character]]> Data")]
    public void Invalid_CData_Close_Delimiter(string data)
    {
        var bytes = Encoding.UTF8.GetBytes(data);
        var reader = new XmlReader(bytes);

        var resultSpan = reader.ReadCharacterData();

        var result = Encoding.UTF8.GetString(resultSpan);
        Assert.Equal("Character", result);
    }

    [Theory]
    [InlineData("Character] Data")]
    [InlineData("Character]] Data")]
    public void Valid_CData_Close_Delimiter(string data)
    {
        var bytes = Encoding.UTF8.GetBytes(data);
        var reader = new XmlReader(bytes);

        var resultSpan = reader.ReadCharacterData();

        var result = Encoding.UTF8.GetString(resultSpan);
        Assert.Equal(data, result);
    }
}