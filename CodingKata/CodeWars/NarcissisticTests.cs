using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using NUnit.Framework;

namespace CodingKata.CodeWars
{
    public class NarcissisticTests
    {
        private NarcissisticClass _narcissisticClass;

        [SetUp]
        public void SetUp()
        {
            _narcissisticClass = new NarcissisticClass();
        }

        [TearDown]
        public void TearDown()
        {
            _narcissisticClass = null;
        }

        [Test]
        [TestCase(1, true)]
        [TestCase(153, true)]
        [TestCase(371, true)]
        [TestCase(1634, true)]
        [TestCase(1635, false)]
        public void Test1(int input, bool expected)
        {
            Assert.AreEqual(expected, _narcissisticClass.Narcissistic(input));
        }
    }

    public class NarcissisticClass
    {
        // Mine
        public bool Narcissistic(int value)
        {
            return value == (int)value.ToString().Select(x => Math.Pow(Convert.ToInt32(x.ToString()), value.ToString().Length)).Sum(); 
        }
    }
}

    
