using System;
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
    public interface IWorkPermitFortHillsService
    {
        [OperationContract]
        List<NotifiedEvent> Insert(WorkPermitFortHills workPermit);

        [OperationContract]
        List<NotifiedEvent> InsertMergePermit(WorkPermitFortHills workPermit, List<long> mergeSourceIds);

        [OperationContract]
        WorkPermitFortHills QueryById(long id);

        [OperationContract]
        DateTime? QueryLatestExpiryDateByPermitRequestId(long permitRequestId);

        [OperationContract]
        IList<WorkPermitFortHillsDTO> QueryByDateRangeAndFlocs(Range<Date> dateRange, RootFlocSet flocSet);

        [OperationContract]
        IList<WorkPermitFortHillsDTO> QueryByDateRangeAndFlocsForTurnaround(Range<Date> dateRange, RootFlocSet flocSet);

        [OperationContract]
        IList<WorkPermitFortHillsDTO> QueryByDateRangeAndFlocsForAllButTurnaround(Range<Date> dateRange,
            RootFlocSet rootFlocSet);

        [OperationContract]
        List<NotifiedEvent> Update(WorkPermitFortHills workPermit);

        [OperationContract]
        WorkPermitFortHills QueryPreviousDayIssuedPermitForSamePermitRequest(WorkPermitFortHills permit);

        [OperationContract]
        List<NotifiedEvent> InsertWithPermitRequestEdmontonAssociation(WorkPermitFortHills workPermit,
            PermitRequestFortHills request);

        [OperationContract]
        bool DoesPermitRequestFortHillsAssociationExist(List<PermitRequestFortHillsDTO> submittedRequests,
            Date workPermitStartDate);

        [OperationContract]
        List<NotifiedEvent> Remove(WorkPermitFortHills permit);

        [OperationContract]
        List<NotifiedEvent> UpdateAndInsertLogs(List<WorkPermitFortHills> workPermits,
            Dictionary<long, Log> permitIdToAssociatedLogMap);

        [OperationContract]
        List<WorkPermitFortHillsGroup> QueryAllGroups();

        [OperationContract]
        List<NotifiedEvent> UpdateAndInsertActionItems(PermitRequestFortHills workPermits, ActionItemDefinition permitIdToAssociatedActionItemDefinitionsMap);

        //[OperationContract]
        //List<WorkPermitFortHillsDTO> QueryDtosByFormGN59Id(long id);

        //[OperationContract]
        //List<WorkPermitFortHillsDTO> QueryDtosByFormGN7Id(long id);

        //[OperationContract]
        //List<WorkPermitFortHillsDTO> QueryDtosByFormGN24Id(long id);

        //[OperationContract]
        //List<WorkPermitFortHillsDTO> QueryDtosByFormGN6Id(long id);

        //[OperationContract]
        //List<WorkPermitFortHillsDTO> QueryDtosByFormGN75AId(long id);

        //[OperationContract]
        //List<WorkPermitFortHillsDTO> QueryDtosByFormGN1Id(long id);

        //[OperationContract]
        //List<WorkPermitFortHills> QueryByFormGN59Id(long id);

        //[OperationContract]
        //List<WorkPermitFortHills> QueryByFormGN7Id(long id);

        //[OperationContract]
        //List<WorkPermitFortHills> QueryByFormGN24Id(long id);

        //[OperationContract]
        //List<WorkPermitFortHills> QueryByFormGN75AId(long id);

        //[OperationContract]
        //List<WorkPermitFortHills> QueryByFormGN1Id(long id);

        //[OperationContract]
        //List<WorkPermitFortHills> QueryByFormGN6Id(long id);

        [OperationContract]
        List<WorkPermitFortHillsHazardDTO> QueryByFlocsAndStatuses(IFlocSet flocSet,
            List<PermitRequestBasedWorkPermitStatus> statuses);
    }
}