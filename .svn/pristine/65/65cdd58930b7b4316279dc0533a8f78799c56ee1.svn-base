using System.Collections.Generic;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Client.Security
{
    public class PermitRequestLubesAuthorization : AbstractRoleBasedAuthorization<PermitRequestLubesDTO>
    {
        protected override RoleElement ViewRoleElement
        {
            get { return RoleElement.VIEW_PERMIT_REQUESTS; }
        }

        protected override RoleElement CreateRoleElement
        {
            get { return RoleElement.CREATE_PERMIT_REQUEST; }
        }

        protected override RoleElement EditRoleElement
        {
            get { return RoleElement.EDIT_PERMIT_REQUEST; }
        }

        protected RoleElement DeleteRoleElement
        {
            get { return RoleElement.DELETE_PERMIT_REQUEST; }
        }

        protected override bool CheckPermissionForAction(UserContext userContext, RoleElement attemptedAction, PermitRequestLubesDTO dto)
        {
            if (dto.CreatedByRoleId == PermitRequestLubesDTO.CreatedByImportRoleID)
            {
                return true;
            }

            return base.CheckPermissionForAction(userContext, attemptedAction, dto);
        }

        public bool ToDelete(List<PermitRequestLubesDTO> dtos, UserContext userContext)
        {
            return dtos.TrueForAll(dto => ToDelete(dto, userContext));
        }

        public virtual bool ToDelete(PermitRequestLubesDTO dto, UserContext userContext)
        {
            if (dto == null)
            {
                return false;
            }

            return IsPermittedToDoAction(userContext, DeleteRoleElement, dto) && dto.DataSource.Id != DataSource.SAP.Id;
        }
    }
}
