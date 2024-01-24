using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO;

namespace Com.Suncor.Olt.Client.Security
{
    public class LogAuthorization : AbstractLogAuthorization<LogDTO>
    {
        protected override RoleElement ViewRoleElement
        {
            get { return RoleElement.VIEW_LOG; }
        }

        protected override RoleElement CreateRoleElement
        {
            get { return RoleElement.CREATE_LOG; }
        }

        protected override RoleElement EditRoleElement
        {
            get { return RoleElement.EDIT_LOG; }
        }

        protected override RoleElement DeleteRoleElement
        {
            get { return RoleElement.DELETE_LOG; }
        }

        private RoleElement CancelRoleElement
        {
            get { return RoleElement.CANCEL_LOG; }
        }

        public bool ToViewLogsFlaggedAsOperatingEngineerLogs(UserRoleElements userRoleElements)
        {
            return AuthorizedTo(userRoleElements, RoleElement.EDIT_LOG_FLAGGED_AS_OPERATING_ENGINEER_LOG);
        }

        public bool ToReplyTo(UserRoleElements userRoleElements)
        {
            return AuthorizedTo(userRoleElements, RoleElement.REPLY_TO_LOG);
        }

        public bool ToViewNavigation(UserRoleElements userRoleElements)
        {
            return AuthorizedTo(userRoleElements, RoleElement.VIEW_LOG_NAVIGATION);
        }

        public override bool ToDelete(LogDTO dto, UserContext userContext)
        {
            return base.ToDelete(dto, userContext) && !dto.HasChildren;
        }

        public bool ToCancel(List<LogDTO> dtos, UserContext userContext)
        {
            return dtos.TrueForAll(dto => ToCancel(dto, userContext));
        }

        public bool ToCancel(LogDTO dto, UserContext userContext)
        {
            if (!dto.IsRecurring || dto.LogDefinitionDeleted.GetValueOrDefault(false))
            {
                return false;
            }
            return IsPermittedToDoAction(userContext, CancelRoleElement, dto);
        }

        public override bool ToCopy(UserRoleElements userRoleElements)
        {
            return AuthorizedTo(userRoleElements, RoleElement.COPY_LOG);
        }

        public bool ToAddShiftInformation(UserRoleElements userRoleElements)
        {
            return AuthorizedTo(userRoleElements, RoleElement.ADD_SHIFT_INFORMATION);
        }

        protected override bool HasOverridingPermissionToDoAction(UserContext userContext, RoleElement attemptedAction, LogDTO dto)
        {
            RoleElement operatingEngineerFlagPermission = GetOperatingEngineerFlagPermission(attemptedAction);
            if (operatingEngineerFlagPermission != null)
            {
                return HasPermissionToDoActionIfDTOIsFlaggedAsOperatingEngineerLog(
                    userContext.UserRoleElements, dto, operatingEngineerFlagPermission);
            }
            else
            {
                return false;
            }
        }

        protected override bool IsPreventedFromDoingAction(UserContext userContext, RoleElement attemptedAction, LogDTO dto)
        {
            RoleElement operatingEngineerFlagPermission = GetOperatingEngineerFlagPermission(attemptedAction);
            if (operatingEngineerFlagPermission != null)
            {
                return IsPreventedFromDoingActionIfDTOIsFlaggedAsOperatingEngineerLog(
                    userContext.UserRoleElements, dto, operatingEngineerFlagPermission);
            }
            else
            {
                return false;
            }
        }

        private RoleElement GetOperatingEngineerFlagPermission(RoleElement attemptedAction)
        {
            if (attemptedAction.Id == EditRoleElement.Id)
            {
                return RoleElement.EDIT_LOG_FLAGGED_AS_OPERATING_ENGINEER_LOG;
            }
            else if (attemptedAction.Id == DeleteRoleElement.Id)
            {
                return RoleElement.DELETE_LOG_FLAGGED_AS_OPERATING_ENGINEER_LOG;
            }
            else if (attemptedAction.Id == CancelRoleElement.Id)
            {
                return RoleElement.CANCEL_LOG_FLAGGED_AS_OPERATING_ENGINEER_LOG;
            }
            else
            {
                return null;
            }
        }
    }
}
