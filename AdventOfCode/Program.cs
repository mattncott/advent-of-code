using AdventOfCode.DayOne;
using AdventOfCode.DayTwo;

namespace AdventOfCode
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var console = new ConsoleWrapper();

            var dayOne = new DayOneTest(console);

            dayOne.TestOne();
            dayOne.TestTwo();

            var dayTwo = new DayTwoTest(console);

            dayTwo.TestOne();
            //dayOne.TestTwo();
        }
    }
}