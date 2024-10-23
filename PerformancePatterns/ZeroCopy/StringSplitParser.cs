using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformancePatterns.ZeroCopy
{
    public class StringSplitParser
    {
        public Sell ParseLine(string line)
        {
            var parts = line.Split(';');
            var date = DateTime.Parse(parts[0]);
            var country = parts[1];
            var city = parts[2];
            var store = parts[3];
            var product = parts[4];
            var price = decimal.Parse(parts[5]);

            return new Sell(date, country, city, store, product, price);
        }
    }
}
