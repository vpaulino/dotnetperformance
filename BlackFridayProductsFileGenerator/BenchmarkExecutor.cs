using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnostics.Windows.Configs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackFridayProductsFileGenerator
{
    [MemoryDiagnoser]
    [TailCallDiagnoser]
    [EtwProfiler]
    [ConcurrencyVisualizerProfiler]
    [NativeMemoryProfiler]
    [ThreadingDiagnoser]
    [ExceptionDiagnoser]
    public class BenchmarkExecutor
    {
        [Benchmark]
        public async ValueTask ExecuteAsync() 
        {

            StoreDataGenerator generator = new StoreDataGenerator();

            var sells = generator.GenerateMillionSells(StoreDataGenerator.GenerateStores(), StoreDataGenerator.GenerateLocations());

            await File.WriteAllLinesAsync("sells.csv", sells.Select(sell => sell.ToString()), System.Text.Encoding.UTF8);

        }
    }
}
