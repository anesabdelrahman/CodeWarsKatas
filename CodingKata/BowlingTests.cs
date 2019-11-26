using System;
using FluentAssertions;
using NUnit.Framework;

namespace CodingKata
{
    [TestFixture]
    public class BowlingTests
    {
        private BowlingService _bowlingService = new BowlingService();
        [SetUp]
        public void TestSetup()
        {
            //_bowlingService = new BowlingService();
        }

        [Test]
        [TestCase(1, 1)]
        [TestCase(2, 3)]
        [TestCase(3, 6)]
        [TestCase(4, 10)]
        public void WhenBowlShouldRecordScore(int input, int expectedScore)
        {
            _bowlingService.Roll(input);
            _bowlingService.Pins.Should().Be(expectedScore);
        }

        [Test]
        public void WhenFinshBowlingShouldShowScore()
        {
            _bowlingService.Score();
            _bowlingService.Pins.Should().Be(10);
        }
    }

    public class BowlingService
    {
        public int Pins { get; set; }
        public void Roll(int score)
        {
            Pins += score;
        }

        public int Score()
        {
            return Pins;
        }
    }
}