using System;
using System.Collections.Generic;

namespace Com.Suncor.Olt.Common.Domain.WorkPermit
{
    [Serializable]
    public class WorkOrderImportData : DomainObject, IHasPermitKey
    {
        public WorkOrderImportData(long batchId, DateTime batchItemCreatedDateTime, User submittedByUser)
        {
            BatchId = batchId;
            BatchItemCreatedDateTime = batchItemCreatedDateTime;
            SubmittedByUser = submittedByUser;
        }

        public long BatchId { get; set; }
        public Date ImportDate { get; set; }
        public DateTime BatchItemCreatedDateTime { get; set; }
        public User SubmittedByUser { get; set; }

        public string ProcessStatus { get; set; }

        public string WONumber { get; set; }
        public string ShortText { get; set; }
        public string FunctionalLocation { get; set; }
        public string EquipmentNumber { get; set; }
        public string PlantId { get; set; }
        public string LanguageCode { get; set; }
        public string Priority { get; set; }
        public string PlannerGroup { get; set; }
        public string OperationKeyNo { get; set; }
        public string Suboperation { get; set; }
        public string EarliestStartDate { get; set; }
        public string EarliestStartTime { get; set; }
        public string EarliestFinishDate { get; set; }
        public string EarliestFinishTime { get; set; }
        public string LongText { get; set; }
        public string WorkPermitType { get; set; }
        public string WorkPermitAttrib { get; set; }
        public string WorkCenterID { get; set; }
        public string WorkCenterName { get; set; }
        public string WorkCenterText { get; set; }
        public string OperationNumber { get; set; }

        public string WorkOrderNumber
        {
            get { return WONumber; }
        }

        public string SubOperationNumber
        {
            get { return Suboperation; }
        }

        public bool MatchesByPermitKey(IHasPermitKey item)
        {
            return PermitKeyData.MatchesByPermitKey(this, item);
        }

        public static List<WorkOrderImportData> RemoveDuplicates(List<WorkOrderImportData> data)
        {
            var map = new Dictionary<PermitKeyData, WorkOrderImportData>();

            foreach (var item in data)
            {
                var key = new PermitKeyData(item);

                if (!map.ContainsKey(key))
                {
                    map.Add(key, item);
                }
            }

            var result = new List<WorkOrderImportData>();

            foreach (var key in map.Keys)
            {
                result.Add(map[key]);
            }

            return result;
        }
    }
}