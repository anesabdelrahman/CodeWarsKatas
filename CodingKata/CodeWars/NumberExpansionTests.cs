using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using NUnit.Framework;

namespace CodingKata.CodeWars
{
    public class NumberExpansionTests
    {
        private NumberExpansion _NumberExpansion;

        [SetUp]
        public void SetUp()
        {
            _NumberExpansion = new NumberExpansion();
        }

        [TearDown]
        public void TearDown()
        {
            _NumberExpansion = null;
        }

        [Test]
        [TestCase(12, "10 + 2")]
        [TestCase(42, "40 + 2")]
        [TestCase(70304, "70000 + 300 + 4")]
        [TestCase(6808690, "6000000 + 800000 + 8000 + 600 + 90")]
        public void Test1(long input, string expected)
        {
            Assert.AreEqual(expected, _NumberExpansion.ExpandedForm(input));
        }
    }

    public class NumberExpansion
    {
        public string ExpandedForm(long num)
        {
            var result = string.Empty;
            var numberLength = num.ToString().Length - 1;
           
            foreach (var digit in num.ToString())
            {
                if (digit.ToString() == "0")
                {
                    numberLength--;
                    continue;
                }

                result += $"{Convert.ToInt32(digit.ToString()) * Math.Pow(10, numberLength--)}";

                if (numberLength > -1)
                {
                    result += " + ";
                }
            }

            return result.EndsWith(" + ") ? result.Remove(result.LastIndexOf(" + ")) : result;
        }
    }
}

    
