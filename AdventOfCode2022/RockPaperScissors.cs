using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    internal static class RockPaperScissors
    {
        internal static Dictionary<Result, Result> LooseMap = new Dictionary<Result, Result>()
        {
            {Result.Rock, Result.Scissors },
            {Result.Scissors, Result.Paper },
            {Result.Paper, Result.Rock }
        };

        internal static Dictionary<Result, Result> WinMap = new Dictionary<Result, Result>()
        {
            {Result.Scissors, Result.Rock },
            {Result.Paper, Result.Scissors },
            {Result.Rock, Result.Paper }
        };

        internal static Dictionary<char, Result> CodeMap = new Dictionary<char, Result>()
        {
            {'A', Result.Rock },
            {'B', Result.Paper },
            {'C', Result.Scissors },
            {'X', Result.Rock },
            {'Y', Result.Paper },
            {'Z', Result.Scissors }
        };
    }
}
