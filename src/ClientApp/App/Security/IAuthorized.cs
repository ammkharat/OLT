using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.DTO;
using Infragistics.Win.UltraWinSpellChecker;

namespace Com.Suncor.Olt.Client.Security
{
    public interface IAuthorized
    {
        bool ToViewLogsNavigation(UserRoleElements userRoleElements);
        bool ToViewLogs(UserRoleElements userRoleElements);
        bool ToCreateLogs(UserRoleElements userRoleElements);
        bool ToEditLog(LogDTO dto, UserContext userContext);
        bool ToDeleteLogs(List<LogDTO> dtos, UserContext userContext);
        bool ToDeleteLog(LogDTO dto, UserContext userContext);
        bool ToReplyToLog(UserRoleElements userRoleElements);
        bool ToCancelReoccuringLogs(List<LogDTO> dtos, UserContext userContext);
        bool ToCancelReoccuringLog(LogDTO dto, UserContext userContext);
        bool ToMarkLogsAsRead(User user, LogDTO log);
        bool ToCopyLogs(UserRoleElements userRoleElements);
        bool ToViewOperatingEngineerLogs(UserRoleElements userRoleElements);
        bool ToAddShiftInformation(UserRoleElements userRoleElements);

        bool ToViewSummaryLogs(UserRoleElements userRoleElements);
        bool ToCreateSummaryLogs(UserRoleElements userRoleElements);
        bool ToEditSummaryLog(SummaryLogDTO log, UserContext userContext);

        bool ToEditDORComments(UserRoleElements userRoleElements, UserShift userShift, SummaryLogDTO log,
            Time dorEditCutoffHour);

        bool ToDeleteSummaryLogs(List<SummaryLogDTO> dtos, UserContext userContext);
        bool ToMarkSummaryLogsAsRead(User user, SummaryLogDTO dto);

        // NEW Directives
        bool ToViewDirectivesOnPrioritiesPage(UserRoleElements userRoleElements);
        bool ToViewDirectiveNavigation(UserRoleElements userRoleElements);
        bool ToViewFutureDirectives(UserRoleElements userRoleElements);
        bool ToViewDirectives(UserRoleElements userRoleElements);
        bool ToCreateDirectives(UserRoleElements userRoleElements);
        bool ToEditDirective(DirectiveDTO dto, UserContext userContext, DateTime now);
        bool ToDeleteDirectives(List<DirectiveDTO> dtos, UserContext userContext, DateTime now);
        bool ToExpireDirective(DirectiveDTO dto, UserContext userContext, DateTime now);
        bool ToExpireDirectives(List<DirectiveDTO> dtos, UserContext userContext, DateTime now);
        bool ToMarkDirectiveAsRead(User user, DirectiveDTO dto, DateTime now);

        // OLD Log-based Directives
        bool ToViewDirectiveLogsOnPrioritiesPage(UserRoleElements userRoleElements);
        bool ToViewDirectiveLogs(UserRoleElements userRoleElements);
        bool ToEditDirectiveLogs(LogDTO dto, UserContext userContext);
        bool ToCreateDirectiveLogs(UserRoleElements userRoleElements);
        bool ToReplyToDirectiveLogs(UserRoleElements userRoleElements);
        bool ToDeleteDirectiveLogs(List<LogDTO> dtos, UserContext userContext);
        bool ToCopyDirectiveLogs(UserRoleElements userRoleElements);

        bool ToViewLogDefinitions(UserRoleElements userRoleElements);
        bool ToCreateLogDefinition(UserRoleElements userRoleElements);
        bool ToEditLogDefinition(LogDefinitionDTO dto, UserContext userContext);
        bool ToCancelLogDefinitions(List<LogDefinitionDTO> dtos, UserContext userContext);
        bool ToEditLogDefinitionsFlaggedAsOperatingEngineerLog(UserRoleElements userRoleElements);

        bool ToViewStandingOrders(UserRoleElements userRoleElements);
        bool ToEditStandingOrders(LogDefinitionDTO dto, UserContext userContext);
        bool ToCancelStandingOrders(List<LogDefinitionDTO> dtos, UserContext userContext);

