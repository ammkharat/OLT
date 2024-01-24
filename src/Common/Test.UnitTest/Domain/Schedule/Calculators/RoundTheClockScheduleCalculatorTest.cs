using System;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Utility;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Domain.Schedule.Calculators
{
    [TestFixture]
    public class RoundTheClockScheduleCalculatorTest
    {
        private RoundTheClockScheduleCalculator calculator;
        private OltTimeZoneInfo timeZone;
        private int frequency;

        [SetUp]
        public void SetUp()
        {
            timeZone = TimeZoneFixture.GetSarniaTimeZone();
            frequency = 2; // every 2 minutes
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

            calculator = new RoundTheClockScheduleCalculator(timeZone, startDateTime, endDateTime, null, frequency);

            Assert.AreEqual(startDateTime, calculator.GetNextInvokeDateTime());
        }

        [Test] // Condition 2
        public void NextInvokeTimeShouldBeTheNextInvokeTimePastNowIfStartTimeHasPassedAndNowIsInRange()
        {
            Clock.Now = new DateTime(2000, 1, 1, 2, 1, 0);

            DateTime startDateTime = new DateTime(2000, 1, 1, 2, 0, 0);
            DateTime endDateTime = new DateTime(2000, 2, 2, 7, 0, 0);

            calculator = new RoundTheClockScheduleCalculator(timeZone, startDateTime, endDateTime, null, frequency);

            Assert.AreEqual(new DateTime(2000, 1, 1, 2, 2, 0), calculator.GetNextInvokeDateTime());
        }
    
        [Test]
        public void TestCurrentDateTimePastEndDateTime()
        {
            Clock.Now = new DateTime(2000, 1, 1, 3, 0, 0);

            DateTime startDateTime = new DateTime(1999, 12, 12, 1, 0, 0);
            DateTime endDateTime = new DateTime(2000, 01, 01, 2, 0, 0);

            calculator = new RoundTheClockScheduleCalculator(timeZone, startDateTime, endDateTime, null, frequency);

            Assert.AreEqual(Constants.PAST_END_TIME, calculator.GetNextInvokeDateTime());
        }

        [Test]
        public void TestNextInvokeDateTimePastEndDateTime()
        {
            Clock.Now = new DateTime(2000, 1, 1, 2, 1, 45);

            DateTime startDateTime = new DateTime(1999, 12, 12, 1, 0, 0);
            DateTime endDateTime = new DateTime(2000, 01, 01, 2, 1, 0);
            DateTime lastInvokedDateTime = new DateTime(2000, 1, 1, 1, 0, 0);

            calculator =
                new RoundTheClockScheduleCalculator(timeZone, startDateTime, endDateTime, lastInvokedDateTime,
                                                      frequency);

            Assert.AreEqual(Constants.PAST_END_TIME, calculator.GetNextInvokeDateTime());
        }

        [Test]
        public void TestNextInvokeDateTimeCalculatedAgainstSchedule()
        {
            Clock.Now = new DateTime(2000, 1, 1, 10, 3, 0);

            DateTime startDateTime = new DateTime(2000, 1, 1, 10, 0, 0);
            DateTime endDateTime = new DateTime(2000, 12, 31, 12, 0, 0);
            DateTime lastInvokedDateTime = new DateTime(2000, 1, 1, 10, 2, 0);

            calculator =
                new RoundTheClockScheduleCalculator(timeZone, startDateTime, endDateTime, lastInvokedDateTime,
                                                      frequency);

            DateTime nextInvokeTime = calculator.GetNextInvokeDateTime();

            Assert.AreEqual(new DateTime(2000, 1, 1, 10, 4, 0), nextInvokeTime);
        }

        [Test]
        public void TestNextInvokeDateTimeCalculatedAfterTheEndTimeAndBetweenStartDateAndEndDate()
        {
            // NOTE: steve/mike - this test would break on any other calculator, because we use 
            //       StartTime and EndTime literally, not as polling components.
            Clock.Now = new DateTime(2000, 1, 3, 15, 3, 0);

            DateTime startDateTime = new DateTime(2000, 1, 1, 10, 0, 0);
            DateTime endDateTime = new DateTime(2000, 12, 31, 12, 0, 0);
            DateTime lastInvokedDateTime = new DateTime(2000, 1, 3, 15, 2, 0);

            calculator =
                new RoundTheClockScheduleCalculator(timeZone, startDateTime, endDateTime, lastInvokedDateTime,
                                                      frequency);

            DateTime nextInvokeTime = calculator.GetNextInvokeDateTime();

            Assert.AreEqual(new DateTime(2000, 1, 3, 15, 4, 0), nextInvokeTime);
        }

        // This is when the scheduler is down and the schedules that should have been fired
        // are now fired once the scheduler is restarted
        [Test]
        public void TestLastInvokedFourDaysAgoAndNextInvokeShouldBeFourDaysAgoPlus2Minutes()
        {
            Clock.Now = new DateTime(2000, 1, 5, 9, 45, 0);

            DateTime startDateTime = new DateTime(2000, 1, 1, 10, 0, 0);
            DateTime endDateTime = new DateTime(2000, 12, 31, 12, 0, 0);
            DateTime lastInvokedDateTime = new DateTime(2000, 1, 1, 10, 0, 0);

            calculator =
                new RoundTheClockScheduleCalculator(timeZone, startDateTime, endDateTime, lastInvokedDateTime,
                                                      frequency);

            Assert.AreEqual(new DateTime(2000, 1, 1, 10, 2, 0), calculator.GetNextInvokeDateTime());
        }

        [Test]
        public void IfLastInvokedTimeIsRightBeforeTheEndTimeButNotOnEndDayTheNextTriggerTimeShouldBe2MinutesAhead()
        {
            Clock.Now = new DateTime(2005, 1, 1, 18, 0, 0);

            DateTime startDateTime = new DateTime(2005, 1, 1, 5, 0, 0);
            DateTime endDateTime = new DateTime(2006, 01, 01, 18, 0, 0);
            DateTime lastInvokedDateTime = new DateTime(2005, 1, 1, 18, 0, 0);

            calculator =
                new RoundTheClockScheduleCalculator(timeZone, startDateTime, endDateTime, lastInvokedDateTime,
                                                      frequency);

            Assert.AreEqual(new DateTime(2005, 1, 1, 18, 2, 0), calculator.GetNextInvokeDateTime());
        }

        [Test]
        public void TestNextInvokeDateTimeIsTheCurrentTimeIfTheyMatch()
        {
            Clock.Now = new DateTime(2000, 1, 5, 10, 0, 0);

            DateTime startDateTime = new DateTime(2000, 1, 5, 10, 0, 0);
            DateTime endDateTime = new DateTime(2000, 12, 31, 12, 0, 0);

            calculator = new RoundTheClockScheduleCalculator(timeZone, startDateTime, endDateTime, null, 15);

            Assert.AreEqual(new DateTime(2000, 1, 5, 10, 0, 0), calculator.GetNextInvokeDateTime());

        }
    }
}
