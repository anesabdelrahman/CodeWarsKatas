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
        [TestCase(531, 131)]
        public void WhenPassingValidInt_ShouldReturnNumberOfTrailingZerox(int input, int expected)
        {
            
            var result = _TrailingZeros.TrailingZero1(input);
            result.Should().Be(expected);
        }
    }

    public class TrailingZeros
    {
        public int TrailingZero(int n)
        {
            ulong factorial = 1;
            var result = 0;
            for (var i = 1; i <= n; i++)
            {
                factorial *= (ulong)i;
            }

            while ( factorial > 0 && factorial.ToString().EndsWith('0'))
            {
                result++;
                factorial /= 10;
            }

            return result;
        }

        public int TrailingZero1(int n)
        {
            if (n > 0 && n < 25)
            {
                return n / 5;
            }

            //if (n > 10)
            //{
                //if (n % 10 == 0)
                //{
                //    return n / 5;
                //}

                //if (n % 5 == 0)
                //{
                    if (n >= 25)
                    {
                        //if ((n / 5) % 5 == 0)
                        //{
                        //    return (n / 5) + (n / 25);
                        //}

                        return (n / 5) +  25;
                    }
                   
                    //return n / 5;
                //}

                //if (n / 5 > 0 && n % 5 >= 0)
                //{
                //    return (n / 5) + 25;
                //}

                //return n / 5;
            //}

            

            return 0;
        }
    }
}
