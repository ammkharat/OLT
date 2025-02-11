using System;
using System.ComponentModel;

namespace Com.Suncor.Olt.Common.Domain
{
    [Serializable]
    public class SiteConfiguration : DomainObject
    {
        public SiteConfiguration(long siteId, int daysToDisplayActionItems, int daysToDisplayShiftLogs,
            int daysToDisplayShiftHandovers, int daysToDisplayDeviationAlerts, int daysToDisplayWorkPermitsBackwards,
            int daysToDisplayWorkPermitsForwards, int daysToDisplayLabAlerts, int daysToDisplayCokerCards,
            int daysToEditDeviationAlerts, int daysBeforeArchivingClosedWorkPermits,
            int daysBeforeDeletingPendingWorkPermits, int daysBeforeClosingIssuedWorkPermits,
            int labAlertRetryAttemptLimit, bool autoApproveWorkOrderActionItemDefinition,
            bool autoApproveSAPAMActionItemDefinition, bool autoApproveSAPMCActionItemDefinition,
            ActionItemDefinitionAutoReApprovalConfiguration aidAutoReApprovalConfig,
            TargetDefinitionAutoReApprovalConfiguration targetDefAutoReApprovalConfig, bool createOperatingEngineerLogs,
            string operatingEngineerLogDisplayName, bool workPermitNotApplicableAutoSelected,
            bool workPermitOptionAutoSelected, int summaryLogFunctionalLocationDisplayLevel,
            bool showActionItemsByWorkAssignmentOnPriorityPage, bool allowStandardLogAtSecondLevelFunctionalLocation,
            Time dorEditCutoffTime, bool requireLogForActionItemResponse, bool actionItemRequiresApprovalDefaultValue,
            bool actionItemRequiresResponseDefaultValue, bool hideDORCommentEntry, bool showActionItemsOnShiftHandover,
            bool useNewPriorityPage, bool showShiftHandoversByWorkAssignmentOnPriorityPage,
            int daysToDisplayDirectivesOnPriorityPage, int daysToDisplayShiftHandoversOnPriorityPage,
            int daysToDisplayTargetAlertsOnPriorityPage, bool displayActionItemWorkAssignmentOnPriorityPage,
            int daysToDisplayPermitRequestsBackwards, int daysToDisplayPermitRequestsForwards,
            bool displayActionItemCommentOnly, int defaultNumberOfCopiesForWorkPermits, bool showFollowupOnLogForm,
            bool allowCreateALogForEachSelectedFlocOnLogForm, bool showAdditionalDetailsOnLogFormByDefault,
            bool atLeastOneRoleCanCreateLogDefinitions, string culture, bool showWorkPermitPrinitingTabInPreferences,
            bool showDefaultPermitTimesTabInPreferences, int loginFlocSelectionLevel, int itemFlocSelectionLevel,
            bool useCreatedByColumnForLogs, bool showIsModifiedColumnForLogs,
            bool defaultSelectedFlocsToLoginFlocsForShiftLogsAndSummaryLogs,
            bool defaultSelectedFlocsToLoginFlocsForDirectivesAndLogDefinitionsAndStandingOrders,
            int daysToDisplayFormsBackwards, int? daysToDisplayFormsForwards,
            int daysToDisplayFormsBackwardsOnPriorityPage, FunctionalLocationSetType formsFlocSetType,
            int daysToDisplaySAPNotificationsBackwards, int preShiftPaddingInMinutes, int postShiftPaddingInMinutes,
            bool showNumberOfCopiesOnWorkPermitPrintingPreferencesTab, bool allowCombinedShiftHandoverAndLog,
            bool showCreateShiftHandoverMessageFromNewLogClick,
            int? daysToDisplayIncompleteActionItemsBackwardsOnPriorityPage,
            bool defaultTargetDefinitionRequiresResponseWhenAlertedValue, bool collectAnalyticsData,
            int daysToDisplayDirectivesBackwards, int? daysToDisplayDirectivesForwards, bool useLogBasedDirectives,
            bool showNumberOfTurnaroundCopiesOnWorkPermitPrintingPreferencesTab, bool rememberActionItemWorkAssignment,
            int maximumDirectiveFlocLevel, int maximumAllowableExcursionEventDurationMins, int maximumAllowableExcursionEventTimeframeMins,
            int? daysToDisplayEventsBackwards, int daysToDisplayDocumentSuggestionFormsBackwards, int? daysToDisplayDocumentSuggestionFormsForwards,
            int daysToDisplayDocumentSuggestionFormsBackwardsOnPriorityPage,
            int actionItemFlocLevel, int shiftLogFlocLevel, int shiftHandoverFlocLevel,
            bool allowCustomFieldsToBePartOfAddShiftInfo,
            bool allowEditingOfOldLogs, // RITM0221979 Changing edit feature in OLT logs- UDS only
            bool enableCSDMarkAsRead,
            bool soundAlertforActionItemDirectiveEventsTargets, // DMND0010264 : Sound alert for ActionItem, Directives, Events and Targets
            int? shiftHandoverAlert, //RITM0387753-Shift Handover creation alert:Aarti
            bool enableShiftHandoverAlert, //RITM0387753-Shift Handover creation alert:Aarti
            bool enableLogsFromOtherUsers) //RITM0377367-Enable logs from othet users:Aarti
        {
            id = siteId;
            DaysToDisplayActionItems = daysToDisplayActionItems;
            DaysToDisplayShiftLogs = daysToDisplayShiftLogs;
            DaysToDisplayShiftHandovers = daysToDisplayShiftHandovers;
            DaysToDisplayDeviationAlerts = daysToDisplayDeviationAlerts;
            DaysToDisplayWorkPermitsBackwards = daysToDisplayWorkPermitsBackwards;
            DaysToDisplayWorkPermitsForwards = daysToDisplayWorkPermitsForwards;
            DaysToDisplayLabAlerts = daysToDisplayLabAlerts;
            DaysToDisplayCokerCards = daysToDisplayCokerCards;
            DaysToEditDeviationAlerts = daysToEditDeviationAlerts;
            DaysToDisplayPermitRequestsBackwards = daysToDisplayPermitRequestsBackwards;
            DaysToDisplayPermitRequestsForwards = daysToDisplayPermitRequestsForwards;
            DaysToDisplayFormsBackwards = daysToDisplayFormsBackwards;
            DaysToDisplayFormsForwards = daysToDisplayFormsForwards;
            DaysToDisplaySAPNotificationsBackwards = daysToDisplaySAPNotificationsBackwards;
            DaysToDisplayDirectivesBackwards = daysToDisplayDirectivesBackwards;
            DaysToDisplayDirectivesForwards = daysToDisplayDirectivesForwards;
            DaysToDisplayEventsBackwards = daysToDisplayEventsBackwards;
            DaysToDisplayDocumentSuggestionFormsBackwards = daysToDisplayDocumentSuggestionFormsBackwards;
            DaysToDisplayDocumentSuggestionFormsForwards = daysToDisplayDocumentSuggestionFormsForwards;
            DaysToDisplayDocumentSuggestionFormsBackwardsOnPriorityPage =
                daysToDisplayDocumentSuggestionFormsBackwardsOnPriorityPage;

            LabAlertRetryAttemptLimit = labAlertRetryAttemptLimit;
            DaysBeforeArchivingClosedWorkPermits = daysBeforeArchivingClosedWorkPermits;
            DaysBeforeDeletingPendingWorkPermits = daysBeforeDeletingPendingWorkPermits;
            DaysBeforeClosingIssuedWorkPermits = daysBeforeClosingIssuedWorkPermits;
            AutoApproveWorkOrderActionItemDefinition = autoApproveWorkOrderActionItemDefinition;
            AutoApproveSAPAMActionItemDefinition = autoApproveSAPAMActionItemDefinition;
            AutoApproveSAPMCActionItemDefinition = autoApproveSAPMCActionItemDefinition;

            ActionItemDefinitionAutoReApprovalConfiguration = aidAutoReApprovalConfig;
            TargetDefinitionAutoReApprovalConfiguration = targetDefAutoReApprovalConfig;

            CreateOperatingEngineerLogs = createOperatingEngineerLogs;
            OperatingEngineerLogDisplayName = operatingEngineerLogDisplayName;
            WorkPermitNotApplicableAutoSelected = workPermitNotApplicableAutoSelected;
            WorkPermitOptionAutoSelected = workPermitOptionAutoSelected;

            SummaryLogFunctionalLocationDisplayLevel = summaryLogFunctionalLocationDisplayLevel;

            AllowStandardLogAtSecondLevelFunctionalLocation = allowStandardLogAtSecondLevelFunctionalLocation;
            DorEditCutoffTime = dorEditCutoffTime;
            RequireLogForActionItemResponse = requireLogForActionItemResponse;
            ActionItemRequiresApprovalDefaultValue = actionItemRequiresApprovalDefaultValue;
            ActionItemRequiresResponseDefaultValue = actionItemRequiresResponseDefaultValue;

            HideDORCommentEntry = hideDORCommentEntry;

            ShowActionItemsOnShiftHandover = showActionItemsOnShiftHandover;

            UseNewPriorityPage = useNewPriorityPage;
            ShowShiftHandoversByWorkAssignmentOnPriorityPage = showShiftHandoversByWorkAssignmentOnPriorityPage;
            ShowActionItemsByWorkAssignmentOnPriorityPage = showActionItemsByWorkAssignmentOnPriorityPage;
            DaysToDisplayDirectivesOnPriorityPage = daysToDisplayDirectivesOnPriorityPage;
            DaysToDisplayShiftHandoversOnPriorityPage = daysToDisplayShiftHandoversOnPriorityPage;
            DaysToDisplayTargetAlertsOnPriorityPage = daysToDisplayTargetAlertsOnPriorityPage;
            DisplayActionItemWorkAssignmentOnPriorityPage = displayActionItemWorkAssignmentOnPriorityPage;
            DisplayActionItemCommentOnly = displayActionItemCommentOnly;

            DefaultNumberOfCopiesForWorkPermits = defaultNumberOfCopiesForWorkPermits;

            ShowFollowupOnLogForm = showFollowupOnLogForm;
            AllowCreateALogForEachSelectedFlocOnLogForm = allowCreateALogForEachSelectedFlocOnLogForm;
            ShowAdditionalDetailsOnLogFormByDefault = showAdditionalDetailsOnLogFormByDefault;
            Culture = culture;
            AtLeastOneRoleCanCreateLogDefinitions = atLeastOneRoleCanCreateLogDefinitions;

            ShowWorkPermitPrintingTabInPreferences = showWorkPermitPrinitingTabInPreferences;
            ShowNumberOfCopiesOnWorkPermitPrintingPreferencesTab = showNumberOfCopiesOnWorkPermitPrintingPreferencesTab;
            AllowCombinedShiftHandoverAndLog = allowCombinedShiftHandoverAndLog;
            ShowCreateShiftHandoverMessageFromNewLogClick = showCreateShiftHandoverMessageFromNewLogClick;
            ShowDefaultPermitTimesTabInPreferences = showDefaultPermitTimesTabInPreferences;

            LoginFlocSelectionLevel = loginFlocSelectionLevel;
            ItemFlocSelectionLevel = itemFlocSelectionLevel;

            UseCreatedByColumnForLogs = useCreatedByColumnForLogs;
            ShowIsModifiedColumnForLogs = showIsModifiedColumnForLogs;

            DefaultSelectedFlocsToLoginFlocsForShiftLogsAndSummaryLogs =defaultSelectedFlocsToLoginFlocsForShiftLogsAndSummaryLogs;
            DefaultSelectedFlocsToLoginFlocsForDirectivesAndLogDefinitionsAndStandingOrders = defaultSelectedFlocsToLoginFlocsForDirectivesAndLogDefinitionsAndStandingOrders;
            DaysToDisplayFormsBackwardsOnPriorityPage = daysToDisplayFormsBackwardsOnPriorityPage;
            FormsFlocSetType = formsFlocSetType;

            PreShiftPaddingInMinutes = preShiftPaddingInMinutes;
            PostShiftPaddingInMinutes = postShiftPaddingInMinutes;

            DaysToDisplayIncompleteActionItemsBackwardsOnPriorityPage =daysToDisplayIncompleteActionItemsBackwardsOnPriorityPage;

            DefaultTargetDefinitionRequiresResponseWhenAlertedValue = defaultTargetDefinitionRequiresResponseWhenAlertedValue;

            CollectAnalyticsData = collectAnalyticsData;
            UseLogBasedDirectives = useLogBasedDirectives;

            ShowNumberOfTurnaroundCopiesOnWorkPermitPrintingPreferencesTab =showNumberOfTurnaroundCopiesOnWorkPermitPrintingPreferencesTab;
            RememberActionItemWorkAssignment = rememberActionItemWorkAssignment;
            MaximumDirectiveFlocLevel = maximumDirectiveFlocLevel;

            MaximumAllowableExcursionEventDurationMins = maximumAllowableExcursionEventDurationMins;
            MaximumAllowableExcursionEventTimeframeMins = maximumAllowableExcursionEventTimeframeMins;

            //FLOC Sturure  Level changes- control the display level for every site for the settings ---implemented by Sarika
            ActionItemFlocLevel= actionItemFlocLevel;
           ShiftLogFlocLevel= shiftLogFlocLevel;
            ShiftHandoverFlocLevel= shiftHandoverFlocLevel;

            AllowCustomFieldsToBePartOfAddShiftInfo = allowCustomFieldsToBePartOfAddShiftInfo; //RITM0164968 - mangesh
            AllowEditingOfOldLogs = allowEditingOfOldLogs; // RITM0221979 Changing edit feature in OLT logs- UDS only
            EnableCSDMarkAsRead = enableCSDMarkAsRead; /*RITM0265746 - Sarnia CSD marked as read start*/
            SoundAlertforActionItemDirectiveEventsTargets = soundAlertforActionItemDirectiveEventsTargets; //// DMND0010264 : Sound alert for ActionItem, Directives, Events and Targets
            ShiftHandoverAlert = shiftHandoverAlert; //RITM0387753-Shift Handover creation alert:Aarti
            EnableShiftHandoverAlert = enableShiftHandoverAlert;//RITM0387753-Shift Handover creation alert:Aarti
            EnableLogsFromOtherUsers = enableLogsFromOtherUsers;//RITM0377367-Enable logs from other users
        }

