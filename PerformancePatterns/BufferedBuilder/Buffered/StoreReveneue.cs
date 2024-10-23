using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformancePatterns.BufferedBuilder.Buffered
{
    public class StoreReveneuePerProduct
    {
        public int StoreId { get; set; }

        public int ProductId { get; set; }

        public decimal Total { get; set; }

        public int NumberOfDays { get; set; }

        public int NumberOfProductsSold { get; set; }

        public decimal ProductPrice { get; set; }

        public int Score { get; set; }


        public void UpdateScore()
        {
            // Ensure no division by zero
            if (NumberOfProductsSold == 0 || NumberOfDays == 0)
            {
                Score = 0;
                return;
            }

            // Profit per product (this could be an indicator of profitability)
            decimal profitPerProduct = Total / NumberOfProductsSold;

            // Revenue per day: this shows how intense the sales period is
            decimal revenuePerDay = Total / NumberOfDays;

            // Volume impact: how much impact the number of sold products has
            decimal salesVolumeImpact = NumberOfProductsSold * 0.5m;

            // Sales intensity: give more weight to products that sold fast
            decimal salesIntensityFactor = (decimal)NumberOfProductsSold / NumberOfDays;

            // Price influence: higher price products might contribute more to a good score
            decimal priceImpact = ProductPrice * 0.2m;

            // Calculate the score
            Score = (int)(profitPerProduct + revenuePerDay + salesVolumeImpact + salesIntensityFactor + priceImpact);
        }


        public override string ToString()
        {
            return $"<StoreReveneuePerProduct><{nameof(StoreId)}>{StoreId}</{nameof(StoreId)}><{nameof(ProductId)}>{ProductId}</{nameof(ProductId)}><{nameof(Total)}>{Total}</{nameof(Total)}><{nameof(NumberOfDays)}>{NumberOfDays}</{nameof(NumberOfDays)}></StoreReveneuePerProduct>";
        }


    }
}
