using AdventOfCode.DayThree;
using FluentAssertions;

namespace AdventOfCode.Tests.DayThree
{
	public class RucksackTests
	{
        [Test]
        public void Rucksack_GeneratesCompartmentsCorrectly()
        {
            var rucksack = new Rucksack("vJrwpWtwJgWrhcsFMMfFFhFp");

            rucksack.CompartmentOne.Should().Be("vJrwpWtwJgWr");
            rucksack.CompartmentTwo.Should().Be("hcsFMMfFFhFp");
        }

        [TestCase('a', 1)]
        [TestCase('b', 2)]
        [TestCase('c', 3)]
        [TestCase('A', 27)]
        [TestCase('B', 28)]
        [TestCase('C', 29)]
        [TestCase('z', 26)]
        [TestCase('Z', 52)]
        public void RuckSack_GetLetterValue_ReturnsTheCorrectValue(char letter, int expectedValue)
        {
            var result = Rucksack.GetLetterValue(letter);
            result.Should().Be(expectedValue);
        }
    }
}

