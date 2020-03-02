using System.Buffers;
using UnMango.Xml;
using Xunit;

namespace Unmango.Xml.Test
{
    [Trait("Category", "Unit")]
    public class XmlWriterTest
    {
        [Fact]
        public void WriteTrue()
        {
            var bufferWriter = new ArrayBufferWriter<byte>(4);
            var writer = new XmlWriter(bufferWriter);

            writer.WriteTrue();

            var written = bufferWriter.WrittenSpan;
            Assert.Equal((byte)'t', written[0]);
            Assert.Equal((byte)'r', written[1]);
            Assert.Equal((byte)'u', written[2]);
            Assert.Equal((byte)'e', written[3]);
        }

        [Fact]
        public void WriteFalse()
        {
            var bufferWriter = new ArrayBufferWriter<byte>(5);
            var writer = new XmlWriter(bufferWriter);

            writer.WriteFalse();

            var written = bufferWriter.WrittenSpan;
            Assert.Equal((byte)'f', written[0]);
            Assert.Equal((byte)'a', written[1]);
            Assert.Equal((byte)'l', written[2]);
            Assert.Equal((byte)'s', written[3]);
            Assert.Equal((byte)'e', written[4]);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void WriteBoolean(bool value)
        {
            var bufferWriter = new ArrayBufferWriter<byte>(5);
            var writer = new XmlWriter(bufferWriter);

            writer.Write(value);

            var written = bufferWriter.WrittenSpan;

            if (value)
            {
                Assert.Equal((byte)'t', written[0]);
                Assert.Equal((byte)'r', written[1]);
                Assert.Equal((byte)'u', written[2]);
                Assert.Equal((byte)'e', written[3]);
            }
            else
            {
                Assert.Equal((byte)'f', written[0]);
                Assert.Equal((byte)'a', written[1]);
                Assert.Equal((byte)'l', written[2]);
                Assert.Equal((byte)'s', written[3]);
                Assert.Equal((byte)'e', written[4]);
            }
        }
    }
}
