using System;
using System.Collections.Generic;

namespace Com.Suncor.Olt.Common.Domain.WorkPermit
{
    public interface IMergeablePermitRequest : IHasPermitKey
    {
        long? Id { get; set; }
        string SAPWorkCentre { get; }
        long IdValue { get; }
        bool IsModified { get; set; }
        string SapDescription { get; set; }
        Date RequestedStartDate { get; set; }
        Date EndDate { get; set; }
        //Time RequestedStartTimeDay { get; set; }
        DateTime LastModifiedDateTime { get; set; }
        User LastModifiedBy { get; set; }
        User LastImportedByUser { get; set; }
        DateTime? LastImportedDateTime { get; set; }
        PermitRequestCompletionStatus CompletionStatus { get; set; }
        User LastSubmittedByUser { get; set; }
        DateTime? LastSubmittedDateTime { get; set; }
        List<PermitRequestWorkOrderSource> WorkOrderSourceList { get; }
        string Description { get; }
        bool IsSubmitted { get; }
        bool ContainsWorkOrderSource(IHasPermitKey key);
        void ClearWorkOrderSources();
        void AddWorkOrderSource(PermitRequestWorkOrderSource workOrderSource);
        PermitRequestCompletionStatus DetectIsComplete();
    }
}