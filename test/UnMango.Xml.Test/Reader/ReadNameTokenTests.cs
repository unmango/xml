using System.Collections.Generic;
using System.Text;
using Xunit;

namespace UnMango.Xml.Test.Reader;

[Trait("Category", "Unit")]
public class ReadNameTokenTests
{
    public static readonly IEnumerable<object[]> Invalid_First_Character_Names =
        TestData.InvalidNameCharacters.SelectAsTestParameters(x => x + "Element");

    public static readonly IEnumerable<object[]> Invalid_Names =
        TestHelper.CartesianProduct(TestData.ValidNameCharacters, TestData.InvalidNameCharacters)
            .SelectAsTestParameters(x => new[] { x.Item1 + $"Elem{x.Item2}ent", x.Item1 + "Elem" });

    public static readonly IEnumerable<object[]> Valid_Names_Containing_Name_Characters =
        TestData.ValidNameCharacters.SelectAsTestParameters(x => $"Elem{x}ent");

    [Theory]
    [MemberData(nameof(Valid_Names_Containing_Name_Characters))]
    public void Valid_Name(string name)
    {
        var bytes = Encoding.UTF8.GetBytes(name);
        var reader = new XmlReader(bytes);

        var resultSpan = reader.ReadNameToken();

        var result = Encoding.UTF8.GetString(resultSpan);
        Assert.Equal(name, result);
    }

    [Theory]
    [MemberData(nameof(Invalid_First_Character_Names))]
    public void Invalid_First_Character(string name)
    {
        var bytes = Encoding.UTF8.GetBytes(name);

        Assert.Throws<XmlParsingException>(() => {
            var reader = new XmlReader(bytes);
            var resultSpan = reader.ReadNameToken();
        });
    }

    [Theory]
    [MemberData(nameof(Invalid_Names))]
    public void Invalid_Name_Returns_Substring(string name, string expected)
    {
        var bytes = Encoding.UTF8.GetBytes(name);
        var reader = new XmlReader(bytes);

        var resultSpan = reader.ReadNameToken();

        var result = Encoding.UTF8.GetString(resultSpan);
        Assert.Equal(expected, result);
    }
}