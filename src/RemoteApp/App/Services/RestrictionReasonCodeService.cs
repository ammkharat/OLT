using System;
using System.Collections.Generic;
using System.ServiceModel;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Restriction;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Remote.DataAccess;
using Com.Suncor.Olt.Remote.DataAccess.Domain;

namespace Com.Suncor.Olt.Remote.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class RestrictionReasonCodeService : IRestrictionReasonCodeService
    {
        private readonly IRestrictionReasonCodeDao restrictionReasonCodeDao;        

        public RestrictionReasonCodeService()
        {            
            restrictionReasonCodeDao = DaoRegistry.GetDao<IRestrictionReasonCodeDao>();
        }

        public RestrictionReasonCode QueryById(long id)
        {
            return restrictionReasonCodeDao.QueryById(id);
        }

        public List<RestrictionReasonCode> QueryAll(long siteid)      // ayman restriction reason codes
        {
            return restrictionReasonCodeDao.QueryAll(siteid);
        }

        public RestrictionReasonCode Insert(RestrictionReasonCode restrictionReasonCode)
        {
            return restrictionReasonCodeDao.Insert(restrictionReasonCode);
        }

        public void DeleteReasonCodeList(List<RestrictionReasonCode> deleteList, User lastModifiedUser, DateTime lastModifiedDate,long siteid)      //ayman restriction reason codes
        {
            foreach (RestrictionReasonCode reasonCode in deleteList)
            {
                reasonCode.LastModifiedBy = lastModifiedUser;
                reasonCode.LastModifiedDate = lastModifiedDate;
                restrictionReasonCodeDao.Remove(reasonCode);
            }
        }

        public void UpdateReasonCodeList(List<RestrictionReasonCode> updateList, User lastModifiedUser, DateTime lastModifiedDate, long siteid)       //ayman restriction reason codes
        {
            foreach (RestrictionReasonCode restrictionReasonCode in updateList)
            {
                restrictionReasonCode.LastModifiedBy = lastModifiedUser;
                restrictionReasonCode.LastModifiedDate = lastModifiedDate;
                restrictionReasonCode.SiteID = siteid;
                restrictionReasonCodeDao.Update(restrictionReasonCode);
            }
        }

        public void AddReasonCodeList(List<RestrictionReasonCode> addList, User lastModifiedUser, DateTime lastModifiedDate, long siteid)       //ayman restriction reason codes
        {
            foreach (RestrictionReasonCode restrictionReasonCode in addList)
            {
                restrictionReasonCode.LastModifiedBy = lastModifiedUser;
                restrictionReasonCode.LastModifiedDate = lastModifiedDate;
                restrictionReasonCodeDao.Insert(restrictionReasonCode);
            }
        }
    }
}
