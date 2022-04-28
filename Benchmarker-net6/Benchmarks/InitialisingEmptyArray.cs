using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using Benchmarker.Core;
using System;

namespace Benchmarks.Benchmarks
{
    [Title(".NET 6 Benchmarks - Initialising Empty Array")]
    [Introduction(@"
When initialising an empty array in your codebase, there are two options you would choose from:
`new T[0]` or `Array.Empty<T>()`. 
This benchmark is to compare the two options to see which is better.")]
    [Summary(@"
From the results, `Array.Empty<T>()` is a better solution. This also matches with Microsoft's Code Analysis rule [CA1825](https://docs.microsoft.com/en-us/dotnet/fundamentals/code-analysis/quality-rules/ca1825).
Please take the timings with a pinch of salt as this is being run on my local PC and your results may differ. The important thing is the Ratio and Memory Allocation.
")]
    [SimpleJob(RuntimeMoniker.CoreRt50)]
    [SimpleJob(RuntimeMoniker.CoreRt60)]
    [MemoryDiagnoser]
    [MarkdownExporterAttribute.GitHub]
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