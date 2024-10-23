using BenchmarkDotNet.Attributes;
using PerformancePatterns.StructArrays.Classic;
using PerformancePatterns.StructArrays.NoStructs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformancePatterns.StructArrays
{
    [MemoryDiagnoser]
    [Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class BenchmarkStructArrays
    {
        private StoreRevenuePerProductRepository repository;
        private StoreRevenuePerProductStructOptimizedRepository repositoryOptimized;
        private NoStructsStoreRevenuePerProductRepository repositoryWithNoStructs;


        public BenchmarkStructArrays()
        {
            repository = new StoreRevenuePerProductRepository();
            repositoryOptimized = new StoreRevenuePerProductStructOptimizedRepository();
            repositoryWithNoStructs = new NoStructsStoreRevenuePerProductRepository();
        }
        [Benchmark]
        public void StoreRevenuePerProductRepository() 
        {   
         
            repository.UpdateScorings();
        }


        [Benchmark]
        public void StoreRevenuePerProductStructOptimizedRepository()
        { 

            repositoryOptimized.UpdateScorings();
        }

        [Benchmark]
        public void StoreRevenuePerProductWithNoStructsRepository()
        {

            repositoryWithNoStructs.UpdateScorings();
        }
    }
}
