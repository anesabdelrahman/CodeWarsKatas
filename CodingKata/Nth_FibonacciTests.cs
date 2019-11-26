using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using NUnit.Framework;

namespace CodingKata
{
    class Nth_FibonacciTests
    {
        private FibonacciNumber _fibonacciNumber = new FibonacciNumber();

        [SetUp]
        public void TestSetup()
        {
            //_fibonacciNumber = new FibonacciNumber();
        }

        [Test]
        [TestCase(0,0)]
        [TestCase(1,1)]
        [TestCase(2,1)]
        [TestCase(3,2)]
        [TestCase(4,3)]
        [TestCase(5,5)]
        [TestCase(6,8)]
        [TestCase(7,13)]
        [TestCase(8,21)]
        [TestCase(9,34)]
        [TestCase(10,55)]
        [TestCase(11,89)]
        [TestCase(12,144)]
        [TestCase(13,233)]
        [TestCase(14,377)]
        public void WhenPassValidInteger_ShouldGetNthNumber(int number, int expected)
        {
            var result = _fibonacciNumber.Fib(number);

            result.Should().Be(expected);
        }
    }

    internal class FibonacciNumber
    {
        public int Fib(int number)
        {
            // Create a sequence up to the value of number e.g. {0, 1, 1, 2, 3, 5}

            if (number <= 0)
            {
                return 0;
            }

            var fibonacciArray = new int[number + 1];

            for (var i = 0; i < fibonacciArray.Length; i++)
            {
                if (i < 2)
                {
                    fibonacciArray[i] = i;
                    continue;;
                }

                fibonacciArray[i] = fibonacciArray[i-1] + fibonacciArray[i-2];
            }

            return fibonacciArray[number];
        }
    }
}
