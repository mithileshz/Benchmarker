using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benchmarker.Benchmarks
{
    [SimpleJob(RuntimeMoniker.CoreRt50)]
    [SimpleJob(RuntimeMoniker.CoreRt60)]
    [MemoryDiagnoser()]
    [MarkdownExporterAttribute.GitHub]
    public class EmptyString
    {
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
