using System;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Utility;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.Schedulers.Common
{
    [TestFixture]
    public class ScheduleBatchCollectionTest
    {
        [SetUp]
        public void SetUp()
        {
            Clock.UnFreeze();
        }

        [Test]
        public void AddScheduleShouldCreateFirstItemInCollection()
        {
            var collection = new ScheduleBatchCollection(OltTimeZoneInfo.Local);
            var scheduleA = RecurringMinuteScheduleFixture.CreateEvery10MinutesFrom5AM15To8PM05BetweenFeb12Onward();
            scheduleA.LastInvokedDateTime = Clock.Now.AddDays(-1);
            scheduleA.Id = 1000;

            collection.AddSchedule(scheduleA);
            Assert.That(collection.IsEmpty, Is.False);
            Assert.That(collection.First, Is.Not.Null);
        }

        [Test]
        public void ShouldAddTwoSchedulesToTheSameBatch()
        {
            Clock.Freeze();
            Clock.Now = new DateTime(2013, 07, 01, 04, 0, 0);
            var collection = new ScheduleBatchCollection(OltTimeZoneInfo.Local);

            var scheduleA = RecurringMinuteScheduleFixture.CreateEvery10MinutesFrom5AM15To8PM05BetweenFeb12Onward();
            scheduleA.LastInvokedDateTime = Clock.Now.AddDays(-5);
            scheduleA.Id = 111;
            var batchA = collection.AddSchedule(scheduleA);

            var scheduleB = RecurringMinuteScheduleFixture.CreateEvery10MinutesFrom5AM15To8PM05BetweenFeb12Onward();
            scheduleB.LastInvokedDateTime = Clock.Now.AddDays(-1);
            scheduleB.Id = 222;
            var batchB = collection.AddSchedule(scheduleB);

            Assert.That(batchA, Is.EqualTo(batchB));
        }

        [Test]
        public void ShouldBeAbleToRemoveSchedule()
        {
            Clock.Freeze();
            Clock.Now = new DateTime(2013, 07, 01, 04, 0, 0);
            Clock.TimeZone = OltTimeZoneInfo.Local;

            var collection = new ScheduleBatchCollection(OltTimeZoneInfo.Local);

            var scheduleA = RecurringMinuteScheduleFixture.CreateEvery10MinutesFrom5AM15To8PM05BetweenFeb12Onward();
            scheduleA.LastInvokedDateTime = Clock.Now.AddDays(-1);
            scheduleA.Id = 111;
            var batchA = collection.AddSchedule(scheduleA);

            var scheduleB = RecurringMinuteScheduleFixture.CreateEvery10MinutesFrom5AM15To8PM05BetweenFeb12Onward();
            scheduleB.StartTime = scheduleB.StartTime.AddMinutes(-15); // make schedule b start a 5am instead of 5:15am.
            scheduleB.LastInvokedDateTime = Clock.Now.AddDays(-1);
            scheduleB.Id = 222;
            collection.AddSchedule(scheduleB);

            Assert.True(collection.IsInFirstBatch(scheduleA));

            collection.RemoveSchedule(scheduleA);

            Assert.True(collection.IsInFirstBatch(scheduleB));
        }

        [Test]
        public void ShouldBeOnlyScheduleInFirstBatch()
        {
            Clock.Freeze();
            Clock.Now = new DateTime(2013, 07, 01, 04, 0, 0);
            Clock.TimeZone = OltTimeZoneInfo.Local;

            var collection = new ScheduleBatchCollection(OltTimeZoneInfo.Local);

            var scheduleA = RecurringMinuteScheduleFixture.CreateEvery10MinutesFrom5AM15To8PM05BetweenFeb12Onward();
            scheduleA.LastInvokedDateTime = Clock.Now.AddDays(-1);
            scheduleA.Id = 111;
            collection.AddSchedule(scheduleA);

            var scheduleB = RecurringMinuteScheduleFixture.CreateEvery10MinutesFrom5AM15To8PM05BetweenFeb12Onward();
            scheduleB.StartTime = scheduleB.StartTime.AddMinutes(-15); // make schedule b start a 5am instead of 5:15am.
            scheduleB.LastInvokedDateTime = Clock.Now.AddDays(-1);
            scheduleB.Id = 222;
            collection.AddSchedule(scheduleB);

            Assert.IsTrue(collection.IsOnlyScheduleInFirstBatch(scheduleA));
        }

        [Test]
        public void ShouldFindBatchAnotherScheduleInFirstBatch()
        {
            var collection = new ScheduleBatchCollection(OltTimeZoneInfo.Local);

            var scheduleA = RecurringMinuteScheduleFixture.CreateEvery10MinutesFrom5AM15To8PM05BetweenFeb12Onward();
            scheduleA.LastInvokedDateTime = Clock.Now.AddDays(-1);
            scheduleA.Id = 111;

            collection.AddSchedule(scheduleA);

            var scheduleB = RecurringMinuteScheduleFixture.CreateEvery2MinutesFrom1AM15To1AM25FromJan12000ToJan32000();
            scheduleB.LastInvokedDateTime = Clock.Now.AddDays(-10);
            scheduleB.Id = 111;

            // We search by id, don't care about the schedule part at all.
            Assert.That(collection.IsInFirstBatch(scheduleB), Is.True);
        }

        [Test]
        public void ShouldFindBatchWithSameSchedule()
        {
            var collection = new ScheduleBatchCollection(OltTimeZoneInfo.Local);

            var scheduleA = RecurringMinuteScheduleFixture.CreateEvery10MinutesFrom5AM15To8PM05BetweenFeb12Onward();
            scheduleA.LastInvokedDateTime = Clock.Now.AddDays(-1);
            scheduleA.Id = 111;

            collection.AddSchedule(scheduleA);

            var scheduleB = RecurringMinuteScheduleFixture.CreateEvery10MinutesFrom5AM15To8PM05BetweenFeb12Onward();
            scheduleB.LastInvokedDateTime = Clock.Now.AddDays(-10);
            scheduleB.Id = 222;

            Assert.That(collection.HasExistingBatchForSchedule(scheduleB), Is.True);
        }

        [Test]
        public void ShouldFindScheduleInFirstItemOfCollection()
        {
            var collection = new ScheduleBatchCollection(OltTimeZoneInfo.Local);

            var scheduleA = RecurringMinuteScheduleFixture.CreateEvery10MinutesFrom5AM15To8PM05BetweenFeb12Onward();
            scheduleA.LastInvokedDateTime = Clock.Now.AddDays(-1);
            scheduleA.Id = 1000;

            collection.AddSchedule(scheduleA);

            Assert.That(collection.First.Contains(scheduleA), Is.True);
        }

        [Test]
        public void ShouldNotFindBatchAnotherScheduleInFirstBatch()
        {
            Clock.Freeze();
            Clock.Now = new DateTime(2013, 07, 01, 04, 0, 0);
            Clock.TimeZone = OltTimeZoneInfo.Local;

            var collection = new ScheduleBatchCollection(OltTimeZoneInfo.Local);

            var scheduleA = RecurringMinuteScheduleFixture.CreateEvery10MinutesFrom5AM15To8PM05BetweenFeb12Onward();
            scheduleA.LastInvokedDateTime = Clock.Now.AddDays(-1);
            scheduleA.Id = 111;
            var batchA = collection.AddSchedule(scheduleA);

            var scheduleB = RecurringMinuteScheduleFixture.CreateEvery10MinutesFrom5AM15To8PM05BetweenFeb12Onward();
            scheduleB.StartTime = scheduleB.StartTime.AddMinutes(-15); // make schedule b start a 5am instead of 5:15am.
            scheduleB.LastInvokedDateTime = Clock.Now.AddDays(-1);
            scheduleB.Id = 222;
            var batchB = collection.AddSchedule(scheduleB);

            Assert.That(batchA, Is.Not.EqualTo(batchB));

            Assert.That(collection.ShouldBeFirst(batchB), Is.True);

            collection.Sort();

            Assert.That(collection.First, Is.EqualTo(batchB));
        }

        [Test]
        public void ShouldNotFindBatchWithSameSchedule()
        {
            var collection = new ScheduleBatchCollection(OltTimeZoneInfo.Local);

            var scheduleA = RecurringMinuteScheduleFixture.CreateEvery10MinutesFrom5AM15To8PM05BetweenFeb12Onward();
            scheduleA.LastInvokedDateTime = Clock.Now.AddDays(-1);
            scheduleA.Id = 111;

            collection.AddSchedule(scheduleA);

            var scheduleB = RecurringMinuteScheduleFixture.CreateEvery2MinutesFrom1AM15To1AM25FromJan12000ToJan32000();
            scheduleB.LastInvokedDateTime = Clock.Now.AddDays(-10);
            scheduleB.Id = 222;

            Assert.That(collection.HasExistingBatchForSchedule(scheduleB), Is.False);
        }

        [Test]
        public void ShouldPutTwoSchedulesWithSameTimesButDifferentSitesIntoTwoDifferentBatches()
        {
            Clock.Freeze();
            Clock.Now = new DateTime(2013, 07, 01, 04, 0, 0);
            Clock.TimeZone = OltTimeZoneInfo.Local;

            var collection = new ScheduleBatchCollection(OltTimeZoneInfo.Local);

            var scheduleA =
                RecurringMinuteScheduleFixture.CreateEvery10MinutesFrom5AM15To8PM05BetweenFeb12Onward(
                    SiteFixture.Denver());
            scheduleA.LastInvokedDateTime = Clock.Now.AddDays(-1);
            scheduleA.Id = 111;

            var scheduleB =
                RecurringMinuteScheduleFixture.CreateEvery10MinutesFrom5AM15To8PM05BetweenFeb12Onward(
                    SiteFixture.Oilsands());
            scheduleB.LastInvokedDateTime = Clock.Now.AddDays(-1);
            scheduleB.Id = 222;
            var scheduleBatchB = collection.AddSchedule(scheduleB);

            Assert.False(scheduleBatchB.Contains(scheduleA));
        }

        [Test]
        public void ShouldRemoveFirstBatch()
        {
            Clock.Freeze();
            Clock.Now = new DateTime(2013, 07, 01, 04, 0, 0);
            Clock.TimeZone = OltTimeZoneInfo.Local;

            var collection = new ScheduleBatchCollection(OltTimeZoneInfo.Local);
            Assert.True(collection.IsEmpty);
            collection.RemoveFirst();
            Assert.True(collection.IsEmpty);

            var scheduleA = RecurringMinuteScheduleFixture.CreateEvery10MinutesFrom5AM15To8PM05BetweenFeb12Onward();
            scheduleA.LastInvokedDateTime = Clock.Now.AddDays(-1);
            scheduleA.Id = 111;
            collection.AddSchedule(scheduleA);

            Assert.False(collection.IsEmpty);
            collection.RemoveFirst();
            Assert.IsTrue(collection.IsEmpty);
        }

        [Test]
        public void ShouldStartEmpty()
        {
            var collection = new ScheduleBatchCollection(OltTimeZoneInfo.Local);
            Assert.That(collection.IsEmpty, Is.True);
            Assert.That(collection.First, Is.Null);
        }
    }
}