using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022
{
    public static class ItemUtils
    {
        public static int ItemPriority(char item)
        {
            var prioOffset = Char.IsUpper(item) ? 38 : 96;
            return (int)item - prioOffset;
        }
    }
}
