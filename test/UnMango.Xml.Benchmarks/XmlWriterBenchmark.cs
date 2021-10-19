using System.Buffers;
using System.Text;
using System.Xml;
using BenchmarkDotNet.Attributes;

namespace UnMango.Xml.Benchmarks;

[MemoryDiagnoser]
public class XmlWriterBenchmark
{
    private const int Iterations = 10_000;

    [Benchmark(Baseline = true)]
    public void System_WriteTrue()
    {
        var stringBuilder = new StringBuilder(4);
        var writer = System.Xml.XmlWriter.Create(stringBuilder, new() {
            ConformanceLevel = ConformanceLevel.Fragment
        });

        for (var i = 0; i < Iterations; i++)
            writer.WriteValue(true);
    }

    [Benchmark]
    public void UnMango_WriteTrue()
    {
        var bufferWriter = new ArrayBufferWriter<byte>(4);
        var writer = new XmlWriter(bufferWriter);

        for (var i = 0; i < Iterations; i++)
            writer.WriteTrue();
    }
}
