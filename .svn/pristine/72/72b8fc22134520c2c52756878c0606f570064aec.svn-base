using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Schedule;
using Com.Suncor.Olt.Common.Domain.Target;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Remote;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using log4net;
using NUnit.Framework;
using Rhino.Mocks;

namespace Com.Suncor.Olt.Remote.Schedulers.Common.Schedulers
{
    [TestFixture]
    public class ActionItemSchedulingServiceTest
    {
        private IActionItemDefinitionService actionItemDefinitionServiceMock;
        private IActionItemService actionItemServiceMock;
        private IFunctionalLocationService functionalLocationServiceMock;
        private ILog mockLog;
        private IRemoteEventRepeater mockRemoteEventRepeater;
        private INonBatchingScheduler nonBatchingSchedulerMock;
        private IFunctionalLocationOperationalModeService operationalModeServiceMock;
        private IScheduleService scheduleServiceMock;
        private ActionItemSchedulingService schedulingService;
        private IShiftPatternService shiftPatternServiceMock;
        private ISiteConfigurationService siteConfigurationServiceMock;
        private ITargetDefinitionService targetDefinitionServiceMock;
        
        private ITimeService timeServiceMock;

        [SetUp]
        public void SetUp()
        {
            timeServiceMock = MockRepository.GenerateMock<ITimeService>();
            mockRemoteEventRepeater = MockRepository.GenerateMock<IRemoteEventRepeater>();
            actionItemDefinitionServiceMock = MockRepository.GenerateMock<IActionItemDefinitionService>();
            actionItemServiceMock = MockRepository.GenerateMock<IActionItemService>();
            shiftPatternServiceMock = MockRepository.GenerateMock<IShiftPatternService>();
            nonBatchingSchedulerMock = MockRepository.GenerateMock<INonBatchingScheduler>();
            functionalLocationServiceMock = MockRepository.GenerateMock<IFunctionalLocationService>();
            scheduleServiceMock = MockRepository.GenerateMock<IScheduleService>();
            mockLog = MockRepository.GenerateMock<ILog>();
            operationalModeServiceMock = MockRepository.GenerateMock<IFunctionalLocationOperationalModeService>();
            targetDefinitionServiceMock = MockRepository.GenerateMock<ITargetDefinitionService>();
            siteConfigurationServiceMock = MockRepository.GenerateMock<ISiteConfigurationService>();

            siteConfigurationServiceMock.Stub(mock => mock.QueryBySiteId(0))
                .IgnoreArguments()
                .Return(SiteConfigurationFixture.CreateDefaultSiteConfiguration(SiteFixture.Oilsands()));

            schedulingService = new ActionItemSchedulingService(
                nonBatchingSchedulerMock,
                actionItemDefinitionServiceMock,
                actionItemServiceMock,
                shiftPatternServiceMock,
                mockRemoteEventRepeater,
                scheduleServiceMock,
                timeServiceMock,
                operationalModeServiceMock, targetDefinitionServiceMock,
                siteConfigurationServiceMock,
                mockLog);

            //Since If the schedulers crashs we capture the exception and do not throw it again (but instead
            //we log it) this expectation is used to confirm no errors are being thrown (and therefore logged)
            mockLog.AssertWasNotCalled(m => m.Error(null), options => options.IgnoreArguments());
        }

        [Test]
        public void OnOnScheduleTriggerShouldNotDoAnythingIfStopRequested()
        {
            var unit = FunctionalLocationFixture.GetAny_Unit1();
            var actionItemDefinition = CreateApprovedActionItemDefinition(66, unit);

            nonBatchingSchedulerMock.Expect(m => m.StopScheduler());
            schedulingService.StopService();

            mockLog.Expect(mock => mock.Debug("Stop Action Item Scheduler requested."));

            schedulingService.OnScheduleTrigger(actionItemDefinition.Schedule, null);

            nonBatchingSchedulerMock.VerifyAllExpectations();
            mockLog.VerifyAllExpectations();
        }

        [Test]
        public void ShouldAddActionItemDefinitionFLOCShiftAdjustedScheduleToScheduler()
        {
            timeServiceMock.Stub(mock => mock.GetTime(null)).IgnoreArguments().Return(Clock.Now);
            var aiDefinition = ActionItemDefinitionFixture.CreateAnApprovedActionItemDefinitionWithFLOCList();
            mockLog.Expect(mock => mock.Debug(null)).IgnoreArguments().Repeat.Any();
            nonBatchingSchedulerMock.Expect(mock => mock.AddSchedule(null)).IgnoreArguments();

            schedulingService.AddActionItemDefinitionSchedule(aiDefinition);
            mockLog.VerifyAllExpectations();
            nonBatchingSchedulerMock.VerifyAllExpectations();
        }

        [Test]
        public void ShouldBuildActionItemDefinitionByFLOC()
        {
            var aiDefinition = ActionItemDefinitionFixture.CreateAPendingActionItemDefinitionWithFLOCList();
            var flattenedList =
                aiDefinition.BuildActionItemDefinitionForEachFunctionalLocation();

            Assert.AreEqual(aiDefinition.FunctionalLocations.Count, flattenedList.Count);

            for (var count = 0; count < flattenedList.Count; count++)
            {
                Assert.AreEqual(aiDefinition.FunctionalLocations[count], flattenedList[count].FunctionalLocations[0]);
            }

            aiDefinition.FunctionalLocations.Clear();

            for (var count = 0; count < flattenedList.Count; count++)
            {
                flattenedList[count].FunctionalLocations.Clear();
                Assert.AreEqual(aiDefinition, flattenedList[count]);
            }
        }

        [Test]
        public void ShouldBuildAnInsertAnActionItemWithDSTAdjustedStartAndEndDateTimes()
        {
            Clock.Freeze();
            Clock.Now = new DateTime(2006, 04, 03, 13, 01, 00);

            timeServiceMock.Stub(mock => mock.GetTime(null)).IgnoreArguments().Return(Clock.Now);

            ISchedule recurringDailySchedule =
                RecurringDailyScheduleFixture.CreateRecurringDailyScheduleBetweenMar30AndMay1From1pmTo1am();

            var shift = ShiftPatternFixture.CreateDayShift();
            var actionItemDefinition =
                ActionItemDefinitionFixture.CreateApprovedActionItemDefinition(1);
            actionItemDefinition.Schedule = recurringDailySchedule;
            actionItemDefinition.OperationalMode = OperationalMode.Normal;
            var floc = FunctionalLocationFixture.GetAny_Unit1();
            var schedule =
                new ActionItemDefinitionFLOCShiftAdjustedSchedule(recurringDailySchedule, floc, 1,
                    shiftPatternServiceMock);
            var flocOperationalMode =
                FunctionalLocationOperationalModeDTOFixture.MakeNormalOpModeDto(floc.IdValue);

            operationalModeServiceMock.Expect(m => m.GetByFunctionalLocationId(floc.IdValue))
                .Return(flocOperationalMode);
            actionItemDefinitionServiceMock.Expect(m => m.QueryById(-1)).IgnoreArguments().Return(actionItemDefinition);
            shiftPatternServiceMock.Expect(m => m.GetShiftBySiteAndDateTimeFavourEarlierShift(null, DateTime.Now))
                .IgnoreArguments()
                .Repeat.Any()
                .Return(shift);
            actionItemServiceMock.Expect(
                m =>
                    m.Insert(
                        Arg<ActionItem>.Matches(
                            ai =>
                                ai.StartDateTime.Equals(new DateTime(2006, 04, 03, 13, 00, 00)) &&
                                ai.EndDateTime.Equals(new DateTime(2006, 04, 04, 01, 00, 00)))));

            schedulingService.OnScheduleTrigger(schedule, null);

            operationalModeServiceMock.VerifyAllExpectations();
            actionItemDefinitionServiceMock.VerifyAllExpectations();
            shiftPatternServiceMock.VerifyAllExpectations();
            actionItemServiceMock.VerifyAllExpectations();

            Clock.UnFreeze();
        }

