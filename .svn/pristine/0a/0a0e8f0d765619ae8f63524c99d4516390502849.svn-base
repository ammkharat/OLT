using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Client.Controls.ToolStrips;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Presenters.Section;
using Com.Suncor.Olt.Client.Security;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Fixtures;
using Com.Suncor.Olt.Common.Utility;
using NUnit.Framework;
using Rhino.Mocks;
namespace Com.Suncor.Olt.Client.Presenters
{
    [TestFixture]
    public class MainFormPresenterSecurityManagerTest
    {
        private UserContext userContext;
        private IMainForm mockView;
        private IMainUserStrip mockStrip;
        private ISectionRegistry mockSectionRegistry;
        private IAuthorized mockAuthorized;

        private MainFormSecurityManager securityManager;

        [SetUp]
        public void SetUp()
        {
            Clock.Freeze();

            mockView = MockRepository.GenerateMock<IMainForm>();
            mockStrip = MockRepository.GenerateMock<IMainUserStrip>();
            mockAuthorized = MockRepository.GenerateMock<IAuthorized>();
            mockSectionRegistry = MockRepository.GenerateStub<ISectionRegistry>();

            List<FunctionalLocation> userSelectedFlocs
                = FunctionalLocationFixture.CreateNewListOfNewItems(6);

            userContext = ClientSession.GetUserContext();

            userContext.SetSelectedFunctionalLocations(userSelectedFlocs, new List<FunctionalLocation>(), new List<FunctionalLocation>());
            User user = UserFixture.CreateUser(SiteFixture.Sarnia());
            user.Id = 1;
            userContext.User = user;
            securityManager = new MainFormSecurityManager(mockView, mockAuthorized);

        }

        [Test]
        public void RefreshSecurityWhenAuthorizedForAnyConfigurationShouldMakeAdministrationMenuVisible()
        {
            Fixtures.UserFixture.CreateOperator(userContext);

            Site site = SiteFixture.SiteWideServices();
            SiteConfiguration siteConfiguration = SiteConfigurationFixture.CreateDefaultSiteConfiguration(site);
            userContext.SetSite(site, siteConfiguration);

            UserRoleElements userRoleElements = userContext.UserRoleElements;

            mockAuthorized.Expect(mock => mock.ToConfigureDisplayLimits(userRoleElements)).IgnoreArguments().Return(true);
            mockAuthorized.Expect(mock => mock.ToConfigureWorkPermitArchivalProcess(userRoleElements)).IgnoreArguments().Return(false);
            mockAuthorized.Expect(mock => mock.ToConfigureAutoApproveSAPActionItemDefinition(userRoleElements)).IgnoreArguments().Return(false);
            mockAuthorized.Expect(mock => mock.ToConfigureWorkPermitContractor(userRoleElements)).IgnoreArguments().Return(false);
            mockAuthorized.Expect(mock => mock.ToConfigurePlantHistorianTagList(userRoleElements)).IgnoreArguments().Return(false);
            mockAuthorized.Expect(mock => mock.ToConfigureCraftOrTrade(userRoleElements)).IgnoreArguments().Return(false);
            mockAuthorized.Expect(mock => mock.ToConfigureWorkAssignments(userRoleElements)).IgnoreArguments().Return(false);
            mockAuthorized.Expect(mock => mock.ToConfigureAutoReApprovalByField(userRoleElements)).IgnoreArguments().Return(false);
            mockAuthorized.Expect(mock => mock.ToConfigurePreApprovedTargetRanges(userRoleElements)).IgnoreArguments().Return(false);
            mockAuthorized.Expect(mock => mock.ToConfigureDefaultFLOCsForAssignments(userRoleElements)).IgnoreArguments().Return(false);
            mockView.Expect(mock => mock.AdminstrationVisible(true));

            mockView.Expect(mock => mock.UserStrip).Return(mockStrip);

            //Execute
            securityManager.GetActionForSelectedSection(userRoleElements, mockSectionRegistry);
        }

