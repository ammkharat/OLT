using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Utility;
using log4net;

namespace Com.Suncor.Olt.Remote.Utilities
{
    public class MergingPermitRequestPersistanceProcessor
    {
        private static readonly ILog logger = GenericLogManager.GetLogger<MergingPermitRequestPersistanceProcessor>();
        
        private readonly List<PermitRequestEdmonton> existingPermitRequests;        
        private readonly List<PermitRequestEdmontonSAPImportData> incomingPermitRequests;

        private readonly DateTime now;
        private readonly User user;

        private int numberOfPermitRequestsProcessed = 0;

        protected readonly List<PermitRequestEdmonton> updateList = new List<PermitRequestEdmonton>();
        protected readonly List<PermitRequestEdmonton> insertList = new List<PermitRequestEdmonton>();
        protected readonly List<PermitRequestEdmonton> deleteList = new List<PermitRequestEdmonton>();
        
        public MergingPermitRequestPersistanceProcessor(List<PermitRequestEdmonton> existingPermitRequests, List<PermitRequestEdmontonSAPImportData> incomingPermitRequests, DateTime now, User user)
        {
            this.existingPermitRequests = existingPermitRequests;
            this.incomingPermitRequests = incomingPermitRequests;

            this.now = now;
            this.user = user;
        }

        public List<PermitRequestEdmonton> UpdateList
        {
            get { return updateList; }           
        }

        public List<PermitRequestEdmonton> InsertList
        {
            get { return insertList; }
        }

        public List<PermitRequestEdmonton> DeleteList
        {
            get { return deleteList; }
        }

        public void Process()
        {
            ThrowAwayAnySubOperationsWithoutParents();

            List<long> existingPermitRequestsReplacedByNewOnes = new List<long>();

            List<PermitRequestEdmonton> mergedIncomingList = MergeAllIncomingPermitRequestsAndBuildDoNotMergeList();
           
            foreach (PermitRequestEdmonton incomingPermitRequest in mergedIncomingList)
            {
                foreach (PermitRequestEdmontonWorkOrderSource source in incomingPermitRequest.WorkOrderSourceList)
                {
                    PermitRequestEdmonton existingPermitRequest = FindExistingPermitRequest(source, existingPermitRequestsReplacedByNewOnes);

                    bool alreadyHandled = UpdateListContainsItemWithSource(source) || InsertListContainsItemWithSource(source);

                    if (!alreadyHandled)
                    {
                        if (existingPermitRequest != null)
                        {
                            if (existingPermitRequest.IsModified)
                            {
                                UpdateModifiedPermitRequest(existingPermitRequest, incomingPermitRequest);
                                numberOfPermitRequestsProcessed++;
                                UpdateList.Add(existingPermitRequest);
                            }
                            else
                            {
                                incomingPermitRequest.Id = existingPermitRequest.Id;
                                incomingPermitRequest.LastSubmittedByUser = existingPermitRequest.LastSubmittedByUser;
                                incomingPermitRequest.LastSubmittedDateTime = existingPermitRequest.LastSubmittedDateTime;
                                numberOfPermitRequestsProcessed++;
                                UpdateList.Add(incomingPermitRequest);
                                existingPermitRequestsReplacedByNewOnes.Add(existingPermitRequest.IdValue);
                            }
                        }
                        else
                        {
                            numberOfPermitRequestsProcessed++;
                            InsertList.Add(incomingPermitRequest);
                        }
                    }
                }
            }

            foreach (PermitRequestEdmonton existingPermitRequest in existingPermitRequests)
            {
                if (!UpdateList.Exists(i => existingPermitRequest.IdValue == i.Id))
                {
                    if (!existingPermitRequest.IsSubmitted)
                    {
                        DeleteList.Add(existingPermitRequest);
                    }
                    else
                    {
                        existingPermitRequest.LastModifiedDateTime = now;
                        existingPermitRequest.LastModifiedBy = user;
                        existingPermitRequest.EndDate = new Date(now);
                        UpdateList.Add(existingPermitRequest);
                    }
                }
            }
        }

