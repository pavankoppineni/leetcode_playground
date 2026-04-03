using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeProblems.TwoPointers
{
    /// <summary>
    /// https://leetcode.com/problems/partition-labels/description/?envType=problem-list-v2&envId=two-pointers
    /// </summary>
    public class Leetcode_763_PartitionLabels_V1
    {
        public IList<int> CalculatePartitions(string str)
        {
            var result = new List<int>();
            var lookup = ConstructLookup(str);
            var pair = lookup[str[0]];
            var start = pair.Start;
            var end = pair.End;
            for (var index = 1; index < str.Length; index++)
            {
                var currentChat = str[index];
                var currentPair = lookup[currentChat];

                // When : current char start is greater than end
                if (currentPair.Start > end)
                {
                    result.Add(end - start + 1);
                    start = currentPair.Start;
                    end = currentPair.End;
                    continue;
                }

                // When : current char end is greater than end
                if (currentPair.End > end)
                {
                    end = currentPair.End;
                    continue;
                }
            }

            result.Add(end - start + 1);
            return result;
        }

        private IDictionary<int, Pair763> ConstructLookup(string str)
        {
            var lookup = new Dictionary<int, Pair763>();
            for (int i = 0; i < str.Length; i++)
            {
                if (lookup.ContainsKey(str[i]))
                {
                    lookup[str[i]].End = i;
                    continue;
                }
                lookup[str[i]] = new Pair763 { Start = i, End = i };
            }

            return lookup;
        }
    }

    public class Pair763
    {
        public int Start { get; set; }
        public int End { get; set; }
    }
}
