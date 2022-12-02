using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AdventOfCode2022.RockPaperScissors;

namespace AdventOfCode2022
{
    public class TheAssumedStrategy : IRockPaperScissorStrategy
    {
        public Result GetHisResult(string gameResultEntry)
        {
            return CodeMap[gameResultEntry.First()];
        }

        public Result GetMyResult(string gameResultEntry)
        {
            return CodeMap[gameResultEntry.Last()];
        }
    }
}
