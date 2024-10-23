using Dia2Lib;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformantFileReader
{
    public class StreamSpanReader
    {

        private readonly string _filePath;
        private readonly char _separator;

        public StreamSpanReader(string filePath, char separator = ';')
        {
            _filePath = filePath;
            _separator = separator;
        }


        public IEnumerable<string[]> ReadCsv()
        {
            var lines = new List<string[]>();
            int offset = 0;
            var buffer = new byte[1024];
            using (var stream = File.OpenRead(_filePath))
            {
                int bytesRead;
                while ((bytesRead = stream.Read(buffer.AsSpan(offset))) > 0)
                {
                    var span = buffer.AsSpan(0, bytesRead + offset);

                    while (span.Length > 0)
                    {
                        var eol = span.IndexOf((byte)'\n');
                        if (eol < 0) break;

                        var line = span.Slice(0, eol);
                     
                       _ = SplitLine(line, ';');
                        span = span.Slice(eol + 1);
                    }

                    span.CopyTo(buffer);
                    offset = span.Length;
                }
            }

            return lines;
        }

        // Helper method to split the line using Span<T>
        private static SellRecord SplitLine(ReadOnlySpan<byte> line, char separator)
        {
            //// 2023-12-03T19:17:17;South Africa;Cape Town;NAPA Auto Parts;Coolant;24,99
            // Indices to hold start positions and lengths


          

            // Parse each part
            var originalLine = line;
            int start = 0;
            var separatorIndex = line.IndexOf((byte)separator);
            var date = line.Slice(start, separatorIndex);
           
            start = separatorIndex+1;
            line = line.Slice(start);
            start = 0;
            separatorIndex = line.IndexOf((byte)separator);
            var country = line.Slice(start, separatorIndex);

            start = separatorIndex+1;
            line = line.Slice(start);
            start = 0;
            separatorIndex = line.IndexOf((byte)separator);
            var city = line.Slice(start, separatorIndex);

            start = separatorIndex + 1;
            line = line.Slice(start);
            start = 0;
            separatorIndex = line.IndexOf((byte)separator);
            var storeName = line.Slice(start, separatorIndex);

            start = separatorIndex+1;
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
}
