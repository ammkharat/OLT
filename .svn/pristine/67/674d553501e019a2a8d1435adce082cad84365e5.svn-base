using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Restriction;
using Com.Suncor.Olt.Common.Domain.Schedule;
using Com.Suncor.Olt.Common.Exceptions;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Remote;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using log4net;
using NMock2;
using NUnit.Framework;
using Is = NMock2.Is;

namespace Com.Suncor.Olt.Remote.Schedulers.Common.Schedulers
{
    [TestFixture]
    public class RestrictionSchedulingServiceTest
    {
        private const string DEFINITION_CREATED_EVENT = "ServerRestrictionDefinitionCreated";
        private const string DEFINITION_REMOVED_EVENT = "ServerRestrictionDefinitionRemoved";
        private IStopWatch blastoffStopWatch;

        private IDeviationAlertService deviationAlertService;
        private ILog mockLog;
        private Mockery mocks;
        private INonBatchingScheduler nonBatchingScheduler;
        private IRemoteEventRepeater remoteEventRepeater;

        private IStopWatch restartStopWatch;
        private IRestrictionDefinitionService restrictionDefinitionService;

        private RestrictionSchedulingService schedulingService;
        private ITimeService timeService;

        [SetUp]
        public void SetUp()
        {
            mocks = new Mockery();

            mockLog = mocks.NewMock<ILog>();
            timeService = mocks.NewMock<ITimeService>();
            restrictionDefinitionService = mocks.NewMock<IRestrictionDefinitionService>();
            deviationAlertService = mocks.NewMock<IDeviationAlertService>();
            remoteEventRepeater = mocks.NewMock<IRemoteEventRepeater>();

            blastoffStopWatch = mocks.NewMock<IStopWatch>();
            restartStopWatch = mocks.NewMock<IStopWatch>();

            nonBatchingScheduler = new NonBatchingScheduler(blastoffStopWatch, restartStopWatch,
                TimeZoneFixture.GetMountainTimeZone());

            // don't care about any of these things
            OltStub.On(mockLog);
            Stub.On(remoteEventRepeater).EventAdd(DEFINITION_CREATED_EVENT, Is.Anything);
            Stub.On(remoteEventRepeater).EventAdd(DEFINITION_REMOVED_EVENT, Is.Anything);
            Stub.On(timeService).Method("GetTime").Will(Return.Value(Clock.Now));
            Stub.On(blastoffStopWatch).Method("Stop");
            Stub.On(blastoffStopWatch).Method("CountDown");
            Stub.On(restartStopWatch).Method("Stop");
            Stub.On(restartStopWatch).Method("CountDown");

            schedulingService = new RestrictionSchedulingService(
                mockLog,
                timeService,
                restrictionDefinitionService,
                deviationAlertService,
                remoteEventRepeater,
                nonBatchingScheduler);

            Clock.Freeze();
        }

        [TearDown]
        public void TearDown()
        {
            Clock.UnFreeze();
        }

        [Test]
        public void ShouldCatchupOnMissedAlertsOnStartup()
        {
            var definitions = new List<RestrictionDefinition>
            {
                RestrictionDefinitionFixture.CreateDefinition(
                    RestrictionDefinitionStatus.Valid,
                    SiteFixture.Denver())
            };

            Clock.Now = new DateTime(2010, 3, 20, 14, 30, 0);
            definitions[0].CreatedDate = new DateTime(2010, 3, 20, 13, 30, 0);
            definitions[0].LastInvokedDateTime = null;

            var schedulingList = new SchedulingList<RestrictionDefinition, OLTException>(
                definitions, new List<OLTException>());
            Stub.On(restrictionDefinitionService)
                .Method("QueryAllAvailableForScheduling")
                .Will(Return.Value(schedulingList));

            schedulingService.LoadScheduler();
            Assert.AreEqual(new DateTime(2010, 3, 20, 14, 0, 0), definitions[0].LastInvokedDateTime);
        }

        [Test]
        public void ShouldCreateSchedulesPerSiteAndIgnoreInvalidDefinitions()
        {
            var definitions = new List<RestrictionDefinition>
            {
                RestrictionDefinitionFixture.CreateDefinition(
                    RestrictionDefinitionStatus.Valid,
                    SiteFixture.Denver()),
                RestrictionDefinitionFixture.CreateDefinition(
                    RestrictionDefinitionStatus.Valid,
                    SiteFixture.Denver()),
                RestrictionDefinitionFixture.CreateDefinition(
                    RestrictionDefinitionStatus.InvalidTag,
                    SiteFixture.Denver()),
                RestrictionDefinitionFixture.CreateDefinition(
                    RestrictionDefinitionStatus.InvalidTag,
                    SiteFixture.Denver()),
                RestrictionDefinitionFixture.CreateDefinition(
                    RestrictionDefinitionStatus.Valid,
                    SiteFixture.Sarnia()),
                RestrictionDefinitionFixture.CreateDefinition(
                    RestrictionDefinitionStatus.Valid,
                    SiteFixture.Sarnia()),
                RestrictionDefinitionFixture.CreateDefinition(
                    RestrictionDefinitionStatus.InvalidTag,
                    SiteFixture.Sarnia()),
                RestrictionDefinitionFixture.CreateDefinition(
                    RestrictionDefinitionStatus.InvalidTag,
                    SiteFixture.Sarnia())
            };

            var schedulingList = new SchedulingList<RestrictionDefinition, OLTException>(
                definitions, new List<OLTException>());
            Stub.On(restrictionDefinitionService)
                .Method("QueryAllAvailableForScheduling")
                .Will(Return.Value(schedulingList));

            schedulingService.LoadScheduler();

            Assert.AreEqual(2, nonBatchingScheduler.Schedules.Count);
            Assert.IsTrue(nonBatchingScheduler.Schedules.Exists(obj => obj.Schedule.Site.Id == SiteFixture.Sarnia().Id));
            Assert.IsTrue(nonBatchingScheduler.Schedules.Exists(obj => obj.Schedule.Site.Id == SiteFixture.Denver().Id));
        }

