using BenchmarkDotNet.Running;

namespace UnMango.Xml.Benchmarks;

internal static class Program
{
    private static void Main(string[] args)
    {
        if (args.Length > 0)
        {
            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
        }
        else
        {
            BenchmarkRunner.Run<XmlWriterBenchmark>();
        }
    }
}
