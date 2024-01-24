using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Client.Security
{   //ayman enhance forms
    public class FormOilsandsTrainingAuthorization : AbstractRoleBasedAuthorization<FormOilsandsTrainingDTO>
    {
        protected override RoleElement ViewRoleElement
        {
            get { return RoleElement.VIEW_FORM_TRAINING; }
        }

        protected override RoleElement CreateRoleElement
        {
            get { return RoleElement.CREATE_FORM_TRAINING; }
        }

        protected override RoleElement EditRoleElement
        {
            get { return RoleElement.EDIT_FORM; }            //ayman training form edit fix
        }

        public bool ToDelete(FormOilsandsTrainingDTO dto, UserContext userContext)
        {
            if (dto == null)
            {
                return false;
            }

            return IsPermittedToDoAction(userContext, RoleElement.DELETE_FORM_TRAINING, dto);
        }
    }
}
