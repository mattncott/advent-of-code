using AdventOfCode.DayFour;
using FluentAssertions;
namespace AdventOfCode.Tests.DayFour
{
	public class DayFourTestTests
	{
		[Test]
		public void GetNumberOfFullOverlaps_CorrectlyCalculatesScoreAccordingToData()
		{

			var input = new List<AreaPair>
            {
                new(new AreaToClean(2, 4), new AreaToClean(6, 8)),
                new(new AreaToClean(2, 3), new AreaToClean(4, 5)),
                new(new AreaToClean(5, 7), new AreaToClean(7, 9)),
                new(new AreaToClean(2, 8), new AreaToClean(3, 7)),
                new(new AreaToClean(6, 6), new AreaToClean(4, 6)),
                new(new AreaToClean(2, 6), new AreaToClean(4, 8))
			};

			var result = DayFourTest.GetNumberOfPairOverlaps(input);
			result.Should().Be(2);
		}

        [Test]
        public void _CorrectlyCalculatesScoreAccordingToData()
        {
            var input = new List<AreaPair>
            {
                new(new AreaToClean(2, 4), new AreaToClean(6, 8)),
                new(new AreaToClean(2, 3), new AreaToClean(4, 5)),
                new(new AreaToClean(5, 7), new AreaToClean(7, 9)),
                new(new AreaToClean(2, 8), new AreaToClean(3, 7)),
                new(new AreaToClean(6, 6), new AreaToClean(4, 6)),
                new(new AreaToClean(2, 6), new AreaToClean(4, 8))
            };

            var result = DayFourTest.GetNumberOfPairOverlaps(input, true);
            result.Should().Be(4);
        }
    }
}
