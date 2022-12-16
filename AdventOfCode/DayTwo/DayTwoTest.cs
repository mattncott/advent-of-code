namespace AdventOfCode.DayTwo
{
    public class DayTwoTest
    {
        private readonly IConsoleWrapper _consoleWrapper;

        public DayTwoTest(IConsoleWrapper consoleWrapper)
        {
            this._consoleWrapper = consoleWrapper;
        }

        public void TestOne()
        {
            var input = GetInputFileContentsFromString("../../../DayTwo/input.txt");
            var result = CalculateScoreFromStrategyGuide(input);

            this._consoleWrapper.WriteLine(string.Format("Day Two - Test One - {0}", result));
        }

        public void TestTwo()
        {
            var input = GetInputFileContentsFromString("../../../DayTwo/input.txt", false);
            var result = CalculateNextMoveAndReturnScore(input);

            this._consoleWrapper.WriteLine(string.Format("Day Two - Test Two - {0}", result));
        }

        public static int CalculateNextMoveAndReturnScore(IEnumerable<Game> input)
        {
            var newInput = input.Select(x => new Game(x.OpponentChose, x.GetWhatIShouldPick()));

            return CalculateScoreFromStrategyGuide(newInput);
        }

        public static int CalculateScoreFromStrategyGuide(IEnumerable<Game> input)
            => input.Select(x => x.GetPointsForGame()).Sum();

        private static IEnumerable<Game> GetInputFileContentsFromString(string inputLocation, bool generatingOutcomes = true)
        {
            string? line;
            int lineCount = 0;
            var output = new List<Game>();

            using (var streamReader = new StreamReader(inputLocation))
            {
                while ((line = streamReader.ReadLine()) != null)
                {
                    if (!string.IsNullOrEmpty(line))
                    {
                        lineCount++;
                        var plays = line.Split(' ');

                        if (generatingOutcomes)
                        {
                            output.Add(new((TheirChoice)char.Parse(plays[0]), (YourChoice)char.Parse(plays[1])));
                        }
                        else
                        {
                            output.Add(new((TheirChoice)char.Parse(plays[0]), (DesiredOutcome)char.Parse(plays[1])));
                        }
                    }
                }
            }

            return output;
        }
    }
}
