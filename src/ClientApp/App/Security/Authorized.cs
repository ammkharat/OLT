using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Domain.Target;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Client.Security
{
    public class Authorized : IAuthorized
    {
        private readonly DirectiveAuthorization directiveAuthorization = new DirectiveAuthorization();

        private readonly FormOilsandsTrainingAuthorization formOilsandsTrainingAuthorization =
            new FormOilsandsTrainingAuthorization();

        private readonly LogAuthorization logAuthorization = new LogAuthorization();

        private readonly LogBasedDirectiveAuthorization logBasedDirectiveAuthorization =
            new LogBasedDirectiveAuthorization();

        private readonly LogDefinitionAuthorization logDefinitionAuthorization = new LogDefinitionAuthorization();

        private readonly PermitRequestLubesAuthorization permitRequestLubesAuthorization =
            new PermitRequestLubesAuthorization();

        private readonly StandingOrderAuthorization standingOrderAuthorization = new StandingOrderAuthorization();
        private readonly SummaryLogAuthorization summaryLogAuthorization = new SummaryLogAuthorization();

        private readonly FormGenericTemplateAuthorization formGenericTemplateAuthorization =
            new FormGenericTemplateAuthorization();

        #region Log Rules

        public bool ToViewLogsNavigation(UserRoleElements userRoleElements)
        {
            return logAuthorization.ToViewNavigation(userRoleElements);
        }

        public bool ToViewLogs(UserRoleElements userRoleElements)
        {
            return logAuthorization.ToView(userRoleElements);
        }

        public bool ToViewOperatingEngineerLogs(UserRoleElements userRoleElements)
        {
            return logAuthorization.ToViewLogsFlaggedAsOperatingEngineerLogs(userRoleElements);
        }

        public bool ToAddShiftInformation(UserRoleElements userRoleElements)
        {
            return logAuthorization.ToAddShiftInformation(userRoleElements);
        }

        public bool ToCreateLogs(UserRoleElements userRoleElements)
        {
            return logAuthorization.ToCreate(userRoleElements);
        }

        public bool ToReplyToLog(UserRoleElements userRoleElements)
        {
            return logAuthorization.ToReplyTo(userRoleElements);
        }

        public bool ToCopyLogs(UserRoleElements userRoleElements)
        {
            return logAuthorization.ToCopy(userRoleElements);
        }

        public bool ToMarkLogsAsRead(User user, LogDTO log)
        {
            return logAuthorization.ToMarkAsRead(log, user);
        }

        public bool ToEditLog(LogDTO dto, UserContext userContext)
        {
            return logAuthorization.ToEdit(dto, userContext);
        }

        public bool ToDeleteLogs(List<LogDTO> dtos, UserContext userContext)
        {
            return logAuthorization.ToDelete(dtos, userContext);
        }

        public bool ToDeleteLog(LogDTO dto, UserContext userContext)
        {
            return logAuthorization.ToDelete(dto, userContext);
        }

        public bool ToCancelReoccuringLogs(List<LogDTO> dtos, UserContext userContext)
        {
            return logAuthorization.ToCancel(dtos, userContext);
        }

        public bool ToCancelReoccuringLog(LogDTO dto, UserContext userContext)
        {
            return logAuthorization.ToCancel(dto, userContext);
        }

        public bool ToViewLogDefinitions(UserRoleElements userRoleElements)
        {
            return logDefinitionAuthorization.ToView(userRoleElements);
        }

        public bool ToCreateLogDefinition(UserRoleElements userRoleElements)
        {
            return logDefinitionAuthorization.ToCreate(userRoleElements);
        }

        public bool ToEditLogDefinition(LogDefinitionDTO logDefinition, UserContext userContext)
        {
            return logDefinitionAuthorization.ToEdit(logDefinition, userContext);
        }

        public bool ToCancelLogDefinitions(List<LogDefinitionDTO> dtos, UserContext userContext)
        {
            return logDefinitionAuthorization.ToCancel(dtos, userContext);
        }

        public bool ToEditLogDefinitionsFlaggedAsOperatingEngineerLog(UserRoleElements userRoleElements)
        {
            return logDefinitionAuthorization.ToEditLogDefinitionsFlaggedAsOperatingEngineerLog(userRoleElements);
        }

        public bool ToViewDirectivesOnPrioritiesPage(UserRoleElements userRoleElements)
        {
            return directiveAuthorization.ToViewOnPrioritesPage(userRoleElements);
        }

        public bool ToViewDirectiveLogsOnPrioritiesPage(UserRoleElements userRoleElements)
        {
            return logBasedDirectiveAuthorization.ToViewOnPrioritesPage(userRoleElements);
        }

        public bool ToViewDirectiveLogs(UserRoleElements userRoleElements)
        {
            return logBasedDirectiveAuthorization.ToView(userRoleElements);
        }

        public bool ToViewDirectives(UserRoleElements userRoleElements)
        {
            return directiveAuthorization.ToView(userRoleElements);
        }

        public bool ToCreateDirectives(UserRoleElements userRoleElements)
        {
            return directiveAuthorization.ToCreate(userRoleElements);
        }

        public bool ToCreateDirectiveLogs(UserRoleElements userRoleElements)
        {
            return logBasedDirectiveAuthorization.ToCreate(userRoleElements);
        }

        public bool ToReplyToDirectiveLogs(UserRoleElements userRoleElements)
        {
            return logBasedDirectiveAuthorization.ToReplyTo(userRoleElements);
        }

        public bool ToCopyDirectiveLogs(UserRoleElements userRoleElements)
        {
            return logBasedDirectiveAuthorization.ToCopy(userRoleElements);
        }

        public bool ToEditDirectiveLogs(LogDTO dto, UserContext userContext)
        {
            return logBasedDirectiveAuthorization.ToEdit(dto, userContext);
        }

        public bool ToDeleteDirectiveLogs(List<LogDTO> dtos, UserContext userContext)
        {
            return logBasedDirectiveAuthorization.ToDelete(dtos, userContext);
        }

        public bool ToViewStandingOrders(UserRoleElements userRoleElements)
        {
            return standingOrderAuthorization.ToView(userRoleElements);
        }

        public bool ToEditStandingOrders(LogDefinitionDTO dto, UserContext userContext)
        {
            return standingOrderAuthorization.ToEdit(dto, userContext);
        }

        public bool ToCancelStandingOrders(List<LogDefinitionDTO> dtos, UserContext userContext)
        {
            return standingOrderAuthorization.ToCancel(dtos, userContext);
        }

        public bool ToViewSummaryLogs(UserRoleElements userRoleElements)
        {
            return summaryLogAuthorization.ToView(userRoleElements);
        }

        public bool ToCreateSummaryLogs(UserRoleElements userRoleElements)
        {
            return summaryLogAuthorization.ToCreate(userRoleElements);
        }

        public bool ToEditSummaryLog(SummaryLogDTO log, UserContext userContext)
        {
            return summaryLogAuthorization.ToEdit(log, userContext);
        }

        public bool ToEditDORComments(UserRoleElements userRoleElements, UserShift userShift, SummaryLogDTO log,
            Time dorEditCutoffHour)
        {
            return SummaryLogAuthorization.ToEditDORComments(userRoleElements, userShift, log, dorEditCutoffHour);
        }

        public bool ToDeleteSummaryLogs(List<SummaryLogDTO> dtos, UserContext userContext)
        {
            return summaryLogAuthorization.ToDelete(dtos, userContext);
        }

        public bool ToMarkSummaryLogsAsRead(User user, SummaryLogDTO dto)
        {
            return summaryLogAuthorization.ToMarkAsRead(dto, user);
        }

        #endregion Log Rules

        #region Target Rules

        /// <summary>
        ///     Check whether the userRoleElements has  permission to create targets
        /// </summary>
        public bool ToCreateTargets(UserRoleElements userRoleElements)
        {
            if (userRoleElements == null)
            {
                return false;
            }
            return userRoleElements.AuthorizedTo(RoleElement.CREATE_TARGETDEFINITION);
        }

        public bool ToViewTargetAlerts(UserRoleElements userRoleElements)
        {
            return userRoleElements != null && userRoleElements.AuthorizedTo(RoleElement.VIEW_TARGET_ALERTS);
        }

        public bool ToViewTargetDefinitions(UserRoleElements userRoleElements)
        {
            return userRoleElements != null && userRoleElements.AuthorizedTo(RoleElement.VIEW_TARGETDEFINITION);
        }

        public bool ToViewTargetsNavigation(UserRoleElements userRoleElements)
        {
            return userRoleElements != null && userRoleElements.AuthorizedTo(RoleElement.VIEW_TARGET_NAVIGATION);
        }

        public bool ToViewTargetsOnPrioritiesPage(UserRoleElements userRoleElements)
        {
            if (userRoleElements == null)
            {
                return false;
            }

            return userRoleElements.AuthorizedTo(RoleElement.VIEW_TARGET_PRIORITIES);
        }

        public bool ToDeleteTargetDefinitions(UserRoleElements userRoleElements,
            List<TargetDefinitionDTO> targetDefinitionDTOs)
        {
            return targetDefinitionDTOs.TrueForAll(target => ToDeleteTargetDefinition(userRoleElements, target));
        }

        /// <summary>
        ///     Check whether the userRoleElements has  permission to delete this target
        /// </summary>
        public bool ToDeleteTargetDefinition(UserRoleElements userRoleElements, TargetDefinitionDTO target)
        {
            if (userRoleElements == null || target == null)
            {
                return false;
            }
            return userRoleElements.AuthorizedTo(RoleElement.DELETE_TARGETDEFINITION);
        }

        /// <summary>
        ///     Check whether the userRoleElements has  permission to edit this target
        /// </summary>
        public bool ToEditTargetTargetDefinition(UserRoleElements userRoleElements, TargetDefinitionDTO target)
        {
            if (userRoleElements == null || target == null)
            {
                return false;
            }
            return userRoleElements.AuthorizedTo(RoleElement.EDIT_TARGETDEFINITION);
        }

        public bool ToApproveTargetDefinitions(UserRoleElements userRoleElements,
            List<TargetDefinitionDTO> targetDefinitionDTOs)
        {
            return targetDefinitionDTOs.TrueForAll(
                targetDefinitionDTO => ToApproveTargetDefinition(userRoleElements, targetDefinitionDTO));
        }

        /// <summary>
        ///     Check whether the userRoleElements has  permission to approve this target
        /// </summary>
        public bool ToApproveTargetDefinition(UserRoleElements userRoleElements, TargetDefinitionDTO target)
        {
            if (userRoleElements == null || target == null)
            {
                return false;
            }
            return userRoleElements.AuthorizedTo(RoleElement.APPROVE_TARGETDEFINITION) &&
                   (TargetDefinitionStatus.Pending.IdValue == target.StatusId);
        }

        public bool ToAutoApproveTargetDefinition(UserRoleElements userRoleElements)
        {
            if (userRoleElements == null)
                return false;
            return userRoleElements.AuthorizedTo(RoleElement.APPROVE_TARGETDEFINITION);
        }

        public bool ToRejectTargetDefinitions(UserRoleElements userRoleElements,
            List<TargetDefinitionDTO> targetDefinitionDTOs)
        {
            return targetDefinitionDTOs.TrueForAll(target => ToRejectTargetDefinition(userRoleElements, target));
        }

        /// <summary>
        ///     Check whether the userRoleElements has  permission to reject this target
        /// </summary>
        public bool ToRejectTargetDefinition(UserRoleElements userRoleElements, TargetDefinitionDTO target)
        {
            if (userRoleElements == null || target == null)
            {
                return false;
            }
            return
                TargetDefinitionStatus.Pending.IdValue == target.StatusId &&
                userRoleElements.AuthorizedTo(RoleElement.REJECT_TARGETDEFINITION);
        }

        /// <summary>
        ///     Check whether the userRoleElements has  permission to comment on this target definition
        /// </summary>
        public bool ToCommentTargetDefinition(UserRoleElements userRoleElements, TargetDefinitionDTO target)
        {
            if (userRoleElements == null || target == null)
            {
                return false;
            }
            return userRoleElements.AuthorizedTo(RoleElement.REVIEW_TARGETDEFINITION);
        }

        /// <summary>
        ///     Check whether the userRoleElements has  permission to change the requiement of approvals for targets
        /// </summary>
        public bool ToChangeApprovalForTargetDefinitions(UserRoleElements userRoleElements)
        {
            if (userRoleElements == null)
            {
                return false;
            }
            return userRoleElements.AuthorizedTo(RoleElement.TOGGLE_TARGETDEFINITION_APPROVAL_REQUIRED);
        }

        public bool ToRespondToTargetAlerts(UserRoleElements userRoleElements)
        {
            return userRoleElements.AuthorizedTo(RoleElement.RESPOND_TO_TARGET_ALERTS);
        }

        public bool ToAcknowledgeTargetAlerts(UserRoleElements userRoleElements, List<TargetAlertDTO> targetAlertDTOs)
        {
            // This can use the respond role Element - verified by Troy and Eric
            return ToRespondToTargetAlerts(userRoleElements)
                   && AreTargetAlertsValidToAcknowledge(targetAlertDTOs);
        }

        public bool ToToggleApprovalRequiredForTargetDefinition(UserRoleElements userRoleElements)
        {
            if (userRoleElements == null)
            {
                return false;
            }
            return userRoleElements.AuthorizedTo(RoleElement.TOGGLE_TARGETDEFINITION_APPROVAL_REQUIRED);
        }

        private static bool AreTargetAlertsValidToAcknowledge(List<TargetAlertDTO> targetAlerts)
        {
            if (targetAlerts.Count > 1)
            {
                return targetAlerts.TrueForAll(
                    dto => dto.Status != TargetAlertStatus.Acknowledged && !dto.ResponseRequiredAsBool);
            }
            return targetAlerts.TrueForAll(dto => dto.Status != TargetAlertStatus.Acknowledged);
        }

        #endregion Target Rules

        #region Action Items Rules

        public bool ToViewActionItems(UserRoleElements userRoleElements)
        {
            if (userRoleElements == null)
            {
                return false;
            }
            return userRoleElements.AuthorizedTo(RoleElement.VIEW_ACTIONITEM);
        }

        //ayman action item reading
        public bool ToViewReading(UserRoleElements userRoleElements)
        {
            if (userRoleElements == null)
            {
                return false;
            }
            return userRoleElements.AuthorizedTo(RoleElement.VIEW_READING);
        }

        public bool ToViewActionItemsNavigation(UserRoleElements userRoleElements)
        {
            return userRoleElements != null && userRoleElements.AuthorizedTo(RoleElement.VIEW_ACTIONITEM_NAVIGATION);
        }

        //ayman action item reading
        public bool ToViewReadingNavigation(UserRoleElements userRoleElements)
        {
            return userRoleElements != null && userRoleElements.AuthorizedTo(RoleElement.VIEW_READING_NAVIGATION);
        }

        public bool ToViewActionItemsOnPrioritiesPage(UserRoleElements userRoleElements)
        {
            if (userRoleElements == null)
            {
                return false;
            }

            return userRoleElements.AuthorizedTo(RoleElement.VIEW_ACTIONITEM_PRIORITIES);
        }

        //ayman action item reading
        public bool ToViewReadingOnPrioritiesPage(UserRoleElements userRoleElements)
        {
            if (userRoleElements == null)
            {
                return false;
            }

            return userRoleElements.AuthorizedTo(RoleElement.VIEW_READING_PRIORITIES);
        }

        public bool ToRespondActionItem(UserRoleElements userRoleElements, ActionItemDTO actionItem)
        {
            if (userRoleElements == null || actionItem == null)
            {
                return false;
            }
            return userRoleElements.AuthorizedTo(RoleElement.RESPOND_ACTIONITEM);
        }

        #endregion

        #region Action Item Definition Rules

        /// <summary>
        ///     Check whether the userRoleElements has  permission to create action item definitions
        /// </summary>
        public bool ToCreateActionItemDefinitions(UserRoleElements userRoleElements)
        {
            if (userRoleElements == null)
            {
                return false;
            }
            return userRoleElements.AuthorizedTo(RoleElement.CREATE_ACTIONITEMDEFINITION);
        }


        /// <summary>
        ///     Check whether the userRoleElements has  permission to view action item definitions
        /// </summary>
        public bool ToViewActionItemDefinitions(UserRoleElements userRoleElements)
        {
            if (userRoleElements == null)
            {
                return false;
            }
            return userRoleElements.AuthorizedTo(RoleElement.VIEW_ACTIONITEMDEFINITION);
        }

        /// <summary>
        ///     Check whether the userRoleElements has  permission to view action item definitions
        /// </summary>
        public bool ToViewFutureActionItemDefinitions(UserRoleElements userRoleElements)
        {
            if (userRoleElements == null)
            {
                return false;
            }
            return userRoleElements.AuthorizedTo(RoleElement.VIEW_FUTUREACTIONITEMS);
        }

        public bool ToDeleteActionItemDefinitions(UserRoleElements userRoleElements,
            List<ActionItemDefinitionDTO> actionItemDefinitionDTOs)
        {
            return actionItemDefinitionDTOs.TrueForAll(
                actionItemDefinitionDTO => ToDeleteActionItemDefinitions(userRoleElements, actionItemDefinitionDTO));
        }

        /// <summary>
        ///     Check whether the userRoleElements has  permission to delete this action item definition
        /// </summary>
        public bool ToDeleteActionItemDefinitions(UserRoleElements userRoleElements,
            ActionItemDefinitionDTO actionItemDefinitionDTO)
        {
            if (userRoleElements == null || actionItemDefinitionDTO == null)
            {
                return false;
            }
            return userRoleElements.AuthorizedTo(RoleElement.DELETE_ACTIONITEMDEFINITION);
        }

        /// <summary>
        ///     Check whether the userRoleElements has  permission to edit this action item definition
        /// </summary>
        public bool ToEditActionItemDefinition(UserRoleElements userRoleElements,
            ActionItemDefinitionDTO actionItemDefinitionDTO)
        {
            if (userRoleElements == null || actionItemDefinitionDTO == null)
            {
                return false;
            }
            return userRoleElements.AuthorizedTo(RoleElement.EDIT_ACTIONITEMDEFINITION);
        }

        public bool ToApproveActionItemDefinitions(UserRoleElements userRoleElements,
            List<ActionItemDefinitionDTO> actionItemDefinitionDTOs)
        {
            return
                actionItemDefinitionDTOs.TrueForAll(
                    actionItemDefinition => ToApproveActionItemDefinitions(userRoleElements,
                        actionItemDefinition));
        }

        /// <summary>
        ///     Check whether the userRoleElements has permission to approve this action item definition
        /// </summary>
        public bool ToApproveActionItemDefinitions(UserRoleElements userRoleElements,
            ActionItemDefinitionDTO actionItemDefinitionDTO)
        {
            if (userRoleElements == null || actionItemDefinitionDTO == null)
            {
                return false;
            }
            return userRoleElements.AuthorizedTo(RoleElement.APPROVE_ACTIONITEMDEFINITION) &&
                   (actionItemDefinitionDTO.IsPending);
        }

        public bool ToAutoApproveActionItemDefinition(UserRoleElements userRoleElements)
        {
            if (userRoleElements == null)
                return false;
            return userRoleElements.AuthorizedTo(RoleElement.APPROVE_ACTIONITEMDEFINITION);
        }

        public bool ToRejectActionItemDefinitions(UserRoleElements userRoleElements,
            List<ActionItemDefinitionDTO> actionItemDefinitionDTOs)
        {
            return
                actionItemDefinitionDTOs.TrueForAll(
                    actionItemDefinitionDTO => ToRejectActionItemDefinitions(userRoleElements,
                        actionItemDefinitionDTO));
        }

        /// <summary>
        ///     Check whether the userRoleElements has  permission to reject this action item definition
        /// </summary>
        public bool ToRejectActionItemDefinitions(UserRoleElements userRoleElements,
            ActionItemDefinitionDTO actionItemDefinitionDTO)
        {
            if (userRoleElements == null || actionItemDefinitionDTO == null)
            {
                return false;
            }
            return userRoleElements.AuthorizedTo(RoleElement.REJECT_ACTIONITEMDEFINITION) &&
                   actionItemDefinitionDTO.IsPending;
        }

        /// <summary>
        ///     Check whether the userRoleElements has  permission to comment this action item definition
        /// </summary>
        public bool ToCommentActionItemDefinition(UserRoleElements userRoleElements,
            ActionItemDefinitionDTO actionItemDefinitionDTO)
        {
            if (userRoleElements == null || actionItemDefinitionDTO == null)
            {
                return false;
            }
            return userRoleElements.AuthorizedTo(RoleElement.COMMENT_ACTIONITEMDEFINITION);
        }

        public bool ToToggleApprovalRequiredForActionItemDefinition(UserRoleElements userRoleElements)
        {
            if (userRoleElements == null)
            {
                return false;
            }
            return userRoleElements.AuthorizedTo(RoleElement.TOGGLE_ACTIONITEMDEFINITION_APPROVAL_REQUIRED);
        }

        #endregion Action Item Defintion Rules

        #region Work Permit Rules

        public bool ToViewWorkPermits(UserRoleElements userRoleElements)
        {
            return userRoleElements != null && userRoleElements.AuthorizedTo(RoleElement.VIEW_PERMIT);
        }

        public bool ToViewWorkPermitsOnThePrioritiesPage(UserRoleElements userRoleElements)
        {
            return userRoleElements != null && userRoleElements.AuthorizedTo(RoleElement.VIEW_PERMIT_PRIORITIES);
        }

        public bool ToViewWorkPermitsNavigation(UserRoleElements userRoleElements)
        {
            return userRoleElements != null && userRoleElements.AuthorizedTo(RoleElement.VIEW_PERMIT_NAVIGATION);
        }

        public bool ToCreateWorkPermits(UserRoleElements userRoleElements)
        {
            return userRoleElements != null && userRoleElements.AuthorizedTo(RoleElement.CREATE_PERMIT);
        }

        public bool ToCreateWorkPermitsWithNoRestriction(UserRoleElements userRoleElements)
        {
            return ToCreateWorkPermits(userRoleElements) &&
                   (userRoleElements.NotAuthorizedTo(RoleElement.COPY_PERMIT_WITH_SOME_RESTRICTIONS)
                    ||
                    userRoleElements.NotAuthorizedTo(RoleElement.CLONE_PERMIT_WITH_SOME_RESTRICTIONS));
        }

        public bool ToApproveWorkPermits(UserRoleElements userRoleElements, UserShift userShift,
            List<WorkPermit> workPermits)
        {
            return CanUserApproveWorkPermits(userRoleElements, userShift, workPermits);
        }

        public bool ToApproveWorkPermit(UserRoleElements userRoleElements, UserShift userShift, WorkPermit workPermit)
        {
            if (userRoleElements == null || workPermit == null || userShift == null || workPermit.IsAtLeastApproved)
            {
                return false;
            }

            if (userRoleElements.AuthorizedTo(RoleElement.APPROVE_NON_OPERATIONS_PERMIT))
            {
                if (workPermit.StartsInUserShift(userShift))
                {
                    return IsNonOperationsIssuerAndPermit(userRoleElements.Role, workPermit);
                }
            }

            if (userRoleElements.AuthorizedTo(RoleElement.APPROVE_PERMIT))
            {
                if (workPermit.StartsInUserShift(userShift))
                {
                    return true;
                }
            }

            return false;
        }

        public bool ToRejectWorkPermits(UserRoleElements userRoleElements, List<WorkPermit> workPermits)
        {
            return workPermits.TrueForAll(permit => ToRejectWorkPermit(userRoleElements, permit));
        }

        public bool ToRejectWorkPermit(UserRoleElements userRoleElements, WorkPermit workPermit)
        {
            if (userRoleElements == null || workPermit == null)
            {
                return false;
            }

            if (workPermit.Is(WorkPermitStatus.Rejected)
                || workPermit.Is(WorkPermitStatus.Approved)
                || workPermit.Is(WorkPermitStatus.Issued)
                || workPermit.Is(WorkPermitStatus.Complete)
                || workPermit.Is(WorkPermitStatus.Archived))
            {
                return false;
            }

            if (userRoleElements.AuthorizedTo(RoleElement.REJECT_NON_OPERATIONS_PERMIT))
            {
                return IsNonOperationsIssuerAndPermit(userRoleElements.Role, workPermit);
            }

            if (userRoleElements.AuthorizedTo(RoleElement.REJECT_PERMIT))
            {
                return true;
            }

            return false;
        }

        public bool ToCloseWorkPermits(UserRoleElements userRoleElements, List<WorkPermit> workPermits)
        {
            return workPermits.TrueForAll(permit => ToCloseWorkPermit(userRoleElements, permit));
        }

        public bool ToCloseWorkPermit(UserRoleElements userRoleElements, WorkPermit workPermit)
        {
            if (userRoleElements == null || workPermit == null)
            {
                return false;
            }

            if (workPermit.Is(WorkPermitStatus.Pending)
                || workPermit.Is(WorkPermitStatus.Rejected)
                || workPermit.Is(WorkPermitStatus.Complete)
                || workPermit.Is(WorkPermitStatus.Archived))
            {
                return false;
            }

            if (userRoleElements.AuthorizedTo(RoleElement.CLOSE_NON_OPERATIONS_PERMIT))
            {
                return IsNonOperationsIssuerAndPermit(userRoleElements.Role, workPermit);
            }

            if (userRoleElements.AuthorizedTo(RoleElement.CLOSE_PERMIT))
            {
                return true;
            }

            return false;
        }

        public bool ToDeleteWorkPermits(UserRoleElements userRoleElements, List<WorkPermit> workPermits)
        {
            return workPermits.TrueForAll(permit => ToDeleteWorkPermit(userRoleElements, permit));
        }

        public bool ToDeleteWorkPermit(UserRoleElements userRoleElements, WorkPermit workPermit)
        {
            if (userRoleElements == null || workPermit == null || workPermit.IsAtLeastApproved)
            {
                return false;
            }

            if (userRoleElements.AuthorizedTo(RoleElement.DELETE_NON_OPERATIONS_PERMIT))
            {
                return IsNonOperationsIssuerAndPermit(userRoleElements.Role, workPermit);
            }

            if (userRoleElements.AuthorizedTo(RoleElement.DELETE_PERMIT))
            {
                return true;
            }

            return false;
        }

        public bool ToCloseWorkPermits(UserRoleElements userRoleElements, List<WorkPermitEdmontonDTO> workPermits)
        {
            return workPermits.TrueForAll(permit => ToCloseWorkPermit(userRoleElements, permit));
        }

        public bool ToEditWorkPermit(UserRoleElements userRoleElements, WorkPermit workPermit)
        {
            if (userRoleElements == null || workPermit == null)
            {
                return false;
            }
            if (workPermit.HasEditableStatus() == false)
            {
                return false;
            }

            if (userRoleElements.AuthorizedTo(RoleElement.EDIT_NON_OPERATIONS_PERMIT))
            {
                return IsNonOperationsIssuerAndPermit(userRoleElements.Role, workPermit);
            }

            //check to see if userRoleElements has partial permission (as long as certain people have not edited it)
            if (userRoleElements.AuthorizedTo(RoleElement.UPDATE_PERMIT_WITH_RESTRICTED_PERMIT_UPDATING))
            {
                //no one has editing the work permit yet so everything is good
                if (workPermit.LastModifiedBy == null)
                {
                    return true;
                }

                //check to see if whoever last modified work permit has ability to stop updates

                return true;
            }
            if (userRoleElements.AuthorizedTo(RoleElement.UPDATE_PERMIT_NO_RESTRICTIONS))
            {
                return true;
            }
            return false;
        }

        public bool ToEditNonOpsWorkPermit(UserRoleElements userRoleElements)
        {
            if (userRoleElements == null)
            {
                return false;
            }
            return userRoleElements.AuthorizedTo(RoleElement.EDIT_NON_OPERATIONS_PERMIT);
        }

        public bool ToFullyValidateWorkPermit(UserRoleElements userRoleElements)
        {
            return userRoleElements.AuthorizedTo(RoleElement.UPDATE_PERMIT_NO_RESTRICTIONS) ||
                   userRoleElements.AuthorizedTo(RoleElement.EDIT_NON_OPERATIONS_PERMIT) ||
                   (userRoleElements.AuthorizedTo(RoleElement.CREATE_PERMIT) &&
                    !userRoleElements.AuthorizedTo(RoleElement.UPDATE_PERMIT_NO_RESTRICTIONS) &&
                    !userRoleElements.AuthorizedTo(RoleElement.UPDATE_PERMIT_WITH_RESTRICTED_PERMIT_UPDATING) &&
                    !userRoleElements.AuthorizedTo(RoleElement.EDIT_NON_OPERATIONS_PERMIT)
                       );
        }

        public bool ToPrintWorkPermits(UserRoleElements userRoleElements, UserShift userShift,
            List<WorkPermit> workPermits)
        {
            return workPermits.TrueForAll(permit => ToPrintWorkPermit(userRoleElements, userShift, permit));
        }

        public bool ToPrintWorkPermit(UserRoleElements userRoleElements, UserShift userShift, WorkPermit workPermit)
        {
            if (userRoleElements == null || workPermit == null)
            {
                return false;
            }
            //can never print Pending or Rejected
            if (workPermit.Is(WorkPermitStatus.Pending) || workPermit.Is(WorkPermitStatus.Rejected))
            {
                return false;
            }

            var authorizedToPrint = false;

            if (userRoleElements.AuthorizedTo(RoleElement.PRINT_NON_OPERATIONS_PERMIT))
            {
                authorizedToPrint = IsNonOperationsIssuerAndPermit(userRoleElements.Role, workPermit);
            }

            if (HasPrintPermitRoleElement(userRoleElements))
            {
                authorizedToPrint = true;
            }

            // when permit is approved, only ever print if it starts in the users current shift
            if (workPermit.Is(WorkPermitStatus.Approved))
            {
                authorizedToPrint = authorizedToPrint && workPermit.StartsInUserShift(userShift);
            }

            // else always allow printing for Issued, Completed, Archived
            return authorizedToPrint;
        }

        public bool ToPrintWorkPermitsInGeneral(UserRoleElements userRoleElements)
        {
            return HasPrintPermitRoleElement(userRoleElements) ||
                   userRoleElements.AuthorizedTo(RoleElement.PRINT_NON_OPERATIONS_PERMIT);
        }

        public bool ToPrintPreviewWorkPermit(UserRoleElements userRoleElements, UserShift userShift,
            WorkPermit workPermit)
        {
            return ToPrintWorkPermit(userRoleElements, userShift, workPermit);
        }

        public bool ToCloneWorkPermitWithSomeRestrictions(UserRoleElements userRoleElements)
        {
            return userRoleElements.AuthorizedTo(RoleElement.CLONE_PERMIT_WITH_SOME_RESTRICTIONS);
        }

        public bool ToCloneWorkPermitWithNoRestriction(UserRoleElements userRoleElements)
        {
            return userRoleElements.AuthorizedTo(RoleElement.CLONE_PERMIT_WITH_NO_RESTRICTION);
        }

        public bool ToCopyWorkPermitWithSomeRestrictions(UserRoleElements userRoleElements)
        {
            return userRoleElements.AuthorizedTo(RoleElement.COPY_PERMIT_WITH_SOME_RESTRICTIONS);
        }

        public bool ToCopyWorkPermitWithNoRestriction(UserRoleElements userRoleElements)
        {
            return userRoleElements.AuthorizedTo(RoleElement.COPY_PERMIT_WITH_NO_RESTRICTION);
        }

       //Added By Vibhor : DMND0010779 : OLT - Templateeasy clone
        public bool ToMarkTemplateForClone(UserRoleElements userRoleElements)
        {
            return userRoleElements.AuthorizedTo(RoleElement.WORKPERMIT_MARKED_TEMPLATE);
        }

        // Added By Vibhor : RITM0574870 - OLT - Clone feature created for AI definitions
        public bool ToCloneActionItem(UserRoleElements userRoleElements)
        {
            return userRoleElements.AuthorizedTo(RoleElement.CLONE_ACTIONITEM);
        }

        //Added by ppanigrahi
        public bool ToCreateCSDLog(UserRoleElements userRoleElements)
        {
            return userRoleElements.AuthorizedTo(RoleElement.CSD_LOG);
        }

        public bool ToCommentWorkPermit(UserRoleElements userRoleElements)
        {
            return userRoleElements.AuthorizedTo(RoleElement.COMMENT_WORK_PERMIT);
        }

        public bool ToCopyToWorkPermit(UserRoleElements userRoleElements, WorkPermit destinationWorkPermit,
            WorkPermit sourceWorkPermit)
        {
            if (destinationWorkPermit.IsNot(WorkPermitStatus.Pending))
            {
                return false;
            }
            if (destinationWorkPermit.Id.Equals(sourceWorkPermit.Id))
            {
                return false;
            }
            return ToEditWorkPermit(userRoleElements, destinationWorkPermit);
        }

        public bool ToEditWorkPermit(UserRoleElements userRoleElements, WorkPermitMontrealDTO workPermit)
        {
            if (userRoleElements == null || workPermit == null)
            {
                return false;
            }

            return (workPermit.Status.Id == PermitRequestBasedWorkPermitStatus.Requested.Id ||
                    workPermit.Status.Id == PermitRequestBasedWorkPermitStatus.Pending.Id) &&
                   userRoleElements.AuthorizedTo(RoleElement.UPDATE_PERMIT_NO_RESTRICTIONS);
        }

        public bool ToDeleteWorkPermits(UserRoleElements userRoleElements, List<WorkPermitMontrealDTO> workPermits)
        {
            return workPermits.TrueForAll(permit => ToDeleteWorkPermit(userRoleElements, permit));
        }

        public bool ToCloseWorkPermits(UserRoleElements userRoleElements, List<WorkPermitMontrealDTO> workPermits)
        {
            return workPermits.TrueForAll(permit => ToCloseWorkPermit(userRoleElements, permit));
        }

        public bool ToPrintWorkPermits(UserRoleElements userRoleElements, List<WorkPermitMontrealDTO> workPermits)
        {
            return workPermits.TrueForAll(permit => ToPrintWorkPermit(userRoleElements, permit));
        }

        public bool ToPrintWorkPermit(UserRoleElements userRoleElements, WorkPermitMontrealDTO workPermit)
        {
            if (!HasPrintPermitRoleElement(userRoleElements))
            {
                return false;
            }

            return PermitRequestBasedWorkPermitStatus.Pending.Equals(workPermit.Status) || workPermit.HasBeenIssued;
        }

        public bool ToPrintWorkPermits(UserRoleElements userRoleElements, List<WorkPermitEdmontonDTO> workPermits)
        {
            return workPermits.TrueForAll(permit => ToPrintWorkPermit(userRoleElements, permit));
        }

        public bool ToPrintWorkPermit(UserRoleElements userRoleElements, WorkPermitEdmontonDTO workPermit)
        {
            if (!ToPrintWorkPermit(userRoleElements, workPermit.WorkPermitStatus))
            {
                return false;
            }

            if (PermitRequestBasedWorkPermitStatus.Pending.Equals(workPermit.WorkPermitStatus) &&
                workPermit.EndDateTime < Clock.Now)
            {
                return false;
            }

            return HasPrintPermitRoleElement(userRoleElements);
        }

        //RITM0301321 start - mangesh
        public bool ToEditWorkPermit(UserRoleElements userRoleElements, WorkPermitMudsDTO workPermit)
        {
            if (userRoleElements == null || workPermit == null)
            {
                return false;
            }

            return (workPermit.Status.Id == PermitRequestBasedWorkPermitStatus.Requested.Id ||
                    workPermit.Status.Id == PermitRequestBasedWorkPermitStatus.Pending.Id ||
                    workPermit.Status.Id == PermitRequestBasedWorkPermitStatus.Signed.Id)&&
                   userRoleElements.AuthorizedTo(RoleElement.UPDATE_PERMIT_NO_RESTRICTIONS);
        }

        public bool ToDeleteWorkPermits(UserRoleElements userRoleElements, List<WorkPermitMudsDTO> workPermits)
        {
            return workPermits.TrueForAll(permit => ToDeleteWorkPermit(userRoleElements, permit));
        }

        public bool ToCloseWorkPermits(UserRoleElements userRoleElements, List<WorkPermitMudsDTO> workPermits)
        {
            return workPermits.TrueForAll(permit => ToCloseWorkPermit(userRoleElements, permit));
        }

        public bool ToPrintWorkPermits(UserRoleElements userRoleElements, List<WorkPermitMudsDTO> workPermits)
        {
            return workPermits.TrueForAll(permit => ToPrintWorkPermit(userRoleElements, permit));
        }

        public bool ToPrintWorkPermit(UserRoleElements userRoleElements, WorkPermitMudsDTO workPermit)
        {
            if (!HasPrintPermitRoleElement(userRoleElements))
            {
                return false;
            }

            return PermitRequestBasedWorkPermitStatus.Pending.Equals(workPermit.Status) || workPermit.HasBeenIssued
                || PermitRequestBasedWorkPermitStatus.Signed.Equals(workPermit.Status);
        }
        private static bool ToDeleteWorkPermit(UserRoleElements userRoleElements, WorkPermitMudsDTO workPermit)
        {
            if (userRoleElements == null || workPermit == null)
            {
                return false;
            }

            return (workPermit.Status.Id == PermitRequestBasedWorkPermitStatus.Requested.Id ||
                    workPermit.Status.Id == PermitRequestBasedWorkPermitStatus.Pending.Id ||
                    workPermit.Status.Id == PermitRequestBasedWorkPermitStatus.Signed.Id) &&
                   userRoleElements.AuthorizedTo(RoleElement.DELETE_PERMIT);
        }

        private static bool ToCloseWorkPermit(UserRoleElements userRoleElements, WorkPermitMudsDTO workPermit)
        {
            if (userRoleElements == null || workPermit == null)
            {
                return false;
            }

            return userRoleElements.AuthorizedTo(RoleElement.CLOSE_PERMIT);
        }
        //RITM0301321 End 

        public bool ToPerformTechnicalAdminTasks(UserRoleElements userRoleElements)
        {
            return userRoleElements.AuthorizedTo(RoleElement.PERFORM_TECH_ADMIN_TASKS);
        }

        public bool ToConfigureAreaLabels(UserRoleElements userRoleElements)
        {
            return userRoleElements.AuthorizedTo(RoleElement.CONFIGURE_AREA_LABELS);
        }

        public bool ToViewPermitRequests(UserRoleElements userRoleElements)
        {
            return userRoleElements.AuthorizedTo(RoleElement.VIEW_PERMIT_REQUESTS);
        }

        public bool ToCreatePermitRequest(UserRoleElements userRoleElements)
        {
            return userRoleElements.AuthorizedTo(RoleElement.CREATE_PERMIT_REQUEST);
        }

        public bool ToClonePermitRequest(UserRoleElements userRoleElements)
        {
            return userRoleElements.AuthorizedTo(RoleElement.CLONE_PERMIT_REQUEST);
        }

        public bool ToCreateConfinedSpace(UserRoleElements userRoleElements)
        {
            return userRoleElements.AuthorizedTo(RoleElement.CREATE_CONFINED_SPACE);
        }

        public bool ToViewConfinedSpaceDocuments(UserRoleElements userRoleElements)
        {
            return userRoleElements.AuthorizedTo(RoleElement.VIEW_CONFINED_SPACE);
        }

        public bool ToEditConfinedSpace(UserRoleElements userRoleElements, ConfinedSpaceDTO dto)
        {
            return dto.Status != ConfinedSpaceStatus.Issued &&
                   userRoleElements.AuthorizedTo(RoleElement.EDIT_CONFINED_SPACE);
        }

        public bool ToDeleteConfinedSpace(UserRoleElements userRoleElements, List<ConfinedSpaceDTO> dtos)
        {
            return userRoleElements.AuthorizedTo(RoleElement.DELETE_CONFINED_SPACE) &&
                   dtos.TrueForAll(dto => dto.Status != ConfinedSpaceStatus.Issued);
        }

        //RITM0301321 - mangesh
        public bool ToEditConfinedSpace(UserRoleElements userRoleElements, ConfinedSpaceMudsDTO dto)
        {
            return dto.Status != ConfinedSpaceStatusMuds.Issued &&
                   userRoleElements.AuthorizedTo(RoleElement.EDIT_CONFINED_SPACE);
        }

        public bool ToDeleteConfinedSpace(UserRoleElements userRoleElements, List<ConfinedSpaceMudsDTO> dtos)
        {
            return userRoleElements.AuthorizedTo(RoleElement.DELETE_CONFINED_SPACE) &&
                   dtos.TrueForAll(dto => dto.Status != ConfinedSpaceStatusMuds.Issued);
        }

        public bool ToPrintConfinedSpace(UserRoleElements userRoleElements)
        {
            return userRoleElements.AuthorizedTo(RoleElement.PRINT_CONFINED_SPACE);
        }

        public bool ToEditPermitRequest(UserRoleElements userRoleElements, List<PermitRequestEdmontonDTO> dtos)
        {
            return userRoleElements.AuthorizedTo(RoleElement.EDIT_PERMIT_REQUEST);
        }

        public bool ToEditPermitRequest(UserContext userContext, PermitRequestLubesDTO dto)
        {
            return permitRequestLubesAuthorization.ToEdit(dto, userContext);
        }

        public bool ToEditPermitRequest(UserRoleElements userRoleElements, List<PermitRequestMontrealDTO> dtos,
            User user)
        {
            return userRoleElements.AuthorizedTo(RoleElement.EDIT_PERMIT_REQUEST);
        }

        //RITM0301321 - mangesh
        public bool ToEditPermitRequest(UserRoleElements userRoleElements, List<PermitRequestMudsDTO> dtos,
            User user)
        {
            return userRoleElements.AuthorizedTo(RoleElement.EDIT_PERMIT_REQUEST);
        }

        public bool ToDeletePermitRequest(UserRoleElements userRoleElements, List<BasePermitRequestDTO> dtos, User user)
        {
            return userRoleElements.AuthorizedTo(RoleElement.DELETE_PERMIT_REQUEST) &&
                   ToEditOrDeletePermitRequest(dtos, user);
        }

        public bool ToDeletePermitRequests(UserContext userContext, List<PermitRequestLubesDTO> dtos)
        {
            return permitRequestLubesAuthorization.ToDelete(dtos, userContext);
        }

        public bool ToSubmitPermitRequest(UserRoleElements userRoleElements)
        {
            return userRoleElements.AuthorizedTo(RoleElement.SUBMIT_PERMIT_REQUEST);
        }

        public bool ToImportPermitRequests(UserRoleElements userRoleElements)
        {
            return userRoleElements.AuthorizedTo(RoleElement.IMPORT_PERMIT_REQUESTS);
        }

        public bool ToEditWorkPermit(UserRoleElements userRoleElements, WorkPermitEdmontonDTO workPermit)
        {
            if (userRoleElements == null || workPermit == null)
            {
                return false;
            }

            return (workPermit.WorkPermitStatus.Id == PermitRequestBasedWorkPermitStatus.Requested.Id ||
                    workPermit.WorkPermitStatus.Id == PermitRequestBasedWorkPermitStatus.Pending.Id) &&
                   userRoleElements.AuthorizedTo(RoleElement.UPDATE_PERMIT_NO_RESTRICTIONS);
        }

        public bool ToDeleteWorkPermits(UserRoleElements userRoleElements, List<WorkPermitEdmontonDTO> workPermits)
        {
            return workPermits.TrueForAll(permit => ToDeleteWorkPermit(userRoleElements, permit));
        }

        public bool ToEditWorkPermit(UserRoleElements userRoleElements, WorkPermitLubesDTO workPermit)
        {
            if (userRoleElements == null || workPermit == null)
            {
                return false;
            }

            return (workPermit.Status.Id == PermitRequestBasedWorkPermitStatus.Requested.Id ||
                    workPermit.Status.Id == PermitRequestBasedWorkPermitStatus.Pending.Id) &&
                   userRoleElements.AuthorizedTo(RoleElement.UPDATE_PERMIT_NO_RESTRICTIONS);
        }

        public bool ToDeleteWorkPermits(UserRoleElements userRoleElements, List<WorkPermitLubesDTO> workPermits)
        {
            return workPermits.TrueForAll(permit => ToDeleteWorkPermit(userRoleElements, permit));
        }

        public bool ToCloseWorkPermits(UserRoleElements userRoleElements, List<WorkPermitLubesDTO> workPermits)
        {
            return workPermits.TrueForAll(permit => ToCloseWorkPermit(userRoleElements, permit));
        }

        public bool ToPrintWorkPermits(UserRoleElements userRoleElements, List<WorkPermitLubesDTO> workPermits)
        {
            return workPermits.TrueForAll(permit => ToPrintWorkPermit(userRoleElements, permit));
        }

        public bool ToPrintWorkPermit(UserRoleElements userRoleElements, WorkPermitLubesDTO workPermit)
        {
            if (!ToPrintWorkPermit(userRoleElements, workPermit.Status))
            {
                return false;
            }

            if (PermitRequestBasedWorkPermitStatus.Pending.Equals(workPermit.Status) &&
                workPermit.ExpireDateTime < Clock.Now)
            {
                return false;
            }

            return HasPrintPermitRoleElement(userRoleElements);
        }

        private bool CanUserApproveWorkPermits(UserRoleElements userRoleElements, UserShift userShift,
            List<WorkPermit> workPermits)
        {
            return workPermits.TrueForAll(workPermit => ToApproveWorkPermit(userRoleElements, userShift, workPermit));
        }

        private static bool ToCloseWorkPermit(UserRoleElements userRoleElements, WorkPermitEdmontonDTO workPermit)
        {
            if (userRoleElements == null || workPermit == null)
            {
                return false;
            }

            return userRoleElements.AuthorizedTo(RoleElement.CLOSE_PERMIT);
        }

        public bool HasPrintPermitRoleElement(UserRoleElements userRoleElements)
        {
            return userRoleElements.AuthorizedTo(RoleElement.PRINT_PERMIT);
        }

        private static bool IsNonOperationsIssuerAndPermit(Role role, WorkPermit workPermit)
        {
            return role.IsWorkPermitNonOperationsRole && workPermit.IsNonOperations();
        }

        private static bool ToDeleteWorkPermit(UserRoleElements userRoleElements, WorkPermitMontrealDTO workPermit)
        {
            if (userRoleElements == null || workPermit == null)
            {
                return false;
            }

            return (workPermit.Status.Id == PermitRequestBasedWorkPermitStatus.Requested.Id ||
                    workPermit.Status.Id == PermitRequestBasedWorkPermitStatus.Pending.Id) &&
                   userRoleElements.AuthorizedTo(RoleElement.DELETE_PERMIT);
        }

        private static bool ToCloseWorkPermit(UserRoleElements userRoleElements, WorkPermitMontrealDTO workPermit)
        {
            if (userRoleElements == null || workPermit == null)
            {
                return false;
            }

            return userRoleElements.AuthorizedTo(RoleElement.CLOSE_PERMIT);
        }

        private bool ToPrintWorkPermit(UserRoleElements userRoleElements,
            PermitRequestBasedWorkPermitStatus permitStatus)
        {
            if (userRoleElements == null || permitStatus == null)
            {
                return false;
            }

            return HasPrintPermitRoleElement(userRoleElements) &&
                   permitStatus.Id != PermitRequestBasedWorkPermitStatus.Requested.Id;
        }

        private static bool ToEditOrDeletePermitRequest(List<BasePermitRequestDTO> dtos, User user)
        {
            return dtos.TrueForAll(obj => obj.DataSource.Id == DataSource.SAP.Id || obj.CreatedByUserId == user.Id);
        }

        private static bool ToDeleteWorkPermit(UserRoleElements userRoleElements, WorkPermitEdmontonDTO workPermit)
        {
            if (userRoleElements == null || workPermit == null)
            {
                return false;
            }

            return (workPermit.Status.Id == PermitRequestBasedWorkPermitStatus.Requested.Id || 
                    workPermit.Status.Id == PermitRequestBasedWorkPermitStatus.Pending.Id) &&
                   userRoleElements.AuthorizedTo(RoleElement.DELETE_PERMIT); 
        }

        private static bool ToDeleteWorkPermit(UserRoleElements userRoleElements, WorkPermitLubesDTO workPermit)
        {
            if (userRoleElements == null || workPermit == null)
            {
                return false;
            }

            return (workPermit.Status.Id == PermitRequestBasedWorkPermitStatus.Requested.Id ||
                    workPermit.Status.Id == PermitRequestBasedWorkPermitStatus.Pending.Id) &&
                   userRoleElements.AuthorizedTo(RoleElement.DELETE_PERMIT);
        }

        private static bool ToCloseWorkPermit(UserRoleElements userRoleElements, WorkPermitLubesDTO workPermit)
        {
            if (userRoleElements == null || workPermit == null)
            {
                return false;
            }

            return userRoleElements.AuthorizedTo(RoleElement.CLOSE_PERMIT);
        }

        #endregion Work Permit Rules

        #region Form Rules

        public bool ToViewForm(UserRoleElements userRoleElements)
        {
            return userRoleElements.AuthorizedTo(RoleElement.VIEW_FORM);
        }

        public bool ToViewFormNavigation(UserRoleElements userRoleElements)
        {
            return userRoleElements.AuthorizedTo(RoleElement.VIEW_FORM_NAVIGATION);
        }

        public bool ToViewFormsOnThePrioritiesPage(UserRoleElements userRoleElements)
        {
            return userRoleElements.AuthorizedTo(RoleElement.VIEW_FORM_PRIORITIES);
        }

        public bool ToViewLubeCsdsOnPrioritiesPage(UserRoleElements userRoleElements)
        {
            return userRoleElements.AuthorizedTo(RoleElement.VIEW_LUBESCSD_PRIORITIES);
        }

        public bool ToDeleteLubesCsdForms(UserRoleElements userRoleElements, List<LubesCsdFormDTO> selectedItems)
        {
            return
                selectedItems.TrueForAll(dto => dto.CanBeDeleted) &&
                userRoleElements.AuthorizedTo(RoleElement.DELETE_LUBES_CSD_FORM);
        }

        public bool ToCloseLubesCsdForms(UserRoleElements userRoleElements, List<LubesCsdFormDTO> selectedItems)
        {
            return selectedItems.TrueForAll(dto => dto.CanBeClosed) &&
                   userRoleElements.AuthorizedTo(RoleElement.CLOSE_LUBES_CSD_FORM);
        }

        public bool ToViewEventsNavigation(UserRoleElements userRoleElements)
        {
            return userRoleElements.AuthorizedTo(RoleElement.VIEW_EVENTS_NAVIGATION);
        }

        public bool ToViewEventsOnPrioritiesPage(UserRoleElements userRoleElements)
        {
            return userRoleElements.AuthorizedTo(RoleElement.VIEW_EVENTS_PRIORITIES);
        }

        
        public bool ToRespondToExcursionEvents(UserRoleElements userRoleElements)
        {
            return userRoleElements.AuthorizedTo(RoleElement.RESPOND_TO_EXCURSION);
        }

        //DMND0011225 OLT - CSD for WBR

        public bool ToEditGenericCsd(UserRoleElements userRoleElements, FormStatus status)
        {
            return status != FormStatus.Closed && userRoleElements.AuthorizedTo(RoleElement.EDIT_MONTREAL_CSD_FORM);
        }

        public bool ToCreateGenericCsdForm(UserRoleElements userRoleElements)
        {
            return userRoleElements.AuthorizedTo(RoleElement.CREATE_FORM);
        }

        public bool ToViewGenericCsdsOnPrioritiesPage(UserRoleElements userRoleElements)
        {
            return userRoleElements.AuthorizedTo(RoleElement.VIEW_MONTREALCSD_PRIORITIES);
        }

        public bool ToDeleteGenericCsd(UserRoleElements userRoleElements, List<GenericCsdDTO> selectedItems)
        {
            return
                selectedItems.TrueForAll(dto => dto.CanBeDeleted) &&
                userRoleElements.AuthorizedTo(RoleElement.DELETE_FORM);
        }

        public bool ToCloseGenericCsdForms(UserRoleElements userRoleElements, List<GenericCsdDTO> selectedItems)
        {
            return selectedItems.TrueForAll(dto => dto.CanBeClosed) &&
                   userRoleElements.AuthorizedTo(RoleElement.CREATE_FORM);
        }

        //---



        public bool ToEditMontrealCsd(UserRoleElements userRoleElements, FormStatus status)
        {
            return status != FormStatus.Closed && userRoleElements.AuthorizedTo(RoleElement.EDIT_MONTREAL_CSD_FORM);
        }

        public bool ToCreateMontrealCsdForm(UserRoleElements userRoleElements)
        {
            return userRoleElements.AuthorizedTo(RoleElement.CREATE_FORM);
        }

        public bool ToViewFormOP14sOnPrioritiesPage(UserRoleElements userRoleElements)
        {
            return userRoleElements.AuthorizedTo(RoleElement.VIEW_FORMOP14_PRIORITIES);
        }

        public bool ToViewMontrealCsdsOnPrioritiesPage(UserRoleElements userRoleElements)
        {
            return userRoleElements.AuthorizedTo(RoleElement.VIEW_MONTREALCSD_PRIORITIES);
        }

        public bool ToDeleteMontrealCsd(UserRoleElements userRoleElements, List<MontrealCsdDTO> selectedItems)
        {
            return
                selectedItems.TrueForAll(dto => dto.CanBeDeleted) &&
                userRoleElements.AuthorizedTo(RoleElement.DELETE_FORM);
        }

        public bool ToCloseMontrealCsdForms(UserRoleElements userRoleElements, List<MontrealCsdDTO> selectedItems)
        {
            return selectedItems.TrueForAll(dto => dto.CanBeClosed) &&
                   userRoleElements.AuthorizedTo(RoleElement.CREATE_FORM);
        }

        public bool ToCreateFormSafeWorkPermitAuditQuestionnaire(UserRoleElements userRoleElements)
        {
            return userRoleElements.AuthorizedTo(RoleElement.CREATE_OILSANDS_SWP_FORM) ;
        }

        //ayman rolematrix
        public bool ToViewPermitAssessment(UserRoleElements userRoleElements)
        {
            return userRoleElements.AuthorizedTo(RoleElement.VIEW_PERMIT);
        }

        public bool ToEditPermitAssessment(UserRoleElements userRoleElements, PermitAssessmentDTO dto, User currentUser,
            UserShift userShift)
        {
            if (dto.Status == FormStatus.Cancelled) return false;
            return userRoleElements.AuthorizedTo(RoleElement.EDIT_OILSANDS_SWP_FORM) &&
                   PermitAssessmentCreatedBySameUserOnSameShift(dto, currentUser, userShift);
        }

        public bool ToCreateLubesAlarmDisableForm(UserRoleElements userRoleElements)
        {
            return userRoleElements.AuthorizedTo(RoleElement.CREATE_LUBES_ALARM_DISABLE_FORM);
        }

        public bool ToCloseLubesAlarmDisableForms(UserRoleElements userRoleElements,
            List<LubesAlarmDisableFormDTO> selectedItems)
        {
            return selectedItems.TrueForAll(dto => dto.CanBeClosed) &&
                   userRoleElements.AuthorizedTo(RoleElement.CLOSE_LUBES_ALARM_DISABLE_FORM);
        }

        public bool ToDeleteLubesAlarmDisableForms(UserRoleElements userRoleElements,
            List<LubesAlarmDisableFormDTO> selectedItems)
        {
            return
                selectedItems.TrueForAll(dto => dto.CanBeDeleted) &&
                userRoleElements.AuthorizedTo(RoleElement.DELETE_LUBES_ALARM_DISABLE_FORM);
        }

        public bool ToEditFormLubesAlarmDisable(UserRoleElements userRoleElements, FormStatus formStatus)
        {
            return userRoleElements.AuthorizedTo(RoleElement.EDIT_LUBES_ALARM_DISABLE_FORM) &&
                   (FormStatus.Draft.Equals(formStatus) || FormStatus.Approved.Equals(formStatus) ||
                    FormStatus.Expired.Equals(formStatus));
        }
    
        //ayman training form
        public bool ToCreateTrainingForm(UserRoleElements userRoleElements, Site userSite)
        {
            return userRoleElements.AuthorizedTo(RoleElement.CREATE_FORM_TRAINING);
        }

        public bool ToViewTrainingForm(UserRoleElements userRoleElements, Site userSite)
        {
            return userRoleElements.AuthorizedTo(RoleElement.VIEW_FORM_TRAINING);
        }

        public bool ToEditTrainingForm(UserRoleElements userRoleElements, Site userSite)
        {
            return userRoleElements.AuthorizedTo(RoleElement.EDIT_FORM_TRAINING);
        }

        public bool ToCloseTrainingForm(UserRoleElements userRoleElements, Site userSite)
        {
            return userRoleElements.AuthorizedTo(RoleElement.CLOSE_FORM_TRAINING);
        }

  //RITM0268131 - mangesh
        public bool ToCreateMudsTemporaryInstallationsForm(UserRoleElements userRoleElements)
        {
            return userRoleElements.AuthorizedTo(RoleElement.CREATE_TemporaryInstallations);
        }

        public bool ToEditMudsTemporaryInstallations(UserRoleElements userRoleElements, FormStatus status)
        {
            return status != FormStatus.Closed && userRoleElements.AuthorizedTo(RoleElement.EDIT_TemporaryInstallations);
        }

        public bool ToViewMudsTemporaryInstallationsOnPrioritiesPage(UserRoleElements userRoleElements)
        {
            return userRoleElements.AuthorizedTo(RoleElement.VIEW_TemporaryInstallations);
        }

        public bool ToDeleteMudsTemporaryInstallations(UserRoleElements userRoleElements)
        {
            return userRoleElements.AuthorizedTo(RoleElement.DELETE_TemporaryInstallations);
        }

        public bool ToApproveOrCloseMudsTemporaryInstallationsForms(UserRoleElements userRoleElements)
        {
            return userRoleElements.AuthorizedTo(RoleElement.APPROVECLOSE_TemporaryInstallations); //selectedItems.TrueForAll(dto => dto.CanBeClosed)
        }
        //---------------        // ayman sarnia - ayman selc - ayman forthills - ayman E&U
        public bool ToCreateForms(UserRoleElements userRoleElements, Site usersSite)
        {
            return (userRoleElements.AuthorizedTo(RoleElement.CREATE_FORM) && usersSite.Id == Site.OILSAND_ID) ||
                   (userRoleElements.AuthorizedTo(RoleElement.CREATE_FORM) && usersSite.Id == Site.FORT_HILLS_ID) ||
                   (userRoleElements.AuthorizedTo(RoleElement.CREATE_FORM) && usersSite.Id == Site.EDMONTON_ID) ||
                   (userRoleElements.AuthorizedTo(RoleElement.CREATE_FORM) && usersSite.Id == Site.MONTREAL_ID) ||
                   (userRoleElements.AuthorizedTo(RoleElement.CREATE_LUBES_CSD_FORM) && usersSite.Id == Site.LUBES_ID) ||
                   (userRoleElements.AuthorizedTo(RoleElement.CREATE_LUBES_ALARM_DISABLE_FORM) &&
                    usersSite.Id == Site.LUBES_ID) ||
                   (userRoleElements.AuthorizedTo(RoleElement.CREATE_FORM) && usersSite.Id == Site.SARNIA_ID) ||
                   (userRoleElements.AuthorizedTo(RoleElement.CREATE_FORM) && usersSite.Id == Site.SITE_WIDE_SERVICES_ID) ||
                   (userRoleElements.AuthorizedTo(RoleElement.CREATE_FORM) && usersSite.Id == Site.SELC_ID) ||
                   (userRoleElements.AuthorizedTo(RoleElement.CREATE_FORM) && usersSite.Id == Site.MontrealSulphur_ID) || //RITM0268131 - mangesh
                   (userRoleElements.AuthorizedTo(RoleElement.CREATE_FORM) && usersSite.Id == Site.WOODBUFFALO_ID); //DMND0011225 CSD for WBR
        }

        //ayman Sarnia eip DMND0008992
        public bool ToApproveEipIssue(UserRoleElements userRoleElements)
        {
            return userRoleElements.AuthorizedTo(RoleElement.Approve_EIP_ISSUE);
        }
        public bool ToCreateEipIssue(UserRoleElements userRoleElements)
        {
            return userRoleElements.AuthorizedTo(RoleElement.CREATE_EIP_ISSUE);
        }
        public bool ToEditEipIssue(UserRoleElements userRoleElements)
        {
            return userRoleElements.AuthorizedTo(RoleElement.EDIT_EIP_ISSUE);
        }
        public bool ToViewEipIssue(UserRoleElements userRoleElements)
        {
            return userRoleElements.AuthorizedTo(RoleElement.VIEW_EIP_ISSUE);
        }


        public bool ToDeleteForm(UserRoleElements userRoleElements)
        {
            return userRoleElements.AuthorizedTo(RoleElement.DELETE_FORM);
        }

        public bool ToEditForm(UserRoleElements userRoleElements)
        {
            return userRoleElements.AuthorizedTo(RoleElement.EDIT_FORM);
        }

        public bool ToEditEdmontonForm(UserRoleElements userRoleElements, FormStatus formStatus,
            EdmontonFormType formType)
        {
            var canEdit = false;

            if (EdmontonFormType.GN7.Equals(formType))
            {
                canEdit = ToEditFormGN7(userRoleElements, formStatus);
            }
            else if (EdmontonFormType.GN59.Equals(formType))
            {
                canEdit = ToEditFormGN59(userRoleElements, formStatus);
            }
            else if (EdmontonFormType.OP14.Equals(formType))
            {
                canEdit = ToEditFormOP14(userRoleElements, formStatus);
            }
            else if (EdmontonFormType.GN24.Equals(formType))
            {
                canEdit = ToEditFormGN24(userRoleElements, formStatus);
            }
            else if (EdmontonFormType.GN6.Equals(formType))
            {
                canEdit = ToEditFormGN6(userRoleElements, formStatus);
            }
            else if (EdmontonFormType.GN75A.Equals(formType))
            {
                canEdit = ToEditFormGN75A(userRoleElements, formStatus);
            }
            else if (EdmontonFormType.GN75B.Equals(formType))
            {
                canEdit = ToEditFormGN75B(userRoleElements, formStatus);
            }
            else if (EdmontonFormType.GN1.Equals(formType))
            {
                canEdit = ToEditFormGN1(userRoleElements, formStatus);
            }

            return canEdit;
        }

        public bool ToEditFormGN1(UserRoleElements userRoleElements, FormStatus formStatus)
        {
            return ToEditForm(userRoleElements) && !FormStatus.Closed.Equals(formStatus); // ayman added expired status can be edited
        }

        public bool ToEditFormGN7(UserRoleElements userRoleElements, FormStatus formStatus)
        {
            return ToEditForm(userRoleElements) && (FormStatus.Draft.Equals(formStatus) || FormStatus.WaitingForApproval.Equals(formStatus) || FormStatus.Approved.Equals(formStatus) || FormStatus.Expired.Equals(formStatus)); // Swapnil Patki For DMND0005325 Point Number 7 + ayman added expired and approved status
        }

        public bool ToEditFormGN59(UserRoleElements userRoleElements, FormStatus formStatus)
        {
            return ToEditForm(userRoleElements) &&
                   (FormStatus.Draft.Equals(formStatus) || FormStatus.Approved.Equals(formStatus) || FormStatus.WaitingForApproval.Equals(formStatus) || FormStatus.Expired.Equals(formStatus)); // Swapnil Patki For DMND0005325 Point Number 7
        }

        public bool ToEditFormOP14(UserRoleElements userRoleElements, FormStatus formStatus)
        {
            return ToEditForm(userRoleElements) &&
                   (FormStatus.Draft.Equals(formStatus) || FormStatus.Approved.Equals(formStatus) ||
                    FormStatus.Expired.Equals(formStatus) ||
                    FormStatus.WaitingForApproval.Equals(formStatus));  // mangesh -- waiting for approval
        }

        
        public bool ToEditFormLubesCsd(UserRoleElements userRoleElements, FormStatus formStatus)
        {
            return userRoleElements.AuthorizedTo(RoleElement.EDIT_LUBES_CSD_FORM) &&
                   (FormStatus.Draft.Equals(formStatus) || FormStatus.Approved.Equals(formStatus) ||
                    FormStatus.Expired.Equals(formStatus));
        }

        public bool ToEditFormGN24(UserRoleElements userRoleElements, FormStatus formStatus)
        {
            return ToEditForm(userRoleElements) &&
                   (FormStatus.Draft.Equals(formStatus) || FormStatus.Approved.Equals(formStatus) || FormStatus.WaitingForApproval.Equals(formStatus) || FormStatus.Expired.Equals(formStatus)); // Swapnil Patki For DMND0005325 Point Number 7 + ayman added expired to be edited
        }

        public bool ToViewSAPNotifications(UserRoleElements userRoleElements)
        {
            if (userRoleElements == null)
            {
                return false;
            }
            return userRoleElements.AuthorizedTo(RoleElement.VIEW_SAP_NOTIFICATIONS);
        }

        public bool ToProcessSAPNotfications(UserRoleElements userRoleElements,
            List<SAPNotificationDTO> sapNotificationDTOs)
        {
            return sapNotificationDTOs.TrueForAll(dto => ToProcessSAPNotfication(userRoleElements, dto));
        }

        public bool ToProcessSAPNotfication(UserRoleElements userRoleElements, SAPNotificationDTO sapNotificationDTO)
        {
            if (userRoleElements == null || sapNotificationDTO == null)
            {
                return false;
            }
            return userRoleElements.AuthorizedTo(RoleElement.PROCESS_SAP_NOTIFICATIONS);
        }

        public bool ToApproveLubesCsdLeadTech(UserRoleElements userRoleElements)
        {
            return userRoleElements.AuthorizedTo(RoleElement.APPROVE_LUBES_CSD_FORM_LEAD_TECH);
        }

        public bool ToApproveLubesCsdProcessEngineer(UserRoleElements userRoleElements)
        {
            return userRoleElements.AuthorizedTo(RoleElement.APPROVE_LUBES_CSD_FORM_PROCESS_ENGINEER);
        }

        public bool ToApproveLubesCsdAreaTeamLead(UserRoleElements userRoleElements)
        {
            return userRoleElements.AuthorizedTo(RoleElement.APPROVE_LUBES_CSD_FORM_AREA_TEAM_LEAD);
        }

        public bool ToApproveLubesCsdDirectorOfProduction(UserRoleElements userRoleElements)
        {
            return userRoleElements.AuthorizedTo(RoleElement.APPROVE_LUBES_CSD_FORM_DIRECTOR_OF_PRODUCTION);
        }

        public bool ToChangeEndDateOfLubesCsdWithNoReapprovalRequired(UserRoleElements userRoleElements)
        {
            var changeEndDateOfLubesCsdWithNoReapprovalRequired =
                userRoleElements.AuthorizedTo(RoleElement.APPROVE_LUBES_CSD_FORM_CHANGE_END_DATE_WITHOUT_REAPPROVAL);
            return changeEndDateOfLubesCsdWithNoReapprovalRequired;
        }

        public bool ToApproveLubesAlarmDisableLeadTech(UserRoleElements userRoleElements)
        {
            return userRoleElements.AuthorizedTo(RoleElement.APPROVE_LUBES_ALARM_DISABLE_FORM_LEAD_TECH);
        }

        public bool ToApproveLubesAlarmDisableSupervisor(UserRoleElements userRoleElements)
        {
            return userRoleElements.AuthorizedTo(RoleElement.APPROVE_LUBES_ALARM_DISABLE_FORM_SUPERVISOR);
        }

        public bool ToChangeEndDateOfLubesAlarmDisableWithNoReapprovalRequired(UserRoleElements userRoleElements)
        {
            var changeEndDateOfLubesAlarmDisableWithNoReapprovalRequired =
                userRoleElements.AuthorizedTo(
                    RoleElement.APPROVE_LUBES_ALARM_DISABLE_FORM_CHANGE_END_DATE_WITHOUT_REAPPROVAL);
            return changeEndDateOfLubesAlarmDisableWithNoReapprovalRequired;
        }

        public bool ToCancelPermitAssessment(UserRoleElements userRoleElements, User user, UserShift userShift,
            PermitAssessmentDTO dto)
        {
            if (dto.Status == FormStatus.Cancelled) return false;
            if (userRoleElements.AuthorizedTo(RoleElement.CANCEL_ANYTIME_OILSANDS_SWP_FORM)) return true;
            return userRoleElements.AuthorizedTo(RoleElement.CANCEL_DURING_SHIFT_OILSANDS_SWP_FORM) &&
                   PermitAssessmentCreatedBySameUserOnSameShift(dto, user, userShift);
        }

        #region SAP Notifications Rules

        public bool ToEditFormGN6(UserRoleElements userRoleElements, FormStatus formStatus)
        {
            return ToEditForm(userRoleElements) &&
                   (FormStatus.Draft.Equals(formStatus) || FormStatus.Expired.Equals(formStatus) || FormStatus.Approved.Equals(formStatus) || FormStatus.WaitingForApproval.Equals(formStatus)); // Swapnil Patki For DMND0005325 Point Number 7  ayman added expired
        }

        public bool ToEditFormGN75B(UserRoleElements userRoleElements, FormStatus formStatus)
        {
            return ToEditForm(userRoleElements) && !FormStatus.Closed.Equals(formStatus);
        }

        public bool ToEditForm(UserContext userContext, FormOilsandsTrainingDTO dto)
        {
            return formOilsandsTrainingAuthorization.ToEdit(dto, userContext);
        }

        public bool ToViewOvertimeForm(UserRoleElements userRoleElements)
        {
            return userRoleElements.AuthorizedTo(RoleElement.VIEW_FORM_OVERTIME_REQUEST);
        }

        public bool ToCreateOvertimeForm(UserRoleElements userRoleElements)
        {
            return userRoleElements.AuthorizedTo(RoleElement.CREATE_FORM) &&
                   userRoleElements.AuthorizedTo(RoleElement.VIEW_FORM_OVERTIME_REQUEST);
        }

        public bool ToCreateLubesCsdForm(UserRoleElements userRoleElements)
        {
            return userRoleElements.AuthorizedTo(RoleElement.CREATE_LUBES_CSD_FORM);
        }

        public bool ToEditOvertimeForm(UserRoleElements userRoleElements, FormStatus formStatus)
        {
            return formStatus != FormStatus.Cancelled && ToCreateOvertimeForm(userRoleElements);
        }

        public bool ToApproveOvertimeForm(UserRoleElements userRoleElements)
        {
            return userRoleElements.AuthorizedTo(RoleElement.APPROVE_FORM_OVERTIME_REQUEST);
        }

        public bool ToViewOnPremisePersonnelNavigation(UserRoleElements userRoleElements)
        {
            return userRoleElements.AuthorizedTo(RoleElement.VIEW_ON_PREMISE_PERSONNEL_NAVIGATION);
        }

        public bool ToDeleteOilsandsTrainingForm(UserContext userContext, FormOilsandsTrainingDTO dto)
        {
            return formOilsandsTrainingAuthorization.ToDelete(dto, userContext);
        }

        public bool ToApproveOilsandsTrainingForm(UserRoleElements userRoleElements)
        {
            return userRoleElements.AuthorizedTo(RoleElement.APPROVE_OILSANDS_TRAINING_FORM);
        }

        public bool ToConfigureFormTemplates(UserRoleElements userRoleElements)
        {
            return userRoleElements.AuthorizedTo(RoleElement.CONFIGURE_FORM_TEMPLATES);
        }

        //generic template - mangesh
        public bool ToConfigureEFormTemplatesApproval(UserRoleElements userRoleElements)
        {
            return userRoleElements.AuthorizedTo(RoleElement.CONFIGURE_EFORM_TEMPLATES_APPROVAL);
        }

        //olt admin list - mangesh
        public bool ToConfigureOltCommunity(UserRoleElements userRoleElements)
        {
            return userRoleElements.AuthorizedTo(RoleElement.CONFIGURE_OLT_COMMUNITY);
        }

        public bool ToConfigureTrainingBlocks(UserRoleElements userRoleElements)
        {
            return userRoleElements.AuthorizedTo(RoleElement.CONFIGURE_TRAINING_BLOCKS);
        }

        public bool ToChangeEndDateOfGN59WithNoReapprovalRequired(UserRoleElements userRoleElements)
        {
            return userRoleElements.AuthorizedTo(RoleElement.CHANGE_FORMGN59_END_DATE_WITH_NO_REAPPROVAL_REQUIRED);
        }

        public bool ToChangeEndDateOfGN24WithNoReapprovalRequired(UserRoleElements userRoleElements)
        {
            return userRoleElements.AuthorizedTo(RoleElement.CHANGE_FORMGN24_END_DATE_WITH_NO_REAPPROVAL_REQUIRED);
        }

        public bool ToEditFormGN75A(UserRoleElements userRoleElements, FormStatus formStatus)
        {
            return ToEditForm(userRoleElements) && !FormStatus.Closed.Equals(formStatus);
        }

        public bool ToChangeEndDateOfGN6WithNoReapprovalRequired(UserRoleElements userRoleElements)
        {
            return userRoleElements.AuthorizedTo(RoleElement.CHANGE_FORMGN6_END_DATE_WITH_NO_REAPPROVAL_REQUIRED);
        }

        public bool ToChangeEndDateOfGN75AWithNoReapprovalRequired(UserRoleElements userRoleElements)
        {
            return userRoleElements.AuthorizedTo(RoleElement.CHANGE_FORMGN75A_END_DATE_WITH_NO_REAPPROVAL_REQUIRED);
        }

        public bool ToChangeEndDateOfGN1WithNoReapprovalRequired(UserRoleElements userRoleElements)
        {
            return userRoleElements.AuthorizedTo(RoleElement.CHANGE_FORMGN1_END_DATE_WITH_NO_REAPPROVAL_REQUIRED);
        }

        #endregion Form Rules

        private bool CreatedInUserShift(UserShift userShift, DateTime createdOn)
        {
            return (createdOn >= userShift.StartDateTimeWithPadding)
                   && (createdOn <= userShift.EndDateTimeWithPadding);
        }

        private bool CreatedInUserShiftWithoutPadding(UserShift userShift, DateTime createdOn)
        {
            return (createdOn >= userShift.StartDateTime)
                   && (createdOn <= userShift.EndDateTime);
        }

        public bool ToEditFormLubesCsd(UserRoleElements userRoleElements)
        {
            return userRoleElements.AuthorizedTo(RoleElement.EDIT_LUBES_CSD_FORM);
        }

        #endregion

        #region Site Specific Configuration

        public bool ToConfigureGasTestElementLimits(UserRoleElements userRoleElements)
        {
            return userRoleElements.AuthorizedTo(RoleElement.CONFIGURE_GAS_TEST_LIMITS);
        }

        public bool ToConfigureFunctionalLocations(UserRoleElements userRoleElements)
        {
            return userRoleElements.AuthorizedTo(RoleElement.CONFIGURE_FUNCTIONAL_LOCATIONS);
        }

        public bool ToManageOperationalModes(UserRoleElements userRoleElements)
        {
            return userRoleElements.AuthorizedTo(RoleElement.MANAGE_OPERATIONAL_MODES);
        }

        public bool ToConfigureRestrictionFlocsForWorkAssignments(UserRoleElements userRoleElements)
        {
            return userRoleElements.AuthorizedTo(RoleElement.CONFIGURE_RESTRICTION_FLOCS_FOR_WORK_ASSIGNMENTS);
        }

        public bool ToViewDocumentSuggestionOnPrioritiesPage(UserRoleElements userRoleElements, long siteId)
        {
            return userRoleElements.AuthorizedTo(RoleElement.VIEW_PRIORITIES_DOCUMENT_SUGGESTION_FORM) &&
                   Site.IsWoodBuffaloRegionSite(siteId);
        }

        public bool ToCreateFormDocumentSuggestion(UserRoleElements userRoleElements, long siteId)
        {
            return userRoleElements.AuthorizedTo(RoleElement.CREATE_DOCUMENT_SUGGESTION_FORM) &&
                   Site.IsWoodBuffaloRegionSite(siteId);
        }

        public bool ToEditFormDocumentSuggestion(UserRoleElements userRoleElements, long siteId)
        {
            return userRoleElements.AuthorizedTo(RoleElement.EDIT_DOCUMENT_SUGGESTION_FORM) &&
                   Site.IsWoodBuffaloRegionSite(siteId);
        }

        public bool ToApproveFormDocumentSuggestion(UserRoleElements userRoleElements, long siteId)
        {
            return userRoleElements.AuthorizedTo(RoleElement.APPROVE_DOCUMENT_SUGGESTION_FORM) &&
                   Site.IsWoodBuffaloRegionSite(siteId);
        }

        public bool ToDeleteFormDocumentSuggestion(UserRoleElements userRoleElements, long siteId)
        {
            return userRoleElements.AuthorizedTo(RoleElement.DELETE_DOCUMENT_SUGGESTION_FORM) &&
                   Site.IsWoodBuffaloRegionSite(siteId);
        }

        public bool ToViewProcedureDeviationOnPrioritiesPage(UserRoleElements userRoleElements, long siteId)
        {
            return userRoleElements.AuthorizedTo(RoleElement.VIEW_PRIORITIES_PROCEDURE_DEVIATION_FORM) &&
                   Site.IsWoodBuffaloRegionSite(siteId);
        }

        public bool ToCreateFormProcedureDeviation(UserRoleElements userRoleElements, long siteId)
        {
            return userRoleElements.AuthorizedTo(RoleElement.CREATE_PROCEDURE_DEVIATION_FORM) &&
                   Site.IsWoodBuffaloRegionSite(siteId);
        }

        public bool ToEditFormProcedureDeviation(UserRoleElements userRoleElements, long siteId)
        {
            return userRoleElements.AuthorizedTo(RoleElement.EDIT_PROCEDURE_DEVIATION_FORM) &&
                   Site.IsWoodBuffaloRegionSite(siteId);
        }

        public bool ToApproveFormProcedureDeviation(UserRoleElements userRoleElements, long siteId)
        {
            return userRoleElements.AuthorizedTo(RoleElement.APPROVE_PROCEDURE_DEVIATION_FORM) &&
                   Site.IsWoodBuffaloRegionSite(siteId);
        }

        public bool ToDeleteFormProcedureDeviation(UserRoleElements userRoleElements, long siteId)
        {
            return userRoleElements.AuthorizedTo(RoleElement.DELETE_PROCEDURE_DEVIATION_FORM) &&
                   Site.IsWoodBuffaloRegionSite(siteId);
        }

        public bool ToConfigureDisplayLimits(UserRoleElements userRoleElements)
        {
            return userRoleElements.AuthorizedTo(RoleElement.CONFIGURE_DISPLAY_LIMITS);
        }

        public bool ToConfigureSiteCommunications(UserRoleElements userRoleElements)
        {
            return userRoleElements.AuthorizedTo(RoleElement.CONFIGURE_SITE_COMMUNICATIONS);
        }

        public bool ToConfigureDefaultTabs(UserRoleElements userRoleElements)
        {
            return userRoleElements.AuthorizedTo(RoleElement.CONFIGURE_DEFAULT_TABS);
        }

        public bool ToConfigureWorkAssignmentNotSelectedWarning(UserRoleElements userRoleElements)
        {
            return userRoleElements.AuthorizedTo(RoleElement.CONFIGURE_WORK_ASSIGNMENT_NOT_SELECTED_WARNING);
        }

        public bool ToConfigureLabAlerts(UserRoleElements userRoleElements)
        {
            return userRoleElements.AuthorizedTo(RoleElement.CONFIGURE_LAB_ALERT);
        }

        public bool ToConfigureLinks(UserRoleElements userRoleElements)
        {
            return userRoleElements.AuthorizedTo(RoleElement.CONFIGURE_LINKS);
        }

        public bool ToConfigureWorkPermitArchivalProcess(UserRoleElements userRoleElements)
        {
            return userRoleElements.AuthorizedTo(RoleElement.CONFIGURE_WORK_PERMIT_ARCHIVAL_PROCESS);
        }

        public bool ToConfigureAutoApproveSAPActionItemDefinition(UserRoleElements userRoleElements)
        {
            return userRoleElements.AuthorizedTo(RoleElement.CONFIGURE_AUTO_APPROVE_SAP_AID);
        }

        public bool ToConfigureWorkPermitContractor(UserRoleElements userRoleElements)
        {
            return userRoleElements.AuthorizedTo(RoleElement.CONFIGURE_WORK_PERMIT_CONTRACTOR)
                   || userRoleElements.AuthorizedTo(RoleElement.ADMIN_FORM_SWP);
        }

        public bool ToConfigurePlantHistorianTagList(UserRoleElements userRoleElements)
        {
            return userRoleElements.AuthorizedTo(RoleElement.CONFIGURE_PLANT_HISTORIAN_TAG_LIST);
        }

        public bool ToConfigureCraftOrTrade(UserRoleElements userRoleElements)
        {
            return userRoleElements.AuthorizedTo(RoleElement.CONFIGURE_CRAFT_OR_TRADE)
                   || userRoleElements.AuthorizedTo(RoleElement.ADMIN_FORM_SWP);
        }

        public bool ToConfigureRoadAccessOnPermit(UserRoleElements userRoleElements)
        {
            bool retuenValue = false;
            if (ClientSession.GetUserContext().Site.Name.ToLower() == "edmonton" ||
                ClientSession.GetUserContext().Site.IdValue == 8)
            {
                retuenValue = true;
            }
            return retuenValue;
            //return userRoleElements.AuthorizedTo(RoleElement.CONFIGURE_CRAFT_OR_TRADE)
            //       || userRoleElements.AuthorizedTo(RoleElement.ADMIN_FORM_SWP); //Added this function if  suppose require in future - mangesh
        }

        public bool ToConfigureSpecialWork(UserRoleElements userRoleElements)
        {
            bool retuenValue = false;
            if (ClientSession.GetUserContext().Site.Name.ToLower() == "edmonton" ||
                ClientSession.GetUserContext().Site.IdValue == 8)
            {
                retuenValue = true;
            }
            return retuenValue;
        }

        public bool ToAdminSafeWorkPermitQuestionnaires(UserRoleElements userRoleElements)
        {
            return userRoleElements.AuthorizedTo(RoleElement.ADMIN_FORM_SWP);
        }

        public bool ToConfigureWorkAssignments(UserRoleElements userRoleElements)
        {
            return userRoleElements.AuthorizedTo(RoleElement.CONFIGURE_WORK_ASSIGNMENTS);
        }

        public bool ToConfigureDefaultFLOCsForAssignments(UserRoleElements userRoleElements)
        {
            return userRoleElements.AuthorizedTo(RoleElement.CONFIGURE_DEFAULT_FLOCS_FOR_ASSIGNMENTS);
        }

        public bool ToConfigureDefaultFLOCsForAssignmentsForPermitAutoAssignment(UserRoleElements userRoleElements)
        {
            return
                userRoleElements.AuthorizedTo(
                    RoleElement.CONFIGURE_FLOC_ASSIGNMENT_CONFIG_FOR_WORK_PERMIT_AUTO_ASSIGNMENT);
        }

        public bool ToConfigureAssignmentsForPermits(UserRoleElements userRoleElements)
        {
            return userRoleElements.AuthorizedTo(RoleElement.CONFIGURE_ASSIGNMENTS_FOR_WORK_PERMITS);
        }

        public bool ToConfigureLogGuidelines(UserRoleElements userRoleElements)
        {
            return userRoleElements.AuthorizedTo(RoleElement.CONFIGURE_LOG_GUIDELINE);
        }

        public bool ToConfigureAutoReApprovalByField(UserRoleElements userRoleElements)
        {
            return userRoleElements.AuthorizedTo(RoleElement.CONFIGURE_AUTO_RE_APPROVAL_BY_FIELD);
        }

        public bool ToConfigurePreApprovedTargetRanges(UserRoleElements userRoleElements)
        {
            return userRoleElements.AuthorizedTo(RoleElement.CONFIGURE_PREAPPROVED_TARGET_RANGES);
        }

        public bool ToConfigureCustomFields(UserRoleElements userRoleElements)
        {
            return userRoleElements.AuthorizedTo(RoleElement.CONFIGURE_SUMMARY_LOG_CUSTOM_FIELDS);
        }

        public bool ToConfigureDORCutoffTime(UserRoleElements userRoleElements)
        {
            return userRoleElements.AuthorizedTo(RoleElement.CONFIGURE_DOR_CUTOFF_TIME);
        }

        public bool ToConfigureWorkPermitMontrealTemplates(UserRoleElements userRoleElements)
        {
            return userRoleElements.AuthorizedTo(RoleElement.CONFIGURE_WORK_PERMIT_TEMPLATES);
        }

        public bool ToConfigureWorkPermitDropdowns(UserRoleElements userRoleElements)
        {
            return userRoleElements.AuthorizedTo(RoleElement.CONFIGURE_WORK_PERMIT_DROPDOWNS);
        }

        public bool ToConfigureFormDropdowns(UserRoleElements userRoleElements)
        {
            return userRoleElements.AuthorizedTo(RoleElement.CONFIGURE_FORM_DROPDOWNS);
        }

        public bool ToConfigureWorkPermitGroups(UserRoleElements userRoleElements)
        {
            return userRoleElements.AuthorizedTo(RoleElement.CONFIGURE_WORK_PERMIT_GROUPS);
        }

        public bool ToConfigureConfiguredDocumentLinks(UserRoleElements userRoleElements)
        {
            return userRoleElements.AuthorizedTo(RoleElement.CONFIGURE_CONFIGURED_DOCUMENT_LINKS);
        }

        #endregion

        #region Restriction Rules

        public bool ToViewRestrictionNavigation(UserRoleElements userRoleElements)
        {
            return userRoleElements != null && userRoleElements.AuthorizedTo(RoleElement.VIEW_RESTRICTION_NAVIGATION);
        }

        public bool ToViewRestrictionReporting(UserRoleElements userRoleElements)
        {
            if (userRoleElements == null)
            {
                return false;
            }
            return userRoleElements.AuthorizedTo(RoleElement.VIEW_RESTRICTION_REPORTING);
        }

        public bool ToCreateRestrictionDefinitions(UserRoleElements userRoleElements)
        {
            if (userRoleElements == null)
            {
                return false;
            }
            return userRoleElements.AuthorizedTo(RoleElement.CREATE_RESTRICTION_DEFINITION);
        }

        public bool ToDeleteRestrictionDefinitions(UserRoleElements userRoleElements,
            List<RestrictionDefinitionDTO> restrictionDefinitionDtos)
        {
            if (userRoleElements == null)
            {
                return false;
            }
            return userRoleElements.AuthorizedTo(RoleElement.DELETE_RESTRICTION_DEFINITION);
        }

        public bool ToEditRestrictionDefinition(UserRoleElements userRoleElements,
            RestrictionDefinitionDTO restrictionDefinitionDtos)
        {
            if (userRoleElements == null)
            {
                return false;
            }
            return userRoleElements.AuthorizedTo(RoleElement.EDIT_RESTRICTION_DEFINITION);
        }

        public bool ToRespondToDeviationAlerts(UserRoleElements userRoleElements, UserShift shift,
            DeviationAlertDTO alert)
        {
            if (userRoleElements == null)
            {
                return false;
            }

            if (!alert.HasUserEnteredResponse)
            {
                return
                    userRoleElements.HasRoleElement(alert.IsInShift(shift)
                        ? RoleElement.RESPOND_TO_DEVIATION_IN_SHIFT
                        : RoleElement.RESPOND_TO_DEVIATION_OUT_OF_SHIFT);
            }
            return
                userRoleElements.HasRoleElement(alert.IsInShift(shift)
                    ? RoleElement.EDIT_DEVIATION_RESPONSE_FOR_ALERT_IN_SHIFT
                    : RoleElement.EDIT_DEVIATION_RESPONSE_FOR_ALERT_OUT_OF_SHIFT);
        }

        public bool ToEditDeviationAlertComments(UserRoleElements userRoleElements)
        {
            if (userRoleElements == null)
            {
                return false;
            }

            return userRoleElements.HasRoleElement(RoleElement.EDIT_DEVIATION_ALERT_COMMENT);
        }

        public bool ToConfigureBusinessCategories(UserRoleElements userRoleElements)
        {
            if (userRoleElements == null)
            {
                return false;
            }

            return userRoleElements.HasRoleElement(RoleElement.CONFIGURE_BUSINESS_CATEGORIES);
        }

        public bool ToConfigureBusinessCategoryFlocAssociations(UserRoleElements userRoleElements)
        {
            if (userRoleElements == null)
            {
                return false;
            }

            return userRoleElements.HasRoleElement(RoleElement.CONFIGURE_BUSINESS_CATEGORY_FLOC_ASSOCIATION);
        }

        public bool ToConfigureRestrictionReasonCode(UserRoleElements userRoleElements)
        {
            if (userRoleElements == null)
            {
                return false;
            }
            return userRoleElements.HasRoleElement(RoleElement.CONFIGURE_RESTRICTION_REASON_CODE);
        }

        public bool ToConfigureDeviationAlertResponseTimeLimit(UserRoleElements userRoleElements)
        {
            if (userRoleElements == null)
            {
                return false;
            }
            return userRoleElements.HasRoleElement(RoleElement.CONFIGURE_DEVIATION_RESPONSE_TIME_LIMIT);
        }

        #endregion Restriction Rules

        // ayman reports
        #region Reports

        public bool ToViewFormReport(UserRoleElements userRoleElements)
        {
            return userRoleElements.AuthorizedTo(RoleElement.VIEW_FORM_REPORT);
        }

        public bool ToViewTrainingFormExcel(UserRoleElements userRoleElements)
        {
            return userRoleElements.AuthorizedTo(RoleElement.VIEW_TRAINING_FORM_EXCEL);
        }

        public bool ToViewTrainingFormReport(UserRoleElements userRoleElements)
        {
            return userRoleElements.AuthorizedTo(RoleElement.VIEW_TRAINING_FORM_REPORT);
        }

        public bool ToViewSWPAssessmentReport(UserRoleElements userRoleElements)
        {
            return userRoleElements.AuthorizedTo(RoleElement.VIEW_SWP_ASSESSMENT_REPORT);
        }

        #endregion Reports


        #region Shift Handover

        public bool ToViewShiftHandover(UserRoleElements userRoleElements)
        {
            return userRoleElements.AuthorizedTo(RoleElement.VIEW_SHIFT_HANDOVER);
        }

        public bool ToViewShiftHandoverNavigation(UserRoleElements userRoleElements)
        {
            return userRoleElements.AuthorizedTo(RoleElement.VIEW_SHIFT_HANDOVER_NAVIGATION);
        }

        public bool ToViewShiftHandoverOnPrioritiesPage(UserRoleElements userRoleElements)
        {
            return userRoleElements.AuthorizedTo(RoleElement.VIEW_SHIFT_HANDOVER_PRIORITIES);
        }

        public bool ToCreateShiftHandoverQuestionnaire(UserRoleElements userRoleElements)
        {
            return userRoleElements.AuthorizedTo(RoleElement.CREATE_SHIFT_HANDOVER_QUESTIONNAIRE);
        }

        public bool ToDeleteShiftHandoverQuestionnaire(
            User user,
            UserRoleElements userRoleElements,
            UserShift userShift,
            List<ShiftHandoverQuestionnaireDTO> dtos)
        {
            return userRoleElements.AuthorizedTo(RoleElement.DELETE_SHIFT_HANDOVER_QUESTIONNAIRE) &&
                   dtos.TrueForAll(dto => ShiftHandoverQuestionnaireCreatedBySameUserOnSameShift(dto, user, userShift));
        }

        public bool ToEditShiftHandoverQuestionnaire(
            User user,
            UserRoleElements userRoleElements,
            UserShift userShift,
            ShiftHandoverQuestionnaireDTO dto)
        {
            return userRoleElements.AuthorizedTo(RoleElement.EDIT_SHIFT_HANDOVER_QUESTIONNAIRE) &&
                   ShiftHandoverQuestionnaireCreatedBySameUserOnSameShift(dto, user, userShift);
        }

        public bool ToMarkShiftHandoverQuestionnairesAsRead(User user, ShiftHandoverQuestionnaireDTO dto)
        {
            return !dto.IsCreatedBy(user);
        }

        public bool ToEditShiftHandoverConfigurations(UserRoleElements userRoleElements)
        {
            if (userRoleElements == null)
            {
                return false;
            }
            return userRoleElements.HasRoleElement(RoleElement.EDIT_SHIFT_HANDOVER_CONFIGURATIONS);
        }

        public bool ToEditShiftHandoverEmailConfigurations(UserRoleElements userRoleElements)
        {
            if (userRoleElements == null)
            {
                return false;
            }
            return userRoleElements.HasRoleElement(RoleElement.EDIT_SHIFT_HANDOVER_EMAIL_CONFIGURATIONS);
        }

        private static bool ShiftHandoverQuestionnaireCreatedBySameUserOnSameShift(
            ShiftHandoverQuestionnaireDTO dto, User user, UserShift userShift)
        {
            /*RITM0185797 flxi shift handover */
            if (dto.IsFlexible)
            {
               return dto.CreateUserId == user.Id &&
                       userShift.IsInUserFlexiShiftIncludingPadding(dto.ShiftId, dto.FlexiShiftStartDate, dto.FlexiShiftEndDate);
            }
                return dto.CreateUserId == user.Id &&
                       userShift.IsInUserShiftIncludingPadding(dto.ShiftId, dto.CreateDateTime);
            
        }

        private static bool PermitAssessmentCreatedBySameUserOnSameShift(
            PermitAssessmentDTO dto, User user, UserShift userShift)
        {
            return dto.CreatedByUserId == user.Id &&
                   userShift.IsInUserShiftIncludingPadding(dto.CreationUserShiftPatternId, dto.CreatedDateTime);
        }

        #endregion

        #region Log Templates

        public bool ToConfigureLogTemplates(UserRoleElements userRoleElements)
        {
            if (userRoleElements == null)
            {
                return false;
            }

            return userRoleElements.HasRoleElement(RoleElement.CONFIGURE_LOG_TEMPLATES);
        }

        #endregion

        #region Lab Alerts

        public bool ToViewLabAlertsNavigation(UserRoleElements userRoleElements)
        {
            return userRoleElements != null && userRoleElements.AuthorizedTo(RoleElement.VIEW_LAB_ALERT_NAVIGATION);
        }

        public bool ToViewLabAlertDefinitionsAndLabAlerts(UserRoleElements userRoleElements)
        {
            if (userRoleElements == null)
            {
                return false;
            }
            return userRoleElements.AuthorizedTo(RoleElement.VIEW_LAB_ALERT_DEFINITIONS_AND_LAB_ALERTS);
        }

        public bool ToCreateLabAlertDefinitions(UserRoleElements userRoleElements)
        {
            if (userRoleElements == null)
            {
                return false;
            }
            return userRoleElements.AuthorizedTo(RoleElement.CREATE_LAB_ALERT_DEFINITION);
        }


        public bool ToDeleteLabAlertDefinitions(UserRoleElements userRoleElements, List<LabAlertDefinitionDTO> dtos)
        {
            if (userRoleElements == null)
            {
                return false;
            }
            return userRoleElements.AuthorizedTo(RoleElement.DELETE_LAB_ALERT_DEFINITION);
        }

        public bool ToEditLabAlertDefinition(UserRoleElements userRoleElements, LabAlertDefinitionDTO dto)
        {
            if (userRoleElements == null)
            {
                return false;
            }
            return userRoleElements.AuthorizedTo(RoleElement.EDIT_LAB_ALERT_DEFINITION);
        }

        public bool ToRespondToLabAlerts(UserRoleElements userRoleElements)
        {
            if (userRoleElements == null)
            {
                return false;
            }
            return userRoleElements.AuthorizedTo(RoleElement.RESPOND_TO_LAB_ALERT);
        }

        #endregion

        #region Coker Cards

        public bool ToViewCokerCards(UserRoleElements userRoleElements)
        {
            if (userRoleElements == null)
            {
                return false;
            }

            return userRoleElements.HasRoleElement(RoleElement.VIEW_COKER_CARD);
        }

        public bool ToCreateCokerCard(UserRoleElements userRoleElements)
        {
            if (userRoleElements == null)
            {
                return false;
            }

            return userRoleElements.HasRoleElement(RoleElement.CREATE_COKER_CARD);
        }

        public bool ToEditCokerCard(CokerCardDTO cokerCardDto, UserRoleElements userRoleElements, UserShift userShift)
        {
            if (userRoleElements == null)
            {
                return false;
            }

            return userRoleElements.AuthorizedTo(RoleElement.EDIT_COKER_CARD) &&
                   CokerCardCreatedOnSameShift(cokerCardDto, userShift);
        }

        public bool ToDeleteCokerCards(List<CokerCardDTO> cokerCardDtos, UserRoleElements userRoleElements,
            UserShift userShift)
        {
            return cokerCardDtos.TrueForAll(obj => ToDeleteCokerCards(obj, userRoleElements, userShift));
        }

        public bool ToEditCokerCardConfigurations(UserRoleElements userRoleElements)
        {
            if (userRoleElements == null)
            {
                return false;
            }

            return userRoleElements.AuthorizedTo(RoleElement.CONFIGURE_COKER_CARDS);
        }

        public bool ToConfigurePrioritiesPage(UserRoleElements userRoleElements)
        {
            if (userRoleElements == null)
            {
                return false;
            }
            return userRoleElements.AuthorizedTo(RoleElement.CONFIGURE_PRIORITIES_PAGE);
        }

        private static bool CokerCardCreatedOnSameShift(CokerCardDTO dto, UserShift userShift)
        {
            return userShift.IsSameShift(dto.ShiftId, dto.ShiftDate);
        }

        private static bool ToDeleteCokerCards(CokerCardDTO cokerCardDto, UserRoleElements userRoleElements,
            UserShift userShift)
        {
            if (userRoleElements == null)
            {
                return false;
            }

            return userRoleElements.AuthorizedTo(RoleElement.DELETE_COKER_CARD) &&
                   CokerCardCreatedOnSameShift(cokerCardDto, userShift);
        }

        #endregion

        #region Directives

        public bool ToViewDirectiveNavigation(UserRoleElements userRoleElements)
        {
            return directiveAuthorization.ToViewDirectiveNavigation(userRoleElements);
        }

        public bool ToViewFutureDirectives(UserRoleElements userRoleElements)
        {
            return directiveAuthorization.ToViewFutureDirectives(userRoleElements);
        }

        public bool ToEditDirective(DirectiveDTO dto, UserContext userContext, DateTime now)
        {
            var isExpired = dto.IsExpired(now);

            var allowed = directiveAuthorization.ToEdit(dto, userContext);

            return allowed && !isExpired;
        }

        public bool ToDeleteDirectives(List<DirectiveDTO> dtos, UserContext userContext, DateTime now)
        {
            var allInFuture = dtos.TrueForAll(d => d.IsInFuture(now));

            var allowed = directiveAuthorization.ToDelete(dtos, userContext);

            return allowed && allInFuture;
        }

        public bool ToExpireDirective(DirectiveDTO dto, UserContext userContext, DateTime now)
        {
            var isActiveDirective = dto.IsActive(now);

            var allowed = directiveAuthorization.ToEdit(dto, userContext);

            return allowed && isActiveDirective;
        }

        public bool ToExpireDirectives(List<DirectiveDTO> dtos, UserContext userContext, DateTime now)
        {
            var allActiveDirectives = dtos.TrueForAll(d => d.IsActive(now));

            var allowed = directiveAuthorization.ToEdit(dtos, userContext);

            return allowed && allActiveDirectives;
        }

        public bool ToMarkDirectiveAsRead(User user, DirectiveDTO dto, DateTime now)
        {
            return dto.CreatedByUserId != user.Id && !dto.IsInFuture(now);
        }

        #endregion

        
        //generic template - mangesh
        public bool ToEditFormGenericTemplate(UserRoleElements userRoleElements, FormStatus formStatus)
        {
            return ToEditForm(userRoleElements) &&
                   (FormStatus.Draft.Equals(formStatus) || FormStatus.Approved.Equals(formStatus) ||
                    FormStatus.Expired.Equals(formStatus) ||
                    FormStatus.WaitingForApproval.Equals(formStatus));
        }

        public bool ToEditFormGenericTemplate(UserContext userContext, FormStatus formStatus, EdmontonFormType formType, FormGenericTemplateDTO dto)
        {
            return formGenericTemplateAuthorization.ToEdit(dto, userContext);
        }

        public bool ToEditFormGenericTemplate(UserRoleElements userRoleElements, FormStatus formStatus,EdmontonFormType formType, Site userSite)
        {
            var canEdit = false;
            
            if (EdmontonFormType.OdourNoiseComplaint.Equals(formType))
            {   
                canEdit = userRoleElements.AuthorizedTo(RoleElement.EDIT_ODOURNOISE);
            }
            if (EdmontonFormType.Deviation.Equals(formType))
            {
                canEdit = userRoleElements.AuthorizedTo(RoleElement.EDIT_DEVIATION);
            }
            if (EdmontonFormType.RoadClosure.Equals(formType))
            {
                canEdit = userRoleElements.AuthorizedTo(RoleElement.EDIT_ROADCLOSURE);
            }
            if (EdmontonFormType.GN27FreezePlug.Equals(formType))
            {
                canEdit = userRoleElements.AuthorizedTo(RoleElement.EDIT_GN27FREEZEPLUG);
            }
            if (EdmontonFormType.GN11GroundDisturbance.Equals(formType))
            {
                canEdit = userRoleElements.AuthorizedTo(RoleElement.EDIT_GN11GROUNDDISTURBANCE);
            }
            if (EdmontonFormType.HazardAssessment.Equals(formType))
            {
                canEdit = userRoleElements.AuthorizedTo(RoleElement.EDIT_HAZARDASSESSMENT);
            }
            //TASK0593631 - mangesh
            if (EdmontonFormType.NonEmergencyWaterSystemApproval.Equals(formType))
            {
                canEdit = userRoleElements.AuthorizedTo(RoleElement.EDIT_NonEmergencyWaterSystemApproval);
            }
            //RITM0341710 - mangesh
            if (EdmontonFormType.FortHillOilSample.Equals(formType))
            {
                canEdit = userRoleElements.AuthorizedTo(RoleElement.EDIT_OILSAMPLE);
            }
            if (EdmontonFormType.FortHillDailyInspection.Equals(formType))
            {
                canEdit = userRoleElements.AuthorizedTo(RoleElement.EDIT_DAILYINSPECTION);
            }
            return canEdit &&
                   (FormStatus.Draft.Equals(formStatus) || FormStatus.Approved.Equals(formStatus) ||
                    FormStatus.Expired.Equals(formStatus) ||
                    FormStatus.WaitingForApproval.Equals(formStatus));
        }

        public bool ToDeleteFormGenericTemplate(UserRoleElements userRoleElements, FormStatus formStatus, EdmontonFormType formType, Site userSite)
        {
            var canDelete = false;

            if (EdmontonFormType.OdourNoiseComplaint.Equals(formType))
            {
                canDelete = userRoleElements.AuthorizedTo(RoleElement.DELETE_ODOURNOISE);
            }
            if (EdmontonFormType.Deviation.Equals(formType))
            {
                canDelete = userRoleElements.AuthorizedTo(RoleElement.DELETE_DEVIATION);
            }
            if (EdmontonFormType.RoadClosure.Equals(formType))
            {
                canDelete = userRoleElements.AuthorizedTo(RoleElement.DELETE_ROADCLOSURE);
            }
            if (EdmontonFormType.GN27FreezePlug.Equals(formType))
            {
                canDelete = userRoleElements.AuthorizedTo(RoleElement.DELETE_GN27FREEZEPLUG);
            }
            if (EdmontonFormType.GN11GroundDisturbance.Equals(formType))
            {
                canDelete = userRoleElements.AuthorizedTo(RoleElement.DELETE_GN11GROUNDDISTURBANCE);
            }
            if (EdmontonFormType.HazardAssessment.Equals(formType))
            {
                canDelete = userRoleElements.AuthorizedTo(RoleElement.DELETE_HAZARDASSESSMENT);
            }

            //TASK0593631 - mangesh
            if (EdmontonFormType.NonEmergencyWaterSystemApproval.Equals(formType))
            {
                canDelete = userRoleElements.AuthorizedTo(RoleElement.DELETE_NonEmergencyWaterSystemApproval);
            }
            //RITM0341710 - mangesh
            if (EdmontonFormType.FortHillOilSample.Equals(formType))
            {
                canDelete = userRoleElements.AuthorizedTo(RoleElement.DELETE_OILSAMPLE);
            }
            if (EdmontonFormType.FortHillDailyInspection.Equals(formType))
            {
                canDelete = userRoleElements.AuthorizedTo(RoleElement.DELETE_DAILYINSPECTION);
            }
            return canDelete;
        }

        public bool ToApproveOrCloseFormGenericTemplate(UserRoleElements userRoleElements, FormStatus formStatus, EdmontonFormType formType, Site userSite)
        {
            var canApproveOrClose = false;

            if (EdmontonFormType.OdourNoiseComplaint.Equals(formType))
            {   
                canApproveOrClose = userRoleElements.AuthorizedTo(RoleElement.APPROVE_ODOURNOISE);
            }
            if (EdmontonFormType.Deviation.Equals(formType))
            {
                canApproveOrClose = userRoleElements.AuthorizedTo(RoleElement.APPROVE_DEVIATION);
            }
            if (EdmontonFormType.RoadClosure.Equals(formType))
            {
                canApproveOrClose = userRoleElements.AuthorizedTo(RoleElement.APPROVE_ROADCLOSURE);
            }
            if (EdmontonFormType.GN27FreezePlug.Equals(formType))
            {
                canApproveOrClose = userRoleElements.AuthorizedTo(RoleElement.APPROVE_GN27FREEZEPLUG);
            }
            if (EdmontonFormType.GN11GroundDisturbance.Equals(formType))
            {
                canApproveOrClose = userRoleElements.AuthorizedTo(RoleElement.APPROVE_GN11GROUNDDISTURBANCE);
            }
            if (EdmontonFormType.HazardAssessment.Equals(formType))
            {
                canApproveOrClose = userRoleElements.AuthorizedTo(RoleElement.APPROVE_HAZARDASSESSMENT);
            }
            //TASK0593631 - mangesh
            if (EdmontonFormType.NonEmergencyWaterSystemApproval.Equals(formType))
            {
                canApproveOrClose = userRoleElements.AuthorizedTo(RoleElement.APPROVE_NonEmergencyWaterSystemApproval);
            }
           //RITM0341710 - mangesh
            if (EdmontonFormType.FortHillOilSample.Equals(formType))
            {
                canApproveOrClose = userRoleElements.AuthorizedTo(RoleElement.APPROVE_OILSAMPLE);
            }
            if (EdmontonFormType.FortHillDailyInspection.Equals(formType))
            {
                canApproveOrClose = userRoleElements.AuthorizedTo(RoleElement.APPROVE_DAILYINSPECTION);
            }
            return canApproveOrClose;
        }

        public bool ToCreateFormGenericTemplate(UserRoleElements userRoleElements, FormStatus formStatus, EdmontonFormType formType, Site userSite)
        {
            var canCreate = false;

            if (EdmontonFormType.OdourNoiseComplaint.Equals(formType))
            {
                canCreate = userRoleElements.AuthorizedTo(RoleElement.CREATE_ODOURNOISE);
            }
            if (EdmontonFormType.Deviation.Equals(formType))
            {
                canCreate = userRoleElements.AuthorizedTo(RoleElement.CREATE_DEVIATION);
            }
            if (EdmontonFormType.RoadClosure.Equals(formType))
            {
                canCreate = userRoleElements.AuthorizedTo(RoleElement.CREATE_ROADCLOSURE);
            }
            if (EdmontonFormType.GN27FreezePlug.Equals(formType))
            {
                canCreate = userRoleElements.AuthorizedTo(RoleElement.CREATE_GN27FREEZEPLUG);
            }
            if (EdmontonFormType.GN11GroundDisturbance.Equals(formType))
            {
                canCreate = userRoleElements.AuthorizedTo(RoleElement.CREATE_GN11GROUNDDISTURBANCE);
            }
            if (EdmontonFormType.HazardAssessment.Equals(formType))
            {
                canCreate = userRoleElements.AuthorizedTo(RoleElement.CREATE_HAZARDASSESSMENT);
            }
            //TASK0593631 - mangesh
            if (EdmontonFormType.NonEmergencyWaterSystemApproval.Equals(formType))
            {
                canCreate = userRoleElements.AuthorizedTo(RoleElement.CREATE_NonEmergencyWaterSystemApproval);
            }

            //RITM0341710 - mangesh
            if (EdmontonFormType.FortHillOilSample.Equals(formType))
            {
                canCreate = userRoleElements.AuthorizedTo(RoleElement.CREATE_OILSAMPLE);
            }
            if (EdmontonFormType.FortHillDailyInspection.Equals(formType))
            {
                canCreate = userRoleElements.AuthorizedTo(RoleElement.CREATE_DAILYINSPECTION);
            }

            return canCreate;
        }

        public bool ToViewFormGenericTemplate(UserRoleElements userRoleElements, FormStatus formStatus, EdmontonFormType formType, Site userSite)
        {
            var canView = false;

            if (EdmontonFormType.OdourNoiseComplaint.Equals(formType))
            {   
                canView = userRoleElements.AuthorizedTo(RoleElement.VIEW_ODOURNOISE);
            }
            if (EdmontonFormType.Deviation.Equals(formType))
            {
                canView = userRoleElements.AuthorizedTo(RoleElement.VIEW_DEVIATION);
            }
            if (EdmontonFormType.RoadClosure.Equals(formType))
            {
                canView = userRoleElements.AuthorizedTo(RoleElement.VIEW_ROADCLOSURE);
            }
            if (EdmontonFormType.GN27FreezePlug.Equals(formType))
            {
                canView = userRoleElements.AuthorizedTo(RoleElement.VIEW_GN27FREEZEPLUG);
            }
            if (EdmontonFormType.GN11GroundDisturbance.Equals(formType))
            {
                canView = userRoleElements.AuthorizedTo(RoleElement.VIEW_GN11GROUNDDISTURBANCE);
            }
            if (EdmontonFormType.HazardAssessment.Equals(formType))
            {
                canView = userRoleElements.AuthorizedTo(RoleElement.VIEW_HAZARDASSESSMENT);
            }

            //TASK0593631 - mangesh
            if (EdmontonFormType.NonEmergencyWaterSystemApproval.Equals(formType))
            {
                canView = userRoleElements.AuthorizedTo(RoleElement.VIEW_NonEmergencyWaterSystemApproval);
            }
            //RITM0341710 - mangesh
            if (EdmontonFormType.FortHillOilSample.Equals(formType))
            {
                canView = userRoleElements.AuthorizedTo(RoleElement.VIEW_OILSAMPLE);
            }
            if (EdmontonFormType.FortHillDailyInspection.Equals(formType))
            {
                canView = userRoleElements.AuthorizedTo(RoleElement.VIEW_DAILYINSPECTION);
            }
            return canView;
        }

        /* DMND0009632 - Fort Hills OLT - E-Permit Development*/

        public bool ToEditPermitRequest(UserRoleElements userRoleElements, List<PermitRequestFortHillsDTO> dtos)
        {
            return userRoleElements.AuthorizedTo(RoleElement.EDIT_PERMIT_REQUEST);
        }
        public bool ToEditWorkPermit(UserRoleElements userRoleElements, WorkPermitFortHillsDTO workPermit)
        {
            if (userRoleElements == null || workPermit == null)
            {
                return false;
            }

            return (workPermit.WorkPermitStatus.Id == PermitRequestBasedWorkPermitStatus.Requested.Id ||
                    workPermit.WorkPermitStatus.Id == PermitRequestBasedWorkPermitStatus.Pending.Id) &&
                   userRoleElements.AuthorizedTo(RoleElement.UPDATE_PERMIT_NO_RESTRICTIONS);
        }
        private static bool ToCloseWorkPermit(UserRoleElements userRoleElements, WorkPermitFortHillsDTO workPermit)
        {
            if (userRoleElements == null || workPermit == null)
            {
                return false;
            }

            return userRoleElements.AuthorizedTo(RoleElement.CLOSE_PERMIT);
        }
        public bool ToPrintWorkPermit(UserRoleElements userRoleElements, WorkPermitFortHillsDTO workPermit)
        {
            if (!ToPrintWorkPermit(userRoleElements, workPermit.WorkPermitStatus))
            {
                return false;
            }

            if (PermitRequestBasedWorkPermitStatus.Pending.Equals(workPermit.WorkPermitStatus) &&
                workPermit.EndDateTime < Clock.Now)
            {
                return false;
            }

            return HasPrintPermitRoleElement(userRoleElements);
        }
        private static bool ToDeleteWorkPermit(UserRoleElements userRoleElements, WorkPermitFortHillsDTO workPermit)
        {
            if (userRoleElements == null || workPermit == null)
            {
                return false;
            }

            return (workPermit.Status.Id == PermitRequestBasedWorkPermitStatus.Requested.Id ||
                    workPermit.Status.Id == PermitRequestBasedWorkPermitStatus.Pending.Id) &&
                   userRoleElements.AuthorizedTo(RoleElement.DELETE_PERMIT);
        }
        public bool ToPrintWorkPermits(UserRoleElements userRoleElements, List<WorkPermitFortHillsDTO> workPermits)
        {
            return workPermits.TrueForAll(permit => ToPrintWorkPermit(userRoleElements, permit));
        }
        public bool ToCloseWorkPermits(UserRoleElements userRoleElements, List<WorkPermitFortHillsDTO> workPermits)
        {
            return workPermits.TrueForAll(permit => ToCloseWorkPermit(userRoleElements, permit));
        }
        public bool ToDeleteWorkPermits(UserRoleElements userRoleElements, List<WorkPermitFortHillsDTO> workPermits)
        {
            return workPermits.TrueForAll(permit => ToDeleteWorkPermit(userRoleElements, permit));
        }

    }
}