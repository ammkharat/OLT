using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO;

namespace Com.Suncor.Olt.Client.Security
{
    public class DirectiveAuthorization : AbstractLogAuthorization<DirectiveDTO>
    {
        protected override RoleElement ViewRoleElement
        {
            get { return RoleElement.VIEW_NEW_DIRECTIVES; }
        }

        protected override RoleElement CreateRoleElement
        {
            get { return RoleElement.CREATE_NEW_DIRECTIVES; }
        }

        protected override RoleElement EditRoleElement
        {
            get { return RoleElement.EDIT_NEW_DIRECTIVES; }
        }

        protected override RoleElement DeleteRoleElement
        {
            get { return RoleElement.DELETE_NEW_DIRECTIVES; }
        }

        public bool ToViewDirectiveNavigation(UserRoleElements userRoleElements)
        {
            return AuthorizedTo(userRoleElements, RoleElement.VIEW_DIRECTIVE_NAVIGATION);
        }

        public bool ToViewFutureDirectives(UserRoleElements userRoleElements)
        {
            return AuthorizedTo(userRoleElements, RoleElement.VIEW_DIRECTIVES_FUTURE);
        }

        public bool ToViewOnPrioritesPage(UserRoleElements userRoleElements)
        {
            return AuthorizedTo(userRoleElements, RoleElement.VIEW_NEW_DIRECTIVES_PRIORITIES);
        }

        public bool ToEdit(List<DirectiveDTO> dtos, UserContext userContext)
        {
            return dtos.TrueForAll(dto => ToEdit(dto, userContext));
        }

        public override bool ToEdit(DirectiveDTO dto, UserContext userContext)
        {
            if (dto == null)
            {
                return false;
            }

            return IsPermittedToDoAction(userContext, EditRoleElement, dto);
        }

        public override bool ToDelete(DirectiveDTO dto, UserContext userContext)
        {
            if (dto == null)
            {
                return false;
            }

            return IsPermittedToDoAction(userContext, DeleteRoleElement, dto);
        }
    }
}