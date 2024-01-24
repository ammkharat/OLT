using System.Collections.Generic;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;

namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface IWorkPermitMontrealDao : IDao
    {
        WorkPermitMontreal QueryById(long id);
        // #3003 (Caching) - should move permit request id to be part of the WorkPermitMontreal domain object so that we can cache this!
        WorkPermitMontreal Insert(WorkPermitMontreal workPermit, long? permitRequestId);
        bool DoesPermitRequestMontrealAssociationExist(List<PermitRequestMontrealDTO> permitRequests, Date workPermitStartDate);
        void Update(WorkPermitMontreal workPermit);

        WorkPermitMontreal InsertTemplate(WorkPermitMontreal workPermit);
        WorkPermitMontreal QueryByIdTemplate(long id, string templateName, string categories);

        void Remove(WorkPermitMontreal workPermit);
        void RemoveTemplate(WorkPermitMontreal workPermit); //Added By Vibhor : RITM0613645 : OLT - Template Easy clone **Delete Feature**
        WorkPermitMontreal UpdateTemplate(WorkPermitMontreal workPermit); //Added By Vibhor : RITM0613645 : OLT - Template Easy clone **Edit Feature**
        bool HasUserReadAtLeastOneDocumentLink(long userId, long workPermitMontrealId);
        void InsertWorkPermitMontrealUserReadDocumentLinkAssociation(long userId, long workPermitMontrealId);
        WorkPermitMontreal QueryPreviousDayIssuedPermitForSamePermitRequest(WorkPermitMontreal permit);
    }
}