using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using Benchmarker.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Benchmarker.Benchmarks
{
    [Version(1)]
    [MemoryDiagnoser()]
    [MarkdownExporterAttribute.GitHub]
    [JsonExporterAttribute.Full]
    public class FindvFirstOrDefault
    {
        private static readonly List<int> arr = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        [Benchmark]
        public int Find()
        {
            return arr.Find(x => x == 10);
        }

        [Benchmark]
        public int FirstOrDefault()
        {
            return arr.FirstOrDefault(x => x == 10);
        }
    }
}
