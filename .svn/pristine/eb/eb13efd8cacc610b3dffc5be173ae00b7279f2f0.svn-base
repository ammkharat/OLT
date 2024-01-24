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
    public interface IPermitRequestEdmontonService
    {
        [OperationContract]
        List<PermitRequestEdmontonDTO> QueryByFlocUnitAndBelow(IFlocSet flocSet, DateRange dateRange);

        [OperationContract]
        PermitRequestEdmonton QueryById(long id);

        [OperationContract]
        PermitRequestEdmonton QueryByIdTemplate(long id, string templateName, string categories);

        [OperationContract]
        List<PermitRequestEdmontonDTO> QueryByCompletenessAndGroupAndDateWithinRange(
            List<PermitRequestCompletionStatus> completionStatuses, long groupId, Date date);

        [OperationContract]
        List<NotifiedEvent> Insert(PermitRequestEdmonton request);

        [OperationContract]
        List<NotifiedEvent> Update(PermitRequestEdmonton request);

        [OperationContract]
        List<NotifiedEvent> Remove(PermitRequestEdmonton request);

        [OperationContract]
        List<NotifiedEvent> RemoveTemplate(PermitRequestEdmonton request); //Added By Vibhor : RITM0613645 : OLT - Template Easy clone **Delete Feature**

        [OperationContract]
        List<NotifiedEvent> UpdateTemplate(PermitRequestEdmonton workPermit); //Added By Vibhor : RITM0613645 : OLT - Template Easy clone **Edit Feature**

        [OperationContract(Name = "SubmitRequestDtos")]
        List<NotifiedEvent> Submit(Date workPermitDate, List<PermitRequestEdmontonDTO> dtos, User user);

        [OperationContract(Name = "SubmitRequests")]
        List<NotifiedEvent> Submit(Date workPermitDate, List<PermitRequestEdmonton> requests, User user);

        [OperationContract]
        List<NotifiedEvent> SaveAndSubmit(Date workPermitDate, PermitRequestEdmonton request, User user);

        [OperationContract]
        List<PermitRequestEdmonton> QueryByFormGN59Id(long id);

        [OperationContract]
        List<PermitRequestEdmonton> QueryByFormGN6Id(long id);

        [OperationContract]
        List<PermitRequestEdmonton> QueryByFormGN7Id(long id);

        [OperationContract]
        List<PermitRequestEdmonton> QueryByFormGN24Id(long id);

        [OperationContract]
        List<PermitRequestEdmonton> QueryByFormGN75AId(long id);

        [OperationContract]
        List<PermitRequestEdmonton> QueryByFormGN1Id(long id);

        [OperationContract]
        List<PermitRequestEdmontonDTO> QueryByDateRangeAndFlocsForTurnaround(IFlocSet flocSet, DateRange dateRange);

        [OperationContract]
        List<PermitRequestEdmontonDTO> QueryByDateRangeAndFlocsForAllButTurnaround(IFlocSet flocSet, DateRange dateRange);


        [OperationContract]
        List<PermitRequestEdmontonDTO> QueryByDateRangeAndFlocsForTemplate(IFlocSet flocSet, DateRange dateRange, string username);

        [OperationContract]
        long GetNewBatchId();

        [OperationContract]
        PermitRequestImportResult Import(User user, Date from, List<FunctionalLocation> userDivisions,
            List<IHasPermitKey> importsFromCurrentSession, long batchId);

        [OperationContract]
        EdmontonPermitRequestPostFinalizeResult FinalizeImport(Date from, Date to,
            List<IHasPermitKey> incomingPermitRequests, List<IHasPermitKey> rejectList, long batchId, User currentUser);

        [OperationContract]
        DateTime? GetLastImportDateTime();
    }
}