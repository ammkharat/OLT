using System;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Utility;
using NUnit.Framework;

namespace Com.Suncor.Olt.Common.Domain.Schedule
{
    [TestFixture]
    public class ScheduleHelperTest
    {
        [Test]
        public void ShouldHandleWeirdScheduleStartTimeCaseWhereTheEndTimeIsAfterTheScheduleFireTime()
        {
            DateTime now = new DateTime(2000, 1, 1, 6, 0, 0);
            Date scheduleStartDate = new Date(1999, 5, 1);
            Date scheduleEndDate = new Date(2001, 5, 1);
            Time startTime = new Time(8);
            Time endTime = new Time(7);

            RecurringDailySchedule recurringDailySchedule = RecurringDailyScheduleFixture.CreateRecurringDailySchedule(scheduleStartDate, scheduleEndDate, startTime, endTime);

            Clock.Freeze();
            Clock.Now = new DateTime(2000, 1, 1, 6, 0, 0);
            DateTime expectedInstanceStartTime = startTime.ToDateTime(new Date(2000, 1, 1));
                       
            DateTime instanceStartTime = ScheduleHelper.GetScheduleInstanceStartDateTime(recurringDailySchedule, now, 120);
            
            Assert.AreEqual(expectedInstanceStartTime, instanceStartTime);
            Clock.UnFreeze();
        }

        [Test]
        public void ShouldHandleScheduleStartTimeCaseWhereTheEndTimeIsTheSameAsTheStartTime()
        {
            DateTime now = new DateTime(2000, 1, 1, 6, 0, 0);
            Date scheduleStartDate = new Date(1999, 5, 1);
            Date scheduleEndDate = new Date(2001, 5, 1);
            Time startTime = new Time(8);
            Time endTime = new Time(8);

            RecurringDailySchedule recurringDailySchedule = RecurringDailyScheduleFixture.CreateRecurringDailySchedule(scheduleStartDate, scheduleEndDate, startTime, endTime);
           
            DateTime expectedInstanceStartTime = startTime.ToDateTime(new Date(2000, 1, 1));
                       
            DateTime instanceStartTime = ScheduleHelper.GetScheduleInstanceStartDateTime(recurringDailySchedule, now, 120);
            
            Assert.AreEqual(expectedInstanceStartTime, instanceStartTime);
            Clock.UnFreeze();
        }

        [Test]
        public void ShouldReturnScheduleInstanceStartTimeShouldBeJan3_2000_10pmWithCurrentDateTimeJan3_2000_8pm()
        {
            Clock.Freeze();
            Clock.Now = new DateTime(2000, 1, 3, 20, 0, 0);
            var expectedInstanceStartTime = new DateTime(2000, 1, 3, 22, 0, 0);
            ISchedule recurringWeeklySchedule = RecurringWeeklyScheduleFixture.CreateEveryOtherMondayAndFridayFrom10pmTO2amBetweenJan1AndOct10In2000();
            DateTime instanceStartTime = ScheduleHelper.GetScheduleInstanceStartDateTime(recurringWeeklySchedule, Clock.Now, 0);
            Assert.AreEqual(expectedInstanceStartTime, instanceStartTime);
            Clock.UnFreeze();
        }

        [Test]
        public void ShouldReturnScheduleInstanceStartTimeShouldBeJan3_8amWithCurrentDateTimeJan3_2000_8am()
        {
            Clock.Freeze();
            Clock.Now = new DateTime(2000, 1, 3, 8, 0, 0);
            var expectedInstanceStartTime = new DateTime(2000, 1, 3, 8, 0, 0);
            ISchedule recurringWeeklySchedule = RecurringWeeklyScheduleFixture.CreateEveryMondayAndFridayFrom8AMTO2PMBetweenJan1AndOct10In2000();
            DateTime instanceStartTime = ScheduleHelper.GetScheduleInstanceStartDateTime(recurringWeeklySchedule, Clock.Now, 0);
            Assert.AreEqual(expectedInstanceStartTime, instanceStartTime);
            Clock.UnFreeze();
        }

        [Test]
        public void ShouldReturnScheduleInstanceStartTimeShouldBeJan3_2000_2amWithCurrentDateTimeJan2_2000_8pm()
        {
            Clock.Freeze();
            Clock.Now = new DateTime(2000, 1, 2, 20, 0, 0);
            var expectedInstanceStartTime = new DateTime(2000, 1, 3, 2, 0, 0);
            ISchedule recurringWeeklySchedule = RecurringWeeklyScheduleFixture.CreateEveryOtherMondayAndFridayFrom2AMTO3amBetweenJan1AndOct10In2000();
            DateTime instanceStartTime = ScheduleHelper.GetScheduleInstanceStartDateTime(recurringWeeklySchedule, Clock.Now, 0);
            Assert.AreEqual(expectedInstanceStartTime, instanceStartTime);
            Clock.UnFreeze();
        }

