using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Schedule;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Utility;
using NUnit.Framework;
using Rhino.Mocks;
using Is = Rhino.Mocks.Constraints.Is;
using ListConstraint = Rhino.Mocks.Constraints.List;

namespace Com.Suncor.Olt.Remote.Schedulers.Common
{
    [TestFixture]
    public class BatchingSchedulerTest
    {
        private const long MILLISECONDS_IN_MIN = 60*1000;
        private const long MILLISECONDS_IN_HR = 60*MILLISECONDS_IN_MIN;
        private const long MILLISECONDS_IN_DAY = 24*MILLISECONDS_IN_HR;
        private const long zero = 0;
        private IBatchHandler mockBatchHandler;
        private IStopWatch mockBlastOffStopWatch;
        private IStopWatch mockRestartStopWatch;
        private BatchingScheduler scheduler;
        private SingleSchedule single1MinTo2Min;

        [SetUp]
        public void SetUp()
        {
            Clock.Freeze();
            Clock.Now = new DateTime(1999, 12, 31, 23, 0, 0);
            Clock.TimeZone = TimeZoneFixture.GetSarniaTimeZone();

            single1MinTo2Min = SingleScheduleFixture.Create2000Jan1AM1MinTo2Min();

            mockBlastOffStopWatch = MockRepository.GenerateMock<IStopWatch>();
            mockRestartStopWatch = MockRepository.GenerateMock<IStopWatch>();
            mockBatchHandler = MockRepository.GenerateMock<IBatchHandler>();

            scheduler = new BatchingScheduler(mockBlastOffStopWatch, mockRestartStopWatch,
                TimeZoneFixture.GetMountainTimeZone()) {BatchHandler = mockBatchHandler};
        }

        [TearDown]
        public void TearDown()
        {
            Clock.UnFreeze();
        }

        [Test]
        public void ShouldAddScheduleAndSetToFire()
        {
            mockBlastOffStopWatch.Stub(sw => sw.Stop());

            mockBlastOffStopWatch.Expect(sw => sw.CountDown(MILLISECONDS_IN_MIN, new DateTime(1999, 12, 31, 23, 1, 0)));
            scheduler.AddSchedule(single1MinTo2Min);

            mockBlastOffStopWatch.VerifyAllExpectations();
        }

        [Test]
        public void ShouldAddTwoDifferentSchedulesAndResetTimerTwice()
        {
            mockBlastOffStopWatch.Stub(sw => sw.Stop());

            mockBlastOffStopWatch.Expect(sw => sw.CountDown(MILLISECONDS_IN_MIN, new DateTime(1999, 12, 31, 23, 1, 0)));
            scheduler.AddSchedule(single1MinTo2Min);

            var secondIdenticalSchedule = single1MinTo2Min.DeepClone();
            secondIdenticalSchedule.Id = single1MinTo2Min.IdValue + 1000;
            secondIdenticalSchedule.StartTime = new Time(1, 0, 30);

            mockBlastOffStopWatch.Expect(
                sw => sw.CountDown(MILLISECONDS_IN_MIN/2, new DateTime(1999, 12, 31, 23, 00, 30)));
            scheduler.AddSchedule(secondIdenticalSchedule);

            mockBlastOffStopWatch.VerifyAllExpectations();
        }

        [Test]
        public void ShouldAddTwoOfTheSameSchedulesAndNotResetTimer()
        {
            mockBlastOffStopWatch.Stub(sw => sw.Stop());

            mockBlastOffStopWatch.Expect(sw => sw.CountDown(MILLISECONDS_IN_MIN, new DateTime(1999, 12, 31, 23, 1, 0)));
            scheduler.AddSchedule(single1MinTo2Min);

            var secondIdenticalSchedule = single1MinTo2Min.DeepClone();
            secondIdenticalSchedule.Id = single1MinTo2Min.IdValue + 1000;

            scheduler.AddSchedule(secondIdenticalSchedule);

            mockBlastOffStopWatch.VerifyAllExpectations();
        }

        [Test]
        public void ShouldCountDown1MinWithOneSingleScheduleSetTo1MinFromNowAndNeverFireAgain()
        {
            mockBlastOffStopWatch.Expect(sw => sw.Stop()).Repeat.AtLeastOnce();

            mockBlastOffStopWatch.Expect(sw => sw.CountDown(MILLISECONDS_IN_MIN, new DateTime(1999, 12, 31, 23, 1, 0)));
            scheduler.AddSchedule(single1MinTo2Min);

            var schedules = new List<ISchedule> {single1MinTo2Min};
            mockBatchHandler.Expect(m => m.OnBatchTrigger(single1MinTo2Min.BatchingKey, schedules));

            // Move the clock up one minute
            Clock.Now = new DateTime(1999, 12, 31, 23, 1, 0);

            var intendedExecutionTime = single1MinTo2Min.StartDateTime;
            scheduler.BlastOffHandler(intendedExecutionTime);

            Assert.IsTrue(scheduler.IsEmpty);

            mockBlastOffStopWatch.VerifyAllExpectations();
            mockBatchHandler.VerifyAllExpectations();
        }