        bool ToViewTargetsNavigation(UserRoleElements userRoleElements);
        bool ToCreateTargets(UserRoleElements userRoleElements);
        bool ToViewTargetAlerts(UserRoleElements userRoleElements);
        bool ToViewTargetDefinitions(UserRoleElements userRoleElements);
        bool ToViewTargetsOnPrioritiesPage(UserRoleElements userRoleElements);
        bool ToDeleteTargetDefinitions(UserRoleElements userRoleElements, List<TargetDefinitionDTO> targets);
        bool ToDeleteTargetDefinition(UserRoleElements userRoleElements, TargetDefinitionDTO target);
        bool ToEditTargetTargetDefinition(UserRoleElements userRoleElements, TargetDefinitionDTO target);
        bool ToApproveTargetDefinition(UserRoleElements userRoleElements, TargetDefinitionDTO target);
        bool ToApproveTargetDefinitions(UserRoleElements userRoleElements, List<TargetDefinitionDTO> target);
        bool ToAutoApproveTargetDefinition(UserRoleElements userRoleElements);

        bool ToRejectTargetDefinition(UserRoleElements userRoleElements, TargetDefinitionDTO target);
        bool ToRejectTargetDefinitions(UserRoleElements userRoleElements, List<TargetDefinitionDTO> target);
        bool ToChangeApprovalForTargetDefinitions(UserRoleElements userRoleElements);
        bool ToCommentTargetDefinition(UserRoleElements userRoleElements, TargetDefinitionDTO target);

        bool ToAcknowledgeTargetAlerts(UserRoleElements userRoleElements, List<TargetAlertDTO> targetAlertDTOs);
        bool ToRespondToTargetAlerts(UserRoleElements userRoleElements);

        bool ToViewRestrictionNavigation(UserRoleElements userRoleElements);
        bool ToViewRestrictionReporting(UserRoleElements userRoleElements);
        bool ToCreateRestrictionDefinitions(UserRoleElements userRoleElements);

        bool ToDeleteRestrictionDefinitions(UserRoleElements userRoleElements,
            List<RestrictionDefinitionDTO> restrictionDefinitionDtos);

        bool ToEditRestrictionDefinition(UserRoleElements userRoleElements,
            RestrictionDefinitionDTO restrictionDefinitionDtos);

        bool ToRespondToDeviationAlerts(UserRoleElements userRoleElements, UserShift shift, DeviationAlertDTO alert);
        // Right now, if the user can edit deviatin alert comments, that's ALL they can do on that screen (Dustin, Oct 2010)
        bool ToEditDeviationAlertComments(UserRoleElements userRoleElements);

        bool ToConfigureBusinessCategories(UserRoleElements userRoleElements);
        bool ToConfigureLogTemplates(UserRoleElements userRoleElements);
        bool ToConfigureBusinessCategoryFlocAssociations(UserRoleElements userRoleElements);
        bool ToConfigureRestrictionReasonCode(UserRoleElements userRoleElements);
        bool ToConfigureDeviationAlertResponseTimeLimit(UserRoleElements userRoleElements);

        bool ToViewActionItemDefinitions(UserRoleElements userRoleElements);
        bool ToCreateActionItemDefinitions(UserRoleElements userRoleElements);
//        bool ToCreateReadingDefinitions(UserRoleElements userRoleElements);        //ayman action item reading

        bool ToDeleteActionItemDefinitions(UserRoleElements userRoleElements,
            List<ActionItemDefinitionDTO> actionItemDefinitionDTOs);

        bool ToDeleteActionItemDefinitions(UserRoleElements userRoleElements,
            ActionItemDefinitionDTO actionItemDefinitionDTO);

        bool ToEditActionItemDefinition(UserRoleElements userRoleElements,
            ActionItemDefinitionDTO actionItemDefinitionDTO);

        bool ToApproveActionItemDefinitions(UserRoleElements userRoleElements,
            List<ActionItemDefinitionDTO> actionItemDefinitionDTOs);

        bool ToApproveActionItemDefinitions(UserRoleElements userRoleElements,
            ActionItemDefinitionDTO actionItemDefinitionDTO);

        bool ToAutoApproveActionItemDefinition(UserRoleElements userRoleElements);

