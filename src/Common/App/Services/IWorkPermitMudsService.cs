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
    public interface IWorkPermitMudsService
    {
        [OperationContract]
        List<NotifiedEvent> Insert(WorkPermitMuds workPermit);

        [OperationContract]
        List<NotifiedEvent> InsertWithUserReadDocumentLinkAssociation(WorkPermitMuds workPermit,
            bool userReadDocumentLink);

        [OperationContract]
        List<WorkPermitMudsDTO> QueryByDateRangeAndFlocs(Range<Date> dateRange, IFlocSet flocSet);

         [OperationContract]
        List<WorkPermitMudsTemplateDTO> QueryByDateRangeAndFlocsTemplate(Range<Date> dateRange, IFlocSet flocSet, string username);


        [OperationContract]
        List<NotifiedEvent> Update(WorkPermitMuds workPermit);

        [OperationContract]
        List<NotifiedEvent> InsertTemplate(WorkPermitMuds workPermit);

        [OperationContract]
        List<NotifiedEvent> UpdateWithUserReadDocumentLinkAssociation(WorkPermitMuds workPermit,
            bool userReadDocumentLink);

        [OperationContract]
        List<NotifiedEvent> UpdateAndInsertLogs(List<WorkPermitMuds> workPermits,
            Dictionary<long, Log> permitIdToAssociatedLogMap);

        [OperationContract]
        WorkPermitMuds QueryById(long id);

        [OperationContract]
        WorkPermitMuds QueryByIdTemplate(long id, string templateName, string categories);

        [OperationContract]
        List<NotifiedEvent> UpdateTemplate(WorkPermitMuds workPermit); //Added By Vibhor : RITM0613645 : OLT - Template Easy clone **Edit Feature**

        

        [OperationContract]
        List<NotifiedEvent> Remove(WorkPermitMuds workPermit);


        [OperationContract]
        List<NotifiedEvent> RemoveTemplate(WorkPermitMuds workPermit); //Added By Vibhor : RITM0613645 : OLT - Template Easy clone **Delete Feature**
        

        [OperationContract]
        List<NotifiedEvent> InsertWithPermitRequestMudsAssociation(WorkPermitMuds workPermitMonreal,
            PermitRequestMuds permitRequestMuds);

        [OperationContract]
        bool DoesPermitRequestMudsAssociationExist(List<PermitRequestMudsDTO> submittedRequests,
            Date workPermitStartDate);

        [OperationContract]
        List<WorkPermitMudsGroup> QueryAllGroups();

        [OperationContract]
        void SaveWorkPermitGroups(List<WorkPermitMudsGroup> insertList, List<WorkPermitMudsGroup> updateList,
            List<WorkPermitMudsGroup> deleteList);

        [OperationContract]
        bool HasUserReadAtLeastOneDocumentLink(long userId, long workPermitMudsId);

        [OperationContract]
        bool HasUserReadAtLeastOneDocumentLinkInEachPermit(long userId, List<long> workPermitMudsIds);

        [OperationContract]
        void InsertUserReadDocumentLinkAssociation(long workPermitId, long userId);
 
        [OperationContract]
        WorkPermitMuds QueryPreviousDayIssuedPermitForSamePermitRequest(WorkPermitMuds permit);

        //Adde by Mukesh for WOrkpermit Sign
        [OperationContract]
        WorkPermitMudSign GetWorkPermitSign(string WorkPermitId, int SiteId);
        [OperationContract]
        void InserUpdateWorkPermitSign(WorkPermitMudSign workPermitSign);
        //Added by ppanigrahi
        [OperationContract]
        List<NotifiedEvent> UpdateAndInsertActionItems(WorkPermitMuds workPermits,
            ActionItemDefinition actionItemDefinition);

    }
}