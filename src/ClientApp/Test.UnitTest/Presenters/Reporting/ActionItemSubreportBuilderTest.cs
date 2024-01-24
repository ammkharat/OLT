using System;
using System.Globalization;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Schedule;
using Com.Suncor.Olt.Common.Domain.ShiftHandover;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Reports.Adapters;
using NMock2;
using NUnit.Framework;
using System.Collections.Generic;
using Expect = NMock2.Expect;

namespace Com.Suncor.Olt.Client.Presenters.Reporting
{
    [TestFixture]
    public class ActionItemSubreportBuilderTest
    {
        private IActionItemDefinitionService mockActionItemDefinitionService;
        private IActionItemService mockActionItemService;
        private IFunctionalLocationOperationalModeService mockOperationalModeService;        
        private Mockery mocks;

        private SiteConfiguration siteConfiguration;

        [SetUp]
        public void SetUp()
        {
            Clock.Freeze();
            Clock.TimeZone = TimeZoneFixture.GetMountainTimeZone();
            mocks = new Mockery();

            mockActionItemDefinitionService = mocks.NewMock<IActionItemDefinitionService>();
            mockActionItemService = mocks.NewMock<IActionItemService>();
            mockOperationalModeService = mocks.NewMock<IFunctionalLocationOperationalModeService>();

            siteConfiguration = SiteConfigurationFixture.CreateDefaultSiteConfiguration(SiteFixture.Oilsands());

            WorkAssignment assignment = WorkAssignmentFixture.CreateConsoleOperator();
            assignment.UseWorkAssignmentForActionItemHandoverDisplay = true;
            ClientSession.GetUserContext().Assignment = assignment;
        }

        [TearDown]
        public void TearDown()
        {
            Clock.UnFreeze();
        }

