using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeProblems.SlidingWindowProblems
{
    /// <summary>
    /// https://leetcode.com/problems/count-the-number-of-good-subarrays/description/?envType=problem-list-v2&envId=sliding-window
    /// </summary>
    public class Leetcode_2537_CountNumberOfGoodArrays_V1
    {
        public long Calculate(int[] values)
        {
            var binaryArray = new int[values.Length];
            var set = new HashSet<int>();
            for(var index = 0; index < values.Length; index++)
            {
                var value = values[index];

                // When : value is already present in the set
                // Then : remove value from set
                if(set.Contains(value))
                {
                    set.Remove(value);
                }
                else
                {
                    set.Add(value);
                }

                // When : value is not present in the set
                // Then : add to set
            }
            return 0;
        }
    }
}
