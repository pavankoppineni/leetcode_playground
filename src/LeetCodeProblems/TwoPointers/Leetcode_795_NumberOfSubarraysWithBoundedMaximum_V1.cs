using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeProblems.TwoPointers
{
    /// <summary>
    /// https://leetcode.com/problems/number-of-subarrays-with-bounded-maximum/description/?envType=problem-list-v2&envId=two-pointers
    /// </summary>
    public class Leetcode_795_NumberOfSubarraysWithBoundedMaximum_V1
    {
        public int Calculate(int[] nums, int left, int right)
        {
            var count = 0;
            var leftIndex = -1;
            var leftMaxIndex = -1;
            for (var index = 0; index < nums.Length; index++)
            {
                var value = nums[index];

                // When : value is less than left
                if (value < left)
                {
                    if (leftIndex == -1)
                    {
                        leftIndex = index;
                        continue;
                    }

                    if (leftMaxIndex == -1)
                    {
                        continue;
                    }

                    count += leftMaxIndex - leftIndex + 1;
                    continue;
                }

                if (value > right)
                {
                    leftIndex = -1;
                    leftMaxIndex = -1;
                    continue;
                }

                if (leftIndex == -1)
                {
                    leftIndex = index;
                    leftMaxIndex = index;
                    count += 1;
                    continue;
                }

                count += index - leftIndex + 1;
                leftMaxIndex = index;
            }

            return count;
        }
    }
}
