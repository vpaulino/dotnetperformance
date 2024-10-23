// See https://aka.ms/new-console-template for more information
using BenchmarkDotNet.Running;
using PerformantFileReader;

//Console.WriteLine("Press any key to start!");

//Console.ReadLine();

//Console.WriteLine("Processing file.... ");

//var summary = BenchmarkRunner.Run<BenchmarkExecutor>();

Console.WriteLine("Process started... ");

var pipelineSpanOrchestrator = new PipelineSpanOrchestrator("smallSells.csv");

await pipelineSpanOrchestrator.IngestFileAsync(CancellationToken.None);


Console.WriteLine("Process completed");
//var _csvReader = new AllInMemoryReader("sells.csv");
//var result = await _csvReader.ReadCsv();

//Console.WriteLine($"records count : {result.Count()}");

//Console.ReadLine();