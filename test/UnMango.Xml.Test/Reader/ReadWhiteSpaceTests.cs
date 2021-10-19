using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace UnMango.Xml.Test.Reader;

[Trait("Category", "Unit")]
public class ReadWhiteSpaceTests
{
    [Theory]
    [InlineData(" ")]
    [InlineData("\n")]
    [InlineData("\r")]
    [InlineData("\t")]
    [InlineData(" A")]
    [InlineData("\nA")]
    [InlineData("\rA")]
    [InlineData("\tA")]
    public void Starting_At_WhiteSpace(string whitespace)
    {
        var bytes = Encoding.UTF8.GetBytes(whitespace);
        var reader = new XmlReader(bytes);

        reader.ReadWhiteSpace();
    }

    [Theory]
    [InlineData("!")]
    [InlineData("\b")]
    [InlineData("\v")]
    [InlineData("A")]
    [InlineData("Z")]
    [InlineData("a")]
    [InlineData("z")]
    public void Throws_When_Not_Positioned_At_WhiteSpace(string value)
    {
        var bytes = Encoding.UTF8.GetBytes(value);

        Assert.Throws<XmlParsingException>(() => {
            var reader = new XmlReader(bytes);
            reader.ReadWhiteSpace();
        });
    }
}