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
        public void ExampleStrategy_ReturnsPriority()
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

        //   [Test]
        // public void ExcerciseList_RealStrategy_ReturnsCorrectScore()
        // {
        //     var sut = new RockPaperScissorsStrategyEvaluator(
        //         new ResourceDataProvider("AdventOfCode2022Tests.Data.Day2Exercise1.txt"),
        //         new TheRealStrategy());

        //     sut.GetStrategyScore().Should().Be(13889);
        // }

        private ItemPrioritySummarizer CreateItemPrioritySummarizer(IDataProvider dataProvider)
        {
            return new ItemPrioritySummarizer(dataProvider);
        }
    }
}
