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

            sut.GetMaxCalories().Should().Be(0);
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

            sut.GetMaxCalories().Should().Be(600);
        }

        [Test]
        public void MultiEntryList_ReturnsBiggestSumOfCalories()
        {
            var dataProvider = Substitute.For<IDataProvider>();
            dataProvider.LoadData().Returns(new List<string>()
            {
                "10", "20", "30", "", "1000", "2000", "3000", "", "100", "200", "300"
            });
            var sut = CreateCalorieCalculator(dataProvider);

            sut.GetMaxCalories().Should().Be(6000);
        }

        [Test]
        public void ExcerciseList_ReturnsCorrectAnswer()
        {
            var sut = CreateCalorieCalculator(new ResourceDataProvider("AdventOfCode2022Tests.Data.Day1Exercise1.txt"));

            sut.GetMaxCalories().Should().Be(64929);
        }

        private CalorieCalculator CreateCalorieCalculator(IDataProvider dataProvider)
        {
            return new CalorieCalculator(dataProvider);
        }
    }
}