        [Test]
        public void ShouldEvaluateAndUpdateAllDefinitionsEvenIfOneFailsWithAnException()
        {
            var invocationDateTime = new DateTime(2010, 1, 2, 3, 4, 5);
            ISchedule schedule = new RoundTheClockSchedule(
                1, new Date(Clock.Now), null, Time.START_OF_DAY, Time.END_OF_DAY, int.MaxValue, invocationDateTime,
                SiteFixture.Denver());

            var definition1 = RestrictionDefinitionFixture.CreateDefinition(
                RestrictionDefinitionStatus.Valid, SiteFixture.Denver());
            var definition2 = RestrictionDefinitionFixture.CreateDefinition(
                RestrictionDefinitionStatus.Valid, SiteFixture.Denver());

            var definitions = new List<RestrictionDefinition> {definition1, definition2};

            var schedulingList = new SchedulingList<RestrictionDefinition, OLTException>(
                definitions, new List<OLTException>());
            Stub.On(restrictionDefinitionService).Method("QueryAllAvailableForScheduling")
                .Will(Return.Value(schedulingList));

            Expect.Once.On(deviationAlertService).Method("EvaluateDefinition")
                .With(definition1, invocationDateTime)
                .Will(Throw.Exception(new Exception()));
            Expect.Once.On(deviationAlertService).Method("EvaluateDefinition")
                .With(definition2, invocationDateTime)
                .Will(Return.Value(new DateTime()));
            Expect.Once.On(restrictionDefinitionService).Method("UpdateLastInvokedDateTime").With(definition1);
            Expect.Once.On(restrictionDefinitionService).Method("UpdateLastInvokedDateTime").With(definition2);

            schedulingService.OnScheduleTrigger(schedule, null);

            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldEvaluateDefinitionsAtScheduledSite()
        {
            var invocationDateTime = new DateTime(2010, 1, 2, 3, 4, 5);
            ISchedule schedule = new RoundTheClockSchedule(
                1, new Date(Clock.Now), null, Time.START_OF_DAY, Time.END_OF_DAY, int.MaxValue, invocationDateTime,
                SiteFixture.Denver());

            var definition1 = RestrictionDefinitionFixture.CreateDefinition(
                RestrictionDefinitionStatus.Valid, SiteFixture.Sarnia());
            var definition2 = RestrictionDefinitionFixture.CreateDefinition(
                RestrictionDefinitionStatus.Valid, SiteFixture.Denver());

            var definitions = new List<RestrictionDefinition> {definition1, definition2};

            var schedulingList = new SchedulingList<RestrictionDefinition, OLTException>(
                definitions, new List<OLTException>());
            Stub.On(restrictionDefinitionService)
                .Method("QueryAllAvailableForScheduling")
                .Will(Return.Value(schedulingList));

            Expect.Once.On(deviationAlertService).Method("EvaluateDefinition")
                .With(definition2, invocationDateTime)
                .Will(Return.Value(new DateTime()));
            Expect.Once.On(restrictionDefinitionService).Method("UpdateLastInvokedDateTime")
                .With(definition2);

            schedulingService.OnScheduleTrigger(schedule, null);

            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldNotUpdateLastInvokedDateTimeIfEvaluateReturnsNull()
        {
            var invocationDateTime = new DateTime(2010, 1, 2, 3, 4, 5);
            ISchedule schedule = new RoundTheClockSchedule(
                1, new Date(Clock.Now), null, Time.START_OF_DAY, Time.END_OF_DAY, int.MaxValue, invocationDateTime,
                SiteFixture.Denver());

            var definition = RestrictionDefinitionFixture.CreateDefinition(
                RestrictionDefinitionStatus.Valid, schedule.Site);
            definition.LastInvokedDateTime = new DateTime(1910, 1, 1, 1, 1, 1);

            var definitions = new List<RestrictionDefinition> {definition};

            var schedulingList = new SchedulingList<RestrictionDefinition, OLTException>(
                definitions, new List<OLTException>());
            Stub.On(restrictionDefinitionService)
                .Method("QueryAllAvailableForScheduling")
                .Will(Return.Value(schedulingList));

            Stub.On(deviationAlertService).Method("EvaluateDefinition")
                .With(definition, invocationDateTime);
            Stub.On(restrictionDefinitionService).Method("UpdateLastInvokedDateTime")
                .With(definition);

            schedulingService.OnScheduleTrigger(schedule, null);

            Assert.AreEqual(new DateTime(1910, 1, 1, 1, 1, 1).TruncateToHour(), definition.LastInvokedDateTime);
        }

        [Test]
        public void ShouldRemoveSchedule()
        {
            nonBatchingScheduler.AddSchedule(new RoundTheClockSchedule(
                new Date(Clock.Now), null, Time.START_OF_DAY, Time.END_OF_DAY, int.MaxValue, SiteFixture.Denver())
            {
                Id = 1
            });
            nonBatchingScheduler.AddSchedule(new RoundTheClockSchedule(
                new Date(Clock.Now), null, Time.START_OF_DAY, Time.END_OF_DAY, int.MaxValue, SiteFixture.Sarnia())
            {
                Id = 2
            });
            Assert.AreEqual(2, nonBatchingScheduler.Schedules.Count);

            var definitions = new List<RestrictionDefinition>
            {
                RestrictionDefinitionFixture.CreateDefinition(
                    RestrictionDefinitionStatus.Valid,
                    SiteFixture.Denver())
            };

            var schedulingList = new SchedulingList<RestrictionDefinition, OLTException>(
                definitions, new List<OLTException>());
            Stub.On(restrictionDefinitionService)
                .Method("QueryAllAvailableForScheduling")
                .Will(Return.Value(schedulingList));

            schedulingService.LoadScheduler();
            Assert.AreEqual(1, nonBatchingScheduler.Schedules.Count);
            Assert.IsTrue(nonBatchingScheduler.Schedules.Exists(obj => obj.Schedule.Site.Id == SiteFixture.Denver().Id));
        }

        [Test]
        public void ShouldUpdateLastInvokedDateTimeFromEvaluate()
        {
            var invocationDateTime = new DateTime(2010, 1, 2, 3, 4, 5);
            ISchedule schedule = new RoundTheClockSchedule(
                1, new Date(Clock.Now), null, Time.START_OF_DAY, Time.END_OF_DAY, int.MaxValue, invocationDateTime,
                SiteFixture.Denver());

            var definition = RestrictionDefinitionFixture.CreateDefinition(
                RestrictionDefinitionStatus.Valid, schedule.Site);
            definition.LastInvokedDateTime = new DateTime(1910, 1, 1, 1, 1, 1);

            var definitions = new List<RestrictionDefinition> {definition};

            var schedulingList = new SchedulingList<RestrictionDefinition, OLTException>(
                definitions, new List<OLTException>());
            Stub.On(restrictionDefinitionService)
                .Method("QueryAllAvailableForScheduling")
                .Will(Return.Value(schedulingList));

            var lastSuccessfulAlert = new DateTime(1950, 5, 6, 7, 8, 9);
            Stub.On(deviationAlertService).Method("EvaluateDefinition")
                .With(definition, invocationDateTime)
                .Will(Return.Value(lastSuccessfulAlert));
            Stub.On(restrictionDefinitionService).Method("UpdateLastInvokedDateTime")
                .With(definition);

            schedulingService.OnScheduleTrigger(schedule, null);

            Assert.AreEqual(lastSuccessfulAlert.TruncateToHour(), definition.LastInvokedDateTime);
        }

        [Test]
        public void ShouldUpdateLastInvokedDateTimeIfEvaluateThrowsAnException()
        {
            var invocationDateTime = new DateTime(2010, 1, 2, 3, 4, 5);
            ISchedule schedule = new RoundTheClockSchedule(
                1, new Date(Clock.Now), null, Time.START_OF_DAY, Time.END_OF_DAY, int.MaxValue, invocationDateTime,
                SiteFixture.Denver());

            var definition = RestrictionDefinitionFixture.CreateDefinition(
                RestrictionDefinitionStatus.Valid, schedule.Site);
            definition.LastInvokedDateTime = new DateTime(1910, 1, 1, 1, 1, 1);

            var definitions = new List<RestrictionDefinition> {definition};

            var schedulingList = new SchedulingList<RestrictionDefinition, OLTException>(
                definitions, new List<OLTException>());
            Stub.On(restrictionDefinitionService)
                .Method("QueryAllAvailableForScheduling")
                .Will(Return.Value(schedulingList));

            Stub.On(deviationAlertService).Method("EvaluateDefinition")
                .With(definition, invocationDateTime)
                .Will(Throw.Exception(new Exception()));
            Stub.On(restrictionDefinitionService).Method("UpdateLastInvokedDateTime")
                .With(definition);

            schedulingService.OnScheduleTrigger(schedule, null);

            Assert.AreEqual(invocationDateTime.TruncateToHour(), definition.LastInvokedDateTime);
        }
    }
}