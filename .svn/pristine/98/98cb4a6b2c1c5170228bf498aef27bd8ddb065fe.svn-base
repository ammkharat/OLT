using System;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Remote.Schedulers.Common;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Domain.Schedule
{
    [TestFixture]
    public class RecurringHourlyScheduleTest
    {
        RecurringHourlySchedule recurringHourlySchedule;

        [SetUp]
        public void SetUp()
        {
            Clock.Freeze();
            Clock.TimeZone = SiteFixture.Sarnia().TimeZone;
            recurringHourlySchedule = RecurringHourlyScheduleFixture.CreateEvery3HoursFrom12AM00To12AM00BetweenJan01AndDec31In2006();
        }

        [TearDown]
        public void TearDown()
        {
            Clock.UnFreeze();
        }

        [Test]
        public void RecurringHourlyScheduleForEvery3HoursFrom12AM00To12AM00BetweenJan01AndDec31In2006ShouldDescribeFrom12AM00To12AM00()
        {
            Assert.AreEqual(new Time(12, 00), recurringHourlySchedule.StartTime);
            Assert.AreEqual(new Time(12, 00), recurringHourlySchedule.EndTime);
        }

        [Test]
        public void RecurringHourlyScheduleForEvery3HoursFrom12AM00To12AM00BetweenJan01AndDec31In2006ShouldDescribeDateRangeFromJan1ToDec31In2006()
        {
            Assert.AreEqual(new Date(2006, 1, 1), recurringHourlySchedule.StartDate);
            Assert.AreEqual(new Date(2006, 12, 31), recurringHourlySchedule.EndDate);
        }

        [Test]
        public void RecurringHourlyScheduleForEvery3HoursFrom12AM00To12AM00BetweenJan01AndDec31In2006ShouldDescribeEveryThreeHours()
        {
            Assert.AreEqual(3, recurringHourlySchedule.Frequency);
        }

        [Test]
        public void RecurringHourlyScheduleShouldBeSerializable()
        {
            Assert.IsTrue(typeof(RecurringHourlySchedule).IsSerializable);
        }

        [Test]
        public void RecurringHourlyScheduleShouldImplementISchedule()
        {
            Assert.IsTrue(recurringHourlySchedule is ISchedule);
        }

        [Test]
        public void TypeNameShouldReturnRecurringHourly()
        {
            Assert.AreEqual(ScheduleType.Hourly, RecurringHourlyScheduleFixture.CreateEvery3HoursFrom12AM00To12AM00BetweenJan01AndDec31In2006().Type);
        }

        [Test]
        public void TwoRecurringHourlySchedulesWithTheSameValuesShouldBeEqual()
        {
            Assert.AreEqual(RecurringHourlyScheduleFixture.CreateEvery3HoursFrom12AM00To12AM00BetweenJan01AndDec31In2006(), RecurringHourlyScheduleFixture.CreateEvery3HoursFrom12AM00To12AM00BetweenJan01AndDec31In2006());
        }

        [Test]
        public void IsNextScheduledTimeValidShouldBeValid()
        {
            Clock.Now = new DateTime(2006, 01, 01, 11, 0, 0);
            
            ISchedule schedule = RecurringHourlyScheduleFixture.CreateEvery3HoursFrom12AM00To12AM00BetweenJan01AndDec31In2006();
            Assert.IsTrue(schedule.IsNextScheduledTimeValid);
        }

        [Test]
        public void IsNextScheduledTimeValidShouldBeInvalidValidIfNextInvokeTimeDateTimeIsGreaterthanThanEndDateTime()
        {
            Clock.Now = new DateTime(2007, 02, 01, 11, 0, 0);
            
            ISchedule schedule = RecurringHourlyScheduleFixture.CreateEvery3HoursFrom12AM00To12AM00BetweenJan01AndDec31In2006();
            Assert.IsFalse(schedule.IsNextScheduledTimeValid);
        }

        [Test]
        public void IsNextScheduledTimeValidShouldBeInvalidValidIfFrequencyIsZero()
        {
            Clock.Now = new DateTime(2006, 01, 01, 11, 0, 0);

            var noon = new Time(12, 0, 0);
            Time fromTime = noon;
            Time toTime = noon;
            Date startDate = new Date(2006, 1, 1);
            Date endDate = new Date(2006, 12, 31);
            const int frequency = 0;
            recurringHourlySchedule = new RecurringHourlySchedule(startDate, endDate, fromTime, toTime, frequency, SiteFixture.Sarnia());
            Assert.IsFalse(recurringHourlySchedule.IsNextScheduledTimeValid);
        }

        [Test]
        public void IfCurrentDateTimeIsPastScheduleEndDateTimeScheduleShouldBeInvalid()
        {
            ISchedule schedule = RecurringHourlyScheduleFixture.CreateRecurringHourlyScheduleBetweenApr1AndApr2From11pmTo4am();
            Clock.Now = new DateTime(2006, 4, 3, 4, 1, 0);
            Assert.IsFalse(schedule.IsNextScheduledTimeValid);
        }

        [Test]
        public void IfLastInvokedDateTimeIsPastScheduleEndDateTimeScheduleShouldBeInvalid()
        {
            Clock.Now = new DateTime(2006, 4, 3, 4, 1, 0);
            ISchedule schedule = RecurringHourlyScheduleFixture.CreateRecurringHourlyScheduleBetweenApr1AndApr2From11pmTo4am();
            schedule.LastInvokedDateTime = new DateTime?(new DateTime(2006, 4, 3, 4, 1, 0));
            Assert.IsFalse(schedule.IsNextScheduledTimeValid);
        }

        [Test]
        public void IfStartDateTimeEqualToEndDateTimeShouldBeInvalid()
        {
            Clock.Now = new DateTime(2006, 01, 01, 11, 0, 0);

            Date startDate = new Date(2006, 01, 01);
            Date endDate = new Date(2006, 01, 01);
            Time startTime = new Time(10, 1, 55);
            Time endTime = new Time(10, 1, 55);
            ISchedule schedule = new RecurringHourlySchedule(startDate, endDate, startTime, endTime, 0, SiteFixture.Sarnia());
            Assert.IsFalse(schedule.IsNextScheduledTimeValid);
        }

        [Test]
        public void IfStartDateTimeGreaterThanoEndDateTimeShouldBeInvalid()
        {
            Clock.Now = new DateTime(2006, 01, 01, 11, 0, 0);

            Date startDate = new Date(2006, 01, 01);
            Date endDate = new Date(2006, 01, 01);
            Time startTime = new Time(10, 1, 56);
            Time endTime = new Time(10, 1, 55);
            ISchedule schedule = new RecurringHourlySchedule(startDate, endDate, startTime, endTime, 0, SiteFixture.Sarnia());
            Assert.IsFalse(schedule.IsNextScheduledTimeValid);
        }

        [Test]
        public void ShouldDeterminePreviousOccurrenceGivenDateTime()
        {
            DateTime someTime = new DateTime(2006, 5, 12, 12, 59, 59);
            Assert.AreEqual(someTime.AddHours(-1), CreateHourlySchedule(1).GetPreviousOccurrence(someTime));
            Assert.AreEqual(someTime.AddHours(-2), CreateHourlySchedule(2).GetPreviousOccurrence(someTime));
        }

        [Test]
        public void ShouldRunEveryHour()
        {
            //Clock.UnFreeze(); // want to run this for real to try to reproduce a bug
            Clock.Now = new DateTime(2013, 06, 14, 21, 44, 0);

            DateTime dateTime = Clock.Now;
            // The bug is that if you set start and end time to the current time, then you don't get what you expect here.
//            RecurringHourlySchedule hourlySchedule =
//                new RecurringHourlySchedule(-1, dateTime.ToDate(), null, dateTime.ToTime(), dateTime.ToTime(), 4, null, SiteFixture.Denver());

            RecurringHourlySchedule hourlySchedule = 
                new RecurringHourlySchedule(-1, dateTime.ToDate(), null, Time.MIDNIGHT, Time.END_OF_DAY, 4, null, SiteFixture.Denver());
            
            DateTime lastInvokedDateTime = hourlySchedule.NextInvokeDateTime;
            hourlySchedule.LastInvokedDateTime = lastInvokedDateTime;
            
            DateTime nextInvokeDateTime = hourlySchedule.NextInvokeDateTime;
            Assert.That(nextInvokeDateTime.Subtract(lastInvokedDateTime), Is.EqualTo(new TimeSpan(0, 4, 0, 0)));
        }

        [Test]
        public void Defect_1889_and_808_Test()
        {
            Clock.TimeZone = TimeZoneFixture.GetMountainTimeZone();
            CultureInfoTestHelper.SetFormatsForEnglishFromResourceFile();

            RecurringHourlySchedule hourlySchedule = new RecurringHourlySchedule(new Date(2009, 1, 1), null, new Time(0, 0, 0), new Time(23, 59, 59), 1, SiteFixture.Oilsands());
            hourlySchedule.LastInvokedDateTime = new DateTime(2012, 3, 11, 1, 0, 0);   // timezone change is on March 11 at 2am

            TimeZoneConvertedSchedule schedule = new TimeZoneConvertedSchedule(hourlySchedule, TimeZoneFixture.GetMountainTimeZone());
            DateTime nextInvokeDateTime = schedule.NextInvokeDateTime;  // this used to throw an exception
            Assert.That(nextInvokeDateTime, Is.EqualTo(new DateTime(2012, 3, 11, 3, 0, 0)));
        }

        private static RecurringHourlySchedule CreateHourlySchedule(int frequency)
        {
            return new RecurringHourlySchedule(new Date(2006, 1, 1), new Date(2006, 1, 1),
                Time.MIDNIGHT, Time.END_OF_DAY, frequency, SiteFixture.Sarnia());
        }
    }
}