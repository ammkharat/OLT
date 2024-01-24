using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Client.Security
{   //TODO: to get particular role-element  by passing formtypeid as a parameter  
    public class FormGenericTemplateAuthorization : AbstractRoleBasedAuthorization<FormGenericTemplateDTO>
    {
        protected override RoleElement ViewRoleElement
        {
            get { return RoleElement.VIEW_ODOURNOISE; }
        }

        protected override RoleElement CreateRoleElement
        {
            get { return RoleElement.CREATE_ODOURNOISE; }
        }

        protected override RoleElement EditRoleElement
        {
            get { return RoleElement.EDIT_ODOURNOISE; }          
        }

        public bool ToDelete(FormGenericTemplateDTO dto, UserContext userContext)
        {
            if (dto == null)
            {
                return false;
            }
            
            return IsPermittedToDoAction(userContext, RoleElement.DELETE_ODOURNOISE, dto);
        }
    }
}