        [Test]
        public void
            ShouldBuildAndInsertActionItemWhenActionItemDefintionIsTriggeredAndOperationalModesAreBothConstrained()
        {
            var flocOperationalMode = FunctionalLocationOperationalModeDTOFixture.MakeConstrainedOpModeDto();
            timeServiceMock.Stub(mock => mock.GetTime(null)).IgnoreArguments().Return(Clock.Now);

            ISchedule recurringDailySchedule =
                RecurringDailyScheduleFixture.CreateEvery2DaysFrom10AM12To07PM11BetweenJan10AndOct21In2000();
            var floc = FunctionalLocationFixture.GetAny_Unit1();
            flocOperationalMode.Id = floc.Id;

            var correspondingShift = ShiftPatternFixture.CreateDayShift();
            var expectedAID = ActionItemDefinitionFixture.CreateApprovedActionItemDefinition(1);
            expectedAID.OperationalMode = OperationalMode.Constrained;

            var schedule = new ActionItemDefinitionFLOCShiftAdjustedSchedule(recurringDailySchedule, floc, 1,
                shiftPatternServiceMock);

            operationalModeServiceMock.Expect(mock => mock.GetByFunctionalLocationId(floc.IdValue))
                .Return(flocOperationalMode);
            actionItemDefinitionServiceMock.Expect(mock => mock.QueryById(-1)).IgnoreArguments().Return(expectedAID);
            actionItemServiceMock.Expect(mock => mock.Insert(null)).IgnoreArguments().Return(null);
            shiftPatternServiceMock.Expect(mock => mock.GetShiftBySiteAndDateTimeFavourEarlierShift(null, DateTime.Now))
                .IgnoreArguments()
                .Return(correspondingShift);
            scheduleServiceMock.Expect(mock => mock.Update(schedule.InternalSchedule));

            schedulingService.OnScheduleTrigger(schedule, null);

            operationalModeServiceMock.VerifyAllExpectations();
            actionItemDefinitionServiceMock.VerifyAllExpectations();
            actionItemServiceMock.VerifyAllExpectations();
            shiftPatternServiceMock.VerifyAllExpectations();
            scheduleServiceMock.VerifyAllExpectations();
        }

        [Test]
        public void ShouldBuildAndInsertActionItemWhenActionItemDefintionIsTriggeredAndOperationalModesAreBothNormal()
        {
            var flocOperationalMode = FunctionalLocationOperationalModeDTOFixture.MakeNormalOpModeDto();

            timeServiceMock.Stub(mock => mock.GetTime(null)).IgnoreArguments().Return(Clock.Now);

            ISchedule recurringDailySchedule =
                RecurringDailyScheduleFixture.CreateEvery2DaysFrom10AM12To07PM11BetweenJan10AndOct21In2000();
            var floc = FunctionalLocationFixture.GetAny_Unit1();
            flocOperationalMode.Id = floc.Id;

            var correspondingShift = ShiftPatternFixture.CreateDayShift();
            var expectedAID = ActionItemDefinitionFixture.CreateApprovedActionItemDefinition(1);
            expectedAID.OperationalMode = OperationalMode.Normal;

            var schedule = new ActionItemDefinitionFLOCShiftAdjustedSchedule(recurringDailySchedule, floc, 1,
                shiftPatternServiceMock);

            operationalModeServiceMock.Expect(mock => mock.GetByFunctionalLocationId(floc.IdValue))
                .Return(flocOperationalMode);
            actionItemDefinitionServiceMock.Expect(mock => mock.QueryById(0)).IgnoreArguments().Return(expectedAID);
            actionItemServiceMock.Expect(mock => mock.Insert(null)).IgnoreArguments().Return(null);
            shiftPatternServiceMock.Expect(mock => mock.GetShiftBySiteAndDateTimeFavourEarlierShift(null, DateTime.Now))
                .IgnoreArguments()
                .Return(correspondingShift);
            scheduleServiceMock.Expect(mock => mock.Update(schedule.InternalSchedule));

            schedulingService.OnScheduleTrigger(schedule, null);

            operationalModeServiceMock.VerifyAllExpectations();
            actionItemDefinitionServiceMock.VerifyAllExpectations();
            actionItemServiceMock.VerifyAllExpectations();
            shiftPatternServiceMock.VerifyAllExpectations();
            scheduleServiceMock.VerifyAllExpectations();
        }

        [Test]
        public void ShouldBuildAndInsertActionItemWhenActionItemDefintionIsTriggeredAndOperationalModesAreBothShutDown()
        {
            var flocOperationalMode = FunctionalLocationOperationalModeDTOFixture.MakeShutDownOpModeDto();
            timeServiceMock.Stub(mock => mock.GetTime(null)).IgnoreArguments().Return(Clock.Now);

            ISchedule recurringDailySchedule =
                RecurringDailyScheduleFixture.CreateEvery2DaysFrom10AM12To07PM11BetweenJan10AndOct21In2000();
            var floc = FunctionalLocationFixture.GetAny_Unit1();
            flocOperationalMode.Id = floc.Id;

            var correspondingShift = ShiftPatternFixture.CreateDayShift();
            var expectedAID = ActionItemDefinitionFixture.CreateApprovedActionItemDefinition(1);
            expectedAID.OperationalMode = OperationalMode.ShutDown;

            var schedule = new ActionItemDefinitionFLOCShiftAdjustedSchedule(recurringDailySchedule, floc, 1,
                shiftPatternServiceMock);

            operationalModeServiceMock.Expect(mock => mock.GetByFunctionalLocationId(floc.IdValue))
                .Return(flocOperationalMode);
            actionItemDefinitionServiceMock.Expect(mock => mock.QueryById(-1)).IgnoreArguments().Return(expectedAID);
            actionItemServiceMock.Expect(mock => mock.Insert(null)).IgnoreArguments().Return(null);
            shiftPatternServiceMock.Expect(mock => mock.GetShiftBySiteAndDateTimeFavourEarlierShift(null, DateTime.Now))
                .IgnoreArguments()
                .Return(correspondingShift);
            scheduleServiceMock.Expect(mock => mock.Update(schedule.InternalSchedule));

            schedulingService.OnScheduleTrigger(schedule, null);

            operationalModeServiceMock.VerifyAllExpectations();
            actionItemDefinitionServiceMock.VerifyAllExpectations();
            actionItemServiceMock.VerifyAllExpectations();
            shiftPatternServiceMock.VerifyAllExpectations();
            scheduleServiceMock.VerifyAllExpectations();
        }

        [Test]
        public void ShouldContinueWithLoadEvenIfExceptionIsEncountered()
        {
            var badDefinition = CreateApprovedActionItemDefinition(1, FunctionalLocationFixture.GetAny_Unit1());
            badDefinition.Schedule = null;
            var definitions = new List<ActionItemDefinition> {badDefinition};

            nonBatchingSchedulerMock.Expect(m => m.StartInitialLoad());
            nonBatchingSchedulerMock.Expect(m => m.InitialLoadComplete());

            actionItemDefinitionServiceMock.Stub(m => m.QueryAllAvailableForScheduling()).Return(definitions);

            schedulingService.LoadScheduler();

            nonBatchingSchedulerMock.VerifyAllExpectations();
            actionItemDefinitionServiceMock.VerifyAllExpectations();
        }

