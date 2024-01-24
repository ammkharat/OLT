using System;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Utility;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Domain.Schedule
{
    [TestFixture]
    public class RecurringMinuteScheduleTest
    {
        private RecurringMinuteSchedule recurringMinuteSchedule;

        [SetUp]
        public void SetUp()
        {
            recurringMinuteSchedule =
                RecurringMinuteScheduleFixture.CreateEvery10MinutesFrom5AM15To8PM05BetweenFeb12AndDec21In2002();

            Clock.TimeZone = SiteFixture.Sarnia().TimeZone;
        }

        [TearDown]
        public void TearDown()
        {
        }

        [Test]
        public void
            CreateRecurringMinuteScheduleForEvery10MinutesFrom5AM15To8PM05BetweenFeb12AndDec21In2002ShouldDescribeFrom5AM15To8PM05
            ()
        {
            Assert.AreEqual(new Time(5, 15), recurringMinuteSchedule.StartTime);
            Assert.AreEqual(new Time(20, 05), recurringMinuteSchedule.EndTime);
        }

        [Test]
        public void
            CreateRecurringMinuteScheduleForEvery10MinutesFrom5AM15To8PM05BetweenFeb12AndDec21In2002ShouldDescribeDateRangeFromFeb12ToDec21In2002
            ()
        {
            Assert.AreEqual(new Date(2002, 2, 12), recurringMinuteSchedule.StartDate);
            Assert.AreEqual(new Date(2002, 12, 21), recurringMinuteSchedule.EndDate);
        }

        [Test]
        public void
            CreateRecurringMinuteScheduleForEvery10MinutesFrom5AM15To8PM05BetweenFeb12AndDec21In2002ShouldDescribeEveryThreeHours
            ()
        {
            Assert.AreEqual(10, recurringMinuteSchedule.Frequency);
        }

        [Test]
        public void RecurringMinuteScheduleShouldBeSerializable()
        {
            Assert.IsTrue(typeof (RecurringMinuteSchedule).IsSerializable);
        }

        [Test]
        public void RecurringMinuteScheduleShouldImplementISchedule()
        {
            Assert.IsTrue(recurringMinuteSchedule is ISchedule);
        }

        [Test]
        public void TypeNameShouldReturnRecurringMinute()
        {
            Assert.AreEqual(ScheduleType.ByMinute,
                            RecurringMinuteScheduleFixture.
                                CreateEvery10MinutesFrom5AM15To8PM05BetweenFeb12AndDec21In2002().Type);
        }

        [Test]
        public void TwoRecurringMinuteSchedulesWithTheSameValuesShouldBeEqual()
        {
            Assert.AreEqual(
                RecurringMinuteScheduleFixture.CreateEvery10MinutesFrom5AM15To8PM05BetweenFeb12AndDec21In2002(),
                RecurringMinuteScheduleFixture.CreateEvery10MinutesFrom5AM15To8PM05BetweenFeb12AndDec21In2002());
        }

        [Test]
        public void IsNextScheduledTimeValidShouldBeValid()
        {
            Clock.Freeze();
            Clock.Now = new DateTime(2000, 01, 01, 1, 30, 0);

            ISchedule schedule =
                RecurringMinuteScheduleFixture.CreateEvery2MinutesFrom1AM15To1AM25FromJan12000ToJan32000();
            Assert.IsTrue(schedule.IsNextScheduledTimeValid);
            Clock.UnFreeze();
        }

        [Test]
        public void IsNextScheduledTimeValidShouldBeInvalidValidIfNextInvokeTimeDateTimeIsGreaterthanThanEndDateTime()
        {
            Clock.Freeze();
            Clock.Now = new DateTime(2007, 02, 01, 11, 0, 0);

            ISchedule schedule =
                RecurringMinuteScheduleFixture.CreateEvery2MinutesFrom1AM15To1AM25FromJan12000ToJan32000();
            Assert.IsFalse(schedule.IsNextScheduledTimeValid);
            Clock.UnFreeze();
        }

        [Test]
        public void IsNextScheduledTimeValidShouldBeInvalidValidIfFrequencyIsZero()
        {
            Clock.Freeze();
            Clock.Now = new DateTime(2006, 01, 01, 11, 0, 0);

            Time fromTime = new Time(12, 00);
            Time toTime = new Time(12, 00);
            Date startDate = new Date(2006, 1, 1);
            Date endDate = new Date(2006, 12, 31);
            const int frequency = 0;
            ISchedule recurringHourlySchedule =
                new RecurringMinuteSchedule(startDate, endDate, fromTime, toTime, frequency, SiteFixture.Sarnia());
            Assert.IsFalse(recurringHourlySchedule.IsNextScheduledTimeValid);
            Clock.UnFreeze();
        }

        [Test]
        public void IfCurrentDateTimeIsPastScheduleEndDateTimeScheduleShouldBeInvalid()
        {
            Clock.Freeze();
            ISchedule schedule =
                RecurringMinuteScheduleFixture.CreateEvery2MinutesFrom1AM15To1AM25FromJan12000ToJan32000();
            Clock.Now = new DateTime(2006, 4, 3, 4, 1, 0);
            Assert.IsFalse(schedule.IsNextScheduledTimeValid);
        }

        [Test]
        public void IfLastInvokedDateTimeIsPastScheduleEndDateTimeScheduleShouldBeInvalid()
        {
            Clock.Freeze();
            Clock.Now = new DateTime(2006, 4, 3, 4, 1, 0);

            ISchedule schedule =
                RecurringMinuteScheduleFixture.CreateEvery2MinutesFrom1AM15To1AM25FromJan12000ToJan32000();
            schedule.LastInvokedDateTime = new DateTime?(new DateTime(2006, 4, 3, 4, 1, 0));
            Assert.IsFalse(schedule.IsNextScheduledTimeValid);
        }

        [Test]
        public void IfStartDateTimeEqualToEndDateTimeShouldBeInvalid()
        {
            Clock.Freeze();
            Clock.Now = new DateTime(2006, 01, 01, 11, 0, 0);

            Date startDate = new Date(2006, 01, 01);
            Date endDate = new Date(2006, 01, 01);
            Time startTime = new Time(10, 1, 55);
            Time endTime = new Time(10, 1, 55);
            ISchedule schedule =
                new RecurringMinuteSchedule(startDate, endDate, startTime, endTime, 0, SiteFixture.Sarnia());
            Assert.IsFalse(schedule.IsNextScheduledTimeValid);
            Clock.UnFreeze();
        }

        [Test]
        public void IfStartDateTimeGreaterThanoEndDateTimeShouldBeInvalid()
        {
            Clock.Freeze();
            Clock.Now = new DateTime(2006, 01, 01, 11, 0, 0);

            Date startDate = new Date(2006, 01, 01);
            Date endDate = new Date(2006, 01, 01);
            Time startTime = new Time(10, 1, 56);
            Time endTime = new Time(10, 1, 55);
            ISchedule schedule =
                new RecurringMinuteSchedule(startDate, endDate, startTime, endTime, 0, SiteFixture.Sarnia());
            Assert.IsFalse(schedule.IsNextScheduledTimeValid);
            Clock.UnFreeze();
        }

        [Test]
        public void ShouldDeterminePreviousOccurrenceGivenDateTime()
        {
            DateTime someTime = new DateTime(2006, 5, 12, 12, 59, 59);
            Assert.AreEqual(someTime.AddMinutes(-1), CreateMinuteSchedule(1).GetPreviousOccurrence(someTime));
            Assert.AreEqual(someTime.AddMinutes(-2), CreateMinuteSchedule(2).GetPreviousOccurrence(someTime));
        }

        private static RecurringMinuteSchedule CreateMinuteSchedule(int frequency)
        {
            return new RecurringMinuteSchedule(new Date(2006, 1, 1), new Date(2006, 1, 1),
                                               Time.MIDNIGHT, Time.END_OF_DAY, frequency, SiteFixture.Sarnia());
        }

        [Test]
        public void ShouldShowToStringWithEndTimeProperly()
        {
            CultureInfoTestHelper.SetFormatsForEnglishFromResourceFile();

            Date startDate = new Date(2011, 05, 06);
            Date endDate = new Date(2011, 07, 08);
            Time fromTime = new Time(4, 0);
            Time endTime = new Time(15, 15);

            RecurringMinuteSchedule schedule =
                    new RecurringMinuteSchedule(startDate, endDate, fromTime, endTime, 3, SiteFixture.Sarnia());

            Assert.That(schedule.ToString(true),
                        Is.EqualTo("Every 3 minute(s) from 05/06/2011 to 07/08/2011 between 04:00 and 15:15"));

        }

        [Test]
        public void ShouldShowToStringWithNoEndTimeProperly()
        {
            CultureInfoTestHelper.SetFormatsForEnglishFromResourceFile();

            Date startDate = new Date(2011, 05, 06);
            Date endDate = new Date(2011, 07, 08);
            Time fromTime = new Time(4, 0);
            Time endTime = new Time(15, 15);

            RecurringMinuteSchedule schedule =
                    new RecurringMinuteSchedule(startDate, endDate, fromTime, endTime, 3, SiteFixture.Sarnia());

            Assert.That(schedule.ToString(false),
                        Is.EqualTo("Every 3 minute(s) from 05/06/2011 to 07/08/2011 at 04:00"));
        }

        [Test]
        public void ShouldShowRecurrincePatternProperly()
        {
            CultureInfoTestHelper.SetFormatsForEnglishFromResourceFile();

            Date startDate = new Date(2011, 05, 06);
            Date endDate = new Date(2011, 07, 08);
            Time fromTime = new Time(4, 0);
            Time endTime = new Time(15, 15);

            RecurringMinuteSchedule schedule =
                    new RecurringMinuteSchedule(startDate, endDate, fromTime, endTime, 3, SiteFixture.Sarnia());

            Assert.That(schedule.RecurrencePatternString,
                        Is.EqualTo("Every 3 minute(s)"));
        }
    }
}