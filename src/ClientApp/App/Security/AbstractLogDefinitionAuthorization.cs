using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO;

namespace Com.Suncor.Olt.Client.Security
{
    public abstract class AbstractLogDefinitionAuthorization : AbstractRoleBasedAuthorization<LogDefinitionDTO>
    {
        protected abstract RoleElement CancelRoleElement { get; }

        public bool ToCancel(List<LogDefinitionDTO> dtos, UserContext userContext)
        {
            return dtos.TrueForAll(dto => ToCancel(dto, userContext));
        }

        private bool ToCancel(LogDefinitionDTO dto, UserContext userContext)
        {
            return IsPermittedToDoAction(userContext, CancelRoleElement, dto);
        }
    }
}
