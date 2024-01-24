using System;
using System.Threading;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Domain
{
    [TestFixture]
    public class StopWatchTest
    {
        private StopWatch stopWatch;
        bool hasFired;

        [SetUp]
        public void Setup()
        {
            hasFired = false;
            stopWatch = new StopWatch(BlastoffHandler);
        }

        [Test][Ignore]
        public void CountDownTwoSecondsShouldCallMyHandlerInAboutTwoSeconds()
        {
            stopWatch.CountDown(2000, null);
            // sleep here a bit
            Thread.Sleep(1500);
            Assert.IsFalse(hasFired);
            Thread.Sleep(700);
            Assert.IsTrue(hasFired);
        }

        [Test]
        public void CountDownTwoSecondsShouldNotCallMyHandlerIfStopped()
        {
            stopWatch.CountDown(2000, null);
            // sleep here a bit
            Thread.Sleep(1500);
            Assert.IsFalse(hasFired);
            stopWatch.Stop();
            Thread.Sleep(700);
            Assert.IsFalse(hasFired);
        }

        void BlastoffHandler(DateTime? expectedEventExecutionTime)
        {
            hasFired = true;
        }
    }
}
