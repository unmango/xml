using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace UnMango.Xml.Test
{
    [Trait("Category", "Unit")]
    public class XmlReaderTest
    {
        private static readonly char[] _validNameCharacters = new[]
        {
            '-', '.', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9'
        };

        private static readonly char[] _invalidNameCharacters = new[]
        {
            ';', '^', '`', '@', '['
        };

        [Theory(Skip = "Haven't finalized any element stuff yet")]
        [InlineData("<Element>")]
        [InlineData("<Element/>")]
        [InlineData("<Element />")]
        [InlineData("<Element Attribute=\"\">")]
        public void ReadBeginElement_Valid_Element(string input)
        {
            // Arrange
            var bytes = Encoding.UTF8.GetBytes(input);
            var reader = new XmlReader(bytes);

            // Act
            var result = reader.ReadBeginElement();

            // Assert
            var resultString = Encoding.UTF8.GetString(result.ToArray());
            Assert.Equal("Element", resultString);
        }

        [Fact(Skip = "Haven't finalized any element stuff yet")]
        public void ReadBeginElement_Invalid_Begin_Element()
        {
            const string input = "Element";
            var bytes = Encoding.UTF8.GetBytes(input);

            Assert.Throws<XmlParsingException>(() =>
            {
                var reader = new XmlReader(bytes);
                reader.ReadBeginElement();
            });
        }

        [Fact(Skip = "Haven't finalized any element stuff yet")]
        public void ReadBeginElement_Element_Does_Not_Close()
        {
            const string input = "<Element";
            var bytes = Encoding.UTF8.GetBytes(input);

            Assert.Throws<XmlParsingException>(() =>
            {
                var reader = new XmlReader(bytes);
                reader.ReadBeginElement();
            });
        }

        [Theory]
        [InlineData(":Element")]
        [InlineData("AElement")]
        [InlineData("ZElement")]
        [InlineData("_Element")]
        [InlineData("aElement")]
        [InlineData("zElement")]
        public void ReadName_Valid_Name(string name)
        {
            var bytes = Encoding.UTF8.GetBytes(name);
            var reader = new XmlReader(bytes);

            var resultSpan = reader.ReadName();

            var result = Encoding.UTF8.GetString(resultSpan);
            Assert.Equal(name, result);
        }

        [Theory]
        [InlineData("9Element")]
        [InlineData(";Element")]
        [InlineData("^Element")]
        [InlineData("`Element")]
        [InlineData("@Element")]
        [InlineData("[Element")]
        public void ReadName_Invalid_Start_Character(string name)
        {
            var bytes = Encoding.UTF8.GetBytes(name);

            Assert.Throws<XmlParsingException>(() =>
            {
                var reader = new XmlReader(bytes);
                var resultSpan = reader.ReadName();
            });
        }

        [Theory]
        [MemberData(nameof(InsertInvalidNameCharacterAt), ":Element", 5)]
        [MemberData(nameof(InsertInvalidNameCharacterAt), "AElement", 5)]
        [MemberData(nameof(InsertInvalidNameCharacterAt), "ZElement", 5)]
        [MemberData(nameof(InsertInvalidNameCharacterAt), "_Element", 5)]
        [MemberData(nameof(InsertInvalidNameCharacterAt), "aElement", 5)]
        [MemberData(nameof(InsertInvalidNameCharacterAt), "zElement", 5)]
        public void ReadName_Early_Non_Name_Character(string name, string expected)
        {
            var bytes = Encoding.UTF8.GetBytes(name);
            var reader = new XmlReader(bytes);

            var resultSpan = reader.ReadName();

            var result = Encoding.UTF8.GetString(resultSpan);
            Assert.Equal(expected, result);
        }

        [Theory]
        [MemberData(nameof(InsertValidNameCharacterAt), ":Element", 5)]
        [MemberData(nameof(InsertValidNameCharacterAt), "AElement", 5)]
        [MemberData(nameof(InsertValidNameCharacterAt), "ZElement", 5)]
        [MemberData(nameof(InsertValidNameCharacterAt), "_Element", 5)]
        [MemberData(nameof(InsertValidNameCharacterAt), "aElement", 5)]
        [MemberData(nameof(InsertValidNameCharacterAt), "zElement", 5)]
        public void ReadName_Early_Name_Character_Non_Name_Start_Character(string name)
        {
            var bytes = Encoding.UTF8.GetBytes(name);
            var reader = new XmlReader(bytes);

            var resultSpan = reader.ReadName();

            var result = Encoding.UTF8.GetString(resultSpan);
            Assert.Equal(name, result);
        }

        public static IEnumerable<object[]> InsertValidNameCharacterAt(string input, int index)
            => InsertAt(input, index, _validNameCharacters).Select(x => new object[] { x[0] });

        public static IEnumerable<object[]> InsertInvalidNameCharacterAt(string input, int index)
            => InsertAt(input, index, _invalidNameCharacters);

        private static IEnumerable<object[]> InsertAt(string input, int index, IEnumerable<char> characters)
        {
            foreach (var character in characters)
            {
                yield return new object[] {
                    input.Insert(index, character.ToString()),
                    input.Substring(0, index)
                };
            }
        }
    }
}