        public bool RememberActionItemWorkAssignment { get; set; }
        public int DaysToDisplayCokerCards { set; get; }
        public int DaysToDisplayActionItems { set; get; }
        public int DaysToDisplayShiftLogs { set; get; }
        public int DaysToDisplayShiftHandovers { get; set; }
        public int DaysToDisplayDeviationAlerts { set; get; }
        public int DaysToDisplayWorkPermitsBackwards { set; get; }
        public int DaysToDisplayWorkPermitsForwards { set; get; }
        public int DaysToDisplayLabAlerts { set; get; }
        public int DaysToDisplayPermitRequestsBackwards { set; get; }
        public int DaysToDisplayPermitRequestsForwards { set; get; }

        public int DaysToEditDeviationAlerts { set; get; }

        public int DaysBeforeArchivingClosedWorkPermits { set; get; }

        public int DaysBeforeDeletingPendingWorkPermits { set; get; }

        public int DaysBeforeClosingIssuedWorkPermits { set; get; }

        public bool AutoApproveWorkOrderActionItemDefinition { get; set; }

        public bool AutoApproveSAPAMActionItemDefinition { get; set; }

        public bool AutoApproveSAPMCActionItemDefinition { get; set; }

        [Browsable(false)]
        public ActionItemDefinitionAutoReApprovalConfiguration ActionItemDefinitionAutoReApprovalConfiguration { get;
            private set; }

