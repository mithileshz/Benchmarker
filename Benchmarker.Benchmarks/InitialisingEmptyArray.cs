using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using Benchmarker.Core;
using System;

namespace Benchmarker.Benchmarks
{
    [Version(1)]
    [SimpleJob(RuntimeMoniker.Net60)]
    [SimpleJob(RuntimeMoniker.Net70)]
    [SimpleJob(RuntimeMoniker.Net80)]
    [MemoryDiagnoser]
    [MarkdownExporterAttribute.GitHub]
    [JsonExporterAttribute.Full]
    public class InitialisingEmptyArray
    {
        [Benchmark(Baseline = true)]
        public int[] EmptyArrayByNewT()
        {
            return new int[0];
        }

        [Benchmark]
        public int[] EmptyArrayByArrayEmpty()
        {
            return Array.Empty<int>();
        }
    }
}