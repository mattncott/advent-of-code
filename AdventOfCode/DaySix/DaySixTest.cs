using System;
using AdventOfCode.DayFive;

namespace AdventOfCode.DaySix
{
	public class DaySixTest
	{
		private readonly IConsoleWrapper _consoleWrapper;

		public DaySixTest(IConsoleWrapper consoleWrapper)
		{
			this._consoleWrapper = consoleWrapper;
		}

        public void TestOne()
        {
            var input = GetStringFromInputFile("../../../DaySix/input.txt");
            var result = FindMarkerInString(input);

            this._consoleWrapper.WriteLine(string.Format("Day Six - Test One - {0}", result));
        }

        public void TestTwo()
        {
            var input = GetStringFromInputFile("../../../DaySix/input.txt");
            var result = FindMessageInString(input);

            this._consoleWrapper.WriteLine(string.Format("Day Six - Test Two - {0}", result));
        }

        public static int FindMarkerInString(string input)
            => FindNonMatchingCharacterInString(input, lengthOfStringToCheck: 4);

        public static int FindMessageInString(string input)
            => FindNonMatchingCharacterInString(input, lengthOfStringToCheck: 14);

        private static int FindNonMatchingCharacterInString(string input, int lengthOfStringToCheck)
        {
            for (var i = (lengthOfStringToCheck - 1); i <= input.Length - 1; i++)
            {
                var subStringToCheck = input.Substring(i - (lengthOfStringToCheck - 1), lengthOfStringToCheck);

                if (StringDoesNotContainDuplicateChar(subStringToCheck))
                {
                    return i + 1;
                }
            }

            throw new Exception("No marker found in string");
        }

        private static bool StringDoesNotContainDuplicateChar(string input)
            => input.Distinct().Count() == input.Length;

        private static string GetStringFromInputFile(string inputLocation)
        {
            string? line;
            var output = "";

            using (var streamReader = new StreamReader(inputLocation))
            {
                while ((line = streamReader.ReadLine()) != null)
                {
                    if (!string.IsNullOrEmpty(line))
                    {
                        output = line;
                    }
                }
            }

            return output;
        }
    }
}

