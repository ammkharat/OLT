using System.Collections.Generic;
using System.ServiceModel;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;

namespace Com.Suncor.Olt.Common.Services
{
    [ServiceContract]
    public interface IWorkPermitAutoAssignmentConfigurationService
    {
        [OperationContract]
        List<AssignmentFlocConfiguration> QueryBySite(Site site);

        [OperationContract]
        void UpdateFunctionalLocations(List<AssignmentFlocConfiguration> listToSave);

        [OperationContract]
        long? GetWorkAssignmentIdForFunctionalLocation(FunctionalLocation functionalLocation, long siteId);
    }
}