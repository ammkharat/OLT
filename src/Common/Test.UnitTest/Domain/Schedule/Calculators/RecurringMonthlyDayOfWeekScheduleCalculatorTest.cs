using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Utility;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Domain.Schedule.Calculators
{
    [TestFixture]
    public class RecurringMonthlyDayOfWeekScheduleCalculatorTest
    {
        private RecurringMonthlyDayOfWeekScheduleCalculator calculator;
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

            calculator = new RecurringMonthlyDayOfWeekScheduleCalculator(timeZone, startDateTime,
                endDateTime, null, monthToIncludes, DayOfWeek.Monday, WeekOfMonth.Last);

            Assert.AreEqual(new DateTime(2005, 1, 31, 8, 0, 0), calculator.GetNextInvokeDateTime());
        }

        [Test] // Condition 2
        public void NextInvokeTimeShouldBeTheNextInvokeTimePastNowIfStartTimeHasPassedAndNowIsInRange()
        {
            Clock.Now = new DateTime(2005, 1, 1, 8, 30, 0);

            DateTime startDateTime = new DateTime(2005, 1, 1, 8, 0, 0);
            DateTime endDateTime = new DateTime(2005, 12, 31, 12, 0, 0);

            calculator = new RecurringMonthlyDayOfWeekScheduleCalculator(timeZone, startDateTime,
                endDateTime, null, monthToIncludes, DayOfWeek.Monday, WeekOfMonth.Last);

            Assert.AreEqual(new DateTime(2005, 1, 31, 8, 0, 0), calculator.GetNextInvokeDateTime());
        }

        [Test] // Condition 3
        public void TestCurrentTimeGreaterThanEndDateTime()
        {
            Clock.Now = new DateTime(2005, 12, 31, 12, 30, 0);

            DateTime startDateTime = new DateTime(2005, 1, 1, 8, 0, 0);
            DateTime endDateTime = new DateTime(2005, 12, 31, 12, 0, 0);

            calculator = new RecurringMonthlyDayOfWeekScheduleCalculator(timeZone, startDateTime,
                endDateTime, null, monthToIncludes, DayOfWeek.Monday, WeekOfMonth.Last);

            Assert.AreEqual(Constants.PAST_END_TIME, calculator.GetNextInvokeDateTime());
        }

        [Test] // Condition 3a
        public void TestNextInvokeDateTimePastEndDateTime()
        {
            Clock.Now = new DateTime(2005, 12, 28, 12, 30, 0);

            DateTime startDateTime = new DateTime(2005, 1, 1, 8, 0, 0);
            DateTime endDateTime = new DateTime(2005, 12, 31, 12, 0, 0);

            calculator = new RecurringMonthlyDayOfWeekScheduleCalculator(timeZone, startDateTime,
                endDateTime, null, monthToIncludes, DayOfWeek.Monday, WeekOfMonth.Last);

            Assert.AreEqual(Constants.PAST_END_TIME, calculator.GetNextInvokeDateTime());
        }

        [Test] // Condition 4
        public void TestNextInvokeDateTimeCalculatedAgainstScheduleAndNotAgainstLastInvokedDateTime()
        {
            Clock.Now = new DateTime(2005, 12, 28, 12, 30, 0);

            DateTime startDateTime = new DateTime(2005, 1, 1, 8, 0, 0);
            DateTime endDateTime = new DateTime(2005, 12, 31, 12, 0, 0);
            DateTime lastInvokedDateTime = new DateTime(2005, 1, 31, 8, 0, 0);

            calculator = new RecurringMonthlyDayOfWeekScheduleCalculator(timeZone, startDateTime,
                endDateTime, lastInvokedDateTime, monthToIncludes, DayOfWeek.Monday, WeekOfMonth.Last);

            Assert.AreEqual(new DateTime(2005, 2, 28, 8, 0, 0), calculator.GetNextInvokeDateTime());
        }

        [Test] // Condition 5
        public void TestLastInvokedFourMonthsAgoAndNextInvokeShouldBeThreeMonthsAgo()
        {
            Clock.Now = new DateTime(2005, 6, 15, 1, 0, 0);

            DateTime startDateTime = new DateTime(2005, 1, 1, 8, 0, 0);
            DateTime endDateTime = new DateTime(2005, 12, 31, 12, 0, 0);
            DateTime lastInvokedDateTime = new DateTime(2005, 2, 28, 8, 0, 0);

            calculator = new RecurringMonthlyDayOfWeekScheduleCalculator(timeZone, startDateTime,
                endDateTime, lastInvokedDateTime, monthToIncludes, DayOfWeek.Monday, WeekOfMonth.Last);

            Assert.AreEqual(new DateTime(2005, 3, 28, 8, 0, 0), calculator.GetNextInvokeDateTime());
        }

        [Test]
        public void NextInvokeTimeShouldGoToTheDayOfMonthIfWeAreInTheMonth()
        {
            Clock.Now = new DateTime(2005, 1, 1, 8, 0, 0);

            DateTime startDateTime = new DateTime(2005, 1, 1, 8, 0, 0);
            DateTime endDateTime = new DateTime(2005, 12, 31, 12, 0, 0);

            calculator = new RecurringMonthlyDayOfWeekScheduleCalculator(timeZone, startDateTime,
                endDateTime, null, monthToIncludes, DayOfWeek.Monday, WeekOfMonth.Last);

            Assert.AreEqual(new DateTime(2005, 1, 31, 8, 0, 0), calculator.GetNextInvokeDateTime());
        }

        [Test]
        public void NextInvokeTimeShouldGoToTheDayOfMonthIfWeAreBeforeTheMonth()
        {
            Clock.Now = new DateTime(2005, 1, 1, 8, 0, 0);

            DateTime startDateTime = new DateTime(2005, 2, 1, 8, 0, 0);
            DateTime endDateTime = new DateTime(2005, 12, 31, 12, 0, 0);
            DateTime lastInvokedDateTime = new DateTime(2005, 1, 31, 8, 0, 0);

            calculator = new RecurringMonthlyDayOfWeekScheduleCalculator(timeZone, startDateTime,
                endDateTime, lastInvokedDateTime, monthToIncludes, DayOfWeek.Monday, WeekOfMonth.Last);

            Assert.AreEqual(new DateTime(2005, 2, 28, 8, 0, 0), calculator.GetNextInvokeDateTime());
        }

        [Test]
        public void NextInvokeTimeShouldGoToTheSecondMonthWhenWeAreOnTheRightDayButOurCurrentTimeHasPassedEndOfTimeRange()
        {
            Clock.Now = new DateTime(2005, 1, 1, 8, 0, 1);

            DateTime startDateTime = new DateTime(2005, 1, 1, 8, 0, 0);
            DateTime endDateTime = new DateTime(2005, 12, 31, 12, 0, 0);
            DateTime lastInvokedDateTime = new DateTime(2005, 1, 31, 8, 0, 0);

            calculator = new RecurringMonthlyDayOfWeekScheduleCalculator(timeZone, startDateTime,
                endDateTime, lastInvokedDateTime, monthToIncludes, DayOfWeek.Monday, WeekOfMonth.Last);

            Assert.AreEqual(new DateTime(2005, 2, 28, 8, 0, 0), calculator.GetNextInvokeDateTime());
        }

        [Test]
        public void NextInvokeTimeShouldGoToTheFirstMonthWhenWeAreOnTheRightDayAndWeAreBeforeStartOfRange()
        {
            Clock.Now = new DateTime(2005, 2, 1, 7, 59, 59);

            DateTime startDateTime = new DateTime(2005, 2, 1, 8, 0, 0);
            DateTime endDateTime = new DateTime(2005, 12, 31, 12, 0, 0);
            DateTime lastInvokedDateTime = new DateTime(2005, 1, 31, 8, 0, 0);

            calculator = new RecurringMonthlyDayOfWeekScheduleCalculator(timeZone, startDateTime,
                endDateTime, lastInvokedDateTime, monthToIncludes, DayOfWeek.Monday, WeekOfMonth.Last);

            Assert.AreEqual(new DateTime(2005, 2, 28, 8, 0, 0), calculator.GetNextInvokeDateTime());
        }


        [Test]
        public void ScheduleShouldGoFromDecemberToJanuaryOfTheNextYear()
        {
            Clock.Now = new DateTime(2005, 2, 1, 7, 59, 59);

            DateTime startDateTime = new DateTime(2004, 2, 1, 8, 0, 0);
            DateTime endDateTime = new DateTime(2005, 12, 31, 12, 0, 0);
            DateTime lastInvokedDateTime = new DateTime(2004, 3, 1, 8, 0, 0);
            
            List<Month> testMonthToIncludes = new List<Month>
                                                            {
                                                                Month.December,
                                                                Month.January,
                                                                Month.February
                                                            };

            calculator = new RecurringMonthlyDayOfWeekScheduleCalculator(timeZone, startDateTime,
                endDateTime, lastInvokedDateTime, testMonthToIncludes, DayOfWeek.Monday, WeekOfMonth.Last);

            Assert.AreEqual(new DateTime(2004, 12, 27, 8, 0, 0), calculator.GetNextInvokeDateTime());

            lastInvokedDateTime = new DateTime(2004, 12, 27, 8, 0, 0);

            calculator = new RecurringMonthlyDayOfWeekScheduleCalculator(timeZone, startDateTime,
                endDateTime, lastInvokedDateTime, testMonthToIncludes, DayOfWeek.Monday, WeekOfMonth.Last);

            Assert.AreEqual(new DateTime(2005, 1, 31, 8, 0, 0), calculator.GetNextInvokeDateTime());
        }


    }
}
