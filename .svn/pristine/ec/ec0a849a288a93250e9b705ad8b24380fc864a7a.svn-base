using System;
using System.Collections.Generic;
using System.ServiceModel;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Common.Services
{
    [ServiceContract]
    public interface IBusinessCategoryService
    {
        [OperationContract]
        List<BusinessCategory> QueryAllBySite(long siteId);

        [OperationContract]
        List<BusinessCategory> Save(List<BusinessCategory> finalAddList, List<BusinessCategory> finalUpdateList,
            List<BusinessCategory> finalDeleteList,
            User lastModifiedUser, DateTime lastModifiedDate);

        [OperationContract]
        BusinessCategory GetDefaultSAPWorkOrderCategory(long siteId);

        [OperationContract]
        BusinessCategory GetDefaultSAPNotificationCategory(long siteId);

        [OperationContract]
        List<BusinessCategory> QueryUniqueCategoriesByFunctionalLocationList(List<FunctionalLocation> divisions);
    }
}