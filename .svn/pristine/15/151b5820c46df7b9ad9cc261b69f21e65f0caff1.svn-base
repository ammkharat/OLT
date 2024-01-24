using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    // #3003 (Caching) - should move permit request id to be part of the WorkPermitLubes domain object so that we can cache this!
    public interface IWorkPermitLubesDao : IDao
    {
        WorkPermitLubes QueryById(long id);        
        WorkPermitLubes Insert(WorkPermitLubes workPermit, long? permitRequestId);
        void Update(WorkPermitLubes workPermit);
        void Remove(WorkPermitLubes workPermit);
        bool DoesPermitRequestLubesAssociationExist(List<long> permitRequests, Range<DateTime> rangeOfExistingPermits);
        WorkPermitLubes QueryPreviousDayIssuedPermitForSamePermitRequest(WorkPermitLubes permit);
    }
}
