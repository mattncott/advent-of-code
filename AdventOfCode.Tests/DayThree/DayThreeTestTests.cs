using AdventOfCode.DayThree;
using FluentAssertions;

namespace AdventOfCode.Tests.DayThree
{
    public class DayThreeTestTests
    {
        [Test]
        public void CalculateScoreFromRucksacks_CorrectlyCalculatesScoreAccordingToData()
        {
            var input = new List<Rucksack>
            {
                new("vJrwpWtwJgWrhcsFMMfFFhFp"),
                new("jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL"),
                new("PmmdzqPrVvPwwTWBwg"),
                new("wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn"),
                new("ttgJtRGJQctTZtZT"),
                new("CrZsJsPPZsGzwwsLwLmpwMDw")
            };

            var result = DayThreeTest.CalculateScoreFromRucksacks(input);
            result.Should().Be(157);
        }

        [Test]
        public void CalculateValuesOfIdentifier_CorrectlyCalculatesScoreAccordingToData()
        {
            var input = new List<Rucksack>
            {
                new("vJrwpWtwJgWrhcsFMMfFFhFp"),
                new("jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL"),
                new("PmmdzqPrVvPwwTWBwg"),
                new("wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn"),
                new("ttgJtRGJQctTZtZT"),
                new("CrZsJsPPZsGzwwsLwLmpwMDw")
            };

            var result = DayThreeTest.CalculateValuesOfIdentifier(input);
            result.Should().Be(70);
        }
    }
}