        #region OnMainFormLoad - Shift Pattern and Security Tests

        private void OnMainFormLoadShouldPopulateUserStripAndSetupNavigationAndRestrictMenuItems(User user, UserRoleElements userRoleElements, ShiftPattern shiftPattern, SiteConfiguration configuration)
        {
            ClientSession.GetUserContext().User = user;
            ClientSession.GetUserContext().UserShift = UserShiftFixture.CreateUserShift(shiftPattern, Clock.Now);
            ClientSession.GetUserContext().SetRole(RoleFixture.CreateOperatorRole(), userRoleElements, new List<RoleDisplayConfiguration>(), new List<RolePermission>());

            const bool authorizedForActionItems = true;
            const bool authorizedForTargets = true;
            const bool authorizedForPermits = true;
            const bool authorizedForLogs = true;
            const bool authorizedForGasTestLimits = false;
            const bool authorizedForManageOperationalMode = false;
            const bool authorizedForMaintainShiftFlocRelationship = false;
            const bool authorizedForConfigureDisplayLimits = false;
            const bool authorizedForConfiguringWorkPermitArchivalProcess = false;
            const bool authorizedForConfigureAutoApproveSAPActionItemDefinition = false;
            const bool authorizedForConfigureWorkPermitContractor = false;
            const bool authorizedForConfigurePlantHistorianTagList = false;
            const bool authorizedForConfigureCraftOrTrade = false;
            const bool authorizedForConfigureWorkAssignments = false;
            const bool authorizedForConfigureAutoReApprovalByField = false;
            const bool authorizedForConfigureDefaultFLOCsForAssignments = false;
            const bool authorizedForConfigureCommentCategories = false;
            const bool authorizedForConfigureLabAlerts = false;
            const bool authorizedForConfigureLinks = false;
            const bool authorizedConfigureWorkPermitMontrealTemplates = false;

            SetupAuthorizationExpectations
                (
                    userRoleElements,
                    authorizedForActionItems,
                    authorizedForTargets,
                    authorizedForPermits,
                    authorizedForLogs,
                    authorizedForGasTestLimits,
                    authorizedForManageOperationalMode,
                    authorizedForMaintainShiftFlocRelationship,
                    authorizedForManageOperationalMode,
                    authorizedForConfiguringWorkPermitArchivalProcess,
                    authorizedForConfigureAutoApproveSAPActionItemDefinition,
                    authorizedForConfigureWorkPermitContractor,
                    authorizedForConfigurePlantHistorianTagList,
                    authorizedForConfigureCraftOrTrade,
                    authorizedForConfigureWorkAssignments,
                    authorizedForConfigureAutoReApprovalByField,
                    authorizedForConfigureDefaultFLOCsForAssignments,
                    authorizedForConfigureCommentCategories,
                    authorizedForConfigureLabAlerts,
                    authorizedForConfigureLinks,
                    authorizedConfigureWorkPermitMontrealTemplates);

            SetUserStripExpectations
                (authorizedForActionItems,
                 authorizedForTargets,
                 authorizedForPermits,
                 authorizedForLogs);

            SetupMainMenuExpectations
                (
                    authorizedForActionItems,
                    authorizedForTargets,
                    authorizedForPermits,
                    authorizedForLogs,
                    authorizedForGasTestLimits,
                    configuration.CreateOperatingEngineerLogs,
                    configuration.OperatingEngineerLogDisplayName,
                    authorizedForManageOperationalMode,
                    authorizedForMaintainShiftFlocRelationship,
                    authorizedForConfigureDisplayLimits,
                    authorizedForConfiguringWorkPermitArchivalProcess,
                    authorizedForConfigureAutoApproveSAPActionItemDefinition,
                    authorizedForConfigureWorkPermitContractor,
                    authorizedForConfigurePlantHistorianTagList,
                    authorizedForConfigureCraftOrTrade,
                    authorizedForConfigureWorkAssignments,
                    authorizedForConfigureAutoReApprovalByField,
                    authorizedForConfigureDefaultFLOCsForAssignments);

            // Execute:
            securityManager.ApplySecurityToMenuItems(userRoleElements, configuration);
        }