        [Test]
        public void ShouldFireDifferentRepeatingSchedulesCorrectly()
        {
            Clock.Now = new DateTime(2013, 01, 01, 00, 00, 00);

            ISchedule scheduleA = new RecurringMinuteSchedule(new Date(2013, 01, 01), new Date(2013, 12, 31),
                Time.START_OF_DAY, Time.END_OF_DAY, 5, SiteFixture.Oilsands());
            scheduleA.Id = 100;
            ISchedule scheduleB = new RecurringMinuteSchedule(new Date(2013, 01, 01), new Date(2013, 12, 31),
                Time.START_OF_DAY, Time.END_OF_DAY, 2, SiteFixture.Oilsands());
            scheduleB.Id = 200;

            mockBlastOffStopWatch.Stub(sw => sw.Stop());

            mockBlastOffStopWatch.Expect(sw => sw.CountDown(zero, new DateTime(2013, 01, 01, 00, 0, 0))).Repeat.Twice();
            scheduler.AddSchedule(scheduleA);

            scheduler.AddSchedule(scheduleB);

            mockBatchHandler.Expect(m => m.OnBatchTrigger(scheduleA.BatchingKey, new List<ISchedule> {scheduleA}))
                .Repeat.Times(2);
            mockBatchHandler.Expect(m => m.OnBatchTrigger(scheduleB.BatchingKey, new List<ISchedule> {scheduleB}))
                .Repeat.Times(3);

            scheduler.BlastOffHandler(Clock.Now);

            mockBlastOffStopWatch.Expect(
                sw => sw.CountDown(2*MILLISECONDS_IN_MIN, new DateTime(2013, 01, 01, 00, 2, 00)));
            scheduler.BlastOffHandler(Clock.Now);

            Clock.Now = new DateTime(2013, 01, 01, 00, 02, 00);

            mockBlastOffStopWatch.Expect(
                sw => sw.CountDown(2*MILLISECONDS_IN_MIN, new DateTime(2013, 01, 01, 00, 4, 00)));
            scheduler.BlastOffHandler(Clock.Now);

            Clock.Now = new DateTime(2013, 01, 01, 00, 4, 00);

            mockBlastOffStopWatch.Expect(sw => sw.CountDown(MILLISECONDS_IN_MIN, new DateTime(2013, 01, 01, 00, 5, 00)));
            scheduler.BlastOffHandler(Clock.Now);

            Clock.Now = new DateTime(2013, 01, 01, 00, 5, 00);

            mockBlastOffStopWatch.Expect(sw => sw.CountDown(MILLISECONDS_IN_MIN, new DateTime(2013, 01, 01, 00, 6, 00)));
            scheduler.BlastOffHandler(Clock.Now);

            mockBatchHandler.VerifyAllExpectations();
            mockBlastOffStopWatch.VerifyAllExpectations();
        }

        [Test]
        public void ShouldNotSendFutureScheduleToTargetSchedulerUponTrigger()
        {
            Clock.Now = new DateTime(2013, 01, 05, 00, 00, 00);

            ISchedule scheduleA = new RecurringMinuteSchedule(new Date(2013, 01, 01), new Date(2013, 12, 31),
                Time.START_OF_DAY, Time.END_OF_DAY, 2, SiteFixture.Oilsands());
            scheduleA.Id = 100;
            ISchedule scheduleB = new RecurringMinuteSchedule(new Date(2013, 01, 03), new Date(2013, 12, 31),
                Time.START_OF_DAY, Time.END_OF_DAY, 2, SiteFixture.Oilsands());
            scheduleB.Id = 200;

            ISchedule futureSchedule = new RecurringMinuteSchedule(new Date(2013, 01, 06), new Date(2013, 12, 31),
                Time.START_OF_DAY, Time.END_OF_DAY, 2, SiteFixture.Oilsands());
            futureSchedule.Id = 300;

            mockBlastOffStopWatch.Stub(sw => sw.Stop());

            mockBlastOffStopWatch.Expect(sw => sw.CountDown(zero, new DateTime(2013, 01, 05, 00, 0, 0)));
            scheduler.AddSchedule(scheduleA);
            scheduler.AddSchedule(futureSchedule);
            scheduler.AddSchedule(scheduleB);

            mockBatchHandler.Expect(
                m => m.OnBatchTrigger(scheduleA.BatchingKey, new List<ISchedule> {scheduleA, scheduleB}));
            mockBlastOffStopWatch.Expect(sw => sw.CountDown(2*MILLISECONDS_IN_MIN, new DateTime(2013, 01, 05, 0, 2, 0)));
            scheduler.BlastOffHandler(Clock.Now);

            Clock.Now = new DateTime(2013, 01, 06, 0, 0, 0);
            mockBatchHandler.Expect(m => m.OnBatchTrigger(null, null))
                .Constraints(Is.Equal(scheduleA.BatchingKey),
                    ListConstraint.ContainsAll(new List<ISchedule> {scheduleA, scheduleB, futureSchedule}));
            mockBlastOffStopWatch.Expect(sw => sw.CountDown(2*MILLISECONDS_IN_MIN, new DateTime(2013, 01, 06, 0, 2, 0)));
            scheduler.BlastOffHandler(Clock.Now);

            mockBatchHandler.VerifyAllExpectations();
            mockBlastOffStopWatch.VerifyAllExpectations();
        }

