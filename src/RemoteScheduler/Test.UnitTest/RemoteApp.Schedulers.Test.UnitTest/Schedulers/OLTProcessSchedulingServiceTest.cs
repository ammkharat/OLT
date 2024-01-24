using System.Collections.Generic;
using Com.Suncor.Olt.Common;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Schedule;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Remote;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Remote.Schedulers.Common.Schedulers.Commands;
using NMock2;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.Schedulers.Common.Schedulers
{
    [TestFixture]
    public class OltProcessSchedulingServiceTest
    {
        private Mockery mock;
        private IScheduledJob mockFirstJob;
        private INonBatchingScheduler mockNonBatchingScheduler;
        private IScheduledJobRunner mockScheduledJobRunner;
        private IScheduledJob mockSecoundJob;
        private OltProcessSchedulingService oltProcessSchedulingService;
        private IRemoteEventRepeater remoteEventRepeater;


        [SetUp]
        public void SetUp()
        {
            mock = new Mockery();
            mockNonBatchingScheduler = mock.NewMock<INonBatchingScheduler>();
            mockFirstJob = mock.NewMock<IScheduledJob>();
            mockSecoundJob = mock.NewMock<IScheduledJob>();
            remoteEventRepeater = new TestRemoteEventRepeater();
            mockScheduledJobRunner = mock.NewMock<IScheduledJobRunner>();

            Stub.On(mockNonBatchingScheduler)
                .SetProperty("ScheduleHandler")
                .To(new TypeMatcher(typeof (OltProcessSchedulingService)));
        }

        [TearDown]
        public void TearDown()
        {
            Clock.UnFreeze();
        }

        [Test]
        public void LoadSchedulerShouldLoadOLTProcessItems()
        {
            var scheduleMock = mock.NewMock<ISchedule>();
            Stub.On(scheduleMock);

            Stub.On(mockNonBatchingScheduler).Method("StartInitialLoad");
            Stub.On(mockFirstJob).GetProperty("Schedule").Will(Return.Value(scheduleMock));
            Expect.Once.On(mockNonBatchingScheduler).Method("AddSchedule").With(scheduleMock);
            Stub.On(mockNonBatchingScheduler).Method("InitialLoadComplete");

            oltProcessSchedulingService = new OltProcessSchedulingService(mockNonBatchingScheduler,
                new List<IScheduledJob> {mockFirstJob}, remoteEventRepeater, mockScheduledJobRunner);

            oltProcessSchedulingService.LoadScheduler();
            mock.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldNotTriggerJobExecuteIfStopRequested()
        {
            oltProcessSchedulingService = new OltProcessSchedulingService(mockNonBatchingScheduler,
                new List<IScheduledJob> {mockFirstJob}, remoteEventRepeater, mockScheduledJobRunner);

            Expect.Once.On(mockNonBatchingScheduler).Method("StopScheduler");
            oltProcessSchedulingService.StopService();

            const long scheduleId = 10;
            ISchedule dailySchedule = new RecurringDailySchedule(scheduleId, Clock.DateNow, null, new Time(Clock.Now),
                new Time(Clock.Now), 1, null, SiteFixture.Sarnia());
            Stub.On(mockFirstJob).GetProperty("Schedule").Will(Return.Value(dailySchedule));

            Expect.Never.On(mockScheduledJobRunner).Method("Run");

            oltProcessSchedulingService.OnScheduleTrigger(dailySchedule, null);
            mock.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldNotTriggerJobExecuteWhenNoScheduleIdMatchesJobId()
        {
            oltProcessSchedulingService = new OltProcessSchedulingService(mockNonBatchingScheduler,
                new List<IScheduledJob> {mockFirstJob}, remoteEventRepeater, mockScheduledJobRunner);

            const long scheduleForJobId = 10;
            ISchedule scheduleForJob = new RecurringDailySchedule(scheduleForJobId, Clock.DateNow, null,
                new Time(Clock.Now), new Time(Clock.Now), 1, null, SiteFixture.Sarnia());
            Stub.On(mockFirstJob).GetProperty("Schedule").Will(Return.Value(scheduleForJob));

            const long scheduleToFindJobForId = 11;
            ISchedule scheduleToFindJobFor = new RecurringDailySchedule(scheduleToFindJobForId, Clock.DateNow, null,
                new Time(Clock.Now), new Time(Clock.Now), 1, null, SiteFixture.Sarnia());

            Expect.Never.On(mockScheduledJobRunner).Method("Run");

            oltProcessSchedulingService.OnScheduleTrigger(scheduleToFindJobFor, null);

            mock.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldTriggerJobExecuteWhenScheduleIdMatchesIdOfJobsSchedule()
        {
            oltProcessSchedulingService = new OltProcessSchedulingService(mockNonBatchingScheduler,
                new List<IScheduledJob> {mockFirstJob, mockSecoundJob}, remoteEventRepeater, mockScheduledJobRunner);

            const long scheduleId = 10;
            ISchedule scheduleForJob = new RecurringDailySchedule(scheduleId, Clock.DateNow, null, new Time(Clock.Now),
                new Time(Clock.Now), 1, null, SiteFixture.Sarnia());
            Stub.On(mockFirstJob).GetProperty("Schedule").Will(Return.Value(scheduleForJob));
            Stub.On(mockFirstJob).GetProperty("Name").Will(Return.Value("Unit Test Job"));

            ISchedule scheduleToFindJobFor = new RecurringDailySchedule(scheduleId, Clock.DateNow, null,
                new Time(Clock.Now), new Time(Clock.Now), 1, null, SiteFixture.Sarnia());

            Expect.Once.On(mockScheduledJobRunner).Method("Run").With(mockFirstJob);

            oltProcessSchedulingService.OnScheduleTrigger(scheduleToFindJobFor, null);

            mock.VerifyAllExpectationsHaveBeenMet();
        }
    }
}