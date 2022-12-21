using AdventOfCode2022;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using System.Collections.Generic;

namespace AdventOfCode2022Tests
{
    public class CleaningOverlapCounterTest
    {
        [Test]
        public void SimpleList_ReturnsSumOfCalories()
        {
            var dataProvider = Substitute.For<IDataProvider>();
            dataProvider.LoadData().Returns(new List<string>()
            {
                "2-4,6-8", "2-3,4-5", "2-8,3-7"
            });
            var sut = CreateCleaningOverlapCounter(dataProvider);

            sut.GetNumberOfOverlaps().Should().Be(1);
        }
        
        [Test]
        public void ExerciseList_ReturnsCorrectAnswerOnOverlaps()
        {
            var sut = CreateCleaningOverlapCounter(new ResourceDataProvider("AdventOfCode2022Tests.Data.Day4.txt"));

            sut.GetNumberOfOverlaps().Should().Be(459);
        }

        [Test]
        public void ExerciseList_ReturnsCorrectAnswerOnIntersections()
        {
            var sut = CreateCleaningOverlapCounter(new ResourceDataProvider("AdventOfCode2022Tests.Data.Day4.txt"));

            sut.GetNumberOfIntersections().Should().Be(779);
        }

        private CleaningOverlapCounter CreateCleaningOverlapCounter(IDataProvider dataProvider)
        {
            return new CleaningOverlapCounter(dataProvider);
        }
    }
}
