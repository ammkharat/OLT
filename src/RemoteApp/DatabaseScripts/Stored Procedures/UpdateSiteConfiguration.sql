
IF EXISTS (SELECT * FROM sysobjects WHERE type = 'P' AND name = 'UpdateSiteConfiguration')
	BEGIN
		DROP PROCEDURE [dbo].[UpdateSiteConfiguration]
	END
	
GO

CREATE Procedure [dbo].[UpdateSiteConfiguration]        
 (        
 @SiteId bigint,         
 @DaysToDisplayActionItems [int],        
 @DaysToDisplayShiftLogs [int],        
 @DaysBeforeArchivingClosedWorkPermits [int],        
 @DaysBeforeDeletingPendingWorkPermits [int],        
 @DaysBeforeClosingIssuedWorkPermits [int],        
 @AutoApproveWorkOrderActionItemDefinition [bit],        
 @AutoApproveSAPAMActionItemDefinition [bit],        
 @AutoApproveSAPMCActionItemDefinition [bit],        
 @CreateOperatingEngineerLogs [bit],        
 @WorkPermitNotApplicableAutoSelected [bit],        
 @WorkPermitOptionAutoSelected [bit],        
 @OperatingEngineerLogDisplayName [varchar](100),        
 @DaysToEditDeviationAlerts [int],        
 @DaysToDisplayShiftHandovers [int],        
 @SummaryLogFunctionalLocationDisplayLevel [int],        
 @ShowActionItemsByWorkAssignmentOnPriorityPage [bit],        
 @DaysToDisplayDeviationAlerts [int],        
 @AllowStandardLogAtSecondLevelFunctionalLocation [bit],        
 @DorCutoffTime [datetime],        
 @DaysToDisplayWorkPermitsBackwards [int],        
 @DaysToDisplayLabAlerts [int],        
 @LabAlertRetryAttemptLimit [int],        
 @RequireActionItemResponseLog [bit],        
 @ActionItemRequiresApprovalDefaultValue [bit],        
 @HideDORCommentEntry [bit],        
 @DaysToDisplayCokerCards [int],        
 @ActionItemRequiresResponseDefaultValue [bit],        
 @ShowActionItemsOnShiftHandover [bit],        
 @UseNewPriorityPage [bit],        
 @ShowShiftHandoversByWorkAssignmentOnPriorityPage [bit],        
 @DaysToDisplayDirectivesOnPriorityPage [int],        
 @DaysToDisplayShiftHandoversOnPriorityPage [int],        
 @DisplayActionItemWorkAssignmentOnPriorityPage [bit],        
 @DaysToDisplayPermitRequestsBackwards [int],        
 @DaysToDisplayPermitRequestsForwards [int],        
 @DaysToDisplayWorkPermitsForwards [int],        
 @DisplayActionItemCommentOnly [bit],        
 @DefaultNumberOfCopiesForWorkPermits [int],        
 @ShowFollowupOnLogForm [bit],        
 @AllowCreateALogForEachSelectedFlocOnLogForm [bit],        
 @ShowAdditionalDetailsOnLogFormByDefault [bit],        
 @Culture [varchar](5),        
 @ShowWorkPermitPrintingTabInPreferences [bit],        
 @ShowDefaulPermitTimesTabInPreferences [bit],        
 @DaysToDisplayTargetAlertsOnPriorityPage [int],        
 @LoginFlocSelectionLevel [int],        
 @UseCreatedByColumnForLogs [bit],        
 @ShowIsModifiedColumnForLogs [bit],        
 @ItemFlocSelectionLevel [int],        
 @DefaultSelectedFlocsToLoginFlocsForShiftLogsAndSummaryLogs [bit],        
 @PreShiftPaddingInMinutes [int],        
 @PostShiftPaddingInMinutes [int],        
 @DaysToDisplayFormsBackwards [int],        
 @DaysToDisplayFormsForwards [int] = NULL,        
 @DefaultSelectedFlocsToLoginFlocsForDirectivesAndLogDefinitionsAndStandingOrders [bit],        
 @DaysToDisplayFormsBackwardsOnPriorityPage [int],        
 @FormsFlocSetTypeId [int],        
 @DaysToDisplaySAPNotificationsBackwards [int],        
 @ShowNumberOfCopiesOnWorkPermitPrintingPreferencesTab [bit],        
 @AllowCombinedShiftHandoverAndLog [bit],        
 @ShowCreateShiftHandoverMessageFromNewLogClick [bit],        
 @DaysToDisplayIncompleteActionItemsBackwardsOnPriorityPage int = NULL,        
 @DefaultTargetDefinitionRequiresResponseWhenAlertedValue bit,        
 @CollectAnalyticsData bit,        
 @UseLogBasedDirectives bit,         
 @ShowNumberOfTurnaroundCopiesOnWorkPermitPrintingPreferencesTab bit,         
 @RememberActionItemWorkAssignment bit,        
 @MaximumDirectiveFLOClevel [int],        
 @MaximumAllowableExcursionEventDurationMins [int],        
 @MaximumAllowableExcursionEventTimeframeMins [int],        
 @DaysToDisplayDocumentSuggestionFormsBackwards [int],        
 @DaysToDisplayDocumentSuggestionFormsForwards [int],        
 @DaysToDisplayDocumentSuggestionFormsBackwardsOnPriorityPage [int],        
 @ActionItemFlocLevel [int],        
 @ShiftLogFlocLevel [int],        
 @ShiftHandoverFlocLevel [int],        
 @AllowCustomFieldsToBePartOfAddShiftInfo [bit], --RITM0164968 - mangesh       
 @AllowEditingOfOldLogs [bit], -- RITM0221979 amit      
 @EnableCSDMarkAsRead [bit] ,-- /*RITM0265746 - Sarnia CSD marked as read start*/ amit    
 @AllowAdminToCreateAndEditPastDateLog bit=0, -- Vibhor : RITM0272920     
 @AllowToDisplayActionItemTitleOnPriorityPage bit=0, -- RITM0360089 : Added By Vibhor    
 @ShiftHandoverAlert [int],--RITM0387753-Shift Handover creation alert:Aarti    
 @EnableShiftHandoverAlert [bit],--RITM0387753-Shift Handover creation alert:Aarti    
 @EnableLogsFromOtherUsers [bit], --RITM0377367:Aarti    
 --@AllowToDisplayEveryShiftOnActionItemDefinitionForm [bit], -- //RITM0265710 - mangesh    
 @SoundAlertforActionItemDirectiveEventsTargets bit=0 -- DMND0010264 : Sound alert for ActionItem, Directives, Events and Targets  
 --Mukesh-DMND0010634:: OLT - Cont Mgmt - Adding pictures to Shift Logs/ Shift Summary Log  
 ,@LogImagePath varchar(500)  
 ,@EnableLogImage bit  
  
 ,@EnableActionItemImage bit = 0  --vibhor action item and directive images  
 ,@EnableDirectiveImage bit = 0  --vibhor action item and directive images  
 ,@EnableRoundInfo bit=0 ---For OperatorRound  
 ,@EnableWorkPermitSignature bit=0 --For Work Permit Signature
 ,@EnableTemplateFeatureForWorkPermit bit=0 --Added By Vibhor 
 , @RefreshCSDOnPriorityPage [int]
 , @SetWorkPermitQuestionForMudsSite varchar(max)
 
 )        
