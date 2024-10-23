using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformantFileReader
{
    public class SimpleStreamReader
    {
        private readonly string _filePath;
        private readonly char _separator;

        public SimpleStreamReader(string filePath, char separator = ';')
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
                    // Split the line based on the separator
                    var values = line.Split(_separator);
                    lines.Add(values);
                }
            }

            return lines;
        }
    }
}