        [Test]
        public void ShouldPredictFutureActionItemsIfCurrentTimeIsBeforeStartTimeOfNextShift()
        {
            UserShift nextShift = UserShiftFixture.CreateUserShift(new Time(8), new Time(20), new DateTime(2010, 12, 15));
            Clock.Now = new DateTime(2010, 12, 15, 7, 0, 0);

            var actionItemSubreportBuilder =
                new ActionItemSubreportBuilder(
                    mockActionItemDefinitionService,
                    mockActionItemService,
                    mockOperationalModeService,
                    siteConfiguration);

            ActionItemDefinition actionItemDefinition = ActionItemDefinitionFixture.CreateActionItemDefinition();
            actionItemDefinition.Schedule =
                RecurringDailyScheduleFixture.CreateRecurringDailySchedule(new Date(2010, 12, 15),
                                                                           new Date(2010, 12, 16), 
                                                                           new Time(10),
                                                                           new Time(12));

            Expect.Once.On(mockActionItemDefinitionService).Method("QueryActiveDtosByWorkAssignmentAndParentFunctionalLocations").Will(Return.Value(new List<ActionItemDefinition> { actionItemDefinition }));
            Stub.On(mockOperationalModeService).Method("GetByFunctionalLocationId").Will(Return.Value(FunctionalLocationOperationalModeDTOFixture.MakeNormalOpModeDto()));

            ShiftHandoverQuestionnaire questionnaire = ShiftHandoverQuestionnaireFixture.Create();
            questionnaire.Id = 1;

            List<ActionItemReportAdapter> reportAdapters = actionItemSubreportBuilder.GetActionItemReportAdapters(questionnaire, nextShift);
            Assert.AreEqual(1, reportAdapters.Count);
            Assert.AreEqual(questionnaire.IdValue.ToString(CultureInfo.InvariantCulture), reportAdapters[0].ParentId);
            Assert.AreEqual(actionItemDefinition.Name, reportAdapters[0].ActionItemName);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test][Ignore]
        public void ShouldGrabExistingActionItemsIfCurrentTimeIsDuringNextShift()
        {            
            UserShift nextShift = UserShiftFixture.CreateUserShift(new Time(8), new Time(20), new DateTime(2010, 12, 15));
            Clock.Now = new DateTime(2010, 12, 15, 9, 0, 0);

            var actionItemSubreportBuilder =
                new ActionItemSubreportBuilder(
                    mockActionItemDefinitionService,
                    mockActionItemService,
                    mockOperationalModeService,
                    siteConfiguration);

            ActionItemDTO actionItemDto = ActionItemDTOFixture.CreateActionItemDto();
            Expect.Once.On(mockActionItemService).Method("QueryDTOsByParentFunctionalLocationsAndWorkAssignmentAndDateRange").Will(Return.Value(new List<ActionItemDTO> { actionItemDto }));

            ShiftHandoverQuestionnaire questionnaire = ShiftHandoverQuestionnaireFixture.Create();
            questionnaire.Id = 1;

            List<ActionItemReportAdapter> reportAdapters = actionItemSubreportBuilder.GetActionItemReportAdapters(questionnaire, nextShift);
            Assert.AreEqual(1, reportAdapters.Count);
            Assert.AreEqual(questionnaire.IdValue.ToString(CultureInfo.InvariantCulture), reportAdapters[0].ParentId);
            Assert.AreEqual(actionItemDto.Name, reportAdapters[0].ActionItemName);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldOnlyShowActionItemsWithFLOCsThatMatchHandoverFloc_ActionItemDefinitionCreatesOneActionItemPerFloc()
        {
            // This test is a result of bug #769 - Before the fix, if a handover matched ONE of the flocs in a definition, the builder would generate
            // an action item for ALL of the flocs in the definition.

            ActionItemDefinition actionItemDefinition = ActionItemDefinitionFixture.CreateActionItemDefinition();
            actionItemDefinition.CreateAnActionItemForEachFunctionalLocation = true;
            actionItemDefinition.FunctionalLocations.Clear();
            actionItemDefinition.FunctionalLocations.Add(FunctionalLocationFixture.GetAny_Unit1(1));
            actionItemDefinition.FunctionalLocations.Add(FunctionalLocationFixture.GetAny_Unit2(2));

            ShiftHandoverQuestionnaire questionnaire = ShiftHandoverQuestionnaireFixture.Create();
            questionnaire.FunctionalLocations.Clear();
            questionnaire.FunctionalLocations.Add(FunctionalLocationFixture.GetAny_Unit1(1));

            List<string> expectedFlocs = new List<string>{FunctionalLocationFixture.GetAny_Unit1(1).FullHierarchyWithDescription};
            AssertFlocMatch(actionItemDefinition, questionnaire, expectedFlocs);
        }

        [Test]
        public void ShouldOnlyShowActionItemsWithFLOCsThatMatchHandoverParentFloc_ActionItemDefinitionCreatesOneActionItemPerFloc()
        {
            ActionItemDefinition actionItemDefinition = ActionItemDefinitionFixture.CreateActionItemDefinition();
            actionItemDefinition.CreateAnActionItemForEachFunctionalLocation = true;
            actionItemDefinition.FunctionalLocations.Clear();
            actionItemDefinition.FunctionalLocations.Add(FunctionalLocationFixture.CreateNew(1, "A-B-C1"));
            actionItemDefinition.FunctionalLocations.Add(FunctionalLocationFixture.CreateNew(2, "Z-B-C2"));

            ShiftHandoverQuestionnaire questionnaire = ShiftHandoverQuestionnaireFixture.Create();
            questionnaire.FunctionalLocations.Clear();
            questionnaire.FunctionalLocations.Add(FunctionalLocationFixture.CreateNew(3, "A-B"));

            List<string> expectedFlocs = new List<string> { FunctionalLocationFixture.CreateNew(1, "A-B-C1").FullHierarchyWithDescription };
            AssertFlocMatch(actionItemDefinition, questionnaire, expectedFlocs);
        }

        [Test]
        public void ShouldShowActionItemWithAllFlocs_ActionItemDefinitionCreatesOneActionItemForAllFlocs()
        {
            ActionItemDefinition actionItemDefinition = ActionItemDefinitionFixture.CreateActionItemDefinition();
            actionItemDefinition.CreateAnActionItemForEachFunctionalLocation = false;
            actionItemDefinition.FunctionalLocations.Clear();
            actionItemDefinition.FunctionalLocations.Add(FunctionalLocationFixture.CreateNew(1, "A-B-C1"));
            actionItemDefinition.FunctionalLocations.Add(FunctionalLocationFixture.CreateNew(2, "Z-B-C2"));

            ShiftHandoverQuestionnaire questionnaire = ShiftHandoverQuestionnaireFixture.Create();
            questionnaire.FunctionalLocations.Clear();
            questionnaire.FunctionalLocations.Add(FunctionalLocationFixture.CreateNew(3, "A-B"));

            List<string> expectedFlocs = new List<string>
                { FunctionalLocationFixture.CreateNew(1, "A-B-C1").FullHierarchyWithDescription + ", " + FunctionalLocationFixture.CreateNew(1, "Z-B-C2").FullHierarchyWithDescription
                                             };
            AssertFlocMatch(actionItemDefinition, questionnaire, expectedFlocs);
        }

        private void AssertFlocMatch(ActionItemDefinition actionItemDefinition, ShiftHandoverQuestionnaire questionnaire, List<string> expectedFlocs)
        {
            UserShift nextShift = UserShiftFixture.CreateUserShift(new Time(8), new Time(20), new DateTime(2010, 12, 15));
            Clock.Now = new DateTime(2010, 12, 15, 7, 0, 0);

            var actionItemSubreportBuilder =
                new ActionItemSubreportBuilder(
                    mockActionItemDefinitionService,
                    mockActionItemService,
                    mockOperationalModeService,
                    siteConfiguration);

            actionItemDefinition.Schedule =
                RecurringDailyScheduleFixture.CreateRecurringDailySchedule(new Date(2010, 12, 15),
                                                                           new Date(2010, 12, 16),
                                                                           new Time(10),
                                                                           new Time(12));

            Expect.Once.On(mockActionItemDefinitionService).Method("QueryActiveDtosByWorkAssignmentAndParentFunctionalLocations").Will(Return.Value(new List<ActionItemDefinition> { actionItemDefinition }));
            Stub.On(mockOperationalModeService).Method("GetByFunctionalLocationId").Will(Return.Value(FunctionalLocationOperationalModeDTOFixture.MakeNormalOpModeDto()));

            questionnaire.Id = 1;

            List<ActionItemReportAdapter> reportAdapters = actionItemSubreportBuilder.GetActionItemReportAdapters(questionnaire, nextShift);
            Assert.AreEqual(expectedFlocs.Count, reportAdapters.Count);
            for (int i = 0; i < expectedFlocs.Count; i++)
            {
                string expectedFloc = expectedFlocs[i];
                Assert.AreEqual(expectedFloc, reportAdapters[i].FunctionalLocations);
            }
            Assert.AreEqual(questionnaire.IdValue.ToString(CultureInfo.InvariantCulture), reportAdapters[0].ParentId);
            Assert.AreEqual(actionItemDefinition.Name, reportAdapters[0].ActionItemName);
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldSortActionItemsByStartDateTime()
        {
            UserShift nextShift = UserShiftFixture.CreateUserShift(new Time(8), new Time(20), new DateTime(2010, 12, 15));
            Clock.Now = new DateTime(2010, 12, 15, 9, 0, 0);

            var actionItemSubreportBuilder =
                new ActionItemSubreportBuilder(
                    mockActionItemDefinitionService,
                    mockActionItemService,
                    mockOperationalModeService,
                    siteConfiguration);

            ActionItemDTO actionItemDtoOne = ActionItemDTOFixture.CreateActionItemDto(new DateTime(2010, 12, 15, 9, 0, 0), new DateTime(2010, 12, 15, 10, 0, 0));
            ActionItemDTO actionItemDtoTwo = ActionItemDTOFixture.CreateActionItemDto(new DateTime(2010, 12, 15, 8, 30, 0), new DateTime(2010, 12, 15, 11, 0, 0));            

            Expect.Once.On(mockActionItemService).Method("QueryDTOsByParentFunctionalLocationsAndWorkAssignmentAndDateRange").Will(Return.Value(new List<ActionItemDTO> { actionItemDtoOne, actionItemDtoTwo }));

            ShiftHandoverQuestionnaire questionnaire = ShiftHandoverQuestionnaireFixture.Create();
            questionnaire.Id = 1;

            List<ActionItemReportAdapter> reportAdapters = actionItemSubreportBuilder.GetActionItemReportAdapters(questionnaire, nextShift);
            Assert.AreEqual(2, reportAdapters.Count);
            Assert.AreEqual(actionItemDtoTwo.StartDateTime, reportAdapters[0].GetRawStartDateTime());
            Assert.AreEqual(actionItemDtoOne.StartDateTime, reportAdapters[1].GetRawStartDateTime());
            mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldOnlyShowActionItemsThatMatchOperationMode_ActionItemDefinitionCreatesOneActionItemPerFloc()
        {
            ActionItemDefinition actionItemDefinition = ActionItemDefinitionFixture.CreateActionItemDefinition();
            actionItemDefinition.OperationalMode = OperationalMode.Constrained;
            actionItemDefinition.CreateAnActionItemForEachFunctionalLocation = true;
            actionItemDefinition.FunctionalLocations.Clear();
            actionItemDefinition.FunctionalLocations.Add(FunctionalLocationFixture.CreateNew(1, "A-B-C1"));
            actionItemDefinition.FunctionalLocations.Add(FunctionalLocationFixture.CreateNew(2, "A-B-C2"));
            actionItemDefinition.FunctionalLocations.Add(FunctionalLocationFixture.CreateNew(3, "A-B-C3"));

            Stub.On(mockOperationalModeService).Method("GetByFunctionalLocationId")
                .With((long)1)
                .Will(Return.Value(FunctionalLocationOperationalModeDTOFixture.MakeNormalOpModeDto()));
            Stub.On(mockOperationalModeService).Method("GetByFunctionalLocationId")
                .With((long)2)
                .Will(Return.Value(FunctionalLocationOperationalModeDTOFixture.MakeConstrainedOpModeDto()));
            Stub.On(mockOperationalModeService).Method("GetByFunctionalLocationId")
                .With((long)3)
                .Will(Return.Value(FunctionalLocationOperationalModeDTOFixture.MakeShutDownOpModeDto()));

            List<string> expectedFlocs = new List<string> { FunctionalLocationFixture.CreateNew(2, "A-B-C2").FullHierarchyWithDescription };
            AssertOperationalModeMatch(actionItemDefinition, expectedFlocs);
        }

        [Test]
        public void ShouldShowActionItemsIfAtLeastOneMatchesOperationMode_ActionItemDefinitionCreatesOneActionItemForAllFlocs()
        {
            ActionItemDefinition actionItemDefinition = ActionItemDefinitionFixture.CreateActionItemDefinition();
            actionItemDefinition.OperationalMode = OperationalMode.Constrained;
            actionItemDefinition.CreateAnActionItemForEachFunctionalLocation = false;
            actionItemDefinition.FunctionalLocations.Clear();
            actionItemDefinition.FunctionalLocations.Add(FunctionalLocationFixture.CreateNew(1, "A-B-C1"));
            actionItemDefinition.FunctionalLocations.Add(FunctionalLocationFixture.CreateNew(2, "A-B-C2"));
            actionItemDefinition.FunctionalLocations.Add(FunctionalLocationFixture.CreateNew(3, "A-B-C3"));

            Stub.On(mockOperationalModeService).Method("GetByFunctionalLocationId")
                .With((long)1)
                .Will(Return.Value(FunctionalLocationOperationalModeDTOFixture.MakeNormalOpModeDto()));
            Stub.On(mockOperationalModeService).Method("GetByFunctionalLocationId")
                .With((long)2)
                .Will(Return.Value(FunctionalLocationOperationalModeDTOFixture.MakeConstrainedOpModeDto()));
            Stub.On(mockOperationalModeService).Method("GetByFunctionalLocationId")
                .With((long)3)
                .Will(Return.Value(FunctionalLocationOperationalModeDTOFixture.MakeShutDownOpModeDto()));

            List<string> expectedFlocs = new List<string>
            {
                FunctionalLocationFixture.CreateNew(1, "A-B-C1").FullHierarchyWithDescription + ", " +
                FunctionalLocationFixture.CreateNew(2, "A-B-C2").FullHierarchyWithDescription + ", " +
                FunctionalLocationFixture.CreateNew(3, "A-B-C3").FullHierarchyWithDescription
            };
            AssertOperationalModeMatch(actionItemDefinition, expectedFlocs);
        }

        [Test]
        public void ShouldNotShowActionItemsIfNoneMatchOperationMode_ActionItemDefinitionCreatesOneActionItemForAllFlocs()
        {
            ActionItemDefinition actionItemDefinition = ActionItemDefinitionFixture.CreateActionItemDefinition();
            actionItemDefinition.OperationalMode = OperationalMode.Constrained;
            actionItemDefinition.CreateAnActionItemForEachFunctionalLocation = false;
            actionItemDefinition.FunctionalLocations.Clear();
            actionItemDefinition.FunctionalLocations.Add(FunctionalLocationFixture.CreateNew(1, "A-B-C1"));
            actionItemDefinition.FunctionalLocations.Add(FunctionalLocationFixture.CreateNew(2, "A-B-C2"));
            actionItemDefinition.FunctionalLocations.Add(FunctionalLocationFixture.CreateNew(3, "A-B-C3"));

            Stub.On(mockOperationalModeService).Method("GetByFunctionalLocationId")
                .With((long)1)
                .Will(Return.Value(FunctionalLocationOperationalModeDTOFixture.MakeNormalOpModeDto()));
            Stub.On(mockOperationalModeService).Method("GetByFunctionalLocationId")
                .With((long)2)
                .Will(Return.Value(FunctionalLocationOperationalModeDTOFixture.MakeNormalOpModeDto()));
            Stub.On(mockOperationalModeService).Method("GetByFunctionalLocationId")
                .With((long)3)
                .Will(Return.Value(FunctionalLocationOperationalModeDTOFixture.MakeNormalOpModeDto()));

            List<string> expectedFlocs = new List<string>();
            AssertOperationalModeMatch(actionItemDefinition, expectedFlocs);
        }

        private void AssertOperationalModeMatch(ActionItemDefinition actionItemDefinition, List<string> expectedFlocs)
        {
            UserShift nextShift = UserShiftFixture.CreateUserShift(new Time(8), new Time(20), new DateTime(2010, 12, 15));
            Clock.Now = new DateTime(2010, 12, 15, 7, 0, 0);

            var actionItemSubreportBuilder =
                new ActionItemSubreportBuilder(
                    mockActionItemDefinitionService,
                    mockActionItemService,
                    mockOperationalModeService,
                    siteConfiguration);

            actionItemDefinition.Schedule =
                RecurringDailyScheduleFixture.CreateRecurringDailySchedule(new Date(2010, 12, 15),
                                                                           new Date(2010, 12, 16),
                                                                           new Time(10),
                                                                           new Time(12));

            Expect.Once.On(mockActionItemDefinitionService).Method("QueryActiveDtosByWorkAssignmentAndParentFunctionalLocations").Will(Return.Value(new List<ActionItemDefinition> { actionItemDefinition }));

            ShiftHandoverQuestionnaire questionnaire = ShiftHandoverQuestionnaireFixture.Create();
            questionnaire.FunctionalLocations.Clear();
            foreach (FunctionalLocation floc in actionItemDefinition.FunctionalLocations)
            {
                questionnaire.FunctionalLocations.Add(floc);
            }
            questionnaire.Id = 1;

            List<ActionItemReportAdapter> reportAdapters = actionItemSubreportBuilder.GetActionItemReportAdapters(questionnaire, nextShift);
            Assert.AreEqual(expectedFlocs.Count, reportAdapters.Count);
            for (int i = 0; i < expectedFlocs.Count; i++)
            {
                string expectedFloc = expectedFlocs[i];
                Assert.AreEqual(expectedFloc, reportAdapters[i].FunctionalLocations);
            }
            foreach (ActionItemReportAdapter reportAdapter in reportAdapters)
            {
                Assert.AreEqual(questionnaire.IdValue.ToString(CultureInfo.InvariantCulture), reportAdapter.ParentId);
                Assert.AreEqual(actionItemDefinition.Name, reportAdapter.ActionItemName);
            }
            mocks.VerifyAllExpectationsHaveBeenMet();
        }


        [Test]
        public void ShouldShowActionItemsForSingleSchedule()
        {
            Clock.TimeZone = TimeZoneFixture.GetMountainTimeZone();
            Site site = SiteFixture.Oilsands();

            List<ISchedule> schedules = new List<ISchedule>
                {
                    new SingleSchedule(0, new Date(2011, 2, 8), new Time(06, 0), new Time(18, 0), null, site),
                    new SingleSchedule(0, new Date(2011, 2, 8), new Time(18, 0), new Time(06, 0), null, site),
                    new SingleSchedule(0, new Date(2011, 2, 9), new Time(06, 0), new Time(18, 0), null, site),
                    new SingleSchedule(0, new Date(2011, 2, 9), new Time(18, 0), new Time(06, 0), null, site),
                    new SingleSchedule(0, new Date(2011, 2, 9), new Time(11, 0), new Time(12, 0), null, site),
                    new SingleSchedule(0, new Date(2011, 2, 9), new Time(11, 0), new Time(20, 0), null, site),
                    new SingleSchedule(0, new Date(2011, 2, 9), new Time(20, 0), new Time(21, 0), null, site),
                    new SingleSchedule(0, new Date(2011, 2, 9), new Time(20, 0), new Time(01, 0), null, site),
                    new SingleSchedule(0, new Date(2011, 2, 9), new Time(20, 0), new Time(11, 0), null, site),
                    new SingleSchedule(0, new Date(2011, 2, 10), new Time(06, 0), new Time(18, 0), null, site),
                    new SingleSchedule(0, new Date(2011, 2, 10), new Time(18, 0), new Time(06, 0), null, site)
                };

            RunTestsForSingleOrContinuousSchedule(schedules);
        }

        [Test]
        public void ShouldShowActionItemsForContinuousSchedule_EndDateIsNull()
        {
            Clock.TimeZone = TimeZoneFixture.GetMountainTimeZone();
            Site site = SiteFixture.Oilsands();

            List<ISchedule> schedules = new List<ISchedule>
                {
                    new ContinuousSchedule(0, new Date(2011, 2, 8), null, new Time(06, 0), new Time(18, 0), null, site),
                    new ContinuousSchedule(0, new Date(2011, 2, 8), null, new Time(18, 0), new Time(06, 0), null, site),
                    new ContinuousSchedule(0, new Date(2011, 2, 9), null, new Time(06, 0), new Time(18, 0), null, site),
                    new ContinuousSchedule(0, new Date(2011, 2, 9), null, new Time(18, 0), new Time(06, 0), null, site),
                    new ContinuousSchedule(0, new Date(2011, 2, 9), null, new Time(11, 0), new Time(12, 0), null, site),
                    new ContinuousSchedule(0, new Date(2011, 2, 9), null, new Time(11, 0), new Time(20, 0), null, site),
                    new ContinuousSchedule(0, new Date(2011, 2, 9), null, new Time(20, 0), new Time(21, 0), null, site),
                    new ContinuousSchedule(0, new Date(2011, 2, 9), null, new Time(20, 0), new Time(01, 0), null, site),
                    new ContinuousSchedule(0, new Date(2011, 2, 9), null, new Time(20, 0), new Time(11, 0), null, site),
                    new ContinuousSchedule(0, new Date(2011, 2, 10), null, new Time(06, 0), new Time(18, 0), null, site),
                    new ContinuousSchedule(0, new Date(2011, 2, 10), null, new Time(18, 0), new Time(06, 0), null, site)
                };

            RunTestsForSingleOrContinuousSchedule(schedules);
        }

        [Test]
        public void ShouldShowActionItemsForContinuousSchedule_EndDateIsNotNull()
        {
            Clock.TimeZone = TimeZoneFixture.GetMountainTimeZone();
            Site site = SiteFixture.Oilsands();

            List<ISchedule> schedules = new List<ISchedule>
                {
                    new ContinuousSchedule(0, new Date(2011, 2, 8), new Date(2011, 2, 11), new Time(06, 0), new Time(18, 0), null, site),
                    new ContinuousSchedule(0, new Date(2011, 2, 8), new Date(2011, 2, 11), new Time(18, 0), new Time(06, 0), null, site),
                    new ContinuousSchedule(0, new Date(2011, 2, 9), new Date(2011, 2, 11), new Time(06, 0), new Time(18, 0), null, site),
                    new ContinuousSchedule(0, new Date(2011, 2, 9), new Date(2011, 2, 11), new Time(18, 0), new Time(06, 0), null, site),
                    new ContinuousSchedule(0, new Date(2011, 2, 9), new Date(2011, 2, 11), new Time(11, 0), new Time(12, 0), null, site),
                    new ContinuousSchedule(0, new Date(2011, 2, 9), new Date(2011, 2, 11), new Time(11, 0), new Time(20, 0), null, site),
                    new ContinuousSchedule(0, new Date(2011, 2, 9), new Date(2011, 2, 11), new Time(20, 0), new Time(21, 0), null, site),
                    new ContinuousSchedule(0, new Date(2011, 2, 9), new Date(2011, 2, 11), new Time(20, 0), new Time(01, 0), null, site),
                    new ContinuousSchedule(0, new Date(2011, 2, 9), new Date(2011, 2, 11), new Time(20, 0), new Time(11, 0), null, site),
                    new ContinuousSchedule(0, new Date(2011, 2, 10), new Date(2011, 2, 11), new Time(06, 0), new Time(18, 0), null, site),
                    new ContinuousSchedule(0, new Date(2011, 2, 10), new Date(2011, 2, 11), new Time(18, 0), new Time(06, 0), null, site)
                };

            RunTestsForSingleOrContinuousSchedule(schedules);
            {
                Clock.Now = new DateTime(2011, 2, 10, 06, 0, 0);
                AssertShowActionItemForSchedule(schedules, GetNextShiftAsNightShift(Clock.Now),
                    new List<bool> { false, false, false, false, 
                                     false, false, false, false, false,
                                     false, true});
            }
            {
                Clock.Now = new DateTime(2011, 2, 10, 18, 0, 0);
                AssertShowActionItemForSchedule(schedules, GetNextShiftAsDayShiftPlusOneDay(Clock.Now),
                    new List<bool> { false, false, false, false, 
                                     false, false, false, false, false,
                                     false, false});
            }
            {
                DateTime date = new DateTime(2011, 02, 11);
                while (date <= new DateTime(2011, 02, 14))
                {
                    {
                        Clock.Now = new DateTime(date.Year, date.Month, date.Day, 06, 0, 0);
                        AssertShowActionItemForSchedule(schedules, GetNextShiftAsNightShift(Clock.Now),
                            new List<bool> { false, false, false, false, 
                                     false, false, false, false, false,
                                     false, false});
                    }
                    {
                        Clock.Now = new DateTime(date.Year, date.Month, date.Day, 18, 0, 0);
                        AssertShowActionItemForSchedule(schedules, GetNextShiftAsDayShiftPlusOneDay(Clock.Now),
                            new List<bool> { false, false, false, false, 
                                     false, false, false, false, false,
                                     false, false});
                    }
                    date = date.AddDays(1);
                }
            }
        }

        private void RunTestsForSingleOrContinuousSchedule(List<ISchedule> schedules)
        {
            {
                Clock.Now = new DateTime(2011, 2, 7, 5, 0, 0);
                AssertShowActionItemForSchedule(schedules, GetNextShiftAsDayShiftSameDay(Clock.Now),
                    new List<bool> { false, false, false, false, 
                                     false, false, false, false, false,
                                     false, false});
            }
            {
                Clock.Now = new DateTime(2011, 2, 7, 6, 0, 0);
                AssertShowActionItemForSchedule(schedules, GetNextShiftAsNightShift(Clock.Now),
                    new List<bool> { false, false, false, false, 
                                     false, false, false, false, false,
                                     false, false});
            }
            {
                Clock.Now = new DateTime(2011, 2, 7, 17, 0, 0);
                AssertShowActionItemForSchedule(schedules, GetNextShiftAsNightShift(Clock.Now),
                    new List<bool> { false, false, false, false, 
                                     false, false, false, false, false,
                                     false, false});
            }
            {
                Clock.Now = new DateTime(2011, 2, 7, 18, 0, 0);
                AssertShowActionItemForSchedule(schedules, GetNextShiftAsDayShiftPlusOneDay(Clock.Now),
                    new List<bool> { true, false, false, false, 
                                     false, false, false, false, false,
                                     false, false});
            }
            {
                Clock.Now = new DateTime(2011, 2, 7, 22, 0, 0);
                AssertShowActionItemForSchedule(schedules, GetNextShiftAsDayShiftPlusOneDay(Clock.Now),
                    new List<bool> { true, false, false, false, 
                                     false, false, false, false, false,
                                     false, false});
            }
            {
                Clock.Now = new DateTime(2011, 2, 8, 06, 0, 0);
                AssertShowActionItemForSchedule(schedules, GetNextShiftAsNightShift(Clock.Now),
                    new List<bool> { false, true, false, false, 
                                     false, false, false, false, false,
                                     false, false});
            }
            {
                Clock.Now = new DateTime(2011, 2, 8, 18, 0, 0);
                AssertShowActionItemForSchedule(schedules, GetNextShiftAsDayShiftPlusOneDay(Clock.Now),
                    new List<bool> { false, false, true, false, 
                                     true, true, false, false, false,
                                     false, false});
            }
            {
                Clock.Now = new DateTime(2011, 2, 8, 22, 0, 0);
                AssertShowActionItemForSchedule(schedules, GetNextShiftAsDayShiftPlusOneDay(Clock.Now),
                    new List<bool> { false, false, true, false, 
                                     true, true, false, false, false,
                                     false, false});
            }
            {
                Clock.Now = new DateTime(2011, 2, 9, 06, 0, 0);
                AssertShowActionItemForSchedule(schedules, GetNextShiftAsNightShift(Clock.Now),
                    new List<bool> { false, false, false, true, 
                                     false, false, true, true, true,
                                     false, false});
            }
            {
                Clock.Now = new DateTime(2011, 2, 9, 11, 0, 0);
                AssertShowActionItemForSchedule(schedules, GetNextShiftAsNightShift(Clock.Now),
                    new List<bool> { false, false, false, true, 
                                     false, false, true, true, true,
                                     false, false});
            }
            {
                Clock.Now = new DateTime(2011, 2, 9, 17, 0, 0);
                AssertShowActionItemForSchedule(schedules, GetNextShiftAsNightShift(Clock.Now),
                    new List<bool> { false, false, false, true, 
                                     false, false, true, true, true,
                                     false, false});
            }
            {
                Clock.Now = new DateTime(2011, 2, 9, 18, 0, 0);
                AssertShowActionItemForSchedule(schedules, GetNextShiftAsDayShiftPlusOneDay(Clock.Now),
                    new List<bool> { false, false, false, false, 
                                     false, false, false, false, false,
                                     true, false});
            }
            {
                Clock.Now = new DateTime(2011, 2, 9, 20, 0, 0);
                AssertShowActionItemForSchedule(schedules, GetNextShiftAsDayShiftPlusOneDay(Clock.Now),
                    new List<bool> { false, false, false, false, 
                                     false, false, false, false, false,
                                     true, false});
            }
        }


        [Test]
        public void ShouldShowActionItemsForDailySchedule_LastInvokedDateTimeIsNull()
        {
            List<ISchedule> schedules = new List<ISchedule>
                {
                    RecurringDailyScheduleFixture.CreateRecurringDailySchedule(
                        new Date(2011, 2, 1), null, new Time(11), new Time(13), 1, null),
                    RecurringDailyScheduleFixture.CreateRecurringDailySchedule(
                        new Date(2011, 2, 1), null, new Time(23), new Time(1), 1, null)
                };

            // -------------------
            // before the schedule's start date
            // -------------------
            {
                Clock.Now = new DateTime(2011, 1, 15, 10, 0, 0);
                AssertShowActionItemForSchedule(schedules, GetNextShiftAsNightShift(Clock.Now),
                    new List<bool> { false, false });
            }
            {
                Clock.Now = new DateTime(2011, 01, 15, 22, 0, 0);
                AssertShowActionItemForSchedule(schedules, GetNextShiftAsDayShiftPlusOneDay(Clock.Now),
                    new List<bool> { false, false });
            }

            // -------------------
            // around the schedule's start date
            // -------------------
            {
                Clock.Now = new DateTime(2011, 1, 31, 18, 0, 0);
                AssertShowActionItemForSchedule(schedules, GetNextShiftAsNightShift(Clock.Now),
                    new List<bool> { false, false });
            }
            {
                Clock.Now = new DateTime(2011, 1, 31, 18, 0, 0);
                AssertShowActionItemForSchedule(schedules, GetNextShiftAsDayShiftPlusOneDay(Clock.Now),
                    new List<bool> { true, false });
            }
            {
                Clock.Now = new DateTime(2011, 1, 31, 22, 0, 0);
                AssertShowActionItemForSchedule(schedules, GetNextShiftAsDayShiftPlusOneDay(Clock.Now),
                    new List<bool> { true, false });
            }
            {
                Clock.Now = new DateTime(2011, 2, 01, 06, 0, 0); // no longer future, will query action items directly
                AssertShowActionItemForSchedule(schedules, GetNextShiftAsDayShiftSameDay(Clock.Now),
                    new List<bool> { false, false });
            }
            {
                Clock.Now = new DateTime(2011, 2, 01, 06, 0, 0);
                AssertShowActionItemForSchedule(schedules, GetNextShiftAsNightShift(Clock.Now),
                    new List<bool> { false, true });
            }
            {
                Clock.Now = new DateTime(2011, 2, 01, 10, 0, 0);
                AssertShowActionItemForSchedule(schedules, GetNextShiftAsNightShift(Clock.Now),
                    new List<bool> { false, true });
            }
            {
                Clock.Now = new DateTime(2011, 2, 01, 18, 0, 0); // no longer future, will query action items directly
                AssertShowActionItemForSchedule(schedules, GetNextShiftAsNightShift(Clock.Now),
                    new List<bool> { false, false });
            }
            {
                Clock.Now = new DateTime(2011, 02, 01, 18, 0, 0);
                AssertShowActionItemForSchedule(schedules, GetNextShiftAsDayShiftPlusOneDay(Clock.Now),
                    new List<bool> { true, false });
            }
            {
                Clock.Now = new DateTime(2011, 02, 01, 22, 0, 0);
                AssertShowActionItemForSchedule(schedules, GetNextShiftAsDayShiftPlusOneDay(Clock.Now),
                    new List<bool> { true, false });
            }

            // -------------------
            // some time after the schedule's start date
            // -------------------
            {
                Clock.Now = new DateTime(2011, 02, 15, 06, 0, 0); // no longer future, will query action items directly
                AssertShowActionItemForSchedule(schedules, GetNextShiftAsDayShiftSameDay(Clock.Now),
                    new List<bool> { false, false });
            }
            {
                Clock.Now = new DateTime(2011, 02, 15, 06, 0, 0);
                AssertShowActionItemForSchedule(schedules, GetNextShiftAsNightShift(Clock.Now),
                    new List<bool> { false, true });
            }
            {
                Clock.Now = new DateTime(2011, 02, 15, 10, 0, 0);
                AssertShowActionItemForSchedule(schedules, GetNextShiftAsNightShift(Clock.Now),
                    new List<bool> { false, true });
            }
            {
                Clock.Now = new DateTime(2011, 02, 15, 18, 0, 0); // no longer future, will query action items directly
                AssertShowActionItemForSchedule(schedules, GetNextShiftAsNightShift(Clock.Now),
                    new List<bool> { false, false });
            }
            {
                Clock.Now = new DateTime(2011, 02, 15, 18, 0, 0);
                AssertShowActionItemForSchedule(schedules, GetNextShiftAsDayShiftPlusOneDay(Clock.Now),
                    new List<bool> { true, false });
            }
            {
                Clock.Now = new DateTime(2011, 02, 15, 22, 0, 0);
                AssertShowActionItemForSchedule(schedules, GetNextShiftAsDayShiftPlusOneDay(Clock.Now),
                    new List<bool> { true, false });
            }
        }

        [Test]
        public void ShouldShowActionItemsForDailySchedule_LastInvokedDateTimeIsNotNull()
        {
            List<ISchedule> schedules = new List<ISchedule>
                {
                    RecurringDailyScheduleFixture.CreateRecurringDailySchedule(
                        new Date(2011, 2, 1), null, new Time(11), new Time(13), 1, new DateTime(2011, 2, 10, 6, 0, 0)),
                    RecurringDailyScheduleFixture.CreateRecurringDailySchedule(
                        new Date(2011, 2, 1), null, new Time(23), new Time(1), 1, new DateTime(2011, 2, 10, 18, 0, 0))
                };

            {
                Clock.Now = new DateTime(2011, 02, 10, 18, 00, 00);
                AssertShowActionItemForSchedule(schedules, GetNextShiftAsDayShiftPlusOneDay(Clock.Now),
                    new List<bool> {true, false});
            }
            {
                Clock.Now = new DateTime(2011, 02, 10, 18, 00, 01);
                AssertShowActionItemForSchedule(schedules, GetNextShiftAsDayShiftPlusOneDay(Clock.Now),
                    new List<bool> { true, false });
            }
            {
                Clock.Now = new DateTime(2011, 02, 11, 05, 59, 59);
                AssertShowActionItemForSchedule(schedules, GetNextShiftAsDayShiftSameDay(Clock.Now),
                    new List<bool> { true, false });
            }
            {
                Clock.Now = new DateTime(2011, 02, 11, 06, 00, 00);
                AssertShowActionItemForSchedule(schedules, GetNextShiftAsNightShift(Clock.Now),
                    new List<bool> { false, true });
            }
            {
                Clock.Now = new DateTime(2011, 02, 11, 06, 00, 01);
                AssertShowActionItemForSchedule(schedules, GetNextShiftAsNightShift(Clock.Now),
                    new List<bool> { false, true });
            }
            {
                Clock.Now = new DateTime(2011, 02, 11, 17, 59, 59);
                AssertShowActionItemForSchedule(schedules, GetNextShiftAsNightShift(Clock.Now),
                    new List<bool> { false, true });
            }
            {
                Clock.Now = new DateTime(2011, 02, 11, 18, 00, 00);
                AssertShowActionItemForSchedule(schedules, GetNextShiftAsDayShiftPlusOneDay(Clock.Now),
                    new List<bool> { true, false });
            }
            {
                Clock.Now = new DateTime(2011, 02, 11, 18, 00, 01);
                AssertShowActionItemForSchedule(schedules, GetNextShiftAsDayShiftPlusOneDay(Clock.Now),
                    new List<bool> { true, false });
            }
            {
                Clock.Now = new DateTime(2011, 02, 12, 05, 59, 59);
                AssertShowActionItemForSchedule(schedules, GetNextShiftAsDayShiftSameDay(Clock.Now),
                    new List<bool> { true, false });
            }
            {
                Clock.Now = new DateTime(2011, 02, 12, 06, 00, 00);
                AssertShowActionItemForSchedule(schedules, GetNextShiftAsNightShift(Clock.Now),
                    new List<bool> { false, true });
            }
            {
                Clock.Now = new DateTime(2011, 02, 12, 06, 00, 01);
                AssertShowActionItemForSchedule(schedules, GetNextShiftAsNightShift(Clock.Now),
                    new List<bool> { false, true });
            }
            {
                Clock.Now = new DateTime(2011, 02, 12, 17, 59, 59);
                AssertShowActionItemForSchedule(schedules, GetNextShiftAsNightShift(Clock.Now),
                    new List<bool> { false, true });
            }
            {
                Clock.Now = new DateTime(2011, 02, 12, 18, 00, 00);
                AssertShowActionItemForSchedule(schedules, GetNextShiftAsDayShiftPlusOneDay(Clock.Now),
                    new List<bool> { true, false });
            }
            {
                Clock.Now = new DateTime(2011, 02, 12, 18, 00, 01);
                AssertShowActionItemForSchedule(schedules, GetNextShiftAsDayShiftPlusOneDay(Clock.Now),
                    new List<bool> { true, false });
            }
        }

        [Test]
        public void ShouldShowActionItemsForDailySchedule_EndDateIsNotNull()
        {
            List<ISchedule> schedules = new List<ISchedule>
                {
                    RecurringDailyScheduleFixture.CreateRecurringDailySchedule(
                        new Date(2011, 2, 1), new Date(2011, 2, 15), new Time(11), new Time(13), 1, null),
                    RecurringDailyScheduleFixture.CreateRecurringDailySchedule(
                        new Date(2011, 2, 1), new Date(2011, 2, 15), new Time(23), new Time(1), 1, null),
                    RecurringDailyScheduleFixture.CreateRecurringDailySchedule(
                        new Date(2011, 2, 1), new Date(2011, 2, 15), new Time(11), new Time(13), 1, new DateTime(2011, 2, 10, 6, 0, 0)),
                    RecurringDailyScheduleFixture.CreateRecurringDailySchedule(
                        new Date(2011, 2, 1), new Date(2011, 2, 15), new Time(23), new Time(1), 1, new DateTime(2011, 2, 10, 18, 0, 0))
                };

            {
                Clock.Now = new DateTime(2011, 02, 10, 18, 00, 00);
                AssertShowActionItemForSchedule(schedules, GetNextShiftAsDayShiftPlusOneDay(Clock.Now),
                    new List<bool> { true, false, true, false });
            }
            {
                Clock.Now = new DateTime(2011, 02, 10, 18, 00, 01);
                AssertShowActionItemForSchedule(schedules, GetNextShiftAsDayShiftPlusOneDay(Clock.Now),
                    new List<bool> { true, false, true, false });
            }

            {
                DateTime date = new DateTime(2011, 02, 11);
                while (date <= new DateTime(2011, 02, 14))
                {
                    {
                        Clock.Now = new DateTime(date.Year, date.Month, date.Day, 05, 59, 59);
                        AssertShowActionItemForSchedule(schedules, GetNextShiftAsDayShiftSameDay(Clock.Now),
                            new List<bool> { true, false, true, false });
                    }
                    {
                        Clock.Now = new DateTime(date.Year, date.Month, date.Day, 06, 00, 00);
                        AssertShowActionItemForSchedule(schedules, GetNextShiftAsNightShift(Clock.Now),
                            new List<bool> { false, true, false, true });
                    }
                    {
                        Clock.Now = new DateTime(date.Year, date.Month, date.Day, 06, 00, 01);
                        AssertShowActionItemForSchedule(schedules, GetNextShiftAsNightShift(Clock.Now),
                            new List<bool> { false, true, false, true });
                    }
                    {
                        Clock.Now = new DateTime(date.Year, date.Month, date.Day, 17, 59, 59);
                        AssertShowActionItemForSchedule(schedules, GetNextShiftAsNightShift(Clock.Now),
                            new List<bool> { false, true, false, true });
                    }
                    {
                        Clock.Now = new DateTime(date.Year, date.Month, date.Day, 18, 00, 00);
                        AssertShowActionItemForSchedule(schedules, GetNextShiftAsDayShiftPlusOneDay(Clock.Now),
                            new List<bool> { true, false, true, false });
                    }
                    {
                        Clock.Now = new DateTime(date.Year, date.Month, date.Day, 18, 00, 01);
                        AssertShowActionItemForSchedule(schedules, GetNextShiftAsDayShiftPlusOneDay(Clock.Now),
                            new List<bool> { true, false, true, false });
                    }
                    date = date.AddDays(1);
                }
            }
            {
                Clock.Now = new DateTime(2011, 02, 15, 05, 59, 59);
                AssertShowActionItemForSchedule(schedules, GetNextShiftAsDayShiftSameDay(Clock.Now),
                    new List<bool> { true, false, true, false });
            }
            {
                Clock.Now = new DateTime(2011, 02, 15, 06, 00, 00);
                AssertShowActionItemForSchedule(schedules, GetNextShiftAsNightShift(Clock.Now),
                    new List<bool> { false, true, false, true });
            }
            {
                Clock.Now = new DateTime(2011, 02, 15, 06, 00, 01);
                AssertShowActionItemForSchedule(schedules, GetNextShiftAsNightShift(Clock.Now),
                    new List<bool> { false, true, false, true });
            }
            {
                Clock.Now = new DateTime(2011, 02, 15, 17, 59, 59);
                AssertShowActionItemForSchedule(schedules, GetNextShiftAsNightShift(Clock.Now),
                    new List<bool> { false, true, false, true });
            }
            {
                Clock.Now = new DateTime(2011, 02, 15, 18, 00, 00);
                AssertShowActionItemForSchedule(schedules, GetNextShiftAsDayShiftPlusOneDay(Clock.Now),
                    new List<bool> { false, false, false, false });
            }
            {
                Clock.Now = new DateTime(2011, 02, 15, 18, 00, 01);
                AssertShowActionItemForSchedule(schedules, GetNextShiftAsDayShiftPlusOneDay(Clock.Now),
                    new List<bool> { false, false, false, false });
            }
            {
                DateTime date = new DateTime(2011, 02, 16);
                while (date <= new DateTime(2011, 02, 20))
                {
                    {
                        Clock.Now = new DateTime(date.Year, date.Month, date.Day, 05, 59, 59);
                        AssertShowActionItemForSchedule(schedules, GetNextShiftAsDayShiftSameDay(Clock.Now),
                            new List<bool> { false, false, false, false });
                    }
                    {
                        Clock.Now = new DateTime(date.Year, date.Month, date.Day, 06, 00, 00);
                        AssertShowActionItemForSchedule(schedules, GetNextShiftAsNightShift(Clock.Now),
                            new List<bool> { false, false, false, false });
                    }
                    {
                        Clock.Now = new DateTime(date.Year, date.Month, date.Day, 06, 00, 01);
                        AssertShowActionItemForSchedule(schedules, GetNextShiftAsNightShift(Clock.Now),
                            new List<bool> { false, false, false, false });
                    }
                    {
                        Clock.Now = new DateTime(date.Year, date.Month, date.Day, 17, 59, 59);
                        AssertShowActionItemForSchedule(schedules, GetNextShiftAsNightShift(Clock.Now),
                            new List<bool> { false, false, false, false });
                    }
                    {
                        Clock.Now = new DateTime(date.Year, date.Month, date.Day, 18, 00, 00);
                        AssertShowActionItemForSchedule(schedules, GetNextShiftAsDayShiftPlusOneDay(Clock.Now),
                            new List<bool> { false, false, false, false });
                    }
                    {
                        Clock.Now = new DateTime(date.Year, date.Month, date.Day, 18, 00, 01);
                        AssertShowActionItemForSchedule(schedules, GetNextShiftAsDayShiftPlusOneDay(Clock.Now),
                            new List<bool> { false, false, false, false });
                    }
                    date = date.AddDays(1);
                }
            }
            
        }

        private static UserShift GetNextShiftAsDayShiftSameDay(DateTime now)
        {
            return UserShiftFixture.CreateUserShift(ShiftPatternFixture.CreateDayShift(), new DateTime(now.Year, now.Month, now.Day));
        }

        private static UserShift GetNextShiftAsDayShiftPlusOneDay(DateTime now)
        {
            return UserShiftFixture.CreateUserShift(ShiftPatternFixture.CreateDayShift(), new DateTime(now.Year, now.Month, now.Day).AddDays(1));
        }

        private static UserShift GetNextShiftAsNightShift(DateTime now)
        {
            return UserShiftFixture.CreateUserShift(ShiftPatternFixture.CreateNightShift(), new DateTime(now.Year, now.Month, now.Day));
        }

        private void AssertShowActionItemForSchedule(
            List<ISchedule> schedules, 
            UserShift nextShift, 
            List<bool> expectShowActionItems
            )
        {
            List<ActionItemDefinition> definitions = new List<ActionItemDefinition>();
            for (int i = 0; i < schedules.Count; i++)
            {
                ISchedule schedule = schedules[i];
                ActionItemDefinition actionItemDefinition = ActionItemDefinitionFixture.CreateActionItemDefinition();
                actionItemDefinition.Id = i;
                actionItemDefinition.Name = "ActionItem" + i;
                actionItemDefinition.FunctionalLocations.Clear();
                actionItemDefinition.FunctionalLocations.Add(FunctionalLocationFixture.GetAny_Unit1(1));
                actionItemDefinition.OperationalMode = OperationalMode.Normal;
                actionItemDefinition.Schedule = schedule;
                definitions.Add(actionItemDefinition);
            }

            ShiftHandoverQuestionnaire questionnaire = ShiftHandoverQuestionnaireFixture.Create();
            questionnaire.FunctionalLocations.Clear();
            questionnaire.FunctionalLocations.Add(FunctionalLocationFixture.GetAny_Unit1(1));
            questionnaire.Id = 1;

            mocks = new Mockery();
            mockActionItemDefinitionService = mocks.NewMock<IActionItemDefinitionService>();
            mockOperationalModeService = mocks.NewMock<IFunctionalLocationOperationalModeService>();
            mockActionItemService = mocks.NewMock<IActionItemService>();
            Stub.On(mockActionItemDefinitionService)
                .Method("QueryActiveDtosByWorkAssignmentAndParentFunctionalLocations")
                .Will(Return.Value(definitions));
            Stub.On(mockOperationalModeService)
                .Method("GetByFunctionalLocationId")
                .Will(Return.Value(FunctionalLocationOperationalModeDTOFixture.MakeNormalOpModeDto()));
            Stub.On(mockActionItemService)
                .Method("QueryDTOsByParentFunctionalLocationsAndWorkAssignmentAndDateRange")
                .Will(Return.Value(new List<ActionItemDTO>()));

            ActionItemSubreportBuilder actionItemSubreportBuilder =
                new ActionItemSubreportBuilder(
                    mockActionItemDefinitionService,
                    mockActionItemService,
                    mockOperationalModeService,
                    siteConfiguration);

            List<ActionItemReportAdapter> reportAdapters = actionItemSubreportBuilder.GetActionItemReportAdapters(questionnaire, nextShift);
            for (int i = 0; i < expectShowActionItems.Count; i++)
            {
                bool expectShowActionItem = expectShowActionItems[i];
                string expectedActionItemName = "ActionItem" + i;
                Assert.AreEqual(expectShowActionItem, reportAdapters.Exists(obj => obj.ActionItemName == expectedActionItemName), expectedActionItemName);
            }

            mocks.VerifyAllExpectationsHaveBeenMet();
        }

    }
}