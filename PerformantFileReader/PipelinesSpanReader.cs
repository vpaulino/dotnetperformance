using BenchmarkDotNet.Engines;
using Dia2Lib;
using Microsoft.Diagnostics.Runtime.Utilities;
using System;
using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.IO.Pipelines;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformantFileReader
{

    public class PipelineSpanOrchestrator 
    {

        Pipe pipe;
        PipeReader pipereader;
        PipeWriter pipewriter;
        PipelinesSpanFileReader pipelineSpanReader;
        PipelineSpanWriterToDatabase pipelineSpanWriterToDatabase;
        public PipelineSpanOrchestrator(string filePath, char separator = ';')
        {
            var options = new PipeOptions(pauseWriterThreshold: 70, resumeWriterThreshold: 20);
            pipe = new Pipe();
            pipereader = pipe.Reader;
            pipewriter = pipe.Writer;
            pipelineSpanReader = new PipelinesSpanFileReader(pipewriter, filePath, separator);
            pipelineSpanWriterToDatabase = new PipelineSpanWriterToDatabase(pipereader);
        }


        public async Task IngestFileAsync(CancellationToken token) 
        {

            CancellationTokenSource source = new CancellationTokenSource();

            var taskProducer = Task.Run(() =>
            {
                try
                {
                    pipelineSpanReader.ReadCsv(source.Token);
                }
                catch (Exception)
                {
                    source.Cancel();
                    throw;
                }
                
                
            });

            await pipelineSpanWriterToDatabase.ConsumeFromPipe(source.Token);

          //  await Task.WhenAll(taskConsumer, taskProducer);

        }

    }

    public class PipelineSpanWriterToDatabase 
    {
        private PipeReader reader;
        public PipelineSpanWriterToDatabase(PipeReader reader)
        {
            this.reader = reader;
        }

        public async Task ConsumeFromPipe(CancellationToken token) 
        {
            
            while (!token.IsCancellationRequested) 
            {
              
                var result = await reader.ReadAsync(token);
                if (result.IsCanceled)
                {
                    Console.WriteLine("read result was canceled");
                    break;
                }

                var sequenceReader = new SequenceReader<byte>(result.Buffer);

                SequencePosition consumed = result.Buffer.Start;
                SequencePosition examined = result.Buffer.End;

                try
                {
                   
                    Console.WriteLine("Process New Record...");
                    _ = SplitLine(sequenceReader.CurrentSpan, ';');
                    Console.WriteLine("Record Processed!");


                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
                finally 
                {
                    reader.AdvanceTo(consumed, examined);
                }
               
            }

            await reader.CompleteAsync();

            
        }

        private static SellRecord SplitLine(ReadOnlySpan<byte> line, char separator)
        {
            //// 2023-12-03T19:17:17;South Africa;Cape Town;NAPA Auto Parts;Coolant;24,99
            // Indices to hold start positions and lengths




            // Parse each part
            var originalLine = line;
            int start = 0;
            var separatorIndex = line.IndexOf((byte)separator);
            var date = line.Slice(start, separatorIndex);

            start = separatorIndex + 1;
            line = line.Slice(start);
            start = 0;
            separatorIndex = line.IndexOf((byte)separator);
            var country = line.Slice(start, separatorIndex);

            start = separatorIndex + 1;
            line = line.Slice(start);
            start = 0;
            separatorIndex = line.IndexOf((byte)separator);
            var city = line.Slice(start, separatorIndex);

            start = separatorIndex + 1;
            line = line.Slice(start);
            start = 0;
            separatorIndex = line.IndexOf((byte)separator);
            var storeName = line.Slice(start, separatorIndex);

            start = separatorIndex + 1;
            line = line.Slice(start);
            start = 0;
            separatorIndex = line.IndexOf((byte)separator);
            var productName = line.Slice(start, separatorIndex);

            start = separatorIndex + 1;
            line = line.Slice(start);
            start = 0;
            separatorIndex = line.IndexOf((byte)separator);
            var price = ReadOnlySpan<byte>.Empty;
            if (separatorIndex == -1)
            {
                separatorIndex = line.IndexOf((byte)'\r');
                price = line.Slice(start, separatorIndex);

            }
            else
            {
                price = line.Slice(start, separatorIndex);

            }

            return new SellRecord(
            date,
                country,
                city,
                storeName,
                productName,
                price);


        }
         
    }

    /// <summary>
    /// Reads the file and writes the memory to the pipe
    /// </summary>
    public class PipelinesSpanFileReader
    {

        private readonly string _filePath;
        private readonly char _separator;
        private readonly PipeWriter writer;
        public PipelinesSpanFileReader(PipeWriter writer, string filePath, char separator = ';')
        {
            _filePath = filePath;
            _separator = separator;
            this.writer = writer;
        }


        public async Task ReadCsv(CancellationToken token)
        {
            var lines = new List<string[]>();
            int offset = 0;
            var buffer = new byte[1024];

            using (var stream = File.OpenRead(_filePath))
            {               
                int bytesRead;

                while ((bytesRead = stream.Read(buffer.AsSpan(offset))) > 0)
                {
                    var memoryRead = buffer.AsMemory(0, bytesRead + offset);

                    while (memoryRead.Length > 0)
                    {
                        var eol = memoryRead.Span.IndexOf((byte)'\n');
                        if (eol < 0) break;

                        var line = memoryRead.Slice(0, eol);
                        Console.WriteLine("Publish new line to pipe...");
                        await writer.WriteAsync(line);
                        
                        memoryRead = memoryRead.Slice(eol + 1);
                    }

                    memoryRead.CopyTo(buffer);
                    offset = memoryRead.Length;

                    if (token.IsCancellationRequested)
                        break;
                }
            }
            //this.writer.Complete();
            //return lines;
        }

        // Helper method to split the line using Span<T>
       
    }
}
