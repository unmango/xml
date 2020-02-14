using System.IO;
using System.IO.Pipelines;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace UnMango.Xml.Test
{
    //[Trait("Category", "Unit")]
    public class XmlSerializerSerializeGenericAsyncTest
    {
        private readonly CancellationTokenSource _tokenSource = TestOptions.GetTokenSource();

        [Fact]
        public async Task SerializeAsBytes_HappyPath()
        {
            const string xml = "<Item><Property>value</Property></Item>";
            var bytes = Encoding.UTF8.GetBytes(xml);
            var obj = new { Property = "value" };

            var result = await XmlSerializer.SerializeAsync(
                obj,
                TestOptions.DefaultSerializerOptions,
                _tokenSource.Token);

            Assert.Equal(bytes, result);
        }

        [Fact(Skip = "Still working out whether XmlWriter should be a struct/ref struct/class etc.")]
        public void SerializeToWriter_HappyPath()
        {
            const string xml = "<Item><Property>value</Property></Item>";
            var bytes = Encoding.UTF8.GetBytes(xml);
            var obj = new { Property = "value" };
            var buffer = new byte[bytes.Length];
            var writer = new XmlWriter(buffer);

            var task = XmlSerializer.SerializeAsync(
                ref writer,
                obj,
                TestOptions.DefaultSerializerOptions,
                _tokenSource.Token);

            //Assert.Equal(bytes, writer.Something);
        }

        [Fact]
        public async Task SerializeToPipeWriter_HappyPath()
        {
            const string xml = "<Item><Property>value</Property></Item>";
            var bytes = Encoding.UTF8.GetBytes(xml);
            var obj = new { Property = "value" };
            var pipe = new Pipe();

            await XmlSerializer.SerializeAsync(
                pipe.Writer,
                obj,
                TestOptions.DefaultSerializerOptions,
                _tokenSource.Token);

            var result = await pipe.Reader.ReadAsync(_tokenSource.Token);
            byte[] read = result.Buffer.FirstSpan.ToArray();

            Assert.Equal(bytes, read);
        }

        [Fact]
        public async Task SerializeToStream_HappyPath()
        {
            const string xml = "<Item><Property>value</Property></Item>";
            var bytes = Encoding.UTF8.GetBytes(xml);
            var obj = new { Property = "value" };
            using var stream = new MemoryStream();

            await XmlSerializer.SerializeAsync(
                stream,
                obj,
                TestOptions.DefaultSerializerOptions,
                _tokenSource.Token);

            var read = stream.ToArray();

            Assert.Equal(bytes, read);
        }
    }
}
