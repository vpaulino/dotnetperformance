using PerformancePatterns.StackBased.Stackallocs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformancePatterns.StackBased.Classic
{
    public class StoreRevenuePerProductStructOptimizedRepository
    {
        List<StoreReveneuePerProduct> productRevenues = new List<StoreReveneuePerProduct>();

        public StoreRevenuePerProductStructOptimizedRepository()
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

        public void UpdateSellsScorings()
        {
            foreach (var revenue in productRevenues)
                revenue.UpdateScore();
        }

        private decimal CalculateStoreScoreMean(int storeId)
        {
            decimal scoreSum = 0;
            int count = 0;

            for (int index = 0; index < productRevenues.Count; ++index)
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

        private decimal CalculateStoreScoreMeanWithLinq(int storeId)
        {
            decimal scoreSum = 0;
            int count = 0;

            var allStoreSells = productRevenues.Where((store) => store.StoreId == storeId);
            
            foreach (var revenue in allStoreSells)
            {
                scoreSum += revenue.Score;
                count++;
            }

            return count > 0 ? scoreSum / count : 0;
        }

        public void UpdateStoreScoringsWithHeap()
        {
            var storeScores = new List<StoreScoreClass>();

            for (int i = 0; i <= 99; i++)
            {
                var storeScore = new StoreScoreClass(i + 1, 0);
                storeScore.Score = CalculateStoreScoreMean(i);

                storeScores.Add(storeScore);
            }

        }

        public void UpdateStoreScoringsWithHeapAndLinq()
        {
            var storeScores = new List<StoreScoreClass>();

            for (int i = 0; i <= 99; i++)
            {
                var storeScore = new StoreScoreClass(i + 1, 0);
                storeScore.Score = CalculateStoreScoreMeanWithLinq(i);

                storeScores.Add(storeScore);
            }

        }
    }
}
