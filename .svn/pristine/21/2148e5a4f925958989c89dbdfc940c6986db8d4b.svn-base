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
    public interface IPermitRequestFortHillsService
    {
        [OperationContract]
        List<PermitRequestFortHillsDTO> QueryByFlocUnitAndBelow(IFlocSet flocSet, DateRange dateRange);

        [OperationContract]
        PermitRequestFortHills QueryById(long id);

        [OperationContract]
        List<PermitRequestFortHillsDTO> QueryByCompletenessAndGroupAndDateWithinRange(
            List<PermitRequestCompletionStatus> completionStatuses, long groupId, Date date);

        [OperationContract]
        List<NotifiedEvent> Insert(PermitRequestFortHills request);

        [OperationContract]
        List<NotifiedEvent> Update(PermitRequestFortHills request);

        [OperationContract]
        List<NotifiedEvent> Remove(PermitRequestFortHills request);

        [OperationContract(Name = "SubmitRequestDtos")]
        List<NotifiedEvent> Submit(Date workPermitDate, List<PermitRequestFortHillsDTO> dtos, User user);

        [OperationContract(Name = "SubmitRequests")]
        List<NotifiedEvent> Submit(Date workPermitDate, List<PermitRequestFortHills> requests, User user);

        [OperationContract]
        List<NotifiedEvent> SaveAndSubmit(Date workPermitDate, PermitRequestFortHills request, User user);

        //[OperationContract]
        //List<PermitRequestFortHills> QueryByFormGN59Id(long id);

        //[OperationContract]
        //List<PermitRequestFortHills> QueryByFormGN6Id(long id);

        //[OperationContract]
        //List<PermitRequestFortHills> QueryByFormGN7Id(long id);

        //[OperationContract]
        //List<PermitRequestFortHills> QueryByFormGN24Id(long id);

        //[OperationContract]
        //List<PermitRequestFortHills> QueryByFormGN75AId(long id);

        //[OperationContract]
        //List<PermitRequestFortHills> QueryByFormGN1Id(long id);

        [OperationContract]
        List<PermitRequestFortHillsDTO> QueryByDateRangeAndFlocsForTurnaround(IFlocSet flocSet, DateRange dateRange);

        [OperationContract]
        List<PermitRequestFortHillsDTO> QueryByDateRangeAndFlocsForAllButTurnaround(IFlocSet flocSet, DateRange dateRange);

        [OperationContract]
        long GetNewBatchId();

        [OperationContract]
        PermitRequestImportResult Import(User user, Date from, List<FunctionalLocation> userDivisions,
            List<IHasPermitKey> importsFromCurrentSession, long batchId);

        [OperationContract]
        FortHillsPermitRequestPostFinalizeResult FinalizeImport(Date from, Date to,
            List<IHasPermitKey> incomingPermitRequests, List<IHasPermitKey> rejectList, long batchId, User currentUser);

        [OperationContract]
        DateTime? GetLastImportDateTime();
    }
}