using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace CodingKata.CodeWars
{
    [TestFixture]
    public class GreedTests
    {
        private Greed _greed;
        [SetUp]
        public void Initialize() => _greed = new Greed();

        [Test]
        [TestCase(0, new[] { 2, 3, 4, 6, 2 })]
        [TestCase(400, new[] { 4, 4, 4, 3, 3 })]
        [TestCase(450, new[] { 2, 4, 4, 5, 4 })]
        [TestCase(250, new[] { 5, 1, 3, 3, 1 })]
        [TestCase(1100, new [] { 1, 1, 1, 3, 1 })]
        public void WhenPassingValidDicValues_ShouldReturnCorrectScore(int expected, int[] dice)
        {
            
            var result = _greed.Score1(dice);
            result.Should().Be(expected);
        }
    }

    public class Greed
    {
        public int Score(int[] dice)
        {
            var result = 0;
            var roll = new List<int>(dice);
            
            if (roll.Count(x => x.Equals(6)) >= 3)
            {
                result += 600;
            }
            if (roll.Count(x => x.Equals(5)) > 0)
            {
                if (roll.Count(x => x.Equals(5)) >= 3)
                {
                    result += 500;
                    result += 50 * (roll.Count(x => x.Equals(5)) - 3);
                    roll.RemoveAll(x => x.Equals(5));
                }
                else
                {
                    result += 50 * (roll.Count(x => x.Equals(5)));
                }
            }
            if (roll.Count(x => x.Equals(4)) >= 3)
            {
                result += 400;
            }
            if (roll.Count(x => x.Equals(3)) >= 3)
            {
                result += 300;
            }
            if (roll.Count(x => x.Equals( 2)) >= 3)
            {
                result += 200;
            }

            if (roll.Count(x => x.Equals(1)) <= 0) return result;
            {
                if (roll.Count(x => x.Equals( 1)) >= 3)
                {
                    result += 1000;
                    result += 100 * (roll.Count(x => x.Equals( 1)) - 3);
                    roll.RemoveAll(x => x.Equals( 1));
                }
                else
                {
                    result += 100 * roll.Count(x => x.Equals( 1));
                }
            }

            return result;
        }

        public int Score1(int[] dice)
        {
            int[] tripleValue = { 0, 1000, 200, 300, 400, 500, 600 };
            int[] singleValue = { 0, 100, 0, 0, 0, 50, 0 };

            var value = 0;
            for (var dieSide = 1; dieSide <= 6; dieSide++)
            {
                var countRolls = dice.Count(outcome => outcome == dieSide);
                value += tripleValue[dieSide] * (countRolls / 3) + singleValue[dieSide] * (countRolls % 3);
            }
            return value;
        }
    }
}
