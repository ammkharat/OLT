using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Fixtures;
using NUnit.Framework;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    [TestFixture] [Category("Database")]
    public class SiteConfigurationDaoTest : AbstractDaoTest
    {
        private ISiteConfigurationDao dao;

        protected override void TestInitialize()
        {
            dao = DaoRegistry.GetDao<ISiteConfigurationDao>();
        }

        protected override void Cleanup()
        {
            DaoRegistry.Clear();
        }

        [Ignore] [Test]
        public void ShouldSelectSiteConfigurationBySiteId()
        {
            // Sarnia
            {
                Site site = SiteFixture.Sarnia();
                SiteConfiguration expected = SiteConfigurationFixture.CreateDefaultSiteConfiguration(site);
                SiteConfiguration actual = dao.QueryBySiteId(site.IdValue);

                Assert.AreEqual(expected.AllowStandardLogAtSecondLevelFunctionalLocation,
                                actual.AllowStandardLogAtSecondLevelFunctionalLocation);
                Assert.AreEqual(3, actual.LoginFlocSelectionLevel);
                Assert.IsFalse(actual.DefaultSelectedFlocsToLoginFlocsForShiftLogsAndSummaryLogs);
                Assert.IsFalse(actual.DefaultSelectedFlocsToLoginFlocsForDirectivesAndLogDefinitionsAndStandingOrders);
            }

            // Edmonton
            {                        
                SiteConfiguration actual = dao.QueryBySiteId(Site.EDMONTON_ID);
                Assert.AreEqual(true, actual.UseCreatedByColumnForLogs);
                Assert.IsTrue(actual.DefaultSelectedFlocsToLoginFlocsForShiftLogsAndSummaryLogs);
                Assert.IsTrue(actual.DefaultSelectedFlocsToLoginFlocsForDirectivesAndLogDefinitionsAndStandingOrders);
                Assert.AreEqual(FunctionalLocationSetType.WorkPermit, actual.FormsFlocSetType);                
                Assert.IsTrue(actual.ShowNumberOfTurnaroundCopiesOnWorkPermitPrintingPreferencesTab);
            }

            // Montreal
            {
                Site site = SiteFixture.Montreal();
                SiteConfiguration actual = dao.QueryBySiteId(site.IdValue);
                Assert.AreEqual(true, actual.ShowIsModifiedColumnForLogs);
                Assert.IsFalse(actual.DefaultSelectedFlocsToLoginFlocsForShiftLogsAndSummaryLogs);
                Assert.IsFalse(actual.DefaultSelectedFlocsToLoginFlocsForDirectivesAndLogDefinitionsAndStandingOrders);
                Assert.AreEqual(FunctionalLocationSetType.LogIn, actual.FormsFlocSetType);
            }
        }

        [Ignore] [Test]
        public void ShouldUpdateDisplayLimits()
        {
            const int newDaysToDisplayActionItems = 45678;
            const int newDaysToDisplayShiftLogs = 56789;
            const int newDaysToDisplayShiftHandovers = 56800;
            const int newDaysToDisplayDeviationAlerts = 221144;
            const int newDaysToDisplayWorkPermits = 112312;
            const int newLabAlertDisplayLimits = 986532;
            const int newCokerCardsDispalyLimits = 23423;

            dao.UpdateDisplayLimits(
                1, newDaysToDisplayActionItems, newDaysToDisplayShiftLogs, newDaysToDisplayShiftHandovers,
                newDaysToDisplayDeviationAlerts, newDaysToDisplayWorkPermits, 33, newLabAlertDisplayLimits, newCokerCardsDispalyLimits,
                11, 22, 44, 55, 66, 77, 88,99, 33, 17);

            SiteConfiguration changedSiteConfiguration = dao.QueryBySiteId(1);
            Assert.IsNotNull(changedSiteConfiguration);
            Assert.AreEqual(newDaysToDisplayActionItems, changedSiteConfiguration.DaysToDisplayActionItems);
            Assert.AreEqual(newDaysToDisplayShiftLogs, changedSiteConfiguration.DaysToDisplayShiftLogs);
            Assert.AreEqual(newDaysToDisplayShiftHandovers, changedSiteConfiguration.DaysToDisplayShiftHandovers);
            Assert.AreEqual(newDaysToDisplayDeviationAlerts, changedSiteConfiguration.DaysToDisplayDeviationAlerts);
            Assert.AreEqual(newDaysToDisplayWorkPermits, changedSiteConfiguration.DaysToDisplayWorkPermitsBackwards);
            Assert.AreEqual(newLabAlertDisplayLimits, changedSiteConfiguration.DaysToDisplayLabAlerts);
            Assert.AreEqual(newCokerCardsDispalyLimits, changedSiteConfiguration.DaysToDisplayCokerCards);
            Assert.AreEqual(11, changedSiteConfiguration.DaysToDisplayPermitRequestsBackwards);
            Assert.AreEqual(22, changedSiteConfiguration.DaysToDisplayPermitRequestsForwards);
            Assert.AreEqual(33, changedSiteConfiguration.DaysToDisplayWorkPermitsForwards);
            Assert.AreEqual(44, changedSiteConfiguration.DaysToDisplayFormsBackwards);
            Assert.AreEqual(55, changedSiteConfiguration.DaysToDisplayFormsForwards);
            Assert.AreEqual(66, changedSiteConfiguration.DaysToDisplaySAPNotificationsBackwards);
            Assert.AreEqual(77, changedSiteConfiguration.DaysToDisplayDirectivesBackwards);
            Assert.AreEqual(88, changedSiteConfiguration.DaysToDisplayDirectivesForwards);
            Assert.AreEqual(99, changedSiteConfiguration.DaysToDisplayEventsBackwards);
            Assert.AreEqual(33, changedSiteConfiguration.DaysToDisplayDocumentSuggestionFormsBackwards);
            Assert.AreEqual(17, changedSiteConfiguration.DaysToDisplayDocumentSuggestionFormsForwards);
        }

        [Ignore] [Test]
        public void ShouldUpdateWorkPermitArchivalProcess()
        {
            Site site = SiteFixture.Sarnia();
            long siteId = site.IdValue;
            SiteConfiguration expected = dao.QueryBySiteId(siteId);
            expected.DaysBeforeArchivingClosedWorkPermits += 10;
            expected.DaysBeforeDeletingPendingWorkPermits += 20;
            expected.DaysBeforeClosingIssuedWorkPermits += 30;
            dao.UpdateWorkPermitArchivalProcess(siteId,
                                                expected.DaysBeforeArchivingClosedWorkPermits,
                                                expected.DaysBeforeDeletingPendingWorkPermits,
                                                expected.DaysBeforeClosingIssuedWorkPermits);
            SiteConfiguration actual = dao.QueryBySiteId(siteId);
            Assert.AreEqual(expected, actual);
        }

        [Ignore] [Test]
        public void ShouldUpdateActionItemSettings()
        {
            long siteId = SiteFixture.Sarnia().IdValue;
                       
            dao.UpdateActionItemSettings(siteId, false, false, false, false, false, false);

            SiteConfiguration siteConfiguration = dao.QueryBySiteId(siteId);
            
            Assert.IsFalse(siteConfiguration.AutoApproveWorkOrderActionItemDefinition);
            Assert.IsFalse(siteConfiguration.AutoApproveSAPAMActionItemDefinition);
            Assert.IsFalse(siteConfiguration.AutoApproveSAPMCActionItemDefinition);
            Assert.IsFalse(siteConfiguration.RequireLogForActionItemResponse);
            Assert.IsFalse(siteConfiguration.ActionItemRequiresApprovalDefaultValue);
            Assert.IsFalse(siteConfiguration.ActionItemRequiresResponseDefaultValue);

            dao.UpdateActionItemSettings(siteId, true, true, true, true, true, true);
            siteConfiguration = dao.QueryBySiteId(siteId);

            Assert.IsTrue(siteConfiguration.AutoApproveWorkOrderActionItemDefinition);
            Assert.IsTrue(siteConfiguration.AutoApproveSAPAMActionItemDefinition);
            Assert.IsTrue(siteConfiguration.AutoApproveSAPMCActionItemDefinition);
            Assert.IsTrue(siteConfiguration.RequireLogForActionItemResponse);
            Assert.IsTrue(siteConfiguration.ActionItemRequiresApprovalDefaultValue);
            Assert.IsTrue(siteConfiguration.ActionItemRequiresResponseDefaultValue);

            dao.UpdateActionItemSettings(siteId, false, false, false, false, false, false);
            siteConfiguration = dao.QueryBySiteId(siteId);

            Assert.IsFalse(siteConfiguration.AutoApproveWorkOrderActionItemDefinition);
            Assert.IsFalse(siteConfiguration.AutoApproveSAPAMActionItemDefinition);
            Assert.IsFalse(siteConfiguration.AutoApproveSAPMCActionItemDefinition);
            Assert.IsFalse(siteConfiguration.RequireLogForActionItemResponse);
            Assert.IsFalse(siteConfiguration.ActionItemRequiresApprovalDefaultValue);
            Assert.IsFalse(siteConfiguration.ActionItemRequiresResponseDefaultValue);
        }     

        [Ignore] [Test]
        public void ShouldUpdateRestrictionReportingLimits()
        {
            const int siteId = 1;
            const int newLimit = 123;

            dao.UpdateRestrictionReportingLimits(siteId, newLimit);

            SiteConfiguration changedSiteConfiguration = dao.QueryBySiteId(siteId);
            Assert.IsNotNull(changedSiteConfiguration);
            Assert.AreEqual(newLimit, changedSiteConfiguration.DaysToEditDeviationAlerts);
        }

        [Ignore] [Test]
        public void ShouldUpdateDORCutoffTime()
        {
            const int siteId = 1;
            Time newTime = new Time(13);

            dao.UpdateDORCutoffTime(siteId, newTime);

            SiteConfiguration changedSiteConfiguration = dao.QueryBySiteId(siteId);
            Assert.IsNotNull(changedSiteConfiguration);
            Assert.AreEqual(newTime, changedSiteConfiguration.DorEditCutoffTime);
        }

        [Ignore] [Test]
        public void ShouldUpdateHideDORCommentsTextBox()
        {
            const int siteId = 1;

            {
                dao.UpdateHideDORCommentsTextBox(siteId, true);
                SiteConfiguration changedSiteConfiguration = dao.QueryBySiteId(siteId);
                Assert.IsTrue(changedSiteConfiguration.HideDORCommentEntry);    
            }

            {
                dao.UpdateHideDORCommentsTextBox(siteId, false);
                SiteConfiguration changedSiteConfiguration = dao.QueryBySiteId(siteId);
                Assert.IsFalse(changedSiteConfiguration.HideDORCommentEntry);    
            }
        }

        [Ignore] [Test]
        public void ShouldUpdateLabAlertRetryAttemptLimit()
        {
            const int siteId = 1;

            {
                SiteConfiguration siteConfiguration = dao.QueryBySiteId(siteId);
                int labAlertRetryAttempts = siteConfiguration.LabAlertRetryAttemptLimit;
                Assert.AreNotEqual(242, labAlertRetryAttempts); // sanity check
                siteConfiguration.LabAlertRetryAttemptLimit = 242;
                dao.UpdateLabAlertRetryAttemptLimit(siteId, 242);
            }

            {
                SiteConfiguration siteConfiguration = dao.QueryBySiteId(siteId);
                int labAlertRetryAttempts = siteConfiguration.LabAlertRetryAttemptLimit;
                Assert.AreEqual(242, labAlertRetryAttempts);
            }            
        }

        [Ignore] [Test]
        public void ShowActionItemsOnShiftHandoverIsConfiguredProperly()
        {
            List<long> allOLTSiteIds = new List<long>(){Site.SARNIA_ID, Site.DENVER_ID, Site.OILSAND_ID, 
                                                        Site.FIREBAG_ID, Site.MACKAY_ID, Site.EDMONTON_ID, 
                                                        Site.MONTREAL_ID};
            
            List<bool> expected = new List<bool>(){true, true, true,
                                                   true, true, true,
                                                   false};

            AssertShowActionItemsOnShiftHandover(allOLTSiteIds, expected);
        }

        [Ignore] [Test]
        public void ShouldUpdateSiteConfigurationPriorityPageConfiguration()
        {
            const int siteId = 1;
            SiteConfiguration siteConfiguration = dao.QueryBySiteIdWithNoCaching(siteId);

            siteConfiguration.AllowCustomFieldsToBePartOfAddShiftInfo = false; //RITM0164968 mangesh
            siteConfiguration.UseNewPriorityPage = true;
            siteConfiguration.ShowActionItemsByWorkAssignmentOnPriorityPage = true;
            siteConfiguration.ShowShiftHandoversByWorkAssignmentOnPriorityPage = true;
            siteConfiguration.DaysToDisplayDirectivesOnPriorityPage = 1;
            siteConfiguration.DaysToDisplayShiftHandoversOnPriorityPage = 2;
            siteConfiguration.DisplayActionItemWorkAssignmentOnPriorityPage = true;
            siteConfiguration.DaysToDisplayFormsBackwardsOnPriorityPage = 5;
            siteConfiguration.DaysToDisplayIncompleteActionItemsBackwardsOnPriorityPage = 2;
            siteConfiguration.DaysToDisplayDocumentSuggestionFormsBackwardsOnPriorityPage = 44;
            dao.UpdateSiteConfigurationPriorityPageConfiguration(siteConfiguration);

            siteConfiguration = dao.QueryBySiteIdWithNoCaching(siteId);
            Assert.IsTrue(siteConfiguration.UseNewPriorityPage);
            Assert.IsTrue(siteConfiguration.ShowActionItemsByWorkAssignmentOnPriorityPage);
            Assert.AreEqual(1, siteConfiguration.DaysToDisplayDirectivesOnPriorityPage);
            Assert.AreEqual(2, siteConfiguration.DaysToDisplayShiftHandoversOnPriorityPage);
            Assert.AreEqual(5, siteConfiguration.DaysToDisplayFormsBackwardsOnPriorityPage);
            Assert.AreEqual(2, siteConfiguration.DaysToDisplayIncompleteActionItemsBackwardsOnPriorityPage);
            Assert.AreEqual(44, siteConfiguration.DaysToDisplayDocumentSuggestionFormsBackwardsOnPriorityPage);
            Assert.IsTrue(siteConfiguration.DisplayActionItemWorkAssignmentOnPriorityPage);

            siteConfiguration.UseNewPriorityPage = false;
            siteConfiguration.ShowActionItemsByWorkAssignmentOnPriorityPage = false;
            siteConfiguration.ShowShiftHandoversByWorkAssignmentOnPriorityPage = false;
            siteConfiguration.DaysToDisplayDirectivesOnPriorityPage = 3;
            siteConfiguration.DaysToDisplayShiftHandoversOnPriorityPage = 4;
            siteConfiguration.DisplayActionItemWorkAssignmentOnPriorityPage = false;
            siteConfiguration.DaysToDisplayFormsBackwardsOnPriorityPage = 1;
            siteConfiguration.DaysToDisplayIncompleteActionItemsBackwardsOnPriorityPage = null;
            dao.UpdateSiteConfigurationPriorityPageConfiguration(siteConfiguration);

            siteConfiguration = dao.QueryBySiteIdWithNoCaching(siteId);
            Assert.IsFalse(siteConfiguration.UseNewPriorityPage);
            Assert.IsFalse(siteConfiguration.ShowActionItemsByWorkAssignmentOnPriorityPage);
            Assert.AreEqual(3, siteConfiguration.DaysToDisplayDirectivesOnPriorityPage);
            Assert.AreEqual(4, siteConfiguration.DaysToDisplayShiftHandoversOnPriorityPage);
            Assert.AreEqual(1, siteConfiguration.DaysToDisplayFormsBackwardsOnPriorityPage);
            Assert.IsNull(siteConfiguration.DaysToDisplayIncompleteActionItemsBackwardsOnPriorityPage);
            Assert.IsFalse(siteConfiguration.DisplayActionItemWorkAssignmentOnPriorityPage);
        }

        [Ignore] [Test]
        public void ShouldDisplayCommentOnlyCheckBoxOnActionItemResponseForAllSitesExceptMontreal()
        {
            List<long> allOLTSiteIds = new List<long>(){Site.SARNIA_ID, Site.DENVER_ID, Site.OILSAND_ID, 
                                                        Site.FIREBAG_ID, Site.MACKAY_ID, Site.EDMONTON_ID, 
                                                        Site.MONTREAL_ID};

            List<bool> expected = new List<bool>(){true, true, true,
                                                   true, true, true,
                                                   false};

            AssertShouldDisplayCommentOnlyCheckBoxOnActionItemResponseForm(allOLTSiteIds, expected);
        }

        [Ignore] [Test]
        public void ShouldKnowWhetherOrNotSiteIsUsingLogBasedDirectives()
        {
            SiteConfiguration lubesSiteConfig = dao.QueryBySiteIdWithNoCaching(Site.LUBES_ID);
            lubesSiteConfig.UseLogBasedDirectives = true;
            dao.Update(lubesSiteConfig);
            Assert.IsTrue(dao.SiteIsUsingLogBasedDirectives(Site.LUBES_ID));

            lubesSiteConfig.UseLogBasedDirectives = false;
            dao.Update(lubesSiteConfig);
            Assert.IsFalse(dao.SiteIsUsingLogBasedDirectives(Site.LUBES_ID));
        }

        [Ignore] [Test]
        public void ShouldUpdateEverythingOtherThanThingsInAJoinedTable()
        {
            SiteConfiguration sc = dao.QueryBySiteIdWithNoCaching(Site.EDMONTON_ID);

            FunctionalLocationSetType alteredFlocSetType;
            if (sc.FormsFlocSetType == FunctionalLocationSetType.LogIn)
            {
                alteredFlocSetType = FunctionalLocationSetType.WorkPermit;
            }
            else
            {
                alteredFlocSetType = FunctionalLocationSetType.LogIn;
            }

            SiteConfiguration updatedSc = new SiteConfiguration(Site.EDMONTON_ID, sc.DaysToDisplayActionItems + 1,
                sc.DaysToDisplayShiftLogs + 1, sc.DaysToDisplayShiftHandovers + 1, sc.DaysToDisplayDeviationAlerts + 1,
                sc.DaysToDisplayWorkPermitsBackwards + 1, sc.DaysToDisplayWorkPermitsForwards + 1,
                sc.DaysToDisplayLabAlerts + 1, sc.DaysToDisplayCokerCards + 1, sc.DaysToEditDeviationAlerts + 1,
                sc.DaysBeforeArchivingClosedWorkPermits + 1, sc.DaysBeforeDeletingPendingWorkPermits + 1,
                sc.DaysBeforeClosingIssuedWorkPermits + 1, sc.LabAlertRetryAttemptLimit + 1,
                !sc.AutoApproveWorkOrderActionItemDefinition, !sc.AutoApproveSAPAMActionItemDefinition,
                !sc.AutoApproveSAPMCActionItemDefinition,
                sc.ActionItemDefinitionAutoReApprovalConfiguration, sc.TargetDefinitionAutoReApprovalConfiguration,
                !sc.CreateOperatingEngineerLogs, sc.OperatingEngineerLogDisplayName + "!",
                !sc.WorkPermitNotApplicableAutoSelected, !sc.WorkPermitOptionAutoSelected,
                sc.SummaryLogFunctionalLocationDisplayLevel + 1, !sc.ShowActionItemsByWorkAssignmentOnPriorityPage,
                !sc.AllowStandardLogAtSecondLevelFunctionalLocation, sc.DorEditCutoffTime.AddHours(1),
                !sc.RequireLogForActionItemResponse, !sc.ActionItemRequiresApprovalDefaultValue,
                !sc.ActionItemRequiresResponseDefaultValue,
                !sc.HideDORCommentEntry, !sc.ShowActionItemsOnShiftHandover, !sc.UseNewPriorityPage,
                !sc.ShowShiftHandoversByWorkAssignmentOnPriorityPage, sc.DaysToDisplayDirectivesOnPriorityPage + 1,
                sc.DaysToDisplayShiftHandoversOnPriorityPage + 1,
                sc.DaysToDisplayTargetAlertsOnPriorityPage + 1, !sc.DisplayActionItemWorkAssignmentOnPriorityPage,
                sc.DaysToDisplayPermitRequestsBackwards + 1,
                sc.DaysToDisplayPermitRequestsForwards + 1, !sc.DisplayActionItemCommentOnly,
                sc.DefaultNumberOfCopiesForWorkPermits + 1,
                !sc.ShowFollowupOnLogForm, !sc.AllowCreateALogForEachSelectedFlocOnLogForm,
                !sc.ShowAdditionalDetailsOnLogFormByDefault,
                sc.AtLeastOneRoleCanCreateLogDefinitions, sc.Culture + "!", !sc.ShowWorkPermitPrintingTabInPreferences,
                !sc.ShowDefaultPermitTimesTabInPreferences,
                sc.LoginFlocSelectionLevel + 1, sc.ItemFlocSelectionLevel + 1, !sc.UseCreatedByColumnForLogs,
                !sc.ShowIsModifiedColumnForLogs,
                !sc.DefaultSelectedFlocsToLoginFlocsForShiftLogsAndSummaryLogs,
                !sc.DefaultSelectedFlocsToLoginFlocsForDirectivesAndLogDefinitionsAndStandingOrders,
                sc.DaysToDisplayFormsBackwards + 1, 99, sc.DaysToDisplayFormsBackwardsOnPriorityPage + 1,
                alteredFlocSetType,
                sc.DaysToDisplaySAPNotificationsBackwards + 1, sc.PreShiftPaddingInMinutes + 1,
                sc.PostShiftPaddingInMinutes + 1, !sc.ShowNumberOfCopiesOnWorkPermitPrintingPreferencesTab,
                !sc.AllowCombinedShiftHandoverAndLog, !sc.ShowCreateShiftHandoverMessageFromNewLogClick,
                sc.DaysToDisplayIncompleteActionItemsBackwardsOnPriorityPage + 1,
                !sc.DefaultTargetDefinitionRequiresResponseWhenAlertedValue, !sc.CollectAnalyticsData,
                sc.DaysToDisplayDirectivesBackwards + 1, sc.DaysToDisplayDirectivesForwards + 1,
                !sc.UseLogBasedDirectives,
                !sc.ShowNumberOfTurnaroundCopiesOnWorkPermitPrintingPreferencesTab, sc.RememberActionItemWorkAssignment,
                sc.MaximumDirectiveFlocLevel + 1, sc.MaximumAllowableExcursionEventDurationMins + 1,
                sc.MaximumAllowableExcursionEventTimeframeMins + 1, sc.DaysToDisplayEventsBackwards + 1,
                sc.DaysToDisplayDocumentSuggestionFormsBackwards + 1,
                sc.DaysToDisplayDocumentSuggestionFormsForwards + 1,
                sc.DaysToDisplayDocumentSuggestionFormsBackwardsOnPriorityPage + 1,
                sc.ActionItemFlocLevel + 1, sc.ShiftLogFlocLevel + 1, sc.ShiftHandoverFlocLevel + 1,
                //Floc Struture level changes- control the display level for every site for the settings--Sarika
                sc.AllowCustomFieldsToBePartOfAddShiftInfo,
                //RITM0164968 added allowCustomFieldsToBePartOfAddShiftInfo- mangesh
                sc.AllowEditingOfOldLogs, // RITM0221979 Changing edit feature in OLT logs- UDS only
                sc.EnableCSDMarkAsRead,
                sc.SoundAlertforActionItemDirectiveEventsTargets, // DMND0010264 : Sound alert for ActionItem, Directives, Events and Targets
                sc.ShiftHandoverAlert, //RITM0387753-Shift Handover creation alert:Aarti
                sc.EnableShiftHandoverAlert, //RITM0387753-Shift Handover creation alert:Aarti
                sc.EnableLogsFromOtherUsers); //RITM0377367-Enable logs from other users:Aarti
            dao.Update(updatedSc);

            SiteConfiguration requeried = dao.QueryBySiteIdWithNoCaching(Site.EDMONTON_ID);

            //Floc Struture level changes- control the display level for every site for the settings---sarika
            Assert.AreEqual(updatedSc.ActionItemFlocLevel, requeried.ActionItemFlocLevel);
            Assert.AreEqual(updatedSc.ShiftLogFlocLevel, requeried.ShiftLogFlocLevel);
            Assert.AreEqual(updatedSc.ShiftHandoverFlocLevel, requeried.ShiftHandoverFlocLevel);

            Assert.AreEqual(updatedSc.DaysToDisplayActionItems, requeried.DaysToDisplayActionItems);
            Assert.AreEqual(updatedSc.DaysToDisplayShiftLogs, requeried.DaysToDisplayShiftLogs);
            Assert.AreEqual(updatedSc.DaysToDisplayShiftHandovers, requeried.DaysToDisplayShiftHandovers);
            Assert.AreEqual(updatedSc.DaysToDisplayDeviationAlerts, requeried.DaysToDisplayDeviationAlerts);
            Assert.AreEqual(updatedSc.DaysToDisplayWorkPermitsBackwards, requeried.DaysToDisplayWorkPermitsBackwards);
            Assert.AreEqual(updatedSc.DaysToDisplayWorkPermitsForwards, requeried.DaysToDisplayWorkPermitsForwards);
            Assert.AreEqual(updatedSc.DaysToDisplayLabAlerts, requeried.DaysToDisplayLabAlerts);
            Assert.AreEqual(updatedSc.DaysToDisplayCokerCards, requeried.DaysToDisplayCokerCards);
            Assert.AreEqual(updatedSc.DaysToEditDeviationAlerts, requeried.DaysToEditDeviationAlerts);
            Assert.AreEqual(updatedSc.DaysBeforeArchivingClosedWorkPermits, requeried.DaysBeforeArchivingClosedWorkPermits);
            Assert.AreEqual(updatedSc.DaysBeforeDeletingPendingWorkPermits, requeried.DaysBeforeDeletingPendingWorkPermits);
            Assert.AreEqual(updatedSc.DaysBeforeClosingIssuedWorkPermits, requeried.DaysBeforeClosingIssuedWorkPermits);
            Assert.AreEqual(updatedSc.LabAlertRetryAttemptLimit, requeried.LabAlertRetryAttemptLimit);
            Assert.AreEqual(updatedSc.AutoApproveWorkOrderActionItemDefinition, requeried.AutoApproveWorkOrderActionItemDefinition);
            Assert.AreEqual(updatedSc.AutoApproveSAPAMActionItemDefinition, requeried.AutoApproveSAPAMActionItemDefinition);
            Assert.AreEqual(updatedSc.AutoApproveSAPMCActionItemDefinition, requeried.AutoApproveSAPMCActionItemDefinition);
            Assert.AreEqual(updatedSc.CreateOperatingEngineerLogs, requeried.CreateOperatingEngineerLogs);
            Assert.AreEqual(updatedSc.OperatingEngineerLogDisplayName, requeried.OperatingEngineerLogDisplayName);
            Assert.AreEqual(updatedSc.WorkPermitNotApplicableAutoSelected, requeried.WorkPermitNotApplicableAutoSelected);
            Assert.AreEqual(updatedSc.WorkPermitOptionAutoSelected, requeried.WorkPermitOptionAutoSelected);
            Assert.AreEqual(updatedSc.SummaryLogFunctionalLocationDisplayLevel, requeried.SummaryLogFunctionalLocationDisplayLevel);
            Assert.AreEqual(updatedSc.ShowActionItemsByWorkAssignmentOnPriorityPage, requeried.ShowActionItemsByWorkAssignmentOnPriorityPage);
            Assert.AreEqual(updatedSc.AllowStandardLogAtSecondLevelFunctionalLocation, requeried.AllowStandardLogAtSecondLevelFunctionalLocation);
            Assert.AreEqual(updatedSc.DorEditCutoffTime, requeried.DorEditCutoffTime);
            Assert.AreEqual(updatedSc.RequireLogForActionItemResponse, requeried.RequireLogForActionItemResponse);
            Assert.AreEqual(updatedSc.ActionItemRequiresApprovalDefaultValue, requeried.ActionItemRequiresApprovalDefaultValue);
            Assert.AreEqual(updatedSc.ActionItemRequiresResponseDefaultValue, requeried.ActionItemRequiresResponseDefaultValue);
            Assert.AreEqual(updatedSc.HideDORCommentEntry, requeried.HideDORCommentEntry);
            Assert.AreEqual(updatedSc.ShowActionItemsOnShiftHandover, requeried.ShowActionItemsOnShiftHandover);
            Assert.AreEqual(updatedSc.UseNewPriorityPage, requeried.UseNewPriorityPage);
            Assert.AreEqual(updatedSc.ShowShiftHandoversByWorkAssignmentOnPriorityPage, requeried.ShowShiftHandoversByWorkAssignmentOnPriorityPage);
            Assert.AreEqual(updatedSc.DaysToDisplayDirectivesOnPriorityPage, requeried.DaysToDisplayDirectivesOnPriorityPage);
            Assert.AreEqual(updatedSc.DaysToDisplayShiftHandoversOnPriorityPage, requeried.DaysToDisplayShiftHandoversOnPriorityPage);
            Assert.AreEqual(updatedSc.DaysToDisplayTargetAlertsOnPriorityPage, requeried.DaysToDisplayTargetAlertsOnPriorityPage);
            Assert.AreEqual(updatedSc.DisplayActionItemWorkAssignmentOnPriorityPage, requeried.DisplayActionItemWorkAssignmentOnPriorityPage);
            Assert.AreEqual(updatedSc.DaysToDisplayPermitRequestsBackwards, requeried.DaysToDisplayPermitRequestsBackwards);
            Assert.AreEqual(updatedSc.DaysToDisplayPermitRequestsForwards, requeried.DaysToDisplayPermitRequestsForwards);
            Assert.AreEqual(updatedSc.DisplayActionItemCommentOnly, requeried.DisplayActionItemCommentOnly);
            Assert.AreEqual(updatedSc.DefaultNumberOfCopiesForWorkPermits, requeried.DefaultNumberOfCopiesForWorkPermits);
            Assert.AreEqual(updatedSc.ShowFollowupOnLogForm, requeried.ShowFollowupOnLogForm);
            Assert.AreEqual(updatedSc.AllowCreateALogForEachSelectedFlocOnLogForm, requeried.AllowCreateALogForEachSelectedFlocOnLogForm);
            Assert.AreEqual(updatedSc.ShowAdditionalDetailsOnLogFormByDefault, requeried.ShowAdditionalDetailsOnLogFormByDefault);
            Assert.AreEqual(updatedSc.Culture, requeried.Culture);
            Assert.AreEqual(updatedSc.ShowWorkPermitPrintingTabInPreferences, requeried.ShowWorkPermitPrintingTabInPreferences);
            Assert.AreEqual(updatedSc.ShowDefaultPermitTimesTabInPreferences, requeried.ShowDefaultPermitTimesTabInPreferences);
            Assert.AreEqual(updatedSc.LoginFlocSelectionLevel, requeried.LoginFlocSelectionLevel);
            Assert.AreEqual(updatedSc.ItemFlocSelectionLevel, requeried.ItemFlocSelectionLevel);
            Assert.AreEqual(updatedSc.UseCreatedByColumnForLogs, requeried.UseCreatedByColumnForLogs);
            Assert.AreEqual(updatedSc.ShowIsModifiedColumnForLogs, requeried.ShowIsModifiedColumnForLogs);
            Assert.AreEqual(updatedSc.DefaultSelectedFlocsToLoginFlocsForShiftLogsAndSummaryLogs, requeried.DefaultSelectedFlocsToLoginFlocsForShiftLogsAndSummaryLogs);
            Assert.AreEqual(updatedSc.DefaultSelectedFlocsToLoginFlocsForDirectivesAndLogDefinitionsAndStandingOrders, requeried.DefaultSelectedFlocsToLoginFlocsForDirectivesAndLogDefinitionsAndStandingOrders);
            Assert.AreEqual(updatedSc.DaysToDisplayFormsBackwards, requeried.DaysToDisplayFormsBackwards);
            Assert.AreEqual(updatedSc.DaysToDisplayFormsBackwardsOnPriorityPage, requeried.DaysToDisplayFormsBackwardsOnPriorityPage);
            Assert.AreEqual(updatedSc.FormsFlocSetType.IdValue, requeried.FormsFlocSetType.IdValue);
            Assert.AreEqual(updatedSc.DaysToDisplaySAPNotificationsBackwards, requeried.DaysToDisplaySAPNotificationsBackwards);
            Assert.AreEqual(updatedSc.PreShiftPaddingInMinutes, requeried.PreShiftPaddingInMinutes);
            Assert.AreEqual(updatedSc.PostShiftPaddingInMinutes, requeried.PostShiftPaddingInMinutes);
            Assert.AreEqual(updatedSc.ShowNumberOfCopiesOnWorkPermitPrintingPreferencesTab, requeried.ShowNumberOfCopiesOnWorkPermitPrintingPreferencesTab);
            Assert.AreEqual(updatedSc.AllowCombinedShiftHandoverAndLog, requeried.AllowCombinedShiftHandoverAndLog);
            Assert.AreEqual(updatedSc.ShowCreateShiftHandoverMessageFromNewLogClick, requeried.ShowCreateShiftHandoverMessageFromNewLogClick);
            Assert.AreEqual(updatedSc.DaysToDisplayIncompleteActionItemsBackwardsOnPriorityPage, requeried.DaysToDisplayIncompleteActionItemsBackwardsOnPriorityPage);
            Assert.AreEqual(updatedSc.DefaultTargetDefinitionRequiresResponseWhenAlertedValue, requeried.DefaultTargetDefinitionRequiresResponseWhenAlertedValue);
            Assert.AreEqual(updatedSc.CollectAnalyticsData, requeried.CollectAnalyticsData);
            Assert.AreEqual(updatedSc.UseLogBasedDirectives, requeried.UseLogBasedDirectives);            
            Assert.AreEqual(updatedSc.ShowNumberOfTurnaroundCopiesOnWorkPermitPrintingPreferencesTab, requeried.ShowNumberOfTurnaroundCopiesOnWorkPermitPrintingPreferencesTab);
            Assert.AreEqual(updatedSc.RememberActionItemWorkAssignment,requeried.RememberActionItemWorkAssignment);
            Assert.AreEqual(updatedSc.MaximumDirectiveFlocLevel, requeried.MaximumDirectiveFlocLevel);
            Assert.AreEqual(updatedSc.MaximumAllowableExcursionEventDurationMins, requeried.MaximumAllowableExcursionEventDurationMins);
            Assert.AreEqual(updatedSc.DaysToDisplayEventsBackwards, requeried.DaysToDisplayEventsBackwards);
            Assert.AreEqual(updatedSc.MaximumAllowableExcursionEventTimeframeMins, requeried.MaximumAllowableExcursionEventTimeframeMins);
            Assert.AreEqual(updatedSc.DaysToDisplayDocumentSuggestionFormsBackwards, requeried.DaysToDisplayDocumentSuggestionFormsBackwards);
            Assert.AreEqual(updatedSc.DaysToDisplayDocumentSuggestionFormsForwards, requeried.DaysToDisplayDocumentSuggestionFormsForwards);
            Assert.AreEqual(updatedSc.DaysToDisplayDocumentSuggestionFormsBackwardsOnPriorityPage, requeried.DaysToDisplayDocumentSuggestionFormsBackwardsOnPriorityPage);
        }

        private void AssertShouldDisplayCommentOnlyCheckBoxOnActionItemResponseForm(List<long> siteIds, List<bool> expectedList)
        {
            for (int i = 0; i < expectedList.Count; i++ )
            {
                bool expected = expectedList[i];
                Assert.AreEqual(expected, dao.QueryBySiteId(siteIds[i]).DisplayActionItemCommentOnly);
            }
        }

        private void AssertShowActionItemsOnShiftHandover(List<long> siteIds, List<bool> expectedList)
        {
            for (int i = 0; i < expectedList.Count; i++)
            {
                bool expected = expectedList[i];
                Assert.AreEqual(expected, dao.QueryBySiteId(siteIds[i]).ShowActionItemsOnShiftHandover);
            }
        }
    }
}