        bool ToRejectActionItemDefinitions(UserRoleElements userRoleElements,
            List<ActionItemDefinitionDTO> actionItemDefinitionDTOs);

        bool ToRejectActionItemDefinitions(UserRoleElements userRoleElements,
            ActionItemDefinitionDTO actionItemDefinitionDTO);

        bool ToCommentActionItemDefinition(UserRoleElements userRoleElements,
            ActionItemDefinitionDTO actionItemDefinitionDTO);

        bool ToViewActionItemsOnPrioritiesPage(UserRoleElements userRoleElements);
        bool ToViewReadingOnPrioritiesPage(UserRoleElements userRoleElements);            //ayman action item reading
        bool ToViewActionItemsNavigation(UserRoleElements userRoleElements);
        bool ToViewReadingNavigation(UserRoleElements userRoleElements);                 //ayman action item reading
//        bool ToViewReadingDefinitions(UserRoleElements userRoleElements);                 //ayman action item reading
        bool ToViewActionItems(UserRoleElements userRoleElements);
        bool ToViewReading(UserRoleElements userRoleElements);                           //ayman action item reading
        bool ToRespondActionItem(UserRoleElements userRoleElements, ActionItemDTO actionItem);

        bool ToViewWorkPermits(UserRoleElements userRoleElements);
        bool ToViewWorkPermitsOnThePrioritiesPage(UserRoleElements userRoleElements);
        bool ToViewWorkPermitsNavigation(UserRoleElements userRoleElements);
        bool ToCreateWorkPermits(UserRoleElements userRoleElements);
//        bool ToCreateWorkPermitsWithSomeRestrictions(UserRoleElements userRoleElements);
        bool ToCreateWorkPermitsWithNoRestriction(UserRoleElements userRoleElements);
        bool ToApproveWorkPermit(UserRoleElements userRoleElements, UserShift userShift, WorkPermit workPermit);
        bool ToApproveWorkPermits(UserRoleElements userRoleElements, UserShift userShift, List<WorkPermit> workPermits);
        bool ToRejectWorkPermit(UserRoleElements userRoleElements, WorkPermit workPermit);
        bool ToRejectWorkPermits(UserRoleElements userRoleElements, List<WorkPermit> workPermits);
        bool ToCloseWorkPermit(UserRoleElements userRoleElements, WorkPermit workPermit);
        bool ToCloseWorkPermits(UserRoleElements userRoleElements, List<WorkPermit> workPermit);
        bool ToDeleteWorkPermit(UserRoleElements userRoleElements, WorkPermit workPermit);
        bool ToDeleteWorkPermits(UserRoleElements userRoleElements, List<WorkPermit> workPermits);
        bool ToEditWorkPermit(UserRoleElements userRoleElements, WorkPermit workPermits);
//        bool ToEditWorkPermitWithNoRestriction(UserRoleElements userRoleElements);
        bool ToEditNonOpsWorkPermit(UserRoleElements userRoleElements);
        bool ToFullyValidateWorkPermit(UserRoleElements userRoleElements);
        bool ToPrintWorkPermit(UserRoleElements userRoleElements, UserShift userShift, WorkPermit workPermit);
        bool ToPrintWorkPermits(UserRoleElements userRoleElements, UserShift userShift, List<WorkPermit> workPermits);
        bool ToPrintPreviewWorkPermit(UserRoleElements userRoleElements, UserShift shift, WorkPermit item);
        bool ToCloneWorkPermitWithSomeRestrictions(UserRoleElements userRoleElements);
        bool ToCloneWorkPermitWithNoRestriction(UserRoleElements userRoleElements);

        bool ToMarkTemplateForClone(UserRoleElements userRoleElements);  //Added By Vibhor : DMND0010779 : OLT - Templateeasy clone

        bool ToCloneActionItem(UserRoleElements userRoleElements);  

        bool ToCopyWorkPermitWithSomeRestrictions(UserRoleElements userRoleElements);
        bool ToCopyWorkPermitWithNoRestriction(UserRoleElements userRoleElements);
        bool ToCommentWorkPermit(UserRoleElements userRoleElements);

        bool ToCopyToWorkPermit(UserRoleElements userRoleElements, WorkPermit destinationWorkPermit,
            WorkPermit sourceWorkPermit);

