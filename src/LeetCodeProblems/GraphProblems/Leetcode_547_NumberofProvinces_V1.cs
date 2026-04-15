using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeProblems.GraphProblems
{
    /// <summary>
    /// https://leetcode.com/problems/number-of-provinces/description/?envType=problem-list-v2&envId=graph
    /// </summary>
    public class Leetcode_547_NumberofProvinces_V1
    {
        public int CalculateNumberOfProvinces(int[][] isConnected)
        {
            var numberOfProvinces = 0;
            var visited = new HashSet<int>();
            var numberOfCities = isConnected.Length;
            for (var index = 0; index < numberOfCities; index++)
            {
                if (visited.Contains(index))
                {
                    continue;
                }

                numberOfProvinces += 1;
                DFS(visited, index, isConnected);
            }

            return numberOfProvinces;
        }

        private void DFS(HashSet<int> visited, int city, int[][] m)
        {
            visited.Add(city);
            for (var index = 0; index < m.Length; index++)
            {
                if (visited.Contains(index) || m[city][index] == 0)
                {
                    continue;
                }

                DFS(visited, index, m);
            }
        }
    }
}
