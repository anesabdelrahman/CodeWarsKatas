using System;
using System.Globalization;
using System.Linq;
using System.Text;
using FluentAssertions;
using NUnit.Framework;

namespace CodingKata.CodeWars
{
    [TestFixture]
    public class TrailingZerosTests
    {
        private TrailingZeros _TrailingZeros;
        [SetUp]
        public void Initialize() => _TrailingZeros = new TrailingZeros();

        [Test]
        [TestCase(5, 1)]
        [TestCase(10, 2)]
        [TestCase(15, 3)]
        [TestCase(20, 4)]
        [TestCase(25, 6)]
        [TestCase(30, 7)]
        [TestCase(35, 8)]
        [TestCase(40, 9)]
        [TestCase(45, 10)]
        [TestCase(50, 12)]
        [TestCase(100, 24)]
        [TestCase(531, 131)]
        [TestCase(1000, 249)]
        public void WhenPassingValidInt_ShouldReturnNumberOfTrailingZerox(int input, int expected)
        {
            
            var result = _TrailingZeros.TrailingZero(input);
            result.Should().Be(expected);
        }
    }

    public class TrailingZeros
    {
        public int TrailingZero(int n)
        {
            var result = 0;
            var denominator = 5;
            var index = 1;

            while ((n / denominator) > 0)
            {
                result += n / denominator;
                denominator = (int)Math.Pow(5,++index);
            }
            return result;

        }
    }
}