        [Test]
        public void RefreshSecurityWhenNotAuthorizedForAnyConfigurationShouldMakeAdministrationMenuInvisible()
        {
            Fixtures.UserFixture.CreateOperator(userContext);
//            userContext.UserShift = UserShiftFixture.CreateUserShift();

            Site site = SiteFixture.SiteWideServices();
            SiteConfiguration siteConfiguration = SiteConfigurationFixture.CreateDefaultSiteConfiguration(site);
            userContext.SetSite(site, siteConfiguration);

            UserRoleElements userRoleElements = userContext.UserRoleElements;

            mockAuthorized.Expect(mock => mock.ToConfigureDisplayLimits(userRoleElements)).IgnoreArguments().Return(false);
            mockAuthorized.Expect(mock => mock.ToConfigureWorkPermitArchivalProcess(userRoleElements)).IgnoreArguments().Return(false);
            mockAuthorized.Expect(mock => mock.ToConfigureAutoApproveSAPActionItemDefinition(userRoleElements)).IgnoreArguments().Return(false);
            mockAuthorized.Expect(mock => mock.ToConfigureWorkPermitContractor(userRoleElements)).IgnoreArguments().Return(false);
            mockAuthorized.Expect(mock => mock.ToConfigurePlantHistorianTagList(userRoleElements)).IgnoreArguments().Return(false);
            mockAuthorized.Expect(mock => mock.ToConfigureCraftOrTrade(userRoleElements)).IgnoreArguments().Return(false);
            mockAuthorized.Expect(mock => mock.ToConfigureWorkAssignments(userRoleElements)).IgnoreArguments().Return(false);
            mockAuthorized.Expect(mock => mock.ToConfigureAutoReApprovalByField(userRoleElements)).IgnoreArguments().Return(false);
            mockAuthorized.Expect(mock => mock.ToConfigurePreApprovedTargetRanges(userRoleElements)).IgnoreArguments().Return(false);
            mockAuthorized.Expect(mock => mock.ToConfigureDefaultFLOCsForAssignments(userRoleElements)).IgnoreArguments().Return(false);
            mockView.Expect(mock => mock.AdminstrationVisible(false));

            mockView.Expect(mock => mock.UserStrip).Return(mockStrip);

            //Execute
            securityManager.ApplySecurityToMenuItems(userContext.UserRoleElements, siteConfiguration);
        }


        [Test]
        public void OnMainFormLoadShouldPopulateUserStripAndSetupNavigationAndRestrictMenuItemsBeforeMidnight()
        {
            Clock.Now = new DateTime(2004, 2, 16, 23, 55, 55);
            ShiftPattern shiftPattern = ShiftPatternFixture.CreateNightShift();
            Fixtures.UserFixture.CreateEngineeringSupport(userContext);
            User user = userContext.User;
            UserRoleElements userRoleElements = userContext.UserRoleElements;

            Site site = user.AvailableSites[0];
            SiteConfiguration siteConfiguration = SiteConfigurationFixture.CreateDefaultSiteConfiguration(site);
            userContext.SetSite(site, siteConfiguration);

            OnMainFormLoadShouldPopulateUserStripAndSetupNavigationAndRestrictMenuItems(user, userRoleElements,
                                                                                        shiftPattern,
                                                                                        siteConfiguration);

            mockAuthorized.VerifyAllExpectations();
            
        }

