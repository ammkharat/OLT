using System.Collections.Generic;
using System.ServiceModel;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Common.Services
{
    [ServiceContract]
    public interface IFunctionalLocationService
    {
        [OperationContract]
        FunctionalLocation QueryById(long id);

        [OperationContract(Name = "QueryByFullHierarchy")]
        FunctionalLocation QueryByFullHierarchy(string fullHierarchy, long siteId);

        [OperationContract]
        FunctionalLocation QueryByFullHierarchyIncludeDeleted(string fullHierarchy, long siteId);

        [OperationContract]
        FunctionalLocation Insert(FunctionalLocation functionalLocation);

        [OperationContract]
        void RemoveByFullHierarchy(FunctionalLocation functionalLocation);

        [OperationContract]
        void Update(FunctionalLocation functionalLocation);

        [OperationContract]
        List<FunctionalLocation> GetSectionLevelFunctionalLocation(FunctionalLocation functionalLocation);

        [OperationContract]
        List<FunctionalLocation> GetUnitLevelAndHigherFunctionalLocationsForSite(long siteId);

        [OperationContract]
        void UndoRemove(FunctionalLocation functionalLocation);

        [OperationContract]
        List<FunctionalLocation> GetDefaultFLOCs(FunctionalLocationType highestLevelAllowedFlocType,
            List<FunctionalLocation> userSelectedRoots);

        [OperationContract]
        List<FunctionalLocation> QueryByWorkAssignmentIdForWorkPermits(long workAssignmentId);

        [OperationContract]
        List<FunctionalLocation> QueryByWorkAssignmentIdForRestrictionFlocs(long workAssignmentId);
    }
}