        public int NumberOfPermitRequestsProcessed
        {
            get { return numberOfPermitRequestsProcessed; }
        }

        private void UpdateModifiedPermitRequest(PermitRequestEdmonton existingPermitRequest, PermitRequestEdmonton incomingPermitRequest)
        {
            existingPermitRequest.SapDescription = incomingPermitRequest.Description;

            existingPermitRequest.RequestedStartDate = incomingPermitRequest.RequestedStartDate;
            existingPermitRequest.EndDate = incomingPermitRequest.EndDate;

            existingPermitRequest.LastModifiedDateTime = incomingPermitRequest.LastModifiedDateTime;
            existingPermitRequest.LastModifiedBy = incomingPermitRequest.LastModifiedBy;
            existingPermitRequest.LastImportedByUser = incomingPermitRequest.LastImportedByUser;
            existingPermitRequest.LastImportedDateTime = incomingPermitRequest.LastImportedDateTime;

            existingPermitRequest.ClearWorkOrderSources();
            incomingPermitRequest.WorkOrderSourceList.ForEach(existingPermitRequest.AddWorkOrderSource);

            existingPermitRequest.CompletionStatus = existingPermitRequest.DetectIsComplete();
        }

        private void ThrowAwayAnySubOperationsWithoutParents()
        {
            List<PermitRequestEdmontonSAPImportData> subOperations = incomingPermitRequests.FindAll(r => r.IsSubOperation);

            foreach (PermitRequestEdmontonSAPImportData subOperation in subOperations)
            {
                if(!incomingPermitRequests.Exists(r => (r.WorkOrderNumber == subOperation.WorkOrderNumber && r.OperationNumber == subOperation.OperationNumber && r.SAPWorkCentre == subOperation.SAPWorkCentre) && !r.IsSubOperation))
                {
                    incomingPermitRequests.Remove(subOperation);
                }
            }                     
        }

        private bool UpdateListHasNoValueForCurrentSourceRecord(PermitRequestEdmontonWorkOrderSource source)
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

        public PermitRequestEdmonton FindExistingPermitRequest(IHasPermitKey key)
        {
            return existingPermitRequests.Find(pr => pr.ContainsWorkOrderSource(key));
        }

        public PermitRequestEdmonton FindExistingPermitRequest(IHasPermitKey key, List<long> alreadyReplacedPermitRequestIdList)
        {
            PermitRequestEdmonton permitRequest = existingPermitRequests.Find(pr => pr.ContainsWorkOrderSource(key));

            if(permitRequest != null && alreadyReplacedPermitRequestIdList.Exists(t => t == permitRequest.IdValue))
            {
                return null;
            }

            return permitRequest;
        }

