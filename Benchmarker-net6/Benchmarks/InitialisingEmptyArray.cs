using BenchmarkDotNet.Attributes;

namespace Benchmarker_net6.Benchmarks;

/// <title>
/// .NET 6 Benchmarks - Initialising Empty Array
/// </title>
/// <summary>
/// When initialising an empty array in your codebase, there are two options you would choose from:
/// `new T[0]` or `Array.Empty<T>()`. 
/// This benchmark is to compare the two options to see which is better.
/// </summary>
[MemoryDiagnoser()]
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