using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.Restriction;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    // #3003 - if the floc association was part of the this object, and you just added/deleted/removed flocs on the Restriction Reason Code and called update, we could cache this thing.
    public interface IRestrictionReasonCodeDao : IDao
    {
        RestrictionReasonCode QueryById(long id);
        RestrictionReasonCode Insert(RestrictionReasonCode restrictionReasonCode);
        void Update(RestrictionReasonCode restrictionReasonCode);
        void Remove(RestrictionReasonCode restrictionReasonCode);
        List<RestrictionReasonCode> QueryAll(long siteid);    // ayman restriction reason codes
    }
}