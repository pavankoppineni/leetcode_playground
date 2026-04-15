using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeProblems.GraphProblems
{
    /// <summary>
    /// https://leetcode.com/problems/network-delay-time/description/?envType=problem-list-v2&envId=graph
    /// </summary>
    public class Leetcode_743_NetworkDelayTime_V1
    {
        public class GraphNode
        {
            public int Node { get; set; }
            public int Time { get; set; }
        }

        public int CalculateNetworkDelayTime(int[][] times, int n, int k)
        {
            var minTime = GetMinTime(n, k);
            var graph = BuildGraph(times);
            return CalculateNetworkDelayTimeInternal(graph, minTime, k);
        }

        private int CalculateNetworkDelayTimeInternal(IDictionary<int, IList<GraphNode>> graph, int[] minTime, int startNode)
        {
            var visited = new HashSet<int>();
            var queue = new Queue<int>();
            queue.Enqueue(startNode);
            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                visited.Add(node);
                var edges = graph.ContainsKey(node) ? graph[node] : new List<GraphNode>();
                if (edges.Count == 0)
                {
                    continue;
                }

                foreach (var edge in edges)
                {
                    var edgeNode = edge.Node;
                    var networkTime = edge.Time + minTime[node - 1];
                    if (networkTime < minTime[edgeNode - 1])
                    {
                        minTime[edgeNode - 1] = networkTime;
                        queue.Enqueue(edgeNode);
                    }
                }
            }

            if (visited.Count != minTime.Length)
            {
                return -1;
            }

            return minTime.Max();
        }

        private IDictionary<int, IList<GraphNode>> BuildGraph(int[][] times)
        {
            var graph = new Dictionary<int, IList<GraphNode>>();
            for (var index = 0; index < times.Length; index++)
            {
                var time = times[index];
                var from = time[0];
                var to = time[1];
                if (!graph.ContainsKey(from))
                {
                    graph.Add(from, new List<GraphNode>());
                }
                graph[from].Add(new GraphNode { Node = to, Time = time[2] });
            }
            return graph;
        }

        private int[] GetMinTime(int n, int k)
        {
            var minTime = new int[n];
            for (int i = 0; i < n; i++)
            {
                minTime[i] = int.MaxValue;
            }
            minTime[k - 1] = 0;

            return minTime;
        }
    }
}
