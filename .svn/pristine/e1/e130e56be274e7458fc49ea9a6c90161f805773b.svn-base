using System;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Utility;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Domain.Schedule.Calculators
{
    [TestFixture]
    public class RecurringMinuteScheduleCalculatorTest
    {
        private RecurringMinuteScheduleCalculator calculator;
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

            calculator = new RecurringMinuteScheduleCalculator(timeZone, startDateTime, endDateTime, null, frequency);

            Assert.AreEqual(new DateTime(2000, 1, 1, 2, 0, 0), calculator.GetNextInvokeDateTime());
        }

        [Test] // Condition 2
            public void NextInvokeTimeShouldBeTheNextInvokeTimePastNowIfStartTimeHasPassedAndNowIsInRange()
        {
            Clock.Now = new DateTime(2000, 1, 1, 2, 1, 0);

            DateTime startDateTime = new DateTime(2000, 1, 1, 2, 0, 0);
            DateTime endDateTime = new DateTime(2000, 2, 2, 7, 0, 0);

            calculator = new RecurringMinuteScheduleCalculator(timeZone, startDateTime, endDateTime, null, frequency);

            Assert.AreEqual(new DateTime(2000, 1, 1, 2, 2, 0), calculator.GetNextInvokeDateTime());
        }

        [Test]
        public void TestCurrentDateTimePastEndDateTime()
        {
            Clock.Now = new DateTime(2000, 1, 1, 3, 0, 0);

            DateTime startDateTime = new DateTime(1999, 12, 12, 1, 0, 0);
            DateTime endDateTime = new DateTime(2000, 01, 01, 2, 0, 0);

            calculator = new RecurringMinuteScheduleCalculator(timeZone, startDateTime, endDateTime, null, frequency);

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
                new RecurringMinuteScheduleCalculator(timeZone, startDateTime, endDateTime, lastInvokedDateTime,
                                                      frequency);

            Assert.AreEqual(Constants.PAST_END_TIME, calculator.GetNextInvokeDateTime());
        }


        [Test]
        public void TestNextInvokeDateTimeCalculatedAgainstScheduleAndNotAgainstLastInvokedDateTime()
        {
            Clock.Now = new DateTime(2000, 1, 1, 10, 3, 0);

            DateTime startDateTime = new DateTime(2000, 1, 1, 10, 0, 0);
            DateTime endDateTime = new DateTime(2000, 12, 31, 12, 0, 0);
            DateTime lastInvokedDateTime = new DateTime(2000, 1, 1, 10, 2, 0);

            calculator =
                new RecurringMinuteScheduleCalculator(timeZone, startDateTime, endDateTime, lastInvokedDateTime,
                                                      frequency);

            DateTime nextInvokeTime = calculator.GetNextInvokeDateTime();

            Assert.AreEqual(new DateTime(2000, 1, 1, 10, 4, 0), nextInvokeTime);
        }

        [Test]
        public void NextInvokeDateTimeShouldNotReturnOneLastDateIfStillInRangeButLastDateIsAfterEndDateTime()
        {
            // NOTE: mike/steve - we noticed that there is a magic threshold of 24 hours for recurring-by-minute
            //       calculators in RecurringMinuteScheduleCalculator.RollForwardInvokeTimeIfNotInRange().
            //
            //       It seems that the logic in this method is causing one final execution of the scheduled item
            //       even after the EndDate. Should this really be the case?

            const int longerFrequency = 31;
            Clock.Now = new DateTime(2000, 1, 1, 2, 0, 59);// Jan 1 2000 02:00:59

            DateTime startDateTime = new DateTime(1999, 12, 12, 1, 0, 0); // December 12, 1999 01:00:00
            DateTime endDateTime = new DateTime(2000, 01, 01, 2, 1, 0); // January 1 2000 02:01:00
            DateTime lastInvokedDateTime = new DateTime(2000, 1, 1, 2, 1, 1); // January 1, 2000 02:01:01

            calculator =
                new RecurringMinuteScheduleCalculator(timeZone, startDateTime, endDateTime, lastInvokedDateTime,
                                                      longerFrequency);
            
            // This is the behaviour we expect based on the way AbstractRecurringScheduleCalculator is written:
            Assert.AreEqual(Constants.PAST_END_TIME, calculator.GetNextInvokeDateTime());
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

            calculator =
                new RecurringMinuteScheduleCalculator(timeZone, startDateTime, endDateTime, lastInvokedDateTime,
                                                      frequency);

            Assert.AreEqual(new DateTime(2000, 1, 1, 10, 2, 0), calculator.GetNextInvokeDateTime());
        }

        [Test]
        public void IfLastInvokedDateTimeIsRightBeforeTheEndTimeTheNextTriggerTimeShouldBeTheNextDaysStartTime()
        {
            Clock.Now = new DateTime(2005, 1, 1, 18, 0, 0);

            DateTime startDateTime = new DateTime(2005, 1, 1, 5, 0, 0);
            DateTime endDateTime = new DateTime(2006, 01, 01, 18, 0, 0);
            DateTime lastInvokedDateTime = new DateTime(2005, 1, 1, 18, 0, 0);

            calculator =
                new RecurringMinuteScheduleCalculator(timeZone, startDateTime, endDateTime, lastInvokedDateTime,
                                                      frequency);

            Assert.AreEqual(new DateTime(2005, 1, 2, 5, 0, 0), calculator.GetNextInvokeDateTime());
        }

        [Test]
        public void TestNextInvokeDateTimeIsTheCurrentTimeIfTheyMatch()
        {
            Clock.Now = new DateTime(2000, 1, 5, 10, 0, 0);

            DateTime startDateTime = new DateTime(2000, 1, 5, 10, 0, 0);
            DateTime endDateTime = new DateTime(2000, 12, 31, 12, 0, 0);

            calculator = new RecurringMinuteScheduleCalculator(timeZone, startDateTime, endDateTime, null, 15);

            Assert.AreEqual(new DateTime(2000, 1, 5, 10, 0, 0), calculator.GetNextInvokeDateTime());

        }
    }
}