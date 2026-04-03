using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeProblems.TwoPointers
{
    /// <summary>
    /// https://leetcode.com/problems/longest-mountain-in-array/?envType=problem-list-v2&envId=dynamic-programming
    /// </summary>
    public class Leetcode_845_LongestMountainArray_V1
    {
        public int Calculate(int[] values)
        {
            var valuesItems = CalculateLeft(values);
            var rightValues = CalculateRight(values, valuesItems);
            var max = int.MinValue;
            for (var index = 0; index < rightValues.Length; index++)
            {
                if (rightValues[index].Left == 0 || rightValues[index].Right == 0)
                {
                    continue;
                }

                var sum = rightValues[index].Left + rightValues[index].Right;
                max = Math.Max(max, sum);
            }

            if(max == 0)
            {
                return 0;
            }

            return max + 1;
        }

        public ValueItem[] CalculateLeft(int[] values)
        {
            var valueItems = new ValueItem[values.Length];
            valueItems[0] = new ValueItem
            {
                Value = values[0],
                Left = 0
            };
            for (var index = 1; index < values.Length; index++)
            {
                var previousValue = values[index - 1];
                var currentValue = values[index];
                valueItems[index] = new ValueItem
                {
                    Value = currentValue,
                };

                // when : current value is equal to previous
                if (currentValue <= previousValue)
                {
                    valueItems[index].Left = 0;
                    continue;
                }

                // when : current value is greater than previous
                if (currentValue > previousValue)
                {
                    valueItems[index].Left = valueItems[index - 1].Left + 1;
                    continue;
                }
            }

            return valueItems;
        }

        public ValueItem[] CalculateRight(int[] values, ValueItem[] valueItems)
        {
            valueItems[values.Length - 1].Right = 0;
            for (var index = values.Length - 2; index >= 0; index--)
            {
                var previousValue = values[index + 1];
                var currentValue = values[index];

                // when : current value is equal to previous
                if (currentValue <= previousValue)
                {
                    valueItems[index].Right = 0;
                    continue;
                }

                // when : current value is greater than previous
                if (currentValue > previousValue)
                {
                    valueItems[index].Right = valueItems[index + 1].Right + 1;
                    continue;
                }
            }

            return valueItems;
        }
    }

    public class ValueItem
    {
        public int Value { get; set; }
        public int Left { get; set; }
        public int Right { get; set; }
    }
}
