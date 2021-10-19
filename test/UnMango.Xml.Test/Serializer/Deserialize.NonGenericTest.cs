using System;
using System.IO;
using System.IO.Pipelines;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace UnMango.Xml.Test.Serializer;

[Trait("Category", "Unit")]
public class XmlSerializerDeserializeNonGenericTest
{
    private readonly CancellationTokenSource _tokenSource = TestOptions.GetTokenSource();

    [Fact(Skip = "Serializer not implemented")]
    public void DeserializeString_HappyPath()
    {
        var type = typeof(object);
        const string xml = "<Element></Element>";

        var result = XmlSerializer.Deserialize(type, xml, TestOptions.DefaultSerializerOptions);

        Assert.NotNull(result);
        Assert.IsType(type, result);
    }

    [Fact(Skip = "Serializer not implemented")]
    public void DeserializeBytes_HappyPath()
    {
        var type = typeof(object);
        const string xml = "<Element></Element>";
        var bytes = Encoding.UTF8.GetBytes(xml);

        var result = XmlSerializer.Deserialize(type, bytes, TestOptions.DefaultSerializerOptions);

        Assert.NotNull(result);
        Assert.IsType(type, result);
    }

    [Fact(Skip = "Serializer not implemented")]
    public void DeserializeBytesWithOffset_HappyPath()
    {
        var type = typeof(object);
        const string xml = "<Element></Element>";
        const int offset = 69;
        var xmlBytes = Encoding.UTF8.GetBytes(xml);
        var bytes = new byte[offset + xmlBytes.Length];
        Array.Copy(xmlBytes, 0, bytes, offset, xmlBytes.Length);

        var result = XmlSerializer.Deserialize(type, bytes, offset, TestOptions.DefaultSerializerOptions);

        Assert.NotNull(result);
        Assert.IsType(type, result);
    }

    [Fact(Skip = "Serializer not implemented")]
    public void DeserializeSpan_HappyPath()
    {
        var type = typeof(object);
        const string xml = "<Element></Element>";
        var span = Encoding.UTF8.GetBytes(xml).AsSpan();

        var result = XmlSerializer.Deserialize(type, span, TestOptions.DefaultSerializerOptions);

        Assert.NotNull(result);
        Assert.IsType(type, result);
    }

    [Fact(Skip = "Serializer not implemented")]
    public void DeserializeReader_HappyPath()
    {
        var type = typeof(object);
        const string xml = "<Element></Element>";
        var span = Encoding.UTF8.GetBytes(xml).AsSpan();
        var reader = new XmlReader(span);

        var result = XmlSerializer.Deserialize(type, ref reader, TestOptions.DefaultSerializerOptions);

        Assert.NotNull(result);
        Assert.IsType(type, result);
    }

    [Fact(Skip = "Serializer not implemented")]
    public async Task DeserializePipeReader_HappyPath()
    {
        var type = typeof(object);
        const string xml = "<Element></Element>";
        var memory = Encoding.UTF8.GetBytes(xml).AsMemory();
        var pipe = new Pipe();

        await pipe.Writer.WriteAsync(memory, _tokenSource.Token);

        var result = XmlSerializer.Deserialize(type, pipe.Reader, TestOptions.DefaultSerializerOptions);

        Assert.NotNull(result);
        Assert.IsType(type, result);
    }

    [Fact(Skip = "Serializer not implemented")]
    public void DeserializeStream_HappyPath()
    {
        var type = typeof(object);
        const string xml = "<Element></Element>";
        var bytes = Encoding.UTF8.GetBytes(xml);
        using var stream = new MemoryStream(bytes);

        var result = XmlSerializer.Deserialize(type, stream, TestOptions.DefaultSerializerOptions);

        Assert.NotNull(result);
        Assert.IsType(type, result);
    }
}