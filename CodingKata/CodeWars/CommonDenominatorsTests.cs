using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace CodingKata.CodeWars
{
    public class CommonDenominatorsTests
    {
        private CommonDenominator _commonDenominator;

        [SetUp]
        public void SetUp()
        {
            _commonDenominator = new CommonDenominator();
        }

        [TearDown]
        public void TearDown()
        {
            _commonDenominator = null;
        }

        [Test]
        public void Test()
        {
            var lst = new long[,] { { 1, 2 }, { 1, 3 }, { 1, 4 } };
            var lst2 = new long[,] { { 69, 130 }, { 87, 1310 }, { 3, 4 } };
            Assert.AreEqual("(6,12)(4,12)(3,12)", CommonDenominator.convertFrac1(lst));
            Assert.AreEqual("(18078,34060)(2262,34060)(25545,34060)", CommonDenominator.convertFrac1(lst2));
        }
    }

    public class CommonDenominator
    {
        //One of the other solution
        public static string convertFrac1(long[,] lst)
        {
            var indices = Enumerable.Range(0, lst.GetLength(0));
            var d = indices.Aggregate(1L, (a, i) => a * lst[i, 1] / gcd(a, lst[i, 1]));
            return string.Concat(indices.Select(i => $"({d * lst[i, 0] / lst[i, 1]},{d})"));
        }

        private static long gcd(long a, long b) => b == 0 ? a : gcd(b, a % b);

        public static string convertFrac(long[,] lst)
        {
            var fractions = new List<Fraction>();
            for (var i = 0; i <= lst.GetUpperBound(0); i++)
            {
                fractions.Add(new Fraction
                {
                    Numerator = lst[i, 0],
                    Denominator = lst[i, 1],
                    Multiples = new List<long>()
                });
            }

            foreach (var fraction in fractions)
            {
                for (var i = 1; i < 1000001; i++)
                {
                    fraction.Multiples.Add(fraction.Denominator * i);
                }
            }

            var commonDenominators = new List<long>();
            for (var i = 0; i < fractions.Count -1; i++)
            {
                commonDenominators = fractions[i].Multiples.Intersect(fractions[i + 1].Multiples).ToList();
            }

            commonDenominators = commonDenominators.Where(x => fractions.All(y => x % y.Denominator == 0)).ToList();
            var result = string.Empty;
            foreach (var fraction in fractions)
            {
                result += $"({(commonDenominators.Min() / fraction.Denominator) * fraction.Numerator},{commonDenominators.Min()})";
            }

            return result;
        }

        public class Fraction
        {
            public long Denominator { get; set; }
            public long Numerator { get; set; }
            public List<long> Multiples { get; set; }

        }
    }
}

    
