using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using System.Collections.Generic;
using System.Linq;

namespace Benchmarker.Benchmarks
{
    [SimpleJob(RuntimeMoniker.CoreRt60)]
    [MemoryDiagnoser()]
    public class MethodGroups
    {
        private static readonly IEnumerable<int> ListOfInts = Enumerable.Range(1, 10_000).ToList();

        [Benchmark]
        public int Lambda_Static()
        {
            return ListOfInts.Count(x => ConditionStatic(x));
        }

        [Benchmark]
        public int MethodGroup_Static()
        {
            return ListOfInts.Count(ConditionStatic);
        }

        private static bool ConditionStatic(int value)
        {
            return value > 10;
        }

        [Benchmark]
        public int Lambda_Instance()
        {
            return ListOfInts.Count(x => ConditionInstance(x));
        }

        [Benchmark]
        public int MethodGroup_Instance()
        {
            return ListOfInts.Count(ConditionInstance);
        }

        private bool ConditionInstance(int value)
        {
            return value > 10;
        }
    }
}

