using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformantFileReader
{
    internal ref struct SellRecord(ReadOnlySpan<byte> Timestamp, ReadOnlySpan<byte> Country, ReadOnlySpan<byte> City, ReadOnlySpan<byte> Store, ReadOnlySpan<byte> Product, ReadOnlySpan<byte> Price);

    public class SellClass(DateTime timestamp, string country, string city, string store, string product, decimal price)
    {
        public DateTime Timestamp { get; init; } = timestamp;

        public string Country { get; init; } = country;

        public string City { get; init; } = city;

        public string Store { get; init; } = product;

        public string Product { get; init; } = product;

        public decimal Price { get; init; } = price;
    }         
    
}
