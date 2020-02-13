using System.IO;
using System.IO.Pipelines;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace UnMango.Xml.Test
{
    [Trait("Category", "Unit")]
    public class XmlSerializerSerializeGenericTest
    {
        private readonly CancellationTokenSource _tokenSource = TestOptions.GetTokenSource();

        [Fact]
        public void SerializeAsBytes_HappyPath()
        {
            const string xml = "<Item><Property>value</Property></Item>";
            var bytes = Encoding.UTF8.GetBytes(xml);
            var obj = new { Property = "value" };

            var result = XmlSerializer.Serialize(obj, TestOptions.DefaultSerializerOptions);

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

            XmlSerializer.Serialize(ref writer, obj, TestOptions.DefaultSerializerOptions);

            //Assert.Equal(bytes, writer.Something);
        }

        [Fact]
        public async Task SerializeToPipeWriter_HappyPath()
        {
            const string xml = "<Item><Property>value</Property></Item>";
            var bytes = Encoding.UTF8.GetBytes(xml);
            var obj = new { Property = "value" };
            var pipe = new Pipe();

            XmlSerializer.Serialize(pipe.Writer, obj, TestOptions.DefaultSerializerOptions);

            var result = await pipe.Reader.ReadAsync(_tokenSource.Token);
            byte[] read = result.Buffer.FirstSpan.ToArray();

            Assert.Equal(bytes, read);
        }

        [Fact]
        public void SerializeToStream_HappyPath()
        {
            const string xml = "<Item><Property>value</Property></Item>";
            var bytes = Encoding.UTF8.GetBytes(xml);
            var obj = new { Property = "value" };
            using var stream = new MemoryStream();

            XmlSerializer.Serialize(stream, obj, TestOptions.DefaultSerializerOptions);

            var read = stream.ToArray();

            Assert.Equal(bytes, read);
        }
    }
}