        bool ToEditWorkPermit(UserRoleElements userRoleElements, WorkPermitMontrealDTO workPermit);
        bool ToDeleteWorkPermits(UserRoleElements userRoleElements, List<WorkPermitMontrealDTO> workPermits);
        bool ToCloseWorkPermits(UserRoleElements userRoleElements, List<WorkPermitMontrealDTO> workPermits);
        bool ToPrintWorkPermits(UserRoleElements userRoleElements, List<WorkPermitMontrealDTO> workPermits);
        bool ToPrintWorkPermit(UserRoleElements userRoleElements, WorkPermitMontrealDTO workPermit);

        bool ToEditWorkPermit(UserRoleElements userRoleElements, WorkPermitEdmontonDTO selectedItem);
        bool ToDeleteWorkPermits(UserRoleElements userRoleElements, List<WorkPermitEdmontonDTO> workPermits);
        bool ToCloseWorkPermits(UserRoleElements userRoleElements, List<WorkPermitEdmontonDTO> workPermits);

        bool ToEditWorkPermit(UserRoleElements userRoleElements, WorkPermitLubesDTO selectedItem);
        bool ToDeleteWorkPermits(UserRoleElements userRoleElements, List<WorkPermitLubesDTO> workPermits);
        bool ToPrintWorkPermits(UserRoleElements userRoleElements, List<WorkPermitLubesDTO> workPermits);
        bool ToPrintWorkPermit(UserRoleElements userRoleElements, WorkPermitLubesDTO workPermit);
        bool ToCloseWorkPermits(UserRoleElements userRoleElements, List<WorkPermitLubesDTO> workPermits);

        bool ToViewPermitRequests(UserRoleElements userRoleElements);
        bool ToCreatePermitRequest(UserRoleElements userRoleElements);
        bool ToEditPermitRequest(UserRoleElements userRoleElements, List<PermitRequestEdmontonDTO> dtos);
        bool ToEditPermitRequest(UserRoleElements userRoleElements, List<PermitRequestMontrealDTO> dtos, User user);
        bool ToEditPermitRequest(UserRoleElements userRoleElements, List<PermitRequestMudsDTO> dtos, User user); //RITM0301321 mangesh
        bool ToEditPermitRequest(UserContext userContext, PermitRequestLubesDTO dto);
        bool ToDeletePermitRequest(UserRoleElements userRoleElements, List<BasePermitRequestDTO> dtos, User user);
        bool ToDeletePermitRequests(UserContext userContext, List<PermitRequestLubesDTO> dtos);
        bool ToSubmitPermitRequest(UserRoleElements userRoleElements);
        bool ToImportPermitRequests(UserRoleElements userRoleElements);
        bool ToClonePermitRequest(UserRoleElements userRoleElements);

        bool ToViewSAPNotifications(UserRoleElements userRoleElements);
        bool ToProcessSAPNotfications(UserRoleElements userRoleElements, List<SAPNotificationDTO> sapNotificationDTOs);
        bool ToProcessSAPNotfication(UserRoleElements userRoleElements, SAPNotificationDTO sapNotificationDTO);

        bool ToConfigureGasTestElementLimits(UserRoleElements userRoleElements);
        bool ToManageOperationalModes(UserRoleElements userRoleElements);
        bool ToConfigureDisplayLimits(UserRoleElements userRoleElements);
        bool ToConfigureSiteCommunications(UserRoleElements userRoleElements);
        bool ToConfigureDefaultTabs(UserRoleElements userRoleElements);
        bool ToConfigureWorkAssignmentNotSelectedWarning(UserRoleElements userRoleElements);
        bool ToConfigureLabAlerts(UserRoleElements userRoleElements);
        bool ToConfigureLinks(UserRoleElements userRoleElements);
        bool ToConfigureWorkPermitArchivalProcess(UserRoleElements userRoleElements);
        bool ToConfigureAutoApproveSAPActionItemDefinition(UserRoleElements userRoleElements);
        bool ToConfigureWorkPermitContractor(UserRoleElements userRoleElements);
        bool ToConfigurePlantHistorianTagList(UserRoleElements userRoleElements);
        bool ToConfigureCraftOrTrade(UserRoleElements userRoleElements);
        bool ToConfigureRoadAccessOnPermit(UserRoleElements userRoleElements);
        bool ToConfigureSpecialWork(UserRoleElements userRoleElements);
        bool ToConfigureWorkAssignments(UserRoleElements userRoleElements);
        bool ToConfigureAutoReApprovalByField(UserRoleElements userRoleElements);
        bool ToConfigurePreApprovedTargetRanges(UserRoleElements userRoleElements);
        bool ToConfigureDefaultFLOCsForAssignments(UserRoleElements userRoleElements);
        bool ToConfigureDefaultFLOCsForAssignmentsForPermitAutoAssignment(UserRoleElements userRoleElements);
        bool ToConfigureAssignmentsForPermits(UserRoleElements userRoleElements);
        bool ToConfigureLogGuidelines(UserRoleElements userRoleElements);
        bool ToConfigureCustomFields(UserRoleElements userRoleElements);
        bool ToConfigureDORCutoffTime(UserRoleElements userRoleElements);

