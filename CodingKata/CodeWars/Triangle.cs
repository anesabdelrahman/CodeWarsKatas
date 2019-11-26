using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using FluentAssertions;
using NUnit.Framework;

namespace CodingKata.CodeWars
{
    [TestFixture]
    public class IsTriangleTests
    {
        private Triangle _triangle;
        [SetUp]
        public void Initialize() => _triangle = new Triangle();

        [Test]
        [TestCase(1, 1, 1, true)]
        [TestCase(5, 7, 10, true)]
        [TestCase(5, -7, 10, false)]
        [TestCase(0, 0, 0, false)]
        [TestCase(1, 2, 4, false)]
        [TestCase(4, 1, 2, false)]
        [TestCase(1, 4, 2, false)]
        [TestCase(1, 2, 3, false)]
        [TestCase(1, 3, 2, false)]
        [TestCase(3, 1, 2, false)]
        public void WhenPassingValidInt_ShouldSquareEachDigit(int a, int b, int c, bool expected)
        {
            
            var result = _triangle.IsTriangle1(a,b,c);
            result.Should().Be(expected);
        }
    }

    public class Triangle
    {
        //Mine
        public bool IsTriangle(int a, int b, int c)
        {
            var numbers = new List<int>{a,b,c};
            var result = !numbers.Any(x => x <= 0) && numbers.Sum() != 7 && numbers.All(x => x % (numbers.Sum() - x) != 0);
            return result;
        }

        // someone - I didn't know the triangle inequality theorem 
        public bool IsTriangle1(int a, int b, int c)
        {
            var lengths = new List<int>() { a, b, c };
            lengths.Sort();
            return lengths[0] + lengths[1] > lengths[2];
        }
    }
}
