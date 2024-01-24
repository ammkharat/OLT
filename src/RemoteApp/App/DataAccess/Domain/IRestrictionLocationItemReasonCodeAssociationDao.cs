using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.Restriction;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    internal interface IRestrictionLocationItemReasonCodeAssociationDao : IDao
    {
        List<RestrictionLocationItemReasonCodeAssociation> QueryByRestrictionLocationItem(long restrictionLocationItemId);
        void InsertReasonCodeAssociations(long restrictionLocationItemId, RestrictionLocationItemReasonCodeAssociation itemReasonCodeAssociation);
    }
}