using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Utility;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.Schedulers.Common
{
    [TestFixture]
    public class ScheduleBatchTest
    {
        [Test]
        public void ShouldFindBatchWithSameSchedule()
        {
            var scheduleA = RecurringMinuteScheduleFixture.CreateEvery10MinutesFrom5AM15To8PM05BetweenFeb12Onward();
            scheduleA.LastInvokedDateTime = Clock.Now.AddDays(-1);
            scheduleA.Id = 1000;

            var scheduleBatch = new ScheduleBatch(scheduleA, OltTimeZoneInfo.Local);
            scheduleBatch.AddSchedule(scheduleA);

            Assert.That(scheduleBatch.ScheduleCount, Is.GreaterThan(0));

            var scheduleB = RecurringMinuteScheduleFixture.CreateEvery10MinutesFrom5AM15To8PM05BetweenFeb12Onward();
            scheduleB.LastInvokedDateTime = Clock.Now;
            scheduleB.Id = 4000;

            Assert.IsTrue(scheduleBatch.HasSameSchedule(scheduleB));
        }

        [Test]
        public void ShouldFindBatchWithSameScheduleAsAnotherBatch()
        {
            var scheduleA = RecurringMinuteScheduleFixture.CreateEvery10MinutesFrom5AM15To8PM05BetweenFeb12Onward();
            scheduleA.LastInvokedDateTime = Clock.Now.AddDays(-1);
            scheduleA.Id = 1000;

            var scheduleBatch = new ScheduleBatch(scheduleA, OltTimeZoneInfo.Local);
            scheduleBatch.AddSchedule(scheduleA);

            Assert.That(scheduleBatch.ScheduleCount, Is.GreaterThan(0));

            var scheduleB = RecurringMinuteScheduleFixture.CreateEvery10MinutesFrom5AM15To8PM05BetweenFeb12Onward();
            scheduleB.LastInvokedDateTime = Clock.Now;
            scheduleB.Id = 4000;

            Assert.IsTrue(scheduleBatch.HasSameSchedule(scheduleB));
        }

        [Test]
        public void ShouldFindScheduleById()
        {
            var scheduleA = RecurringMinuteScheduleFixture.CreateEvery10MinutesFrom5AM15To8PM05BetweenFeb12Onward();
            scheduleA.LastInvokedDateTime = Clock.Now.AddDays(-1);
            scheduleA.Id = 1000;

            var scheduleBatch = new ScheduleBatch(scheduleA, OltTimeZoneInfo.Local);
            scheduleBatch.AddSchedule(scheduleA);

            var scheduleB = RecurringMinuteScheduleFixture.CreateEvery10MinutesFrom5AM15To8PM05BetweenFeb12Onward();
            scheduleB.LastInvokedDateTime = Clock.Now;
            scheduleB.Id = 1000;

            Assert.IsTrue(scheduleBatch.Contains(scheduleB));
        }

        [Test]
        public void ShouldRemoveSchedule()
        {
            var scheduleA = RecurringMinuteScheduleFixture.CreateEvery10MinutesFrom5AM15To8PM05BetweenFeb12Onward();
            scheduleA.LastInvokedDateTime = Clock.Now.AddDays(-1);
            scheduleA.Id = 1000;

            var scheduleBatch = new ScheduleBatch(scheduleA, OltTimeZoneInfo.Local);
            scheduleBatch.AddSchedule(scheduleA);

            Assert.That(scheduleBatch.ScheduleCount, Is.GreaterThan(0));

            var scheduleB = RecurringMinuteScheduleFixture.CreateEvery10MinutesFrom5AM15To8PM05BetweenFeb12Onward();
            scheduleB.LastInvokedDateTime = Clock.Now;
            scheduleB.Id = 1000;

            scheduleBatch.RemoveSchedule(scheduleB);
            Assert.That(scheduleBatch.ScheduleCount, Is.EqualTo(0));
        }
    }
}