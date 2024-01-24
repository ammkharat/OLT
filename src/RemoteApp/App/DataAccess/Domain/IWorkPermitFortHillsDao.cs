using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Remote.Caching;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface IWorkPermitFortHillsDao : IDao
    {
        [CachedQueryById]
        WorkPermitFortHills QueryById(long id);
        [CachedInsertOrUpdate(false, false)]
        WorkPermitFortHills Insert(WorkPermitFortHills workPermit, long? permitRequestId);
        [CachedInsertOrUpdate(false, false)]
        void Update(WorkPermitFortHills workPermit);
        [CachedRemove(false, false)]
        void Remove(WorkPermitFortHills workPermit);
        
        DateTime? QueryLatestExpiryDateByPermitRequestId(long permitRequestId);

        WorkPermitFortHills QueryPreviousDayIssuedPermitForSamePermitRequest(WorkPermitFortHills permit);
        bool DoesPermitRequestFortHillsAssociationExist(List<long> submittedRequests, Range<DateTime> rangeOfExistingPermits);


    }
}
