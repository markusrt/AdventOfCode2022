using AdventOfCode2022;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;

namespace AdventOfCode2022Tests
{
    public class RockPaperScissorsStrategyEvaluatorTest
    {
        [Test]
        public void EmptyList_ReturnsZeroScore()
        {
            var dataProvider = Substitute.For<IDataProvider>();
            dataProvider.LoadData().Returns(new List<string>());
            var sut = CreateCalorieCalculator(dataProvider);

            sut.GetStrategyScore().Should().Be(0);
        }

        [Test]
        public void ExampleStrategy_ReturnsCorrectScore()
        {
            var dataProvider = Substitute.For<IDataProvider>();
            dataProvider.LoadData().Returns(new List<string>()
            {
                "A Y", "B X", "C Z"
            });
            var sut = CreateCalorieCalculator(dataProvider);

            sut.GetStrategyScore().Should().Be(15);
        }


        [Test]
        public void ExcerciseList_AssumedStrategy_ReturnsCorrectScore()
        {
            var sut = CreateCalorieCalculator(new ResourceDataProvider("AdventOfCode2022Tests.Data.Day2Exercise1.txt"));

            sut.GetStrategyScore().Should().Be(14827);
        }

          [Test]
        public void ExcerciseList_RealStrategy_ReturnsCorrectScore()
        {
            var sut = new RockPaperScissorsStrategyEvaluator(
                new ResourceDataProvider("AdventOfCode2022Tests.Data.Day2Exercise1.txt"),
                new TheRealStrategy());

            sut.GetStrategyScore().Should().Be(13889);
        }

        private RockPaperScissorsStrategyEvaluator CreateCalorieCalculator(IDataProvider dataProvider)
        {
            return new RockPaperScissorsStrategyEvaluator(dataProvider, new TheAssumedStrategy());
        }
    }
}
