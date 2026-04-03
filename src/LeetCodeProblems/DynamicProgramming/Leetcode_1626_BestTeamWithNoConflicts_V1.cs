using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeProblems.DynamicProgramming
{
    /// <summary>
    /// https://leetcode.com/problems/best-team-with-no-conflicts/description/?envType=problem-list-v2&envId=dynamic-programming
    /// </summary>
    public class Leetcode_1626_BestTeamWithNoConflicts_V1
    {
        private int _maxScore;
        private Player[] _players;
        public int Calculate(int[] scores, int[] ages)
        {
            var infi = new Player
            {
                Age = int.MaxValue,
                Score = int.MaxValue
            };
            _players = CreatePlayers(scores, ages);
            Calculate(0, 0, infi);
            return _maxScore;
        }

        private void Calculate(int index, int score, Player minScorePlayer)
        {
            if (index >= _players.Length)
            {
                if (score > _maxScore)
                {
                    _maxScore = score;
                }
                return;
            }

            var currentPlayer = _players[index];
            Calculate(index + 1, score, minScorePlayer);

            if (currentPlayer.Score > minScorePlayer.Score)
            {
                if (currentPlayer.Age < minScorePlayer.Age)
                {
                    return;
                }
            }

            var currentMinPlayer = currentPlayer.Score < minScorePlayer.Score ? currentPlayer : minScorePlayer;
            Calculate(index + 1, score + currentPlayer.Score, currentMinPlayer);
        }

        private Player[] CreatePlayers(int[] scores, int[] ages)
        {
            var players = new Player[scores.Length];
            for (int i = 0; i < scores.Length; i++)
            {
                players[i] = new Player
                {
                    Score = scores[i],
                    Age = ages[i]
                };
            }

            return players
                .OrderByDescending(player => player.Age)
                .ToArray();
        }
    }

    public class Player
    {
        public int Score { get; set; }
        public int Age { get; set; }
    }
}
