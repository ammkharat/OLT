using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Client.Security
{
    public class StandingOrderAuthorization : AbstractLogDefinitionAuthorization
    {
        protected override RoleElement ViewRoleElement
        {
            get { return RoleElement.VIEW_STANDING_ORDERS; }
        }

        protected override RoleElement CreateRoleElement
        {
            get { return RoleElement.CREATE_LOG_BASED_DIRECTIVES; }
        }

        protected override RoleElement EditRoleElement
        {
            get { return RoleElement.EDIT_LOG_BASED_DIRECTIVES; }
        }

        protected override RoleElement CancelRoleElement
        {
            get { return RoleElement.CANCEL_STANDING_ORDERS; }
        }

    }
}
