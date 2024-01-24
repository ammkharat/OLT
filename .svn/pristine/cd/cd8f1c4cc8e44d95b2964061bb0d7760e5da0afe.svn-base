using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Common.Fixtures
{
    public static class SiteConfigurationFixture
    {
        public static SiteConfiguration CreateDefaultSiteConfiguration(Site site)
        {
            const bool includeWorkAssignmentInPriorityScreenQuery = false;
            return CreateDefaultSiteConfiguration(site, includeWorkAssignmentInPriorityScreenQuery);
        }

        public static SiteConfiguration CreateDefaultSiteConfiguration(
            Site site, bool includeWorkAssignmentInPriorityScreenQuery)
        {
            return CreateSiteConfiguration(
                site,
                includeWorkAssignmentInPriorityScreenQuery,
                ActionItemDefinitionAutoReApprovalConfigurationFixture.CreateDefaultAIDAutoReApprovalConfig(site.IdValue),
                site != SiteFixture.Denver(),
                site != SiteFixture.Denver(),
                true);
        }

        private static SiteConfiguration CreateSiteConfiguration(
            Site site, 
            bool includeWorkAssignmentInPriorityScreenQuery,
            ActionItemDefinitionAutoReApprovalConfiguration actionItemDefinitionAutoReApprovalConfiguration,
            bool workPermitNotApplicableAutoSelected,
            bool workPermitOptionAutoSelected,
            bool showActionItemsOnHandover)
        {
            int daysToDisplayActionItems = site == SiteFixture.Denver() ? 5 : (site == SiteFixture.Sarnia() ? 7 : 30);
            int daysToDisplayShiftLogs = site == SiteFixture.Denver() ? 5 : (site == SiteFixture.Sarnia() ? 7 :60);
            const int daysToDisplayShiftHandovers = 7;
            const int daysToDisplayDeviationAlert = 30;
            const int daysToEditDeviationAlert = 7;
            const int daysToDisplayWorkPermits = 15;
            const int daysToDisplayCokerCards = 14;
            const int daysToDisplayLabAlerts = 30;
            const int labAlertRetryAttemptLimit = 3;
            int daysBeforeArchivingClosedWorkPermits = site == SiteFixture.Denver() ? 7 : (site == SiteFixture.Sarnia() ? 5 : 30);
            const int daysBeforeDeletingPendingWorkPermits = 7;
            const int daysBeforeClosingIssuedWorkPermits = 1;
            bool autoApproveWorkOrderActionItemDefinition = site != SiteFixture.Denver();
            const bool autoApproveSAPAMActionItemDefinition = false;
            const bool autoApproveSAPMCActionItemDefinition = false;
            const bool requireLogForActionItemResponse = false;
            const bool actionItemRequiresApprovalDefaultValue = true;
            const bool actionItemRequiresResponseDefaultValue = true;
            const bool hideDORTextEntry = true;
            const int summaryLogFunctionalLocationDisplayLevel = 1;
            int loginFlocSelectionLevel = site == SiteFixture.Montreal() ? 5 : 3;
            int itemFlocSelectionLevel = site == SiteFixture.Montreal() ? 7 : 5;
            bool showIsModifiedColumnForLogs = site == SiteFixture.Montreal();
            bool useCreatedByColumnForLogs = site == SiteFixture.Edmonton();
            const int daysToDisplayFormsBackwards = 3;
            const int daysToDisplayFormsForwards = 3;
            const int daysToDisplayDocumentSuggestionFormsBackwards = 30;
            const int daysToDisplayDocumentSuggestionFormsForwards = 7;
            const int daysToDisplayFormsBackwardsOnPriorityPage = 3;
            const int daysToDisplaySAPNotificationsBackwards = 1;
            const int daysToDisplayDirectivesBackwards = 44;
            const int daysToDisplayDirectivesForwards = 21;
            const int preShiftPaddingInMinutes = 30;
            const int postShiftPaddingInMinutes = 30;

            // Allow Creation of Operating Engineer logs if the Site isn't Denver
            bool createOperatingEngineerLogs = (site != SiteFixture.Denver());
            long siteId = site.IdValue;

            TargetDefinitionAutoReApprovalConfiguration defaultTargetDefAutoReApprovalConfig =
                TargetDefinitionAutoReApprovalConfigurationFixture.CreateDefaultTargetDefAutoReApprovalConfig(
                    siteId);

            // Display the Comment Only check box in Action Item Response for all sites except for Montreal
            bool displayActionItemCommentOnly = (site != SiteFixture.Montreal());

            string culture = siteId == Site.MONTREAL_ID ? Culture.FrenchCultureName : Culture.DEFAULT_CULTURE_NAME;

            bool defaultSelectedFlocsToLoginFlocsForShiftLogsAndSummaryLogs = Site.EDMONTON_ID == siteId;
            bool defaultSelectedFlocsToLoginFlocsForDirectivesAndLogDefinitionsAndStandingOrders = Site.EDMONTON_ID == siteId;
            
            bool showNumberOfTurnaroundUnitCopiesOnWorkPermitPrintingPreferencesTab = Site.EDMONTON_ID == siteId;
            bool rememberActionItemWorkAssignment = Site.EDMONTON_ID == siteId;
            int maximumDirectiveFlocLevel = 1;

            int maximumAllowableExcursionEventDurationMins = 0;
            int maximumAllowableExcursionEventTimeframeMins = 120;

            int actionItemFlocLevel = 2;
           int  shiftLogFlocLevel = 1;
           int ShiftHandoverFlocLevel = 1;
           // const int actionItemFlocLevel=site.

           bool allowCustomFieldsToBePartOfAddShiftInfo = false; //RITM0164968 - mangesh
           bool allowEditingOfOldLogs = false; // RITM0221979 Changing edit feature in OLT logs- UDS only
           bool enableCSDMarkAsRead = false; /*RITM0265746 - Sarnia CSD marked as read start*/
           bool soundAlertforActionItemDirectiveEventsTargets = false; // DMND0010264 : Sound alert for ActionItem, Directives, Events and Targets
           int shiftHandoverAlert = 0;//RITM0387753-Shift Handover creation alert:Aarti
           bool enableShiftHandoveralert = false;//RITM0387753-Shift Handover creation alert:Aarti
           bool enableLogsFromOtherUsers = false; //RITM0377367-enable logs from other users:Aarti

            return new SiteConfiguration(siteId,
                daysToDisplayActionItems,
                daysToDisplayShiftLogs,
                daysToDisplayShiftHandovers,
                daysToDisplayDeviationAlert,
                daysToDisplayWorkPermits,
                0,
                daysToDisplayLabAlerts,
                daysToDisplayCokerCards,
                daysToEditDeviationAlert,
                daysBeforeArchivingClosedWorkPermits,
                daysBeforeDeletingPendingWorkPermits,
                daysBeforeClosingIssuedWorkPermits,
                labAlertRetryAttemptLimit,
                autoApproveWorkOrderActionItemDefinition,
                autoApproveSAPAMActionItemDefinition,
                autoApproveSAPMCActionItemDefinition,
                actionItemDefinitionAutoReApprovalConfiguration,
                defaultTargetDefAutoReApprovalConfig,
                createOperatingEngineerLogs,
                "Operating Engineer Log",
                workPermitNotApplicableAutoSelected,
                workPermitOptionAutoSelected,
                summaryLogFunctionalLocationDisplayLevel,
                includeWorkAssignmentInPriorityScreenQuery,
                false,
                new Time(10),
                requireLogForActionItemResponse,
                actionItemRequiresApprovalDefaultValue,
                actionItemRequiresResponseDefaultValue,
                hideDORTextEntry,
                showActionItemsOnHandover,
                true, true, 2, 2, 7, true,
                0, 0, displayActionItemCommentOnly, 1,
                true, true, true, true,
                culture, true, true,
                loginFlocSelectionLevel, itemFlocSelectionLevel,
                useCreatedByColumnForLogs, showIsModifiedColumnForLogs,
                defaultSelectedFlocsToLoginFlocsForShiftLogsAndSummaryLogs,
                defaultSelectedFlocsToLoginFlocsForDirectivesAndLogDefinitionsAndStandingOrders,
                daysToDisplayFormsBackwards, daysToDisplayFormsForwards,
                daysToDisplayFormsBackwardsOnPriorityPage,
                FunctionalLocationSetType.LogIn,
                daysToDisplaySAPNotificationsBackwards,
                preShiftPaddingInMinutes,
                postShiftPaddingInMinutes,
                true,
                false, false, null, false, true,
                daysToDisplayDirectivesBackwards, daysToDisplayDirectivesForwards,
                false,
                showNumberOfTurnaroundUnitCopiesOnWorkPermitPrintingPreferencesTab,
                rememberActionItemWorkAssignment,
                maximumDirectiveFlocLevel,
                maximumAllowableExcursionEventTimeframeMins,
                maximumAllowableExcursionEventTimeframeMins,
                3,
                daysToDisplayDocumentSuggestionFormsBackwards,
                daysToDisplayDocumentSuggestionFormsForwards,
                30,
                actionItemFlocLevel, shiftLogFlocLevel, ShiftHandoverFlocLevel,
                allowCustomFieldsToBePartOfAddShiftInfo,
                //RITM0164968 added allowCustomFieldsToBePartOfAddShiftInfo- mangesh
                allowEditingOfOldLogs, // RITM0221979 Changing edit feature in OLT logs- UDS only
                enableCSDMarkAsRead, /*RITM0265746 - Sarnia CSD marked as read start*/
                soundAlertforActionItemDirectiveEventsTargets, // DMND0010264 : Sound alert for ActionItem, Directives, Events and Targets
                shiftHandoverAlert, //RITM0387753-Shift Handover creation alert:Aarti
                enableShiftHandoveralert, //RITM0387753-Shift Handover creation alert:Aarti
                enableLogsFromOtherUsers);

        }

        public static SiteConfiguration CreateSiteConfiguration()
        {

            return CreateSiteConfiguration(SiteFixture.Sarnia(), null);
        }
        
        public static SiteConfiguration CreateSiteConfiguration(
            Site site, ActionItemDefinitionAutoReApprovalConfiguration aidConfig)
        {
            return CreateSiteConfiguration(site, false, aidConfig, false, false, true);
        }

        public static SiteConfiguration CreateDoNotAutoApproveSAPActionItemDefinition(Site site)
        {
            SiteConfiguration ret = CreateDefaultSiteConfiguration(site);
            ret.AutoApproveWorkOrderActionItemDefinition = false;
            ret.AutoApproveSAPAMActionItemDefinition = false;
            ret.AutoApproveSAPMCActionItemDefinition = false;
            return ret;
        }

        public static SiteConfiguration CreateWorkPermitNotApplicableAutoSelected(bool workPermitNotApplicableAutoSelected)
        {
            return CreateSiteConfiguration(
                SiteFixture.Sarnia(), false, null, workPermitNotApplicableAutoSelected, false, true);
        }
        
        public static SiteConfiguration CreateWorkPermitOptionAutoSelected(bool workPermitOptionAutoSelected)
        {
            return CreateSiteConfiguration(SiteFixture.Sarnia(), false, null, false, workPermitOptionAutoSelected, true);
        }

        public static SiteConfiguration CreateDoNotShowActionItemsOnHandover(Site site)
        {
            const bool showActionItemsOnHandover = false;

            return CreateSiteConfiguration(site, false, null, false, false, showActionItemsOnHandover);
        }
    }
}