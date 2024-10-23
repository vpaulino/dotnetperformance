using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PerformancePatterns.BufferedBuilder.Buffered
{
    public class BufferedBuilderStoreRevenuePerProductRepository
    {

        public BufferedBuilderStoreRevenuePerProductRepository()
        {
            Random rand = new Random();

            for (int i = 0; i < 1000; i++)
            {
                var storeId = rand.Next(1, 100); // Random store ID between 1 and 1000
                var productId = rand.Next(1, 1000); // Random product ID between 1 and 5000
                var productPrice = (decimal)(rand.NextDouble() * 100.0); // Random price between 0 and 100
                var numberOfProductsSold = rand.Next(1, 50); // Random number of products sold between 1 and 1000
                var numberOfDays = rand.Next(1, 30); // Random number of days between 1 and 30
                var totalRevenue = productPrice * numberOfProductsSold; // Total revenue = price * number of products sold

                // Create a new StoreRevenuePerProduct object and populate fields
                var revenueRecord = new StoreReveneuePerProduct
                {
                    StoreId = storeId,
                    ProductId = productId,
                    ProductPrice = productPrice,
                    NumberOfProductsSold = numberOfProductsSold,
                    NumberOfDays = numberOfDays,
                    Total = totalRevenue
                };
                  
                // Add the record to the list
                productRevenues.Add(revenueRecord);
            }
        }

        List<StoreReveneuePerProduct> productRevenues = new List<StoreReveneuePerProduct>();

        public string FormatAsXml() 
        {
            var xmlString = "<StoreReveneuesPerProducts>";

            DefaultInterpolatedStringHandler handler = new DefaultInterpolatedStringHandler();
            handler.AppendLiteral(xmlString);
            foreach (var item in productRevenues)
            {
                handler.AppendFormatted(item.ToString());
            }
            handler.AppendLiteral("</StoreReveneuesPerProducts>");
            

            return handler.ToStringAndClear();
        }
    }
}