        [Test]
        public void ShouldNotSetTimerIfHoldingForInitialLoad()
        {
            scheduler.StartInitialLoad();
            mockBlastOffStopWatch.Stub(sw => sw.Stop());

            mockBlastOffStopWatch.Expect(sw => sw.CountDown(MILLISECONDS_IN_MIN, new DateTime(1999, 12, 31, 23, 1, 0)))
                .Repeat.Never();
            scheduler.AddSchedule(single1MinTo2Min);

            mockBlastOffStopWatch.VerifyAllExpectations();
        }

        [Test]
        public void ShouldRemoveFirstBatchWhenScheduleThatIsRemovedIsOnlyOneInTheBatch()
        {
            mockBlastOffStopWatch.Stub(sw => sw.Stop());
            mockBlastOffStopWatch.Expect(sw => sw.CountDown(MILLISECONDS_IN_MIN, new DateTime(1999, 12, 31, 23, 1, 0)));
            scheduler.AddSchedule(single1MinTo2Min);

            var secondScheduleAMinuteLater = single1MinTo2Min.DeepClone();
            secondScheduleAMinuteLater.Id = single1MinTo2Min.IdValue + 1000;
            secondScheduleAMinuteLater.StartTime = new Time(1, 2);

            scheduler.AddSchedule(secondScheduleAMinuteLater);

            mockBlastOffStopWatch.Expect(sw => sw.CountDown(2*MILLISECONDS_IN_MIN, new DateTime(1999, 12, 31, 23, 2, 0)));
            scheduler.RemoveSchedule(single1MinTo2Min);

            mockBlastOffStopWatch.VerifyAllExpectations();
        }

        [Test]
        public void ShouldResetStopWatchAfterRemovingTheTopSchedule()
        {
            mockBlastOffStopWatch.Stub(sw => sw.Stop());

            scheduler.StartInitialLoad();
            scheduler.AddSchedule(single1MinTo2Min);

            var secondScheduleAMinuteBefore = single1MinTo2Min.DeepClone();
            secondScheduleAMinuteBefore.Id = single1MinTo2Min.IdValue + 1000;
            secondScheduleAMinuteBefore.StartTime = new Time(1, 0, 0);

            scheduler.AddSchedule(secondScheduleAMinuteBefore);

            mockBlastOffStopWatch.Expect(sw => sw.CountDown(zero, new DateTime(1999, 12, 31, 23, 0, 00)));
            scheduler.InitialLoadComplete();

            mockBlastOffStopWatch.Expect(sw => sw.CountDown(MILLISECONDS_IN_MIN, new DateTime(1999, 12, 31, 23, 1, 0)));
            scheduler.RemoveSchedule(secondScheduleAMinuteBefore);

            mockBlastOffStopWatch.VerifyAllExpectations();
        }

        [Test]
        public void ShouldSetTimerOnlyOnceAfterInitialLoadIsComplete()
        {
            scheduler.StartInitialLoad();
            mockBlastOffStopWatch.Stub(sw => sw.Stop());

            scheduler.AddSchedule(single1MinTo2Min);

            var secondIdenticalSchedule = single1MinTo2Min.DeepClone();
            secondIdenticalSchedule.Id = single1MinTo2Min.IdValue + 1000;
            secondIdenticalSchedule.StartTime = new Time(1, 0, 30);

            mockBlastOffStopWatch.Expect(
                sw => sw.CountDown(MILLISECONDS_IN_MIN/2, new DateTime(1999, 12, 31, 23, 00, 30)));
            scheduler.AddSchedule(secondIdenticalSchedule);

            scheduler.InitialLoadComplete();
            mockBlastOffStopWatch.VerifyAllExpectations();
        }
    }
}