AS        
         
 UPDATE        
   [dbo].SiteConfiguration        
 SET        
  DaysToDisplayActionItems = @DaysToDisplayActionItems,        
 DaysToDisplayShiftLogs = @DaysToDisplayShiftLogs,        
 DaysBeforeArchivingClosedWorkPermits = @DaysBeforeArchivingClosedWorkPermits,        
 DaysBeforeDeletingPendingWorkPermits = @DaysBeforeDeletingPendingWorkPermits,        
 DaysBeforeClosingIssuedWorkPermits = @DaysBeforeClosingIssuedWorkPermits,        
 AutoApproveWorkOrderActionItemDefinition = @AutoApproveWorkOrderActionItemDefinition,        
 AutoApproveSAPAMActionItemDefinition = @AutoApproveSAPAMActionItemDefinition,        
 AutoApproveSAPMCActionItemDefinition = @AutoApproveSAPMCActionItemDefinition,        
 CreateOperatingEngineerLogs = @CreateOperatingEngineerLogs,        
 WorkPermitNotApplicableAutoSelected = @WorkPermitNotApplicableAutoSelected,        
 WorkPermitOptionAutoSelected = @WorkPermitOptionAutoSelected,        
 OperatingEngineerLogDisplayName = @OperatingEngineerLogDisplayName,        
 DaysToEditDeviationAlerts = @DaysToEditDeviationAlerts,        
 DaysToDisplayShiftHandovers = @DaysToDisplayShiftHandovers,        
 SummaryLogFunctionalLocationDisplayLevel = @SummaryLogFunctionalLocationDisplayLevel,        
 ShowActionItemsByWorkAssignmentOnPriorityPage = @ShowActionItemsByWorkAssignmentOnPriorityPage,        
 DaysToDisplayDeviationAlerts = @DaysToDisplayDeviationAlerts,        
 AllowStandardLogAtSecondLevelFunctionalLocation = @AllowStandardLogAtSecondLevelFunctionalLocation,        
 DorCutoffTime = @DorCutoffTime,        
 DaysToDisplayWorkPermitsBackwards = @DaysToDisplayWorkPermitsBackwards,        
 DaysToDisplayLabAlerts = @DaysToDisplayLabAlerts,        
 LabAlertRetryAttemptLimit = @LabAlertRetryAttemptLimit,        
 RequireActionItemResponseLog = @RequireActionItemResponseLog,        
 ActionItemRequiresApprovalDefaultValue = @ActionItemRequiresApprovalDefaultValue,        
 HideDORCommentEntry = @HideDORCommentEntry,        
 DaysToDisplayCokerCards = @DaysToDisplayCokerCards,        
 ActionItemRequiresResponseDefaultValue = @ActionItemRequiresResponseDefaultValue,        
 ShowActionItemsOnShiftHandover = @ShowActionItemsOnShiftHandover,        
 UseNewPriorityPage = @UseNewPriorityPage,        
 ShowShiftHandoversByWorkAssignmentOnPriorityPage = @ShowShiftHandoversByWorkAssignmentOnPriorityPage,        
 DaysToDisplayDirectivesOnPriorityPage = @DaysToDisplayDirectivesOnPriorityPage,        
 DaysToDisplayShiftHandoversOnPriorityPage = @DaysToDisplayShiftHandoversOnPriorityPage,        
 DisplayActionItemWorkAssignmentOnPriorityPage = @DisplayActionItemWorkAssignmentOnPriorityPage,        
 DaysToDisplayPermitRequestsBackwards = @DaysToDisplayPermitRequestsBackwards,        
 DaysToDisplayPermitRequestsForwards = @DaysToDisplayPermitRequestsForwards,        
 DaysToDisplayWorkPermitsForwards = @DaysToDisplayWorkPermitsForwards,        
 DisplayActionItemCommentOnly = @DisplayActionItemCommentOnly,        
 DefaultNumberOfCopiesForWorkPermits = @DefaultNumberOfCopiesForWorkPermits,        
 ShowFollowupOnLogForm = @ShowFollowupOnLogForm,        
 AllowCreateALogForEachSelectedFlocOnLogForm = @AllowCreateALogForEachSelectedFlocOnLogForm,        
 ShowAdditionalDetailsOnLogFormByDefault = @ShowAdditionalDetailsOnLogFormByDefault,        
 Culture = @Culture,        
 ShowWorkPermitPrintingTabInPreferences = @ShowWorkPermitPrintingTabInPreferences,        
 ShowDefaulPermitTimesTabInPreferences = @ShowDefaulPermitTimesTabInPreferences,        
 DaysToDisplayTargetAlertsOnPriorityPage = @DaysToDisplayTargetAlertsOnPriorityPage,        
 LoginFlocSelectionLevel = @LoginFlocSelectionLevel,        
 UseCreatedByColumnForLogs = @UseCreatedByColumnForLogs,        
 ShowIsModifiedColumnForLogs = @ShowIsModifiedColumnForLogs,        
 ItemFlocSelectionLevel = @ItemFlocSelectionLevel,        
 DefaultSelectedFlocsToLoginFlocsForShiftLogsAndSummaryLogs = @DefaultSelectedFlocsToLoginFlocsForShiftLogsAndSummaryLogs,        
 PreShiftPaddingInMinutes = @PreShiftPaddingInMinutes,        
 PostShiftPaddingInMinutes = @PostShiftPaddingInMinutes,        
 DaysToDisplayFormsBackwards = @DaysToDisplayFormsBackwards,        
 DaysToDisplayFormsForwards = @DaysToDisplayFormsForwards,        
 DefaultSelectedFlocsToLoginFlocsForDirectivesAndLogDefinitionsAndStandingOrders = @DefaultSelectedFlocsToLoginFlocsForDirectivesAndLogDefinitionsAndStandingOrders,        
 DaysToDisplayFormsBackwardsOnPriorityPage = @DaysToDisplayFormsBackwardsOnPriorityPage,        
 FormsFlocSetTypeId = @FormsFlocSetTypeId,        
 DaysToDisplaySAPNotificationsBackwards = @DaysToDisplaySAPNotificationsBackwards,        
 ShowNumberOfCopiesOnWorkPermitPrintingPreferencesTab = @ShowNumberOfCopiesOnWorkPermitPrintingPreferencesTab,        
 AllowCombinedShiftHandoverAndLog = @AllowCombinedShiftHandoverAndLog,        
 ShowCreateShiftHandoverMessageFromNewLogClick = @ShowCreateShiftHandoverMessageFromNewLogClick,        
 DaysToDisplayIncompleteActionItemsBackwardsOnPriorityPage = @DaysToDisplayIncompleteActionItemsBackwardsOnPriorityPage,        
 DefaultTargetDefinitionRequiresResponseWhenAlertedValue = @DefaultTargetDefinitionRequiresResponseWhenAlertedValue,        
 CollectAnalyticsData = @CollectAnalyticsData,        
 UseLogBasedDirectives = @UseLogBasedDirectives,        
 ShowNumberOfTurnaroundCopiesOnWorkPermitPrintingPreferencesTab = @ShowNumberOfTurnaroundCopiesOnWorkPermitPrintingPreferencesTab,        
 RememberActionItemWorkAssignment = @RememberActionItemWorkAssignment,        
 MaximumDirectiveFLOClevel = @MaximumDirectiveFLOClevel,        
 MaximumAllowableExcursionEventDurationMins = @MaximumAllowableExcursionEventDurationMins,        
 MaximumAllowableExcursionEventTimeframeMins = @MaximumAllowableExcursionEventTimeframeMins,        
 DaysToDisplayDocumentSuggestionFormsBackwards = @DaysToDisplayDocumentSuggestionFormsBackwards,        
 DaysToDisplayDocumentSuggestionFormsForwards = @DaysToDisplayDocumentSuggestionFormsForwards,        
    DaysToDisplayDocumentSuggestionFormsBackwardsOnPriorityPage = @DaysToDisplayDocumentSuggestionFormsBackwardsOnPriorityPage,        
 ActionItemFlocLevel = @ActionItemFlocLevel,        
 ShiftLogFlocLevel = @ShiftLogFlocLevel ,        
 ShiftHandoverFlocLevel = @ShiftHandoverFlocLevel,        
 AllowCustomFieldsToBePartOfAddShiftInfo = @AllowCustomFieldsToBePartOfAddShiftInfo, -- RITM0164968 mangesh      
 AllowEditingOfOldLogs=@AllowEditingOfOldLogs, -- RITM0221979 amit     
 EnableCSDMarkAsRead = @EnableCSDMarkAsRead ,  --/*RITM0265746 - Sarnia CSD marked as read start*/    
