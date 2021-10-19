using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace UnMango.Xml.Test;

[Trait("Category", "Unit")]
public class XmlConstantsTests
{
    public static readonly IEnumerable<object[]> NameStartCharacters = new byte[]
    {
        (byte)':',
        (byte)'_',
        (byte)'A',
        (byte)'B',
        (byte)'Y',
        (byte)'Z',
        (byte)'a',
        (byte)'b',
        (byte)'y',
        (byte)'z',
        0xC0,
        0xC1,
        0xD5,
        0xD6,
        0xD8,
        0xD9,
        0xF5,
        0xF6,
        0xF8,
        0xF9
    }.Select(x => new object[] { x });

    [Theory]
    [InlineData('\'')]
    [InlineData('"')]
    public void Is_Literal_Delimeter(char character)
    {
        Assert.True(XmlConstants.IsLiteralDelimiter((byte)character));
    }

    [Theory]
    [InlineData('<')]
    [InlineData('>')]
    public void Is_Not_Literal_Delimeter(char character)
    {
        Assert.False(XmlConstants.IsLiteralDelimiter((byte)character));
    }

    [Theory]
    [MemberData(nameof(NameStartCharacters))]
    public void Is_Name_Start_Character(byte character)
    {
        Assert.True(XmlConstants.IsNameStartCharacter(character));
    }

    [Theory]
    [InlineData('9')]
    [InlineData(';')]
    [InlineData('^')]
    [InlineData('`')]
    [InlineData('@')]
    [InlineData('[')]
    [InlineData(0xBF)]
    [InlineData(0xD7)]
    [InlineData(0xF7)]
    public void Is_Not_Name_Start_Character(byte character)
    {
        Assert.False(XmlConstants.IsNameStartCharacter(character));
    }

    [Theory]
    [MemberData(nameof(NameStartCharacters))]
    [InlineData('-')]
    [InlineData('.')]
    [MemberData(nameof(Range), (byte)'0', (byte)'9')]
    [InlineData(0xB7)]
    public void Is_Name_Character(byte character)
    {
        Assert.True(XmlConstants.IsNameCharacter(character));
    }

    [Theory]
    [InlineData(';')]
    [InlineData('^')]
    [InlineData('`')]
    [InlineData('@')]
    [InlineData('[')]
    [InlineData(0xBF)]
    [InlineData(0xD7)]
    [InlineData(0xF7)]
    [InlineData('/')]
    public void Is_Not_Name_Character(byte character)
    {
        Assert.False(XmlConstants.IsNameCharacter(character));
    }

    [Theory]
    [InlineData('a')]
    [InlineData('b')]
    [InlineData('y')]
    [InlineData('z')]
    [InlineData('A')]
    [InlineData('B')]
    [InlineData('Y')]
    [InlineData('Z')]
    [InlineData(0x20)]
    [InlineData(0xD)]
    [InlineData(0xA)]
    [MemberData(nameof(Range), (byte)'0', (byte)'9')]
    [InlineData('-')]
    [InlineData('\'')]
    [InlineData('(')]
    [InlineData(0x29)] // ')' This character messes with the test runner somehow
    [InlineData('+')]
    [InlineData(',')]
    [InlineData('.')]
    [InlineData('/')]
    [InlineData(':')]
    [InlineData('=')]
    [InlineData('?')]
    [InlineData(';')]
    [InlineData('!')]
    [InlineData('*')]
    [InlineData('#')]
    [InlineData('@')]
    [InlineData('$')]
    [InlineData('_')]
    [InlineData('%')]
    public void Is_Pubid_Character(byte character)
    {
        Assert.True(XmlConstants.IsPubidCharacter(character));
    }

    [Theory]
    [InlineData(0x19)]
    [InlineData(0x9)]
    [InlineData(0xB)]
    [InlineData(0xC)]
    [InlineData(0xE)]
    [InlineData('`')]
    [InlineData(0x18)]
    [InlineData('~')]
    public void Is_Not_Pubid_Character(byte character)
    {
        Assert.False(XmlConstants.IsPubidCharacter(character));
    }

    [Theory]
    [InlineData(' ')]
    [InlineData('\t')]
    [InlineData('\n')]
    [InlineData('\r')]
    public void Is_Whitespace(byte character)
    {
        Assert.True(XmlConstants.IsWhiteSpace(character));
    }

    public static IEnumerable<object[]> Range(byte start, byte end)
    {
        for (byte i = start; i <= end; i++)
        {
            yield return new object[] { i };
        }
    }
}