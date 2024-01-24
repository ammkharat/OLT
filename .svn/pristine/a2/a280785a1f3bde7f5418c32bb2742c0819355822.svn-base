using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.ShiftHandover;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Reports.Adapters;
using NUnit.Framework;
using Rhino.Mocks;

namespace Com.Suncor.Olt.Client.Presenters.Reporting
{
    [TestFixture]
    public class ShiftHandoverQuestionnaireReportAdapterBuilderTest
    {
        [Test]
        public void ShouldAttemptToGetFutureActionItemsIfSiteConfigurationSaysToIncludeThem()
        {
            Clock.Freeze();
            Clock.Now = new DateTime(2011, 11, 16, 11, 0, 0);

            var functionalLocations = new List<FunctionalLocation> {FunctionalLocationFixture.GetReal_MT1_A003_U120()};
            var workAssignment = WorkAssignmentFixture.CreateUnitLeader(functionalLocations);
            workAssignment.UseWorkAssignmentForActionItemHandoverDisplay = true;
            var montreal = SiteFixture.Montreal();
            var questionnaire = ShiftHandoverQuestionnaireFixture.Create(workAssignment,
                UserFixture.CreateUser(montreal), ShiftPatternFixture.Create8HourDayShift(), Clock.Now.AddMinutes(-10),
                functionalLocations);
            questionnaire.Id = 1;

            var mockShiftHandoverService = MockRepository.GenerateStub<IShiftHandoverService>();
            var mockActionItemDefService =
                MockRepository.GenerateStub<IActionItemDefinitionService>();
            var mockShiftPatternService = MockRepository.GenerateStub<IShiftPatternService>();
            var mockActionItemService = MockRepository.GenerateStrictMock<IActionItemService>();
            var mockFunctionalLocationOperationalModeService =
                MockRepository.GenerateStub<IFunctionalLocationOperationalModeService>();
            var mockLubesCsdService = MockRepository.GenerateStub<IFormEdmontonService>();
            var mockExcursionResponseService = MockRepository.GenerateStub<IExcursionResponseService>();

            var questionnaireAssocations = new ShiftHandoverQuestionnaireAssocations(new List<HasCommentsDTO>(0),
                new List<HasCommentsDTO>(0),
                new CokerCardInfoForShiftHandoverDTO(
                    new List<CokerCardDrumEntryDTO>()));
            mockShiftHandoverService.Stub(x => x.QueryAssocationedItems(questionnaire.IdValue,
                DateTime.Now.ToDate(), -1, -1, null,ClientSession.GetUserContext().Site.Id.Value)).IgnoreArguments().Return(questionnaireAssocations);

            var siteConfiguration = SiteConfigurationFixture.CreateDefaultSiteConfiguration(montreal);

            ClientSession.GetUserContext().SetSite(montreal, siteConfiguration);

            mockShiftPatternService.Stub(x => x.QueryBySite(null))
                .IgnoreArguments()
                .Return(new List<ShiftPattern> {ShiftPatternFixture.Create8HourNightShift()});

            // expect a call to get future action items if they are suppose to be shown on the handover
            mockActionItemDefService.Expect(
                x => x.QueryActiveDtosByWorkAssignmentAndParentFunctionalLocations(null, null, Clock.Now, null))
                .IgnoreArguments()
                .Return(new List<ActionItemDefinition>(0));

            var builder = new ShiftHandoverQuestionnaireReportAdapterBuilder(mockShiftHandoverService,
                mockActionItemDefService,
                mockShiftPatternService,
                mockActionItemService,
                mockFunctionalLocationOperationalModeService,
                siteConfiguration,
                mockLubesCsdService,
                null, mockExcursionResponseService);

            var adapters = builder.GetShiftHandoverQuestionnaireReportAdapters(questionnaire, siteConfiguration,
                montreal);

            mockActionItemDefService.VerifyAllExpectations();
        }

        [Test]
        public void ShouldNotAttemptToGetFutureActionItemsIfSiteConfigurationSaysNotToIncludeThem()
        {
            Clock.Freeze();
            Clock.Now = new DateTime(2011, 11, 16, 11, 0, 0);
            var questionnaire = ShiftHandoverQuestionnaireFixture.Create(
                WorkAssignmentFixture.CreateConsoleOperator(9), UserFixture.CreateUser(SiteFixture.Montreal()),
                ShiftPatternFixture.Create8HourDayShift(), Clock.Now.AddMinutes(-10),
                new List<FunctionalLocation> {FunctionalLocationFixture.GetReal_MT1_A003_U120()});
            questionnaire.Id = 1;

            var mockActionItemDefService =
                MockRepository.GenerateStub<IActionItemDefinitionService>();
            var mockShiftPatternService = MockRepository.GenerateStub<IShiftPatternService>();
            var mockShiftHandoverService = MockRepository.GenerateStub<IShiftHandoverService>();
            var mockActionItemService2 = MockRepository.GenerateStrictMock<IActionItemService>();
            var mockFunctionalLocationOperationalModeService =
                MockRepository.GenerateStub<IFunctionalLocationOperationalModeService>();
            var mockExcursionResponseService = MockRepository.GenerateStub<IExcursionResponseService>();

            var mockLubesCsdService = MockRepository.GenerateStub<IFormEdmontonService>();

            var questionnaireAssocations = new ShiftHandoverQuestionnaireAssocations(new List<HasCommentsDTO>(0),
                new List<HasCommentsDTO>(0),
                new CokerCardInfoForShiftHandoverDTO(
                    new List<CokerCardDrumEntryDTO>()));
            mockShiftHandoverService.Stub(x => x.QueryAssocationedItems(questionnaire.IdValue,
                DateTime.Now.ToDate(), -1, -1, null,ClientSession.GetUserContext().Site.Id.Value)).IgnoreArguments().Return(questionnaireAssocations);

            var siteConfiguration = SiteConfigurationFixture.CreateDoNotShowActionItemsOnHandover(SiteFixture.Montreal());

            var site = SiteFixture.Montreal();

            ClientSession.GetUserContext().SetSite(site, siteConfiguration);

            var builder = new ShiftHandoverQuestionnaireReportAdapterBuilder(mockShiftHandoverService,
                mockActionItemDefService,
                mockShiftPatternService,
                mockActionItemService2,
                mockFunctionalLocationOperationalModeService,
                siteConfiguration,
                mockLubesCsdService,
                null, mockExcursionResponseService);

            var adapters = builder.GetShiftHandoverQuestionnaireReportAdapters(questionnaire, siteConfiguration, site);

            mockActionItemDefService.AssertWasNotCalled(
                x => x.QueryActiveDtosByWorkAssignmentAndParentFunctionalLocations(null, null, Clock.Now, null),
                y => y.IgnoreArguments());
        }
    }
}