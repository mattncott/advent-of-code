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
                new(TheirChoice.Rock, YourChoice.Paper),
                new(TheirChoice.Paper, YourChoice.Rock),
                new(TheirChoice.Scissors, YourChoice.Scissors)
            };

            var result = DayTwoTest.CalculateScoreFromStrategyGuide(input);
            result.Should().Be(15);
        }

        [Test]
        public void CalculateNextMoveAndReturnScore_CorrectlyPickTheNextMoveAndGiveRightScore()
        {
            var input = new List<Game>
            {
                new(TheirChoice.Rock, DesiredOutcome.Draw),
                new(TheirChoice.Paper, DesiredOutcome.Lose),
                new(TheirChoice.Scissors, DesiredOutcome.Win)
            };

            var result = DayTwoTest.CalculateNextMoveAndReturnScore(input);
            result.Should().Be(12);
        }
    }
}
