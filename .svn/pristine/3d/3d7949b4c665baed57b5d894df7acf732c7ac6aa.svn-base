using System;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Utility;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Domain.Schedule.Calculators
{
    /// <summary>
    /// Summary description for RecurringHourlyScheduleCalculatorTest
    /// </summary>
    [TestFixture]
    public class RecurringHourlyScheduleCalculatorTest
    {
        private RecurringHourlyScheduleCalculator calculator;
        private OltTimeZoneInfo timeZone;
        private int frequency;

        [SetUp]
        public void SetUp()
        {
            Clock.Freeze();
            Clock.TimeZone = SiteFixture.Sarnia().TimeZone;

            timeZone = TimeZoneFixture.GetSarniaTimeZone();
            frequency = 2; // every 2 hours
        }

        [TearDown]
        public void TearDown()
        {
            Clock.UnFreeze();
        }

        [Test]
        public void NextInvokeTimeShouldBeStartTimeIfItHasNotPassed()
        {
            Clock.Now = new DateTime(2000, 1, 1, 1, 0, 0);

            DateTime startDateTime = new DateTime(2000, 1, 1, 2, 0, 0);
            DateTime endDateTime = new DateTime(2000, 1, 1, 7, 0, 0);

            calculator = new RecurringHourlyScheduleCalculator(timeZone, startDateTime, endDateTime, null, frequency);

            Assert.AreEqual(startDateTime, calculator.GetNextInvokeDateTime());
        }

        [Test]
        public void NextInvokeTimeShouldBeNowIfStartTimeHasPassedAndNowIsInRange()
        {
            Clock.Freeze();
            Clock.Now = new DateTime(2000, 1, 1, 2, 20, 0);

            DateTime startDateTime = new DateTime(2000, 1, 1, 2, 0, 0);
            DateTime endDateTime = new DateTime(2000, 1, 1, 7, 0, 0);

            calculator = new RecurringHourlyScheduleCalculator(timeZone, startDateTime, endDateTime, null, frequency);

            Assert.AreEqual(new DateTime(2000, 1, 1, 4, 0, 0), calculator.GetNextInvokeDateTime());
            Clock.UnFreeze();
        }


        [Test]
        public void NextInvokeTimeShouldBeFirstTimeNextDayIfNowIsPassedRangeInDay()
        {
            Clock.Now = new DateTime(2000, 1, 1, 7, 30, 0);

            DateTime startDateTime = new DateTime(2000, 1, 1, 2, 0, 0);
            DateTime endDateTime = new DateTime(2000, 1, 4, 7, 0, 0);
            DateTime lastInvokedDateTime = new DateTime(2000, 1, 1, 7, 0, 0);

            calculator =
                new RecurringHourlyScheduleCalculator(timeZone, startDateTime, endDateTime, lastInvokedDateTime,
                                                      frequency);

            Assert.AreEqual(new DateTime(2000, 1, 2, 2, 0, 0), calculator.GetNextInvokeDateTime());
        }

        [Test]
        public void SeriesOfNextInvokeTimesShouldIncrementByOneHourEachTime()
        {
            Clock.Now = new DateTime(2000, 1, 1, 1, 30, 0);

            DateTime startDateTime = new DateTime(2000, 1, 1, 2, 0, 0);
            DateTime endDateTime = new DateTime(2000, 1, 4, 7, 0, 0);

            calculator = new RecurringHourlyScheduleCalculator(timeZone, startDateTime, endDateTime, null, frequency);
            Assert.AreEqual(new DateTime(2000, 1, 1, 2, 0, 0), calculator.GetNextInvokeDateTime());

            DateTime lastInvokedDateTime = new DateTime(2000, 1, 1, 2, 0, 1);
            calculator =
                new RecurringHourlyScheduleCalculator(timeZone, startDateTime, endDateTime, lastInvokedDateTime,
                                                      frequency);
            Assert.AreEqual(new DateTime(2000, 1, 1, 4, 0, 0), calculator.GetNextInvokeDateTime());

            lastInvokedDateTime = new DateTime(2000, 1, 1, 4, 0, 1);
            calculator =
                new RecurringHourlyScheduleCalculator(timeZone, startDateTime, endDateTime, lastInvokedDateTime,
                                                      frequency);
            Assert.AreEqual(new DateTime(2000, 1, 1, 6, 0, 0), calculator.GetNextInvokeDateTime());

            lastInvokedDateTime = new DateTime(2000, 1, 1, 6, 0, 1);
            calculator =
                new RecurringHourlyScheduleCalculator(timeZone, startDateTime, endDateTime, lastInvokedDateTime,
                                                      frequency);
            Assert.AreEqual(new DateTime(2000, 1, 2, 2, 0, 0), calculator.GetNextInvokeDateTime());

            lastInvokedDateTime = new DateTime(2000, 1, 2, 2, 0, 1);
            calculator =
                new RecurringHourlyScheduleCalculator(timeZone, startDateTime, endDateTime, lastInvokedDateTime,
                                                      frequency);
            Assert.AreEqual(new DateTime(2000, 1, 2, 4, 0, 0), calculator.GetNextInvokeDateTime());
        }


        [Test]
        public void NextInvokeTimeShouldBeEndOfTimeIfItHasPassedEndDateTime()
        {
            Clock.Now = new DateTime(2000, 1, 5, 1, 0, 0);

            DateTime startDateTime = new DateTime(2000, 1, 1, 2, 0, 0);
            DateTime endDateTime = new DateTime(2000, 1, 4, 7, 0, 0);

            calculator = new RecurringHourlyScheduleCalculator(timeZone, startDateTime, endDateTime, null, frequency);

            Assert.AreEqual(Constants.PAST_END_TIME, calculator.GetNextInvokeDateTime());
        }
        
        [Test]
        public void NextInvokeFor12HourSchedule()
        {
            // Noon in Sarnia
            Clock.Now = new DateTime(2000, 1, 1, 14, 0, 0);

            DateTime startDateTime = new DateTime(2000, 1, 1, 16, 0, 0);
            DateTime endDateTime = new DateTime(2000, 1, 3, 4, 0, 0);

            calculator = new RecurringHourlyScheduleCalculator(timeZone, startDateTime, endDateTime, null, 12);

            DateTime firstInvokeDateTime = new DateTime(2000, 1, 1, 16, 0, 0);
            Assert.AreEqual(firstInvokeDateTime, calculator.GetNextInvokeDateTime());

            // 4:01pm in Sarnia
            Clock.Now = new DateTime(2000, 1, 1, 16, 0, 1);
            
            calculator = new RecurringHourlyScheduleCalculator(timeZone, startDateTime, endDateTime, firstInvokeDateTime, 12);
            Assert.AreEqual(new DateTime(2000, 1, 2, 4, 0, 0), calculator.GetNextInvokeDateTime());
        }
    }
}