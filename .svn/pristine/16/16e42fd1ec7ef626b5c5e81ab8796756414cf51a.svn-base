using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using NMock2;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.Schedulers.Common.Schedulers
{
    [TestFixture]
    public class ShiftSchedulingServiceTest
    {
        private IActionItemService actionItemService;

        private IStopWatch blastoffStopWatch;
        private Mockery mocks;
        private INonBatchingScheduler nonBatchingScheduler;
        private IStopWatch refreshStopWatch;

        private ShiftSchedulingService schedulingService;
        private IShiftPatternService shiftPatternService;
        private ITimeService timeService;

        [SetUp]
        public void SetUp()
        {
            mocks = new Mockery();

            actionItemService = mocks.NewMock<IActionItemService>();
            shiftPatternService = mocks.NewMock<IShiftPatternService>();
            timeService = mocks.NewMock<ITimeService>();

            blastoffStopWatch = mocks.NewMock<IStopWatch>();
            refreshStopWatch = mocks.NewMock<IStopWatch>();

            nonBatchingScheduler = new NonBatchingScheduler(blastoffStopWatch, refreshStopWatch,
                TimeZoneFixture.GetMountainTimeZone());

            // don't care about any of these things
            Stub.On(timeService).Method("GetTime").Will(Return.Value(Clock.Now));
            Stub.On(blastoffStopWatch).Method("Stop");
            Stub.On(blastoffStopWatch).Method("CountDown");
            Stub.On(refreshStopWatch).Method("Stop");
            Stub.On(refreshStopWatch).Method("CountDown");

            schedulingService = new ShiftSchedulingService(
                nonBatchingScheduler,
                actionItemService,
                shiftPatternService,
                timeService);

            Clock.Freeze();
        }

        [TearDown]
        public void TearDown()
        {
            Clock.UnFreeze();
        }

        [Test]
        public void ShouldCreateSchedulesPerShift()
        {
            var shift1 = new ShiftPattern(1, "a", new Time(1, 10, 11), new Time(2, 20, 22), new DateTime(),
                SiteFixture.Sarnia(), TimeSpan.Zero, TimeSpan.Zero);
            var shift2 = new ShiftPattern(2, "b", new Time(3, 30, 33), new Time(4, 40, 44), new DateTime(),
                SiteFixture.Denver(), TimeSpan.Zero, TimeSpan.Zero);

            var shifts = new List<ShiftPattern> {shift1, shift2};

            Stub.On(timeService).Method("GetDate").Will(Return.Value(new Date(1999, 1, 2)));
            Stub.On(shiftPatternService).Method("QueryAll").Will(Return.Value(shifts));

            schedulingService.LoadScheduler();

            Assert.AreEqual(2, nonBatchingScheduler.Schedules.Count);
            Assert.IsTrue(
                nonBatchingScheduler.Schedules.Exists(
                    obj => obj.Schedule.Site.Id == shift1.Site.Id && obj.Schedule.StartTime == shift1.EndTime));
            Assert.IsTrue(
                nonBatchingScheduler.Schedules.Exists(
                    obj => obj.Schedule.Site.Id == shift2.Site.Id && obj.Schedule.StartTime == shift2.EndTime));
        }
    }
}