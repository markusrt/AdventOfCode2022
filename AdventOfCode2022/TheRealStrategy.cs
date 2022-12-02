using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AdventOfCode2022.RockPaperScissors;

namespace AdventOfCode2022
{
    public class TheRealStrategy : IRockPaperScissorStrategy
    {
        private const char NeedToLoose ='X';
        private const char NeedToWin ='Z';

        public Result GetHisResult(string gameResultEntry)
        {
            return CodeMap[gameResultEntry.First()];
        }

        public Result GetMyResult(string gameResultEntry)
        {
            var hisResult = GetHisResult(gameResultEntry);
            var requiredOutcome = gameResultEntry.Last();
            if (requiredOutcome == NeedToLoose)
            {
                return LooseMap[hisResult];
            }
            if (requiredOutcome == NeedToWin)
            {
                return WinMap[hisResult];
            }
            return hisResult;
        }
    }
}
