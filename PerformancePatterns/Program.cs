using BenchmarkDotNet.Running;
using PerformancePatterns.BufferedBuilder;
using PerformancePatterns.StackBased;
using PerformancePatterns.StructArrays;
using PerformancePatterns.StructArrays.NoStructs;
using PerformancePatterns.ZeroCopy;
using System.Text;


Console.WriteLine("Benchmark running");

//string stringToParse = "2023-12-03T19:17:17;South Africa;Cape Town;NAPA Auto Parts;Coolant;24,99";
//var tobeparsed = Encoding.UTF8.GetBytes(stringToParse);
//var parser = new ZeroCopyParser();
//parser.ParseLine(tobeparsed, ';');

//NoStructsStoreRevenuePerProductRepository repository = new NoStructsStoreRevenuePerProductRepository();

//try
//{

//    repository.UpdateScorings();
//}
//catch (Exception)
//{

//	throw;
//}

var summary = BenchmarkRunner.Run<BenchmarkBufferedStrings>();
Console.WriteLine("Benchmark finished");

Console.ReadLine();