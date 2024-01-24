using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Utility;
using log4net;

namespace Com.Suncor.Olt.Remote.Utilities
{
    public abstract class AbstractMergingPermitRequestPersistanceProcessor
    {
        private static readonly ILog logger = GenericLogManager.GetLogger<AbstractMergingPermitRequestPersistanceProcessor>();
        
        private readonly List<IMergeablePermitRequest> existingPermitRequests;        
        private readonly List<ISAPImportData> incomingPermitRequests;

        protected readonly DateTime now;
        private readonly User user;

        protected int numberOfPermitRequestsProcessed = 0;

        protected readonly List<IMergeablePermitRequest> updateList = new List<IMergeablePermitRequest>();
        protected readonly List<IMergeablePermitRequest> insertList = new List<IMergeablePermitRequest>();
        protected readonly List<IMergeablePermitRequest> deleteList = new List<IMergeablePermitRequest>();
        
        public AbstractMergingPermitRequestPersistanceProcessor(List<IMergeablePermitRequest> existingPermitRequests, List<ISAPImportData> incomingPermitRequests, DateTime now, User user)
        {
            this.existingPermitRequests = existingPermitRequests;
            this.incomingPermitRequests = incomingPermitRequests;

            this.now = now;
            this.user = user;
        }

        public List<IMergeablePermitRequest> UpdateList
        {
            get { return updateList; }           
        }

        public List<IMergeablePermitRequest> InsertList
        {
            get { return insertList; }
        }

        public List<IMergeablePermitRequest> DeleteList
        {
            get { return deleteList; }
        }

        public void Process()
        {
            ThrowAwayAnySubOperationsWithoutParents();

            List<long> existingPermitRequestsReplacedByNewOnes = new List<long>();

            List<IMergeablePermitRequest> mergedIncomingList = MergeAllIncomingPermitRequestsAndBuildDoNotMergeList();
           
            foreach (IMergeablePermitRequest incomingPermitRequest in mergedIncomingList)
            {
                IMergeablePermitRequest existingPermitRequest = FindExistingPermitRequestUsingMultipleSources(incomingPermitRequest, existingPermitRequestsReplacedByNewOnes);

                bool alreadyHandled = existingPermitRequest != null &&
                    (existingPermitRequest.WorkOrderSourceList.Exists(UpdateListContainsItemWithSource) || existingPermitRequest.WorkOrderSourceList.Exists(InsertListContainsItemWithSource));
                
                if (!alreadyHandled)
                {
                    if (existingPermitRequest != null)
                    {
                        ProcessUpdateScenarioForExistingPermitRequest(existingPermitRequest, incomingPermitRequest, existingPermitRequestsReplacedByNewOnes);
                    }
                    else
                    {
                        numberOfPermitRequestsProcessed++;
                        InsertList.Add(incomingPermitRequest);
                    }
                }
                
                //foreach (PermitRequestWorkOrderSource source in incomingPermitRequest.WorkOrderSourceList)
                //{
                //    IMergeablePermitRequest existingPermitRequest = FindExistingPermitRequest(source, existingPermitRequestsReplacedByNewOnes);

                //    bool alreadyHandled = UpdateListContainsItemWithSource(source) || InsertListContainsItemWithSource(source);

                //    if (!alreadyHandled)
                //    {
                //        if (existingPermitRequest != null)
                //        {
                //            ProcessUpdateScenarioForExistingPermitRequest(existingPermitRequest, incomingPermitRequest, existingPermitRequestsReplacedByNewOnes);
                //        }
                //        else
                //        {
                //            numberOfPermitRequestsProcessed++;
                //            InsertList.Add(incomingPermitRequest);
                //        }
                //    }
                //}
            }

            foreach (IMergeablePermitRequest existingPermitRequest in existingPermitRequests)
            {
                if (!UpdateList.Exists(i => existingPermitRequest.IdValue == i.Id))
                {
                    if (!existingPermitRequest.IsSubmitted)
                    {
                        DeleteList.Add(existingPermitRequest);
                    }
                    else
                    {
                        UpdateExistingPermitRequestWhenNotFoundInImportAndShouldHaveBeen(existingPermitRequest);
                        existingPermitRequest.LastModifiedDateTime = now;
                        existingPermitRequest.LastModifiedBy = user;                                                
                        UpdateList.Add(existingPermitRequest);
                    }
                }
            }
        }

        protected abstract void UpdateExistingPermitRequestWhenNotFoundInImportAndShouldHaveBeen(IMergeablePermitRequest existingPermitRequest);

        protected abstract void ProcessUpdateScenarioForExistingPermitRequest(IMergeablePermitRequest existingPermitRequest, IMergeablePermitRequest incomingPermitRequest, List<long> existingPermitRequestsReplacedByNewOnes);

