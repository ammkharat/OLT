﻿using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Remote.Caching;
using Com.Suncor.Olt.Common.Domain;
namespace Com.Suncor.Olt.Remote.DataAccess.Domain
{
    public interface IWorkPermitEdmontonDao : IDao
    {
        //[CachedQueryById]
        WorkPermitEdmonton QueryById(long id);
        //[CachedInsertOrUpdate(false, false)]
        WorkPermitEdmonton Insert(WorkPermitEdmonton workPermit, long? permitRequestId);
        //[CachedInsertOrUpdate(false, false)]
        void Update(WorkPermitEdmonton workPermit);
        [CachedRemove(false, false)]
        void Remove(WorkPermitEdmonton workPermit);

        void RemoveTemplate(WorkPermitEdmonton workPermit); //Added By Vibhor : RITM0613645 : OLT - Template Easy clone **Delete Feature**

        WorkPermitEdmonton UpdateTemplate(WorkPermitEdmonton workPermit); //Added By Vibhor : RITM0613645 : OLT - Template Easy clone **Edit Feature**

        WorkPermitEdmonton InsertTemplate(WorkPermitEdmonton workPermit);

        WorkPermitEdmonton QueryByIdTemplate(long id, string templateName, string categories);
        
        DateTime? QueryLatestExpiryDateByPermitRequestId(long permitRequestId);

        WorkPermitEdmonton QueryPreviousDayIssuedPermitForSamePermitRequest(WorkPermitEdmonton permit);
        bool DoesPermitRequestEdmontonAssociationExist(List<long> submittedRequests, Range<DateTime> rangeOfExistingPermits);

        List<WorkPermitEdmonton> QueryByFormGN59Id(long id);
        List<WorkPermitEdmonton> QueryByFormGN7Id(long id);
        List<WorkPermitEdmonton> QueryByFormGN24Id(long id);
        List<WorkPermitEdmonton> QueryByFormGN6Id(long id);
        List<WorkPermitEdmonton> QueryByFormGN75AId(long id);
        List<WorkPermitEdmonton> QueryByFormGN1Id(long id);

        //Mukesh -DMND0010609-OLT - Work permit Scan and Index
        void InsertWorkpermitScan(WorkpermitScan Scan);
        List<WorkpermitScan> GetWorkpermitScan(string WorkPermitId, int siteId);
        List<ScanDocumentType> GetWorkPermitDocumentType(long siteId);
        ScanCOnfiguration GetScanConfiguration(long siteId, string userlogin);
        int isPermitnumberExist(long siteId, string PermitNumber);
        List<string> GetAutoSearchWorkpermit(long siteid);
        //End Mukesh -DMND0010609-OLT - Work permit Scan and Index
       
    }
}
