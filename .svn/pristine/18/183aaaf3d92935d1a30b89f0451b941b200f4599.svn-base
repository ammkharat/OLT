using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;

namespace Com.Suncor.Olt.Remote.Utilities
{
    public class EdmontonMergingPermitRequestPersistenceProcessor : AbstractMergingPermitRequestPersistanceProcessor
    {
        public EdmontonMergingPermitRequestPersistenceProcessor(
            List<IMergeablePermitRequest> existingPermitRequests, List<ISAPImportData> incomingPermitRequests, DateTime now, User user) : base(existingPermitRequests, incomingPermitRequests, now, user)
        {             
        }

        protected override IMergeablePermitRequest MergeList(List<ISAPImportData> listOfLikeDatedItems)
        {
            PermitRequestEdmontonMergeTool mergeTool = new PermitRequestEdmontonMergeTool();
            List<PermitRequestEdmonton> permitRequests = listOfLikeDatedItems.ConvertAll(e => (PermitRequestEdmonton)e);
            PermitRequestEdmonton mergedPermitRequest = mergeTool.Merge(permitRequests);
            mergedPermitRequest.RequestedStartTimeDay = WorkPermitEdmonton.PermitDefaultDayStart;
            return mergedPermitRequest;
        }

        protected override Time GetPermitDefaultDayStart()
        {
            return WorkPermitEdmonton.PermitDefaultDayStart;
        }

        protected override IMergeablePermitRequest ConvertImportDataToPermitRequest(ISAPImportData importData)
        {
            PermitRequestEdmonton pre = (PermitRequestEdmonton) importData;
            pre.RequestedStartTimeDay = WorkPermitEdmonton.PermitDefaultDayStart;
            return pre;
        }

        protected override DoNotMergeMergeKey CreateDoNotMergeKey(ISAPImportData doNotMergeOperation)
        {
            return new DoNotMergeMergeKey(doNotMergeOperation.WorkOrderNumber, doNotMergeOperation.OperationNumber);
        }

        protected override MergeKey CreateMergeKey(ISAPImportData dataItem)
        {            
            return new MergeKey(dataItem.WorkOrderNumber, dataItem.SAPWorkCentre, null);            
        }

        protected override void UpdateExistingPermitRequestWhenNotFoundInImportAndShouldHaveBeen(IMergeablePermitRequest existingPermitRequest)
        {
            existingPermitRequest.EndDate = new Date(now);
        }

        protected override void ProcessUpdateScenarioForExistingPermitRequest(IMergeablePermitRequest existingPermitRequest, IMergeablePermitRequest incomingPermitRequest, List<long> existingPermitRequestsReplacedByNewOnes)
        {
            if (existingPermitRequest.IsModified)
            {
                UpdateModifiedPermitRequest(existingPermitRequest, incomingPermitRequest);
                numberOfPermitRequestsProcessed++;
                UpdateList.Add(existingPermitRequest);
            }
            else
            {
                incomingPermitRequest.Id = existingPermitRequest.IdValue;
                incomingPermitRequest.LastSubmittedByUser = existingPermitRequest.LastSubmittedByUser;
                incomingPermitRequest.LastSubmittedDateTime = existingPermitRequest.LastSubmittedDateTime;
                numberOfPermitRequestsProcessed++;
                UpdateList.Add(incomingPermitRequest);
                existingPermitRequestsReplacedByNewOnes.Add(existingPermitRequest.IdValue);
            }
        }

    }
}
