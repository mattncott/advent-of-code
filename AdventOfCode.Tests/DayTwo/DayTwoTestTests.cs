using AdventOfCode.DayOne;
using AdventOfCode.DayTwo;
using FluentAssertions;

namespace AdventOfCode.Tests.DayTwo
{
    public class DayTwoTestTests
    {
        [Test]
        public void CalculateScoreFromStrategyGuide_CorrectlyCalculatesScoreAccordingToData()
        {
            var input = new List<Game>
            {
                new Game(TheirChoice.Rock, YourChoice.Paper),
                new Game(TheirChoice.Paper, YourChoice.Rock),
                new Game(TheirChoice.Scissors, YourChoice.Scissors)
            };

            var result = DayTwoTest.CalculateScoreFromStrategyGuide(input);
            result.Should().Be(15);
        }

        [Test]
        public void CalculateNextMoveAndReturnScore_CorrectlyPickTheNextMoveAndGiveRightScore()
        {
            var input = new List<Game>
            {
                new Game(TheirChoice.Rock, DesiredOutcome.Draw),
                new Game(TheirChoice.Paper, DesiredOutcome.Lose),
                new Game(TheirChoice.Scissors, DesiredOutcome.Win)
            };

            var result = DayTwoTest.CalculateNextMoveAndReturnScore(input);
            result.Should().Be(12);
        }
    }
}
