using AdventOfCode.DayTwo;
using FluentAssertions;

namespace AdventOfCode.Tests.DayTwo
{
	public class GameTests
	{
        private const int _rockChoicePoints = 1;
        private const int _paperChoicePoints = 2;
        private const int _scissorsChoicePoints = 3;

        // losing
        [TestCase(TheirChoice.Rock, YourChoice.Scissors, Points.Loss + _scissorsChoicePoints)]
        [TestCase(TheirChoice.Scissors, YourChoice.Paper, Points.Loss + _paperChoicePoints)]
        [TestCase(TheirChoice.Paper, YourChoice.Rock, Points.Loss + _rockChoicePoints)]
        // winning
        [TestCase(TheirChoice.Paper, YourChoice.Scissors, Points.Win + _scissorsChoicePoints)]
        [TestCase(TheirChoice.Scissors, YourChoice.Rock, Points.Win + _rockChoicePoints)]
        [TestCase(TheirChoice.Rock, YourChoice.Paper, Points.Win + _paperChoicePoints)]
        // drawing
        [TestCase(TheirChoice.Paper, YourChoice.Paper, Points.Draw + _paperChoicePoints)]
        [TestCase(TheirChoice.Rock, YourChoice.Rock, Points.Draw + _rockChoicePoints)]
        [TestCase(TheirChoice.Scissors, YourChoice.Scissors, Points.Draw + _scissorsChoicePoints)]
        public void GetPointsForGame_CalculatesPointsCorrectly(TheirChoice theirChoice, YourChoice yourChoice, int points)
        {
            var game = new Game(theirChoice, yourChoice);

            var result = game.GetPointsForGame();

            result.Should().Be(points);
        }

        // losing
        [TestCase(TheirChoice.Rock, DesiredOutcome.Lose, YourChoice.Scissors)]
        [TestCase(TheirChoice.Scissors, DesiredOutcome.Lose, YourChoice.Paper)]
        [TestCase(TheirChoice.Paper, DesiredOutcome.Lose, YourChoice.Rock)]
        // winning
        [TestCase(TheirChoice.Rock, DesiredOutcome.Win, YourChoice.Paper)]
        [TestCase(TheirChoice.Scissors, DesiredOutcome.Win, YourChoice.Rock)]
        [TestCase(TheirChoice.Paper, DesiredOutcome.Win, YourChoice.Scissors)]
        // drawing
        [TestCase(TheirChoice.Rock, DesiredOutcome.Draw, YourChoice.Rock)]
        [TestCase(TheirChoice.Scissors, DesiredOutcome.Draw, YourChoice.Scissors)]
        [TestCase(TheirChoice.Paper, DesiredOutcome.Draw, YourChoice.Paper)]
        public void GetWhatIShouldPick_ReturnsTheCorrectOptionForTheDesiredOutcome(TheirChoice theirChoice, DesiredOutcome outcome, YourChoice expectedChoice)
        {
            var game = new Game(theirChoice, outcome);

            var result = game.GetWhatIShouldPick();

            result.Should().Be(expectedChoice);
        }
    }
}