        public int LabAlertRetryAttemptLimit { set; get; }

        [Browsable(false)]
        public TargetDefinitionAutoReApprovalConfiguration TargetDefinitionAutoReApprovalConfiguration { get;
            private set; }

        public bool CreateOperatingEngineerLogs { get; set; }

        public string OperatingEngineerLogDisplayName { get; set; }

        public bool WorkPermitNotApplicableAutoSelected { get; set; }

        public bool WorkPermitOptionAutoSelected { get; set; }

        public int SummaryLogFunctionalLocationDisplayLevel { get; set; }

        public bool AllowStandardLogAtSecondLevelFunctionalLocation { get; set; }

        [Browsable(false)]
        public Time DorEditCutoffTime { get; private set; }

        public string DorEditCutoffTimeString
        {
            get { return DorEditCutoffTime.ToString(); }
            set
            {
                DateTime result;
                var parseSucceeded = DateTime.TryParse(value, out result);
                if (parseSucceeded)
                {
                    DorEditCutoffTime = new Time(result);
                }
            }
        }

        public bool HideDORCommentEntry { get; set; }

        public bool RequireLogForActionItemResponse { get; set; }

        public bool ActionItemRequiresApprovalDefaultValue { get; set; }

        public bool ActionItemRequiresResponseDefaultValue { get; set; }

