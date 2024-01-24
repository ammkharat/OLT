using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Services;
using NUnit.Framework;
using Rhino.Mocks;

namespace Com.Suncor.Olt.Client.Presenters
{
    [TestFixture]
    public class ConfigureDisplayLimitsFormPresenterTest
    {
        private IRoleElementService mockRoleElementService;
        private ISiteConfigurationService mockService;
        private ISiteConfigurationFormView mockView;
        private ConfigureDisplayLimitsFormPresenter presenter;

        [SetUp]
        public void SetUp()
        {
            ClientSession.GetUserContext().User = UserFixture.CreateUser(SiteFixture.Sarnia());

            mockView = MockRepository.GenerateMock<ISiteConfigurationFormView>();
            mockService = MockRepository.GenerateMock<ISiteConfigurationService>();
            mockRoleElementService = MockRepository.GenerateMock<IRoleElementService>();

            presenter = new ConfigureDisplayLimitsFormPresenter(mockView, mockService, mockRoleElementService);
        }

        [Test]
        public void ShouldLoadUpTheConfigurationData()
        {
            var site = ClientSession.GetUserContext().Site;
            var siteConfiguration = SiteConfigurationFixture.CreateDefaultSiteConfiguration(site);
            mockView.SiteName = site.Name;
            mockService.Expect(m => m.QueryBySiteIdWithNoCaching(site.IdValue)).Return(siteConfiguration);
            mockRoleElementService.Expect(
                m => m.IsSiteUsingRoleElement(Arg<Site>.Is.Anything, Arg<List<RoleElement>>.Is.Anything))
                .Return(BuildTheStupidDictionaryThatThisTestNeeds());

            presenter.LoadForm(null, EventArgs.Empty);
            mockView.VerifyAllExpectations();
            mockService.VerifyAllExpectations();
        }

        [Test]
        public void ShouldSaveAndCloseOnSave()
        {
            var site = ClientSession.GetUserContext().Site;
            const int newDaysForActionItems = 24;
            const int newDaysForShiftLogs = 37;
            const int newDaysForShiftHandovers = 43;
            const int newDaysForDeviationAlerts = 90;
            const int newDaysForWorkPermitsBackwards = 67;
            const int newDaysForLabAlerts = 45;
            const int newDaysForCokerCards = 89;
            const int newDaysForPermitRequestsBackwards = 89;
            const int newDaysForPermitRequestsForwards = 89;
            const int newDaysForElectronicFormsBackwards = 42;
            const int newDaysForElectronicFormsForwards = 12;
            const int newDaysForSAPNotificationsBackwards = 13;
            const int newDaysForDirectivesBackwards = 14;
            const int newDaysForDirectivesForwards = 15;
            const int newDaysForEvents = 16;
            const int newDaysForDocumentSuggestionFormsBackwards = 31;
            const int newDaysForDocumentSuggestionFormsForwards = 17;

            mockView.Stub(m => m.DaysToDisplayActionItems).Return(newDaysForActionItems.ToString());
            mockView.Stub(m => m.DaysToDisplayShiftLogs).Return(newDaysForShiftLogs.ToString());
            mockView.Stub(m => m.DaysToDisplayShiftHandovers).Return(newDaysForShiftHandovers.ToString());

            mockView.Stub(m => m.DaysToDisplayDeviationAlerts).Return(newDaysForDeviationAlerts.ToString());
            mockView.Stub(m => m.DaysToDisplayWorkPermitsBackwards).Return(newDaysForWorkPermitsBackwards.ToString());
            mockView.Stub(m => m.DaysToDisplayWorkPermitsForwards).Return(null);
            mockView.Stub(m => m.DaysToDisplayLabAlerts).Return(newDaysForLabAlerts.ToString());
            mockView.Stub(m => m.DaysToDisplayCokerCards).Return(newDaysForCokerCards.ToString());
            mockView.Stub(m => m.DaysToDisplayPermitRequestsBackwards)
                .Return(newDaysForPermitRequestsBackwards.ToString());
            mockView.Stub(m => m.DaysToDisplayPermitRequestsForwards)
                .Return(newDaysForPermitRequestsForwards.ToString());
            mockView.Stub(m => m.DaysToDisplayElectronicFormsBackwards)
                .Return(newDaysForElectronicFormsBackwards.ToString());
            mockView.Stub(m => m.DaysToDisplayElectronicFormsForwards)
                .Return(newDaysForElectronicFormsForwards.ToString());
            mockView.Stub(m => m.DaysToDisplaySAPNotificationsBackwards)
                .Return(newDaysForSAPNotificationsBackwards.ToString());
            mockView.Stub(m => m.DaysToDisplayDirectivesBackwards).Return(newDaysForDirectivesBackwards.ToString());
            mockView.Stub(m => m.DaysToDisplayDirectivesForwards).Return(newDaysForDirectivesForwards.ToString());
            mockView.Stub(m => m.DaysToDisplayEvents).Return(newDaysForEvents.ToString());
            mockView.Stub(m => m.DaysToDisplayDocumentSuggestionFormsBackwards)
                .Return(newDaysForDocumentSuggestionFormsBackwards.ToString());
            mockView.Stub(m => m.DaysToDisplayDocumentSuggestionFormsForwards)
                .Return(newDaysForDocumentSuggestionFormsForwards.ToString());

            mockService.Expect(m => m.UpdateDisplayLimits(site.IdValue,
                newDaysForActionItems,
                newDaysForShiftLogs,
                newDaysForShiftHandovers,
                newDaysForDeviationAlerts,
                newDaysForWorkPermitsBackwards,
                0,
                newDaysForLabAlerts,
                newDaysForCokerCards,
                newDaysForPermitRequestsBackwards,
                newDaysForPermitRequestsForwards,
                newDaysForElectronicFormsBackwards,
                newDaysForElectronicFormsForwards,
                newDaysForSAPNotificationsBackwards,
                newDaysForDirectivesBackwards,
                newDaysForDirectivesForwards, 
                newDaysForEvents,
                newDaysForDocumentSuggestionFormsBackwards,
                newDaysForDocumentSuggestionFormsForwards));

            mockView.Expect(m => m.CloseForm());

            presenter.HandleSaveButtonClick(null, EventArgs.Empty);
            mockService.VerifyAllExpectations();
            mockView.VerifyAllExpectations();
        }

        private Dictionary<RoleElement, bool> BuildTheStupidDictionaryThatThisTestNeeds()
        {
            var isSiteUsingRoleElement = new Dictionary<RoleElement, bool>();

            var roleElements = new List<RoleElement>
            {
                RoleElement.VIEW_ACTIONITEM,
                RoleElement.VIEW_COKER_CARD,
                RoleElement.VIEW_RESTRICTION_REPORTING,
                RoleElement.VIEW_LAB_ALERT_DEFINITIONS_AND_LAB_ALERTS,
                RoleElement.VIEW_PERMIT,
                RoleElement.VIEW_SHIFT_HANDOVER,
                RoleElement.VIEW_LOG,
                RoleElement.VIEW_LOG_BASED_DIRECTIVES,
                RoleElement.VIEW_SUMMARY_LOG,
                RoleElement.VIEW_FORM,
                RoleElement.VIEW_DIRECTIVE_NAVIGATION,
                RoleElement.VIEW_EVENTS_NAVIGATION,
                RoleElement.VIEW_PRIORITIES_DOCUMENT_SUGGESTION_FORM
            };

            foreach (var roleElement in roleElements)
            {
                isSiteUsingRoleElement.Add(roleElement, true);
            }

            return isSiteUsingRoleElement;
        }
    }
}