        [Test]
        public void OnMainFormLoadShouldPopulateUserStripAndSetupNavigationAndRestrictMenuItemsStartOfNightShift()
        {
            Clock.Now = new DateTime(2004, 2, 16, 20, 00, 05);
            ShiftPattern shiftPattern = ShiftPatternFixture.CreateNightShift();
            Fixtures.UserFixture.CreateEngineeringSupport(userContext);
            User user = userContext.User;
            UserRoleElements userRoleElements = userContext.UserRoleElements;

            Site site = user.AvailableSites[0];
            SiteConfiguration siteConfiguration = SiteConfigurationFixture.CreateDefaultSiteConfiguration(site);
            userContext.SetSite(site, siteConfiguration);

            OnMainFormLoadShouldPopulateUserStripAndSetupNavigationAndRestrictMenuItems(user, userRoleElements,
                                                                                        shiftPattern,
                                                                                        siteConfiguration);

            mockAuthorized.VerifyAllExpectations();
        }

        [Test]
        public void OnMainFormLoadShouldPopulateUserStripAndSetupNavigationAndRestrictMenuItemsAfterMidnight()
        {
            Clock.Now = new DateTime(2004, 2, 17, 01, 00, 05);
            ShiftPattern shiftPattern = ShiftPatternFixture.CreateNightShift();
            Fixtures.UserFixture.CreateEngineeringSupport(userContext);
            User user = userContext.User;
            UserRoleElements userRoleElements = userContext.UserRoleElements;

            Site site = user.AvailableSites[0];
            SiteConfiguration siteConfiguration = SiteConfigurationFixture.CreateDefaultSiteConfiguration(site);
            userContext.SetSite(site, siteConfiguration);

            OnMainFormLoadShouldPopulateUserStripAndSetupNavigationAndRestrictMenuItems(user, userRoleElements,
                                                                                        shiftPattern,
                                                                                        siteConfiguration);

            mockAuthorized.VerifyAllExpectations();
        }

        [Test]
        public void OnMainFormLoadShouldPopulateUserStripAndSetupNavigationAndRestrictMenuItemsInNightShiftOverlap()
        {
            Clock.Now = new DateTime(2004, 2, 17, 19, 58, 00);
            ShiftPattern shiftPattern = ShiftPatternFixture.CreateNightShift();
            Fixtures.UserFixture.CreateEngineeringSupport(userContext);
            User user = userContext.User;
            UserRoleElements userRoleElements = userContext.UserRoleElements;

            Site site = user.AvailableSites[0];
            SiteConfiguration siteConfiguration = SiteConfigurationFixture.CreateDefaultSiteConfiguration(site);
            userContext.SetSite(site, siteConfiguration);

            OnMainFormLoadShouldPopulateUserStripAndSetupNavigationAndRestrictMenuItems(user, userRoleElements,
                                                                                        shiftPattern,
                                                                                        siteConfiguration);

            mockAuthorized.VerifyAllExpectations();
        }

        [Test]
        public void OnMainFormLoadShouldPopulateUserStripAndSetupNavigationAndRestrictMenuItemsDuringDayShift()
        {
            Clock.Now = new DateTime(2004, 2, 16, 15, 00, 05);
            ShiftPattern shiftPattern = ShiftPatternFixture.CreateDayShift();
            Fixtures.UserFixture.CreateEngineeringSupport(userContext);
            User user = userContext.User;
            UserRoleElements userRoleElements = userContext.UserRoleElements;

            Site site = user.AvailableSites[0];
            SiteConfiguration siteConfiguration = SiteConfigurationFixture.CreateDefaultSiteConfiguration(site);
            userContext.SetSite(site, siteConfiguration);

            OnMainFormLoadShouldPopulateUserStripAndSetupNavigationAndRestrictMenuItems(user, userRoleElements,
                                                                                        shiftPattern,
                                                                                        siteConfiguration);
            mockAuthorized.VerifyAllExpectations();
        }