AllowAdminToCreateAndEditPastDateLog=@AllowAdminToCreateAndEditPastDateLog, -- Vibhor : RITM0272920     
AllowToDisplayActionItemTitleOnPriorityPage=@AllowToDisplayActionItemTitleOnPriorityPage,  -- RITM0360089 : Added By Vibhor    
ShiftHandoverAlert=@ShiftHandoverAlert,--RITM0387753-Shift Handover creation alert:Aarti    
EnableShiftHandoverAlert=@EnableShiftHandoverAlert,--RITM0387753-Shift Handover creation alert:Aarti    
EnableLogsFromOtherUsers=@EnableLogsFromOtherUsers, --RITM0377367 Aarti    
--AllowToDisplayEveryShiftOnActionItemDefinitionForm = @AllowToDisplayEveryShiftOnActionItemDefinitionForm,  --RITM0265710 - mangesh    
SoundAlertforActionItemDirectiveEventsTargets=@SoundAlertforActionItemDirectiveEventsTargets --DMND0010264 Sound alert for ActionItem, Directives, Events, and Targets  
--Mukesh-DMND0010634:: OLT - Cont Mgmt - Adding pictures to Shift Logs/ Shift Summary Log  
,LogImagePath=@LogImagePath   
,EnableLogImage=@EnableLogImage   
  
,EnableActionItemImage = @EnableActionItemImage --vibhor action item and directive images  
 ,EnableDirectiveImage = @EnableDirectiveImage --vibhor action item and directive images  
 ,EnableRoundInfo=@EnableRoundInfo  
 ,EnableWorkPermitSignature=@EnableWorkPermitSignature
 ,EnableTemplateFeatureForWorkPermit=@EnableTemplateFeatureForWorkPermit -- Added By Vibhor


 ,RefreshCSDOnPriorityPage=@RefreshCSDOnPriorityPage -- Added By Vibhor

 , SetWorkPermitQuestionForMudsSite = @SetWorkPermitQuestionForMudsSite
 
WHERE          
 SiteId = @SiteId        
        
GRANT EXEC ON UpdateSiteConfiguration TO PUBLIC        