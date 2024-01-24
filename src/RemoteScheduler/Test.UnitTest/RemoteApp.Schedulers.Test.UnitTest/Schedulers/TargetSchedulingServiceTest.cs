using System.Collections.Generic;
using Com.Suncor.Olt.Common;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Target;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Exceptions;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Remote;
using Com.Suncor.Olt.Common.Services;
using log4net;
using NMock2;
using NUnit.Framework;
using Is = NMock2.Is;

namespace Com.Suncor.Olt.Remote.Schedulers.Common.Schedulers
{
    [TestFixture]
    public class TargetSchedulingServiceTest
    {
        private const string QUERY_BY_ID = "QueryByScheduleId";
        private const string EVALUATE_TARGET = "EvaluateTarget";
        private const string TARGET_DEFINITION_CREATED_EVENT = "ServerTargetDefinitionCreated";
        private const string TARGET_DEFINITION_REMOVED_EVENT = "ServerTargetDefinitionRemoved";
        private const string TARGET_DEFINITION_UPDATED_EVENT = "ServerTargetDefinitionUpdated";

        private readonly List<long> siteIds = new List<long> {1, 2, 3, 5, 6, 8, 9};
        private IBatchingScheduler batchingScheduler;
        private ILog mockLog;
        private IFunctionalLocationOperationalModeService mockOperationalModeService;
        private IRemoteEventRepeater mockRemoteEventRepeater;
        private Mockery mocks;
        private INonBatchingScheduler nonBatchingScheduler;
        private IScheduleService scheduleServiceMock;
        private ITargetDefinitionService targetDefinitionService;
        private TargetSchedulingService targetSchedulingService;
        private TargetSchedulingService targetSchedulingServiceWithBatching;
        private ITargetAlertService targetService;

        [SetUp]
        public void SetUp()
        {
            mocks = new Mockery();

            targetService = mocks.NewMock<ITargetAlertService>();
            targetDefinitionService = mocks.NewMock<ITargetDefinitionService>();
            mockRemoteEventRepeater = mocks.NewMock<IRemoteEventRepeater>();
            scheduleServiceMock = mocks.NewMock<IScheduleService>();
            mockLog = mocks.NewMock<ILog>();
            mockOperationalModeService = mocks.NewMock<IFunctionalLocationOperationalModeService>();

            nonBatchingScheduler = mocks.NewMock<INonBatchingScheduler>();
            batchingScheduler = mocks.NewMock<IBatchingScheduler>();

            Stub.On(mockRemoteEventRepeater).EventAdd(TARGET_DEFINITION_CREATED_EVENT, Is.Anything);
            Stub.On(mockRemoteEventRepeater).EventAdd(TARGET_DEFINITION_REMOVED_EVENT, Is.Anything);
            Stub.On(mockRemoteEventRepeater).EventAdd(TARGET_DEFINITION_UPDATED_EVENT, Is.Anything);

            Stub.On(batchingScheduler).SetProperty("BatchHandler").To(new TypeMatcher(typeof (TargetSchedulingService)));
            Stub.On(nonBatchingScheduler)
                .SetProperty("ScheduleHandler")
                .To(new TypeMatcher(typeof (TargetSchedulingService)));

            targetSchedulingServiceWithBatching = new TargetSchedulingService(targetService, batchingScheduler,
                targetDefinitionService,
                mockRemoteEventRepeater, scheduleServiceMock, mockLog,
                mockOperationalModeService, siteIds);

            targetSchedulingService = new TargetSchedulingService(targetService, nonBatchingScheduler,
                targetDefinitionService,
                mockRemoteEventRepeater, scheduleServiceMock, mockLog,
                mockOperationalModeService, siteIds);

            //Since If the schedulers crashs we capture the exception and do not throw it again (but instead
            //we log it) this expectation is used to confirm no errors are being thrown (and therefore logged)
            Expect.Never.On(mockLog).Method("Error").WithAnyArguments();

            // don't care about logging calls.
            OltStub.On(mockLog);
        }

