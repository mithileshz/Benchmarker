using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using Benchmarker.Core;
using System;

namespace Benchmarker.Benchmarks
{
    [Version(1)]
    [SimpleJob(RuntimeMoniker.CoreRt50)]
    [SimpleJob(RuntimeMoniker.CoreRt60)]
    [MemoryDiagnoser()]
    [MarkdownExporterAttribute.GitHub]
    [JsonExporterAttribute.Full]
    public class EmptyString
    {
        [GlobalSetup]
        public void GlobalSetup()
        {
            _ = string.Empty;
        }

        [Benchmark]
        public string StringEmpty()
        {
            return string.Empty;
        }

        [Benchmark]
        public string StringEmptyWithQuotes()
        {
            return "";
        }
    }
}