        public int NumberOfPermitRequestsProcessed
        {
            get { return numberOfPermitRequestsProcessed; }
        }

        protected void UpdateModifiedPermitRequest(IMergeablePermitRequest existingPermitRequest, IMergeablePermitRequest incomingPermitRequest)
        {
            existingPermitRequest.SapDescription = incomingPermitRequest.Description;

            existingPermitRequest.RequestedStartDate = incomingPermitRequest.RequestedStartDate;
            existingPermitRequest.EndDate = incomingPermitRequest.EndDate;

            UpdateLastModifiedInformation(existingPermitRequest, incomingPermitRequest);

            existingPermitRequest.LastImportedByUser = incomingPermitRequest.LastImportedByUser;
            existingPermitRequest.LastImportedDateTime = incomingPermitRequest.LastImportedDateTime;            

            existingPermitRequest.ClearWorkOrderSources();
            incomingPermitRequest.WorkOrderSourceList.ForEach(existingPermitRequest.AddWorkOrderSource);

            existingPermitRequest.CompletionStatus = existingPermitRequest.DetectIsComplete();
        }

        protected void UpdateLastModifiedInformation(IMergeablePermitRequest existingPermitRequest, IMergeablePermitRequest incomingPermitRequest)
        {
            existingPermitRequest.LastModifiedDateTime = incomingPermitRequest.LastModifiedDateTime;
            existingPermitRequest.LastModifiedBy = incomingPermitRequest.LastModifiedBy;
        }

        private void ThrowAwayAnySubOperationsWithoutParents()
        {
            List<ISAPImportData> subOperations = incomingPermitRequests.FindAll(r => r.IsSubOperation);

            foreach (ISAPImportData subOperation in subOperations)
            {
                if(!incomingPermitRequests.Exists(r => (r.WorkOrderNumber == subOperation.WorkOrderNumber && r.OperationNumber == subOperation.OperationNumber && r.SAPWorkCentre == subOperation.SAPWorkCentre) && !r.IsSubOperation))
                {
                    incomingPermitRequests.Remove(subOperation);
                }
            }                     
        }

        private IMergeablePermitRequest FindExistingPermitRequestUsingMultipleSources(IMergeablePermitRequest incomingPermitRequest, List<long> existingPermitRequestsReplacedByNewOnes)
        {            
            List<IMergeablePermitRequest> matchingExistingRequests = existingPermitRequests.FindAll(epr => epr.WorkOrderSourceList.Exists(incomingPermitRequest.ContainsWorkOrderSource));

            if (matchingExistingRequests.Count == 0)
            {
                return null;
            }

            if (matchingExistingRequests.Count > 1)
            {
                logger.Warn("More than one existing permit request was found when looking for targets to update. OLT will take the first one.");
            }

            IMergeablePermitRequest existingMatchingRequest = matchingExistingRequests[0];

            if(existingMatchingRequest != null && existingPermitRequestsReplacedByNewOnes.Exists(t => t == existingMatchingRequest.IdValue))
            {
                return null;
            }

            return existingMatchingRequest;
        }

        public IMergeablePermitRequest FindExistingPermitRequest(IHasPermitKey key, List<long> alreadyReplacedPermitRequestIdList)
        {
            IMergeablePermitRequest permitRequest = existingPermitRequests.Find(pr => pr.ContainsWorkOrderSource(key));

            if (permitRequest != null && alreadyReplacedPermitRequestIdList.Exists(t => t == permitRequest.IdValue))
            {
                return null;
            }

            return permitRequest;
        }

        private bool UpdateListHasNoValueForCurrentSourceRecord(PermitRequestWorkOrderSource source)
        {
            return !UpdateList.Exists(i => i.ContainsWorkOrderSource(source));
        }

        private bool InsertListContainsItemWithSource(IHasPermitKey source)
        {
            return InsertList.Exists(item => item.ContainsWorkOrderSource(source));
        }

        private bool UpdateListContainsItemWithSource(IHasPermitKey source)
        {
            return UpdateList.Exists(item => item.ContainsWorkOrderSource(source));
        }

        public IMergeablePermitRequest FindExistingPermitRequest(IHasPermitKey key)
        {
            return existingPermitRequests.Find(pr => pr.ContainsWorkOrderSource(key));
        }
        
