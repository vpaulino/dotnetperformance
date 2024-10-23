using BenchmarkDotNet.Attributes;
using PerformancePatterns.StructArrays.Classic;
using PerformancePatterns.StructArrays.NoStructs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PerformancePatterns.StackBased.Classic;
using PerformancePatterns.StackBased.Stackallocs;

namespace PerformancePatterns.StackBased
{
    [MemoryDiagnoser(displayGenColumns:true)]
    [Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class BenchmarkStackBasedArrays
    {
        private StoreRevenuePerProductStructOptimizedRepository classicRepo;
        private StoreRevenuePerProductStructStackAllocOptimizedRepository repositoryOptimized;
      


        public BenchmarkStackBasedArrays()
        {
            classicRepo = new StoreRevenuePerProductStructOptimizedRepository();
            repositoryOptimized = new StoreRevenuePerProductStructStackAllocOptimizedRepository();
           

        }
        [Benchmark]
        public void UpdateStoreScoringsWithHeap() 
        {

            classicRepo.UpdateStoreScoringsWithHeap();
        }

        [Benchmark]
        public void UpdateStoreScoringsWithHeapAndLinq()
        {

            classicRepo.UpdateStoreScoringsWithHeapAndLinq();
        }




        [Benchmark]
        public void UpdateStoreScoringsWithStack()
        {

            repositoryOptimized.UpdateStoreScorings();
        } 




    }
}
