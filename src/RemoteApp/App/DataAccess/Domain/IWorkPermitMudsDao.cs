using System.Collections.Generic;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface IWorkPermitMudsDao : IDao
    {
        WorkPermitMuds QueryById(long id);
        // #3003 (Caching) - should move permit request id to be part of the WorkPermitMuds domain object so that we can cache this!
        WorkPermitMuds Insert(WorkPermitMuds workPermit, long? permitRequestId);
        bool DoesPermitRequestMudsAssociationExist(List<PermitRequestMudsDTO> permitRequests, Date workPermitStartDate);
        void Update(WorkPermitMuds workPermit);
        void Remove(WorkPermitMuds workPermit);
        bool HasUserReadAtLeastOneDocumentLink(long userId, long workPermitMudsId);
        void InsertWorkPermitMudsUserReadDocumentLinkAssociation(long userId, long workPermitMudsId);
        WorkPermitMuds QueryPreviousDayIssuedPermitForSamePermitRequest(WorkPermitMuds permit);

        WorkPermitMuds InsertTemplate(WorkPermitMuds workPermit);
        void RemoveTemplate(WorkPermitMuds workPermit); //Added By Vibhor : RITM0613645 : OLT - Template Easy clone **Delete Feature**

        WorkPermitMuds UpdateTemplate(WorkPermitMuds workPermit); //Added By Vibhor : RITM0613645 : OLT - Template Easy clone **Edit Feature**


        WorkPermitMuds QueryByIdTemplate(long id, string templateName, string categories);
        


        //Adde by Mukesh for WOrkpermit Sign

        WorkPermitMudSign GetWorkPermitSign(string WorkPermitId, int SiteId);
        void InserUpdateWorkPermitSign(WorkPermitMudSign workPermitSign);
    }
}