        private List<IMergeablePermitRequest> MergeAllIncomingPermitRequestsAndBuildDoNotMergeList()
        {
            Dictionary<MergeKey, List<ISAPImportData>> incomingDataMergeMap = new Dictionary<MergeKey,List<ISAPImportData>>();
            Dictionary<DoNotMergeMergeKey, List<ISAPImportData>> incomingDoNotMergeDataMergeMap = new Dictionary<DoNotMergeMergeKey, List<ISAPImportData>>();        
            
            List<ISAPImportData> itemsHandledByDoNotMergeList = new List<ISAPImportData>();
          
            List<ISAPImportData> doNotMergeOperations = incomingPermitRequests.FindAll(t => t.DoNotMerge && !t.IsSubOperation);

            foreach (ISAPImportData doNotMergeOperation in doNotMergeOperations)
            {
                List<ISAPImportData> children = 
                    incomingPermitRequests.FindAll(t => t.IsSubOperation && 
                        t.WorkOrderNumber == doNotMergeOperation.WorkOrderNumber && 
                        t.OperationNumber == doNotMergeOperation.OperationNumber && 
                        t.SAPWorkCentre == doNotMergeOperation.SAPWorkCentre);

                DoNotMergeMergeKey key = CreateDoNotMergeKey(doNotMergeOperation);
                List<ISAPImportData> values = new List<ISAPImportData> { doNotMergeOperation };
                values.AddRange(children);
                itemsHandledByDoNotMergeList.AddRange(values);
                incomingDoNotMergeDataMergeMap.Add(key, values);
            }

            foreach (ISAPImportData dataItem in incomingPermitRequests)
            {              
                if((!dataItem.DoNotMerge || dataItem.IsSubOperation) && !itemsHandledByDoNotMergeList.Exists(i => i.MatchesByPermitKey(dataItem)))
                {
                    MergeKey key = CreateMergeKey(dataItem);

                    if (!incomingDataMergeMap.ContainsKey(key))
                    {
                        incomingDataMergeMap.Add(key, new List<ISAPImportData>());
                    }

                    incomingDataMergeMap[key].Add(dataItem);
                }
            }
            
            List<IMergeablePermitRequest> mergedItems = MergeItems(incomingDataMergeMap);
            List<IMergeablePermitRequest> mergedDoNotMergeItems = MergeDoNotMergeItems(incomingDoNotMergeDataMergeMap);

            List<IMergeablePermitRequest> mergedRequests = new List<IMergeablePermitRequest>();
            mergedRequests.AddRange(mergedItems);
            mergedRequests.AddRange(mergedDoNotMergeItems);

            return mergedRequests;
        }

        protected abstract DoNotMergeMergeKey CreateDoNotMergeKey(ISAPImportData dataItem);
        protected abstract MergeKey CreateMergeKey(ISAPImportData dataItem);    

        protected abstract Time GetPermitDefaultDayStart();

        private List<IMergeablePermitRequest> MergeItems(Dictionary<MergeKey, List<ISAPImportData>> incomingDataMergeMap)
        {
            Dictionary<MergeKey, List<ISAPImportData>>.KeyCollection keyCollection = incomingDataMergeMap.Keys;
            List<IMergeablePermitRequest> mergedRequests = new List<IMergeablePermitRequest>();

            foreach (MergeKey mergeKey in keyCollection)
            {
                List<ISAPImportData> dataList = incomingDataMergeMap[mergeKey];

                if (dataList.Count == 1)
                {
                    ISAPImportData importDataItem = dataList[0];                    
                    mergedRequests.Add(ConvertImportDataToPermitRequest(importDataItem));
                }
                else
                {
                    List<List<ISAPImportData>> dataListGroupedByDates = GroupItemsByDate(incomingDataMergeMap[mergeKey]);

                    foreach (List<ISAPImportData> listOfLikeDatedItems in dataListGroupedByDates)
                    {
                        IMergeablePermitRequest mergedPermitRequest = MergeList(listOfLikeDatedItems);
                        mergedRequests.Add(mergedPermitRequest);
                    }
                }
            }

            return mergedRequests;
        }

        protected abstract IMergeablePermitRequest ConvertImportDataToPermitRequest(ISAPImportData importData);

        private List<IMergeablePermitRequest> MergeDoNotMergeItems(Dictionary<DoNotMergeMergeKey, List<ISAPImportData>> incomingDoNotMergeDataMergeMap)
        {
            Dictionary<DoNotMergeMergeKey, List<ISAPImportData>>.KeyCollection keyCollection = incomingDoNotMergeDataMergeMap.Keys;
            List<IMergeablePermitRequest> mergedRequests = new List<IMergeablePermitRequest>();

            foreach (DoNotMergeMergeKey mergeKey in keyCollection)
            {
                List<ISAPImportData> dataList = incomingDoNotMergeDataMergeMap[mergeKey];

                if (dataList.Count == 1)
                {
                    ISAPImportData singleImportItem = dataList[0];
                    mergedRequests.Add(ConvertImportDataToPermitRequest(singleImportItem));                                        
                }
                else
                {
                    List<List<ISAPImportData>> dataListGroupedByDates = GroupItemsByDate(incomingDoNotMergeDataMergeMap[mergeKey]);

                    foreach (List<ISAPImportData> listOfLikeDatedItems in dataListGroupedByDates)
                    {
                        IMergeablePermitRequest mergedPermitRequest = MergeList(listOfLikeDatedItems);
                        mergedRequests.Add(mergedPermitRequest);
                    }
                }
            }

            return mergedRequests;
        }

