using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeProblems.TwoPointers
{
    /// <summary>
    /// https://leetcode.com/problems/minimum-operations-to-make-binary-palindrome/description/
    /// </summary>
    public class Leetcode_3766_MinimumOperationsToMakeBinaryPalindrome_V1
    {
        public int[] Calculate(int[] nums)
        {
            var resultArray = new int[nums.Length];
            for (var index = 0; index < nums.Length; index++)
            {
                if (nums[index] == 1)
                {
                    continue;
                }
                var msb = CalcualateMsbPosition(nums[index]);
                var operations = CalculateMinOperations(nums[index], msb);
                resultArray[index] = operations;
            }
            return resultArray;
        }

        private int CalculateMinOperations(int number, int msbPositon)
        {
            var resultNumber = number;
            var left = msbPositon - 1;
            var right = 0;
            while (left > right)
            {
                var leftBit = (number & (1 << left)) > 0 ? 1 : 0;
                var rightBit = (number & (1 << right)) > 0 ? 1 : 0;
                if (leftBit != rightBit)
                {
                    if (left - right == 1)
                    {
                        if (leftBit == 1)
                        {
                            resultNumber &= ~(1 << left);
                        }
                        else
                        {
                            resultNumber &= ~(1 << right);
                        }
                        break;
                    }

                    if (leftBit == 1)
                    {
                        resultNumber |= 1 << right;
                    }
                    else
                    {
                        resultNumber &= ~(1 << right);
                    }
                }

                left--;
                right++;
            }

            return Math.Abs(number - resultNumber);
        }

        private int CalcualateMsbPosition(int number)
        {
            var msbPosition = 0;
            while (true)
            {
                var currentNumber = 1 << msbPosition;
                if (currentNumber > number)
                {
                    break;
                }
                msbPosition++;
            }

            return msbPosition;
        }
    }
}
