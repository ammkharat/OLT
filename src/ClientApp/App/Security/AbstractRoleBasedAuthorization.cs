using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO;

namespace Com.Suncor.Olt.Client.Security
{
    public abstract class AbstractRoleBasedAuthorization<T> where T : class, ICreatedByARole
    {
        protected static bool AuthorizedTo(UserRoleElements userRoleElements, RoleElement roleElement)
        {
            if (userRoleElements == null)
            {
                return false;
            }
            return userRoleElements.AuthorizedTo(roleElement);
        }

        protected abstract RoleElement ViewRoleElement { get; }
        protected abstract RoleElement CreateRoleElement { get; }
        protected abstract RoleElement EditRoleElement { get; }

        protected static bool HasPermissionToDoActionIfDTOIsFlaggedAsOperatingEngineerLog(
            UserRoleElements userRoleElements,
            IFlaggableAsOperatingEngineerLog dto,
            RoleElement roleElementForLogMarkedAsOperatingEngineerLog)
        {
            return dto.IsOperatingEngineerLog &&
                   userRoleElements.HasRoleElement(roleElementForLogMarkedAsOperatingEngineerLog);
        }

        protected static bool IsPreventedFromDoingActionIfDTOIsFlaggedAsOperatingEngineerLog(
            UserRoleElements userRoleElements,
            IFlaggableAsOperatingEngineerLog dto,
            RoleElement roleElementForLogMarkedAsOperatingEngineerLog)
        {
            return dto.IsOperatingEngineerLog &&
                   !userRoleElements.HasRoleElement(roleElementForLogMarkedAsOperatingEngineerLog);
        }

        protected bool IsPermittedToDoAction(UserContext userContext, RoleElement attemptedAction, T dto)
        {
            if (userContext == null ||
                userContext.UserRoleElements == null ||
                userContext.RolePermissions == null ||
                userContext.Role == null)
            {
                return false;
            }

            if (!userContext.UserRoleElements.AuthorizedTo(attemptedAction))
            {
                return false;
            }

            if (HasOverridingPermissionToDoAction(userContext, attemptedAction, dto))
            {
                return true;
            }

            if (IsPreventedFromDoingAction(userContext, attemptedAction, dto))
            {
                return false;
            }

            if (userContext.User.IdValue == dto.CreatedByUserId)
            {
                return true;
            }

            return CheckPermissionForAction(userContext, attemptedAction, dto);
        }

        protected virtual bool CheckPermissionForAction(UserContext userContext, RoleElement attemptedAction, T dto)
        {
            // Any migrated objects such as new directives with null CreatedByRoleId can be edited by anyone with permission assigned via role element.
            if (dto.CreatedByRoleId == 0) return true;

            foreach (RolePermission permission in userContext.RolePermissions)
            {
                if (permission.RoleId == userContext.Role.IdValue &&
                   permission.RoleElementId == attemptedAction.IdValue &&
                   permission.CreatedByRoleId == dto.CreatedByRoleId)
                {
                    return true;
                }
            }

            return false;
        }

        protected virtual bool HasOverridingPermissionToDoAction(UserContext userContext, RoleElement attemptedAction, T dto)
        {
            return false;
        }

        protected virtual bool IsPreventedFromDoingAction(UserContext userContext, RoleElement attemptedAction, T dto)
        {
            return false;
        }

        public bool ToView(UserRoleElements userRoleElements)
        {
            return AuthorizedTo(userRoleElements, ViewRoleElement);
        }

        public bool ToCreate(UserRoleElements userRoleElements)
        {
            return AuthorizedTo(userRoleElements, CreateRoleElement);
        }

        public virtual bool ToCopy(UserRoleElements userRoleElements)
        {
            return ToCreate(userRoleElements);
        }

        public virtual bool ToEdit(T dto, UserContext userContext)
        {
            if (dto == null)
            {
                return false;
            }
            return IsPermittedToDoAction(userContext, EditRoleElement, dto);
        }

    }
}
