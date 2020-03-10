using Xunit;

namespace UnMango.Xml.Test
{
    [Trait("Category", "Unit")]
    public class NumberConverterTests
    {
        [Fact]
        public void ToInt16()
        {
            const byte first = 0x69, second = 0x42;
            const short expected = 0x6942;

            var result = NumberConverter.ToInt16(first, second);

            Assert.Equal(expected, result);
        }
    }
}
