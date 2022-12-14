using AdventOfCode.DayOne;
using AdventOfCode.DayTwo;
using FluentAssertions;

namespace AdventOfCode.Tests.DayOne
{
    public class DayTwoTestTests
    {
        private IEnumerable<Game> _input;

        [SetUp]
        public void Setup()
        {
            this._input = new List<Game>
            {
                new Game('A', 'Y'),
                new Game('B', 'X'),
                new Game('C', 'Z')
            };
        }

        [Test]
        public void CalculateScoreFromStrategyGuide_CorrectlyCalculatesTheCorrectScore()
        {
            var result = DayTwoTest.CalculateScoreFromStrategyGuide(this._input);
            result.Should().Be(15);
        }
    }
}
