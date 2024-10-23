using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerformancePatterns.StackBased.Classic
{
  


    public class StoreScoreClass
    {
        public int StoreId { get; set; }
        public decimal Score { get; set; }

        public StoreScoreClass(int storeId, int score)
        {
            StoreId = storeId;
            Score = score;
        }
    }




}
