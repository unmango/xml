using System;
using System.Buffers;
using System.Collections.Generic;
using System.Text;
using BenchmarkDotNet.Attributes;

namespace UnMango.Xml.Benchmarks
{
    public class XmlWriterBenchmark
    {
        [Benchmark]
        public void UnMango_WriteTrue()
        {
            var bufferWriter = new ArrayBufferWriter<byte>(4);
            var writer = new XmlWriter(bufferWriter);

            writer.WriteTrue();
        }

        [Benchmark]
        public void System_WriteTrue()
        {
            var stringBuilder = new StringBuilder(4);
            var writer = System.Xml.XmlWriter.Create(stringBuilder);

            writer.WriteValue(true);
        }
    }
}
