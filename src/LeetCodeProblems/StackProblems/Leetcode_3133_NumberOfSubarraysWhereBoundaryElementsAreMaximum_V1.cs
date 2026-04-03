using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeProblems.StackProblems
{
    /// <summary>
    /// https://leetcode.com/problems/find-the-number-of-subarrays-where-boundary-elements-are-maximum/description/
    /// </summary>
    public class Leetcode_3133_NumberOfSubarraysWhereBoundaryElementsAreMaximum_V1
    {
        public int Calculate(int[] values)
        {
            var count = 0;
            var stack = new Stack<StackItem>();
            for (var index = 0; index < values.Length; index++)
            {
                var value = values[index];
                while (true)
                {
                    if (stack.Count == 0)
                    {
                        var item = new StackItem
                        {
                            Value = value,
                            Count = 1
                        };
                        stack.Push(item);
                        break;
                    }

                    var topItem = stack.Peek();
                    if (value > topItem.Value)
                    {
                        stack.Pop();
                        continue;
                    }

                    if (value < topItem.Value)
                    {
                        var item = new StackItem
                        {
                            Value = value,
                            Count = 1
                        };
                        stack.Push(item);
                        break;
                    }

                    var newItem = new StackItem
                    {
                        Value = value,
                        Count = topItem.Count + 1   
                    };
                    stack.Pop();
                    stack.Push(newItem);
                    count += topItem.Count;
                    break;
                }
            }

            return count + values.Length;
        }
    }

    public class StackItem
    {
        public int Value { get; set; }
        public int Count { get; set; }
    }
}