        [Test]
        public void OnMainFormLoadShouldEnabledOperatingEngineerShiftLogReportMenuItemForSarnia()
        {
            Clock.Now = new DateTime(2004, 2, 16, 15, 00, 05);
            ShiftPattern shiftPattern = ShiftPatternFixture.CreateDayShift();
            Fixtures.UserFixture.CreateEngineeringSupport(userContext);
            Site site = SiteFixture.Sarnia();
            userContext.SetSite(site, SiteConfigurationFixture.CreateDefaultSiteConfiguration(site));
            User user = userContext.User;
            UserRoleElements userRoleElements = userContext.UserRoleElements;
            OnMainFormLoadShouldPopulateUserStripAndSetupNavigationAndRestrictMenuItems(user, userRoleElements,
                                                                                        shiftPattern,
                                                                                        SiteConfigurationFixture.CreateDefaultSiteConfiguration(user.AvailableSites[0]));
            mockAuthorized.VerifyAllExpectations();
        }

        [Test]
        public void OnMainFormLoadShouldNotEnabledOperatingEngineerShiftLogReportMenuItemForDenver()
        {

            Clock.Now = new DateTime(2004, 2, 16, 15, 00, 05);
            ShiftPattern shiftPattern = ShiftPatternFixture.CreateDayShift();
            Fixtures.UserFixture.CreateEngineeringSupport(userContext);
            User user = userContext.User;

            Site site = SiteFixture.Denver();
            SiteConfiguration siteConfiguration = SiteConfigurationFixture.CreateDefaultSiteConfiguration(user.AvailableSites[0]);
            userContext.SetSite(site, siteConfiguration);

            UserRoleElements userRoleElements = userContext.UserRoleElements;

            OnMainFormLoadShouldPopulateUserStripAndSetupNavigationAndRestrictMenuItems(user, userRoleElements,
                                                                                        shiftPattern,
                                                                                        siteConfiguration);
            mockAuthorized.VerifyAllExpectations();
        }
        #endregion OnMainFormLoad - Shift Pattern and Security Tests

