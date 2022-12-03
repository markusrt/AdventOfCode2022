using AdventOfCode2022;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;

namespace AdventOfCode2022Tests
{
    public class ItemPrioritySummarizerTest
    {
        [Test]
        public void FirstPartExample_ReturnsCorrectPriority()
        {
            var dataProvider = Substitute.For<IDataProvider>();
            dataProvider.LoadData().Returns(new List<string>()
            {
                "vJrwpWtwJgWrhcsFMMfFFhFp",
                "jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL",
                "PmmdzqPrVvPwwTWBwg",
                "wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn",
                "ttgJtRGJQctTZtZT",
                "CrZsJsPPZsGzwwsLwLmpwMDw"
            });
            var sut = CreateItemPrioritySummarizer(dataProvider);

            sut.GetSumOfPriorities().Should().Be(157);
        }


        [Test]
        public void ExcerciseList_FirstPart_ReturnsCorrectPriority()
        {
            var sut = CreateItemPrioritySummarizer(new ResourceDataProvider("AdventOfCode2022Tests.Data.Day3.txt"));

            sut.GetSumOfPriorities().Should().Be(8202);
        }

        [Test]
        public void SecondPartExample_ReturnsCorrectPriority()
        {
            var dataProvider = Substitute.For<IDataProvider>();
            dataProvider.LoadData().Returns(new List<string>()
            {
                "vJrwpWtwJgWrhcsFMMfFFhFp",
                "jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL",
                "PmmdzqPrVvPwwTWBwg",
                "wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn",
                "ttgJtRGJQctTZtZT",
                "CrZsJsPPZsGzwwsLwLmpwMDw"
            });
            var sut = CreateItemPrioritySummarizer(dataProvider);

            sut.GetSumOfGroupBadgePriorities().Should().Be(70);
        }

        [Test]
        public void ExcerciseList_SecondPart_ReturnsCorrectPriority()
        {
            var sut = CreateItemPrioritySummarizer(new ResourceDataProvider("AdventOfCode2022Tests.Data.Day3.txt"));

            sut.GetSumOfGroupBadgePriorities().Should().Be(2864);
        }

        private ItemPrioritySummarizer CreateItemPrioritySummarizer(IDataProvider dataProvider)
        {
            return new ItemPrioritySummarizer(dataProvider);
        }
    }
}
