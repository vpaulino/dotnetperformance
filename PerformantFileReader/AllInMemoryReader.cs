namespace PerformantFileReader
{
    internal class AllInMemoryReader
    {
        private string filepath;
        private char separator;
        public AllInMemoryReader(string filepath, char separator = ';')
        {
            this.filepath = filepath;
            this.separator = separator;
        }

        public async Task<List<SellClass>> ReadCsv() 
        {
            string[] allLines = await File.ReadAllLinesAsync(filepath);
            var linesProcessed = new List<SellClass>();
            foreach (var line in allLines)
            {
                var values = line.Split(separator);
                
                SellClass sell = new SellClass(DateTime.Parse(values[0]), values[1], values[2], values[3], values[4], Decimal.Parse(values[5]));
                
                linesProcessed.Add(sell);
            }

            return linesProcessed;


        }
    }
}