        private void SetupAuthorizationExpectations(UserRoleElements userRoleElements, bool authorizedForActionItems,
                                                    bool authorizedForTargets, bool authorizedForPermits,
                                                    bool authorizedForLogs, bool authorizedForConfigureGasTestLimits,
                                                    bool authorizedForManageOpModes,
                                                    bool authorizedForMaintainShiftFlocRelationship,
                                                    bool authorizedForConfigureDisplayLimits,
                                                    bool authorizedForConfiguringWorkPermitArchivalProcess,
                                                    bool authorizedForConfigureAutoApproveSAPActionItemDefinition,
                                                    bool authorizedForConfigureWorkPermitContractor,
                                                    bool authorizedForConfigurePlantHistorianTagList,
                                                    bool authorizedForConfigureCraftOrTrade,
                                                    bool authorizedForConfigWorkAssignments,
                                                    bool authorizedForConfigureAutoReApprovalByField,
                                                    bool authorizedForConfigureDefaultFLOCsForAssignments,
                                                    bool authorizedForConfigureLogGuidelines,
                                                    bool authorizedForConfigureLabAlerts,
                                                    bool authorizedForConfigureLinkRoots,
                                                    bool authorizedForConfigureWorkPermitMontrealTemplates)
        {
            mockAuthorized.Expect(mock => mock.ToCreateActionItemDefinitions(userRoleElements)).Return(authorizedForActionItems).Repeat.Any();

            mockAuthorized.Expect(mock => mock.ToCreateTargets(userRoleElements)).Return(authorizedForTargets).Repeat.Any();
 
            mockAuthorized.Expect(mock => mock.ToCreateRestrictionDefinitions(userRoleElements)).Return(authorizedForTargets).Repeat.Any();
            mockAuthorized.Expect(mock => mock.ToViewRestrictionReporting(userRoleElements)).Return(authorizedForTargets).Repeat.Any();

            mockAuthorized.Expect(mock => mock.ToCreateWorkPermits(userRoleElements)).Return(authorizedForPermits).Repeat.Any();

            mockAuthorized.Expect(mock => mock.ToCreateLogs(userRoleElements)).Return(authorizedForLogs).Repeat.Any();
            mockAuthorized.Expect(mock => mock.ToViewLogs(userRoleElements)).Return(authorizedForLogs).Repeat.Any();

            mockAuthorized.Expect(mock => mock.ToCreateSummaryLogs(userRoleElements)).Return(false).Repeat.Any();
            mockAuthorized.AssertWasNotCalled(mock => mock.ToViewSummaryLogs(userRoleElements));

            mockAuthorized.Expect(mock => mock.ToCreateDirectives(userRoleElements)).Return(false).Repeat.Any();

            mockAuthorized.Expect(mock => mock.ToConfigureGasTestElementLimits(userRoleElements)).Return(authorizedForConfigureGasTestLimits).Repeat.Any();

            mockAuthorized.Expect(mock => mock.ToManageOperationalModes(userRoleElements)).Return(authorizedForManageOpModes).Repeat.Any();

            mockAuthorized.Expect(mock => mock.ToConfigureDisplayLimits(userRoleElements)).Return(authorizedForConfigureDisplayLimits).Repeat.Any();

            mockAuthorized.Expect(mock => mock.ToConfigureWorkPermitArchivalProcess(userRoleElements)).Return(authorizedForConfiguringWorkPermitArchivalProcess).Repeat.Any();

            mockAuthorized.Expect(mock => mock.ToConfigureAutoApproveSAPActionItemDefinition(userRoleElements)).Return(authorizedForConfigureAutoApproveSAPActionItemDefinition).Repeat.Any();

            mockAuthorized.Expect(mock => mock.ToConfigureWorkPermitContractor(userRoleElements)).Return(authorizedForConfigureWorkPermitContractor).Repeat.Any();

            mockAuthorized.Expect(mock => mock.ToConfigurePlantHistorianTagList(userRoleElements)).Return(authorizedForConfigurePlantHistorianTagList).Repeat.Any();

            mockAuthorized.Expect(mock => mock.ToConfigureCraftOrTrade(userRoleElements)).Return(authorizedForConfigureCraftOrTrade).Repeat.Any();

            mockAuthorized.Expect(mock => mock.ToConfigureWorkAssignments(userRoleElements)).Return(authorizedForConfigWorkAssignments).Repeat.Any();

            mockAuthorized.Expect(mock => mock.ToConfigureAutoReApprovalByField(userRoleElements)).Return(authorizedForConfigureAutoReApprovalByField).Repeat.Any();

            mockAuthorized.Expect(mock => mock.ToConfigureDefaultFLOCsForAssignments(userRoleElements)).Return(authorizedForConfigureDefaultFLOCsForAssignments).Repeat.Any();

            mockAuthorized.Expect(mock => mock.ToConfigureLogGuidelines(userRoleElements)).Return(authorizedForConfigureLogGuidelines).Repeat.Any();

            mockAuthorized.Expect(mock => mock.ToConfigureLabAlerts(userRoleElements)).Return(authorizedForConfigureLinkRoots).Repeat.Any();

            mockAuthorized.Expect(mock => mock.ToConfigureWorkPermitMontrealTemplates(userRoleElements)).Return(authorizedForConfigureWorkPermitMontrealTemplates).Repeat.Any();

            mockAuthorized.Expect(mock => mock.ToConfigureLinks(userRoleElements)).Return(authorizedForConfigureLabAlerts).Repeat.Any();

            mockAuthorized.AssertWasNotCalled(mock => mock.ToViewDirectives(userRoleElements));

//            authorized.Stub(mock => mock.ToConfigureRestrictionReasonCode(userRoleElements)).Return(true);
            mockAuthorized.Stub(mock => mock.ToConfigureRestrictionReasonCode(userRoleElements)).Return(true);
            mockAuthorized.Stub(mock => mock.ToConfigureDeviationAlertResponseTimeLimit(userRoleElements)).Return(true);

            mockAuthorized.Stub(mock => mock.ToConfigureBusinessCategories(userRoleElements)).Return(true);
            mockAuthorized.Stub(mock => mock.ToConfigureBusinessCategoryFlocAssociations(userRoleElements)).Return(true);
            mockAuthorized.Stub(mock => mock.ToEditShiftHandoverConfigurations(userRoleElements)).Return(true);

            mockAuthorized.Stub(mock => mock.ToViewShiftHandover(userRoleElements)).Return(true);
            mockAuthorized.Stub(mock => mock.ToCreateShiftHandoverQuestionnaire(userRoleElements)).Return(true);

            mockAuthorized.Stub(mock => mock.ToViewCokerCards(userRoleElements)).Return(true);
            mockAuthorized.Stub(mock => mock.ToCreateCokerCard(userRoleElements)).Return(true);

            mockAuthorized.Stub(mock => mock.ToViewPermitRequests(userRoleElements)).Return(true);
            mockAuthorized.Stub(mock => mock.ToCreatePermitRequest(userRoleElements)).Return(true);

            mockAuthorized.Stub(mock => mock.ToConfigureCustomFields(userRoleElements)).Return(true);
            mockAuthorized.Stub(mock => mock.ToConfigureDORCutoffTime(userRoleElements)).Return(true);
            mockAuthorized.Stub(mock => mock.ToConfigureLogTemplates(userRoleElements)).Return(true);

            mockAuthorized.Stub(mock => mock.ToViewLabAlertDefinitionsAndLabAlerts(userRoleElements)).Return(true);
            mockAuthorized.Stub(mock => mock.ToCreateLabAlertDefinitions(userRoleElements)).Return(true);
            mockAuthorized.Stub(mock => mock.ToConfigureDefaultTabs(userRoleElements)).Return(true);
            mockAuthorized.Stub(mock => mock.ToConfigureWorkAssignmentNotSelectedWarning(userRoleElements)).Return(true);
            mockAuthorized.Stub(mock => mock.ToConfigureDefaultFLOCsForAssignmentsForPermitAutoAssignment(userRoleElements)).Return(false);
            mockAuthorized.Stub(mock => mock.ToEditCokerCardConfigurations(userRoleElements)).Return(false);
            mockAuthorized.Stub(mock => mock.ToConfigurePrioritiesPage(userRoleElements)).Return(false);
        }


