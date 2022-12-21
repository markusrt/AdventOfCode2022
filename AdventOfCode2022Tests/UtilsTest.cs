using AdventOfCode2022;
using FluentAssertions;
using NUnit.Framework;

namespace AdventOfCode2022Tests;

public class UtilsTest
{
    [TestCase("2-8,3-7")]
    [TestCase("6-6,4-6")]
    public void Overlap_IsDetected(string input)
    {
        Utils.DetectOverlap(input).Should().BeTrue();
    }

    [Test]
    public void NonOverlap_IsDetected()
    {
        Utils.DetectOverlap("2-4,6-8").Should().BeFalse();
    }

    [TestCase("2-8,3-7")]
    [TestCase("6-6,4-6")]
    [TestCase("1-6,4-6")]
    [TestCase("7-7,1-100")]
    public void Intersection_IsDetected(string input)
    {
        Utils.DetectIntersection(input).Should().BeTrue();
    }

    [Test]
    public void NonIntersection_IsDetected()
    {
        Utils.DetectIntersection("2-4,6-8").Should().BeFalse();
    }
}