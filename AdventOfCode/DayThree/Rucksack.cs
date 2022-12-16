using System;
namespace AdventOfCode.DayThree
{
	public class Rucksack
	{
        private readonly string _contents;
		private readonly int _splitStringPos;

        public Rucksack(string contents)
		{
			this._contents = contents;
			this._splitStringPos = contents.Length / 2;
		}

        public string Contents
        {
            get => this._contents;
        }

		public string CompartmentOne
		{
			get => _contents.Substring(0, this._splitStringPos);
		}

		public string CompartmentTwo
		{
			get => _contents.Substring(this._splitStringPos);
		}

		public int CalculateScoreFromLine()
		{
            var seenInCompartmentOne = new List<char>();

            foreach (char c in this.CompartmentOne)
            {
                var existsInCompartmentTwo = this.CompartmentTwo.IndexOf(c) != -1;

                if (existsInCompartmentTwo)
                {
                    return GetLetterValue(c);
                }
            }

            throw new ArgumentNullException("No duplicate items in rucksack");
        }

        public static int GetLetterValue(char letter)
        {
            var value = 0;

            if (char.IsUpper(letter))
            {
                value = (char.ToLower(letter) - 'a') + 26;
            }
            else
            {
                value = letter - 'a';
            }

            return value + 1;
        }
    }
}
