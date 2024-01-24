using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO;

namespace Com.Suncor.Olt.Client.Security
{
    public class LogBasedDirectiveAuthorization : AbstractLogAuthorization<LogDTO>
    {
        protected override RoleElement ViewRoleElement
        {
            get { return RoleElement.VIEW_LOG_BASED_DIRECTIVES; }
        }

        protected override RoleElement CreateRoleElement
        {
            get { return RoleElement.CREATE_LOG_BASED_DIRECTIVES; }
        }

        protected override RoleElement EditRoleElement
        {
            get { return RoleElement.EDIT_LOG_BASED_DIRECTIVES; }
        }

        protected override RoleElement DeleteRoleElement
        {
            get { return RoleElement.DELETE_LOG_BASED_DIRECTIVES; }
        }

        public bool ToReplyTo(UserRoleElements userRoleElements)
        {
            return AuthorizedTo(userRoleElements, RoleElement.CREATE_LOG_BASED_DIRECTIVES);
        }

        public bool ToViewOnPrioritesPage(UserRoleElements userRoleElements)
        {
            return AuthorizedTo(userRoleElements, RoleElement.VIEW_LOG_BASED_DIRECTIVES_PRIORITIES);
        }

        public override bool ToDelete(LogDTO dto, UserContext userContext)
        {
            return base.ToDelete(dto, userContext) && !dto.HasChildren;
        }
    }
}
