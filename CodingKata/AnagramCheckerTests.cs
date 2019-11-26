using FluentAssertions;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using NUnit.Framework;

namespace CodingKata
{

    [TestFixture]
    public class AnagramCheckerTests
    {
        private AnagramChecker _anagramChecker;

        [SetUp]
        public void TestSetup()
        {
            _anagramChecker = new AnagramChecker();
        }

        [Test]
        [TestCase("anes", "sena", true)]
        [TestCase("aaas", "saaa", true)]
        [TestCase("sasa", "sdff", false)]
        [TestCase("anes", "sen1", false)]
        public void WhenTwoStringsAreAnagram_ShouldReturnTrue(string firstString, string secondString, bool expected)
        {
            var result = _anagramChecker.CheckAnagram(firstString, secondString);
            result.Should().Be(expected);
        }
    }

    public class AnagramChecker
    {
        public bool CheckAnagram(string firstString, string secondString)
        {
            if (firstString.Length != secondString.Length) return false;
            var string2ToCheckOff = secondString.ToCharArray();

            foreach (var t1 in firstString)
            {
                var letterFound = false;
                foreach (var t in string2ToCheckOff)
                {
                    if (t1 != t) continue;
                    letterFound = true;
                    break;
                }

                if (!letterFound) return false;
            }

            return true;
        }
    }
}
