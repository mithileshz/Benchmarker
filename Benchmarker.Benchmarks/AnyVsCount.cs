using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using Benchmarker.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Benchmarker.Benchmarks
{
    [Version(1)]
    [SimpleJob(RuntimeMoniker.Net80)]
    [MemoryDiagnoser()]
    [MarkdownExporterAttribute.GitHub]
    [JsonExporterAttribute.Full]
    public class AnyVsCount
    {
        [Params(100, 10000)]
        public int N;

        private List<int> benchmarkList { get; set; } = new List<int>();

        [GlobalSetup]
        public void GlobalSetup()
        {
            for (var i = 0; i < this.N; i++)
            {
                this.benchmarkList.Add(i);
            }
        }

        [Benchmark]
        public bool ListAny()
        {
            return benchmarkList.Any();
        }

        [Benchmark]
        public bool CountNotEqualsZero()
        {
            return benchmarkList.Count != 0;
        }
    }
}
