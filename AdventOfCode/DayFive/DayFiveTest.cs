using System;
using AdventOfCode.DayFour;

namespace AdventOfCode.DayFive
{
    public class DayFiveTest
    {
        private readonly IConsoleWrapper _consoleWrapper;

        public DayFiveTest(IConsoleWrapper consoleWrapper)
        {
            this._consoleWrapper = consoleWrapper;
        }

        public void TestOne()
        {
            var cargoShip = GetCargoShipFromInput("../../../DayFive/input.txt");
            var moves = GetMovesFromInput("../../../DayFive/input.txt");
            var result = GetTopLevelItemsAsString(cargoShip, moves, ensureOrder: false);

            this._consoleWrapper.WriteLine(string.Format("Day Five - Test One - {0}", result));
        }

        public void TestTwo()
        {
            var cargoShip = GetCargoShipFromInput("../../../DayFive/input.txt");
            var moves = GetMovesFromInput("../../../DayFive/input.txt");
            var result = GetTopLevelItemsAsString(cargoShip, moves, ensureOrder: true);

            this._consoleWrapper.WriteLine(string.Format("Day Five - Test Two - {0}", result));
        }

        public static string GetTopLevelItemsAsString(IEnumerable<Stack<char>> cargoShip, IEnumerable<Move> moves, bool ensureOrder)
        {
            cargoShip = GetStackAfterMoves(cargoShip, moves, ensureOrder);
            var topLevelCrates = new List<char>();

            foreach (var crate in cargoShip)
            {
                var hasCrate = crate.TryPeek(out var topLevelCrate);

                if (hasCrate)
                {
                    topLevelCrates.Add(topLevelCrate);
                }
            }

            return new string(topLevelCrates.ToArray());
        }

        private static IEnumerable<Stack<char>> GetStackAfterMoves(IEnumerable<Stack<char>> cargoShip, IEnumerable<Move> moves, bool ensureOrder)
        {
            foreach (var move in moves)
            {
                if (!ensureOrder)
                {
                    MoveCrateWithoutKeepingOrder(cargoShip, move);
                }
                else
                {
                    MoveCreateWithKeepingOrder(cargoShip, move);
                }
            }

            return cargoShip;
        }

        private static void MoveCreateWithKeepingOrder(IEnumerable<Stack<char>> cargoShip, Move move)
        {
            var cratesToMove = new List<char>();

            var stackBeingAltered = cargoShip.ElementAt(move.StackToMove);
            var stackBeingMovedTo = cargoShip.ElementAt(move.MoveStackTo);

            for (var i = 1; i <= move.Quantity; i++)
            {
                var hasCrateToMove = stackBeingAltered.TryPop(out var valueBeingMoved);

                if (hasCrateToMove)
                {
                    cratesToMove.Add(valueBeingMoved);
                }
            }

            for (var i = cratesToMove.Count-1; i >= 0; i--)
            {
                stackBeingMovedTo.Push(cratesToMove.ElementAt(i));
            }
        }

        private static void MoveCrateWithoutKeepingOrder(IEnumerable<Stack<char>> cargoShip, Move move)
        {
            var stackBeingAltered = cargoShip.ElementAt(move.StackToMove);
            var stackBeingMovedTo = cargoShip.ElementAt(move.MoveStackTo);

            for (var i = 1; i <= move.Quantity; i++)
            {
                var hasCrateToMove = stackBeingAltered.TryPop(out var valueBeingMoved);

                if (hasCrateToMove)
                {
                    stackBeingMovedTo.Push(valueBeingMoved);
                }
            }
        }

        private static IEnumerable<Stack<char>> GetCargoShipFromInput(string inputLocation)
        {

            var stackOne = new Stack<char>();
            stackOne.Push('J');
            stackOne.Push('H');
            stackOne.Push('G');
            stackOne.Push('M');
            stackOne.Push('Z');
            stackOne.Push('N');
            stackOne.Push('T');
            stackOne.Push('F');

            var stackTwo = new Stack<char>();
            stackTwo.Push('V');
            stackTwo.Push('W');
            stackTwo.Push('J');

            var stackThree = new Stack<char>();
            stackThree.Push('G');
            stackThree.Push('V');
            stackThree.Push('L');
            stackThree.Push('J');
            stackThree.Push('B');
            stackThree.Push('T');
            stackThree.Push('H');

            var stackFour = new Stack<char>();
            stackFour.Push('B');
            stackFour.Push('P');
            stackFour.Push('J');
            stackFour.Push('N');
            stackFour.Push('C');
            stackFour.Push('D');
            stackFour.Push('V');
            stackFour.Push('L');

            var stackFive = new Stack<char>();
            stackFive.Push('F');
            stackFive.Push('W');
            stackFive.Push('S');
            stackFive.Push('M');
            stackFive.Push('P');
            stackFive.Push('R');
            stackFive.Push('G');

            var stackSix = new Stack<char>();
            stackSix.Push('G');
            stackSix.Push('H');
            stackSix.Push('C');
            stackSix.Push('F');
            stackSix.Push('B');
            stackSix.Push('N');
            stackSix.Push('V');
            stackSix.Push('M');

            var stackSeven = new Stack<char>();
            stackSeven.Push('D');
            stackSeven.Push('H');
            stackSeven.Push('G');
            stackSeven.Push('M');
            stackSeven.Push('R');

            var stackEight = new Stack<char>();
            stackEight.Push('H');
            stackEight.Push('N');
            stackEight.Push('M');
            stackEight.Push('V');
            stackEight.Push('Z');
            stackEight.Push('D');

            var stackNine = new Stack<char>();
            stackNine.Push('G');
            stackNine.Push('N');
            stackNine.Push('F');
            stackNine.Push('H');

            return new List<Stack<char>>
            {
                stackOne,
                stackTwo,
                stackThree,
                stackFour,
                stackFive,
                stackSix,
                stackSeven,
                stackEight,
                stackNine,
            };

        }

        private static IEnumerable<Move> GetMovesFromInput(string inputLocation)
        {
            string? line;
            var output = new List<Move>();

            using (var streamReader = new StreamReader(inputLocation))
            {
                while ((line = streamReader.ReadLine()) != null)
                {
                    if (!string.IsNullOrEmpty(line))
                    {
                        if (line.Contains("move"))
                        {
                            var doubleDigit = int.TryParse(line.AsSpan(6, 1), out _);
                           
                            var quantity = int.Parse(line.Substring(5, (!doubleDigit ? 1 : 2)));
                            var stackToMove = int.Parse(line.Substring((!doubleDigit ? 12 : 13), 1));
                            var moveStackTo = int.Parse(line.Substring(line.Length - 1, 1));

                            output.Add(new Move(stackToMove, moveStackTo, quantity));
                        }
                    }
                }
            }

            return output;
        }
    }
}

