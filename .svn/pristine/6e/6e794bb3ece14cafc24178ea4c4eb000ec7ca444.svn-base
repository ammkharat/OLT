using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Remote.Caching;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface IPermitAttributeDao : IDao
    {
        [CachedQueryBySiteId]
        List<PermitAttribute> QueryBySiteId(long siteId);

        IEnumerable<PermitAttribute> QueryByPermitRequestMontreal(PermitRequestMontreal permitRequest);
        IEnumerable<PermitAttribute> QueryByWorKPermitMontreal(WorkPermitMontreal permit);
        //RITM0301321 mangesh
        IEnumerable<PermitAttribute> QueryByPermitRequestMuds(PermitRequestMuds permitRequest);
    }
}