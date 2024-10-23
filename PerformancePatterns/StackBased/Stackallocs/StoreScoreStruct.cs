using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PerformancePatterns.StackBased.Stackallocs
{
    [StructLayout(LayoutKind.Sequential)]
    public struct StoreScoreStruct
    {
        public int StoreId;
        public decimal Score;

        public StoreScoreStruct(int storeId, decimal score)
        {
            StoreId = storeId;
            Score = score;
        }
    } 

}
