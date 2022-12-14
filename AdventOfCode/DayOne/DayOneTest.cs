namespace AdventOfCode.DayOne
{
    public class DayOneTest
    {
        private readonly IConsoleWrapper _consoleWrapper;

        public DayOneTest(IConsoleWrapper consoleWrapper)
        {
            this._consoleWrapper = consoleWrapper;
        }

        public void TestOne()
        {
            var input = GetInputFileContentsFromString("../../../DayOne/input.txt");
            var result = GetHighestCalories(input);

            this._consoleWrapper.WriteLine(string.Format("Day One - Test One - {0}", result));
        }

        public void TestTwo()
        {
            var input = GetInputFileContentsFromString("../../../DayOne/input.txt");
            var result = GetTopThreeCalories(input);

            this._consoleWrapper.WriteLine(string.Format("Day One - Test One - {0}", result));
        }

        public static int GetTopThreeCalories(IEnumerable<IEnumerable<int>> calories)
            => calories.Select(x => x.Sum()).OrderByDescending(x => x).Take(3).Sum();

        public static int GetHighestCalories(IEnumerable<IEnumerable<int>> calories)
            => calories.Select(x => x.Sum()).Max();

        private static IEnumerable<IEnumerable<int>> GetInputFileContentsFromString(string inputLocation)
        {
            string? line;
            var output = new List<List<int>>();

            using (var streamReader = new StreamReader(inputLocation))
            {
                var currentInnerList = new List<int>();

                while ((line = streamReader.ReadLine()) != null)
                {
                    if (string.IsNullOrEmpty(line))
                    {
                        output.Add(new List<int>(currentInnerList));
                        currentInnerList.Clear();
                    }
                    else
                    {
                        currentInnerList.Add(int.Parse(line));
                    }
                }
            }

            return output;
        }
    }
}
