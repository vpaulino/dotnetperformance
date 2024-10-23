using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformancePatterns.ZeroCopy
{
    internal class ZeroCopyParser
    {
        public Sell ParseLine(Span<byte> line, char separator) 
        {
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
                if (separatorIndex == -1)
                {
                    price = line;
                }
                else 
                {
                    price = line.Slice(start, separatorIndex);
                }

            }
            else
            {
                price = line.Slice(start, separatorIndex);

            }

            return new Sell(DateTime.Parse(Encoding.UTF8.GetString(date)), Encoding.UTF8.GetString(country), Encoding.UTF8.GetString(city), Encoding.UTF8.GetString(storeName), Encoding.UTF8.GetString(productName), Decimal.Parse(price));
        } 
    }
}