        [Test]
        public void ShouldCreateActionItemIfAllAssociatedTargetDefinitionsAreExceedingBoundaries()
        {
            const int actionItemDefinitionId = 100;

            var actionItemDefinition =
                ActionItemDefinitionFixture
                    .CreateApprovedActionItemDefinitionWithLinkedTargetDefinitionForMcMurrayWithId(
                        actionItemDefinitionId);
            actionItemDefinition.CreateAnActionItemForEachFunctionalLocation = false;

            var idOfFirstTargetDefinition = actionItemDefinition.TargetDefinitionDTOs[0].IdValue;
            var idOfSecondTargetDefinition = idOfFirstTargetDefinition + 10;
            var targetDefinitionDto = new TargetDefinitionDTO(TargetDefinitionFixture.CreateTargetDefinition())
            {
                Id = idOfSecondTargetDefinition
            };
            actionItemDefinition.TargetDefinitionDTOs.Add(targetDefinitionDto);

            var functionalLocation = actionItemDefinition.FunctionalLocations[0];

            var adjustedSchedule = new ActionItemDefinitionFLOCShiftAdjustedSchedule(actionItemDefinition.Schedule,
                functionalLocation, actionItemDefinitionId,
                shiftPatternServiceMock);
            actionItemDefinitionServiceMock.Stub(m => m.QueryById(actionItemDefinitionId)).Return(actionItemDefinition);
            var now = Clock.Now;
            timeServiceMock.Stub(m => m.GetTime(null)).IgnoreArguments().Return(now);
            shiftPatternServiceMock.Stub(
                m => m.GetShiftBySiteAndDateTimeFavourEarlierShift(functionalLocation.Site, now))
                .IgnoreArguments()
                .Return(ShiftPatternFixture.CreateDayShift(now));

            var targetDefinition = TargetDefinitionFixture.CreateTargetDefinition(TargetDefinitionStatus.Approved, false);
            targetDefinition.Deleted = false;
            targetDefinition.IsActive = true;

            targetDefinitionServiceMock.Stub(m => m.QueryById(idOfFirstTargetDefinition)).Return(targetDefinition);
            targetDefinitionServiceMock.Expect(m => m.QueryState(idOfFirstTargetDefinition))
                .Return(new TargetDefinitionState(idOfFirstTargetDefinition, true, Clock.Now));

            targetDefinitionServiceMock.Stub(m => m.QueryById(idOfSecondTargetDefinition)).Return(targetDefinition);
            targetDefinitionServiceMock.Expect(m => m.QueryState(idOfSecondTargetDefinition))
                .Return(new TargetDefinitionState(idOfSecondTargetDefinition, true, Clock.Now));

            var functionalLocationOperationalModeDto = new FunctionalLocationOperationalModeDTO(-99, "Who cares",
                "who cares",
                actionItemDefinition.OperationalMode,
                AvailabilityReason.RoutineMaintenance, Clock.Now);
            operationalModeServiceMock.Stub(m => m.GetByFunctionalLocationId(-99))
                .IgnoreArguments()
                .Return(functionalLocationOperationalModeDto);
            actionItemServiceMock.Expect(
                m =>
                    m.Insert(Arg<ActionItem>.Matches(ai => ai.CreatedByActionItemDefinition.Equals(actionItemDefinition))))
                .Return(null);

            schedulingService.OnScheduleTrigger(adjustedSchedule, null);

            targetDefinitionServiceMock.VerifyAllExpectations();
            actionItemServiceMock.VerifyAllExpectations();
        }

        [Test]
        public void ShouldCreateOneActionItemForAllFlocs_AllFlocOperationModesMatch()
        {
            timeServiceMock.Stub(mock => mock.GetTime(null)).IgnoreArguments().Return(Clock.Now);

            //  Normal Operational Mode
            var floc1 = FunctionalLocationFixture.GetAny_Unit1();
            var opModeDto1 = FunctionalLocationOperationalModeDTOFixture.MakeDto(OperationalMode.Normal);
            floc1.Id = floc1.Id;
            operationalModeServiceMock.Stub(m => m.GetByFunctionalLocationId(floc1.IdValue)).Return(opModeDto1);

            //  Constrained Operational Mode
            var floc2 = FunctionalLocationFixture.GetAny_Equip1();
            var opModeDto2 = FunctionalLocationOperationalModeDTOFixture.MakeDto(OperationalMode.Normal);
            opModeDto2.Id = floc2.Id;
            operationalModeServiceMock.Stub(m => m.GetByFunctionalLocationId(opModeDto2.IdValue)).Return(opModeDto2);

            // Associate the Two FLOCs to ActionItemDefinition to be triggered.
            var aidToBeTriggered = ActionItemDefinitionFixture.CreateApprovedActionItemDefinition(1);
            aidToBeTriggered.CreateAnActionItemForEachFunctionalLocation = false;
            aidToBeTriggered.FunctionalLocations.Clear();
            aidToBeTriggered.FunctionalLocations.Add(floc1);
            aidToBeTriggered.FunctionalLocations.Add(floc2);
            aidToBeTriggered.OperationalMode = OperationalMode.Normal;
            actionItemDefinitionServiceMock.Stub(m => m.QueryById(-1)).IgnoreArguments().Return(aidToBeTriggered);

            // Expectations for insert
            var correspondingShift = ShiftPatternFixture.CreateDayShift();
            shiftPatternServiceMock.Stub(m => m.GetShiftBySiteAndDateTimeFavourEarlierShift(null, DateTime.Now))
                .IgnoreArguments()
                .Return(correspondingShift);
            functionalLocationServiceMock.Stub(m => m.QueryById(floc1.IdValue)).Return(floc1);
            actionItemServiceMock.Expect(
                m =>
                    m.Insert(
                        Arg<ActionItem>.Matches(
                            ai => ai.FunctionalLocations.Contains(floc1) && ai.FunctionalLocations.Contains(floc2))))
                .Return(null);

            //
            // Note, It does not matter which FLOC is used to create Shift Adjusted AID Schedule because
            // aidToBeTriggered.FunctionalLocations belong to a shift.
            //
            ISchedule recurringDailySchedule =
                RecurringDailyScheduleFixture.CreateEvery2DaysFrom10AM12To07PM11BetweenJan10AndOct21In2000();
            var adjustedSchedule = new ActionItemDefinitionFLOCShiftAdjustedSchedule(recurringDailySchedule, floc1, 1,
                shiftPatternServiceMock);

            scheduleServiceMock.Expect(m => m.Update(adjustedSchedule.InternalSchedule));

            schedulingService.OnScheduleTrigger(adjustedSchedule, null);

            shiftPatternServiceMock.VerifyAllExpectations();
            actionItemServiceMock.VerifyAllExpectations();
            scheduleServiceMock.VerifyAllExpectations();
        }

