using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Utility;
using log4net;

namespace Com.Suncor.Olt.Remote.Utilities
{
    public class LubesMergingPermitRequestPersistenceProcessor : AbstractMergingPermitRequestPersistanceProcessor
    {
        private readonly List<WorkOrderImportData> workOrderImportDataList;

        private static readonly ILog logger = GenericLogManager.GetLogger<LubesMergingPermitRequestPersistenceProcessor>();

        public LubesMergingPermitRequestPersistenceProcessor(List<IMergeablePermitRequest> existingPermitRequests, List<ISAPImportData> incomingPermitRequests, List<WorkOrderImportData> workOrderImportDataList, DateTime now, User user) 
            : base(existingPermitRequests, incomingPermitRequests, now, user)
        {
            this.workOrderImportDataList = workOrderImportDataList;
        }

        protected override Time GetPermitDefaultDayStart()
        {
            return WorkPermitLubes.StartOfDefaultDayShift;
        }

        protected override IMergeablePermitRequest MergeList(List<ISAPImportData> listOfLikeDatedItems)
        {
            PermitRequestLubesMergeTool mergeTool = new PermitRequestLubesMergeTool(workOrderImportDataList);
            List<PermitRequestLubes> permitRequests = listOfLikeDatedItems.ConvertAll(e => (PermitRequestLubes)e);
            PermitRequestLubes mergedPermitRequest = mergeTool.Merge(permitRequests);           
            return mergedPermitRequest;            
        }

        protected override IMergeablePermitRequest ConvertImportDataToPermitRequest(ISAPImportData importData)
        {
            return (PermitRequestLubes) importData;
        }

        protected override DoNotMergeMergeKey CreateDoNotMergeKey(ISAPImportData doNotMergeOperation)
        {
            PermitRequestLubes permitRequest = (PermitRequestLubes)doNotMergeOperation;

            if(permitRequest.WorkOrderSourceList.Count != 1)
            {
                // These are pre-merge so it should have 1 source.
                throw new InvalidOperationException("There should never be more or less than 1 source list item for an incoming permit request.");
            }

            return new DoNotMergeMergeKey(permitRequest.WorkOrderNumber, permitRequest.WorkOrderSourceList[0].OperationNumber);
        }

        protected override MergeKey CreateMergeKey(ISAPImportData dataItem)
        {
            // We know that in this case it's a PermitRequestLubes.
            PermitRequestLubes permitRequest = (PermitRequestLubes) dataItem;           
            string group = permitRequest.RequestedByGroup != null ? permitRequest.RequestedByGroup.Name : null;
            return new MergeKey(dataItem.WorkOrderNumber, dataItem.SAPWorkCentre, group);
        }

        protected override void UpdateExistingPermitRequestWhenNotFoundInImportAndShouldHaveBeen(IMergeablePermitRequest existingPermitRequest)
        {
            existingPermitRequest.CompletionStatus = PermitRequestCompletionStatus.Expired;
        }

        protected override void ProcessUpdateScenarioForExistingPermitRequest(IMergeablePermitRequest existing, IMergeablePermitRequest incoming, List<long> existingPermitRequestsReplacedByNewOnes)
        {
            PermitRequestLubes existingPermitRequest = (PermitRequestLubes) existing;
            PermitRequestLubes incomingPermitRequest = (PermitRequestLubes) incoming;
   
            if (!existingPermitRequest.IsModified)
            {
                numberOfPermitRequestsProcessed++;
                incomingPermitRequest.Id = existingPermitRequest.IdValue;
                incomingPermitRequest.LastSubmittedByUser = existingPermitRequest.LastSubmittedByUser;
                incomingPermitRequest.LastSubmittedDateTime = existingPermitRequest.LastSubmittedDateTime;                
                UpdateList.Add(incomingPermitRequest);
                existingPermitRequestsReplacedByNewOnes.Add(existingPermitRequest.IdValue);                
            }
            else
            {
                existingPermitRequest.LastImportedByUser = incomingPermitRequest.LastImportedByUser;
                existingPermitRequest.LastImportedDateTime = incomingPermitRequest.LastImportedDateTime;
                existingPermitRequest.LastModifiedBy = incomingPermitRequest.LastModifiedBy;
                existingPermitRequest.LastModifiedDateTime = incomingPermitRequest.LastModifiedDateTime;

                existingPermitRequest.UpdateFromSAPPermitRequest(incomingPermitRequest);
                UpdateList.Add(existingPermitRequest);
            }
        }
    }
}
