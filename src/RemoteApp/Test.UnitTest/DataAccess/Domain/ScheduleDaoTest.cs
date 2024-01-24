using System;
using Com.Suncor.Olt.Common.Domain.Schedule;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    [TestFixture]
    [Category("Database")]
    public class ScheduleDaoTest : AbstractDaoTest
    {
        private IScheduleDao dao;

        [Ignore] [Test]
        public void ShouldDeleteASchedule()
        {
            var schedule =
                RecurringMonthlyScheduleFixture.
                    CreateFrom8AMTo12PMForLastDayOfJanuaryAndFebruaryBetweenJanuary1AndDecember31();
            dao.Insert(schedule);
            var queriedSchedule =
                (RecurringMonthlyDayOfMonthSchedule) dao.QueryById((long) schedule.Id);
            AssertSchedulesAreTheSame(schedule, queriedSchedule);
            dao.Delete(schedule);
            var deletedSchedule = dao.QueryById((long) schedule.Id);
            Assert.IsTrue(deletedSchedule.Deleted);
        }

        [Ignore] [Test]
        public void ShouldInsertAContinuousSchedule()
        {
            var schedule =
                ContinuousScheduleFixture.CreateContinuousScheduleFromOctober17AtStartDayToOctober27AtNoon();
            dao.Insert(schedule);
            var queriedSchedule = (ContinuousSchedule) dao.QueryById((long) schedule.Id);
            AssertSchedulesAreTheSame(schedule, queriedSchedule);
        }

        [Ignore] [Test]
        public void ShouldInsertAContinuousScheduleWithALastInvokeTime()
        {
            var schedule =
                ContinuousScheduleFixture.CreateContinuousScheduleFromOctober17AtMidnightToOctober27AtMidnight();
            DateTime? lastInvokeDateTime = new DateTime(1971, 08, 01);
            schedule.LastInvokedDateTime = lastInvokeDateTime;
            dao.Insert(schedule);
            var queriedSchedule = (ContinuousSchedule) dao.QueryById((long) schedule.Id);
            Assert.AreEqual(queriedSchedule.LastInvokedDateTime.Value.ToString(), lastInvokeDateTime.Value.ToString());
        }

        [Ignore] [Test]
        public void ShouldInsertARecurringDailySchedule()
        {
            var schedule =
                RecurringDailyScheduleFixture.CreateEvery2DaysFrom10AM12To07PM11BetweenJan10AndOct21In2000();
            dao.Insert(schedule);
            var queriedSchedule = (RecurringDailySchedule) dao.QueryById((long) schedule.Id);
            AssertSchedulesAreTheSame(schedule, queriedSchedule);
        }

        [Ignore] [Test]
        public void ShouldInsertARecurringDailyScheduleWithLastInvokeDateTime()
        {
            var schedule =
                RecurringDailyScheduleFixture.CreateEvery2DaysFrom10AM12To07PM11BetweenJan10AndOct21In2000();
//            DateTime? lastInvokeDateTime = new DateTime?(schedule.NextInvokeDateTime);
            DateTime? lastInvokeDateTime = new DateTime(2000, 01, 14, 10, 14, 0);
            schedule.LastInvokedDateTime = lastInvokeDateTime;
            dao.Insert(schedule);
            var queriedSchedule = (RecurringDailySchedule) dao.QueryById((long) schedule.Id);
            Assert.AreEqual(queriedSchedule.LastInvokedDateTime.Value.ToString(), lastInvokeDateTime.Value.ToString());
        }

        [Ignore] [Test]
        public void ShouldInsertARecurringDailyScheduleWithNoEndDate()
        {
            var schedule =
                RecurringDailyScheduleFixture.CreateEvery2DaysFrom10AM12To07PM11FromJan10Onward();
            dao.Insert(schedule);
            var queriedSchedule = (RecurringDailySchedule) dao.QueryById((long) schedule.Id);
            AssertSchedulesAreTheSame(schedule, queriedSchedule);
        }

        [Ignore] [Test]
        public void ShouldInsertARecurringHourlySchedule()
        {
            var schedule =
                RecurringHourlyScheduleFixture.CreateEvery3HoursFrom12AM00To12AM00BetweenJan01AndDec31In2006();
            dao.Insert(schedule);
            var queriedSchedule = (RecurringHourlySchedule) dao.QueryById((long) schedule.Id);
            AssertSchedulesAreTheSame(schedule, queriedSchedule);
        }

        [Ignore] [Test]
        public void ShouldInsertARecurringMinuteSchedule()
        {
            var schedule =
                RecurringMinuteScheduleFixture.CreateEvery10MinutesFrom5AM15To8PM05BetweenFeb12AndDec21In2002();
            dao.Insert(schedule);
            var queriedSchedule = (RecurringMinuteSchedule) dao.QueryById((long) schedule.Id);
            AssertSchedulesAreTheSame(schedule, queriedSchedule);
        }

        [Ignore] [Test]
        public void ShouldInsertARecurringMinuteScheduleWithNoEndDate()
        {
            var schedule =
                RecurringMinuteScheduleFixture.CreateEvery10MinutesFrom5AM15To8PM05BetweenFeb12Onward();
            dao.Insert(schedule);
            var queriedSchedule = (RecurringMinuteSchedule) dao.QueryById((long) schedule.Id);
            AssertSchedulesAreTheSame(schedule, queriedSchedule);
        }

        [Ignore] [Test]
        public void ShouldInsertARecurringMonthlyDayOfMonthSchedule()
        {
            var schedule =
                RecurringMonthlyScheduleFixture.
                    CreateFrom8AMTo12PMForLastDayOfJanuaryAndFebruaryBetweenJanuary1AndDecember31();
            dao.Insert(schedule);
            var queriedSchedule =
                (RecurringMonthlyDayOfMonthSchedule) dao.QueryById((long) schedule.Id);
            AssertSchedulesAreTheSame(schedule, queriedSchedule);
        }

        [Ignore] [Test]
        public void ShouldInsertARecurringMonthlyDayOfWeekSchedule()
        {
            var schedule =
                RecurringMonthlyScheduleFixture.
                    CreateFrom9AMTo4PMForSecondWednesdayOfMarchAndMayBetweenJanuary1AndDecember31();
            dao.Insert(schedule);
            var queriedSchedule =
                (RecurringMonthlyDayOfWeekSchedule) dao.QueryById((long) schedule.Id);
            AssertSchedulesAreTheSame(schedule, queriedSchedule);
        }

        [Ignore] [Test]
        public void ShouldInsertARecurringWeeklySchedule()
        {
            var schedule =
                RecurringWeeklyScheduleFixture.CreateEveryMondayAndFridayFrom8AMTO2PMBetweenJan1AndOct10In2000();
            dao.Insert(schedule);
            var queriedSchedule = (RecurringWeeklySchedule) dao.QueryById((long) schedule.Id);
            AssertSchedulesAreTheSame(schedule, queriedSchedule);
        }

        [Ignore] [Test]
        public void ShouldInsertASingleScheduleAndQueryItBackById()
        {
            var schedule = SingleScheduleFixture.CreateSingleScheduleOnOctober17From8AMTo12PM();
            dao.Insert(schedule);
            var queriedSchedule = (SingleSchedule) dao.QueryById((long) schedule.Id);
            AssertSchedulesAreTheSame(schedule, queriedSchedule);
        }

        [Ignore] [Test]
        public void ShouldInsertASingleScheduleAndQueryItBackByIdWithLastInvokeTime()
        {
            var schedule = SingleScheduleFixture.CreateSingleScheduleOnOctober17From8AMTo12PM();
            DateTime? lastInvokeDateTime = DateTimeFixture.DateTimeNow;
            schedule.LastInvokedDateTime = lastInvokeDateTime;
            dao.Insert(schedule);
            var queriedSchedule = (SingleSchedule) dao.QueryById((long) schedule.Id);
            // Can't assert because of rounding.  Need to use .Within
            // Assert.AreEqual(queriedSchedule.LastInvokedDateTime.Value.ToString(), lastInvokeDateTime.Value.ToString());
            Assert.That(lastInvokeDateTime,
                Is.EqualTo(queriedSchedule.LastInvokedDateTime.Value).Within(TimeSpan.FromSeconds(10)));
        }

        [Ignore] [Test]
        public void ShouldUpdateAContinuousSchedule()
        {
            var schedule =
                ContinuousScheduleFixture.CreateContinuousScheduleFromOctober17AtMidnightToOctober27AtMidnight();
            dao.Insert(schedule);
            var updatedSchedule =
                ContinuousScheduleFixture.CreateContinuousScheduleWithNoEndDateFromOctober17AtMidnight();
            updatedSchedule.Id = schedule.Id;
            dao.Update(updatedSchedule);
            var queriedSchedule = (ContinuousSchedule) dao.QueryById((long) schedule.Id);
            AssertSchedulesAreTheSame(updatedSchedule, queriedSchedule);
        }

        [Ignore] [Test]
        public void ShouldUpdateAContinuousScheduleWithALastInvokeDateTime()
        {
            var schedule =
                ContinuousScheduleFixture.CreateContinuousScheduleFromOctober17AtMidnightToOctober27AtMidnight();
            DateTime? lastInvokeDateTime = new DateTime(2005, 10, 18, 0, 0, 0);
            dao.Insert(schedule);
            Assert.IsFalse(schedule.LastInvokedDateTime.HasValue);
            var updatedSchedule =
                ContinuousScheduleFixture.CreateContinuousScheduleWithNoEndDateFromOctober17AtMidnight();
            updatedSchedule.Id = schedule.Id;
            updatedSchedule.LastInvokedDateTime = lastInvokeDateTime;
            dao.Update(updatedSchedule);
            var queriedSchedule = (ContinuousSchedule) dao.QueryById((long) schedule.Id);
            AssertSchedulesAreTheSame(updatedSchedule, queriedSchedule);
            Assert.AreEqual(updatedSchedule.LastInvokedDateTime.Value.ToString(), lastInvokeDateTime.Value.ToString());
        }

        [Ignore] [Test]
        public void ShouldUpdateARecurringDailySchedule()
        {
            var schedule =
                RecurringDailyScheduleFixture.CreateEvery2DaysFrom10AM12To07PM11BetweenJan10AndOct21In2000();
            dao.Insert(schedule);
            var updatedSchedule =
                RecurringDailyScheduleFixture.CreateEvery2DaysFrom2AMTo10AM11BetweenJan1AndJan5In2000();
            updatedSchedule.Id = schedule.Id;
            dao.Update(updatedSchedule);
            var queriedSchedule = (RecurringDailySchedule) dao.QueryById((long) schedule.Id);
            AssertSchedulesAreTheSame(updatedSchedule, queriedSchedule);
        }

        [Ignore] [Test]
        public void ShouldUpdateARecurringHourlySchedule()
        {
            var schedule =
                RecurringHourlyScheduleFixture.CreateEvery3HoursFrom12AM00To12AM00BetweenJan01AndDec31In2006();
            dao.Insert(schedule);
            var updatedSchedule =
                RecurringHourlyScheduleFixture.CreateEvery6HoursFrom2AMTo3PMBetweenJan12000AndJan22000();
            updatedSchedule.Id = schedule.Id;
            dao.Update(updatedSchedule);
            var queriedSchedule = (RecurringHourlySchedule) dao.QueryById((long) schedule.Id);
            AssertSchedulesAreTheSame(updatedSchedule, queriedSchedule);
        }

        [Ignore] [Test]
        public void ShouldUpdateARecurringMinuteSchedule()
        {
            var schedule =
                RecurringMinuteScheduleFixture.CreateEvery10MinutesFrom5AM15To8PM05BetweenFeb12AndDec21In2002();
            dao.Insert(schedule);
            var updatedSchedule =
                RecurringMinuteScheduleFixture.CreateEvery2MinutesFrom1AM15To1AM25FromJan12000ToJan32000();
            updatedSchedule.Id = schedule.Id;
            dao.Update(updatedSchedule);
            var queriedSchedule = (RecurringMinuteSchedule) dao.QueryById((long) schedule.Id);
            AssertSchedulesAreTheSame(updatedSchedule, queriedSchedule);
        }

        [Ignore] [Test]
        public void ShouldUpdateARecurringMonthlyDayOfMonthSchedule()
        {
            var schedule =
                RecurringMonthlyScheduleFixture.
                    CreateFrom8AMTo12PMForLastDayOfJanuaryAndFebruaryBetweenJanuary1AndDecember31();
            dao.Insert(schedule);
            var updatedSchedule =
                RecurringMonthlyScheduleFixture.
                    CreateFrom8AMTo12PMFor15thDayOfJanuaryAndFebruaryBetweenJanuary1AndDecember31();
            updatedSchedule.Id = schedule.Id;
            dao.Update(updatedSchedule);
            var queriedSchedule =
                (RecurringMonthlyDayOfMonthSchedule) dao.QueryById((long) schedule.Id);
            AssertSchedulesAreTheSame(updatedSchedule, queriedSchedule);
        }

        [Ignore] [Test]
        public void ShouldUpdateARecurringMonthlyDayOfWeekSchedule()
        {
//            ITimeService timeService;
//            timeService = new Mockery().NewMock<ITimeService>();
//            ServiceRegistry.RegisterServiceImplementation<ITimeService>(timeService);
            var schedule =
                RecurringMonthlyScheduleFixture.
                    CreateFrom9AMTo4PMForSecondWednesdayOfMarchAndMayBetweenJanuary1AndDecember31();
            dao.Insert(schedule);
            var updatedSchedule =
                RecurringMonthlyScheduleFixture.
                    CreateMonthlyScheduleFrom8AMTo5PMForTheLastFridayOfAllMonthsBetweenJanuary1AndDecember31();
            updatedSchedule.Id = schedule.Id;
            dao.Update(updatedSchedule);
            var queriedSchedule =
                (RecurringMonthlyDayOfWeekSchedule) dao.QueryById((long) schedule.Id);
//            Stub.On(timeService).Method("GetTime").Will(Return.Value(Clock.Now));
            AssertSchedulesAreTheSame(updatedSchedule, queriedSchedule);
        }

        [Ignore] [Test]
        public void ShouldUpdateARecurringScheduleWithLastInvokeDateTime()
        {
            var schedule =
                RecurringDailyScheduleFixture.CreateEvery2DaysFrom10AM12To07PM11BetweenJan10AndOct21In2000();
            DateTime? lastInvokeDateTime = new DateTime(2000, 1, 12, 10, 12, 0);
            dao.Insert(schedule);
            Assert.IsFalse(schedule.LastInvokedDateTime.HasValue);
            var updatedSchedule =
                RecurringDailyScheduleFixture.CreateEvery2DaysFrom2AMTo10AM11BetweenJan1AndJan5In2000();
            updatedSchedule.Id = schedule.Id;
            updatedSchedule.LastInvokedDateTime = lastInvokeDateTime;
            dao.Update(updatedSchedule);
            var queriedSchedule = (RecurringDailySchedule) dao.QueryById((long) schedule.Id);
            AssertSchedulesAreTheSame(updatedSchedule, queriedSchedule);
            Assert.AreEqual(updatedSchedule.LastInvokedDateTime.Value.ToString(), lastInvokeDateTime.Value.ToString());
        }

        [Ignore] [Test]
        public void ShouldUpdateARecurringWeeklySchedule()
        {
            var schedule =
                RecurringWeeklyScheduleFixture.CreateEveryMondayAndFridayFrom8AMTO2PMBetweenJan1AndOct10In2000();
            dao.Insert(schedule);
            var updatedSchedule =
                RecurringWeeklyScheduleFixture.CreateEveryOtherMondayAndFridayFrom8AMTO2PMBetweenJan1AndOct10In2000();
            updatedSchedule.Id = schedule.Id;
            dao.Update(updatedSchedule);
            var queriedSchedule = (RecurringWeeklySchedule) dao.QueryById((long) schedule.Id);
            AssertSchedulesAreTheSame(updatedSchedule, queriedSchedule);
        }

        [Ignore] [Test]
        public void ShouldUpdateASingleScheduleAndQueryItBackById()
        {
            var schedule = SingleScheduleFixture.CreateSingleScheduleOnOctober17From8AMTo12PM();
            dao.Insert(schedule);
            var updatedSchedule = SingleScheduleFixture.CreateSingleScheduleOnNov11From8AMTo12PM();
            updatedSchedule.Id = schedule.Id;
            dao.Update(updatedSchedule);
            var queriedSchedule = (SingleSchedule) dao.QueryById((long) schedule.Id);
            AssertSchedulesAreTheSame(updatedSchedule, queriedSchedule);
        }

        [Ignore] [Test]
        public void ShouldUpdateASingleScheduleWithALastInvokedDateTimeAndQueryItBackById()
        {
            var schedule = SingleScheduleFixture.CreateSingleScheduleOnOctober17From8AMTo12PM();
            DateTime? lastInvokeDateTime = new DateTime(2005, 10, 17, 8, 0, 0);
            dao.Insert(schedule);
            Assert.IsFalse(schedule.LastInvokedDateTime.HasValue);
            var updatedSchedule = SingleScheduleFixture.CreateSingleScheduleOnNov11From8AMTo12PM();
            updatedSchedule.Id = schedule.Id;
            updatedSchedule.LastInvokedDateTime = lastInvokeDateTime;
            dao.Update(updatedSchedule);
            var queriedSchedule = (SingleSchedule) dao.QueryById((long) schedule.Id);
            AssertSchedulesAreTheSame(updatedSchedule, queriedSchedule);
            Assert.AreEqual(updatedSchedule.LastInvokedDateTime.Value.ToString(), lastInvokeDateTime.Value.ToString());
        }

        protected override void TestInitialize()
        {
            dao = DaoRegistry.GetDao<IScheduleDao>();
        }

        protected override void Cleanup()
        {
        }

        private void AssertSchedulesAreTheSame(ISchedule expected, ISchedule actual)
        {
            if (expected == null && actual == null) return;

            var failMessage = "Expected: <{0}> But was: <{1}>";

            if ((expected == null && actual != null) || (actual == null && expected != null))
            {
                Assert.Fail(failMessage, expected.ToString(), actual.ToString());
            }

            var match = expected.IdValue.Equals(actual.IdValue) && expected.ToString().Equals(actual.ToString());
            if (match == false)
            {
                Assert.Fail(failMessage, expected.ToString(), actual.ToString());                
            }
        }
    }
}