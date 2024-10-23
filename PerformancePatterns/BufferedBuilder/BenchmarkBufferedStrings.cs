using BenchmarkDotNet.Attributes;
using PerformancePatterns.BufferedBuilder.Buffered;
using PerformancePatterns.BufferedBuilder.Classic;

namespace PerformancePatterns.BufferedBuilder
{
    [MemoryDiagnoser(displayGenColumns:true)]
    [Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class BenchmarkBufferedStrings
    {
        private ClassicStoreRevenuePerProductRepository  classicRepo;
        private BufferedBuilderStoreRevenuePerProductRepository repositoryOptimized;
      


        public BenchmarkBufferedStrings()
        {
            classicRepo = new ClassicStoreRevenuePerProductRepository();
            repositoryOptimized = new BufferedBuilderStoreRevenuePerProductRepository();
           

        }

        [Benchmark]
        public void ClassicFormatAsXml() 
        {

            classicRepo.FormatAsXml();
        }

        [Benchmark]
        public void BufferedFormatAsXml()
        {

            repositoryOptimized.FormatAsXml();
        }
         



    }
}
