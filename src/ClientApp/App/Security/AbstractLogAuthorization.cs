using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO;

namespace Com.Suncor.Olt.Client.Security
{
    public abstract class AbstractLogAuthorization<T> : AbstractRoleBasedAuthorization<T> 
        where T : class, ICreatedByARole, IShiftBased
    {
        protected abstract RoleElement DeleteRoleElement { get; }

        protected static bool IsCreatedOnSameShift(IShiftBased dto, UserShift userShift)
        {
            return userShift.IsInUserShiftIncludingPadding(dto.CreatedShiftPatternId, dto.CreatedDateTime);
        }       

        public override bool ToEdit(T dto, UserContext userContext)
        {
            //RITM0221979 Request for changing edit feature in OLT logs- UDS only
            if (userContext.SiteConfiguration.AllowEditingOfOldLogs)
            {
                return base.ToEdit(dto, userContext);
            }
            else
            {
            return base.ToEdit(dto, userContext) &&
                   IsCreatedOnSameShift(dto, userContext.UserShift);
            }
        }

        public bool ToDelete(List<T> dtos, UserContext userContext)
        {
            return dtos.TrueForAll(dto => ToDelete(dto, userContext));
        }

        public virtual bool ToDelete(T dto, UserContext userContext)
        {
            if (dto == null)
            {
                return false;
            }

            return IsPermittedToDoAction(userContext, DeleteRoleElement, dto) && IsCreatedOnSameShift(dto, userContext.UserShift);
        }

        public bool ToMarkAsRead(T dto, User user)
        {
            if (dto == null || user == null)
            {
                return false;
            }

            return dto.CreatedByUserId != user.IdValue;
        }
    }
}
