using System;
using AdventOfCode.DaySix;
using FluentAssertions;

namespace AdventOfCode.Tests.DaySix
{
	public class DaySixTestTests
	{
        [TestCase("bvwbjplbgvbhsrlpgdmjqwftvncz", 5)]
        [TestCase("nppdvjthqldpwncqszvftbrmjlhg", 6)]
        [TestCase("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 10)]
        [TestCase("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 11)]
        public void FindMarkerInString_ReturnsTheCorrectValue(string input, int expectedResult)
        {
            var result = DaySixTest.FindMarkerInString(input);
            result.Should().Be(expectedResult);
        }

        [TestCase("mjqjpqmgbljsphdztnvjfqwrcgsmlb", 19)]
        [TestCase("bvwbjplbgvbhsrlpgdmjqwftvncz", 23)]
        [TestCase("nppdvjthqldpwncqszvftbrmjlhg", 23)]
        [TestCase("nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg", 29)]
        [TestCase("zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw", 26)]
        public void FindMessageInString_ReturnsTheCorrectValue(string input, int expectedResult)
        {
            var result = DaySixTest.FindMessageInString(input);
            result.Should().Be(expectedResult);
        }
    }
}