        private void SetUserStripExpectations(bool createActionItemEnabled,
                                              bool createTargetEnabled, bool createPermitEnabled, bool createLogEnabled)
        {
            mockView.Expect(mock => mock.UserStrip).Return(mockStrip).Repeat.Any();
//            mockStrip.CreateActionItemEnabled = createActionItemEnabled;
            mockStrip.CreateActionItemVisible = createActionItemEnabled;
            mockStrip.CreateTargetVisible = createTargetEnabled;
            mockStrip.CreateRestrictionVisible = true;
            mockStrip.CreatePermitVisible = createPermitEnabled;

            mockStrip.Expect(mock => mock.CreateLogVisible(createLogEnabled, false, false, true, false, false));

            mockStrip.CreateShiftHandoverQuestionnaireVisible = false; 
            mockStrip.CreateLabAlertVisible = false; 
            mockStrip.CreatePermitRequestVisible = false; 
        }

        private void SetupMainMenuExpectations(bool authorizedForActionItems, bool authorizedForTargets, bool authorizedForPermits, bool authorizedForLogs, bool authorizedForGasTestLimits, bool authorizedForOperatingEngineerShiftLogReport, string opEngDisplayText, bool authorizedForManageOpMode, bool authorizedForMaintainShiftFlocRelationship, bool authorizedForConfigureDisplayLimits, bool authorizedForConfiguringWorkPermitArchivalProcess, bool authorizedForConfigureAutoApproveSAPActionItemDefinition, bool authorizedForConfigureWorkPermitContractor, bool authorizedForConfigurePlantHistorianTagList, bool authorizedForConfigureCraftOrTrade, bool authorizedForConfigureWorkAssignments, bool authorizedForConfigureAutoReApprovalByField, bool authorizedForConfigureDefaultFLOCsForAssignments)
        {
            mockView.CreateActionItemVisible = authorizedForActionItems;
            mockView.CreateTargetVisible = authorizedForTargets;
            mockView.CreateRestrictionVisible = true;
            mockView.CreateWorkPermitVisible = authorizedForPermits;
            mockView.CreateLogVisible = authorizedForLogs;
            mockView.CreateShiftSummaryLogVisible = false;
            mockView.CreateDailyDirectiveLogEntryVisible = false;
            mockView.CreateShiftHandoverQuestionnaireVisible = false; 
            mockView.CreateLabAlertVisible = false; 
            mockView.ConfigureLinkConfigurationEnabled = false; 
            mockView.CreateCokerCardVisible = false; 
            mockView.CreatePermitRequestVisible = false; 

            mockView.OperatingEngineerShiftLogReportVisible = authorizedForOperatingEngineerShiftLogReport;
            mockView.OperatingEngineerShiftLogReportDisplayText = Arg<string>.Matches(Rhino.Mocks.Constraints.Text.Contains(opEngDisplayText));

            mockView.ConfigureGasTestLimitsEnabled = authorizedForGasTestLimits;
            mockView.ConfigureOperationalModeEnabled = authorizedForManageOpMode;
            mockView.ConfigureDisplayLimitsEnabled = authorizedForConfigureDisplayLimits;
            mockView.ConfigureWorkPermitArchivalProcessEnabled = authorizedForConfiguringWorkPermitArchivalProcess;
            mockView.ConfigureAutoApproveSAPAIDEnabled = authorizedForConfigureAutoApproveSAPActionItemDefinition;
            mockView.ConfigureWorkPermitContractorEnabled = authorizedForConfigureWorkPermitContractor;
            mockView.ConfigurePlantHistorianTagListEnabled = authorizedForConfigurePlantHistorianTagList;
            mockView.ConfigureCraftOrTradeEnabled = authorizedForConfigureCraftOrTrade;
            mockView.ConfigureWorkAssignmentsEnabled = authorizedForConfigureWorkAssignments;
            mockView.ConfigureAutoReApprovalByFieldEnabled = authorizedForConfigureAutoReApprovalByField;

            //mockView.ConfigureRoadAccessOnPermitEnabled = authorizedForConfigureCraftOrTrade;
            mockView.ConfigureDefaultFLOCsForDailyAssignmentsEnabled = authorizedForConfigureDefaultFLOCsForAssignments;

            mockView.ConfigureRestrictionReasonCodeEnabled = false; 
            mockView.ConfigureDeviationAlertResponseTimeLimitEnabled = false;
            mockView.RestrictionReportsVisible = false;
            mockView.ConfigureBusinessCategoriesEnabled = false;
            mockView.ConfigureBusinessCategoryFlocAssociationsEnabled = false;
            mockView.ConfigureLogGuidelinesEnabled = false;
            mockView.ConfigureCustomFieldsEnabled = false;
            mockView.ConfigureShiftHandoverEnabled = false;
            mockView.ConfigureDORCutoffTimeEnabled = false;
            mockView.ConfigureLogTemplatesEnabled = false;
            mockView.ConfigureLabAlertsEnabled = false;
            mockView.ConfigureDefaultTabsEnabled = false;
            mockView.ConfigureWorkAssignmentNotSelectedWarningEnabled = false;
            mockView.ConfigureAssociateWorkAssignmentsToFLOCsForPermitAutoAssignmentEnabled = false;
            mockView.CokerCardReportsVisible = false;
            mockView.ConfigureCokerCardsEnabled = false;
            mockView.ConfigurePriorityPageEnabled = false;
            mockView.ConfigureWorkPermitMontrealTemplatesEnabled = false;

            mockView.Expect(mock => mock.AdminstrationVisible(false)).IgnoreArguments();
        }

    }
}