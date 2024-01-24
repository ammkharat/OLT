using System;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Utility;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Domain.Schedule.Calculators
{
    [TestFixture]
    public class SingleScheduleCalculatorTest
    {
        private OltTimeZoneInfo timeZone;
        SingleScheduleCalculator calculator;

        [SetUp]
        public void SetUp()
        {
            Clock.Freeze();
            Clock.TimeZone = TimeZoneFixture.GetMountainTimeZone();

            timeZone = TimeZoneFixture.GetMountainTimeZone();

        }

        [TearDown]
        public void TearDown()
        {
            Clock.UnFreeze();
            Clock.TimeZone = null;
        }

        [Test]
        public void NextInvokeTimeShouldBeTheStartTimeIfItHasntPassedYet()
        {
            Clock.Now = new DateTime(2000, 1, 1, 1, 0, 0);

            DateTime startDateTime = new DateTime(2000, 1, 1, 2, 0, 0);
            DateTime endDateTime = new DateTime(2000, 2, 2, 7, 0, 0);
            
            calculator = new SingleScheduleCalculator(timeZone, startDateTime, endDateTime);
            Assert.AreEqual(new DateTime(2000, 1, 1, 2, 0, 0), calculator.GetNextInvokeDateTime());
        }

        [Test]
        public void NextInvokeTimeShouldBeNowSinceStartTimeHasPassed()
        {
            Clock.Now = new DateTime(2000, 1, 1, 5, 0, 0);

            DateTime startDateTime = new DateTime(2000, 1, 1, 2, 0, 0);
            DateTime endDateTime = new DateTime(2000, 2, 2, 7, 0, 0);

            calculator = new SingleScheduleCalculator(timeZone, startDateTime, endDateTime);
            Assert.AreEqual(new DateTime(2000, 1, 1, 5, 0, 0), calculator.GetNextInvokeDateTime());
        }

        [Test]
        public void NextInvokeTimeShouldBeMaxIfEndDateHasPassed()
        {
            Clock.Now = new DateTime(2000, 2, 2, 7, 0, 1);

            DateTime startDateTime = new DateTime(2000, 1, 1, 2, 0, 0);
            DateTime endDateTime = new DateTime(2000, 2, 2, 7, 0, 0);

            calculator = new SingleScheduleCalculator(timeZone, startDateTime, endDateTime);
            Assert.AreEqual(Constants.PAST_END_TIME, calculator.GetNextInvokeDateTime());
        }

        [Test]
        public void ShouldAdjustNextInvokeDateTimeToTheFirstNextInvokeDateTime()
        {
            Clock.Now = new DateTime(2000, 1, 1, 0, 0, 0);
            SingleSchedule schedule = SingleScheduleFixture.CreateSingleScheduleOnOctober17From8AMTo12PM();
            SingleScheduleCalculator strategy = new SingleScheduleCalculator(schedule.Site.TimeZone, schedule.StartDateTime, schedule.EndDateTime);
            Assert.AreEqual(new DateTime(2005, 10, 17, 8, 0, 0), strategy.GetNextInvokeDateTime());
            Assert.AreEqual(new DateTime(2005, 10, 17, 8, 0, 0), strategy.GetNextInvokeDateTime());
            Assert.AreEqual(new DateTime(2005, 10, 17, 8, 0, 0), strategy.GetNextInvokeDateTime());
            Clock.Now = new DateTime(2005, 10, 17, 12, 0, 1);
            Assert.AreEqual(Constants.PAST_END_TIME, strategy.GetNextInvokeDateTime());
        }

        [Test]
        public void ShouldHaveNextInvokedDateTimeEqualToJune32006AtNoon()
        {
            Clock.Now = new DateTime(2006, 7, 3, 11, 35, 0);
            Clock.TimeZone = TimeZoneFixture.GetMountainTimeZone();

            DateTime startDateTime = new DateTime(2006, 7, 3, 12, 0, 0);
            DateTime endDateTime = new DateTime(2006, 7, 3, 13, 0, 0);
            SingleScheduleCalculator strategy = new SingleScheduleCalculator(timeZone, startDateTime, endDateTime);
            Assert.AreEqual(new DateTime(2006, 7, 3, 12, 0, 0), strategy.GetNextInvokeDateTime());
        }

        [Test]
        public void ShouldHaveNextInvokedDateTimeEqualToJune32006At_1PM()
        {
            Clock.Now = new DateTime(2006, 7, 3, 11, 35, 0);
            Clock.TimeZone = TimeZoneFixture.GetMountainTimeZone();

            DateTime startDateTime = new DateTime(2006, 7, 3, 13, 0, 0);
            DateTime endDateTime = new DateTime(2006, 7, 3, 14, 0, 0);
            SingleScheduleCalculator strategy = new SingleScheduleCalculator(timeZone, startDateTime, endDateTime);
            Assert.AreEqual(new DateTime(2006, 7, 3, 13, 0, 0), strategy.GetNextInvokeDateTime());
        }

        [Test]
        public void ShouldGetNextInvokeDateTimeWhenStartAndEndTimesAreTheSame()
        {
            Clock.Now = new DateTime(2010, 08, 01, 15, 38, 00);
            Clock.TimeZone = TimeZoneFixture.GetMountainTimeZone();
            DateTime midnight = new DateTime(2010, 09, 02, 0, 0, 0);
            SingleScheduleCalculator singleScheduleCalculator = new SingleScheduleCalculator(timeZone, midnight, midnight);
            DateTime nextInvokeDateTime = singleScheduleCalculator.GetNextInvokeDateTime();
            Assert.That(nextInvokeDateTime, Is.EqualTo(midnight));
        }

    }
}