using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeProblems.DynamicProgramming
{
    /// <summary>
    /// https://leetcode.com/problems/domino-and-tromino-tiling/description/
    /// </summary>
    public class Leetcode_790_DominoTailing_V1
    {
        private IDictionary<int, int> _memo;
        private int _denominator = 1000000007;
        public int Calculate(int columns)
        {
            if (columns <= 2)
            {
                return columns;
            }

            _memo = new Dictionary<int, int>();
            var ways = CalculateInternal(columns);
            return (int)(ways % _denominator);
        }

        private long CalculateInternal(int columns)
        {
            if (_memo.ContainsKey(columns))
            {
                return _memo[columns];
            }

            if (columns < 0)
            {
                return 0;
            }

            if (columns == 0)
            {
                return 1;
            }

            long numberOfWays = 0;
            numberOfWays += CalculateInternal(columns - 1);
            numberOfWays += CalculateInternal(columns - 2);
            for (var index = 3; index <= columns; index++)
            {
                var remainingColumns = columns - index;
                if (remainingColumns < 0)
                {
                    break;
                }

                numberOfWays += 2 * CalculateInternal(columns - index);
            }

            var result = numberOfWays % _denominator;
            _memo.Add(columns, (int)result);
            return numberOfWays;
        }
    }
}
