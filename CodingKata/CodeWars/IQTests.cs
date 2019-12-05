using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using NUnit.Framework;

namespace CodingKata.CodeWars
{
    public class IQTests
    {
        private IQ _iq;

        [SetUp]
        public void SetUp()
        {
            _iq = new IQ();
        }

        [TearDown]
        public void TearDown()
        {
            _iq = null;
        }

        [Test]
        [TestCase("2 4 7 8 10", 3)]
        [TestCase("1 2 2", 1)]
        public void Test1(string input, int expected)
        {
            Assert.AreEqual(expected, _iq.Test(input));
        }
    }

    public class IQ
    {
        public int Test(string numbers)
        {
            var numberList = new List<int>(numbers.Split(' ').Select(x => Convert.ToInt32(x.ToString())));
            var evenNumbers = numberList.Where(y => y > 0 && y % 2 == 0).ToList();
            return numberList.IndexOf(evenNumbers.Count() > numberList.Except(evenNumbers).Count() ? numberList.Except(evenNumbers).FirstOrDefault() : evenNumbers.FirstOrDefault()) + 1;
        }
    }
}

    
