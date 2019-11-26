using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace CodingKata.CodeWars
{
    public class SumOfDigitsTests
    {
        private Number num;

        [SetUp]
        public void SetUp()
        {
            num = new Number();
        }

        [TearDown]
        public void TearDown()
        {
            num = null;
        }

        [Test]
        public void Tests()
        {
            Assert.AreEqual(7, num.DigitalRoot(16));
            Assert.AreEqual(6, num.DigitalRoot(456));
            Assert.AreEqual(6, num.DigitalRoot(942));
            Assert.AreEqual(6, num.DigitalRoot(132189));
            Assert.AreEqual(2, num.DigitalRoot(493193));

            Assert.AreEqual(7, num.DigitalRoot1(16));
            Assert.AreEqual(6, num.DigitalRoot1(456));
            Assert.AreEqual(6, num.DigitalRoot1(942));
            Assert.AreEqual(6, num.DigitalRoot1(132189));
            Assert.AreEqual(2, num.DigitalRoot1(493193));

            Assert.AreEqual(1, num.DigitalRoot2(1));
            Assert.AreEqual(7, num.DigitalRoot2(16));
            Assert.AreEqual(6, num.DigitalRoot2(456));
            Assert.AreEqual(6, num.DigitalRoot2(942));
            Assert.AreEqual(6, num.DigitalRoot2(132189));
            Assert.AreEqual(2, num.DigitalRoot2(493193));
        }
    }

    public class Number
    {
        public int DigitalRoot(long number)
        {
           var sum = 0L;

           while (number > 0)
           {
               sum += number % 10;
               number /= 10;

               if (number != 0 || sum <= 10) continue;
               number = sum;
               sum = 0;
           }
           return (int) sum;
        }

        public int DigitalRoot1(long number)
        {
            return (int)(1 + (number - 1) % 9);
        }

        public int DigitalRoot2(long number)
        {
            var result = number.ToString().Select(c => Convert.ToInt32(c.ToString())).Sum();

            if (result > 9)
            {
                result = DigitalRoot2(result);
            }
            return result;
        }
    }
}

    