        [Test]
        public void CreationOfANewTargetSchedulingServiceShouldCorrectlyHookUpTargetDefinitionCreatedEventHandler()
        {
            var tempTargetService = mocks.NewMock<ITargetAlertService>();
            var tempTargetDefinitionService = mocks.NewMock<ITargetDefinitionService>();
            var tempScheduler = mocks.NewMock<IBatchingScheduler>();
            var tempRemoteEventRepeater = mocks.NewMock<IRemoteEventRepeater>();
            var mockFLOCService =
                mocks.NewMock<IFunctionalLocationOperationalModeService>();

            Stub.On(tempRemoteEventRepeater).EventAdd(TARGET_DEFINITION_CREATED_EVENT, Is.Anything);
            Stub.On(tempRemoteEventRepeater).EventAdd(TARGET_DEFINITION_REMOVED_EVENT, Is.Anything);
            Stub.On(tempRemoteEventRepeater).EventAdd(TARGET_DEFINITION_UPDATED_EVENT, Is.Anything);
            Stub.On(tempScheduler).SetProperty("BatchHandler").To(new TypeMatcher(typeof (TargetSchedulingService)));

            targetSchedulingService =
                new TargetSchedulingService(tempTargetService, tempScheduler, tempTargetDefinitionService,
                    tempRemoteEventRepeater, scheduleServiceMock, mockLog,
                    mockFLOCService, siteIds);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void OnOnScheduleTriggerShouldNotDoAnythingIfStopRequested()
        {
            var targetDefinition =
                TargetDefinitionFixture.CreateATargetWithRecurringDailyScheduleAndActiveTargetFixture();
            Expect.Once.On(nonBatchingScheduler).Method("StopScheduler");
            targetSchedulingService.StopService();

            targetSchedulingService.OnScheduleTrigger(targetDefinition.Schedule, null);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldAddAndRemoveTargetDefinitionSchedules()
        {
            var targetDefinition =
                TargetDefinitionFixture.CreateATargetWithRecurringDailyScheduleAndActiveTargetFixture();
            targetDefinition.Id = 1;

            Expect.Exactly(1).On(targetDefinitionService).Method("QueryById").With(targetDefinition.Id).Will(
                Return.Value(targetDefinition));
            Expect.Once.On(nonBatchingScheduler).Method("AddSchedule").With(targetDefinition.Schedule);
            Expect.Once.On(nonBatchingScheduler).Method("RemoveSchedule").With(targetDefinition.Schedule);

            targetSchedulingService.AddTargetDefinitionSchedule(targetDefinition.Id.Value);

            targetSchedulingService.RemoveTargetDefinitionSchedule(targetDefinition);

            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldBuildAndInsertTargetDefinitionWhenScheduleIsTriggeredAndOperationalModesAreBothConstrained()
        {
            AsserTheOperationalModesAreTheSame(OperationalMode.Constrained,
                FunctionalLocationOperationalModeDTOFixture.MakeConstrainedOpModeDto());
        }

        [Test]
        public void ShouldBuildAndInsertTargetDefinitionWhenScheduleIsTriggeredAndOperationalModesAreBothNormal()
        {
            AsserTheOperationalModesAreTheSame(OperationalMode.Normal,
                FunctionalLocationOperationalModeDTOFixture.MakeNormalOpModeDto());
        }

        [Test]
        public void ShouldBuildAndInsertTargetDefinitionWhenScheduleIsTriggeredAndOperationalModesAreBothShutDown()
        {
            AsserTheOperationalModesAreTheSame(OperationalMode.ShutDown,
                FunctionalLocationOperationalModeDTOFixture.MakeShutDownOpModeDto());
        }

        [Test]
        public void
            ShouldNotEvaluateAndUpdateTargetDefinitionOperationModeIsConstrainedAndFlocOperationModeIsNormalothNotTheSame
            ()
        {
            AssertThatOperationalModeAreDifferent(OperationalMode.Constrained,
                FunctionalLocationOperationalModeDTOFixture.MakeNormalOpModeDto());
        }

        [Test]
        public void
            ShouldNotEvaluateAndUpdateTargetDefinitionWhenScheduleIsTriggeredAndOperationalModesAreBothNotTheSame()
        {
            AssertThatOperationalModeAreDifferent(OperationalMode.Normal,
                FunctionalLocationOperationalModeDTOFixture.MakeShutDownOpModeDto());
        }

        [Test]
        public void StartingScheduleringServiceShouldLoadAllTargetSchedulesAndAddThem()
        {
            var targetDefinitions = new List<TargetDefinition>
            {
                TargetDefinitionFixture.
                    CreateATargetWithRecurringDailyScheduleAndActiveTargetFixture
                    (),
                TargetDefinitionFixture.
                    CreateATargetWithRecurringHourlyScheduleOfEverySixHours
                    (),
                TargetDefinitionFixture.
                    CreateATargetWithRecurringMinuteScheduleOfEveryTenMinutes
                    ()
            };

            var result =
                new SchedulingList<TargetDefinition, OLTException>(targetDefinitions,
                    new List
                        <OLTException>());

            Expect.Once.On(targetDefinitionService).Method("QueryAllAvailableForScheduling").Will(
                Return.Value(result));

            Expect.Once.On(nonBatchingScheduler).Method("InitialLoadComplete");
            Expect.Once.On(nonBatchingScheduler).Method("StartInitialLoad");

            foreach (var targetDefinition in targetDefinitions)
            {
                if (targetDefinition.Status.Equals(TargetDefinitionStatus.Approved))
                {
                    Expect.Once.On(nonBatchingScheduler).Method("AddSchedule").With(targetDefinition.Schedule);
                }
            }
            targetSchedulingService.LoadScheduler();
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        private void AssertThatOperationalModeAreDifferent(OperationalMode targetDefinitionOpMode,
            FunctionalLocationOperationalModeDTO flocOpModeDTO)
        {
            var targetDefinition =
                TargetDefinitionFixture.CreateATargetWithRecurringDailyScheduleAndActiveTargetFixture();
            targetDefinition.OperationalMode = targetDefinitionOpMode;
            var flocOperationalMode = flocOpModeDTO;
            flocOperationalMode.Id = targetDefinition.FunctionalLocation.Id;

            Expect.Once.On(mockOperationalModeService).Method("GetByFunctionalLocationId").With(
                targetDefinition.FunctionalLocation.Id).Will(Return.Value(flocOperationalMode));
            Expect.Once.On(targetDefinitionService).Method(QUERY_BY_ID).With(targetDefinition.Schedule.Id).Will(
                Return.Value(targetDefinition));

            targetSchedulingService.OnScheduleTrigger(targetDefinition.Schedule, null);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        private void AsserTheOperationalModesAreTheSame(OperationalMode targetDefinitionOpMode,
            FunctionalLocationOperationalModeDTO flocOpModeDTO)
        {
            var targetDefinition =
                TargetDefinitionFixture.CreateATargetWithRecurringDailyScheduleAndActiveTargetFixture();
            var flocOperationalMode = flocOpModeDTO;
            flocOperationalMode.Id = targetDefinition.FunctionalLocation.Id;
            targetDefinition.OperationalMode = targetDefinitionOpMode;

            Expect.Once.On(mockOperationalModeService).Method("GetByFunctionalLocationId").With(
                targetDefinition.FunctionalLocation.Id).Will(Return.Value(flocOperationalMode));
            Expect.Once.On(targetDefinitionService).Method(QUERY_BY_ID).With(targetDefinition.Schedule.Id).Will(
                Return.Value(targetDefinition));
            Expect.Once.On(targetService).Method(EVALUATE_TARGET).With(targetDefinition);

            Expect.Once.On(scheduleServiceMock).Method("Update").With(targetDefinition.Schedule);

            targetSchedulingService.OnScheduleTrigger(targetDefinition.Schedule, null);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }
    }
}