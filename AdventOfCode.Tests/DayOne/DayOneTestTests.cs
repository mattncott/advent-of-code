using AdventOfCode.DayOne;
using FluentAssertions;

namespace AdventOfCode.Tests.DayOne
{
    public class DayOneTestTests
    {
        private IEnumerable<IEnumerable<int>> _input;

        [SetUp]
        public void Setup()
        {
            this._input = new List<IEnumerable<int>>
            {
                new List<int>
                {
                    1000,
                    2000,
                    3000,
                },
                new List<int>
                {
                    4000,
                },
                new List<int>
                {
                    5000,
                    6000,
                },
                new List<int>
                {
                    7000,
                    8000,
                    9000,
                },
                new List<int>
                {
                    10000,
                },
            };
        }

        [Test]
        public void GetHighestCalories_CorrectlyCalculatesTheHighestCalories()
        {
            var result = DayOneTest.GetHighestCalories(this._input);
            result.Should().Be(24000);
        }

        [Test]
        public void GetTopThreeCalories_CorrectlyGetsTheSumOfTheTopThreeCalories()
        {
            var result = DayOneTest.GetTopThreeCalories(this._input);
            result.Should().Be(45000);
        }
    }
}
