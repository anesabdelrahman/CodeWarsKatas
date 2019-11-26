using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace CodingKata.CodeWars
{
    public class SumOfTwoDigitsTests
    {
        private TwoDigits num;

        [SetUp]
        public void SetUp()
        {
            num = new TwoDigits();
        }

        [TearDown]
        public void TearDown()
        {
            num = null;
        }

        [Test]
        public void Tests()
        {
            Assert.AreEqual(true, num.Sum(new[] { 2, 1, 8, 4, 7, 3 }, 3));
            Assert.AreEqual(true, num.Sum(new[] { 2, 1, 8, 4, 7, 3 }, 7));
            Assert.AreEqual(false, num.Sum(new[] { 2, 1, 8, 4, 7, 3 }, 20));
            Assert.AreEqual(false, num.Sum(new[] { 2, 1, 8, 4, 7, 3 }, 1));
            Assert.AreEqual(false, num.Sum(new[] { 2, 1, 8, 4, 7, 3 }, 2));

            Assert.AreEqual(true, num.Sum1(new[] { 2, 1, 8, 4, 7, 3 }, 3));
            Assert.AreEqual(true, num.Sum1(new[] { 2, 1, 8, 4, 7, 3 }, 7));
            Assert.AreEqual(false, num.Sum1(new[] { 2, 1, 8, 4, 7, 3 }, 20));
            Assert.AreEqual(false, num.Sum1(new[] { 2, 1, 8, 4, 7, 3 }, 1));
            Assert.AreEqual(false, num.Sum1(new[] { 2, 1, 8, 4, 7, 3 }, 2));

            Assert.AreEqual(true, num.Sum2( new[] { 2, 1, 8, 4, 7, 3 }, 3));
            Assert.AreEqual(true, num.Sum2( new[] { 2, 1, 8, 4, 7, 3 }, 7));
            Assert.AreEqual(false, num.Sum2(new[] { 2, 1, 8, 4, 7, 3 }, 20));
            Assert.AreEqual(false, num.Sum2(new[] { 2, 1, 8, 4, 7, 3 }, 1));
            Assert.AreEqual(false, num.Sum2(new[] {2, 1, 8, 4, 7, 3}, 2));
        }
    }

    public class TwoDigits
    {
        public bool Sum(int [] digits, int number)
        {
            var time = Stopwatch.StartNew();
            Array.Sort(digits);
            for (var i = 0; i <= digits.Length - 1; i++)
            {
                for (var j = 0; j <= digits.Length - 1; j++)
                {
                    if (j == i)
                    {
                        if (j == digits.Length - 1)
                        {
                            continue;
                        }

                        j++;
                    }

                    if (digits[i] + digits[j] == number)
                    {
                        return true;

                    }
                    
                }
            }

            time.Stop();
            Console.WriteLine(time.Elapsed);
            return false;
        }

        public bool Sum1(int[] digits, int number)
        {
            var time = Stopwatch.StartNew();
            Array.Sort(digits);
            for (int i = 0, j = digits.Length - 1; i < j;)
            {
                int sum = digits[i] + digits[j];
                if (sum == number)
                {
                    return true;
                }

                if (sum < number)
                {
                    ++i;
                }
                else
                {
                    --j;
                }
            }
            time.Stop();
            Console.WriteLine(time.Elapsed);
            return false;

        }

        public bool Sum2(int[] digits, int number)
        {
            var time = Stopwatch.StartNew();
            var set = new HashSet<int>();
            for (var i = 0; i <= digits.Length - 1; i++)
            {
                if (set.Contains(number - digits[i]))
                {
                    return true;
                }

                set.Add(digits[i]);
            }
            time.Stop();
            Console.WriteLine(time.Elapsed);
            return false;

        }

    }
}

    
