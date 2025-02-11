using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public class SiteConfigurationDao : AbstractManagedDao, ISiteConfigurationDao
    {
        private const string QUERY_BY_SITE_ID_STORED_PROC = "QuerySiteConfigurationBySiteId";
        private const string UPDATE_DISPLAY_LIMITS = "UpdateDisplayLimits";
        private const string UPDATE_WORK_PERMIT_ARCHIVAL_PROCESS = "UpdateWorkPermitArchivalProcessConfiguration";
        private const string UPDATE_ACTION_ITEM_SETTINGS = "UpdateActionItemSettings";
        private const string UPDATE_RESTRICTION_REPORTING_LIMITS = "UpdateSiteConfigurationRestrictionReportingLimits";
        private const string UPDATE_DOR_CUTOFF_TIME = "UpdateSiteConfigurationDORCutoffTime";
        private const string UPDATE_DOR_COMMENT_ENTRY = "UpdateSiteConfigurationHideDORCommentEntry";
        private const string UPDATE_LAB_ALERT_RETRY_ATTEMPT_LIMIT = "UpdateSiteConfigurationLabAlertRetryAttemptLimit";
        private const string UPDATE_PRIORITY_PAGE_CONFIGURATION = "UpdateSiteConfigurationPriorityPageConfiguration";
        private const string UPDATE = "UpdateSiteConfiguration";
        private const string QUERY_DOES_SITE_USE_LOG_BASED_DIRECTIVES = "QueryDoesSiteUseLogBasedDirectives";

        //sarika-Floc level configuration--setting todo by Administrator
        private const string UPDATESiteConfigurationByAdmin = "UpdateSiteConfigurationByAdmin";

        private readonly IActionItemDefinitionAutoReApprovalConfigurationDao aidAutoReApprovalConfigDao;
        private readonly IRoleDao roleDao;
        private readonly ITargetDefinitionAutoReApprovalConfigurationDao targetDefAutoReApprovalConfigDao;

        public SiteConfigurationDao()
        {
            aidAutoReApprovalConfigDao = DaoRegistry.GetDao<IActionItemDefinitionAutoReApprovalConfigurationDao>();
            targetDefAutoReApprovalConfigDao = DaoRegistry.GetDao<ITargetDefinitionAutoReApprovalConfigurationDao>();
            roleDao = DaoRegistry.GetDao<IRoleDao>();
        }

        /// <summary>
        /// sarika --- Floac Level Setting  allow to Admin
        /// </summary>
        /// <param name="siteId"></param>
        /// <returns></returns>
        public void UPDATESiteConfigurationByAdministrator(long siteId, int ActionItemFlocLevel,
            int ShiftLogFlocLevel,
            int ShiftHandoverFlocLevel)
        {
            var command = ManagedCommand;
            command.AddParameter("@SiteId", siteId);

            AddParametersForUpdatelocLevelByAdmin(command, ActionItemFlocLevel,
                ShiftLogFlocLevel, ShiftHandoverFlocLevel);

            command.ExecuteNonQuery(UPDATESiteConfigurationByAdmin);
        }

        public SiteConfiguration QueryBySiteId(long siteId)
        {
            return ManagedCommand.QueryById(siteId, PopulateInstance, QUERY_BY_SITE_ID_STORED_PROC);
        }

        public SiteConfiguration QueryBySiteIdWithNoCaching(long siteId)
        {
            return QueryBySiteId(siteId);
        }
        
        public void UpdateWorkPermitArchivalProcess(long siteId,
            int daysBeforeArchivingClosedWorkPermits,
            int daysBeforeDeletingPendingWorkPermits,
            int daysBeforeClosingIssuedWorkPermits)
        {
            var command = ManagedCommand;
            command.AddParameter("@SiteId", siteId);
            AddParametersForWorkPermitArchivalProcess(command,
                daysBeforeArchivingClosedWorkPermits,
                daysBeforeDeletingPendingWorkPermits,
                daysBeforeClosingIssuedWorkPermits);

            command.ExecuteNonQuery(UPDATE_WORK_PERMIT_ARCHIVAL_PROCESS);
        }

        public void UpdateActionItemSettings(long siteId, bool autoApproveWorkOrderActionItemDefinition,
            bool autoApproveSAPAMActionItemDefinition, bool autoApproveSAPMCActionItemDefinition,
            bool requireLogForActionItemResponse,
            bool actionItemRequiresApprovalDefaultValue, bool actionItemRequiresResponseDefaultValue)
        {
            var command = ManagedCommand;
            command.AddParameter("@SiteId", siteId);

            AddParametersForActionItemSettings(command, autoApproveWorkOrderActionItemDefinition,
                autoApproveSAPAMActionItemDefinition, autoApproveSAPMCActionItemDefinition,
                requireLogForActionItemResponse,
                actionItemRequiresApprovalDefaultValue, actionItemRequiresResponseDefaultValue);

            command.ExecuteNonQuery(UPDATE_ACTION_ITEM_SETTINGS);
        }

        public void UpdateTargetDefinitionAutoReApprovalConfiguration(
            TargetDefinitionAutoReApprovalConfiguration targetDefConfig)
        {
            targetDefAutoReApprovalConfigDao.Update(targetDefConfig);
        }

        public void UpdateActionItemDefinitionAutoReApprovalConfiguration(
            ActionItemDefinitionAutoReApprovalConfiguration aidConfig)
        {
            aidAutoReApprovalConfigDao.Update(aidConfig);
        }

        public void UpdateRestrictionReportingLimits(long siteId, int daysToEditDeviationAlerts)
        {
            var command = ManagedCommand;
            command.AddParameter("@SiteId", siteId);
            command.AddParameter("@DaysToEditDeviationAlerts", daysToEditDeviationAlerts);
            command.ExecuteNonQuery(UPDATE_RESTRICTION_REPORTING_LIMITS);
        }

        public void UpdateDORCutoffTime(long siteId, Time dorCutoffTime)
        {
            var command = ManagedCommand;
            command.AddParameter("@SiteId", siteId);
            command.AddParameter("@DorCutoffTime", dorCutoffTime.ToDateTime());
            command.ExecuteNonQuery(UPDATE_DOR_CUTOFF_TIME);
        }

        public void UpdateHideDORCommentsTextBox(long siteId, bool hideDORCommentsTextBox)
        {
            var command = ManagedCommand;
            command.AddParameter("@SiteId", siteId);
            command.AddParameter("@HideDORCommentEntry", hideDORCommentsTextBox);
            command.ExecuteNonQuery(UPDATE_DOR_COMMENT_ENTRY);
        }

        public void UpdateLabAlertRetryAttemptLimit(long siteId, int retryAttemptLimit)
        {
            var command = ManagedCommand;
            command.AddParameter("@SiteId", siteId);
            command.AddParameter("@LabAlertRetryAttemptLimit", retryAttemptLimit);
            command.ExecuteNonQuery(UPDATE_LAB_ALERT_RETRY_ATTEMPT_LIMIT);
        }

        public void UpdateSiteConfigurationPriorityPageConfiguration(SiteConfiguration siteConfiguration)
        {
            var command = ManagedCommand;
            command.AddParameter("@SiteId", siteConfiguration.IdValue);
            command.AddParameter("@UseNewPriorityPage", siteConfiguration.UseNewPriorityPage);
            command.AddParameter("@ShowActionItemsByWorkAssignmentOnPriorityPage",
                siteConfiguration.ShowActionItemsByWorkAssignmentOnPriorityPage);
            command.AddParameter("@ShowShiftHandoversByWorkAssignmentOnPriorityPage",
                siteConfiguration.ShowShiftHandoversByWorkAssignmentOnPriorityPage);
            command.AddParameter("@DaysToDisplayDirectivesOnPriorityPage",
                siteConfiguration.DaysToDisplayDirectivesOnPriorityPage);
            command.AddParameter("@DaysToDisplayShiftHandoversOnPriorityPage",
                siteConfiguration.DaysToDisplayShiftHandoversOnPriorityPage);
            command.AddParameter("@DaysToDisplayFormsBackwardsOnPriorityPage",
                siteConfiguration.DaysToDisplayFormsBackwardsOnPriorityPage);
            command.AddParameter("@DaysToDisplayIncompleteActionItemsBackwardsOnPriorityPage",
                siteConfiguration.DaysToDisplayIncompleteActionItemsBackwardsOnPriorityPage);
            command.AddParameter("@DisplayActionItemWorkAssignmentOnPriorityPage",
                siteConfiguration.DisplayActionItemWorkAssignmentOnPriorityPage);
            command.AddParameter("@MaximumAllowableExcursionEventDurationMins",
                siteConfiguration.MaximumAllowableExcursionEventDurationMins);
            command.AddParameter("@MaximumAllowableExcursionEventTimeframeMins",
                siteConfiguration.MaximumAllowableExcursionEventTimeframeMins);
            command.AddParameter("@DaysToDisplayDocumentSuggestionFormsBackwardsOnPriorityPage",
                siteConfiguration.DaysToDisplayDocumentSuggestionFormsBackwardsOnPriorityPage);

            command.ExecuteNonQuery(UPDATE_PRIORITY_PAGE_CONFIGURATION);
        }

        public List<WorkPermitLoggableStatus> QueryWorkPermitStatusesForClosingBySite(long siteId)
        {
            var command = ManagedCommand;
            command.AddParameter("@SiteId", siteId);
            return command.QueryForListResult(PopulateWorkPermitLoggableStatus,
                "QueryWorkPermitCloseConfigurationBySiteId");
        }

        public void Update(SiteConfiguration siteConfiguration)
        {
            var command = ManagedCommand;

            command.AddParameter("@SiteId", siteConfiguration.Id);

            command.AddParameter("@DaysToDisplayActionItems", siteConfiguration.DaysToDisplayActionItems);
            command.AddParameter("@DaysToDisplayShiftLogs", siteConfiguration.DaysToDisplayShiftLogs);
            command.AddParameter("@DaysBeforeArchivingClosedWorkPermits",
                siteConfiguration.DaysBeforeArchivingClosedWorkPermits);
            command.AddParameter("@DaysBeforeDeletingPendingWorkPermits",
                siteConfiguration.DaysBeforeDeletingPendingWorkPermits);
            command.AddParameter("@DaysBeforeClosingIssuedWorkPermits",
                siteConfiguration.DaysBeforeClosingIssuedWorkPermits);
            command.AddParameter("@AutoApproveWorkOrderActionItemDefinition",
                siteConfiguration.AutoApproveWorkOrderActionItemDefinition);
            command.AddParameter("@AutoApproveSAPAMActionItemDefinition",
                siteConfiguration.AutoApproveSAPAMActionItemDefinition);
            command.AddParameter("@AutoApproveSAPMCActionItemDefinition",
                siteConfiguration.AutoApproveSAPMCActionItemDefinition);

            command.AddParameter("@CreateOperatingEngineerLogs", siteConfiguration.CreateOperatingEngineerLogs);
            command.AddParameter("@WorkPermitNotApplicableAutoSelected",
                siteConfiguration.WorkPermitNotApplicableAutoSelected);
            command.AddParameter("@WorkPermitOptionAutoSelected", siteConfiguration.WorkPermitOptionAutoSelected);
            command.AddParameter("@OperatingEngineerLogDisplayName", siteConfiguration.OperatingEngineerLogDisplayName);

            command.AddParameter("@DaysToEditDeviationAlerts", siteConfiguration.DaysToEditDeviationAlerts);
            command.AddParameter("@DaysToDisplayShiftHandovers", siteConfiguration.DaysToDisplayShiftHandovers);
            command.AddParameter("@SummaryLogFunctionalLocationDisplayLevel",
                siteConfiguration.SummaryLogFunctionalLocationDisplayLevel);
            command.AddParameter("@ShowActionItemsByWorkAssignmentOnPriorityPage",
                siteConfiguration.ShowActionItemsByWorkAssignmentOnPriorityPage);
            command.AddParameter("@DaysToDisplayDeviationAlerts", siteConfiguration.DaysToDisplayDeviationAlerts);
            command.AddParameter("@AllowStandardLogAtSecondLevelFunctionalLocation",
                siteConfiguration.AllowStandardLogAtSecondLevelFunctionalLocation);
            command.AddParameter("@DorCutoffTime", siteConfiguration.DorEditCutoffTime.ToDateTime());

            command.AddParameter("@DaysToDisplayWorkPermitsBackwards",
                siteConfiguration.DaysToDisplayWorkPermitsBackwards);
            command.AddParameter("@DaysToDisplayLabAlerts", siteConfiguration.DaysToDisplayLabAlerts);
            command.AddParameter("@LabAlertRetryAttemptLimit", siteConfiguration.LabAlertRetryAttemptLimit);
            command.AddParameter("@RequireActionItemResponseLog", siteConfiguration.RequireLogForActionItemResponse);
            command.AddParameter("@ActionItemRequiresApprovalDefaultValue",
                siteConfiguration.ActionItemRequiresApprovalDefaultValue);
            command.AddParameter("@HideDORCommentEntry", siteConfiguration.HideDORCommentEntry);
            command.AddParameter("@DaysToDisplayCokerCards", siteConfiguration.DaysToDisplayCokerCards);
            command.AddParameter("@ActionItemRequiresResponseDefaultValue",
                siteConfiguration.ActionItemRequiresResponseDefaultValue);
            command.AddParameter("@ShowActionItemsOnShiftHandover", siteConfiguration.ShowActionItemsOnShiftHandover);

            command.AddParameter("@UseNewPriorityPage", siteConfiguration.UseNewPriorityPage);
            command.AddParameter("@ShowShiftHandoversByWorkAssignmentOnPriorityPage",
                siteConfiguration.ShowShiftHandoversByWorkAssignmentOnPriorityPage);
            command.AddParameter("@DaysToDisplayDirectivesOnPriorityPage",
                siteConfiguration.DaysToDisplayDirectivesOnPriorityPage);
            command.AddParameter("@DaysToDisplayShiftHandoversOnPriorityPage",
                siteConfiguration.DaysToDisplayShiftHandoversOnPriorityPage);

            command.AddParameter("@DisplayActionItemWorkAssignmentOnPriorityPage",
                siteConfiguration.DisplayActionItemWorkAssignmentOnPriorityPage);
            command.AddParameter("@DaysToDisplayPermitRequestsBackwards",
                siteConfiguration.DaysToDisplayPermitRequestsBackwards);
            command.AddParameter("@DaysToDisplayPermitRequestsForwards",
                siteConfiguration.DaysToDisplayPermitRequestsForwards);
            command.AddParameter("@DaysToDisplayWorkPermitsForwards", siteConfiguration.DaysToDisplayWorkPermitsForwards);
            command.AddParameter("@DisplayActionItemCommentOnly", siteConfiguration.DisplayActionItemCommentOnly);
            command.AddParameter("@DefaultNumberOfCopiesForWorkPermits",
                siteConfiguration.DefaultNumberOfCopiesForWorkPermits);

            command.AddParameter("@ShowFollowupOnLogForm", siteConfiguration.ShowFollowupOnLogForm);
            command.AddParameter("@AllowCreateALogForEachSelectedFlocOnLogForm",
                siteConfiguration.AllowCreateALogForEachSelectedFlocOnLogForm);
            command.AddParameter("@ShowAdditionalDetailsOnLogFormByDefault",
                siteConfiguration.ShowAdditionalDetailsOnLogFormByDefault);
            command.AddParameter("@Culture", siteConfiguration.Culture);
            command.AddParameter("@ShowWorkPermitPrintingTabInPreferences",
                siteConfiguration.ShowWorkPermitPrintingTabInPreferences);
            command.AddParameter("@ShowDefaulPermitTimesTabInPreferences",
                siteConfiguration.ShowDefaultPermitTimesTabInPreferences);
            command.AddParameter("@DaysToDisplayTargetAlertsOnPriorityPage",
                siteConfiguration.DaysToDisplayTargetAlertsOnPriorityPage);

            command.AddParameter("@LoginFlocSelectionLevel", siteConfiguration.LoginFlocSelectionLevel);
            command.AddParameter("@UseCreatedByColumnForLogs", siteConfiguration.UseCreatedByColumnForLogs);
            command.AddParameter("@ShowIsModifiedColumnForLogs", siteConfiguration.ShowIsModifiedColumnForLogs);
            command.AddParameter("@ItemFlocSelectionLevel", siteConfiguration.ItemFlocSelectionLevel);
            command.AddParameter("@DefaultSelectedFlocsToLoginFlocsForShiftLogsAndSummaryLogs",
                siteConfiguration.DefaultSelectedFlocsToLoginFlocsForShiftLogsAndSummaryLogs);

            command.AddParameter("@PreShiftPaddingInMinutes", siteConfiguration.PreShiftPaddingInMinutes);
            command.AddParameter("@PostShiftPaddingInMinutes", siteConfiguration.PostShiftPaddingInMinutes);
            command.AddParameter("@DaysToDisplayFormsBackwards", siteConfiguration.DaysToDisplayFormsBackwards);
            command.AddParameter("@DaysToDisplayFormsForwards", siteConfiguration.DaysToDisplayFormsForwards);
            command.AddParameter("@DefaultSelectedFlocsToLoginFlocsForDirectivesAndLogDefinitionsAndStandingOrders",
                siteConfiguration.DefaultSelectedFlocsToLoginFlocsForDirectivesAndLogDefinitionsAndStandingOrders);
            command.AddParameter("@DaysToDisplayFormsBackwardsOnPriorityPage",
                siteConfiguration.DaysToDisplayFormsBackwardsOnPriorityPage);
            command.AddParameter("@DaysToDisplayIncompleteActionItemsBackwardsOnPriorityPage",
                siteConfiguration.DaysToDisplayIncompleteActionItemsBackwardsOnPriorityPage);

            command.AddParameter("@FormsFlocSetTypeId", siteConfiguration.FormsFlocSetTypeId);
            command.AddParameter("@DaysToDisplaySAPNotificationsBackwards",
                siteConfiguration.DaysToDisplaySAPNotificationsBackwards);
            command.AddParameter("@ShowNumberOfCopiesOnWorkPermitPrintingPreferencesTab",
                siteConfiguration.ShowNumberOfCopiesOnWorkPermitPrintingPreferencesTab);
            command.AddParameter("@AllowCombinedShiftHandoverAndLog", siteConfiguration.AllowCombinedShiftHandoverAndLog);
            command.AddParameter("@ShowCreateShiftHandoverMessageFromNewLogClick",
                siteConfiguration.ShowCreateShiftHandoverMessageFromNewLogClick);

            command.AddParameter("@DefaultTargetDefinitionRequiresResponseWhenAlertedValue",
                siteConfiguration.DefaultTargetDefinitionRequiresResponseWhenAlertedValue);

            command.AddParameter("@CollectAnalyticsData", siteConfiguration.CollectAnalyticsData);
            command.AddParameter("@UseLogBasedDirectives", siteConfiguration.UseLogBasedDirectives);

            command.AddParameter("@ShowNumberOfTurnaroundCopiesOnWorkPermitPrintingPreferencesTab",
                siteConfiguration.ShowNumberOfTurnaroundCopiesOnWorkPermitPrintingPreferencesTab);

            command.AddParameter("@RememberActionItemWorkAssignment",
                siteConfiguration.RememberActionItemWorkAssignment);

            command.AddParameter("@MaximumDirectiveFLOClevel",
                siteConfiguration.MaximumDirectiveFlocLevel);

            command.AddParameter("@MaximumAllowableExcursionEventDurationMins",
                siteConfiguration.MaximumAllowableExcursionEventDurationMins);
            command.AddParameter("@MaximumAllowableExcursionEventTimeframeMins",
                siteConfiguration.MaximumAllowableExcursionEventTimeframeMins);

            command.AddParameter("DaysToDisplayDocumentSuggestionFormsBackwards", siteConfiguration.DaysToDisplayDocumentSuggestionFormsBackwards);
            command.AddParameter("DaysToDisplayDocumentSuggestionFormsForwards", siteConfiguration.DaysToDisplayDocumentSuggestionFormsForwards);

            command.AddParameter("DaysToDisplayDocumentSuggestionFormsBackwardsOnPriorityPage", siteConfiguration.DaysToDisplayDocumentSuggestionFormsBackwardsOnPriorityPage);
            //FLOC Sturure  Level changes- control the display level for every site for the settings --Implemented by Sarika
            command.AddParameter("ActionItemFlocLevel", siteConfiguration.ActionItemFlocLevel);
            command.AddParameter("ShiftLogFlocLevel", siteConfiguration.ShiftLogFlocLevel);
            command.AddParameter("ShiftHandoverFlocLevel", siteConfiguration.ShiftHandoverFlocLevel);

            command.AddParameter("@AllowCustomFieldsToBePartOfAddShiftInfo", siteConfiguration.AllowCustomFieldsToBePartOfAddShiftInfo);//RITM0164968 - mangesh
            command.AddParameter("@AllowEditingOfOldLogs", siteConfiguration.AllowEditingOfOldLogs);  // RITM0221979 Changing edit feature in OLT logs- UDS only

            command.AddParameter("@AllowAdminToCreateAndEditPastDateLog", siteConfiguration.AllowAdminToCreateAndEditPastDateLog);  // By Vibhor : RITM0272920  
            command.AddParameter("@AllowToDisplayActionItemTitleOnPriorityPage", siteConfiguration.AllowToDisplayActionItemTitleOnPriorityPage);  // RITM0360089 : Added By Vibhor

            command.AddParameter("@EnableCSDMarkAsRead", siteConfiguration.EnableCSDMarkAsRead); /*RITM0265746 - Sarnia CSD marked as read start*/
            command.AddParameter("@ShiftHandoverAlert", siteConfiguration.ShiftHandoverAlert); //RITM0387753-Shift Handover creation alert:Aarti
            command.AddParameter("@EnableShiftHandoverAlert", siteConfiguration.EnableShiftHandoverAlert);//RITM0387753-Shift Handover creation alert:Aarti
            command.AddParameter("@EnableLogsFromOtherUsers", siteConfiguration.EnableLogsFromOtherUsers);//RITM0377367-Enable logs from other users:Aarti

           //command.AddParameter("@AllowToDisplayEveryShiftOnActionItemDefinitionForm", siteConfiguration.AllowToDisplayEveryShiftOnActionItemDefinitionForm); //RITM0265710 - mangesh
            command.AddParameter("@SoundAlertforActionItemDirectiveEventsTargets", siteConfiguration.SoundAlertforActionItemDirectiveEventsTargets);// DMND0010264 : Sound alert for ActionItem, Directives, Events and Targets

            //Mukesh-DMND0010634:: OLT - Cont Mgmt - Adding pictures to Shift Logs/ Shift Summary Log
            command.AddParameter("@LogImagePath", siteConfiguration.LogImagePath);
            command.AddParameter("@EnableLogImage", siteConfiguration.EnableLogImage);

            command.AddParameter("@EnableActionItemImage", siteConfiguration.EnableActionItemImage); //RITM0467567 : Added by Vibhor OLT - Adding Pictures on Action item and Directives
            command.AddParameter("@EnableDirectiveImage", siteConfiguration.EnableDirectiveImage); //RITM0467567 : Added by Vibhor OLT - Adding Pictures on Action item and Directives

            command.AddParameter("@EnableRoundInfo", siteConfiguration.EnableRoundInfo); //Added by Mukesh for Operator Round tool Demand

            command.AddParameter("@EnableWorkPermitSignature", siteConfiguration.EnableWorkPermitSignature); //Added by Mukesh 

            command.AddParameter("@EnableTemplateFeatureForWorkPermit", siteConfiguration.EnableTemplateFeatureForWorkPermit);

            command.AddParameter("@RefreshCSDOnPriorityPage", siteConfiguration.RefreshCSDOnPriorityPage);


// Added By Vibhor - RITM0632893 : Add a section with a question that could trigger a flag in the dashboard when an operator answer yes.

            command.AddParameter("@SetWorkPermitQuestionForMudsSite", siteConfiguration.SetWorkPermitQuestionForMudsSite);

            

            

            
             
            command.ExecuteNonQuery(UPDATE);
        }

        public bool SiteIsUsingLogBasedDirectives(long siteId)
        {
            var command = ManagedCommand;
            command.CommandText = QUERY_DOES_SITE_USE_LOG_BASED_DIRECTIVES;
            command.AddParameter("@SiteId", siteId);
            return (bool) command.ExecuteScalar();
        }

        public void UpdateDisplayLimits(long siteId, int actionItemDisplayLimit, int shiftLogDisplayLimit,
            int shiftHandoversDisplayLimit, int deviatonAlertDisplayLimit, int workPermitDisplayLimitBackwards,
            int workPermitDisplayLimitForwards, int labAlertDisplayLimit, int cokerCardsDisplayLimit,
            int daysToDisplayPermitRequestsBackwards, int daysToDisplayPermitRequestsForwards,
            int daysToDisplayElectronicFormsBackwards, int? daysToDisplayElectronicFormsForwards,
            int daysToDisplaySAPNotificationsBackwards, int daysToDisplayDirectivesBackwards,
            int? toDisplayDirectivesForwards, int? daysToDisplayEvents,
            int daysToDisplayDocumentSuggestionFormsBackwards, int? daysToDisplayDocumentSuggestionFormsForwards)
        {
            var command = ManagedCommand;
            command.AddParameter("@SiteId", siteId);
            command.AddParameter("DaysToDisplayActionItems", actionItemDisplayLimit);
            command.AddParameter("DaysToDisplayShiftLogs", shiftLogDisplayLimit);
            command.AddParameter("DaysToDisplayShiftHandovers", shiftHandoversDisplayLimit);
            command.AddParameter("DaysToDisplayDeviationAlerts", deviatonAlertDisplayLimit);
            command.AddParameter("DaysToDisplayWorkPermitsBackwards", workPermitDisplayLimitBackwards);
            command.AddParameter("DaysToDisplayWorkPermitsForwards", workPermitDisplayLimitForwards);
            command.AddParameter("DaysToDisplayLabAlerts", labAlertDisplayLimit);
            command.AddParameter("DaysToDisplayCokerCards", cokerCardsDisplayLimit);
            command.AddParameter("DaysToDisplayPermitRequestsBackwards", daysToDisplayPermitRequestsBackwards);
            command.AddParameter("DaysToDisplayPermitRequestsForwards", daysToDisplayPermitRequestsForwards);
            command.AddParameter("DaysToDisplayElectronicFormsBackwards", daysToDisplayElectronicFormsBackwards);
            command.AddParameter("DaysToDisplayElectronicFormsForwards", daysToDisplayElectronicFormsForwards);
            command.AddParameter("DaysToDisplaySAPNotificationsBackwards", daysToDisplaySAPNotificationsBackwards);
            command.AddParameter("DaysToDisplayDirectivesBackwards", daysToDisplayDirectivesBackwards);
            command.AddParameter("DaysToDisplayDirectivesForwards", toDisplayDirectivesForwards);
            command.AddParameter("DaysToDisplayEventsBackwards", daysToDisplayEvents);
            command.AddParameter("DaysToDisplayDocumentSuggestionFormsBackwards", daysToDisplayDocumentSuggestionFormsBackwards);
            command.AddParameter("DaysToDisplayDocumentSuggestionFormsForwards", daysToDisplayDocumentSuggestionFormsForwards);

            command.ExecuteNonQuery(UPDATE_DISPLAY_LIMITS);
        }

        private WorkPermitLoggableStatus PopulateWorkPermitLoggableStatus(SqlDataReader reader)
        {
            var workPermitStatus = reader.Get<byte>("StatusId");
            var permitStatus = PermitRequestBasedWorkPermitStatus.Get(workPermitStatus);
            if (permitStatus != default(PermitRequestBasedWorkPermitStatus))
            {
                var requiresLog = reader.Get<bool>("RequiresLog");
                return new WorkPermitLoggableStatus(permitStatus, requiresLog);
            }
            return null;
        }

        private static void AddParametersForWorkPermitArchivalProcess(SqlCommand command,
            int daysBeforeArchivingClosedWorkPermits,
            int daysBeforeDeletingPendingWorkPermits,
            int daysBeforeClosingIssuedWorkPermits)
        {
            command.AddParameter("@DaysBeforeArchivingClosedWorkPermits",
                daysBeforeArchivingClosedWorkPermits);
            command.AddParameter("@DaysBeforeDeletingPendingWorkPermits",
                daysBeforeDeletingPendingWorkPermits);
            command.AddParameter("@DaysBeforeClosingIssuedWorkPermits", daysBeforeClosingIssuedWorkPermits);
        }

        private static void AddParametersForActionItemSettings(SqlCommand command,
            bool autoApproveWorkOrderActionItemDefinition,
            bool autoApproveSAPAMActionItemDefinition,
            bool autoApproveSAPMCActionItemDefinition,
            bool requireLogForActionItemResponse,
            bool actionItemRequiresApprovalDefaultValue,
            bool actionItemRequiresResponseDefaultValue)
        {
            command.AddParameter("@AutoApproveWorkOrderActionItemDefinition", autoApproveWorkOrderActionItemDefinition);
            command.AddParameter("@AutoApproveSAPAMActionItemDefinition", autoApproveSAPAMActionItemDefinition);
            command.AddParameter("@AutoApproveSAPMCActionItemDefinition", autoApproveSAPMCActionItemDefinition);
            command.AddParameter("@RequireActionItemResponseLog", requireLogForActionItemResponse);
            command.AddParameter("@ActionItemRequiresApprovalDefaultValue", actionItemRequiresApprovalDefaultValue);
            command.AddParameter("@ActionItemRequiresResponseDefaultValue", actionItemRequiresResponseDefaultValue);
        }

        private static void AddParametersForUpdatelocLevelByAdmin(SqlCommand command,
            int ActionItemFlocLevel,
            int ShiftLogFlocLevel,
            int ShiftHandoverFlocLevel)
        {
            command.AddParameter("@ActionItemFlocLevel", ActionItemFlocLevel);
            command.AddParameter("@ShiftLogFlocLevel", ShiftLogFlocLevel);
            command.AddParameter("@ShiftHandoverFlocLevel", ShiftHandoverFlocLevel);
        }

        private SiteConfiguration PopulateInstance(SqlDataReader reader)
        {
            var siteId = reader.Get<long>("SiteId");

            var daysToDisplayActionItems = reader.Get<int>("DaysToDisplayActionItems");
            var daysToDisplayShiftLogs = reader.Get<int>("DaysToDisplayShiftLogs");
            var daysToDisplayShiftHandovers = reader.Get<int>("DaysToDisplayShiftHandovers");
            var daysToDisplayWorkPermitsBackwards = reader.Get<int>("DaysToDisplayWorkPermitsBackwards");
            var daysToDisplayWorkPermitsForwards = reader.Get<int>("DaysToDisplayWorkPermitsForwards");
            var daysToDisplayWorkLabAlerts = reader.Get<int>("DaysToDisplayLabAlerts");
            var daysToDisplayCokerCards = reader.Get<int>("DaysToDisplayCokerCards");
            var daysToDisplayPermitRequestsBackwards = reader.Get<int>("DaysToDisplayPermitRequestsBackwards");
            var daysToDisplayPermitRequestsForwards = reader.Get<int>("DaysToDisplayPermitRequestsForwards");
            var daysToDisplayDirectivesBackwards = reader.Get<int>("DaysToDisplayDirectivesBackwards");
            var daysToDisplayDirectivesForwards = reader.Get<int?>("DaysToDisplayDirectivesForwards");

            var daysBeforeArchivingClosedWorkPermits = reader.Get<int>("DaysBeforeArchivingClosedWorkPermits");
            var daysBeforeDeletingPendingWorkPermits = reader.Get<int>("DaysBeforeDeletingPendingWorkPermits");
            var daysBeforeClosingIssuedWorkPermits = reader.Get<int>("DaysBeforeClosingIssuedWorkPermits");

            var daysToDisplayDeviationAlert = reader.Get<int>("DaysToDisplayDeviationAlerts");
            var daysToEditDeviationAlert = reader.Get<int>("DaysToEditDeviationAlerts");

            var labAlertRetryAttemptLimit = reader.Get<int>("LabAlertRetryAttemptLimit");

            var autoApproveWorkOrderActionItemDefinition =
                reader.Get<bool>("AutoApproveWorkOrderActionItemDefinition");
            var autoApproveSAPAMActionItemDefinition = reader.Get<bool>("AutoApproveSAPAMActionItemDefinition");
            var autoApproveSAPMCActionItemDefinition = reader.Get<bool>("AutoApproveSAPMCActionItemDefinition");

            var createOperatingEngineerLogs = reader.Get<bool>("CreateOperatingEngineerLogs");
            var operatingEngineerLogDisplayName = reader.Get<string>("OperatingEngineerLogDisplayName");
            var workPermitNotApplicableAutoSelected = reader.Get<bool>("WorkPermitNotApplicableAutoSelected");
            var workPermitOptionAutoSelected = reader.Get<bool>("WorkPermitOptionAutoSelected");
            var summaryLogFunctionalLocationDisplayLevel = reader.Get<int>("SummaryLogFunctionalLocationDisplayLevel");

            var allowStandardLogAtSecondLevelFunctionalLocation =
                reader.Get<bool>("AllowStandardLogAtSecondLevelFunctionalLocation");
            var dorEditCutoffHour = new Time(reader.Get<DateTime>("DorCutoffTime"));

            var requireLogForActionItemResponse = reader.Get<bool>("RequireActionItemResponseLog");
            var actionItemRequiresApprovalDefaultValue = reader.Get<bool>("ActionItemRequiresApprovalDefaultValue");
            var actionItemRequiresResponseDefaultValue = reader.Get<bool>("ActionItemRequiresResponseDefaultValue");

            var aidAutoReApprovalConfig =
                aidAutoReApprovalConfigDao.QueryBySiteId(siteId);
            var targetDefAutoReApprovalConfig =
                targetDefAutoReApprovalConfigDao.QueryById(siteId);

            var hideDORCommentEntry = reader.Get<bool>("HideDORCommentEntry");

            var showActionItemsOnShiftHandover = reader.Get<bool>("ShowActionItemsOnShiftHandover");

            var useNewPriorityPage = reader.Get<bool>("UseNewPriorityPage");
            var showShiftHandoversByWorkAssignmentOnPriorityPage =
                reader.Get<bool>("ShowShiftHandoversByWorkAssignmentOnPriorityPage");
            var showActionItemsByWorkAssignmentOnPriorityPage =
                reader.Get<bool>("ShowActionItemsByWorkAssignmentOnPriorityPage");
            var daysToDisplayDirectivesOnPriorityPage = reader.Get<int>("DaysToDisplayDirectivesOnPriorityPage");
            var daysToDisplayShiftHandoversOnPriorityPage = reader.Get<int>("DaysToDisplayShiftHandoversOnPriorityPage");
            var daysToDisplayTargetAlertsOnPriorityPage = reader.Get<int>("DaysToDisplayTargetAlertsOnPriorityPage");
            var displayActionItemWorkAssignmentOnPriorityPage =
                reader.Get<bool>("DisplayActionItemWorkAssignmentOnPriorityPage");
            var displayActionItemCommentOnly = reader.Get<bool>("DisplayActionItemCommentOnly");
            var daysToDisplayFormsBackwardsOnPriorityPage = reader.Get<int>("DaysToDisplayFormsBackwardsOnPriorityPage");
            var daysToDisplayIncompleteActionItemsBackwardsOnPriorityPage =
                reader.Get<int?>("DaysToDisplayIncompleteActionItemsBackwardsOnPriorityPage");
            var defaultNumberOfCopiesForWorkPermits = reader.Get<int>("DefaultNumberOfCopiesForWorkPermits");

            var showFollowupOnLogForm = reader.Get<bool>("ShowFollowupOnLogForm");
            var allowCreateALogForEachSelectedFlocOnLogForm =
                reader.Get<bool>("AllowCreateALogForEachSelectedFlocOnLogForm");
            var showAdditionalDetailsOnLogFormByDefault = reader.Get<bool>("ShowAdditionalDetailsOnLogFormByDefault");

            var culture = reader.Get<string>("Culture");

            var showWorkPermitPrintingTabInPreferences = reader.Get<bool>("ShowWorkPermitPrintingTabInPreferences");
            var showDefaulPermitTimesTabInPreferences = reader.Get<bool>("ShowDefaulPermitTimesTabInPreferences");
            var showNumberOfCopiesOnWorkPermitPrintingPreferencesTab =
                reader.Get<bool>("ShowNumberOfCopiesOnWorkPermitPrintingPreferencesTab");

            var loginFlocSelectionLevel = reader.Get<int>("LoginFlocSelectionLevel");
            var itemFlocSelectionLevel = reader.Get<int>("ItemFlocSelectionLevel");

            var useCreatedByColumnForLogs = reader.Get<bool>("UseCreatedByColumnForLogs");
            var showIsModifiedColumnForLogs = reader.Get<bool>("ShowIsModifiedColumnForLogs");

            var defaultSelectedFlocsToLoginFlocsForShiftLogsAndSummaryLogs =
                reader.Get<bool>("DefaultSelectedFlocsToLoginFlocsForShiftLogsAndSummaryLogs");
            var defaultSelectedFlocsToLoginFlocsForDirectivesAndLogDefinitionsAndStandingOrders =
                reader.Get<bool>("DefaultSelectedFlocsToLoginFlocsForDirectivesAndLogDefinitionsAndStandingOrders");

            var daysToDisplayFormsBackwards = reader.Get<int>("DaysToDisplayFormsBackwards");
            var daysToDisplayFormsForwards = reader.Get<int?>("DaysToDisplayFormsForwards");
            var daysToDisplaySAPNotificationsBackwards = reader.Get<int>("DaysToDisplaySAPNotificationsBackwards");
            var daysToDisplayEventsBackwards = reader.Get<int?>("DaysToDisplayEventsBackwards");

            var formsFlocSetType =
                FunctionalLocationSetType.GetById(reader.Get<int>("FormsFlocSetTypeId"));
            var preShiftPaddingInMinutes = reader.Get<int>("PreShiftPaddingInMinutes");
            var postShiftPaddingInMinutes = reader.Get<int>("PostShiftPaddingInMinutes");

            var rolesThatCanCreateLogDefinitions = roleDao.QueryAllAvailableInSiteWithAnyRoleElement(
                siteId, new List<RoleElement> {RoleElement.CREATE_LOG_DEFINITION});
            var atLeastOneRoleCanCreateLogDefinitions = rolesThatCanCreateLogDefinitions.Count > 0;

            var allowCombinedShiftHandoverAndLog = reader.Get<bool>("AllowCombinedShiftHandoverAndLog");
            var showCreateShiftHandoverMessageFromNewLogClick =
                reader.Get<bool>("ShowCreateShiftHandoverMessageFromNewLogClick");

            var defaultTargetDefinitionRequiresResponseWhenAlertedValue =
                reader.Get<bool>("DefaultTargetDefinitionRequiresResponseWhenAlertedValue");

            var collectAnalyticsData = reader.Get<bool>("CollectAnalyticsData");
            var useLogBasedDirectives = reader.Get<bool>("UseLogBasedDirectives");

            var showNumberOfTurnaroundCopiesOnWorkPermitPrintingPreferencesTab =
                reader.Get<bool>("ShowNumberOfTurnaroundCopiesOnWorkPermitPrintingPreferencesTab");

            var rememberActionItemWorkAssignment = reader.Get<bool>("RememberActionItemWorkAssignment");

            var maximumDirectiveFlocLevel = reader.Get<int>("MaximumDirectiveFLOClevel");

            var maximumAllowableExcursionEventDurationMins =
                reader.Get<int>("MaximumAllowableExcursionEventDurationMins");
            var maximumAllowableExcursionEventTimeframeMins =
                reader.Get<int>("MaximumAllowableExcursionEventTimeframeMins");

            var daysToDisplayDocumentSuggestionFormsBackwards =
                reader.Get<int>("DaysToDisplayDocumentSuggestionFormsBackwards");

            var daysToDisplayDocumentSuggestionFormsForwards =
                reader.Get<int?>("DaysToDisplayDocumentSuggestionFormsForwards");

            var daysToDisplayDocumentSuggestionFormsBackwardsOnPriorityPage =
                reader.Get<int>("DaysToDisplayDocumentSuggestionFormsBackwardsOnPriorityPage");

            //Floc Structure level chnages- control the display level for every site for the settings--Implemented by Sarika
            var actionItemFlocLevel =reader.Get<int>("ActionItemFlocLevel");
            var shiftLogFlocLevel =reader.Get<int>("ShiftLogFlocLevel");
            var shiftHandoverFlocLevel =reader.Get<int>("ShiftHandoverFlocLevel");

            var allowCustomFieldsToBePartOfAddShiftInfo = reader.Get<bool>("AllowCustomFieldsToBePartOfAddShiftInfo"); //RITM0164968 - mangesh
            var allowEditingOfOldLogs = reader.Get<bool>("AllowEditingOfOldLogs");// RITM0221979 Changing edit feature in OLT logs- UDS only
            var enableCSDMarkAsRead = reader.Get<bool>("EnableCSDMarkAsRead");/*RITM0265746 - Sarnia CSD marked as read start*/
            var soundAlertforActionItemDirectiveEventsTargets = reader.Get<bool>("SoundAlertforActionItemDirectiveEventsTargets"); // DMND0010264 : Sound alert for ActionItem, Directives, Events and Targets
            var shiftHandoverAlert = reader.Get<int?>("ShiftHandoverAlert");//RITM0387753-Shift Handover creation alert:Aarti
            var enableShiftHandoverAlert = reader.Get<bool>("EnableShiftHandoverAlert");//RITM0387753-Shift Handover creation alert:Aarti
            var enableLogsFromOtherusers = reader.Get<bool>("EnableLogsFromOtherUsers");//RITM0377367-Enable logs from other users:Aarti
        

            SiteConfiguration objSiteconfiguration = new SiteConfiguration(siteId,
                daysToDisplayActionItems,
                daysToDisplayShiftLogs,
                daysToDisplayShiftHandovers,
                daysToDisplayDeviationAlert,
                daysToDisplayWorkPermitsBackwards,
                daysToDisplayWorkPermitsForwards,
                daysToDisplayWorkLabAlerts, daysToDisplayCokerCards,
                daysToEditDeviationAlert,
                daysBeforeArchivingClosedWorkPermits,
                daysBeforeDeletingPendingWorkPermits,
                daysBeforeClosingIssuedWorkPermits,
                labAlertRetryAttemptLimit,
                autoApproveWorkOrderActionItemDefinition,
                autoApproveSAPAMActionItemDefinition,
                autoApproveSAPMCActionItemDefinition,
                aidAutoReApprovalConfig,
                targetDefAutoReApprovalConfig,
                createOperatingEngineerLogs, operatingEngineerLogDisplayName,
                workPermitNotApplicableAutoSelected,
                workPermitOptionAutoSelected,
                summaryLogFunctionalLocationDisplayLevel,
                showActionItemsByWorkAssignmentOnPriorityPage,
                allowStandardLogAtSecondLevelFunctionalLocation,
                dorEditCutoffHour,
                requireLogForActionItemResponse,
                actionItemRequiresApprovalDefaultValue,
                actionItemRequiresResponseDefaultValue,
                hideDORCommentEntry,
                showActionItemsOnShiftHandover,
                useNewPriorityPage,
                showShiftHandoversByWorkAssignmentOnPriorityPage,
                daysToDisplayDirectivesOnPriorityPage,
                daysToDisplayShiftHandoversOnPriorityPage,
                daysToDisplayTargetAlertsOnPriorityPage,
                displayActionItemWorkAssignmentOnPriorityPage,
                daysToDisplayPermitRequestsBackwards,
                daysToDisplayPermitRequestsForwards,
                displayActionItemCommentOnly,
                defaultNumberOfCopiesForWorkPermits,
                showFollowupOnLogForm,
                allowCreateALogForEachSelectedFlocOnLogForm,
                showAdditionalDetailsOnLogFormByDefault,
                atLeastOneRoleCanCreateLogDefinitions,
                culture, showWorkPermitPrintingTabInPreferences, showDefaulPermitTimesTabInPreferences,
                loginFlocSelectionLevel, itemFlocSelectionLevel,
                useCreatedByColumnForLogs, showIsModifiedColumnForLogs,
                defaultSelectedFlocsToLoginFlocsForShiftLogsAndSummaryLogs,
                defaultSelectedFlocsToLoginFlocsForDirectivesAndLogDefinitionsAndStandingOrders,
                daysToDisplayFormsBackwards,
                daysToDisplayFormsForwards,
                daysToDisplayFormsBackwardsOnPriorityPage,
                formsFlocSetType,
                daysToDisplaySAPNotificationsBackwards,
                preShiftPaddingInMinutes,
                postShiftPaddingInMinutes,
                showNumberOfCopiesOnWorkPermitPrintingPreferencesTab,
                allowCombinedShiftHandoverAndLog, showCreateShiftHandoverMessageFromNewLogClick,
                daysToDisplayIncompleteActionItemsBackwardsOnPriorityPage,
                defaultTargetDefinitionRequiresResponseWhenAlertedValue,
                collectAnalyticsData,
                daysToDisplayDirectivesBackwards,
                daysToDisplayDirectivesForwards,
                useLogBasedDirectives,
                showNumberOfTurnaroundCopiesOnWorkPermitPrintingPreferencesTab,
                rememberActionItemWorkAssignment,
                maximumDirectiveFlocLevel,
                maximumAllowableExcursionEventDurationMins,
                maximumAllowableExcursionEventTimeframeMins,
                daysToDisplayEventsBackwards,
                daysToDisplayDocumentSuggestionFormsBackwards,
                daysToDisplayDocumentSuggestionFormsForwards,
                daysToDisplayDocumentSuggestionFormsBackwardsOnPriorityPage,
                actionItemFlocLevel,
                shiftLogFlocLevel,
                shiftHandoverFlocLevel,
                allowCustomFieldsToBePartOfAddShiftInfo,
                //RITM0164968 added allowCustomFieldsToBePartOfAddShiftInfo - mangesh
                allowEditingOfOldLogs, // RITM0221979 Changing edit feature in OLT logs- UDS only
                
                enableCSDMarkAsRead, /*RITM0265746 - Sarnia CSD marked as read start*/
                soundAlertforActionItemDirectiveEventsTargets, // DMND0010264 : Sound alert for ActionItem, Directives, Events and Targets
                shiftHandoverAlert, //RITM0387753-Shift Handover creation alert:Aarti
                enableShiftHandoverAlert, //RITM0387753-Shift Handover creation alert:Aarti
                enableLogsFromOtherusers);

         objSiteconfiguration.AllowAdminToCreateAndEditPastDateLog = reader.Get<bool>("AllowAdminToCreateAndEditPastDateLog"); // By Vibhor : RITM0272920  
         objSiteconfiguration.AllowToDisplayActionItemTitleOnPriorityPage = reader.Get<bool>("AllowToDisplayActionItemTitleOnPriorityPage"); // RITM0360089 : Added By Vibhor
 
         //Mukesh-DMND0010634:: OLT - Cont Mgmt - Adding pictures to Shift Logs/ Shift Summary Log
         objSiteconfiguration.EnableLogImage = reader.Get<bool>("EnableLogImage");
         objSiteconfiguration.LogImagePath = reader.Get<string>("LogImagePath");


         objSiteconfiguration.EnableActionItemImage = reader.Get<bool>("EnableActionItemImage");  //RITM0467567 : Added by Vibhor OLT - Adding Pictures on Action item and Directives
         objSiteconfiguration.EnableDirectiveImage = reader.Get<bool>("EnableDirectiveImage");  //RITM0467567 : Added by Vibhor OLT - Adding Pictures on Action item and Directives
         objSiteconfiguration.EnableRoundInfo = reader.Get<bool>("EnableRoundInfo");//Added by Mukesh for Operator Round Tool Demand
         objSiteconfiguration.EnableWorkPermitSignature = reader.Get<bool>("EnableWorkPermitSignature");//Added by Mukesh

         objSiteconfiguration.EnableTemplateFeatureForWorkPermit = reader.Get<bool>("EnableTemplateFeatureForWorkPermit");

         objSiteconfiguration.RefreshCSDOnPriorityPage = reader.Get<int>("RefreshCSDOnPriorityPage");

// Added By Vibhor - RITM0632893 : Add a section with a question that could trigger a flag in the dashboard when an operator answer yes.
         objSiteconfiguration.SetWorkPermitQuestionForMudsSite = reader.Get<string>("SetWorkPermitQuestionForMudsSite");

            

            

            

         return objSiteconfiguration;
        }
    }
}