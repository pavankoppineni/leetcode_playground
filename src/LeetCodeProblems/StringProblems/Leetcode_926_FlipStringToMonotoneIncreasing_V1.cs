using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeProblems.StringProblems
{
    /// <summary>
    /// https://leetcode.com/problems/flip-string-to-monotone-increasing/
    /// </summary>
    public class Leetcode_926_FlipStringToMonotoneIncreasing_V1
    {
        public int CalculateMinimumFlips(string binaryString)
        {
            var minFlips = int.MaxValue;
            var totalSum = CalculateSum(binaryString);
            var leftSum = 0;
            for (var index = 0; index < binaryString.Length; index++)
            {
                var leftLength = index;
                var rightLength = binaryString.Length - index;
                var leftFlips = leftSum;
                var rightSum = totalSum - leftSum;
                var rightFlips = rightLength - rightSum;
                var currentFlips = leftFlips + rightFlips;
                minFlips = Math.Min(minFlips, currentFlips);
                if (binaryString[index] == '1')
                {
                    leftSum++;
                }
            }

            minFlips = Math.Min(minFlips, totalSum);
            return minFlips;
        }

        private int CalculateSum(string binaryString)
        {
            var sum = 0;
            for (var index = 0; index < binaryString.Length; index++)
            {
                if (binaryString[index] == '1')
                {
                    sum++;
                }
            }

            return sum;
        }
    }
}