        bool ToViewShiftHandover(UserRoleElements userRoleElements);
        bool ToViewShiftHandoverNavigation(UserRoleElements userRoleElements);
        bool ToViewShiftHandoverOnPrioritiesPage(UserRoleElements userRoleElements);
        bool ToCreateShiftHandoverQuestionnaire(UserRoleElements userRoleElements);

        bool ToEditShiftHandoverQuestionnaire(
            User user,
            UserRoleElements userRoleElements,
            UserShift userShift,
            ShiftHandoverQuestionnaireDTO dto);

        bool ToDeleteShiftHandoverQuestionnaire(
            User user,
            UserRoleElements userRoleElements,
            UserShift userShift,
            List<ShiftHandoverQuestionnaireDTO> dtos);

        bool ToEditShiftHandoverConfigurations(UserRoleElements userRoleElements);
        bool ToEditShiftHandoverEmailConfigurations(UserRoleElements userRoleElements);
        bool ToMarkShiftHandoverQuestionnairesAsRead(User user, ShiftHandoverQuestionnaireDTO dto);

        bool ToViewLabAlertsNavigation(UserRoleElements userRoleElements);
        bool ToViewLabAlertDefinitionsAndLabAlerts(UserRoleElements userRoleElements);
        bool ToCreateLabAlertDefinitions(UserRoleElements userRoleElements);
        bool ToDeleteLabAlertDefinitions(UserRoleElements userRoleElements, List<LabAlertDefinitionDTO> dtos);
        bool ToEditLabAlertDefinition(UserRoleElements userRoleElements, LabAlertDefinitionDTO dto);
        bool ToRespondToLabAlerts(UserRoleElements userRoleElements);

        bool ToViewCokerCards(UserRoleElements userRoleElements);
        bool ToCreateCokerCard(UserRoleElements userRoleElements);
        bool ToEditCokerCard(CokerCardDTO cokerCardDto, UserRoleElements userRoleElements, UserShift userShift);
        bool ToDeleteCokerCards(List<CokerCardDTO> cokerCardDtos, UserRoleElements userRoleElements, UserShift userShift);
        bool ToEditCokerCardConfigurations(UserRoleElements userRoleElements);

        bool ToConfigurePrioritiesPage(UserRoleElements userRoleElements);
        bool ToConfigureWorkPermitMontrealTemplates(UserRoleElements userRoleElements);
        bool ToConfigureWorkPermitDropdowns(UserRoleElements userRoleElements);
        bool ToConfigureWorkPermitGroups(UserRoleElements userRoleElements);
        bool ToConfigureConfiguredDocumentLinks(UserRoleElements userRoleElements);

        bool ToCreateConfinedSpace(UserRoleElements userRoleElements);
        bool ToViewConfinedSpaceDocuments(UserRoleElements userRoleElements);
        bool ToEditConfinedSpace(UserRoleElements userRoleElements, ConfinedSpaceDTO confinedSpaceDto);
        bool ToDeleteConfinedSpace(UserRoleElements userRoleElements, List<ConfinedSpaceDTO> dtos);
        bool ToPrintConfinedSpace(UserRoleElements userRoleElements);
        //RITM0301321- mangesh - we can use existing role elements
        bool ToEditConfinedSpace(UserRoleElements userRoleElements, ConfinedSpaceMudsDTO confinedSpaceDto);
        bool ToDeleteConfinedSpace(UserRoleElements userRoleElements, List<ConfinedSpaceMudsDTO> dtos);

