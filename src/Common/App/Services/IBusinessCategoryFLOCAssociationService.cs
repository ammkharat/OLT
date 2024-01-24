using System;
using System.Collections.Generic;
using System.ServiceModel;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Common.Services
{
    [ServiceContract]
    public interface IBusinessCategoryFLOCAssociationService
    {
        [OperationContract]
        List<BusinessCategoryFLOCAssociation> QueryByFLOCId(long id);

        [OperationContract]
        void RecreateFLOCAssociations(List<BusinessCategoryFLOCAssociation> associationList,
            FunctionalLocation functionalLocation,
            User lastModifiedUser, DateTime lastModifiedDate);
    }
}