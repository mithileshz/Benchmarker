using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using Benchmarker.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benchmarker.Benchmarks
{
    //[Version(1)]
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
