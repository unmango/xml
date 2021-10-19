using System;
using System.IO;
using System.IO.Pipelines;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace UnMango.Xml.Test.Serializer;

[Trait("Category", "Unit")]
public class XmlSerializerDeserializeGenericAsyncTest
{
    private readonly CancellationTokenSource _tokenSource = TestOptions.GetTokenSource();

    [Fact(Skip = "Serializer not implemented")]
    public async Task DeserializeXmlString_HappyPath()
    {
        const string xml = "<Element></Element>";

        var result = await XmlSerializer.DeserializeAsync<object>(
            xml,
            TestOptions.DefaultSerializerOptions,
            _tokenSource.Token);

        Assert.NotNull(result);
    }

    [Fact(Skip = "Serializer not implemented")]
    public async Task DeserializeBytes_HappyPath()
    {
        const string xml = "<Element></Element>";
        var bytes = Encoding.UTF8.GetBytes(xml);

        var result = await XmlSerializer.DeserializeAsync<object>(
            bytes,
            TestOptions.DefaultSerializerOptions,
            _tokenSource.Token);

        Assert.NotNull(result);
    }

    [Fact(Skip = "Serializer not implemented")]
    public async Task DeserializeBytesAtOffset_HappyPath()
    {
        const string xml = "<Element></Element>";
        const int offset = 69;
        var xmlBytes = Encoding.UTF8.GetBytes(xml);
        var bytes = new byte[xmlBytes.Length + offset];
        Array.Copy(xmlBytes, 0, bytes, offset, xmlBytes.Length);

        var result = await XmlSerializer.DeserializeAsync<object>(
            bytes,
            offset,
            TestOptions.DefaultSerializerOptions,
            _tokenSource.Token);

        Assert.NotNull(result);
    }

    [Fact(Skip = "Serializer not implemented")]
    public async Task DeserializeSpan_HappyPath()
    {
        const string xml = "<Element></Element>";
        var memory = Encoding.UTF8.GetBytes(xml).AsMemory();

        var result = await XmlSerializer.DeserializeAsync<object>(
            memory.Span,
            TestOptions.DefaultSerializerOptions,
            _tokenSource.Token);

        Assert.NotNull(result);
    }

    [Fact(Skip = "Still working out whether XmlReader should be a struct/ref struct/class etc.")]
    public void DeserializeXmlReader_HappyPath()
    {
        const string xml = "<Element></Element>";
        var span = Encoding.UTF8.GetBytes(xml).AsSpan();
        var reader = new XmlReader(span);

        var result = XmlSerializer.DeserializeAsync<object>(
            ref reader,
            TestOptions.DefaultSerializerOptions,
            _tokenSource.Token);

        Assert.NotNull(result.Result);
    }

    [Fact(Skip = "Serializer not implemented")]
    public async Task DeserializePipeReader_HappyPath()
    {
        const string xml = "<Element></Element>";
        var memory = Encoding.UTF8.GetBytes(xml).AsMemory();
        var pipe = new Pipe();

        await pipe.Writer.WriteAsync(memory, _tokenSource.Token);
        await pipe.Writer.CompleteAsync();

        var result = await XmlSerializer.DeserializeAsync<object>(
            pipe.Reader,
            TestOptions.DefaultSerializerOptions,
            _tokenSource.Token);

        Assert.NotNull(result);
    }

    [Fact(Skip = "Serializer not implemented")]
    public async Task DeserializeStream_HappyPath()
    {
        const string xml = "<Element></Element>";
        var bytes = Encoding.UTF8.GetBytes(xml);
        using var stream = new MemoryStream(bytes);

        var result = await XmlSerializer.DeserializeAsync<object>(
            stream,
            TestOptions.DefaultSerializerOptions,
            _tokenSource.Token);

        Assert.NotNull(result);
    }
}