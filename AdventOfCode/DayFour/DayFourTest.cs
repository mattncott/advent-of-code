using AdventOfCode.DayFour;

namespace AdventOfCode.DayFour
{
	public class DayFourTest
	{
		private readonly IConsoleWrapper _consoleWrapper;

		public DayFourTest(IConsoleWrapper consoleWrapper)
		{
			this._consoleWrapper = consoleWrapper;
		}

        public void TestOne()
        {
            var input = GetInputFileContentsFromString("../../../DayFour/input.txt");
            var result = GetNumberOfPairOverlaps(input);

            this._consoleWrapper.WriteLine(string.Format("Day Four - Test One - {0}", result));
        }

        public void TestTwo()
        {
            var input = GetInputFileContentsFromString("../../../DayFour/input.txt");
            var result = GetNumberOfPairOverlaps(input, true);

            this._consoleWrapper.WriteLine(string.Format("Day Four - Test Two - {0}", result));
        }

        public static int GetNumberOfPairOverlaps(IEnumerable<AreaPair> input, bool findSingleMatchingPair = false)
        {
            var foundRange = 0;

            foreach (var areasToClean in input)
            {
                var increment = false;
                if (AreaToClearCompletelyEncapsulatesTheOther(areasToClean.AreaOne, areasToClean.AreaTwo))
                {
                    increment = true;
                }

                if (findSingleMatchingPair && !increment)
                {
                    var matchingFound = AreaOverlapsAtAll(areasToClean.AreaOne, areasToClean.AreaTwo);

                    if (matchingFound)
                    {
                        increment = true;
                    }
                }

                if (increment)
                {
                    foundRange++;
                }
            }

            return foundRange;
        }

        private static bool AreaOverlapsAtAll(AreaToClean areaOne, AreaToClean areaTwo)
        {
            var areaOneValues =
                Enumerable
                    .Range(areaOne.First, (areaOne.Last - areaOne.First) + 1)
                    .ToList();

            var areaTwoValues =
                Enumerable
                    .Range(areaTwo.First, (areaTwo.Last - areaTwo.First) + 1)
                    .ToList();

            var inter = areaOneValues.Intersect(areaTwoValues).ToList();

            return inter.Any();
        }

        private static bool AreaToClearCompletelyEncapsulatesTheOther(AreaToClean areaOne, AreaToClean areaTwo)
            => (areaOne.First >= areaTwo.First && areaOne.Last <= areaTwo.Last) ||
                (areaTwo.First >= areaOne.First && areaTwo.Last <= areaOne.Last);

        private static IEnumerable<AreaPair> GetInputFileContentsFromString(string inputLocation)
        {
            string? line;
            var output = new List<AreaPair>();

            using (var streamReader = new StreamReader(inputLocation))
            {
                while ((line = streamReader.ReadLine()) != null)
                {
                    if (!string.IsNullOrEmpty(line))
                    {
                        var twoAreas = line.Split(",");
                        var areaOne = twoAreas[0].Split("-");
                        var areaTwo = twoAreas[1].Split("-");

                        var areaPair = new AreaPair(
                                new AreaToClean(int.Parse(areaOne[0]), int.Parse(areaOne[1])),
                                new AreaToClean(int.Parse(areaTwo[0]), int.Parse(areaTwo[1]))
                            );
                        output.Add(areaPair);
                    }
                }
            }

            return output;
        }
    }
}

