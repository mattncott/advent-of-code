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

            this._consoleWrapper.WriteLine(string.Format("Day One - Test One - {0}", result));
        }

        public void TestTwo()
        {
            //var input = Helper.GetInputFileContentsFromString("../../../DayTwo/input.txt");
            //var result = GetTopThreeCalories(input);

            //this._consoleWrapper.WriteLine(string.Format("Day One - Test One - {0}", result));
        }

        public static int CalculateScoreFromStrategyGuide(IEnumerable<Game> input)
            => input.Select(x => x.GetPointsForGame()).Sum();

        private static IEnumerable<Game> GetInputFileContentsFromString(string inputLocation)
        {
            string? line;
            var output = new List<Game>();

            using (var streamReader = new StreamReader(inputLocation))
            {
                while ((line = streamReader.ReadLine()) != null)
                {
                    var plays = line.Split(' ');
                    output.Add(new Game(char.Parse(plays[0]), char.Parse(plays[1])));
                }
            }

            return output;
        }
    }
}
