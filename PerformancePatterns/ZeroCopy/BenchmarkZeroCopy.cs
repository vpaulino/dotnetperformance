using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformancePatterns.ZeroCopy
{
    [MemoryDiagnoser]
    [Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class BenchmarkZeroCopy
    {

        [Benchmark]
        public void StringSplitParseLine() 
        {
            string stringToParse = "2023-12-03T19:17:17;South Africa;Cape Town;NAPA Auto Parts;Coolant;24,99";
            var parser = new StringSplitParser();
            parser.ParseLine(stringToParse);
        }


        [Benchmark]
        public void StringSpanAndSliceParseLine()
        {
            string stringToParse = "2023-12-03T19:17:17;South Africa;Cape Town;NAPA Auto Parts;Coolant;24,99";
            var parser = new ZeroCopyParser();
            parser.ParseLine(Encoding.UTF8.GetBytes(stringToParse), ';');
        }
    }
}
