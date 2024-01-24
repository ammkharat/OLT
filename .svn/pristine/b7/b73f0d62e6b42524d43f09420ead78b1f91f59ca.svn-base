using System;
using System.Collections.Generic;
using System.Linq;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Utility;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Domain.Schedule
{
    [TestFixture]
    public class RecurringWeeklyScheduleTest
    {
        private RecurringWeeklySchedule recurringWeeklySchedule;

        [SetUp]
        public void SetUp()
        {
            Clock.Freeze();
            Clock.TimeZone = SiteFixture.Sarnia().TimeZone;

            recurringWeeklySchedule =
                RecurringWeeklyScheduleFixture.CreateEveryMondayAndFridayFrom8AMTO2PMBetweenJan1AndOct10In2000();
        }

        [TearDown]
        public void TearDown()
        {
            Clock.UnFreeze();
        }

        [Test]
        public void IsNextScheduledTimeValidShouldBeInvalidValidIfFrequencyIsZero()
        {
            Clock.Now = new DateTime(2006, 01, 01, 11, 0, 0);

            var daysofWeek = new List<DayOfWeek> {DayOfWeek.Sunday};
            var noon = new Time(12, 0, 0);
            var fromTime = noon;
            var toTime = noon;
            var startDate = new Date(2006, 1, 1);
            var endDate = new Date(2006, 12, 31);
            const int frequency = 0;
            ISchedule recurringHourlySchedule =
                new RecurringWeeklySchedule(1, startDate, endDate, fromTime, toTime, daysofWeek, frequency, null,
                    SiteFixture.Sarnia());
            Assert.IsFalse(recurringHourlySchedule.IsNextScheduledTimeValid);
        }

        [Test]
        public void IsNextScheduledTimeValidShouldBeValid()
        {
            Clock.Now = new DateTime(2006, 4, 5, 12, 0, 0);

            var schedule =
                RecurringWeeklyScheduleFixture.CreateEverySundayFrom8AMTO2PMBetweenMar15AndDec31In2006();
            Assert.IsTrue(schedule.IsNextScheduledTimeValid);
        }

        [Test]
        public void NextInvokeTimeShouldBeTwoWeeksFromTheStartDateOn19()
        {
            Clock.Now = new DateTime(2000, 1, 19, 1, 30, 0); //3rd wednesday

            ISchedule schedule =
                RecurringWeeklyScheduleFixture.CreateEveryOtherMondayAndFridayFrom8AMTO2PMBetweenJan1AndOct10In2000();

            Assert.AreEqual(new DateTime(2000, 1, 21, 8, 0, 0), schedule.NextInvokeDateTime);
        }

        [Test]
        public void RecurringWeeklyScheduleDescribingEveryMondayAndFridayInTheWeekShouldContainMondayAndFriday()
        {
            Assert.IsTrue(recurringWeeklySchedule.Contains(DayOfWeek.Monday));
            Assert.IsTrue(recurringWeeklySchedule.Contains(DayOfWeek.Friday));
        }

        [Test]
        public void RecurringWeeklyScheduleDescribingEveryMondayAndFridayInTheWeekShouldNotContainTuesday()
        {
            Assert.IsFalse(recurringWeeklySchedule.Contains(DayOfWeek.Tuesday));
        }


        [Test]
        public void
            RecurringWeeklyScheduleDescribingEveryMondayAndFridayInTheWeekShouldReturnScheduledOccurrencesInWindow()
        {
            var lowerBound = new DateTime(2050, 1, 1);
            var upperBound = new DateTime(2050, 2, 1);
            recurringWeeklySchedule =
                RecurringWeeklyScheduleFixture.CreateEveryMondayAndFridayFrom8AMTO2PMBetweenJan1AndOct10In2050();

            var scheduledOccurencesWithin = recurringWeeklySchedule.ScheduledOccurencesWithin(new Range<DateTime>(
                lowerBound, upperBound));

            Assert.AreEqual(9, scheduledOccurencesWithin.Count);
            Assert.AreEqual(scheduledOccurencesWithin.First().LowerBound, new DateTime(2050, 1, 3, 8, 0, 0, 0));
            Assert.AreEqual(scheduledOccurencesWithin.First().UpperBound, new DateTime(2050, 1, 3, 14, 0, 0, 0));
        }

        [Test]
        public void RecurringWeeklyScheduleShouldBeSerializable()
        {
            Assert.IsTrue(typeof (RecurringWeeklySchedule).IsSerializable);
        }

        [Test]
        public void RecurringWeeklyScheduleShouldDescribeDateBoundariesWithin2000Oct1stand2000Oct10th()
        {
            Assert.AreEqual(new Date(2000, 1, 1), recurringWeeklySchedule.StartDate);
            Assert.AreEqual(new Date(2000, 10, 10), recurringWeeklySchedule.EndDate);
        }

        [Test]
        public void RecurringWeeklyScheduleShouldDescribeFrom8AMTO2PM()
        {
            Assert.AreEqual(new Time(8, 00), recurringWeeklySchedule.StartTime);
            Assert.AreEqual(new Time(14, 00), recurringWeeklySchedule.EndTime);
        }

        [Test]
        public void RecurringWeeklyScheduleShouldHaveWeeklyFrequencyOfOne()
        {
            Assert.AreEqual(1, recurringWeeklySchedule.Frequency);
        }

        [Test]
        public void RecurringWeeklyScheduleShouldImplementISchedule()
        {
            Assert.IsTrue(recurringWeeklySchedule is ISchedule);
        }

        [Test]
        public void ShouldBeDifferentBatchKeysForDifferentFrequencies()
        {
            var startDate = new Date(2011, 05, 06);
            var endDate = new Date(2011, 07, 08);
            var fromTime = new Time(4, 0);
            var endTime = new Time(15, 15);

            var weeklySchedule1 = new RecurringWeeklySchedule(startDate, endDate, fromTime, endTime,
                new List<DayOfWeek> {DayOfWeek.Monday, DayOfWeek.Tuesday},
                1, SiteFixture.Sarnia());
            var weeklySchedule2 = new RecurringWeeklySchedule(startDate, endDate, fromTime, endTime,
                new List<DayOfWeek> {DayOfWeek.Monday, DayOfWeek.Tuesday},
                2, SiteFixture.Sarnia());

            Assert.That(weeklySchedule1.BatchingKey, Is.Not.EqualTo(weeklySchedule2.BatchingKey));
        }

        [Test]
        public void ShouldBeDifferentBatchKeysForDifferentStartTimes()
        {
            var startDate = new Date(2011, 05, 06);
            var endDate = new Date(2011, 07, 08);
            var fromTime = new Time(4, 0);
            var endTime = new Time(15, 15);

            var weeklySchedule1 = new RecurringWeeklySchedule(startDate, endDate, fromTime, endTime,
                new List<DayOfWeek> {DayOfWeek.Monday, DayOfWeek.Tuesday},
                1, SiteFixture.Sarnia());
            var weeklySchedule2 = new RecurringWeeklySchedule(startDate, endDate, fromTime.AddHours(1), endTime,
                new List<DayOfWeek> {DayOfWeek.Monday, DayOfWeek.Tuesday},
                2, SiteFixture.Sarnia());

            Assert.That(weeklySchedule1.BatchingKey, Is.Not.EqualTo(weeklySchedule2.BatchingKey));
        }

        [Test]
        public void ShouldConstructRecurrencePattern()
        {
            var schedule =
                RecurringWeeklyScheduleFixture.CreateEveryMondayAndFridayFrom8AMTO2PMBetweenJan1AndOct10In2000();
            StringAssert.EndsWith("Monday, Friday", schedule.RecurrencePatternString);
        }


        [Test]
        public void ShouldCreateDifferentBatchKeysForDifferentDays()
        {
            var startDate = new Date(2011, 05, 06);
            var endDate = new Date(2011, 07, 08);
            var fromTime = new Time(4, 0);
            var endTime = new Time(15, 15);

            var weeklySchedule1 = new RecurringWeeklySchedule(startDate, endDate, fromTime, endTime,
                new List<DayOfWeek> {DayOfWeek.Monday, DayOfWeek.Tuesday},
                1, SiteFixture.Sarnia());
            var weeklySchedule2 = new RecurringWeeklySchedule(startDate, endDate, fromTime, endTime,
                new List<DayOfWeek> {DayOfWeek.Monday, DayOfWeek.Wednesday},
                1, SiteFixture.Sarnia());

            Assert.That(weeklySchedule1.BatchingKey, Is.Not.EqualTo(weeklySchedule2.BatchingKey));
        }

        [Test]
        public void ShouldCreateDifferentBatchKeysForDifferentEndDates()
        {
            var startDate = new Date(2011, 05, 06);
            var endDate = new Date(2011, 07, 08);
            var fromTime = new Time(4, 0);
            var endTime = new Time(15, 15);

            var weeklySchedule1 = new RecurringWeeklySchedule(startDate, endDate, fromTime, endTime,
                new List<DayOfWeek> {DayOfWeek.Monday, DayOfWeek.Tuesday},
                1, SiteFixture.Sarnia());
            var weeklySchedule2 = new RecurringWeeklySchedule(startDate, endDate.AddDays(1), fromTime, endTime,
                new List<DayOfWeek> {DayOfWeek.Monday, DayOfWeek.Tuesday},
                1, SiteFixture.Sarnia());

            Assert.That(weeklySchedule1.BatchingKey, Is.Not.EqualTo(weeklySchedule2.BatchingKey));

            var weeklySchedule3 = new RecurringWeeklySchedule(startDate, null, fromTime, endTime,
                new List<DayOfWeek> {DayOfWeek.Monday, DayOfWeek.Tuesday},
                1, SiteFixture.Sarnia());
            Assert.That(weeklySchedule1.BatchingKey, Is.Not.EqualTo(weeklySchedule3.BatchingKey));
        }

        [Test]
        public void ShouldCreateSameBatchKeysForDifferentEndTimes()
        {
            var startDate = new Date(2011, 05, 06);
            var endDate = new Date(2011, 07, 08);
            var fromTime = new Time(4, 0);
            var endTime = new Time(15, 15);

            var weeklySchedule1 = new RecurringWeeklySchedule(startDate, endDate, fromTime, endTime,
                new List<DayOfWeek> {DayOfWeek.Monday, DayOfWeek.Tuesday},
                1, SiteFixture.Sarnia());
            var weeklySchedule2 = new RecurringWeeklySchedule(startDate, endDate, fromTime, endTime.AddHours(1),
                new List<DayOfWeek> {DayOfWeek.Monday, DayOfWeek.Tuesday},
                1, SiteFixture.Sarnia());

            Assert.That(weeklySchedule1.BatchingKey, Is.EqualTo(weeklySchedule2.BatchingKey));
        }

        [Test]
        public void ShouldCreateSameBatchKeysForDifferentStartDates()
        {
            var startDate = new Date(2011, 05, 06);
            var endDate = new Date(2011, 07, 08);
            var fromTime = new Time(4, 0);
            var endTime = new Time(15, 15);

            var weeklySchedule1 = new RecurringWeeklySchedule(startDate, endDate, fromTime, endTime,
                new List<DayOfWeek> {DayOfWeek.Monday, DayOfWeek.Tuesday},
                1, SiteFixture.Sarnia());
            var weeklySchedule2 = new RecurringWeeklySchedule(startDate.AddDays(1), endDate, fromTime, endTime,
                new List<DayOfWeek> {DayOfWeek.Monday, DayOfWeek.Tuesday},
                1, SiteFixture.Sarnia());

            Assert.That(weeklySchedule1.BatchingKey, Is.EqualTo(weeklySchedule2.BatchingKey));
        }

        [Test]
        public void ShouldDeterminePreviousOccurrenceGivenDateTime()
        {
            var someTime = new DateTime(2006, 5, 12, 12, 59, 59);
            Assert.AreEqual(someTime.AddWeeks(-1), CreateWeeklySchedule(1).GetPreviousOccurrence(someTime));
            Assert.AreEqual(someTime.AddWeeks(-2), CreateWeeklySchedule(2).GetPreviousOccurrence(someTime));
        }

        [Test]
        public void ShouldShowToStringWithEndTimeProperly()
        {
            CultureInfoTestHelper.SetFormatsForEnglishFromResourceFile();

            var startDate = new Date(2011, 05, 06);
            var endDate = new Date(2011, 07, 08);
            var fromTime = new Time(4, 0);
            var endTime = new Time(15, 15);

            var daysOfWeek = new List<DayOfWeek> {DayOfWeek.Monday, DayOfWeek.Thursday};

            var schedule =
                new RecurringWeeklySchedule(startDate, endDate, fromTime, endTime, daysOfWeek, 3, SiteFixture.Sarnia());

            Assert.That(schedule.ToString(true),
                Is.EqualTo(
                    "Every 3 week(s) from 05/06/2011 to 07/08/2011 between 04:00 and 15:15 on the following day(s) of the week: Monday, Thursday"));
        }

        [Test]
        public void ShouldShowToStringWithNoEndTimeProperly()
        {
            CultureInfoTestHelper.SetFormatsForEnglishFromResourceFile();

            var startDate = new Date(2011, 05, 06);
            var endDate = new Date(2011, 07, 08);
            var fromTime = new Time(4, 0);
            var endTime = new Time(15, 15);

            var daysOfWeek = new List<DayOfWeek> {DayOfWeek.Monday, DayOfWeek.Thursday};

            var schedule =
                new RecurringWeeklySchedule(startDate, endDate, fromTime, endTime, daysOfWeek, 3, SiteFixture.Sarnia());

            Assert.That(schedule.ToString(false),
                Is.EqualTo(
                    "Every 3 week(s) from 05/06/2011 to 07/08/2011 at 04:00 on the following day(s) of the week: Monday, Thursday"));
        }

        [Test]
        public void TwoSchedulesWithTheSameValuesShouldBeEqual()
        {
            Assert.AreEqual(
                RecurringWeeklyScheduleFixture.CreateEveryMondayAndFridayFrom8AMTO2PMBetweenJan1AndOct10In2000(),
                RecurringWeeklyScheduleFixture.CreateEveryMondayAndFridayFrom8AMTO2PMBetweenJan1AndOct10In2000());
        }

        [Test]
        public void TypeNameShouldReturnRecurringWeekly()
        {
            Assert.AreEqual(ScheduleType.Weekly,
                RecurringWeeklyScheduleFixture.
                    CreateEveryMondayAndFridayFrom8AMTO2PMBetweenJan1AndOct10In2000().Type);
        }

        private static RecurringWeeklySchedule CreateWeeklySchedule(int frequency)
        {
            return new RecurringWeeklySchedule(new Date(2006, 1, 1), new Date(2006, 1, 1),
                Time.MIDNIGHT, Time.END_OF_DAY,
                new List<DayOfWeek> {DayOfWeek.Monday},
                frequency, SiteFixture.Sarnia());
        }
    }
}