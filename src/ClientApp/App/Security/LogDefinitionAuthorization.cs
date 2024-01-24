using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO;

namespace Com.Suncor.Olt.Client.Security
{
    public class LogDefinitionAuthorization : AbstractLogDefinitionAuthorization
    {
        protected override RoleElement ViewRoleElement
        {
            get { return RoleElement.VIEW_LOG_DEFINITION; }
        }

        protected override RoleElement CreateRoleElement
        {
            get { return RoleElement.CREATE_LOG_DEFINITION; }
        }

        protected override RoleElement EditRoleElement
        {
            get { return RoleElement.EDIT_LOG_DEFINITION; }
        }

        protected override RoleElement CancelRoleElement
        {
            get { return RoleElement.CANCEL_LOG; }
        }

        protected override bool HasOverridingPermissionToDoAction(UserContext userContext, RoleElement attemptedAction, LogDefinitionDTO dto)
        {
            RoleElement operatingEngineerFlagPermission = GetOperatingEngineerFlagPermission(attemptedAction);
            if (operatingEngineerFlagPermission != null)
            {
                return HasPermissionToDoActionIfDTOIsFlaggedAsOperatingEngineerLog(
                    userContext.UserRoleElements, dto, operatingEngineerFlagPermission);
            }
            return false;
        }

        protected override bool IsPreventedFromDoingAction(UserContext userContext, RoleElement attemptedAction, LogDefinitionDTO dto)
        {
            RoleElement operatingEngineerFlagPermission = GetOperatingEngineerFlagPermission(attemptedAction);
            if (operatingEngineerFlagPermission != null)
            {
                return IsPreventedFromDoingActionIfDTOIsFlaggedAsOperatingEngineerLog(
                    userContext.UserRoleElements, dto, operatingEngineerFlagPermission);
            }
            return false;
        }

        private RoleElement GetOperatingEngineerFlagPermission(RoleElement attemptedAction)
        {
            if (attemptedAction.Id == EditRoleElement.Id)
            {
                return RoleElement.EDIT_LOG_FLAGGED_AS_OPERATING_ENGINEER_LOG;
            }
            if (attemptedAction.Id == CancelRoleElement.Id)
            {
                return RoleElement.CANCEL_LOG_FLAGGED_AS_OPERATING_ENGINEER_LOG;
            }
            return null;
        }

        public bool ToEditLogDefinitionsFlaggedAsOperatingEngineerLog(UserRoleElements userRoleElements)
        {
            return userRoleElements.HasRoleElement(RoleElement.EDIT_LOG_FLAGGED_AS_OPERATING_ENGINEER_LOG);
        }
    }
}
