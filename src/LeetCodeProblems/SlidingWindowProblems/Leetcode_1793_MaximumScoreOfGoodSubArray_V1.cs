using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeProblems.SlidingWindowProblems
{
    /// <summary>
    /// https://leetcode.com/problems/maximum-score-of-a-good-subarray/description/
    /// </summary>
    public class Leetcode_1793_MaximumScoreOfGoodSubArray_V1
    {
        public int Calculate(int[] values, int k)
        {
            var stack = new Stack<int>();
            var itemsLookup = new Dictionary<int, Item1793>();
            var index = 0;
            while (index < values.Length)
            {
                var value = values[index];

                // When : stack is empty
                // Then : Add value to stack
                if (stack.Count == 0)
                {
                    index++;
                    continue;
                }

                var peekIndex = stack.Peek();
                var peekValue = values[peekIndex];

                // When : peekValue is less or equal to value
                // Then : Pop value from stack
                if (value <= peekValue)
                {
                    stack.Pop();
                    if (itemsLookup.ContainsKey(peekIndex))
                    {

                    }
                    continue;
                }
            }
            return 1;
        }
    }

    public class Item1793
    {
        public int Left { get; set; }
        public int Right { get; set; }
    }
}