        [Test]
        public void ShouldCreateOneActionItemForAllFlocs_AtLeastOneFlocOperationModeMatches()
        {
            timeServiceMock.Stub(mock => mock.GetTime(null)).IgnoreArguments().Return(Clock.Now);

            //  Normal Operational Mode
            var floc1 = FunctionalLocationFixture.GetAny_Unit1();
            floc1.Id = 10;
            var opModeDto1 = FunctionalLocationOperationalModeDTOFixture.MakeDto(OperationalMode.Normal);

            operationalModeServiceMock.Stub(mock => mock.GetByFunctionalLocationId(floc1.IdValue))
                .Return(opModeDto1)
                .Repeat.Any();

            //  Constrained Operational Mode
            var floc2 = FunctionalLocationFixture.GetAny_Equip1();
            floc2.Id = 20;
            var opModeDto2 = FunctionalLocationOperationalModeDTOFixture.MakeDto(OperationalMode.Constrained);
            opModeDto2.Id = floc2.Id;
            operationalModeServiceMock.Stub(mock => mock.GetByFunctionalLocationId(floc2.IdValue))
                .Return(opModeDto2)
                .Repeat.Any();

            // Associate the Two FLOCs to ActionItemDefinition to be triggered.
            var aidToBeTriggered = ActionItemDefinitionFixture.CreateApprovedActionItemDefinition(1);
            aidToBeTriggered.CreateAnActionItemForEachFunctionalLocation = false;
            aidToBeTriggered.FunctionalLocations.Clear();
            aidToBeTriggered.FunctionalLocations.Add(floc1);
            aidToBeTriggered.FunctionalLocations.Add(floc2);
            aidToBeTriggered.OperationalMode = OperationalMode.Normal;
            actionItemDefinitionServiceMock.Expect(mock => mock.QueryById(-1))
                .IgnoreArguments()
                .Return(aidToBeTriggered);

            // Expectations for insert
            var correspondingShift = ShiftPatternFixture.CreateDayShift();
            shiftPatternServiceMock.Expect(mock => mock.GetShiftBySiteAndDateTimeFavourEarlierShift(null, DateTime.Now))
                .IgnoreArguments()
                .Return(correspondingShift);
            functionalLocationServiceMock.Stub(mock => mock.QueryById(floc1.IdValue)).Return(floc1).Repeat.Any();
            actionItemServiceMock.Expect(
                m =>
                    m.Insert(
                        Arg<ActionItem>.Matches(
                            ai => ai.FunctionalLocations.Contains(floc1) && ai.FunctionalLocations.Contains(floc2))))
                .Return(null);

            //
            // Note, It does not matter which FLOC is used to create Shift Adjusted AID Schedule because
            // aidToBeTriggered.FunctionalLocations belong to a shift.
            //
            ISchedule recurringDailySchedule =
                RecurringDailyScheduleFixture.CreateEvery2DaysFrom10AM12To07PM11BetweenJan10AndOct21In2000();
            var adjustedSchedule = new ActionItemDefinitionFLOCShiftAdjustedSchedule(recurringDailySchedule, floc1, 1,
                shiftPatternServiceMock);

            scheduleServiceMock.Expect(m => m.Update(adjustedSchedule.InternalSchedule));

            schedulingService.OnScheduleTrigger(adjustedSchedule, null);

            shiftPatternServiceMock.VerifyAllExpectations();
            actionItemServiceMock.VerifyAllExpectations();
            scheduleServiceMock.VerifyAllExpectations();
        }

        [Test]
        public void ShouldLoadActionItemDefinitions()
        {
            var actionItemDefinitions = new List<ActionItemDefinition>();
            var aiDefintionRecurringDaily =
                ActionItemDefinitionFixture.CreateApprovedActionItemDefinitionForMcMurrayWithActionItemId(1);
            aiDefintionRecurringDaily.Schedule =
                RecurringDailyScheduleFixture.CreateEvery2DaysFrom10AM12To07PM11BetweenJan10AndOct21In2000();
            aiDefintionRecurringDaily.FunctionalLocations =
                FunctionalLocationFixture.CreateNewListOfNewItems(3);

            var aiDefintionRecurringWeekly =
                ActionItemDefinitionFixture.CreateApprovedActionItemDefinitionForMcMurrayWithActionItemId(2);
            aiDefintionRecurringWeekly.Schedule =
                RecurringWeeklyScheduleFixture.CreateEveryMondayAndFridayFrom8AMTO2PMBetweenJan1AndOct10In2000();
            aiDefintionRecurringWeekly.FunctionalLocations =
                FunctionalLocationFixture.GetListWith2Units();

            actionItemDefinitions.Add(aiDefintionRecurringDaily);
            actionItemDefinitions.Add(aiDefintionRecurringWeekly);


            actionItemDefinitionServiceMock.Expect(m => m.QueryAllAvailableForScheduling())
                .Return(actionItemDefinitions);
            mockLog.Expect(mock => mock.Debug(null)).IgnoreArguments().Repeat.Any();

            nonBatchingSchedulerMock.Expect(m => m.AddSchedule(null)).IgnoreArguments().Repeat.Once();

            schedulingService.LoadScheduler();

            mockLog.VerifyAllExpectations();
            actionItemDefinitionServiceMock.VerifyAllExpectations();
            nonBatchingSchedulerMock.VerifyAllExpectations();
        }

        [Test]
        public void ShouldNotAddInactiveActionItemDefinitionToScheduler()
        {
            timeServiceMock.Stub(mock => mock.GetTime(null)).IgnoreArguments().Return(Clock.Now);
            var aiDefinition = ActionItemDefinitionFixture.CreateAnApprovedActionItemDefinitionWithFLOCList();
            aiDefinition.Active = false;

            mockLog.Expect(mock => mock.Debug(null)).IgnoreArguments().Repeat.Any();
            nonBatchingSchedulerMock.AssertWasNotCalled(m => m.AddSchedule(null), y => y.IgnoreArguments());

            schedulingService.AddActionItemDefinitionSchedule(aiDefinition);
            mockLog.VerifyAllExpectations();
            nonBatchingSchedulerMock.VerifyAllExpectations();
        }

        [Test]
        public void ShouldNotCreateActionItemIfAssociatedTargetDefinitionIsNotExceedingBoundaries()
        {
            const int actionItemDefinitionId = 100;

            var actionItemDefinition =
                ActionItemDefinitionFixture
                    .CreateApprovedActionItemDefinitionWithLinkedTargetDefinitionForMcMurrayWithId(
                        actionItemDefinitionId);
            actionItemDefinition.CreateAnActionItemForEachFunctionalLocation = false;

            var idOfFirstTargetDefinition = actionItemDefinition.TargetDefinitionDTOs[0].IdValue;

            var functionalLocation = actionItemDefinition.FunctionalLocations[0];

            var adjustedSchedule = new ActionItemDefinitionFLOCShiftAdjustedSchedule(actionItemDefinition.Schedule,
                functionalLocation, actionItemDefinitionId,
                shiftPatternServiceMock);
            actionItemDefinitionServiceMock.Stub(m => m.QueryById(actionItemDefinitionId)).Return(actionItemDefinition);
            var now = Clock.Now;
            timeServiceMock.Stub(m => m.GetTime(null)).IgnoreArguments().Return(now);
            shiftPatternServiceMock.Stub(
                m => m.GetShiftBySiteAndDateTimeFavourEarlierShift(functionalLocation.Site, now))
                .IgnoreArguments()
                .Return(ShiftPatternFixture.CreateDayShift(now));

            var targetDefinition = TargetDefinitionFixture.CreateTargetDefinition(TargetDefinitionStatus.Approved, false);
            targetDefinition.Deleted = false;
            targetDefinition.IsActive = true;

            targetDefinitionServiceMock.Stub(m => m.QueryById(idOfFirstTargetDefinition)).Return(targetDefinition);

            targetDefinitionServiceMock.Expect(m => m.QueryState(idOfFirstTargetDefinition))
                .Return(new TargetDefinitionState(idOfFirstTargetDefinition, false, Clock.Now));

            actionItemServiceMock.AssertWasNotCalled(
                m =>
                    m.Insert(Arg<ActionItem>.Matches(ai => ai.CreatedByActionItemDefinition.Equals(actionItemDefinition))));

            schedulingService.OnScheduleTrigger(adjustedSchedule, null);

            targetDefinitionServiceMock.VerifyAllExpectations();
            actionItemServiceMock.VerifyAllExpectations();
        }

