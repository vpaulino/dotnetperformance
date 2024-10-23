using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformantFileReader
{
    public class ChatGptSpanReader
    {

        private readonly string _filePath;
        private readonly char _separator;

        public ChatGptSpanReader(string filePath, char separator = ';')
        {
            _filePath = filePath;
            _separator = separator;
        }


        public IEnumerable<string[]> ReadCsv()
        {
            var lines = new List<string[]>();

            using (var reader = new StreamReader(_filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    // Use Span<char> to avoid allocating unnecessary arrays and strings
                    ReadOnlySpan<char> lineSpan = line.AsSpan();

                    // Split the line using the separator
                    var values = SplitLine(lineSpan, _separator);

                    lines.Add(values);
                }
            }

            return lines;
        }

        // Helper method to split the line using Span<T>
        private string[] SplitLine(ReadOnlySpan<char> line, char separator)
        {
            var result = new List<string>();

            int start = 0;
            int length = line.Length;

            for (int i = 0; i < length; i++)
            {
                if (line[i] == separator)
                {
                    // Add the slice between the start and the current index (i)
                    result.Add(line.Slice(start, i - start).ToString());
                    start = i + 1; // Move start past the separator
                }
            }

            // Add the last value after the last separator
            result.Add(line.Slice(start).ToString());

            return result.ToArray();
        }
    }
}
