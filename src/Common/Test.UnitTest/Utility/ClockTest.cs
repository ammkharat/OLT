using System;
using System.Threading;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Utility
{
    [TestFixture]
    public class ClockTest
    {
        private long ticksInOneSecond;


        [SetUp]
        public void SetUp()
        {
            DateTime time1 = DateTimeFixture.DateTimeNow;
            DateTime time2 = time1.AddMilliseconds(1000);
            ticksInOneSecond = time2.Ticks - time1.Ticks;
        }

        [TearDown]
        public void TearDown()
        {
            Clock.UnFreeze();
        }

        [Test]
        public void UnfrozenClockShouldReportTheSameTimesAsDateTime()
        {
            DateTime expected = DateTimeFixture.DateTimeNow;
            DateTime actual = Clock.Now;
            Assert.IsTrue((actual.Ticks - expected.Ticks) < ticksInOneSecond);
        }

        [Test]
        public void UnfrozenClockTimesShouldAdvanceAsNormal()
        {
            DateTime time1 = Clock.Now;
            Thread.Sleep(50);
            DateTime time2 = Clock.Now;
            Assert.IsTrue(time2.CompareTo(time1) > 0);
        }

        [Test]
        public void FrozenClockShouldKeepReportingTheSameTime()
        {
            Clock.Freeze();
            DateTime time1 = Clock.Now;
            Thread.Sleep(50);
            DateTime time2 = Clock.Now;
            Assert.AreEqual(time1, time2);
        }

        [Test]
        public void FreezingClockWhenAlreadyFrozenDoesNotChangeFreezeTime()
        {
            Clock.Freeze();
            DateTime expected = Clock.Now;
            Thread.Sleep(50);
            Clock.Freeze();
            DateTime actual = Clock.Now;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void UnfreezingClockReportsSystemTimeAgain()
        {
            Clock.Freeze();
            Thread.Sleep(50);
            Assert.IsFalse(DateTimeFixture.DateTimeNow == Clock.Now);
            Clock.UnFreeze();
            Assert.AreEqual(DateTimeFixture.DateTimeNow, Clock.Now);
        }

        [Test]
        public void FreezingTimeShouldSetMillisecondsToZero()
        {
            Clock.Freeze();
            Assert.AreEqual(0, Clock.Now.Millisecond);
        }

        [Test]
        public void FreezingTimeShouldSetTicksToARoundNumber()
        {
            Clock.Freeze();
            long ticks = Clock.Now.Ticks;
            Assert.AreEqual(0, ticks%100000);
        }

        [Test]
        public void ShouldBeAbleToSetAndGetFrozenSpecificDateTime()
        {
            Clock.Freeze();
            Clock.Now = new DateTime(2000, 1, 1);
            DateTime expectedDateTime = new DateTime(2000, 1, 1);
            Assert.AreEqual(expectedDateTime, Clock.Now);
        }
    }
}