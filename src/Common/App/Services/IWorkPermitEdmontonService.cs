﻿using System;
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
    public interface IWorkPermitEdmontonService
    {
        [OperationContract]
        List<NotifiedEvent> Insert(WorkPermitEdmonton workPermit);

        [OperationContract]
        List<NotifiedEvent> InsertMergePermit(WorkPermitEdmonton workPermit, List<long> mergeSourceIds);

        [OperationContract]
        WorkPermitEdmonton QueryById(long id);

        [OperationContract]
        WorkPermitEdmonton QueryByIdTemplate(long id, string templateName, string categories);

        [OperationContract]
        List<NotifiedEvent> UpdateTemplate(WorkPermitEdmonton workPermit); //Added By Vibhor : RITM0613645 : OLT - Template Easy clone **Edit Feature**

        [OperationContract]
        DateTime? QueryLatestExpiryDateByPermitRequestId(long permitRequestId);

        [OperationContract]
        IList<WorkPermitEdmontonDTO> QueryByDateRangeAndFlocs(Range<Date> dateRange, RootFlocSet flocSet);

        [OperationContract]
        IList<WorkPermitEdmontonDTO> QueryByDateRangeAndFlocsForTurnaround(Range<Date> dateRange, RootFlocSet flocSet);

        [OperationContract]
        IList<WorkPermitEdmontonDTO> QueryByDateRangeAndFlocsForTemplate(Range<Date> dateRange, RootFlocSet flocSet, string username);
        

        [OperationContract]
        IList<WorkPermitEdmontonDTO> QueryByDateRangeAndFlocsForAllButTurnaround(Range<Date> dateRange,
            RootFlocSet rootFlocSet);

        [OperationContract]
        List<NotifiedEvent> Update(WorkPermitEdmonton workPermit);

        [OperationContract]
        WorkPermitEdmonton QueryPreviousDayIssuedPermitForSamePermitRequest(WorkPermitEdmonton permit);

        [OperationContract]
        List<NotifiedEvent> InsertWithPermitRequestEdmontonAssociation(WorkPermitEdmonton workPermit,
            PermitRequestEdmonton request);

        [OperationContract]
        bool DoesPermitRequestEdmontonAssociationExist(List<PermitRequestEdmontonDTO> submittedRequests,
            Date workPermitStartDate);

        [OperationContract]
        List<NotifiedEvent> Remove(WorkPermitEdmonton permit);

        [OperationContract]
        List<NotifiedEvent> RemoveTemplate(WorkPermitEdmonton permit); //Added By Vibhor : RITM0613645 : OLT - Template Easy clone **Delete Feature**

        [OperationContract]
        List<NotifiedEvent> UpdateAndInsertLogs(List<WorkPermitEdmonton> workPermits,
            Dictionary<long, Log> permitIdToAssociatedLogMap);

        [OperationContract]
        List<WorkPermitEdmontonGroup> QueryAllGroups();

        [OperationContract]
        List<WorkPermitEdmontonDTO> QueryDtosByFormGN59Id(long id);

        [OperationContract]
        List<WorkPermitEdmontonDTO> QueryDtosByFormGN7Id(long id);

        [OperationContract]
        List<WorkPermitEdmontonDTO> QueryDtosByFormGN24Id(long id);

        [OperationContract]
        List<WorkPermitEdmontonDTO> QueryDtosByFormGN6Id(long id);

        [OperationContract]
        List<WorkPermitEdmontonDTO> QueryDtosByFormGN75AId(long id);

        [OperationContract]
        List<WorkPermitEdmontonDTO> QueryDtosByFormGN1Id(long id);

        [OperationContract]
        List<WorkPermitEdmonton> QueryByFormGN59Id(long id);

        [OperationContract]
        List<WorkPermitEdmonton> QueryByFormGN7Id(long id);

        [OperationContract]
        List<WorkPermitEdmonton> QueryByFormGN24Id(long id);

        [OperationContract]
        List<WorkPermitEdmonton> QueryByFormGN75AId(long id);

        [OperationContract]
        List<WorkPermitEdmonton> QueryByFormGN1Id(long id);

        [OperationContract]
        List<WorkPermitEdmonton> QueryByFormGN6Id(long id);

        [OperationContract]
        List<WorkPermitEdmontonHazardDTO> QueryByFlocsAndStatuses(IFlocSet flocSet,
            List<PermitRequestBasedWorkPermitStatus> statuses);


        //Mukesh -DMND0010609-OLT - Work permit Scan and Index
        [OperationContract]
        void InsertWorkpermitScan(WorkpermitScan Scan);
        [OperationContract]
        List<WorkpermitScan> GetWorkpermitScan(string WorkpermitId,int SiteId);

        [OperationContract]
        List<ScanDocumentType> GetWorkPermitDocumentType(long siteId);

        [OperationContract]
        ScanCOnfiguration GetScanConfiguration(long siteId, string userlogin);

        [OperationContract]
        int isPermitnumberExist(long siteId, string @PermitNumber);
        [OperationContract]
        List<string> GetAutoSearchWorkpermit(long siteid);
        //End Mukesh -DMND0010609-OLT - Work permit Scan and Index
    }
}