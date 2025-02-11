using System.Collections.Generic;
using System.ServiceModel;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.DTO;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Common.Services
{
    [ServiceContract]
    public interface IWorkPermitMontrealService
    {
        [OperationContract]
        List<NotifiedEvent> Insert(WorkPermitMontreal workPermit);

        [OperationContract]
        List<NotifiedEvent> InsertWithUserReadDocumentLinkAssociation(WorkPermitMontreal workPermit,
            bool userReadDocumentLink);

        [OperationContract]
        List<WorkPermitMontrealDTO> QueryByDateRangeAndFlocs(Range<Date> dateRange, IFlocSet flocSet);

        [OperationContract]
        List<WorkPermitMontrealDTO> QueryByDateRangeAndFlocsTemplate(Range<Date> dateRange, IFlocSet flocSet, string username);

        [OperationContract]
        List<NotifiedEvent> Update(WorkPermitMontreal workPermit);

        [OperationContract]
        List<NotifiedEvent> UpdateWithUserReadDocumentLinkAssociation(WorkPermitMontreal workPermit,
            bool userReadDocumentLink);

        [OperationContract]
        List<NotifiedEvent> UpdateAndInsertLogs(List<WorkPermitMontreal> workPermits,
            Dictionary<long, Log> permitIdToAssociatedLogMap);

        [OperationContract]
        WorkPermitMontreal QueryById(long id);

        [OperationContract]
        WorkPermitMontreal QueryByIdTemplate(long id, string templateName, string categories);

        [OperationContract]
        List<NotifiedEvent> Remove(WorkPermitMontreal workPermit);

        [OperationContract]
        List<NotifiedEvent> RemoveTemplate(WorkPermitMontreal workPermit); //Added By Vibhor : RITM0613645 : OLT - Template Easy clone **Delete Feature**

        [OperationContract]
        List<NotifiedEvent> UpdateTemplate(WorkPermitMontreal workPermit); //Added By Vibhor : RITM0613645 : OLT - Template Easy clone **Edit Feature**

        [OperationContract]
        List<NotifiedEvent> InsertWithPermitRequestMontrealAssociation(WorkPermitMontreal workPermitMonreal,
            PermitRequestMontreal permitRequestMontreal);

        [OperationContract]
        bool DoesPermitRequestMontrealAssociationExist(List<PermitRequestMontrealDTO> submittedRequests,
            Date workPermitStartDate);

        [OperationContract]
        List<WorkPermitMontrealGroup> QueryAllGroups();

        [OperationContract]
        void SaveWorkPermitGroups(List<WorkPermitMontrealGroup> insertList, List<WorkPermitMontrealGroup> updateList,
            List<WorkPermitMontrealGroup> deleteList);

        [OperationContract]
        bool HasUserReadAtLeastOneDocumentLink(long userId, long workPermitMontrealId);

        [OperationContract]
        bool HasUserReadAtLeastOneDocumentLinkInEachPermit(long userId, List<long> workPermitMontrealIds);

        [OperationContract]
        void InsertUserReadDocumentLinkAssociation(long workPermitId, long userId);
 
        [OperationContract]
        WorkPermitMontreal QueryPreviousDayIssuedPermitForSamePermitRequest(WorkPermitMontreal permit);
 
    }
}