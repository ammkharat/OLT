using System;
using System.Collections.Generic;
using System.ServiceModel;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Remote.DataAccess;
using Com.Suncor.Olt.Remote.DataAccess.Domain;

namespace Com.Suncor.Olt.Remote.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class BusinessCategoryService : IBusinessCategoryService
    {
        private readonly IBusinessCategoryDao businessCategoryDao;
        private readonly IBusinessCategoryFLOCAssociationDao associationDao;
        
        public BusinessCategoryService()
        {
            businessCategoryDao = DaoRegistry.GetDao<IBusinessCategoryDao>();
            associationDao = DaoRegistry.GetDao<IBusinessCategoryFLOCAssociationDao>();
        }

        public List<BusinessCategory> QueryAllBySite(long siteId)
        {
            return businessCategoryDao.QueryAllBySite(siteId);
        }

        public List<BusinessCategory> Save(List<BusinessCategory> addList, List<BusinessCategory> updateList, List<BusinessCategory> deleteList,
                User lastModifiedUser, DateTime lastModifiedDate)
        {
            foreach (BusinessCategory categoryToDelete in deleteList)
            {
                categoryToDelete.LastModifiedBy = lastModifiedUser;
                categoryToDelete.LastModifiedDateTime = lastModifiedDate;
                businessCategoryDao.Remove(categoryToDelete);
            }

            foreach (BusinessCategory categoryToUpdate in updateList)
            {
                businessCategoryDao.Update(categoryToUpdate);
            }

            foreach (BusinessCategory categoryToAdd in addList)
            {
                businessCategoryDao.Insert(categoryToAdd);
            }
            return addList;
        }

        public BusinessCategory GetDefaultSAPWorkOrderCategory(long siteId)
        {
            // equipment mechanical
            return businessCategoryDao.GetDefaultSAPWorkOrderCategory(siteId); 
        }

        public BusinessCategory GetDefaultSAPNotificationCategory(long siteId)
        {
            // environmental safety
            return businessCategoryDao.GetDefaultSAPNotificationCategory(siteId);
        }

        public List<BusinessCategory> QueryUniqueCategoriesByFunctionalLocationList(List<FunctionalLocation> divisions)
        {
            List<BusinessCategory> categories = new List<BusinessCategory>();

            foreach (FunctionalLocation floc in divisions)
            {
                List<BusinessCategoryFLOCAssociation> associationsForFloc = associationDao.QueryByFLOCId(floc.Id);

                categories.AddNonDuplicatesById(associationsForFloc.ConvertAll(assoc => assoc.BusinessCategory));
                
            }

            categories.Sort(BusinessCategory.CompareByName);

            return categories;
        }
    }
}
