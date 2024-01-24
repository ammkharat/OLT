using System;
using System.Collections.Generic;
using System.ServiceModel;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Restriction;

namespace Com.Suncor.Olt.Common.Services
{
    [ServiceContract]
    public interface IRestrictionReasonCodeService
    {
        [OperationContract]
        RestrictionReasonCode QueryById(long id);

        [OperationContract]
        List<RestrictionReasonCode> QueryAll(long siteid);                  //ayman restriction reason codes

        [OperationContract]
        RestrictionReasonCode Insert(RestrictionReasonCode restrictionReasonCode);

        [OperationContract]
        void DeleteReasonCodeList(List<RestrictionReasonCode> deleteList, User lastModifiedUser,
            DateTime lastModifiedDate, long SiteId);           //ayman restriction reason codes

        [OperationContract]
        void UpdateReasonCodeList(List<RestrictionReasonCode> updateList, User lastModifiedUser,
            DateTime lastModifiedDate,long SiteId);     //ayman restriction reason codes

        [OperationContract]
        void AddReasonCodeList(List<RestrictionReasonCode> addList, User lastModifiedUser, DateTime lastModifiedDate,long SiteId);      //ayman restriction reason codes
    }
}