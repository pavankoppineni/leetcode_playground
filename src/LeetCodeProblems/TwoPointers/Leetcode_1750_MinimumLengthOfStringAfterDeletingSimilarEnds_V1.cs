using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeProblems.TwoPointers
{
    /// <summary>
    /// https://leetcode.com/problems/minimum-length-of-string-after-deleting-similar-ends/description/?envType=problem-list-v2&envId=two-pointers
    /// </summary>
    public class Leetcode_1750_MinimumLengthOfStringAfterDeletingSimilarEnds_V1
    {
        public int CalculateMinLength(string str)
        {
            var leftIndex = 0;
            var rightIndex = str.Length - 1;
            while (true)
            {
                if (leftIndex == rightIndex)
                {
                    return 1;
                }

                if (leftIndex > rightIndex || leftIndex >= str.Length || rightIndex < 0)
                {
                    return 0;
                }

                // Base Case : leftIndex crossed rightIndex
                if (str[leftIndex] != str[rightIndex])
                {
                    break;
                }

                var currentChar = str[leftIndex];
                while (rightIndex >= leftIndex)
                {
                    if (currentChar != str[rightIndex])
                    {
                        break;
                    }
                    rightIndex--;
                }

                while(leftIndex <= rightIndex)
                {
                    if (currentChar != str[leftIndex])
                    {
                        break;
                    }
                    leftIndex++;
                }
            }

            return rightIndex - leftIndex + 1;
        }
    }
}