        protected abstract IMergeablePermitRequest MergeList(List<ISAPImportData> listOfLikeDatedItems);
              
        public static List<List<ISAPImportData>> GroupItemsByDate(List<ISAPImportData> items)
        {
            List<DateRangeGroup> groupList = new List<DateRangeGroup>();

            foreach (ISAPImportData item in items)
            {                
                List<DateRangeGroup> matching = groupList.FindAll(g => g.GroupDatesOverlapItem(item));

                if (matching.Count > 0)
                {
                    groupList.RemoveAll(g => g.GroupDatesOverlapItem(item));
                    DateRangeGroup mergedGroup = MergeGroups(matching);
                    mergedGroup.AddToGroup(item);
                    groupList.Add(mergedGroup);
                }
                else
                {
                    DateRangeGroup group = new DateRangeGroup();
                    group.AddToGroup(item);
                    groupList.Add(group);
                }
            }

            return groupList.ConvertAll(gl => new List<ISAPImportData>(gl.Items));
        }

        private static DateRangeGroup MergeGroups(List<DateRangeGroup> matching)
        {
            DateRangeGroup newGroup = new DateRangeGroup();

            foreach (DateRangeGroup dateRangeGroup in matching)
            {
                newGroup.AddToGroup(dateRangeGroup.Items);
            }

            return newGroup;
        }

        private class DateRangeGroup
        {
            private readonly List<ISAPImportData> items;

            public DateRangeGroup()
            {
                items = new List<ISAPImportData>();
            }

            public List<ISAPImportData> Items
            {
                get { return new List<ISAPImportData>(items); }
            }

            public void AddToGroup(List<ISAPImportData> newItems)
            {
                items.AddRange(newItems);
            }

            public void AddToGroup(ISAPImportData newItem)
            {
                items.Add(newItem);
            }

            public bool GroupDatesOverlapItem(ISAPImportData item)
            {
                DateRange itemRange = new DateRange(item.RequestedStartDate, item.EndDate);
                return items.Exists(i => itemRange.Overlaps(i.RequestedStartDate, i.EndDate));
            }
        }
              
        protected class DoNotMergeMergeKey
        {
            public string WorkOrderNumber { get; private set; }
            public string OperationNumber { get; private set; }

            public DoNotMergeMergeKey(string workOrderNumber, string operationNumber)
            {
                WorkOrderNumber = workOrderNumber;
                OperationNumber = operationNumber;
            }

            public bool Equals(DoNotMergeMergeKey other)
            {
                if (ReferenceEquals(null, other)) return false;
                if (ReferenceEquals(this, other)) return true;
                return Equals(other.WorkOrderNumber, WorkOrderNumber) && Equals(other.OperationNumber, OperationNumber);
            }

            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj)) return false;
                if (ReferenceEquals(this, obj)) return true;
                if (obj.GetType() != typeof (DoNotMergeMergeKey)) return false;
                return Equals((DoNotMergeMergeKey) obj);
            }

            public override int GetHashCode()
            {
                unchecked
                {
                    return ((WorkOrderNumber != null ? WorkOrderNumber.GetHashCode() : 0)*397) ^ (OperationNumber != null ? OperationNumber.GetHashCode() : 0);
                }
            }
       }
       
        protected class MergeKey
        {
            public MergeKey(string workOrderNumber, string sapWorkCentre, string requestedByGroupName)
            {
                WorkOrderNumber = workOrderNumber;
                SAPWorkCentre = sapWorkCentre;
                RequestedByGroupName = requestedByGroupName;
            }

            public string WorkOrderNumber { get; private set; }
            public string SAPWorkCentre { get; private set; }
            public string RequestedByGroupName { get; private set; }

            protected bool Equals(MergeKey other)
            {
                return string.Equals(WorkOrderNumber, other.WorkOrderNumber) && string.Equals(SAPWorkCentre, other.SAPWorkCentre) && string.Equals(RequestedByGroupName, other.RequestedByGroupName);
            }

            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj)) return false;
                if (ReferenceEquals(this, obj)) return true;
                if (obj.GetType() != this.GetType()) return false;
                return Equals((MergeKey) obj);
            }

            public override int GetHashCode()
            {
                unchecked
                {
                    int hashCode = (WorkOrderNumber != null ? WorkOrderNumber.GetHashCode() : 0);
                    hashCode = (hashCode*397) ^ (SAPWorkCentre != null ? SAPWorkCentre.GetHashCode() : 0);
                    hashCode = (hashCode*397) ^ (RequestedByGroupName != null ? RequestedByGroupName.GetHashCode() : 0);
                    return hashCode;
                }
            }
        }        
    }
}
