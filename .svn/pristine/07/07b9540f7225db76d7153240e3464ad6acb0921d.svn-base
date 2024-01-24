using System.Collections.Generic;
using System.ServiceModel;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Common.Services
{
    [ServiceContract]
    public interface IFunctionalLocationInfoService
    {
        [OperationContract]
        List<FunctionalLocationInfo> QueryDivisionsBySiteIdForAdmin(long siteId);

        [OperationContract]
        List<FunctionalLocationInfo> QueryDivisionsBySiteId(long siteId);

        [OperationContract]
        List<FunctionalLocationInfo> QueryByParentFunctionalLocationForAdmin(FunctionalLocation floc);

        [OperationContract]
        List<FunctionalLocationInfo> QueryByParentFunctionalLocation(FunctionalLocation floc);

        [OperationContract]
        List<FunctionalLocationInfo> QueryUnitsBySiteIdForAdmin(long siteId);

        [OperationContract]
        List<FunctionalLocationInfo> QueryUnitsBySiteId(long siteId);
    }
}