using System.Collections.Generic;
using System.ServiceModel;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.DTO;

namespace Com.Suncor.Olt.Common.Services
{
    [ServiceContract]
    public interface IFunctionalLocationOperationalModeService
    {
        [OperationContract]
        List<FunctionalLocationOperationalModeDTO> GetBySiteId(long siteId);

        [OperationContract]
        void Update(List<FunctionalLocationOperationalModeDTO> modifiedOpModeList, User lastModifiedUser);

        [OperationContract]
        FunctionalLocationOperationalModeDTO GetByFunctionalLocationId(long functionalLocationId);

        [OperationContract]
        void InsertDefault(FunctionalLocation unitLevelFunctionalLocation, User lastModifiedUser);
    }
}