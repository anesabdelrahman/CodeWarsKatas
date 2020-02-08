using System;
using System.Reflection.PortableExecutable;
using NUnit.Framework;

namespace CodingKata.CodeWars
{
    [TestFixture]
    public class PerfectPowerTests
    {
        private PerfectPower _PerfectPower;
        [SetUp]
        public void Initialize() => _PerfectPower = new PerfectPower();


        [Test]
        public void Test0()
        {
            Assert.IsNull(_PerfectPower.IsPerfectPower(0), "0 is not a perfect number");
        }

        [Test]
        public void Test1()
        {
            Assert.IsNull(_PerfectPower.IsPerfectPower(1), "1 is not a perfect number");
        }

        [Test]
        public void Test2()
        {
            Assert.IsNull(_PerfectPower.IsPerfectPower(2), "2 is not a perfect number");
        }

        [Test]
        public void Test3()
        {
            Assert.IsNull(_PerfectPower.IsPerfectPower(3), "3 is not a perfect number");
        }

        [Test]
        public void Test4()
        {
            Assert.AreEqual((2, 2), _PerfectPower.IsPerfectPower(4), "4 = 2^2");
        }

        [Test]
        public void Test5()
        {
            Assert.IsNull(_PerfectPower.IsPerfectPower(5), "5 is not a perfect power");
        }

        [Test]
        public void Test8()
        {
            Assert.AreEqual((2, 3), _PerfectPower.IsPerfectPower(8), "8 = 2^3");
        }

        [Test]
        public void Test9()
        {
            Assert.AreEqual((3, 2), _PerfectPower.IsPerfectPower(9), "9 = 3^2");
        }

        [Test]
        public void Test1000()
        {
            Assert.AreEqual((10, 3), _PerfectPower.IsPerfectPower(1000), "1000 = 10^3");
        }

        [Test]
        public void Test1000000()
        {
            Assert.AreEqual((1000, 2), _PerfectPower.IsPerfectPower(1000000), "1000 = 10^6");
        }

        [Test]
        public void Test25()
        {
            Assert.AreEqual((5, 2), _PerfectPower.IsPerfectPower(25), "25 = 5^2");
        }

        [Test]
        public void Test625()
        {
            Assert.AreEqual((25, 2), _PerfectPower.IsPerfectPower(625), "625 = 5^4");
        }

        [Test]
        public void Test4913()
        {
            Assert.AreEqual((17, 3), _PerfectPower.IsPerfectPower(4913), "4913 = 17^3");
        }

        [Test]
        public void TestRand1()
        {
            Assert.AreEqual((3263, 2), _PerfectPower.IsPerfectPower(10647169), "10,647,169 = 3263^2");
        }

        [Test]
        public void TestRand2()
        {
            Assert.AreNotEqual((1967, 2), _PerfectPower.IsPerfectPower(3869893), "1967^2!=3869893");
        }

        [Test]
        public void TestRand362797056()
        {
            Assert.AreEqual((6, 11), _PerfectPower.IsPerfectPower(362797056), "6^11!=362797056");
        }

        [Test]
        public void TestRand2222()
        {
            Assert.IsNotNull(_PerfectPower.IsPerfectPower(19683), "");
        }

        [Test]
        public void TestRand_1()
        {
            Assert.AreEqual((12, 7), _PerfectPower.IsPerfectPower(35831808), "");
        }

        [Test]
        public void TestRand_2()
        {
            Assert.NotNull(_PerfectPower.IsPerfectPower(4741632), "");
        }

        [Test]
        public void TestRand_3()
        {
            Assert.AreEqual((216, 3), _PerfectPower.IsPerfectPower(10077696), "");
        }

        [Test]
        public void TestUpTo500()
        {
            var pp = new int[] { 4, 8, 9, 16, 25, 27, 32, 36, 49, 64, 81, 100, 121, 125, 128, 144, 169, 196, 216, 225, 243, 256, 289, 324, 343, 361, 400, 441, 484 };
            foreach (var i in pp)
                Assert.IsNotNull(_PerfectPower.IsPerfectPower(i), $"{i} is a perfect power");
        }
    }

    public class PerfectPower
    {
        public (int, int)? IsPerfectPower(int n)
        {
            var border = (int)Math.Sqrt(n);
            for (var i = 2; i <= border; border--)
            {
                var deg = Convert.ToInt32(Math.Log(n, border));
                if (Math.Pow(border, deg) == n)
                {
                    return (border, deg);
                }
            }
            return null;
        }
    }
}

