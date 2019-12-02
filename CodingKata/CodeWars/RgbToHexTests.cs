using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using NUnit.Framework;

namespace CodingKata.CodeWars
{
    public class RgbToHexTests
    {
        private RgbToHex _rgbToHex;

        [SetUp]
        public void SetUp()
        {
            _rgbToHex = new RgbToHex();
        }

        [TearDown]
        public void TearDown()
        {
            _rgbToHex = null;
        }

        [Test]
        [TestCase(255,255,255, "FFFFFF")]
        [TestCase(255, 255, 300, "FFFFFF")]
        [TestCase(0,0,0, "000000")]
        [TestCase(148, 0, 211, "9400D3")]
        [TestCase(148, -20, 211, "9400D3")]
        [TestCase(144, 195, 212, "90C3D4")]
        [TestCase(212, 53, 12, "D4350C")]
        public void Test1(int r, int g, int b, string hex)
        {
            Assert.AreEqual(hex, _rgbToHex.Rgb2(r,g,b));
        }
    }

    public class RgbToHex
    {
        // Mine
        public string Rgb(int r, int g, int b)
        {
            var numbers = new List<int>{r,g,b};
            for (var i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] < 0)
                {
                    numbers[i] = 0;
                    continue;
                }

                if (numbers[i] > 255)
                {
                    numbers[i] = 255;
                }
            }

            return $"{numbers[0]:X2}{numbers[1]:X2}{numbers[2]:X2}";
        }

        public string Rgb2(int r, int g, int b)
        {
           return $"{Math.Clamp(r, 0, 255):X2}{Math.Clamp(g, 0, 255):X2}{Math.Clamp(b, 0, 255):X2}";
        }
    }
}

    
