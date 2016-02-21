using System.Collections.Generic;
using NUnit.Framework;

namespace ScoreCalculator.Test
{
    [TestFixture]
    public class ScoreCalculatorTestFixture
    {
        [Test]
        public void CalculateScore_If_AllFramesAreZero()
        {
            var frames = new List<Frame>();
            for (int i = 0; i < 10; i++)
            {
                frames.Add(new Frame());
            }

            var result = ScoreCalculator.CalculateScore(frames);
            Assert.AreEqual(0,result);
        }

        [Test]
        public void CalculateScore_If_AllFramesAreOne()
        {
            var frames = new List<Frame>();
            for (int i = 0; i < 10; i++)
            {
                frames.Add(new Frame() { First = 1, Second = 1 });
            }

            var result = ScoreCalculator.CalculateScore(frames);
            Assert.AreEqual(20, result);
        }

        [Test]
        public void CalculateScore_if_FirstFrameStrike_OthersAreZero()
        {
            var frames = new List<Frame>();
            frames.Add(new Frame(){First = 10});
            for (int i = 0; i < 9; i++)
            {
                frames.Add(new Frame());
            }

            var result = ScoreCalculator.CalculateScore(frames);
            Assert.AreEqual(10, result);
        }

        [Test]
        public void CalculateScore_if_FirstFrameSpare_OthersAreZero()
        {
            var frames = new List<Frame>();
            frames.Add(new Frame() { First = 5, Second = 5});
            for (int i = 0; i < 9; i++)
            {
                frames.Add(new Frame());
            }

            var result = ScoreCalculator.CalculateScore(frames);
            Assert.AreEqual(10, result);
        }

        [Test]
        public void CalculateScore_if_AllFramesAreStrike()
        {
            var frames = new List<Frame>();
            for (int i = 0; i < 9; i++)
            {
                frames.Add(new Frame(){ First = 10});
            }
            frames.Add(new Frame() { First = 10, Second = 10, Third = 10});

            var result = ScoreCalculator.CalculateScore(frames);
            Assert.AreEqual(220, result);
        }

        [Test]
        public void CalculateScore_if_AllFramesAreSpareAndZeroBonus()
        {
            var frames = new List<Frame>();
            for (int i = 0; i < 9; i++)
            {
                frames.Add(new Frame() { First = 5, Second = 5});
            }
            frames.Add(new Frame() { First = 5, Second = 5, Third = 0 });

            var result = ScoreCalculator.CalculateScore(frames);
            Assert.AreEqual(145, result);
        }
    }
}