        public bool ShowActionItemsOnShiftHandover { get; set; }

        public bool UseNewPriorityPage { get; set; }
        public bool ShowShiftHandoversByWorkAssignmentOnPriorityPage { get; set; }
        public bool ShowActionItemsByWorkAssignmentOnPriorityPage { get; set; }
        public bool ShowReadingByWorkAssignmentOnPriorityPage { get; set; }    //ayman action item reading
        public int DaysToDisplayDirectivesOnPriorityPage { get; set; }
        public int DaysToDisplayShiftHandoversOnPriorityPage { get; set; }
        public int DaysToDisplayTargetAlertsOnPriorityPage { get; set; }
        public int DaysToDisplayFormsBackwardsOnPriorityPage { get; set; }
        public int DaysToDisplayDocumentSuggestionFormsBackwardsOnPriorityPage { get; set; }
        public int? DaysToDisplayIncompleteActionItemsBackwardsOnPriorityPage { get; set; }
        public int? DaysToDisplayIncompleteReadingBackwardsOnPriorityPage { get; set; }           //ayman action item reading

        public bool DefaultTargetDefinitionRequiresResponseWhenAlertedValue { get; set; }

        [Browsable(false)]
        public FunctionalLocationSetType FormsFlocSetType { get; set; }

        public long FormsFlocSetTypeId
        {
            get { return FormsFlocSetType.IdValue; }

            set { FormsFlocSetType = FunctionalLocationSetType.GetById(value); }
        }

