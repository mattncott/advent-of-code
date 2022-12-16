using AdventOfCode.DayFour;
using AdventOfCode.DayOne;
using AdventOfCode.DayThree;
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
            dayTwo.TestTwo();

            var dayThree = new DayThreeTest(console);
            dayThree.TestOne();
            dayThree.TestTwo();

            var dayFour = new DayFourTest(console);
            dayFour.TestOne();
            dayFour.TestTwo();
        }
    }
}