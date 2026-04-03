using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeProblems.DynamicProgramming.Leetcode_322_CoinChange
{
    /// <summary>
    /// https://leetcode.com/problems/coin-change/
    /// </summary>
    public class Leetcode_322_CoinChange_V1
    {
        private IDictionary<int, int> _inmemory = new Dictionary<int, int>();
        private int[] _coins;
        public int MinCount(int[] coins, int amount)
        {
            if (amount == 0)
            {
                return 0;
            }

            Array.Sort(coins);
            if (coins[0] > amount)
            {
                return -1;
            }

            _coins = coins;
            var minCount = MinCount(amount);
            if (minCount == int.MaxValue || minCount == -1)
            {
                return -1;
            }

            return minCount;
        }

        private int MinCount(int amount)
        {
            if (amount == 0)
            {
                return 0;
            }

            if (_inmemory.ContainsKey(amount))
            {
                return _inmemory[amount];
            }

            var currentMin = int.MaxValue;
            for (var index = 0; index < _coins.Length; index++)
            {
                var coin = _coins[index];
                if (coin > amount)
                {
                    continue;
                }

                if (amount - coin < 0)
                {
                    continue;
                }

                var minCount = MinCount(amount - coin);
                if (minCount == -1)
                {
                    continue;
                }

                currentMin = Math.Min(minCount + 1, currentMin);
            }

            if (currentMin == int.MaxValue)
            {
                _inmemory.Add(amount, -1);
                return -1;
            }

            _inmemory.Add(amount, currentMin);
            return currentMin;
        }
    }
}