        [Test]
        public void ShouldNotCreateActionItemIfOneAssociatedTargetDefinitionIsDeleted()
        {
            const int actionItemDefinitionId = 100;

            var actionItemDefinition =
                ActionItemDefinitionFixture
                    .CreateApprovedActionItemDefinitionWithLinkedTargetDefinitionForMcMurrayWithId(
                        actionItemDefinitionId);
            actionItemDefinition.CreateAnActionItemForEachFunctionalLocation = false;

            var idOfFirstTargetDefinition = actionItemDefinition.TargetDefinitionDTOs[0].IdValue;
            var idOfSecondTargetDefinition = idOfFirstTargetDefinition + 10;
            var targetDefinitionDto = new TargetDefinitionDTO(TargetDefinitionFixture.CreateTargetDefinition())
            {
                Id = idOfSecondTargetDefinition
            };
            actionItemDefinition.TargetDefinitionDTOs.Add(targetDefinitionDto);

            var functionalLocation = actionItemDefinition.FunctionalLocations[0];

            var adjustedSchedule = new ActionItemDefinitionFLOCShiftAdjustedSchedule(actionItemDefinition.Schedule,
                functionalLocation, actionItemDefinitionId,
                shiftPatternServiceMock);
            actionItemDefinitionServiceMock.Stub(m => m.QueryById(actionItemDefinitionId)).Return(actionItemDefinition);
            var now = Clock.Now;
            timeServiceMock.Stub(m => m.GetTime(null)).IgnoreArguments().Return(now);
            shiftPatternServiceMock.Stub(
                m => m.GetShiftBySiteAndDateTimeFavourEarlierShift(functionalLocation.Site, now))
                .IgnoreArguments()
                .Return(ShiftPatternFixture.CreateDayShift(now));

            var targetDefinition = TargetDefinitionFixture.CreateTargetDefinition(TargetDefinitionStatus.Approved, false);
            targetDefinition.Deleted = true;
            targetDefinition.IsActive = true;

            targetDefinitionServiceMock.Expect(m => m.QueryById(idOfFirstTargetDefinition)).Return(targetDefinition);
            targetDefinitionServiceMock.AssertWasNotCalled(m => m.QueryState(idOfFirstTargetDefinition));

            targetDefinitionServiceMock.Stub(m => m.QueryById(idOfSecondTargetDefinition)).Return(targetDefinition);
            targetDefinitionServiceMock.Stub(m => m.QueryState(idOfSecondTargetDefinition))
                .Return(new TargetDefinitionState(idOfSecondTargetDefinition, false, Clock.Now));

            actionItemServiceMock.AssertWasNotCalled(
                m =>
                    m.Insert(Arg<ActionItem>.Matches(ai => ai.CreatedByActionItemDefinition.Equals(actionItemDefinition))));

            schedulingService.OnScheduleTrigger(adjustedSchedule, null);

            targetDefinitionServiceMock.VerifyAllExpectations();
            actionItemServiceMock.VerifyAllExpectations();
        }

        [Test]
        public void ShouldNotCreateActionItemIfOneAssociatedTargetDefinitionIsNotActive()
        {
            const int actionItemDefinitionId = 100;

            var actionItemDefinition =
                ActionItemDefinitionFixture
                    .CreateApprovedActionItemDefinitionWithLinkedTargetDefinitionForMcMurrayWithId(
                        actionItemDefinitionId);
            actionItemDefinition.CreateAnActionItemForEachFunctionalLocation = false;

            var idOfFirstTargetDefinition = actionItemDefinition.TargetDefinitionDTOs[0].IdValue;
            var idOfSecondTargetDefinition = idOfFirstTargetDefinition + 10;
            var targetDefinitionDto = new TargetDefinitionDTO(TargetDefinitionFixture.CreateTargetDefinition())
            {
                Id = idOfSecondTargetDefinition
            };
            actionItemDefinition.TargetDefinitionDTOs.Add(targetDefinitionDto);

            var functionalLocation = actionItemDefinition.FunctionalLocations[0];

            var adjustedSchedule = new ActionItemDefinitionFLOCShiftAdjustedSchedule(actionItemDefinition.Schedule,
                functionalLocation, actionItemDefinitionId,
                shiftPatternServiceMock);
            actionItemDefinitionServiceMock.Stub(m => m.QueryById(actionItemDefinitionId)).Return(actionItemDefinition);
            var now = Clock.Now;
            timeServiceMock.Stub(m => m.GetTime(null)).IgnoreArguments().Return(now);
            shiftPatternServiceMock.Stub(
                m => m.GetShiftBySiteAndDateTimeFavourEarlierShift(functionalLocation.Site, now))
                .IgnoreArguments()
                .Return(ShiftPatternFixture.CreateDayShift(now));

            var targetDefinition = TargetDefinitionFixture.CreateTargetDefinition(TargetDefinitionStatus.Approved, false);
            targetDefinition.Deleted = false;
            targetDefinition.IsActive = false;

            targetDefinitionServiceMock.Expect(m => m.QueryById(idOfFirstTargetDefinition)).Return(targetDefinition);
            targetDefinitionServiceMock.AssertWasNotCalled(m => m.QueryState(idOfFirstTargetDefinition));

            targetDefinitionServiceMock.Stub(m => m.QueryById(idOfSecondTargetDefinition)).Return(targetDefinition);
            targetDefinitionServiceMock.Stub(m => m.QueryState(idOfSecondTargetDefinition))
                .Return(new TargetDefinitionState(idOfSecondTargetDefinition, false, Clock.Now));

            actionItemServiceMock.AssertWasNotCalled(
                m =>
                    m.Insert(Arg<ActionItem>.Matches(ai => ai.CreatedByActionItemDefinition.Equals(actionItemDefinition))));

            schedulingService.OnScheduleTrigger(adjustedSchedule, null);

            targetDefinitionServiceMock.VerifyAllExpectations();
            actionItemServiceMock.VerifyAllExpectations();
        }

        [Test]
        public void
            ShouldNotCreateActionItemIfOneAssociatedTargetDefinitionIsNotExceedingBoundariesAndTheOthersAreExceedingBoundaries
            ()
        {
            const int actionItemDefinitionId = 100;

            var actionItemDefinition =
                ActionItemDefinitionFixture
                    .CreateApprovedActionItemDefinitionWithLinkedTargetDefinitionForMcMurrayWithId(
                        actionItemDefinitionId);
            actionItemDefinition.CreateAnActionItemForEachFunctionalLocation = false;

            var idOfFirstTargetDefinition = actionItemDefinition.TargetDefinitionDTOs[0].IdValue;
            var idOfSecondTargetDefinition = idOfFirstTargetDefinition + 10;
            var targetDefinitionDto = new TargetDefinitionDTO(TargetDefinitionFixture.CreateTargetDefinition())
            {
                Id = idOfSecondTargetDefinition
            };
            actionItemDefinition.TargetDefinitionDTOs.Add(targetDefinitionDto);

            var functionalLocation = actionItemDefinition.FunctionalLocations[0];

            var adjustedSchedule = new ActionItemDefinitionFLOCShiftAdjustedSchedule(actionItemDefinition.Schedule,
                functionalLocation, actionItemDefinitionId,
                shiftPatternServiceMock);
            actionItemDefinitionServiceMock.Stub(m => m.QueryById(actionItemDefinitionId)).Return(actionItemDefinition);
            var now = Clock.Now;
            timeServiceMock.Stub(m => m.GetTime(null)).IgnoreArguments().Return(now);
            shiftPatternServiceMock.Stub(
                m => m.GetShiftBySiteAndDateTimeFavourEarlierShift(functionalLocation.Site, now))
                .IgnoreArguments()
                .Return(ShiftPatternFixture.CreateDayShift(now));

            var targetDefinition = TargetDefinitionFixture.CreateTargetDefinition(TargetDefinitionStatus.Approved, false);
            targetDefinition.Deleted = false;
            targetDefinition.IsActive = true;

            targetDefinitionServiceMock.Stub(m => m.QueryById(idOfFirstTargetDefinition)).Return(targetDefinition);
            targetDefinitionServiceMock.Expect(m => m.QueryState(idOfFirstTargetDefinition))
                .Return(new TargetDefinitionState(idOfFirstTargetDefinition, true, Clock.Now));

            targetDefinitionServiceMock.Stub(m => m.QueryById(idOfSecondTargetDefinition)).Return(targetDefinition);
            targetDefinitionServiceMock.Expect(m => m.QueryState(idOfSecondTargetDefinition))
                .Return(new TargetDefinitionState(idOfSecondTargetDefinition, false, Clock.Now));

            actionItemServiceMock.AssertWasNotCalled(
                m =>
                    m.Insert(Arg<ActionItem>.Matches(ai => ai.CreatedByActionItemDefinition.Equals(actionItemDefinition))));

            schedulingService.OnScheduleTrigger(adjustedSchedule, null);

            targetDefinitionServiceMock.VerifyAllExpectations();
            actionItemServiceMock.VerifyAllExpectations();
        }

