using System;
using System.Collections.Generic;
using System.Linq;
using static AdventOfCode2022.RockPaperScissors;

namespace AdventOfCode2022
{
    public class RockPaperScissorsStrategyEvaluator
    {
        private IDataProvider _dataProvider;
        private readonly IRockPaperScissorStrategy _strategy;

        public RockPaperScissorsStrategyEvaluator(IDataProvider dataProvider, IRockPaperScissorStrategy strategy)
        {
            _dataProvider = dataProvider;
            this._strategy = strategy;
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
                var hisResult = _strategy.GetHisResult(gameResultEntry);
                var myResult = _strategy.GetMyResult(gameResultEntry);

                var iWon = LooseMap[myResult] == hisResult;
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
    }
}
