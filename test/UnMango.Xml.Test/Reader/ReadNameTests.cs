using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace UnMango.Xml.Test.Reader
{
    [Trait("Category", "Unit")]
    public class ReadNameTests
    {
        private static readonly char[] _validNameCharacters = new[]
        {
            '-', '.', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9'
        };

        private static readonly char[] _invalidNameCharacters = new[]
        {
            ';', '^', '`', '@', '['
        };

        private static readonly char[] _validStartNameCharacters = new[]
        {
            ':', 'A', 'Z', '_', 'a', 'z'
        };

        private static readonly char[] _invalidStartNameCharacters = new[]
        {
            '9', ';', '^', '`', '@', '['
        };

        private static readonly IEnumerable<char> _validNameInvalidStartNameIntersection =
            _validNameCharacters.Intersect(_invalidStartNameCharacters);

        public static readonly IEnumerable<object[]> Invalid_Start_Name_Character =
            _invalidStartNameCharacters.SelectAsTestParameters(x => x + "Element");

        public static readonly IEnumerable<object[]> Invalid_Names =
            TestHelper.CartesianProduct(_validStartNameCharacters, _invalidNameCharacters)
                .SelectAsTestParameters(x => new[] { x.Item1 + $"Elem{x.Item2}ent", x.Item1 + "Elem" });

        public static readonly IEnumerable<object[]> Valid_Start_Name_Character =
            _validStartNameCharacters.SelectAsTestParameters(x => x + "Element");

        public static readonly IEnumerable<object[]> Valid_Name_Containing_Name_Only_Characters =
            TestHelper.CartesianProduct(_validStartNameCharacters, _validNameInvalidStartNameIntersection)
                .SelectAsTestParameters(x => x.Item1 + $"Elem{x.Item2}ent");

        public static readonly IEnumerable<object[]> Valid_Name_Containing_Start_Name_Characters =
            TestHelper.CartesianProduct(_validStartNameCharacters, _validNameCharacters)
                .SelectAsTestParameters(x => x.Item1 + $"Elem{x.Item2}ent");

        [Theory]
        [MemberData(nameof(Valid_Start_Name_Character))]
        [MemberData(nameof(Valid_Name_Containing_Start_Name_Characters))]
        public void Valid_Name(string name)
        {
            var bytes = Encoding.UTF8.GetBytes(name);
            var reader = new XmlReader(bytes);

            var resultSpan = reader.ReadName();

            var result = Encoding.UTF8.GetString(resultSpan);
            Assert.Equal(name, result);
        }

        [Theory]
        [MemberData(nameof(Invalid_Start_Name_Character))]
        [MemberData(nameof(Invalid_Names))]
        public void Invalid_Name(string name)
        {
            var bytes = Encoding.UTF8.GetBytes(name);

            Assert.Throws<XmlParsingException>(() =>
            {
                var reader = new XmlReader(bytes);
                var resultSpan = reader.ReadName();
            });
        }

        [Theory]
        [MemberData(nameof(Valid_Name_Containing_Name_Only_Characters))]
        public void Early_Name_Character_Non_Name_Start_Character(string name, string expected)
        {
            var bytes = Encoding.UTF8.GetBytes(name);
            var reader = new XmlReader(bytes);

            var resultSpan = reader.ReadName();

            var result = Encoding.UTF8.GetString(resultSpan);
            Assert.Equal(expected, result);
        }
    }
}