        [Test]
        public void ShouldPutStartTimeOnSameDayIfSchedulerFiresBeforeDefinitionTimeRange()
        {
            Clock.Freeze();
            Clock.Now = new DateTime(2000, 1, 2, 01, 00, 00);
            ISchedule schedule = new RecurringDailySchedule(Clock.DateNow, Clock.DateNow, new Time(02, 00), new Time(05, 00), 1, SiteFixture.Sarnia());

            Assert.AreEqual(new DateTime(2000, 1, 2, 02, 00, 00), ScheduleHelper.GetScheduleInstanceStartDateTime(schedule, Clock.Now, 0));

            Clock.UnFreeze();
        }

        [Test]
        public void ShouldPutStartTimeOnSameDayIfSchedulerFiresWithinDefinitionTimeRange()
        {
            Clock.Freeze();
            Clock.Now = new DateTime(2000, 1, 2, 03, 00, 00);
            ISchedule schedule = new RecurringDailySchedule(Clock.DateNow, Clock.DateNow, new Time(02, 00), new Time(05, 00), 1, SiteFixture.Sarnia());

            Assert.AreEqual(new DateTime(2000, 1, 2, 02, 00, 00), ScheduleHelper.GetScheduleInstanceStartDateTime(schedule, Clock.Now, 0));

            Clock.UnFreeze();
        }

        [Test]
        public void ShouldPutStartTimeOnFirstDayIfDefinitionTimeRangeCrossesDayBoundaryAndSchedulerFiresWithinRangeOnSecondDay()
        {
            Clock.Freeze();
            Clock.Now = new DateTime(2000, 1, 2, 02, 00, 00);
            ISchedule schedule = new RecurringDailySchedule(new Date(2000, 1, 1), new Date(2000, 12, 31), new Time(22, 00), new Time(03, 00), 1, SiteFixture.Sarnia());

            Assert.AreEqual(new DateTime(2000, 1, 1, 22, 00, 00), ScheduleHelper.GetScheduleInstanceStartDateTime(schedule, Clock.Now, 0));

            Clock.UnFreeze();
        }

        [Test]
        public void ShouldReturnScheduleInstanceEndTimeShouldBeJan3_2pmWithCurrentDateTimeJan3_2000_8am()
        {
            Clock.Freeze();
            Clock.Now = new DateTime(2000, 1, 3, 8, 0, 0);
            var expectedInstanceEndTime = new DateTime(2000, 1, 3, 14, 0, 0);
            ISchedule recurringWeeklySchedule =
                RecurringWeeklyScheduleFixture.CreateEveryMondayAndFridayFrom8AMTO2PMBetweenJan1AndOct10In2000();
            DateTime instanceEndTime =
                ScheduleHelper.GetScheduleInstanceEndDateTime(recurringWeeklySchedule, Clock.Now, 0);
            Assert.AreEqual(expectedInstanceEndTime, instanceEndTime);
            Clock.UnFreeze();
        }

        [Test]
        public void ShouldReturnScheduleInstanceEndTimeShouldBeJan3_3amWithCurrentDateTimeJan2_2000_8pm()
        {
            Clock.Freeze();
            Clock.Now = new DateTime(2000, 1, 2, 20, 0, 0);
            var expectedInstanceEndTime = new DateTime(2000, 1, 3, 3, 0, 0);
            ISchedule recurringWeeklySchedule =
                RecurringWeeklyScheduleFixture.CreateEveryOtherMondayAndFridayFrom2AMTO3amBetweenJan1AndOct10In2000();
            DateTime instanceEndTime =
                ScheduleHelper.GetScheduleInstanceEndDateTime(recurringWeeklySchedule, Clock.Now, 0);
            Assert.AreEqual(expectedInstanceEndTime, instanceEndTime);
            Clock.UnFreeze();
        }

        [Test]
        public void ShouldReturnScheduleInstanceEndTimeShouldBeJan4_2amWithCurrentDateTimeJan3_2000_8pm()
        {
            Clock.Freeze();
            Clock.Now = new DateTime(2000, 1, 3, 20, 0, 0);
            var expectedInstanceEndTime = new DateTime(2000, 1, 4, 2, 0, 0);
            ISchedule recurringWeeklySchedule =
                RecurringWeeklyScheduleFixture.CreateEveryOtherMondayAndFridayFrom10pmTO2amBetweenJan1AndOct10In2000();
            DateTime instanceEndTime =
                ScheduleHelper.GetScheduleInstanceEndDateTime(recurringWeeklySchedule, Clock.Now, 0);
            Assert.AreEqual(expectedInstanceEndTime, instanceEndTime);
            Clock.UnFreeze();
        }
    }
}
