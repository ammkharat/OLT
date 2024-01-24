using System;
using System.Linq;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Utility;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Domain.Schedule
{
    [TestFixture]
    public class RecurringDailyScheduleTest
    {
        private RecurringDailySchedule recurringDailySchedule;

        [SetUp]
        public void SetUp()
        {
            Clock.Freeze();
            Clock.TimeZone = SiteFixture.Sarnia().TimeZone;
            recurringDailySchedule =
                RecurringDailyScheduleFixture.CreateEvery2DaysFrom10AM12To07PM11BetweenJan10AndOct21In2000();
        }

        [TearDown]
        public void TearDown()
        {
            Clock.UnFreeze();
        }

        [Test]
        public void IfCurrentDateTimeIsPastScheduleEndDateTimeScheduleShouldBeInvalid()
        {
            ISchedule schedule =
                RecurringDailyScheduleFixture.CreateRecurringDailyScheduleBetweenMar30AndMay1From8amTo12pm();

            Clock.Now = new DateTime(2006, 5, 1, 12, 1, 0);

            Assert.IsFalse(schedule.IsNextScheduledTimeValid);
        }

        [Test]
        public void IfStartDateTimeEqualToEndDateTimeShouldBeInvalid()
        {
            Clock.Now = new DateTime(2006, 01, 01, 11, 0, 0);

            var startDate = new Date(2006, 01, 01);
            var endDate = new Date(2006, 01, 01);
            var startTime = new Time(10, 1, 55);
            var endTime = new Time(10, 1, 55);
            ISchedule schedule =
                new RecurringDailySchedule(startDate, endDate, startTime, endTime, 1, SiteFixture.Sarnia());
            Assert.IsFalse(schedule.IsNextScheduledTimeValid);
        }

        [Test]
        public void IfStartDateTimeGreaterThanoEndDateTimeShouldBeInvalid()
        {
            Clock.Now = new DateTime(2006, 01, 01, 11, 0, 0);

            var startDate = new Date(2006, 01, 01);
            var endDate = new Date(2006, 01, 01);
            var startTime = new Time(10, 1, 56);
            var endTime = new Time(10, 1, 55);
            ISchedule schedule =
                new RecurringDailySchedule(startDate, endDate, startTime, endTime, 0, SiteFixture.Sarnia());
            Assert.IsFalse(schedule.IsNextScheduledTimeValid);
        }

        [Test]
        public void IfStartTimeEqualToEndTimeTheScheduleIsValid()
        {
            Clock.Now = new DateTime(2006, 01, 01, 11, 0, 0);

            var startDate = new Date(2006, 01, 01);
            var endDate = new Date(2006, 01, 02);
            var startTime = new Time(10, 1, 55);
            var endTime = new Time(10, 1, 55);
            ISchedule schedule =
                new RecurringDailySchedule(startDate, endDate, startTime, endTime, 1, SiteFixture.Sarnia());
            Assert.IsTrue(schedule.IsNextScheduledTimeValid);
        }

        [Test]
        public void IsNextScheduledTimeValidShouldBeInvalidValidIfFrequencyIsZero()
        {
            Clock.Now = new DateTime(2006, 01, 01, 11, 0, 0);
            var startDate = new Date(2006, 01, 01);
            var endDate = new Date(2006, 01, 01);
            var startTime = new Time(10, 1, 55);
            var endTime = new Time(16, 0, 00);
            ISchedule schedule =
                new RecurringDailySchedule(startDate, endDate, startTime, endTime, 0, SiteFixture.Sarnia());
            Assert.IsFalse(schedule.IsNextScheduledTimeValid);
        }

        [Test]
        public void IsNextScheduledTimeValidShouldBeInvalidValidIfNextInvokeTimeDateTimeIsGreaterthanThanEndDateTime()
        {
            Clock.Now = new DateTime(2006, 02, 01, 11, 0, 0);
            ISchedule schedule =
                RecurringDailyScheduleFixture.CreateRecurringDailyScheduleFromJan1200610Hour1Min55SecAMTo4PM();
            Assert.IsFalse(schedule.IsNextScheduledTimeValid);
        }

        [Test]
        public void NextInvokeDateTimeShouldBe5MinutesFromNowIfScheduledFor5MinutesFromNow()
        {
            Clock.Now = new DateTime(2006, 07, 25, 05, 0, 0);
            var now = Clock.Now;
            var schedule =
                new RecurringDailySchedule(new Date(now), null, new Time(now.AddMinutes(5)), new Time(now.AddMinutes(5)),
                    1, SiteFixture.Denver());

            Assert.IsTrue(schedule.IsNextScheduledTimeValid);
            // Assert that the Daily Schedule will fire today.
            Assert.AreEqual(new Date(now), new Date(schedule.NextInvokeDateTime));
        }

        [Test]
        public void NextScheduledTimeValidShouldBeValid()
        {
            Clock.Now = new DateTime(2006, 01, 01, 10, 0, 0);
            ISchedule schedule =
                RecurringDailyScheduleFixture.CreateRecurringDailyScheduleFromJan1200610Hour1Min55SecAMTo4PM();

            Assert.IsTrue(schedule.IsNextScheduledTimeValid);
        }

        [Test]
        public void RecurringDailShceduleShouldBeSerializable()
        {
            Assert.IsTrue(typeof (RecurringDailySchedule).IsSerializable);
        }

        [Test]
        public void
            RecurringDailyScheduleForEvery2DaysFrom10AM12To07PM11BetweenJan10AndOct21In2000ShouldDescribeDateRangeFromJan10ToOct21In2000
            ()
        {
            Assert.AreEqual(new Date(2000, 1, 10), recurringDailySchedule.StartDate);
            Assert.AreEqual(new Date(2000, 10, 21), recurringDailySchedule.EndDate);
        }

        [Test]
        public void
            RecurringDailyScheduleForEvery2DaysFrom10AM12To07PM11BetweenJan10AndOct21In2000ShouldDescribeEveryTwoDays()
        {
            Assert.AreEqual(2, recurringDailySchedule.Frequency);
        }

        [Test]
        public void
            RecurringDailyScheduleForEvery2DaysFrom10AM12To07PM11BetweenJan10AndOct21In2000ShouldDescribeFrom10AM12To7PM11
            ()
        {
            Assert.AreEqual(new Time(10, 12), recurringDailySchedule.StartTime);
            Assert.AreEqual(new Time(19, 11), recurringDailySchedule.EndTime);
        }

        [Test]
        public void RecurringDailyScheduleShouldImplementISchedule()
        {
            Assert.IsTrue(recurringDailySchedule is ISchedule);
        }

        [Test]
        public void ShouldDeterminePreviousOccurrenceGivenDateTime()
        {
            var someTime = new DateTime(2006, 5, 12, 12, 59, 59);
            Assert.AreEqual(someTime.SubtractDays(1), CreateDailySchedule(1).GetPreviousOccurrence(someTime));
            Assert.AreEqual(someTime.SubtractDays(2), CreateDailySchedule(2).GetPreviousOccurrence(someTime));
        }

        [Test]
        public void ShouldGetMoreThanOneNextInvokeDateTimeAtATime()
        {
            Clock.Now = new DateTime(2010, 12, 20, 5, 0, 0);
            var now = Clock.Now;
            var fiveMinutesFromNow = now.AddMinutes(5);

            var schedule = new RecurringDailySchedule(new Date(now), null, new Time(fiveMinutesFromNow),
                new Time(fiveMinutesFromNow), 1, SiteFixture.Denver());

            var nextInvokeDateTimes = schedule.NextInvokeDateTimes(now.AddDays(3));
            Assert.AreEqual(3, nextInvokeDateTimes.Count);
            Assert.AreEqual(fiveMinutesFromNow, nextInvokeDateTimes[0]);
            Assert.AreEqual(fiveMinutesFromNow.AddDays(1), nextInvokeDateTimes[1]);
            Assert.AreEqual(fiveMinutesFromNow.AddDays(2), nextInvokeDateTimes[2]);
        }

        [Test]
        public void ShouldListCorrectOccurencesForFiveDaysWindow()
        {
            recurringDailySchedule =
                RecurringDailyScheduleFixture.CreateEvery1DaysFrom5PMTo6PMWithyNoEndDateStarting2006June15();

            var scheduledOccurencesWithin =
                recurringDailySchedule.ScheduledOccurencesWithin(new Range<DateTime>(
                    new DateTime(2006, 06, 15, 0, 0, 0), new DateTime(2006, 06, 19, 23, 59, 59)));

            Assert.AreEqual(5, scheduledOccurencesWithin.Count);
        }

        [Test]
        public void ShouldListCorrectOccurencesForFiveDaysWindowWhenItSkipsADay()
        {
            recurringDailySchedule =
                RecurringDailyScheduleFixture.CreateEvery2DaysFrom10AM12To07PM11BetweenJan10AndOct21In2000();

            var scheduledOccurencesWithin =
                recurringDailySchedule.ScheduledOccurencesWithin(new Range<DateTime>(
                    new DateTime(2000, 1, 12, 0, 0, 0), new DateTime(2000, 1, 16, 9, 59, 59)));

            Assert.AreEqual(2, scheduledOccurencesWithin.Count);
        }

        [Test]
        public void ShouldListCorrectOccurencesForOneDayWindow()
        {
            recurringDailySchedule =
                RecurringDailyScheduleFixture.CreateEvery1DaysFrom5PMTo6PMWithyNoEndDateStarting2006June15();

            var scheduledOccurencesWithin =
                recurringDailySchedule.ScheduledOccurencesWithin(new Range<DateTime>(
                    new DateTime(2006, 06, 15, 0, 0, 0), new DateTime(2006, 06, 15, 23, 59, 59)));

            Assert.AreEqual(1, scheduledOccurencesWithin.Count);
            Assert.AreEqual(new DateTime(2006, 06, 15, 17, 0, 0), scheduledOccurencesWithin.First().LowerBound);
            Assert.AreEqual(new DateTime(2006, 06, 15, 18, 0, 0), scheduledOccurencesWithin.First().UpperBound);
        }

        [Test]
        public void ShouldNotBeValidWhenStartDateTimeAndEndDateTimeAreTheSame()
        {
            var startDate = new Date(2099, 11, 12);
            var endDate = startDate;
            var fromTime = new Time(4, 41);
            var endTime = fromTime;

            var schedule = new RecurringDailySchedule(startDate, endDate, fromTime, endTime, 1, SiteFixture.Sarnia());

            Assert.That(schedule.IsNextScheduledTimeValid, Is.False);
        }

        [Test]
        public void ShouldNotGetNextInvokeDateTimeAtExactlyEndDateDate()
        {
            Clock.Now = new DateTime(2010, 12, 20, 5, 0, 0);
            var now = Clock.Now;
            var fiveMinutesFromNow = now.AddMinutes(5);

            var schedule = new RecurringDailySchedule(new Date(now), null, new Time(fiveMinutesFromNow),
                new Time(fiveMinutesFromNow), 1, SiteFixture.Denver());

            var nextInvokeDateTimes = schedule.NextInvokeDateTimes(fiveMinutesFromNow);
            Assert.AreEqual(0, nextInvokeDateTimes.Count);
        }

        [Test]
        public void ShouldShowToStringWithEndTimeProperly()
        {
            CultureInfoTestHelper.SetFormatsForEnglishFromResourceFile();

            var startDate = new Date(2011, 05, 06);
            var endDate = new Date(2011, 07, 08);
            var fromTime = new Time(4, 0);
            var endTime = new Time(15, 15);

            var schedule =
                new RecurringDailySchedule(startDate, endDate, fromTime, endTime, 3, SiteFixture.Sarnia());

            Assert.That(schedule.ToString(true),
                Is.EqualTo("Every 3 day(s) from 05/06/2011 to 07/08/2011 between 04:00 and 15:15"));
        }

        [Test]
        public void ShouldShowToStringWithNoEndTimeProperly()
        {
            CultureInfoTestHelper.SetFormatsForEnglishFromResourceFile();

            var startDate = new Date(2011, 05, 06);
            var endDate = new Date(2011, 07, 08);
            var fromTime = new Time(4, 0);
            var endTime = new Time(15, 15);

            var schedule =
                new RecurringDailySchedule(startDate, endDate, fromTime, endTime, 3, SiteFixture.Sarnia());

            Assert.That(schedule.ToString(false),
                Is.EqualTo("Every 3 day(s) from 05/06/2011 to 07/08/2011 at 04:00"));
        }

        [Test]
        public void ShouldUseDifferentBatchKeysForDifferentFrequencies()
        {
            var startDate = new Date(2013, 10, 09);
            var endDate = new Date(2013, 12, 31);
            var fromTime = new Time(4, 0);
            var endTime = new Time(4, 1);

            var scheduleA = new RecurringDailySchedule(startDate, endDate, fromTime, endTime, 1, SiteFixture.Sarnia());
            var scheduleD = new RecurringDailySchedule(startDate, endDate, fromTime, endTime, 2, SiteFixture.Sarnia());

            Assert.That(scheduleA.BatchingKey, Is.Not.EqualTo(scheduleD.BatchingKey));
        }

        [Test]
        public void ShouldUseDifferentBatchKeysForNoEndDateAndSpecificEndDate()
        {
            var startDate = new Date(2013, 10, 09);
            var endDate = new Date(2013, 12, 31);
            var fromTime = new Time(4, 0);
            var endTime = new Time(4, 1);

            var scheduleA = new RecurringDailySchedule(startDate, endDate, fromTime, endTime, 1, SiteFixture.Sarnia());
            var scheduleB = new RecurringDailySchedule(startDate, null, fromTime, endTime, 1, SiteFixture.Sarnia());

            Assert.That(scheduleA.BatchingKey, Is.Not.EqualTo(scheduleB.BatchingKey));
        }

        [Test]
        public void ShouldUseSameBatchKeyRegardlessOfEndTime()
        {
            var startDate = new Date(2013, 10, 09);
            var endDate = new Date(2013, 12, 31);
            var fromTime = new Time(4, 0);
            var endTime = new Time(4, 1);

            var scheduleA = new RecurringDailySchedule(startDate, endDate, fromTime, endTime, 1, SiteFixture.Sarnia());
            var scheduleE = new RecurringDailySchedule(startDate.AddDays(1), endDate, fromTime, endTime, 1,
                SiteFixture.Sarnia());

            Assert.That(scheduleA.BatchingKey, Is.EqualTo(scheduleE.BatchingKey));
        }

        [Test]
        public void ShouldUseSameBatchKeysRegardlessOfStartDate()
        {
            var startDate = new Date(2013, 10, 09);
            var endDate = new Date(2013, 12, 31);
            var fromTime = new Time(4, 0);
            var endTime = new Time(4, 1);

            var scheduleA = new RecurringDailySchedule(startDate, endDate, fromTime, endTime, 1, SiteFixture.Sarnia());
            var scheduleC = new RecurringDailySchedule(startDate, endDate, fromTime, endTime.AddHours(1), 1,
                SiteFixture.Sarnia());

            Assert.That(scheduleA.BatchingKey, Is.EqualTo(scheduleC.BatchingKey));
        }

        [Test]
        public void TwoRecurringDailySchedulesWithTheSameValuesShouldBeEqual()
        {
            Assert.AreEqual(
                RecurringDailyScheduleFixture.CreateEvery2DaysFrom10AM12To07PM11BetweenJan10AndOct21In2000(),
                RecurringDailyScheduleFixture.CreateEvery2DaysFrom10AM12To07PM11BetweenJan10AndOct21In2000());
        }

        [Test]
        public void TypeNameShouldReturnRecurringDaily()
        {
            Assert.AreEqual(ScheduleType.Daily,
                RecurringDailyScheduleFixture.CreateEvery2DaysFrom10AM12To07PM11BetweenJan10AndOct21In2000().Type);
        }

        private static RecurringDailySchedule CreateDailySchedule(int frequency)
        {
            return new RecurringDailySchedule(new Date(2006, 1, 1), new Date(2006, 1, 1),
                Time.MIDNIGHT, Time.END_OF_DAY, frequency, SiteFixture.Sarnia());
        }
    }
}