        bool ToPrintWorkPermits(UserRoleElements userRoleElements, List<WorkPermitEdmontonDTO> selectedItems);
        bool ToPrintWorkPermit(UserRoleElements userRoleElements, WorkPermitEdmontonDTO selectedItem);

        bool ToViewForm(UserRoleElements userRoleElements);
        bool ToViewFormNavigation(UserRoleElements userRoleElements);
        bool ToViewFormsOnThePrioritiesPage(UserRoleElements userRoleElements);
        bool ToViewFormOP14sOnPrioritiesPage(UserRoleElements userRoleElements);
        bool ToCreateForms(UserRoleElements userRoleElements, Site usersSite);

        //ayman training form 
        bool ToCreateTrainingForm(UserRoleElements userRoleElements, Site usersSite);

        //ayman reports
        bool ToViewFormReport(UserRoleElements userRoleElements);
        bool ToViewTrainingFormExcel(UserRoleElements userRoleElements);
        bool ToViewTrainingFormReport(UserRoleElements userRoleElements);
        bool ToViewSWPAssessmentReport(UserRoleElements userRoleElements);

        bool ToDeleteForm(UserRoleElements userRoleElements);
        bool ToEditForm(UserRoleElements userRoleElements);
        bool ToEditEdmontonForm(UserRoleElements userRoleElements, FormStatus formStatus, EdmontonFormType formType);
        bool ToEditFormGN1(UserRoleElements userRoleElements, FormStatus formStatus);
        bool ToEditFormGN7(UserRoleElements userRoleElements, FormStatus formStatus);
        bool ToEditFormGN59(UserRoleElements userRoleElements, FormStatus formStatus);
        bool ToEditFormOP14(UserRoleElements userRoleElements, FormStatus formStatus);
        bool ToEditFormGN24(UserRoleElements userRoleElements, FormStatus formStatus);
        bool ToEditFormGN6(UserRoleElements userRoleElements, FormStatus formStatus);
        bool ToEditFormGN75B(UserRoleElements userRoleElements, FormStatus formStatus);
        bool ToEditForm(UserContext userContext, FormOilsandsTrainingDTO dto);
        bool ToViewOvertimeForm(UserRoleElements userRoleElements);
        bool ToCreateOvertimeForm(UserRoleElements userRoleElements);
        bool ToCreateLubesCsdForm(UserRoleElements userRoleElements);
        bool ToEditOvertimeForm(UserRoleElements userRoleElements, FormStatus formStatus);
        bool ToDeleteOilsandsTrainingForm(UserContext userContext, FormOilsandsTrainingDTO dto);
        bool ToApproveOilsandsTrainingForm(UserRoleElements userRoleElements);
        bool ToConfigureFormTemplates(UserRoleElements userRoleElements);
        bool ToConfigureTrainingBlocks(UserRoleElements userRoleElements);
        bool ToChangeEndDateOfGN59WithNoReapprovalRequired(UserRoleElements userRoleElements);
        bool ToChangeEndDateOfGN24WithNoReapprovalRequired(UserRoleElements userRoleElements);
        bool ToConfigureFormDropdowns(UserRoleElements userRoleElements);

        // Document Suggestion Forms
        bool ToViewDocumentSuggestionOnPrioritiesPage(UserRoleElements userRoleElements, long siteId);
        bool ToCreateFormDocumentSuggestion(UserRoleElements userRoleElements, long siteId);
        bool ToEditFormDocumentSuggestion(UserRoleElements userRoleElements, long siteId);
        bool ToApproveFormDocumentSuggestion(UserRoleElements userRoleElements, long siteId);
        bool ToDeleteFormDocumentSuggestion(UserRoleElements userRoleElements, long siteId);

