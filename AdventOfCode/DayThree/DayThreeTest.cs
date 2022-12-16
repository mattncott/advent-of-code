namespace AdventOfCode.DayThree
{
    public class DayThreeTest
    {
        private readonly IConsoleWrapper _consoleWrapper;

        public DayThreeTest(IConsoleWrapper consoleWrapper)
        {
            this._consoleWrapper = consoleWrapper;
        }

        public void TestOne()
        {
            var input = GetInputFileContentsFromString("../../../DayThree/input.txt");
            var result = CalculateScoreFromRucksacks(input);

            this._consoleWrapper.WriteLine(string.Format("Day Three - Test One - {0}", result));
        }

        public void TestTwo()
        {
            var input = GetInputFileContentsFromString("../../../DayThree/input.txt", false);
            var result = CalculateValuesOfIdentifier(input);

            this._consoleWrapper.WriteLine(string.Format("Day Three - Test Two - {0}", result));
        }

        public static int CalculateScoreFromRucksacks(IEnumerable<Rucksack> input)
            => input.Select(x => x.CalculateScoreFromLine()).Sum();

        public static int CalculateValuesOfIdentifier(IEnumerable<Rucksack> input)
        {
            var scores = new List<int>();
            var numberOfJumps = Math.Floor((decimal)input.Count() / 3) - 1;

            for (var i = 0; i <= numberOfJumps; i++)
            {
                var firstRucksack = input.ElementAt(0);
                var secondRucksack = input.ElementAt(1);
                var thirdRucksack = input.ElementAt(2);

                if (i != 0)
                {
                    firstRucksack = input.ElementAt(3 * i);
                    secondRucksack = input.ElementAt((3 * i) + 1);
                    thirdRucksack = input.ElementAt((3 * i) + 2);
                }

                foreach (char c in firstRucksack.Contents)
                {
                    var foundInSecondRucksack = secondRucksack.Contents.IndexOf(c) != -1;
                    var foundInThirdRucksack = thirdRucksack.Contents.IndexOf(c) != -1;

                    if (foundInSecondRucksack && foundInThirdRucksack)
                    {
                        scores.Add(Rucksack.GetLetterValue(c));
                        break;
                    }
                }

            }
            

            return scores.Sum();
        }

        private static IEnumerable<Rucksack> GetInputFileContentsFromString(string inputLocation, bool generatingOutcomes = true)
        {
            var output = new List<Rucksack>();

            using (var streamReader = new StreamReader(inputLocation))
            {
                string? line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    if (!string.IsNullOrEmpty(line))
                    {
                        output.Add(new(line));
                    }
                }
            }

            return output;
        }
    }
}
