using System;
using System.Collections.Generic;
using System.ServiceModel;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Remote.DataAccess;
using Com.Suncor.Olt.Remote.DataAccess.Domain;

namespace Com.Suncor.Olt.Remote.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class BusinessCategoryFLOCAssociationService : IBusinessCategoryFLOCAssociationService
    {
        private readonly IBusinessCategoryFLOCAssociationDao associationDao;        

        public BusinessCategoryFLOCAssociationService()
        {
            associationDao = DaoRegistry.GetDao<IBusinessCategoryFLOCAssociationDao>();                        
        }

        public List<BusinessCategoryFLOCAssociation> QueryByFLOCId(long id)
        {
            return associationDao.QueryByFLOCId(id);
        }

        public void RecreateFLOCAssociations(
            List<BusinessCategoryFLOCAssociation> associationList, 
            FunctionalLocation functionalLocation, 
            User lastModifiedUser, 
            DateTime lastModifiedDate)
        {
            associationDao.DeleteAllByFLOCId(functionalLocation.Id.Value);

            foreach (BusinessCategoryFLOCAssociation association in associationList)
            {
                association.LastModifiedBy = lastModifiedUser;
                association.LastModifiedDate = lastModifiedDate;

                associationDao.Insert(association);
            }    
        }
    }
}