        public bool DisplayActionItemWorkAssignmentOnPriorityPage { get; set; }
        public bool DisplayActionItemCommentOnly { get; set; }

        public int DefaultNumberOfCopiesForWorkPermits { get; set; }

        public bool ShowFollowupOnLogForm { get; set; }
        public bool AllowCreateALogForEachSelectedFlocOnLogForm { get; set; }
        public bool ShowAdditionalDetailsOnLogFormByDefault { get; set; }

        [Browsable(false)]
        public bool AtLeastOneRoleCanCreateLogDefinitions { get; private set; }

        public bool ShowWorkPermitPrintingTabInPreferences { get; set; }
        public bool ShowNumberOfCopiesOnWorkPermitPrintingPreferencesTab { get; set; }
        public bool ShowNumberOfTurnaroundCopiesOnWorkPermitPrintingPreferencesTab { get; set; }
        public bool ShowDefaultPermitTimesTabInPreferences { get; set; }

        public string Culture { get; set; }
        public bool AllowCombinedShiftHandoverAndLog { get; set; }
        public bool ShowCreateShiftHandoverMessageFromNewLogClick { get; set; }

        public int LoginFlocSelectionLevel { get; set; }
        public int ItemFlocSelectionLevel { get; set; }

        public bool UseCreatedByColumnForLogs { get; set; }
        public bool ShowIsModifiedColumnForLogs { get; set; }

        [Browsable(false)]
        public bool AllowLoginFlocSelectionUpToSeventhLevel
        {
            get { return LoginFlocSelectionLevel == 7; }
        }

