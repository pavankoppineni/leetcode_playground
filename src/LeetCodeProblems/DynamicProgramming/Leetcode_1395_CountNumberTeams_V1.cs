using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeProblems.DynamicProgramming
{
    /// <summary>
    /// https://leetcode.com/problems/count-number-of-teams/description/?envType=problem-list-v2&envId=dynamic-programming
    /// </summary>
    public class Leetcode_1395_CountNumberTeams_V1
    {
        private int[] _ratings;
        private int[] _values = new int[3];
        public int CalculateNumberOfTeams(int[] ratings)
        {
            _ratings = ratings;
            var increasingways = CalculateNumberOfTeams(0, ratings.Length - 1, 0, -1, (prev, current) => prev >= current);
            var decreasingways = CalculateNumberOfTeams(0, ratings.Length - 1, 0, int.MaxValue, (prev, current) => prev <= current);
            return increasingways + decreasingways;
        }

        private int CalculateNumberOfTeams(int start, int end, int level, int previous, Func<int, int, bool> func)
        {
            if (level >= 3)
            {
                return 1;
            }

            if (start > end)
            {
                return 0;
            }

            var numberOfWays = 0;
            for (var index = start; index <= end; index++)
            {
                var value = _ratings[index];
                if (func(previous, value))
                {
                    continue;
                }

                _values[level] = value;
                numberOfWays += CalculateNumberOfTeams(index + 1, end, level + 1, value, func);
            }

            return numberOfWays;
        }
    }
}
