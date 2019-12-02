using System;
using System.Linq;
using NUnit.Framework;

namespace CodingKata.CodeWars
{
    public class WhichAreInTests
    {
        private WhichAreIn _whichAreIn;

        [SetUp]
        public void SetUp()
        {
            _whichAreIn = new WhichAreIn();
        }

        [TearDown]
        public void TearDown()
        {
            _whichAreIn = null;
        }

        [Test]
        public void Test1()
        {
            var a1 = new[] { "arp", "live", "strong" };
            var a2 = new[] { "lively", "alive", "harp", "sharp", "armstrong" };
            var r = new[] { "arp", "live", "strong" };

            var a3 = new[] { "tarp", "mice", "bull" };
            var a4 = new[] { "lively", "alive", "harp", "sharp", "armstrong" };
            var r2 = new string[0];
            Assert.AreEqual(r, WhichAreIn.InArray(a1, a2));
            Assert.AreEqual(r2, WhichAreIn.InArray(a3, a4));
        }
    }

    public class WhichAreIn
    {
        // Mine
        public static string[] InArray(string[] array1, string[] array2)
        {
            return array1.Where(x => array2.Any(y => y.Contains(x))).Distinct().OrderBy(y => y).ToArray(); 
        }
    }
}

    
