using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformantFileReader
{
    [MemoryDiagnoser]
    [Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class BenchmarkExecutor
    {
        private SimpleStreamReader simpleCsvReader;
        private ChatGptSpanReader chatGptCsvReader;
        private StreamSpanReader spanCsvReader;
        private AllInMemoryReader allInMemoryCsvReader;
        private PipelineSpanOrchestrator pipelineSpanOrchestrator;

        [GlobalSetup]
        public void Setup()
        {
             allInMemoryCsvReader = new AllInMemoryReader("sells.csv");
            // Provide a path to your CSV file here
            simpleCsvReader = new SimpleStreamReader("sells.csv");
            chatGptCsvReader = new ChatGptSpanReader("sells.csv");
            spanCsvReader = new StreamSpanReader("sells.csv");
            pipelineSpanOrchestrator = new PipelineSpanOrchestrator("smallSells.csv");
        }

        [Benchmark]
        public async Task BenchmarkPipelineProcess() 
        {
            await pipelineSpanOrchestrator.IngestFileAsync(CancellationToken.None);
        }

        [Benchmark]

        public void BenchmarkAllInMemoryCsvRead()
        {
            allInMemoryCsvReader.ReadCsv();
        }


        [Benchmark]
      
        public void BenchmarkStreamSimpleCsvRead()
        {
            simpleCsvReader.ReadCsv();
        }

        [Benchmark]

        public void BenchmarkChatGptCsvRead()
        {
            chatGptCsvReader.ReadCsv();
        }

        [Benchmark]
        public void BenchmarkSpanCsvRead()
        {
            spanCsvReader.ReadCsv();
        }
    }
}
