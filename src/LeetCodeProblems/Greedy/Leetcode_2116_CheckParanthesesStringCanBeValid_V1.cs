using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeProblems.Greedy
{
    /// <summary>
    /// https://leetcode.com/problems/check-if-a-parentheses-string-can-be-valid
    /// </summary>
    public class Leetcode_2116_CheckParanthesesStringCanBeValid_V1
    {
        public bool CanBeValid(string str, string locked)
        {
            if (str.Length % 2 != 0)
            {
                return false;
            }

            var stack = new Stack<StackItem>();
            var index = 0;
            while (index < str.Length)
            {
                var paranthesesChar = str[index];
                var lockedChar = locked[index];
                if (lockedChar == '1')
                {
                    if (paranthesesChar == '(')
                    {
                        stack.Push(new StackItem { Char = paranthesesChar, IsLocked = true });
                        index++;
                        continue;
                    }

                    if (stack.Count == 0)
                    {
                        return false;
                    }

                    stack.Pop();
                    index++;
                    continue;
                }

                stack.Push(new StackItem { Char = paranthesesChar, IsLocked = false });
                index++;
            }

            if (stack.Count == 0)
            {
                return true;
            }

            var newStack = new Stack<StackItem>();
            while (stack.Count > 0)
            {
                var stackItem = stack.Pop();
                if (newStack.Count == 0)
                {
                    newStack.Push(stackItem);
                    continue;
                }

                if (stackItem.IsLocked)
                {
                    if (newStack.Count == 0)
                    {
                        return false;
                    }

                    var top = newStack.Pop();
                    if(top.IsLocked)
                    {
                        return false;
                    }

                    continue;
                }

                newStack.Push(stackItem);
            }

            return newStack.Count % 2 == 0;
        }
    }

    public class StackItem
    {
        public char Char { get; set; }
        public bool IsLocked { get; set; }
    }
}