        // Operating Procedure Deviation Forms
        bool ToViewProcedureDeviationOnPrioritiesPage(UserRoleElements userRoleElements, long siteId);
        bool ToCreateFormProcedureDeviation(UserRoleElements userRoleElements, long siteId);
        bool ToEditFormProcedureDeviation(UserRoleElements userRoleElements, long siteId);
        bool ToApproveFormProcedureDeviation(UserRoleElements userRoleElements, long siteId);
        bool ToDeleteFormProcedureDeviation(UserRoleElements userRoleElements, long siteId);

        bool ToConfigureAreaLabels(UserRoleElements userRoleElements);
        bool ToPerformTechnicalAdminTasks(UserRoleElements userRoleElements);
        bool ToPrintWorkPermitsInGeneral(UserRoleElements userRoleElements);

        bool ToConfigureFunctionalLocations(UserRoleElements userRoleElements);
        bool ToApproveOvertimeForm(UserRoleElements userRoleElements);
        bool ToViewOnPremisePersonnelNavigation(UserRoleElements userRoleElements);
        bool ToEditFormLubesCsd(UserRoleElements userRoleElements, FormStatus formStatus);
        bool ToViewLubeCsdsOnPrioritiesPage(UserRoleElements userRoleElements);
        bool ToDeleteLubesCsdForms(UserRoleElements userRoleElements, List<LubesCsdFormDTO> selectedItems);
        bool ToCloseLubesCsdForms(UserRoleElements userRoleElements, List<LubesCsdFormDTO> selectedItems);
        bool ToEditMontrealCsd(UserRoleElements userRoleElements, FormStatus status);
        bool ToCreateMontrealCsdForm(UserRoleElements userRoleElements);
        bool ToViewMontrealCsdsOnPrioritiesPage(UserRoleElements userRoleElements);
        bool ToDeleteMontrealCsd(UserRoleElements userRoleElements, List<MontrealCsdDTO> selectedItems );
        bool ToCloseMontrealCsdForms(UserRoleElements userRoleElements, List<MontrealCsdDTO> selectedItems);

        //DMND0011225 OLT - CSD for WBR
        bool ToEditGenericCsd(UserRoleElements userRoleElements, FormStatus status);
        bool ToCreateGenericCsdForm(UserRoleElements userRoleElements);
        bool ToViewGenericCsdsOnPrioritiesPage(UserRoleElements userRoleElements);
        bool ToDeleteGenericCsd(UserRoleElements userRoleElements, List<GenericCsdDTO> selectedItems);
        bool ToCloseGenericCsdForms(UserRoleElements userRoleElements, List<GenericCsdDTO> selectedItems);
        
        
        //RITM0268131 - mangesh
        bool ToEditMudsTemporaryInstallations(UserRoleElements userRoleElements, FormStatus status);
        bool ToCreateMudsTemporaryInstallationsForm(UserRoleElements userRoleElements);
        bool ToViewMudsTemporaryInstallationsOnPrioritiesPage(UserRoleElements userRoleElements);
        bool ToDeleteMudsTemporaryInstallations(UserRoleElements userRoleElements);
        bool ToApproveOrCloseMudsTemporaryInstallationsForms(UserRoleElements userRoleElements);

        //RITM0301321 - mangesh
        bool ToEditWorkPermit(UserRoleElements userRoleElements, WorkPermitMudsDTO workPermit);
        bool ToDeleteWorkPermits(UserRoleElements userRoleElements, List<WorkPermitMudsDTO> workPermits);
        bool ToCloseWorkPermits(UserRoleElements userRoleElements, List<WorkPermitMudsDTO> workPermits);
        bool ToPrintWorkPermits(UserRoleElements userRoleElements, List<WorkPermitMudsDTO> workPermits);
        bool ToPrintWorkPermit(UserRoleElements userRoleElements, WorkPermitMudsDTO workPermit);

        bool ToCreateLubesAlarmDisableForm(UserRoleElements userRoleElements);
        bool ToCloseLubesAlarmDisableForms(UserRoleElements userRoleElements, List<LubesAlarmDisableFormDTO> selectedItems);
        bool ToDeleteLubesAlarmDisableForms(UserRoleElements userRoleElements, List<LubesAlarmDisableFormDTO> selectedItems);
        bool ToEditFormLubesAlarmDisable(UserRoleElements userRoleElements, FormStatus status);

