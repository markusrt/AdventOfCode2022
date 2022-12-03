using AdventOfCode2022;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;

namespace AdventOfCode2022Tests
{
    public class ItemUtilsTest
    {
        [TestCase('a', 1)]
        [TestCase('b', 2)]
        [TestCase('z', 26)]
        [TestCase('A', 27)]
        [TestCase('B', 28)]
        [TestCase('Z', 52)]
        public void GivenItem_HasCorrectPriority(char item, int expectedPriority)
        {
            ItemUtils.ItemPriority(item).Should().Be(expectedPriority);
        }
    }
}
