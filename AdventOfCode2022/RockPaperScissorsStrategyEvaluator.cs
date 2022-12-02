using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2022
{
    public class RockPaperScissorsStrategyEvaluator
    {
        private IDataProvider _dataProvider;

        public RockPaperScissorsStrategyEvaluator(IDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }

        public int GetStrategyScore()
        {
            return AllGameScores().OrderDescending().Sum();
        }

        public IEnumerable<int> AllGameScores() 
        {
            foreach (var gameResultEntry in _dataProvider.LoadData())
            {
                var score = 0;
                var hisResult = GetHisResult(gameResultEntry);
                var myResult = GetMyResult(gameResultEntry);

                var iWon = (myResult == Result.Rock && hisResult == Result.Scissors) 
                    || (myResult == Result.Paper && hisResult == Result.Rock)
                    || (myResult == Result.Scissors && hisResult == Result.Paper);
                var itWasADraw = myResult == hisResult;

                if (iWon)
                {
                    score += 6;
                }
                if (itWasADraw)
                {
                    score += 3;
                }

                score += (int) myResult;
                yield return score;
            }
        }

        private Result GetHisResult(string gameResultEntry)
        {
            var result = gameResultEntry.First();
            if (result == 'A')
            {
                return Result.Rock;
            }
            if (result == 'B')
            {
                return Result.Paper;
            }
            return Result.Scissors;
        }

        private Result GetMyResult(string gameResultEntry)
        {
            var result = gameResultEntry.Last();
            if (result == 'X')
            {
                return Result.Rock;
            }
            if (result == 'Y')
            {
                return Result.Paper;
            }
            return Result.Scissors;
        }
    }

    enum Result
    {
        Rock = 1, Paper = 2, Scissors = 3
    }
}
