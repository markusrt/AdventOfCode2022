using AdventOfCode2022;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;

namespace AdventOfCode2022Tests
{
    public class CalorieCalculatorTest
    {
        [Test]
        public void EmptyList_ReturnsZeroMaxCalories()
        {
            var dataProvider = Substitute.For<IDataProvider>();
            dataProvider.LoadData().Returns(new List<string>());
            var sut = CreateCalorieCalculator(dataProvider);

            sut.GetSumOfMaxCalories().Should().Be(0);
        }

        [Test]
        public void SimpleList_ReturnsSumOfCalories()
        {
            var dataProvider = Substitute.For<IDataProvider>();
            dataProvider.LoadData().Returns(new List<string>()
            {
                "100", "200", "300"
            });
            var sut = CreateCalorieCalculator(dataProvider);

            sut.GetSumOfMaxCalories().Should().Be(600);
        }

        [TestCase(1, 6000)]
        [TestCase(2, 6600)]
        [TestCase(3, 6660)]
        public void MultiEntryList_ReturnsBiggestSumOfCalories(int numberOfTopCalories, int expectedSum)
        {
            var dataProvider = Substitute.For<IDataProvider>();
            dataProvider.LoadData().Returns(new List<string>()
            {
                "10", "20", "30", "", "1", "2", "", "1000",
                "2000", "3000", "", "100", "200", "300"
            });
            var sut = CreateCalorieCalculator(dataProvider);

            sut.GetSumOfMaxCalories(numberOfTopCalories).Should().Be(expectedSum);
        }

        
        [TestCase(1, 64929)]
        [TestCase(3, 193697)]
        public void ExcerciseList_ReturnsCorrectAnswer(int numberOfTopCalories, int expectedSum)
        {
            var sut = CreateCalorieCalculator(new ResourceDataProvider("AdventOfCode2022Tests.Data.Day1Exercise1.txt"));

            sut.GetSumOfMaxCalories(numberOfTopCalories).Should().Be(expectedSum);
        }

        private CalorieCalculator CreateCalorieCalculator(IDataProvider dataProvider)
        {
            return new CalorieCalculator(dataProvider);
        }
    }
}
