// See https://aka.ms/new-console-template for more information
using BlackFridayProductsFileGenerator;
//using BenchmarkDotNet.Attributes;
//using BenchmarkDotNet.Running;
//using BenchmarkDotNet.Configs;
//using BenchmarkDotNet.Diagnosers;
//using BenchmarkDotNet.Jobs;

//using BenchmarkDotNet.Attributes;
//using BenchmarkDotNet.Configs;
//using BenchmarkDotNet.Diagnosers;
//using BenchmarkDotNet.Running;

Console.WriteLine("Hello, World!");


StoreDataGenerator generator = new StoreDataGenerator();

var sells = generator.GenerateMillionSells(StoreDataGenerator.GenerateStores(), StoreDataGenerator.GenerateLocations());

await File.WriteAllLinesAsync("sells.csv", sells.Select(sell => sell.ToString()), System.Text.Encoding.UTF8);


//var summary = BenchmarkRunner.Run<BenchmarkExecutor>();

