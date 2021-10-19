using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace UnMango.Xml.Test.Reader;

[Trait("Category", "Unit")]
public class ReadNameTests
{
    private static readonly IEnumerable<char> _validNameInvalidStartNameIntersection =
        TestData.ValidNameCharacters.Intersect(TestData.InvalidStartNameCharacters);

    public static readonly IEnumerable<object[]> Invalid_Start_Name_Character_Names =
        TestData.InvalidStartNameCharacters.SelectAsTestParameters(x => x + "Element");

    public static readonly IEnumerable<object[]> Invalid_Names =
        TestHelper.CartesianProduct(TestData.ValidStartNameCharacters, TestData.InvalidNameCharacters)
            .SelectAsTestParameters(x => new[] { x.Item1 + $"Elem{x.Item2}ent", x.Item1 + "Elem" });

    public static readonly IEnumerable<object[]> Valid_Start_Name_Character_Names =
        TestData.ValidStartNameCharacters.SelectAsTestParameters(x => x + "Element");

    public static readonly IEnumerable<object[]> Valid_Names_Containing_Name_Only_Characters =
        TestHelper.CartesianProduct(TestData.ValidStartNameCharacters, _validNameInvalidStartNameIntersection)
            .SelectAsTestParameters(x => x.Item1 + $"Elem{x.Item2}ent");

    public static readonly IEnumerable<object[]> Valid_Names_Containing_Start_Name_Characters =
        TestHelper.CartesianProduct(TestData.ValidStartNameCharacters, TestData.ValidNameCharacters)
            .SelectAsTestParameters(x => x.Item1 + $"Elem{x.Item2}ent");

    [Theory]
    [MemberData(nameof(Valid_Start_Name_Character_Names))]
    [MemberData(nameof(Valid_Names_Containing_Name_Only_Characters))]
    [MemberData(nameof(Valid_Names_Containing_Start_Name_Characters))]
    public void Valid_Name(string name)
    {
        var bytes = Encoding.UTF8.GetBytes(name);
        var reader = new XmlReader(bytes);

        var resultSpan = reader.ReadName();

        var result = Encoding.UTF8.GetString(resultSpan);
        Assert.Equal(name, result);
    }

    [Theory]
    [MemberData(nameof(Invalid_Start_Name_Character_Names))]
    public void Invalid_Start_Name_Character(string name)
    {
        var bytes = Encoding.UTF8.GetBytes(name);

        Assert.Throws<XmlParsingException>(() => {
            var reader = new XmlReader(bytes);
            var resultSpan = reader.ReadName();
        });
    }

    [Theory]
    [MemberData(nameof(Invalid_Names))]
    public void Invalid_Name_Returns_Substring(string name, string expected)
    {
        var bytes = Encoding.UTF8.GetBytes(name);
        var reader = new XmlReader(bytes);

        var resultSpan = reader.ReadName();

        var result = Encoding.UTF8.GetString(resultSpan);
        Assert.Equal(expected, result);
    }
}