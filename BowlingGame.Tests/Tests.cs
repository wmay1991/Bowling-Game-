using BowlingGame6215;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingGame.Tests
{
    [TestFixture]
    public class Tests
    {
        private Game g;
        [SetUp]
        public void Setup()
        {
            g = new Game();
        }

        [Test]
        public void TestforOneRoll()
        {
            g.Roll(3);
            Assert.AreEqual(3, g.Score());
        }

        [Test]
        public void TestforGutterGame()
        {
            RollMany(20, 0);
            Assert.AreEqual(0, g.Score());
        }

        [Test]
        public void TestforAllOnes()
        {
            RollMany(20, 1);
            Assert.AreEqual(20, g.Score());
        }

        [Test]
        public void TestforSpare()
        {
            RollSpare();
            g.Roll(3);
            Assert.AreEqual(16, g.Score());
        }

        [Test]
        public void TestforStrike()
        {
            g.Roll(10);
            g.Roll(3);
            g.Roll(4);
            Assert.AreEqual(24, g.Score());
        }

        private void RollMany(int r, int pins)
        {
            for (var i = 0; i < r; i++)
            {
                g.Roll(pins);
            }
        }

        private void RollSpare()
        {
            g.Roll(5);
            g.Roll(5);
        }
    }
}