        [Test]
        public void ShouldNotCreateActionItemIfOneAssociatedTargetDefinitionIsPendingApproval()
        {
            const int actionItemDefinitionId = 100;

            var actionItemDefinition =
                ActionItemDefinitionFixture
                    .CreateApprovedActionItemDefinitionWithLinkedTargetDefinitionForMcMurrayWithId(
                        actionItemDefinitionId);
            actionItemDefinition.CreateAnActionItemForEachFunctionalLocation = false;

            var idOfFirstTargetDefinition = actionItemDefinition.TargetDefinitionDTOs[0].IdValue;
            var idOfSecondTargetDefinition = idOfFirstTargetDefinition + 10;
            var targetDefinitionDto = new TargetDefinitionDTO(TargetDefinitionFixture.CreateTargetDefinition())
            {
                Id = idOfSecondTargetDefinition
            };
            actionItemDefinition.TargetDefinitionDTOs.Add(targetDefinitionDto);

            var functionalLocation = actionItemDefinition.FunctionalLocations[0];

            var adjustedSchedule = new ActionItemDefinitionFLOCShiftAdjustedSchedule(actionItemDefinition.Schedule,
                functionalLocation, actionItemDefinitionId,
                shiftPatternServiceMock);
            actionItemDefinitionServiceMock.Stub(m => m.QueryById(actionItemDefinitionId)).Return(actionItemDefinition);
            var now = Clock.Now;
            timeServiceMock.Stub(m => m.GetTime(null)).IgnoreArguments().Return(now);
            shiftPatternServiceMock.Stub(
                m => m.GetShiftBySiteAndDateTimeFavourEarlierShift(functionalLocation.Site, now))
                .IgnoreArguments()
                .Return(ShiftPatternFixture.CreateDayShift(now));

            var goodTargetDefinition = TargetDefinitionFixture.CreateTargetDefinition(TargetDefinitionStatus.Approved,
                false);
            goodTargetDefinition.Id = idOfFirstTargetDefinition;
            goodTargetDefinition.Deleted = false;
            goodTargetDefinition.IsActive = true;

            targetDefinitionServiceMock.Expect(m => m.QueryById(idOfFirstTargetDefinition)).Return(goodTargetDefinition);
            targetDefinitionServiceMock.Expect(m => m.QueryState(idOfFirstTargetDefinition))
                .Return(new TargetDefinitionState(idOfFirstTargetDefinition, true, Clock.Now));

            var notApprovedTargetDefinition =
                TargetDefinitionFixture.CreateTargetDefinition(TargetDefinitionStatus.Pending, true);
            notApprovedTargetDefinition.Id = idOfSecondTargetDefinition;
            notApprovedTargetDefinition.Deleted = false;
            notApprovedTargetDefinition.IsActive = true;

            targetDefinitionServiceMock.Expect(m => m.QueryById(idOfSecondTargetDefinition))
                .Return(notApprovedTargetDefinition);
            targetDefinitionServiceMock.AssertWasNotCalled(m => m.QueryState(idOfSecondTargetDefinition));

            actionItemServiceMock.AssertWasNotCalled(
                m =>
                    m.Insert(Arg<ActionItem>.Matches(ai => ai.CreatedByActionItemDefinition.Equals(actionItemDefinition))));

            schedulingService.OnScheduleTrigger(adjustedSchedule, null);

            targetDefinitionServiceMock.VerifyAllExpectations();
            actionItemServiceMock.VerifyAllExpectations();
        }

        [Test]
        public void ShouldNotCreateOneActionItemForAllFlocs_NoFlocOperationModeMatches()
        {
            timeServiceMock.Stub(mock => mock.GetTime(null)).IgnoreArguments().Return(Clock.Now);

            //  Normal Operational Mode
            var floc1 = FunctionalLocationFixture.GetAny_Unit1();
            var opModeDto1 = FunctionalLocationOperationalModeDTOFixture.MakeDto(OperationalMode.Constrained);
            floc1.Id = 10;
            operationalModeServiceMock.Stub(m => m.GetByFunctionalLocationId(floc1.IdValue)).Return(opModeDto1);

            //  Constrained Operational Mode
            var floc2 = FunctionalLocationFixture.GetAny_Equip1();
            floc2.Id = 20;
            var opModeDto2 = FunctionalLocationOperationalModeDTOFixture.MakeDto(OperationalMode.ShutDown);
            opModeDto2.Id = floc2.Id;
            operationalModeServiceMock.Stub(m => m.GetByFunctionalLocationId(floc2.IdValue)).Return(opModeDto2);

            // Associate the Two FLOCs to ActionItemDefinition to be triggered.
            var aidToBeTriggered = ActionItemDefinitionFixture.CreateApprovedActionItemDefinition(1);
            aidToBeTriggered.CreateAnActionItemForEachFunctionalLocation = false;
            aidToBeTriggered.FunctionalLocations.Clear();
            aidToBeTriggered.FunctionalLocations.Add(floc1);
            aidToBeTriggered.FunctionalLocations.Add(floc2);
            aidToBeTriggered.OperationalMode = OperationalMode.Normal;
            actionItemDefinitionServiceMock.Stub(m => m.QueryById(-1)).IgnoreArguments().Return(aidToBeTriggered);

            // Expectations for insert
            var correspondingShift = ShiftPatternFixture.CreateDayShift();
            shiftPatternServiceMock.Stub(m => m.GetShiftBySiteAndDateTimeFavourEarlierShift(null, DateTime.Now))
                .IgnoreArguments()
                .Return(correspondingShift);
            functionalLocationServiceMock.Stub(m => m.QueryById(floc1.IdValue)).Return(floc1);

            actionItemServiceMock.AssertWasNotCalled(m => m.Insert(Arg<ActionItem>.Is.Anything));
            scheduleServiceMock.AssertWasNotCalled(m => m.Update(Arg<ISchedule>.Is.Anything));

            //
            // Note, It does not matter which FLOC is used to create Shift Adjusted AID Schedule because
            // aidToBeTriggered.FunctionalLocations belong to a shift.
            //
            ISchedule recurringDailySchedule =
                RecurringDailyScheduleFixture.CreateEvery2DaysFrom10AM12To07PM11BetweenJan10AndOct21In2000();
            var adjustedSchedule = new ActionItemDefinitionFLOCShiftAdjustedSchedule(recurringDailySchedule, floc1, 1,
                shiftPatternServiceMock);

            schedulingService.OnScheduleTrigger(adjustedSchedule, null);

            shiftPatternServiceMock.VerifyAllExpectations();
            actionItemServiceMock.VerifyAllExpectations();
            scheduleServiceMock.VerifyAllExpectations();
        }

