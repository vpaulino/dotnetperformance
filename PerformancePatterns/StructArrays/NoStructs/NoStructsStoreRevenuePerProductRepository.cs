using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PerformancePatterns.StructArrays.NoStructs
{
    public struct NoStructsStoreRevenuePerProductRepository
    {
        public int[] StoreId { get; set; }

        public int[] ProductId { get; set; }

        public decimal[] Total { get; set; }

        public int[] NumberOfDays { get; set; }

        public int[] NumberOfProductsSold { get; set; }

        public decimal[] ProductPrice { get; set; }

        public int[] Score { get; set; }

        public NoStructsStoreRevenuePerProductRepository()
        {
            Random rand = new Random();

            int size = 1_000_000;

            // Initialize arrays with the given size
            StoreId = new int[size];
            ProductId = new int[size];
            Total = new decimal[size];
            NumberOfDays = new int[size];
            NumberOfProductsSold = new int[size];
            ProductPrice = new decimal[size];
            Score = new int[size];

            for (int i = 0; i < 1_000_000; i++)
            {
                StoreId[i] = rand.Next(1, 100); // Random store ID between 1 and 1000
                ProductId[i] = rand.Next(1, 1000); // Random product ID between 1 and 5000
                ProductPrice[i] = (decimal)(rand.NextDouble() * 100.0); // Random price between 0 and 100
                NumberOfProductsSold[i] = rand.Next(1, 100); // Random number of products sold between 1 and 1000
                NumberOfDays[i] = rand.Next(1, 30); // Random number of days between 1 and 30
                Total[i] = ProductPrice[i] * NumberOfProductsSold[i]; // Total revenue = price * number of products sold
            }
        }

        public void UpdateScorings()
        {
            for (int index = 0; index < Score.Length; index++) 
            {
                if (NumberOfProductsSold[index] == 0 || NumberOfDays[index] == 0)
                {
                    Score[index] = 0;
                    return;
                }

                decimal profitPerProduct = Total[index] / NumberOfProductsSold[index];
                decimal revenuePerDay = Total[index] / NumberOfDays[index];
                decimal salesVolumeImpact = NumberOfProductsSold[index] * 0.5m;
                decimal salesIntensityFactor = (decimal)NumberOfProductsSold[index] / NumberOfDays[index];
                decimal priceImpact = ProductPrice[index] * 0.2m;

                Score[index] = (int)(profitPerProduct + revenuePerDay + salesVolumeImpact + salesIntensityFactor + priceImpact);
            }
          
        }

    }
}
