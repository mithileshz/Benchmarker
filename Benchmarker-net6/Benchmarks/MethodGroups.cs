using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using System.Collections.Generic;
using System.Linq;

namespace Benchmarks.Benchmarks
{
    [SimpleJob(RuntimeMoniker.CoreRt50)]
    [SimpleJob(RuntimeMoniker.CoreRt60)]
    [MemoryDiagnoser()]
    [MarkdownExporterAttribute.GitHub]
    public class MethodGroups
    {
        private static readonly IEnumerable<int> ListOfInts = Enumerable.Range(1, 10_000).ToList();

        [Benchmark(Baseline = true)]
        public int LinqStatement()
        {
            return ListOfInts.Count(x => Condition(x));
        }

        [Benchmark]
        public int MethodGroup()
        {
            return ListOfInts.Count(Condition);
        }

        private static bool Condition(int value)
        {
            return value > 10;
        }
    }
}

