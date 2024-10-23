using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformancePatterns.StackBased.Stackallocs
{
    public class StoreRevenuePerProductStructStackAllocOptimizedRepository
    {
        StructStoreReveneuePerProduct[] productRevenues = new StructStoreReveneuePerProduct[1_000_000];

        public StoreRevenuePerProductStructStackAllocOptimizedRepository()
        {
          

            Random rand = new Random();

            for (int i = 0; i < 1_000_000; i++)
            {
                var storeId = rand.Next(1, 100); // Random store ID between 1 and 1000
                var productId = rand.Next(1, 1000); // Random product ID between 1 and 5000
                var productPrice = (decimal)(rand.NextDouble() * 100.0); // Random price between 0 and 100
                var numberOfProductsSold = rand.Next(1, 50); // Random number of products sold between 1 and 1000
                var numberOfDays = rand.Next(1, 30); // Random number of days between 1 and 30
                var totalRevenue = productPrice * numberOfProductsSold; // Total revenue = price * number of products sold

                // Create a new StoreRevenuePerProduct object and populate fields
                var revenueRecord = new StructStoreReveneuePerProduct
                {
                    StoreId = storeId,
                    ProductId = productId,
                    ProductPrice = productPrice,
                    NumberOfProductsSold = numberOfProductsSold,
                    NumberOfDays = numberOfDays,
                    Total = totalRevenue
                };

                // Add the record to the list
                productRevenues[i] = revenueRecord;
            }
        }

       
        public void UpdateSellsScorings()
        {
            for(int index = 0; index < productRevenues.Length; ++index)
                productRevenues[index].UpdateScore();
        }


        private decimal CalculateStoreScoreMean(int storeId)
        {
            decimal scoreSum = 0;
            int count = 0;

            for (int index = 0; index < productRevenues.Length; ++index) 
            {
                var revenue = productRevenues[index];
                if (revenue.StoreId == storeId)
                {
                    scoreSum += revenue.Score;
                    count++;
                }
            }


            return count > 0 ? scoreSum / count : 0;
        }

        public void UpdateStoreScorings()
        {
            Span<StoreScoreStruct> storeScores = stackalloc StoreScoreStruct[100];

            for (int i = 0; i <= 99; i++)
            {
                storeScores[i] = new StoreScoreStruct(i+1, 0);
                storeScores[i].Score = CalculateStoreScoreMean(i);
            }
        }

      
    }
}
