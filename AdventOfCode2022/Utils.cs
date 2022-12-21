using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2022;

public static class Utils
{
    public static bool DetectOverlap(string twoSections)
    {
        var (numbers1, numbers2) = SplitRanges(twoSections);

        return numbers1.All(n => numbers2.Contains(n)) || numbers2.All(n => numbers1.Contains(n));
    }

    public static bool DetectIntersection(string twoSections)
    {
        var (numbers1, numbers2) = SplitRanges(twoSections);

        return numbers1.Intersect(numbers2).Any();
    }
    
    private static (IEnumerable<int> numbers1, IEnumerable<int> numbers2) SplitRanges(string twoSections)
    {
        var sections = twoSections.Split(",");
        var range1 = sections[0].Split("-");
        var range2 = sections[1].Split("-");
        var numbers1 = Enumerable.Range(int.Parse(range1[0]), int.Parse(range1[1]) - int.Parse(range1[0]) + 1);
        var numbers2 = Enumerable.Range(int.Parse(range2[0]), int.Parse(range2[1]) - int.Parse(range2[0]) + 1);
        return (numbers1, numbers2);
    }
}