        [Test]
        public void ShouldNotInsertActionItemWhenActionItemDefintionConstrainedAndFLOCIsShutdown()
        {
            var flocOperationalMode = FunctionalLocationOperationalModeDTOFixture.MakeShutDownOpModeDto();
            ISchedule recurringDailySchedule =
                RecurringDailyScheduleFixture.CreateEvery2DaysFrom10AM12To07PM11BetweenJan10AndOct21In2000();
            var floc = FunctionalLocationFixture.GetAny_Unit1();
            flocOperationalMode.Id = floc.Id;

            var expectedAID = ActionItemDefinitionFixture.CreateApprovedActionItemDefinition(1);
            expectedAID.OperationalMode = OperationalMode.Constrained;

            var schedule = new ActionItemDefinitionFLOCShiftAdjustedSchedule(recurringDailySchedule, floc, 1,
                shiftPatternServiceMock);

            operationalModeServiceMock.Expect(mock => mock.GetByFunctionalLocationId(floc.IdValue))
                .Return(flocOperationalMode);
            actionItemDefinitionServiceMock.Expect(mock => mock.QueryById(-1)).IgnoreArguments().Return(expectedAID);

            schedulingService.OnScheduleTrigger(schedule, null);

            actionItemDefinitionServiceMock.VerifyAllExpectations();
            operationalModeServiceMock.VerifyAllExpectations();
        }

        [Test]
        public void ShouldNotInsertActionItemWhenActionItemDefintionNormalAndFLOCIsShutdown()
        {
            var flocOperationalMode = FunctionalLocationOperationalModeDTOFixture.MakeShutDownOpModeDto();
            ISchedule recurringDailySchedule =
                RecurringDailyScheduleFixture.CreateEvery2DaysFrom10AM12To07PM11BetweenJan10AndOct21In2000();
            var floc = FunctionalLocationFixture.GetAny_Unit1();
            flocOperationalMode.Id = floc.Id;

            var expectedAID = ActionItemDefinitionFixture.CreateApprovedActionItemDefinition(1);
            expectedAID.OperationalMode = OperationalMode.Normal;

            var schedule = new ActionItemDefinitionFLOCShiftAdjustedSchedule(recurringDailySchedule, floc, 1,
                shiftPatternServiceMock);

            operationalModeServiceMock.Expect(mock => mock.GetByFunctionalLocationId(floc.IdValue))
                .Return(flocOperationalMode);
            actionItemDefinitionServiceMock.Expect(mock => mock.QueryById(-1)).IgnoreArguments().Return(expectedAID);

            schedulingService.OnScheduleTrigger(schedule, null);

            actionItemDefinitionServiceMock.VerifyAllExpectations();
            operationalModeServiceMock.VerifyAllExpectations();
        }

        [Test]
        public void ShouldNotInsertActionItemWhenActionItemDefintionShutDownAndFLOCIsNormal()
        {
            var flocOperationalMode = FunctionalLocationOperationalModeDTOFixture.MakeNormalOpModeDto();
            ISchedule recurringDailySchedule =
                RecurringDailyScheduleFixture.CreateEvery2DaysFrom10AM12To07PM11BetweenJan10AndOct21In2000();
            var floc = FunctionalLocationFixture.GetAny_Unit1();
            flocOperationalMode.Id = floc.Id;

            var expectedAID = ActionItemDefinitionFixture.CreateApprovedActionItemDefinition(1);
            expectedAID.OperationalMode = OperationalMode.ShutDown;

            var schedule = new ActionItemDefinitionFLOCShiftAdjustedSchedule(recurringDailySchedule, floc, 1,
                shiftPatternServiceMock);

            operationalModeServiceMock.Expect(mock => mock.GetByFunctionalLocationId(floc.IdValue))
                .Return(flocOperationalMode);
            actionItemDefinitionServiceMock.Expect(mock => mock.QueryById(-1)).IgnoreArguments().Return(expectedAID);

            schedulingService.OnScheduleTrigger(schedule, null);

            actionItemDefinitionServiceMock.VerifyAllExpectations();
            operationalModeServiceMock.VerifyAllExpectations();
        }

        [Test]
        public void ShouldOnlyInsertActionItemForFLOCWithTheSameOperationModeWhenAIDScheduleIsTriggerred()
        {
            timeServiceMock.Stub(mock => mock.GetTime(null)).IgnoreArguments().Return(Clock.Now);

            //
            //  Create Two FLOCs with different Operational Modes
            //
            var normalOpModeFLOC = FunctionalLocationFixture.GetAny_Unit1();
            normalOpModeFLOC.Id = 10;
            var normalOpModeFLOCDto = FunctionalLocationOperationalModeDTOFixture.MakeNormalOpModeDto();

            var constraintedOpModeFLOC = FunctionalLocationFixture.GetAny_Equip1();
            constraintedOpModeFLOC.Id = 20;
            var constraintedOpModeFLOCDto = FunctionalLocationOperationalModeDTOFixture.MakeConstrainedOpModeDto();
            constraintedOpModeFLOCDto.Id = constraintedOpModeFLOC.Id;

            //
            // Associate the Two FLOCs to ActionItemDefinition to be triggered.
            //
            var aidToBeTriggered = ActionItemDefinitionFixture.CreateApprovedActionItemDefinition(1);
            aidToBeTriggered.FunctionalLocations.Clear();
            aidToBeTriggered.FunctionalLocations.Add(normalOpModeFLOC);
            aidToBeTriggered.FunctionalLocations.Add(constraintedOpModeFLOC);

            //
            //  Set AID OpMode to be normal so that only one ActionItem will be triggered.
            //
            aidToBeTriggered.OperationalMode = OperationalMode.Normal;

            actionItemDefinitionServiceMock.Expect(mock => mock.QueryById(-1))
                .IgnoreArguments()
                .Return(aidToBeTriggered);

            //
            //  Expectation for generating ActionItem with Normal OpMode Functional Location
            //
            operationalModeServiceMock.Expect(mock => mock.GetByFunctionalLocationId(normalOpModeFLOC.IdValue))
                .Return(normalOpModeFLOCDto);

            var correspondingShift = ShiftPatternFixture.CreateDayShift();
            shiftPatternServiceMock.Expect(mock => mock.GetShiftBySiteAndDateTimeFavourEarlierShift(null, DateTime.Now))
                .IgnoreArguments()
                .Return(correspondingShift);

            actionItemServiceMock.Expect(
                mock => mock.Insert(Arg<ActionItem>.Matches(ai => ai.FunctionalLocations.Contains(normalOpModeFLOC))))
                .Return(null);


            //
            // Expectation for the constrainted OpMode FunctionLocation.  
            //
            operationalModeServiceMock.Expect(mock => mock.GetByFunctionalLocationId(constraintedOpModeFLOCDto.IdValue))
                .Return(constraintedOpModeFLOCDto);


            //
            // Note, It does not matter which FLOC is used to create Shift Adjusted AID Schedule because
            // aidToBeTriggered.FunctionalLocations belong to a shift.
            //
            ISchedule recurringDailySchedule =
                RecurringDailyScheduleFixture.CreateEvery2DaysFrom10AM12To07PM11BetweenJan10AndOct21In2000();
            var adjustedSchedule = new ActionItemDefinitionFLOCShiftAdjustedSchedule(recurringDailySchedule,
                normalOpModeFLOC, 1, shiftPatternServiceMock);

            scheduleServiceMock.Expect(mock => mock.Update(adjustedSchedule.InternalSchedule));

            schedulingService.OnScheduleTrigger(adjustedSchedule, null);

            scheduleServiceMock.VerifyAllExpectations();
            operationalModeServiceMock.VerifyAllExpectations();
            actionItemServiceMock.VerifyAllExpectations();
            actionItemDefinitionServiceMock.VerifyAllExpectations();
        }

