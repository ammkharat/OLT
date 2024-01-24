using System;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Utility;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Domain.Schedule.Calculators
{
    /// <summary>
    /// Summary description for RecurringDailyScheduleStrategyTest
    /// </summary>
    [TestFixture]
    public class RecurringDailyScheduleCalculatorTest
    {
        private RecurringDailyScheduleCalculator calculator;
        private OltTimeZoneInfo timeZone;
        private int frequency;

        [SetUp]
        public void SetUp()
        {
            timeZone = TimeZoneFixture.GetSarniaTimeZone();
            frequency = 2; // every 2 days
            Clock.TimeZone = SiteFixture.Sarnia().TimeZone;
            Clock.Freeze();
        }

        [TearDown]
        public void TearDown()
        {
            Clock.UnFreeze();
        }

        [Test] // Condition 1
            public void NextInvokeTimeShouldBeStartTimeIfItHasNotPassed()
        {
            Clock.Now = new DateTime(2000, 1, 1, 1, 0, 0);

            DateTime startDateTime = new DateTime(2000, 1, 1, 2, 0, 0);
            DateTime endDateTime = new DateTime(2000, 2, 2, 7, 0, 0);

            calculator = new RecurringDailyScheduleCalculator(timeZone, startDateTime, endDateTime, null, frequency);

            Assert.AreEqual(new DateTime(2000, 1, 1, 2, 0, 0), calculator.GetNextInvokeDateTime());
        }

        [Test] // Condition 2
            public void NextInvokeTimeShouldBeTheNextInvokeTimePastNowIfStartTimeHasPassedAndNowIsInRange()
        {
            Clock.Now = new DateTime(2000, 1, 1, 2, 1, 0);

            DateTime startDateTime = new DateTime(2000, 1, 1, 2, 0, 0);
            DateTime endDateTime = new DateTime(2000, 2, 2, 7, 0, 0);
            
            calculator = new RecurringDailyScheduleCalculator(timeZone, startDateTime, endDateTime, null, frequency);

            Assert.AreEqual(new DateTime(2000, 1, 3, 2, 0, 0), calculator.GetNextInvokeDateTime());
        }

        [Test]
        public void TestCurrentDateTimePastEndDateTime()
        {
            Clock.Now = new DateTime(2000, 1, 1, 3, 0, 0);

            DateTime startDateTime = new DateTime(1999, 12, 12, 1, 0, 0);
            DateTime endDateTime = new DateTime(2000, 01, 01, 2, 0, 0);

            calculator = new RecurringDailyScheduleCalculator(timeZone, startDateTime, endDateTime, null, frequency);

            Assert.AreEqual(Constants.PAST_END_TIME, calculator.GetNextInvokeDateTime());
        }

        [Test]
        public void TestNextInvokeDateTimePastEndDateTime()
        {
            Clock.Now = new DateTime(2000, 1, 1, 1, 30, 0);

            DateTime startDateTime = new DateTime(1999, 12, 12, 1, 0, 0);
            DateTime endDateTime = new DateTime(2000, 01, 01, 2, 0, 0);
            DateTime lastInvokedDateTime = new DateTime(2000, 1, 1, 1, 0, 0);

            calculator = new RecurringDailyScheduleCalculator(timeZone, startDateTime, endDateTime, lastInvokedDateTime, frequency);

            Assert.AreEqual(Constants.PAST_END_TIME, calculator.GetNextInvokeDateTime());
        }

        [Test]
        public void TestNextInvokeDateTimeCalculatedAgainstScheduleAndNotAgainstLastInvokedDateTime()
        {
            Clock.Now = new DateTime(2000, 1, 1, 10, 3, 0);

            DateTime startDateTime = new DateTime(2000, 1, 1, 10, 0, 0);
            DateTime endDateTime = new DateTime(2000, 12, 31, 12, 0, 0);
            DateTime lastInvokedDateTime = new DateTime(2000, 1, 1, 10, 2, 0);

            calculator = new RecurringDailyScheduleCalculator(timeZone, startDateTime, endDateTime, lastInvokedDateTime, frequency);

            DateTime nextInvokeTime = calculator.GetNextInvokeDateTime();

            Assert.AreEqual(new DateTime(2000, 1, 3, 10, 0, 0), nextInvokeTime);
        }

        // This is when the scheduler is down and the schedules that should have been fired
        // are now fired once the scheduler is restarted
        [Test]
        public void TestLastInvokedFourDaysAgoAndNextInvokeShouldBeThreeDaysAgo()
        {
            Clock.Now = new DateTime(2000, 1, 5, 9, 45, 0);
            
            DateTime startDateTime = new DateTime(2000, 1, 1, 10, 0, 0);
            DateTime endDateTime = new DateTime(2000, 12, 31, 12, 0, 0);
            DateTime lastInvokedDateTime = new DateTime(2000, 1, 1, 10, 0, 0);

            calculator = new RecurringDailyScheduleCalculator(timeZone, startDateTime, endDateTime, lastInvokedDateTime, frequency);

            Assert.AreEqual(new DateTime(2000, 1, 3, 10, 0, 0), calculator.GetNextInvokeDateTime());
        }

        [Test]
        public void TestFrequencyMoreThanOneDay()
        {
            Clock.Now = new DateTime(2000, 1, 1, 2, 1, 0);
            RecurringDailySchedule schedule =
                RecurringDailyScheduleFixture.CreateEvery2DaysFrom2AMTo10AM11BetweenJan1AndJan5In2000();

            calculator = new RecurringDailyScheduleCalculator(schedule.Site.TimeZone, schedule.StartDateTime, schedule.EndDateTime, schedule.LastInvokedDateTime, schedule.Frequency);

            DateTime nextInvokeTime = calculator.GetNextInvokeDateTime();
            DateTime expected = new DateTime(2000, 1, 3, 2, 0, 0);

            Assert.AreEqual(expected, nextInvokeTime);

            schedule.LastInvokedDateTime = expected;

            calculator = new RecurringDailyScheduleCalculator(schedule.Site.TimeZone, schedule.StartDateTime,
                                                            schedule.EndDateTime, schedule.LastInvokedDateTime, schedule.Frequency);
            
            nextInvokeTime = calculator.GetNextInvokeDateTime();
            
            expected = new DateTime(2000, 1, 5, 2, 0, 0);
            Assert.AreEqual(expected, nextInvokeTime);
        }

        [Test]
        public void TestMultipleCallsToCalculateNextInvokeDateTimeReturnSameValue()
        {
            Clock.Now = new DateTime(2000, 1, 1, 10, 0, 1);

            DateTime startDateTime = new DateTime(2000, 1, 1, 10, 0, 0);
            DateTime endDateTime = new DateTime(2000, 12, 31, 12, 0, 0);
            DateTime lastInvokedDateTime = new DateTime(2000, 1, 1, 10, 0, 0);

            calculator = new RecurringDailyScheduleCalculator(timeZone, startDateTime, endDateTime, lastInvokedDateTime, frequency);

            DateTime expected = new DateTime(2000, 1, 3, 10, 0, 0);
            DateTime nextInvokeTime = calculator.GetNextInvokeDateTime();

            Assert.AreEqual(expected, nextInvokeTime);

            // second call should return the same as the first
            nextInvokeTime = calculator.GetNextInvokeDateTime();

            Assert.AreEqual(expected, nextInvokeTime);

            // third call should return the same as the first
            nextInvokeTime = calculator.GetNextInvokeDateTime();

            Assert.AreEqual(expected, nextInvokeTime);

            // lots of other calls
            calculator.GetNextInvokeDateTime();
            calculator.GetNextInvokeDateTime();
            calculator.GetNextInvokeDateTime();
            calculator.GetNextInvokeDateTime();
            calculator.GetNextInvokeDateTime();
            nextInvokeTime = calculator.GetNextInvokeDateTime();

            // see, we don't hold state anymore!
            Assert.AreEqual(expected, nextInvokeTime);
        }

        [Test]
        public void OutOfDSTBoundaryTest()
        {
            Clock.Now = new DateTime(2000, 4, 2, 10, 0, 0);

            DateTime startDateTime = new DateTime(2000, 1, 1, 10, 0, 0);
            DateTime endDateTime = new DateTime(2000, 12, 31, 12, 0, 0);
            DateTime lastInvokedDateTime = new DateTime(2000, 4, 1, 10, 0, 0);

            calculator = new RecurringDailyScheduleCalculator(timeZone, startDateTime, endDateTime, lastInvokedDateTime, frequency);

            DateTime expected = new DateTime(2000, 4, 2, 10, 0, 0);
            DateTime nextInvokeTime = calculator.GetNextInvokeDateTime();

            Assert.AreEqual(expected, nextInvokeTime);
        }

        [Test]
        public void IntoDSTBoundaryTest()
        {
            Clock.Now = new DateTime(2000, 9, 29, 10, 0, 0);

            DateTime startDateTime = new DateTime(2000, 1, 1, 10, 0, 0);
            DateTime endDateTime = new DateTime(2000, 12, 31, 12, 0, 0);
            DateTime lastInvokedDateTime = new DateTime(2000, 9, 28, 10, 0, 0);

            calculator = new RecurringDailyScheduleCalculator(timeZone, startDateTime, endDateTime, lastInvokedDateTime, frequency);

            DateTime expected = new DateTime(2000, 9, 29, 10, 0, 0);
            DateTime nextInvokeTime = calculator.GetNextInvokeDateTime();

            Assert.AreEqual(expected, nextInvokeTime);
        }
        
        [Test]
        public void NextInvokeDateTimeSetToTomorrowOnRecurringDailyThatFires()
        {
            Clock.Now = new DateTime(2006, 6, 15, 10, 0, 0);

            DateTime startDateTime = new DateTime(2006, 6, 15, 17, 0, 0);

            calculator = new RecurringDailyScheduleCalculator(timeZone, startDateTime, DateTime.MaxValue, null, 1);
            DateTime expected = new DateTime(2006, 6, 15, 17, 0, 0);
            DateTime nextInvokeTime = calculator.GetNextInvokeDateTime();
            Assert.AreEqual(expected, nextInvokeTime);

            calculator = new RecurringDailyScheduleCalculator(timeZone, startDateTime, DateTime.MaxValue, nextInvokeTime, 1);
            expected = new DateTime(2006, 6, 16, 17, 0, 0);
            nextInvokeTime = calculator.GetNextInvokeDateTime();
            Assert.AreEqual(expected, nextInvokeTime);            
            
        }
    }
}