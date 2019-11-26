using System;
using System.Globalization;
using System.Linq;
using System.Text;
using FluentAssertions;
using NUnit.Framework;

namespace CodingKata.CodeWars
{
    [TestFixture]
    public class SquareDigitsTests
    {
        private SquareDigits _squareDigits;
        [SetUp]
        public void Initialize() => _squareDigits = new SquareDigits();

        [Test]
        [TestCase(1,1)]
        [TestCase(154,12516)]
        [TestCase(9119, 811181)]
        public void WhenPassingValidInt_ShouldSquareEachDigit(int input, int expected)
        {
            
            var result = _squareDigits.Square(input);
            result.Should().Be(expected);
        }
    }

    public class SquareDigits
    {
        //Mine
        public int Square(int n)
        {
            var result = n.ToString().Select(x => Math.Pow(char.GetNumericValue(x), 2).ToString(CultureInfo.InvariantCulture));
            return Convert.ToInt32(result.Aggregate((x, y) => $"{x}{y}"));
        }

        //someone else
        public int Square2(int n)
        {
            return int.Parse(string.Concat(n.ToString().Select(a => (int)Math.Pow(char.GetNumericValue(a), 2))));
        }
    }
}
