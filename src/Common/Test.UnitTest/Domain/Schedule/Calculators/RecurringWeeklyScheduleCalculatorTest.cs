using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Utility;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Domain.Schedule.Calculators
{
    /// <summary>
    /// Summary description for RecurringWeeklyScheduleStrategyTest
    /// </summary>
    [TestFixture]
    public class RecurringWeeklyScheduleCalculatorTest
    {
        private RecurringWeeklyScheduleCalculator calculator;
        private OltTimeZoneInfo timeZone;
        private int frequency;
        List<DayOfWeek> daysofWeek;

        [SetUp]
        public void SetUp()
        {
            timeZone = TimeZoneFixture.GetSarniaTimeZone();
            frequency = 1; // every month
            daysofWeek = new List<DayOfWeek>();
            daysofWeek.Add(DayOfWeek.Monday);
            daysofWeek.Add(DayOfWeek.Friday);
            
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
            Clock.Now = new DateTime(1999, 12, 31, 1, 0, 0);

            DateTime startDateTime = new DateTime(2000, 1, 1, 2, 0, 0);
            DateTime endDateTime = new DateTime(2000, 10, 1, 7, 0, 0);
            
            calculator = new RecurringWeeklyScheduleCalculator(timeZone, startDateTime, endDateTime, null, frequency, daysofWeek);

            Assert.AreEqual(new DateTime(2000, 1, 3, 2, 0, 0), calculator.GetNextInvokeDateTime());
        }

        [Test] // Condition 2
        public void NextInvokeTimeShouldBeTheNextInvokeTimePastNowIfStartTimeHasPassedAndNowIsInRange()
        {
            Clock.Now = new DateTime(2000, 1, 1, 5, 0, 0);

            DateTime startDateTime = new DateTime(2000, 1, 1, 2, 0, 0);
            DateTime endDateTime = new DateTime(2000, 10, 1, 7, 0, 0);

            calculator = new RecurringWeeklyScheduleCalculator(timeZone, startDateTime, endDateTime, null, frequency, daysofWeek);

            Assert.AreEqual(new DateTime(2000, 1, 3, 2, 0, 0), calculator.GetNextInvokeDateTime());
        }

        [Test]
        public void TestCurrentDateTimePastEndDateTime()
        {
            Clock.Now = new DateTime(2000, 10, 1, 7, 0, 1);

            DateTime startDateTime = new DateTime(2000, 1, 1, 2, 0, 0);
            DateTime endDateTime = new DateTime(2000, 10, 1, 7, 0, 0);

            calculator = new RecurringWeeklyScheduleCalculator(timeZone, startDateTime, endDateTime, null, frequency, daysofWeek);

            Assert.AreEqual(Constants.PAST_END_TIME, calculator.GetNextInvokeDateTime());
        }

        [Test]
        public void TestNextInvokeDateTimePastEndDateTime()
        {
            Clock.Now = new DateTime(2000, 1, 1, 2, 0, 0);

            DateTime startDateTime = new DateTime(2000, 1, 1, 2, 0, 0);
            DateTime endDateTime = new DateTime(2000, 10, 1, 7, 0, 0);
            DateTime lastInvokedDateTime = new DateTime(2000, 10, 1, 6, 0, 0);

            calculator = new RecurringWeeklyScheduleCalculator(timeZone, startDateTime, endDateTime, lastInvokedDateTime, frequency, daysofWeek);

            Assert.AreEqual(Constants.PAST_END_TIME, calculator.GetNextInvokeDateTime());
        }

        [Test]
        public void TestNextInvokeDateTimeCalculatedAgainstScheduleAndNotAgainstLastInvokedDateTime()
        {
            Clock.Now = new DateTime(2000, 1, 1, 2, 0, 0);

            DateTime startDateTime = new DateTime(2000, 1, 1, 2, 0, 0);
            DateTime endDateTime = new DateTime(2000, 10, 1, 7, 0, 0);
            DateTime lastInvokedDateTime = new DateTime(2000, 1, 3, 2, 2, 0);

            calculator = new RecurringWeeklyScheduleCalculator(timeZone, startDateTime, endDateTime, lastInvokedDateTime, frequency, daysofWeek);

            Assert.AreEqual(new DateTime(2000, 1, 7, 2, 0, 0), calculator.GetNextInvokeDateTime());
        }

        // This is when the scheduler is down and the schedules that should have been fired
        // are now fired once the scheduler is restarted
        [Test]
        public void TestLastInvokedFourDaysAgoAndNextInvokeShouldBeThreeDaysAgo()
        {
            Clock.Now = new DateTime(2000, 2, 1, 2, 0, 0);

            DateTime startDateTime = new DateTime(2000, 1, 1, 2, 0, 0);
            DateTime endDateTime = new DateTime(2000, 10, 1, 7, 0, 0);
            DateTime lastInvokedDateTime = new DateTime(2000, 1, 7, 2, 2, 0);

            calculator = new RecurringWeeklyScheduleCalculator(timeZone, startDateTime, endDateTime, lastInvokedDateTime, frequency, daysofWeek);

            Assert.AreEqual(new DateTime(2000, 1, 10, 2, 0, 0), calculator.GetNextInvokeDateTime());
        }

        [Test]
        public void TestMultipleCallsToCalculateNextInvokeDateTimeReturnSameValue()
        {
            Clock.Now = new DateTime(2000, 2, 1, 2, 0, 0);

            DateTime startDateTime = new DateTime(2000, 1, 1, 2, 0, 0);
            DateTime endDateTime = new DateTime(2000, 10, 1, 7, 0, 0);
            DateTime lastInvokedDateTime = new DateTime(2000, 1, 7, 2, 2, 0);

            calculator = new RecurringWeeklyScheduleCalculator(timeZone, startDateTime, endDateTime, lastInvokedDateTime, frequency, daysofWeek);
            DateTime expected = new DateTime(2000, 1, 10, 2, 0, 0);

            Assert.AreEqual(expected, calculator.GetNextInvokeDateTime());
            Assert.AreEqual(expected, calculator.GetNextInvokeDateTime());
            Assert.AreEqual(expected, calculator.GetNextInvokeDateTime());

            // lots of other calls
            calculator.GetNextInvokeDateTime();
            calculator.GetNextInvokeDateTime();
            calculator.GetNextInvokeDateTime();
            calculator.GetNextInvokeDateTime();
            calculator.GetNextInvokeDateTime();
            calculator.GetNextInvokeDateTime();

            // see, we don't hold state anymore!
            Assert.AreEqual(expected, calculator.GetNextInvokeDateTime());
        }

        [Test]
        public void NextInvokeTimeShouldBeTheFirstMondayIfItHasNotPassed()
        {
            Clock.Now = new DateTime(2000, 1, 1, 1, 0, 0); //saturday

            DateTime startDateTime = new DateTime(2000, 1, 1, 2, 0, 0);
            DateTime endDateTime = new DateTime(2000, 10, 1, 14, 0, 0);

            calculator = new RecurringWeeklyScheduleCalculator(timeZone, startDateTime, endDateTime, null, frequency, daysofWeek);

            Assert.AreEqual(new DateTime(2000, 1, 3, 2, 0, 0), calculator.GetNextInvokeDateTime());
        }


        [Test]
        public void NextInvokeTimeShouldBeNowIfStartTimeHasPassedAndNowIsInRange()
        {
            Clock.Now = new DateTime(2000, 1, 3, 2, 0, 1); //saturday

            DateTime startDateTime = new DateTime(2000, 1, 1, 2, 0, 0);
            DateTime endDateTime = new DateTime(2000, 10, 1, 14, 0, 0);

            calculator = new RecurringWeeklyScheduleCalculator(timeZone, startDateTime, endDateTime, null, frequency, daysofWeek);

            Assert.AreEqual(new DateTime(2000, 1, 7, 2, 0, 0), calculator.GetNextInvokeDateTime());
        }

        [Test]
        public void NextInvokeTimeShouldBe2WeeksAfterTheFirstFridayIsTriggers()
        {
            Clock.Now = new DateTime(2000, 1, 7, 2, 0, 0);

            int testfrequency = 2; // every 2 week
            DateTime startDateTime = new DateTime(2000, 1, 1, 2, 0, 0);
            DateTime endDateTime = new DateTime(2000, 10, 1, 14, 0, 0);
            DateTime lastInvokedDateTime = new DateTime(2000, 1, 7, 2, 0, 1);

            calculator = new RecurringWeeklyScheduleCalculator(timeZone, startDateTime, endDateTime, lastInvokedDateTime, testfrequency, daysofWeek);

            Assert.AreEqual(new DateTime(2000, 1, 17, 2, 0, 0), calculator.GetNextInvokeDateTime());
        }

        [Test]
        public void NextInvokeTimeShouldBe2WeeksAfterTheFirstFridayIsTriggersWithAWednesdayStartDay()
        {
            Clock.Now = new DateTime(2000, 1, 7, 2, 0, 1);

            int testfrequency = 2; // every 2 week
            DateTime startDateTime = new DateTime(2000, 1, 5, 2, 0, 0);
            DateTime endDateTime = new DateTime(2000, 10, 1, 14, 0, 0);
            DateTime lastInvokedDateTime = new DateTime(2000, 1, 7, 2, 0, 1);

            calculator = new RecurringWeeklyScheduleCalculator(timeZone, startDateTime, endDateTime, lastInvokedDateTime, testfrequency, daysofWeek);
            Assert.AreEqual(new DateTime(2000, 1, 17, 2, 0, 0), calculator.GetNextInvokeDateTime());

            lastInvokedDateTime = new DateTime(2000, 1, 17, 2, 0, 0);
            calculator = new RecurringWeeklyScheduleCalculator(timeZone, startDateTime, endDateTime, lastInvokedDateTime, testfrequency, daysofWeek);
            Assert.AreEqual(new DateTime(2000, 1, 21, 2, 0, 0), calculator.GetNextInvokeDateTime());
        }
        
        [Test]
        public void NextInvokeTimeShouldBeTwoWeeksFromTheStartDateOn13()
        {
            Clock.Now = new DateTime(2000, 1, 13, 1, 30, 0); //2nd thursday

            DateTime startDateTime = new DateTime(2000, 1, 1, 8, 0, 0);
            DateTime endDateTime = new DateTime(2000, 10, 10, 14, 0, 0);

            calculator = new RecurringWeeklyScheduleCalculator(timeZone, startDateTime, endDateTime, null, frequency, daysofWeek);

            Assert.AreEqual(new DateTime(2000, 1, 14, 8, 0, 0), calculator.GetNextInvokeDateTime());
        }

    }
}