        bool ToApproveLubesCsdLeadTech(UserRoleElements userRoleElements);
        bool ToApproveLubesCsdProcessEngineer(UserRoleElements userRoleElements);
        bool ToApproveLubesCsdAreaTeamLead(UserRoleElements userRoleElements);
        bool ToApproveLubesCsdDirectorOfProduction(UserRoleElements userRoleElements);
        bool ToChangeEndDateOfLubesCsdWithNoReapprovalRequired(UserRoleElements userRoleElements);

        bool ToApproveLubesAlarmDisableLeadTech(UserRoleElements userRoleElements);
        bool ToApproveLubesAlarmDisableSupervisor(UserRoleElements userRoleElements);
        bool ToChangeEndDateOfLubesAlarmDisableWithNoReapprovalRequired(UserRoleElements userRoleElements);
        bool ToCreateFormSafeWorkPermitAuditQuestionnaire(UserRoleElements userRoleElements);
        bool ToEditPermitAssessment(UserRoleElements userRoleElements, PermitAssessmentDTO dto, User currentUser, UserShift userShift);
        bool ToCancelPermitAssessment(UserRoleElements userRoleElements, User user, UserShift userShift, PermitAssessmentDTO dto);
        bool ToAdminSafeWorkPermitQuestionnaires(UserRoleElements userRoleElements);

        bool ToViewEventsNavigation(UserRoleElements userRoleElements);
        bool ToViewEventsOnPrioritiesPage(UserRoleElements userRoleElements);
        bool ToRespondToExcursionEvents(UserRoleElements userRoleElements);

        /// <summary>
        ///     Check whether the userRoleElements has  permission to view action item definitions
        /// </summary>
        bool ToViewFutureActionItemDefinitions(UserRoleElements userRoleElements);

        bool ToConfigureRestrictionFlocsForWorkAssignments(UserRoleElements userRoleElements);

        //generic template - mangesh
        bool ToEditFormGenericTemplate(UserRoleElements userRoleElements, FormStatus formStatus);
        bool ToEditFormGenericTemplate(UserContext userContext, FormStatus formStatus, EdmontonFormType formType, FormGenericTemplateDTO dto);
        bool ToEditFormGenericTemplate(UserRoleElements userRoleElements, FormStatus formStatus, EdmontonFormType formType, Site userSite);
        bool ToDeleteFormGenericTemplate(UserRoleElements userRoleElements, FormStatus formStatus, EdmontonFormType formType, Site userSite);
        bool ToApproveOrCloseFormGenericTemplate(UserRoleElements userRoleElements, FormStatus formStatus, EdmontonFormType formType, Site userSite);
        bool ToCreateFormGenericTemplate(UserRoleElements userRoleElements, FormStatus formStatus, EdmontonFormType formType, Site userSite);
        bool ToViewFormGenericTemplate(UserRoleElements userRoleElements, FormStatus formStatus, EdmontonFormType formType, Site userSite);
        bool ToConfigureEFormTemplatesApproval(UserRoleElements userRoleElements);
        //olt admin list - mangesh
        bool ToConfigureOltCommunity(UserRoleElements userRoleElements);

        //ayman Sarnia eip DMND0008992
        bool ToApproveEipIssue(UserRoleElements userRoleElements);
        bool ToCreateEipIssue(UserRoleElements userRoleElements);
        bool ToEditEipIssue(UserRoleElements userRoleElements);
        bool ToViewEipIssue(UserRoleElements userRoleElements);

        bool ToEditPermitRequest(UserRoleElements userRoleElements, List<PermitRequestFortHillsDTO> dtos);
        bool ToEditWorkPermit(UserRoleElements userRoleElements, WorkPermitFortHillsDTO selectedItem);
        bool ToDeleteWorkPermits(UserRoleElements userRoleElements, List<WorkPermitFortHillsDTO> workPermits);
        bool ToCloseWorkPermits(UserRoleElements userRoleElements, List<WorkPermitFortHillsDTO> workPermits);
        bool ToPrintWorkPermits(UserRoleElements userRoleElements, List<WorkPermitFortHillsDTO> selectedItems);
        bool ToPrintWorkPermit(UserRoleElements userRoleElements, WorkPermitFortHillsDTO selectedItem);
    }
}