        private List<PermitRequestEdmonton> MergeAllIncomingPermitRequestsAndBuildDoNotMergeList()
        {
            Dictionary<MergeKey, List<PermitRequestEdmontonSAPImportData>> incomingDataMergeMap = new Dictionary<MergeKey,List<PermitRequestEdmontonSAPImportData>>();
            Dictionary<DoNotMergeMergeKey, List<PermitRequestEdmontonSAPImportData>> incomingDoNotMergeDataMergeMap = new Dictionary<DoNotMergeMergeKey, List<PermitRequestEdmontonSAPImportData>>();        
            
            List<PermitRequestEdmontonSAPImportData> itemsHandledByDoNotMergeList = new List<PermitRequestEdmontonSAPImportData>();
          
            List<PermitRequestEdmontonSAPImportData> doNotMergeOperations = incomingPermitRequests.FindAll(t => t.DoNotMerge && !t.IsSubOperation);

            foreach (PermitRequestEdmontonSAPImportData doNotMergeOperation in doNotMergeOperations)
            {
                List<PermitRequestEdmontonSAPImportData> children = 
                    incomingPermitRequests.FindAll(t => t.IsSubOperation && 
                        t.WorkOrderNumber == doNotMergeOperation.WorkOrderNumber && 
                        t.OperationNumber == doNotMergeOperation.OperationNumber && 
                        t.SAPWorkCentre == doNotMergeOperation.SAPWorkCentre);
                
                DoNotMergeMergeKey key = new DoNotMergeMergeKey(doNotMergeOperation.WorkOrderNumber, doNotMergeOperation.OperationNumber);
                List<PermitRequestEdmontonSAPImportData> values = new List<PermitRequestEdmontonSAPImportData> { doNotMergeOperation };
                values.AddRange(children);
                itemsHandledByDoNotMergeList.AddRange(values);
                incomingDoNotMergeDataMergeMap.Add(key, values);
            }

            foreach (PermitRequestEdmontonSAPImportData dataItem in incomingPermitRequests)
            {
                if((!dataItem.DoNotMerge || dataItem.IsSubOperation) && !itemsHandledByDoNotMergeList.Exists(i => i.MatchesByPermitKey(dataItem)))
                {
                    MergeKey key = new MergeKey(dataItem.WorkOrderNumber, dataItem.SAPWorkCentre);                    

                    if (!incomingDataMergeMap.ContainsKey(key))
                    {
                        incomingDataMergeMap.Add(key, new List<PermitRequestEdmontonSAPImportData>());
                    }

                    incomingDataMergeMap[key].Add(dataItem);                    
                }
            }

            List<PermitRequestEdmonton> mergedItems = MergeItems(incomingDataMergeMap);
            List<PermitRequestEdmonton> mergedDoNotMergeItems = MergeDoNotMergeItems(incomingDoNotMergeDataMergeMap);

            List<PermitRequestEdmonton> mergedRequests = new List<PermitRequestEdmonton>();
            mergedRequests.AddRange(mergedItems.ConvertAll(i => (PermitRequestEdmonton) i));
            mergedRequests.AddRange(mergedDoNotMergeItems.ConvertAll(i => (PermitRequestEdmonton)i));

            return mergedRequests;
        }

        private List<PermitRequestEdmonton> MergeItems(Dictionary<MergeKey, List<PermitRequestEdmontonSAPImportData>> incomingDataMergeMap)
        {
            Dictionary<MergeKey, List<PermitRequestEdmontonSAPImportData>>.KeyCollection keyCollection = incomingDataMergeMap.Keys;
            List<PermitRequestEdmonton> mergedRequests = new List<PermitRequestEdmonton>();

            foreach (MergeKey mergeKey in keyCollection)
            {
                List<PermitRequestEdmontonSAPImportData> dataList = incomingDataMergeMap[mergeKey];

                if (dataList.Count == 1)
                {
                    PermitRequestEdmontonSAPImportData permitRequest = dataList[0];
                    permitRequest.RequestedStartTimeDay = WorkPermitEdmonton.PermitDefaultDayStart;
                    mergedRequests.Add(permitRequest);
                }
                else
                {
                    List<List<PermitRequestEdmontonSAPImportData>> dataListGroupedByDates = GroupItemsByDate(incomingDataMergeMap[mergeKey]);

                    foreach (List<PermitRequestEdmontonSAPImportData> listOfLikeDatedItems in dataListGroupedByDates)
                    {
                        PermitRequestEdmonton mergedPermitRequest = MergeList(listOfLikeDatedItems);
                        mergedRequests.Add(mergedPermitRequest);
                    }
                }
            }

            return mergedRequests;
        }

