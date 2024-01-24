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
    public interface IWorkPermitService
    {
        [OperationContract]
        List<WorkPermit> QueryEditablePermitsByFunctionalLocations(IFlocSet flocSet);

        [OperationContract]
        WorkPermit QueryBySapOperationWorkOrderDetails(string workOrderNumber, string operationNumber,
            string subOperation);

        //ayman USPipeline workpermit
        [OperationContract]
        WorkPermit QueryBySapOperationWorkOrderDetailsForUSPipeline(string workOrderNumber, string operationNumber,
        string subOperation);

        


        [OperationContract]
        List<WorkPermitDTO> QueryByDateRangeAndStatuses(IFlocSet flocSet,
            IList<WorkPermitStatus> statuses, Range<Date> range, WorkAssignment workAssignment);

        [OperationContract]
        List<WorkPermitDTO> QueryByDateRangeAndStatusesForTemplate(IFlocSet flocSet,
            IList<WorkPermitStatus> statuses, Range<Date> range, WorkAssignment workAssignment, bool workPermit, string username);

        [OperationContract]
        List<WorkPermitDTO> QueryOldPriorityPageWorkPermits(IFlocSet flocSet, ShiftPattern shiftPattern);

        [OperationContract]
        WorkPermit QueryById(long id);

        [OperationContract]
        WorkPermit QueryByIdTemplate(long id, string templateName, string categories);

        //ayman USPipeline workpermit
        [OperationContract]
        WorkPermit QueryByIdForUSPipeline(long id);

        [OperationContract]
        List<NotifiedEvent> Insert(WorkPermit workPermit);

        [OperationContract]
        List<NotifiedEvent> InsertTemplate(WorkPermit workPermit);

        [OperationContract(Name = "InsertWithSapWorkOrderOperation")]
        WorkPermit Insert(WorkPermit workPermit, SapWorkOrderOperation operation);

        [OperationContract]
        List<NotifiedEvent> Remove(WorkPermit workPermit);

        [OperationContract]
        List<NotifiedEvent> RemoveTemplate(WorkPermit workPermit); //Added By Vibhor : RITM0613645 : OLT - Template Easy clone **Delete Feature**

        [OperationContract]
        List<NotifiedEvent> UpdateTemplate(WorkPermit workPermit); //Added By Vibhor : RITM0613645 : OLT - Template Easy clone **Edit Feature**

        [OperationContract]
        List<NotifiedEvent> Update(WorkPermit selectedItem);

        [OperationContract]
        List<NotifiedEvent> InsertLog(WorkPermit workPermit, User modifiedBy, string logComments,
            ShiftPattern updatingUserShiftPattern, bool isOperatingEngineerLog, WorkAssignment workAssignment,
            Role createdByRole);

        [OperationContract]
        List<NotifiedEvent> CopyWorkPermit(WorkPermit sourcePermit, WorkPermit destinationPermit,
            List<WorkPermitSection> sectionsToCopy, User currentUser);

        [OperationContract]
        void DeleteInactivePendingWorkPermitsBySiteConfiguration(Site site);

        [OperationContract]
        void DeleteRejectedWorkPermits();

        [OperationContract]
        void CloseInactiveIssuedWorkPermitsBySiteConfiguration(Site site);

        [OperationContract]
        void ArchiveCompletedWorkPermitsBySiteConfiguration(Site site);

        [OperationContract]
        void UpdateWorkPermitsOnDeletedCraftOrTrade(long? craftOrTradeId);

        //Adde by Mukesh for WOrkpermit Sign
        [OperationContract]
        WorkPermitSign GetWorkPermitSign(string WorkPermitId, int SiteId);
        [OperationContract]
        void InserUpdateWorkPermitSign(WorkPermitSign workPermitSign);
        [OperationContract]
        BADGE GetBadgeInfo(string Badgenumber, string strConnection, string strQuery);
        [OperationContract]
        LenleConnection GetWorkPermitSignLenelConnection();
        
    }
}