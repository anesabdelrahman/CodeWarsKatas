using System.Linq;
using NUnit.Framework;

namespace CodingKata.CodeWars
{
    public class PigItTests
    {
        private PigItKata _pigItKata;

        [SetUp]
        public void SetUp()
        {
            _pigItKata = new PigItKata();
        }

        [TearDown]
        public void TearDown()
        {
            _pigItKata = null;
        }

        [Test]
        public void Tests()
        {
            Assert.AreEqual("igPay atinlay siay oolcay", _pigItKata.PigIt2("Pig latin is cool"));
            Assert.AreEqual("hisTay siay ymay tringsay", _pigItKata.PigIt2("This is my string"));

        }
    }

    public class PigItKata
    {
        // Mine
        public string PigIt(string str)
        {
            return string.Join(' ', str.Split(' ').Select(x => new string(x.Append(x.ElementAt(0)).Skip(1).Concat("ay").ToArray())));
        }

        //Best practice - other
        public string PigIt2(string str)
        {
            return string.Join(" ", str.Split(' ').Select(w => w.Substring(1) + w[0] + "ay"));
        }
    }
}

    