        private List<PermitRequestEdmonton> MergeDoNotMergeItems(Dictionary<DoNotMergeMergeKey, List<PermitRequestEdmontonSAPImportData>> incomingDoNotMergeDataMergeMap)
        {
            Dictionary<DoNotMergeMergeKey, List<PermitRequestEdmontonSAPImportData>>.KeyCollection keyCollection = incomingDoNotMergeDataMergeMap.Keys;
            List<PermitRequestEdmonton> mergedRequests = new List<PermitRequestEdmonton>();

            foreach (DoNotMergeMergeKey mergeKey in keyCollection)
            {
                List<PermitRequestEdmontonSAPImportData> dataList = incomingDoNotMergeDataMergeMap[mergeKey];

                if (dataList.Count == 1)
                {
                    PermitRequestEdmontonSAPImportData permitRequest = dataList[0];
                    permitRequest.RequestedStartTimeDay = WorkPermitEdmonton.PermitDefaultDayStart;
                    mergedRequests.Add(permitRequest);
                }
                else
                {
                    List<List<PermitRequestEdmontonSAPImportData>> dataListGroupedByDates = GroupItemsByDate(incomingDoNotMergeDataMergeMap[mergeKey]);

                    foreach (List<PermitRequestEdmontonSAPImportData> listOfLikeDatedItems in dataListGroupedByDates)
                    {
                        PermitRequestEdmonton mergedPermitRequest = MergeList(listOfLikeDatedItems);
                        mergedRequests.Add(mergedPermitRequest);
                    }
                }
            }

            return mergedRequests;
        }

        private static PermitRequestEdmonton MergeList(List<PermitRequestEdmontonSAPImportData> listOfLikeDatedItems)
        {
            PermitRequestEdmontonMergeTool mergeTool = new PermitRequestEdmontonMergeTool();
            List<PermitRequestEdmonton> permitRequests = listOfLikeDatedItems.ConvertAll(e => (PermitRequestEdmonton)e);
            PermitRequestEdmonton mergedPermitRequest = mergeTool.Merge(permitRequests);
            mergedPermitRequest.RequestedStartTimeDay = WorkPermitEdmonton.PermitDefaultDayStart;
            return mergedPermitRequest;
        }

        public static List<List<PermitRequestEdmontonSAPImportData>> GroupItemsByDate(List<PermitRequestEdmontonSAPImportData> items)
        {
            List<DateRangeGroup> groupList = new List<DateRangeGroup>();

            foreach (PermitRequestEdmontonSAPImportData item in items)
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

            return groupList.ConvertAll(gl => new List<PermitRequestEdmontonSAPImportData>(gl.Items));
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
            private readonly List<PermitRequestEdmontonSAPImportData> items;

            public DateRangeGroup()
            {
                items = new List<PermitRequestEdmontonSAPImportData>();
            }

            public List<PermitRequestEdmontonSAPImportData> Items
            {
                get { return new List<PermitRequestEdmontonSAPImportData>(items); }
            }

            public void AddToGroup(List<PermitRequestEdmontonSAPImportData> newItems)
            {
                items.AddRange(newItems);
            }

            public void AddToGroup(PermitRequestEdmontonSAPImportData newItem)
            {
                items.Add(newItem);
            }

            public bool GroupDatesOverlapItem(PermitRequestEdmontonSAPImportData item)
            {
                DateRange itemRange = new DateRange(item.RequestedStartDate, item.EndDate);
                return items.Exists(i => itemRange.Overlaps(i.RequestedStartDate, i.EndDate));
            }
        }
              
        private class DoNotMergeMergeKey
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

        private class MergeKey
        {
            public MergeKey(string workOrderNumber, string sapWorkCentre)
            {
                WorkOrderNumber = workOrderNumber;
                SAPWorkCentre = sapWorkCentre;
            }

            public string WorkOrderNumber { get; private set; }
            public string SAPWorkCentre { get; private set; }

            public bool Equals(MergeKey other)
            {
                if (ReferenceEquals(null, other)) return false;
                if (ReferenceEquals(this, other)) return true;
                return Equals(other.WorkOrderNumber, WorkOrderNumber) && Equals(other.SAPWorkCentre, SAPWorkCentre);
            }

            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj)) return false;
                if (ReferenceEquals(this, obj)) return true;
                if (obj.GetType() != typeof (MergeKey)) return false;
                return Equals((MergeKey) obj);
            }

            public override int GetHashCode()
            {
                unchecked
                {
                    return ((WorkOrderNumber != null ? WorkOrderNumber.GetHashCode() : 0)*397) ^ (SAPWorkCentre != null ? SAPWorkCentre.GetHashCode() : 0);
                }
            }
        }
    }
}
