using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Utility;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Domain.Schedule.Calculators
{
    /// <summary>
    /// Summary description for RecurringMonthlyDayOfMonthScheduleStrategyTest
    /// </summary>
    [TestFixture]
    public class RecurringMonthlyDayOfMonthScheduleCalculatorTest
    {
        private RecurringMonthlyDayOfMonthScheduleCalculator calculator;
        private OltTimeZoneInfo timeZone;
        private List<Month> monthToIncludes; 

        [SetUp]
        public void SetUp()
        {
            timeZone = TimeZoneFixture.GetSarniaTimeZone();
            monthToIncludes = new List<Month> {Month.January, Month.February, Month.March};

            Clock.TimeZone = SiteFixture.Sarnia().TimeZone;
            Clock.Freeze();
        }

        [TearDown]
        public void TearDown()
        {
            Clock.UnFreeze();
        }

        [Test] // Condition 1
            public void NextInvokeTimeShouldBeFirstAllowableDayIfItHasNotPassed()
        {
            Clock.Now = new DateTime(2005, 1, 1, 1, 30, 0);

            DateTime startDateTime = new DateTime(2005, 1, 1, 8, 0, 0);
            DateTime endDateTime = new DateTime(2005, 12, 31, 12, 0, 0);
            
            calculator = new RecurringMonthlyDayOfMonthScheduleCalculator(timeZone, startDateTime,
                endDateTime, null, monthToIncludes, DayOfMonth.Day(15));

            Assert.AreEqual(new DateTime(2005, 1, 15, 8, 0, 0), calculator.GetNextInvokeDateTime());
        }

        [Test] // Condition 2
            public void NextInvokeTimeShouldBeTheNextInvokeTimePastNowIfStartTimeHasPassedAndNowIsInRange()
        {
            Clock.Now = new DateTime(2005, 1, 3, 4, 0, 0);

            DateTime startDateTime = new DateTime(2005, 1, 1, 8, 0, 0);
            DateTime endDateTime = new DateTime(2005, 12, 31, 12, 0, 0);

            calculator = new RecurringMonthlyDayOfMonthScheduleCalculator(timeZone, startDateTime,
                endDateTime, null, monthToIncludes, DayOfMonth.Day(15));

            Assert.AreEqual(new DateTime(2005, 1, 15, 8, 0, 0), calculator.GetNextInvokeDateTime());
        }

        [Test] // Condition 3
            public void TestCurrentTimeGreaterThanEndDateTime()
        {
            Clock.Now = new DateTime(2005, 12, 31, 12, 0, 1);

            DateTime startDateTime = new DateTime(2005, 1, 1, 8, 0, 0);
            DateTime endDateTime = new DateTime(2005, 12, 31, 12, 0, 0);

            calculator = new RecurringMonthlyDayOfMonthScheduleCalculator(timeZone, startDateTime,
                endDateTime, null, monthToIncludes, DayOfMonth.Day(15));

            Assert.AreEqual(Constants.PAST_END_TIME, calculator.GetNextInvokeDateTime());
        }

        [Test] // Condition 3a
            public void TestNextInvokeDateTimePastEndDateTime()
        {
            Clock.Now = new DateTime(2005, 12, 17, 0, 0, 0);

            DateTime startDateTime = new DateTime(2005, 1, 1, 8, 0, 0);
            DateTime endDateTime = new DateTime(2005, 12, 31, 12, 0, 0);
            DateTime lastInvokedDateTime = new DateTime(2005, 12, 17, 0, 0, 0);

            calculator = new RecurringMonthlyDayOfMonthScheduleCalculator(timeZone, startDateTime,
                endDateTime, lastInvokedDateTime, monthToIncludes, DayOfMonth.Day(15));

            Assert.AreEqual(Constants.PAST_END_TIME, calculator.GetNextInvokeDateTime());
        }

        [Test] // Condition 4
            public void TestNextInvokeDateTimeCalculatedAgainstScheduleAndNotAgainstLastInvokedDateTime()
        {
            Clock.Now = new DateTime(2005, 4, 15, 10, 0, 0);

            DateTime startDateTime = new DateTime(2005, 1, 1, 8, 0, 0);
            DateTime endDateTime = new DateTime(2005, 12, 31, 12, 0, 0);
            DateTime lastInvokedDateTime = new DateTime(2005, 2, 15, 8, 30, 0);

            calculator = new RecurringMonthlyDayOfMonthScheduleCalculator(timeZone, startDateTime,
                endDateTime, lastInvokedDateTime, monthToIncludes, DayOfMonth.Day(15));

            Assert.AreEqual(new DateTime(2005, 3, 15, 8, 0, 0), calculator.GetNextInvokeDateTime());
        }

        [Test] // Condition 5
            public void TestLastInvokedFourMonthsAgoAndNextInvokeShouldBeThreeMonthsAgo()
        {
            Clock.Now = new DateTime(2005, 6, 15, 10, 0, 0);

            DateTime startDateTime = new DateTime(2005, 1, 1, 8, 0, 0);
            DateTime endDateTime = new DateTime(2005, 12, 31, 12, 0, 0);
            DateTime lastInvokedDateTime = new DateTime(2005, 2, 15, 8, 0, 0);

            calculator = new RecurringMonthlyDayOfMonthScheduleCalculator(timeZone, startDateTime,
                endDateTime, lastInvokedDateTime, monthToIncludes, DayOfMonth.Day(15));

            Assert.AreEqual(new DateTime(2005, 3, 15, 8, 0, 0), calculator.GetNextInvokeDateTime());
        }

        [Test]
        public void TestMultipleCallsToCalculateNextInvokeDateTimeReturnSameValue()
        {
            Clock.Now = new DateTime(2006, 1, 1, 10, 0, 1);
            RecurringMonthlyDayOfMonthSchedule schedule =
                RecurringMonthlyScheduleFixture.
                    CreateMonthlyScheduleFrom8AMTo5PMForTheSecondDayOfAllMonthsBetweenJanuary1AndDecember31() as
                RecurringMonthlyDayOfMonthSchedule;

            // The last time it fired was the enddatetime
            schedule.LastInvokedDateTime = new DateTime(2006, 1, 2, 9, 0, 0);
            // gave it 9am saying that it took a hour for it to fire. 

            calculator = new RecurringMonthlyDayOfMonthScheduleCalculator(schedule.Site.TimeZone, schedule.StartDateTime,
                schedule.EndDateTime, schedule.LastInvokedDateTime, schedule.MonthsToInclude, schedule.DayOfMonth);

            DateTime expected = new DateTime(2006, 2, 2, 8, 0, 0);
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
            nextInvokeTime = calculator.GetNextInvokeDateTime();

            // see, we don't hold state anymore!
            Assert.AreEqual(expected, nextInvokeTime);
        }


        [Test]
        public void TestLastInvokedDateTimeIsTheLastDayOfTheSequenceShouldBeStartOfTheNextSequence()
        {
            Clock.Now = new DateTime(2005, 6, 15, 10, 0, 0);

            DateTime startDateTime = new DateTime(2005, 1, 1, 8, 0, 0);
            DateTime endDateTime = new DateTime(2007, 12, 31, 12, 0, 0);
            DateTime lastInvokedDateTime = new DateTime(2005, 3, 15, 8, 0, 30);

            calculator = new RecurringMonthlyDayOfMonthScheduleCalculator(timeZone, startDateTime,
                endDateTime, lastInvokedDateTime, monthToIncludes, DayOfMonth.Day(15));

            Assert.AreEqual(new DateTime(2006, 1, 15, 8, 0, 0), calculator.GetNextInvokeDateTime());
        }

        [Test]
        public void NextInvokeTimeShouldBeLastDayInMonthWhichIs31ForJan()
        {
            Clock.Now = new DateTime(2005, 1, 1, 7, 0, 0);

            DateTime startDateTime = new DateTime(2005, 1, 1, 8, 0, 0);
            DateTime endDateTime = new DateTime(2007, 12, 31, 12, 0, 0);

            calculator = new RecurringMonthlyDayOfMonthScheduleCalculator(timeZone, startDateTime,
                endDateTime, null, monthToIncludes, DayOfMonth.Last);

            Assert.AreEqual(new DateTime(2005, 1, 31, 8, 0, 0), calculator.GetNextInvokeDateTime());
        }

        [Test]
        public void NextInvokeTimeShouldBeLastDayInMonthInALeapYear()
        {
            Clock.Now = new DateTime(2000, 1, 1, 7, 0, 0);

            DateTime startDateTime = new DateTime(2000, 1, 1, 8, 0, 0);
            DateTime endDateTime = new DateTime(2007, 12, 31, 12, 0, 0);
            DateTime lastInvokeDateTime = new DateTime(2000, 1, 31, 8, 0, 0);

            calculator = new RecurringMonthlyDayOfMonthScheduleCalculator(timeZone, startDateTime,
                endDateTime, lastInvokeDateTime, monthToIncludes, DayOfMonth.Last);

            Assert.AreEqual(new DateTime(2000, 2, 29, 8, 0, 0), calculator.GetNextInvokeDateTime());
        }

        [Test]
        public void NextInvokeTimeShouldBeLastDayInFebNotInALeapYear()
        {
            Clock.Now = new DateTime(2001, 1, 1, 7, 0, 0);

            DateTime startDateTime = new DateTime(2001, 1, 1, 8, 0, 0);
            DateTime endDateTime = new DateTime(2007, 12, 31, 12, 0, 0);
            DateTime lastInvokeDateTime = new DateTime(2001, 1, 31, 8, 0, 0);

            calculator = new RecurringMonthlyDayOfMonthScheduleCalculator(timeZone, startDateTime,
                endDateTime, lastInvokeDateTime, monthToIncludes, DayOfMonth.Last);

            Assert.AreEqual(new DateTime(2001, 2, 28, 8, 0, 0), calculator.GetNextInvokeDateTime());
        }

        [Test]
        public void NextInvokeTimeShouldBeLastDayOfMonthWhen31StSet()
        {
            Clock.Now = new DateTime(2001, 1, 1, 7, 0, 0);

            DateTime startDateTime = new DateTime(2001, 1, 1, 8, 0, 0);
            DateTime endDateTime = new DateTime(2007, 12, 31, 12, 0, 0);
            DateTime lastInvokeDateTime = new DateTime(2001, 1, 31, 8, 0, 0);

            calculator = new RecurringMonthlyDayOfMonthScheduleCalculator(timeZone, startDateTime,
                endDateTime, lastInvokeDateTime, monthToIncludes, DayOfMonth.Day(31));

            Assert.AreEqual(new DateTime(2001, 2, 28, 8, 0, 0), calculator.GetNextInvokeDateTime());
        }

        [Test]
        public void NextInvokeTimeShouldBeSkipEarlyMonthsAndGoToFirstMonthInTheSeries()
        {
            Clock.Now = new DateTime(2001, 1, 1, 7, 0, 0);

            DateTime startDateTime = new DateTime(2001, 1, 1, 8, 0, 0);
            DateTime endDateTime = new DateTime(2007, 12, 31, 12, 0, 0);
            DateTime lastInvokeDateTime = new DateTime(2001, 1, 31, 8, 0, 0);

            List<Month>  testMonthToIncludes = new List<Month> {Month.August, Month.September, Month.December};

            calculator = new RecurringMonthlyDayOfMonthScheduleCalculator(timeZone, startDateTime,
                endDateTime, lastInvokeDateTime, testMonthToIncludes, DayOfMonth.Day(12));

            Assert.AreEqual(new DateTime(2001, 8, 12, 8, 0, 0), calculator.GetNextInvokeDateTime());
        }


        [Test]
        public void NextInvokeTimeShouldBeAbleToHandleMissingMonthsMonthsAndGoToFirstMonthInTheSeries()
        {
            Clock.Now = new DateTime(2001, 1, 1, 7, 0, 0);

            DateTime startDateTime = new DateTime(2001, 1, 1, 8, 0, 0);
            DateTime endDateTime = new DateTime(2007, 12, 31, 12, 0, 0);
            DateTime lastInvokeDateTime = new DateTime(2001, 9, 12, 8, 0, 0);

            List<Month> testMonthToIncludes = new List<Month> {Month.August, Month.September, Month.December};

            calculator = new RecurringMonthlyDayOfMonthScheduleCalculator(timeZone, startDateTime,
                endDateTime, lastInvokeDateTime, testMonthToIncludes, DayOfMonth.Day(12));

            Assert.AreEqual(new DateTime(2001, 12, 12, 8, 0, 0), calculator.GetNextInvokeDateTime());
        }

        [Test]
        public void NextInvokeTimeShouldBeAbleToHandleMonthsInTheWrongOrderOfTheSeries()
        {
            Clock.Now = new DateTime(2001, 1, 1, 1, 0, 0);

            DateTime startDateTime = new DateTime(2001, 1, 1, 8, 0, 0);
            DateTime endDateTime = new DateTime(2007, 12, 31, 12, 0, 0);
            DateTime lastInvokeDateTime = new DateTime(2001, 1, 12, 8, 0, 0);

            List<Month> testMonthToIncludes = new List<Month> {Month.December, Month.August, Month.January};

            calculator = new RecurringMonthlyDayOfMonthScheduleCalculator(timeZone, startDateTime,
                endDateTime, lastInvokeDateTime, testMonthToIncludes, DayOfMonth.Day(12));

            Assert.AreEqual(new DateTime(2001, 8, 12, 8, 0, 0), calculator.GetNextInvokeDateTime());
        }
    }
}