        [Test]
        public void ShouldRaiseActionItemUpdatedEventsForAllSchedulesWithFLOCsAssociatedWithTheModifiedUnit()
        {
            var unit = FunctionalLocationFixture.GetAny_Unit1();
            unit.Id = 10;
            var otherUnit = FunctionalLocationFixture.CreateNew(unit.Site,
                unit.FunctionalLocationHierarchy.ReplaceSegment(1, "DIFF_DIVISION").ToString());
            otherUnit.Id = 20;

            var actionItemDefinition = CreateApprovedActionItemDefinition(66, unit);
            actionItemDefinition.Schedule.Id = 123;

            var schedules = new List<TimeZoneConvertedSchedule>
            {
                CreateTimeZoneConvertedScheduleAssociatedWith(unit, actionItemDefinition.IdValue),
                CreateTimeZoneConvertedScheduleAssociatedWith(otherUnit, 67)
            };

            nonBatchingSchedulerMock.Expect(m => m.Schedules).Return(schedules);
            actionItemDefinitionServiceMock.Expect(m => m.QueryById(actionItemDefinition.IdValue))
                .Return(actionItemDefinition);

            nonBatchingSchedulerMock.Expect(mock => mock.RemoveSchedule(actionItemDefinition.Schedule));
            nonBatchingSchedulerMock.Expect(mock => mock.AddSchedule(null)).IgnoreArguments();

            schedulingService.UnitOperationalModeChanged(unit);

            nonBatchingSchedulerMock.VerifyAllExpectations();
            actionItemDefinitionServiceMock.VerifyAllExpectations();
        }

        [Test]
        public void ShouldReturnAdjustedEndDateTimeOFJan03_2000_6pmWhereEndTime2pmAndTheShiftEnds8pm()
        {
            Clock.Freeze();
            Clock.Now = new DateTime(2000, 1, 3, 8, 0, 0);
            var dayShift = ShiftPatternFixture.CreateDayShift();
            var expectedadjustedEndTime = new DateTime(2000, 1, 3, 18, 0, 0);
            var floc = FunctionalLocationFixture.GetAny_Division();
            ISchedule recurringWeeklySchedule =
                RecurringWeeklyScheduleFixture.CreateEveryMondayAndFridayFrom8AMTO2PMBetweenJan1AndOct10In2000();
            var adjustedSchedule =
                new ActionItemDefinitionFLOCShiftAdjustedSchedule(recurringWeeklySchedule, floc, 1,
                    shiftPatternServiceMock);

            functionalLocationServiceMock.Expect(mock => mock.QueryById(-1)).IgnoreArguments().Return(floc);
            var twoPM = Clock.Now.ToDate().CreateDateTime(new Time(14, 0, 0));
            shiftPatternServiceMock.Expect(mock => mock.GetShiftBySiteAndDateTimeFavourEarlierShift(floc.Site, twoPM))
                .Return(dayShift);
            var instanceEndTime =
                schedulingService.GetShiftAdjustedDateTimeToShiftEndTime(adjustedSchedule, Clock.Now);
            Assert.AreEqual(expectedadjustedEndTime, instanceEndTime);
            Clock.UnFreeze();
        }

        [Test]
        public void ShouldReturnAdjustedEndDateTimeOFJan04_2000_6amWhereEndTime10pmAndTheShiftEnds8am()
        {
            Clock.Freeze();
            Clock.Now = new DateTime(2000, 1, 3, 20, 0, 0);
            var nightShift = ShiftPatternFixture.CreateNightShift();
            var expectedadjustedEndTime = new DateTime(2000, 1, 4, 6, 0, 0);
            var floc = FunctionalLocationFixture.GetAny_Division();
            ISchedule recurringWeeklySchedule =
                RecurringWeeklyScheduleFixture.CreateEveryOtherMondayAndFridayFrom10PMTO11PMBetweenJan1AndOct10In2000();
            var adjustedSchedule =
                new ActionItemDefinitionFLOCShiftAdjustedSchedule(recurringWeeklySchedule, floc, 1,
                    shiftPatternServiceMock);

            var elevenPM = Clock.Now.ToDate().CreateDateTime(new Time(23, 0, 0));
            shiftPatternServiceMock.Expect(mock => mock.GetShiftBySiteAndDateTimeFavourEarlierShift(floc.Site, elevenPM))
                .Return(nightShift);
            var instanceEndTime =
                schedulingService.GetShiftAdjustedDateTimeToShiftEndTime(adjustedSchedule, Clock.Now);
            Assert.AreEqual(expectedadjustedEndTime, instanceEndTime);
            Clock.UnFreeze();
        }

        [Test]
        public void TriggerOnActionItemDefinitionShouldInsertActionItemWithSamePriorityAsDefinition()
        {
            var actionItemDefinition = ActionItemDefinitionFixture.CreateActionItemDefinition();
            actionItemDefinition.Schedule =
                new ActionItemDefinitionFLOCShiftAdjustedSchedule(actionItemDefinition.Schedule,
                    actionItemDefinition.FunctionalLocations[0], -99, shiftPatternServiceMock);
            actionItemDefinition.Priority = Priority.Elevated;

            actionItemServiceMock.Expect(
                m => m.Insert(Arg<ActionItem>.Matches(ai => ai.Priority.Equals(Priority.Elevated))))
                .Return(ActionItemFixture.Create());

            functionalLocationServiceMock.Stub(m => m.QueryById(-1))
                .IgnoreArguments()
                .Return(FunctionalLocationFixture.GetAny_Equip1());
            timeServiceMock.Stub(m => m.GetTime(null)).IgnoreArguments().Return(Clock.Now);
            operationalModeServiceMock.Stub(m => m.GetByFunctionalLocationId(-1))
                .IgnoreArguments()
                .Return(FunctionalLocationOperationalModeDTOFixture.MakeNormalOpModeDto());
            actionItemDefinitionServiceMock.Stub(m => m.QueryById(-1)).IgnoreArguments().Return(actionItemDefinition);
            shiftPatternServiceMock.Stub(m => m.GetShiftBySiteAndDateTimeFavourEarlierShift(null, DateTime.Now))
                .IgnoreArguments()
                .Return(ShiftPatternFixture.CreateDayShift());

            schedulingService.OnScheduleTrigger(actionItemDefinition.Schedule, null);

            actionItemServiceMock.VerifyAllExpectations();
        }

        private static ActionItemDefinition CreateApprovedActionItemDefinition(int actionItemDefinitionId,
            FunctionalLocation floc)
        {
            var actionItemDefinition =
                ActionItemDefinitionFixture.CreateApprovedProcessActionItemDefinitionForMcMurrayWithActionItemId(
                    actionItemDefinitionId);
            actionItemDefinition.Active = true;
            actionItemDefinition.FunctionalLocations.Add(floc);
            return actionItemDefinition;
        }

        private TimeZoneConvertedSchedule CreateTimeZoneConvertedScheduleAssociatedWith(FunctionalLocation unit,
            long actionItemDefinitionId)
        {
            var actionItemSchedule =
                new ActionItemDefinitionFLOCShiftAdjustedSchedule(null, unit, actionItemDefinitionId,
                    shiftPatternServiceMock);
            return new TimeZoneConvertedSchedule(actionItemSchedule, TimeZoneFixture.GetMountainTimeZone());
        }
    }
}