        [Browsable(false)]
        public bool AllowLoginFlocSelectionUpToFifthLevel
        {
            get { return LoginFlocSelectionLevel == 5; }
        }

        [Browsable(false)]
        public bool AllowLoginFlocSelectionUpToThirdLevel
        {
            get { return LoginFlocSelectionLevel == 3; }
        }

        public bool DefaultSelectedFlocsToLoginFlocsForShiftLogsAndSummaryLogs { get; set; }
        public bool DefaultSelectedFlocsToLoginFlocsForDirectivesAndLogDefinitionsAndStandingOrders { get; set; }

        public int DaysToDisplayFormsBackwards { get; set; }
        public int? DaysToDisplayFormsForwards { get; set; }

        public int DaysToDisplayDocumentSuggestionFormsBackwards { get; set; }
        public int? DaysToDisplayDocumentSuggestionFormsForwards { get; set; }

        public int DaysToDisplaySAPNotificationsBackwards { get; set; }
        public int DaysToDisplayDirectivesBackwards { get; set; }
        public int? DaysToDisplayDirectivesForwards { get; set; }

        public int PreShiftPaddingInMinutes { get; set; }
        public int PostShiftPaddingInMinutes { get; set; }

        public bool CollectAnalyticsData { get; set; }
        public bool UseLogBasedDirectives { get; set; }
        public int MaximumDirectiveFlocLevel { get; set; }

        public int MaximumAllowableExcursionEventDurationMins { get; set; }
        public int MaximumAllowableExcursionEventTimeframeMins { get; set; }
        public int? DaysToDisplayEventsBackwards { get; set; }

        //FLOC STRUTURE LEVEL CHANGES-control the display level for every site for the settings--Implemented by Sarika
        public int ActionItemFlocLevel { get; set; }
        public int ShiftLogFlocLevel { get; set; }
        public int  ShiftHandoverFlocLevel { get; set; }

        public bool AllowCustomFieldsToBePartOfAddShiftInfo { get; set; } //RITM0164968 mangesh
        public bool AllowEditingOfOldLogs { get; set; } // RITM0221979 Changing edit feature in OLT logs- UDS only

        public bool AllowAdminToCreateAndEditPastDateLog { get; set; } // By Vibhor : RITM0272920  
        public bool AllowToDisplayActionItemTitleOnPriorityPage { get; set; } // RITM0360089 : Added By Vibhor

    
        public bool EnableCSDMarkAsRead { get; set; } /*RITM0265746 - Sarnia CSD marked as read start*/
        public bool SoundAlertforActionItemDirectiveEventsTargets { get; set; } // DMND0010264 : Sound alert for ActionItem, Directives, Events and Targets
        public int? ShiftHandoverAlert { get; set; } //RITM0387753-Shift Handover creation alert:Aarti
        public bool EnableShiftHandoverAlert { get; set; }//RITM0387753-Shift Handover creation alert:Aarti
        public bool EnableLogsFromOtherUsers { get; set; }//RITM0377367-Enable Logs from other users:Aarti
        //Mukesh-DMND0010634:: OLT - Cont Mgmt - Adding pictures to Shift Logs/ Shift Summary Log
        public bool EnableLogImage { get; set; } //RITM0265710 - mangesh
        public string LogImagePath { get; set; } //RITM0265710 - mangesh


        public bool EnableActionItemImage { get; set; } //RITM0467567 : Added by Vibhor OLT - Adding Pictures on Action item and Directives
        public bool EnableDirectiveImage { get; set; } //RITM0467567 : Added by Vibhor OLT - Adding Pictures on Action item and Directives

        public bool EnableRoundInfo { get; set; } //Added by Mukesh for Operator Round Tool Demand. 
        public bool EnableWorkPermitSignature { get; set; } //Added by Mukesh

        public bool EnableTemplateFeatureForWorkPermit { get; set; }

        public int RefreshCSDOnPriorityPage { get; set; }

// Added By Vibhor - RITM0632893 : Add a section with a question that could trigger a flag in the dashboard when an operator answer yes.

        public string SetWorkPermitQuestionForMudsSite { get; set; }

        

        }
}