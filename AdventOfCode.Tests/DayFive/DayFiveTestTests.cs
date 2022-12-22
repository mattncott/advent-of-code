using System;
using AdventOfCode.DayFive;
using FluentAssertions;

namespace AdventOfCode.Tests.DayFive
{
	public class DayFiveTestTests
	{
        private IEnumerable<Stack<char>> _cargoShip;
        private IEnumerable<Move> _moves;

        [SetUp]
        public void SetupTests()
        {
            this._cargoShip = GetTestCargoShip();
            this._moves = GetMoves();
        }

        [Test]
        public void GetTopLevelItemsAsString_WhenMovingCratesAndNotEnsuringOrder_ReturnsCorrectValue()
        {
            var result = DayFiveTest.GetTopLevelItemsAsString(this._cargoShip, this._moves, ensureOrder: false);

            result.Should().Be("CMZ");
        }

        [Test]
        public void GetTopLevelItemsAsString_WhenMovingCratesAndEnsuringOrder_ReturnsCorrectValue()
        {
            var result = DayFiveTest.GetTopLevelItemsAsString(this._cargoShip, this._moves, ensureOrder: true);

            result.Should().Be("MCD");
        }

        private static IEnumerable<Stack<char>> GetTestCargoShip()
        {

            var stackOne = new Stack<char>();
            stackOne.Push('Z');
            stackOne.Push('N');

            var stackTwo = new Stack<char>();
            stackTwo.Push('M');
            stackTwo.Push('C');
            stackTwo.Push('D');

            var stackThree = new Stack<char>();
            stackThree.Push('P');

            return new List<Stack<char>>
            {
                stackOne, stackTwo, stackThree
            };
        }

        private static IEnumerable<Move> GetMoves()
            => new List<Move>
            {
                new Move(2, 1, 1),
                new Move(1, 3, 3),
                new Move(2, 1, 2),
                new Move(1, 2, 1),
            };
    }
}

