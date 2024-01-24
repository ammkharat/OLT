using System.Collections.Generic;
using System.ServiceModel;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Restriction;

namespace Com.Suncor.Olt.Common.Services
{
    [ServiceContract]
    public interface IRestrictionLocationService
    {
        [OperationContract]
        List<RestrictionLocation> QueryAll(long siteid);   //ayman restriction 

        [OperationContract]
        RestrictionLocation QueryById(long id);

        [OperationContract]
        List<WorkAssignment> QueryAllAssignedWorkAssignments(long siteid);     //ayman restriction

        [OperationContract]
        void Insert(RestrictionLocation restrictionLocation);

        [OperationContract]
        void Update(RestrictionLocation restrictionLocation);

        [OperationContract]
        void Remove(RestrictionLocation restrictionLocation);

        [OperationContract]
        RestrictionLocation QueryByWorkAssignment(long workAssignmentId);

        [OperationContract]
        bool AllItemsAreInGivenRestrictionLocation(long existingRestrictionLocationId,
            List<long> restrictionLocationItemsToCheck);

        [OperationContract]
        long GetNextLocationItemSequenceNumber();
    }
}