using System.Text;
using Xunit;

namespace UnMango.Xml.Test
{
    [Trait("Category", "Unit")]
    public class XmlReaderTest
    {
        [Theory]
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

        [Fact]
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

        [Fact]
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
    }
}
