using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Common.Domain.WorkPermit
{
    [Serializable]
    public class PermitRequestFortHillsSAPImportData : PermitRequestFortHills, ISAPImportData
    {
        public PermitRequestFortHillsSAPImportData(long batchId, DateTime batchItemCreatedAt, long? id, Date endDate,
            string description, string company, User createdBy, DateTime createdDate) :
                base(id, endDate, description, description, company, DataSource.SAP,
                    createdBy, createdDate, null, null, createdBy, createdDate, createdBy, createdDate)
        {
            BatchId = batchId;
            BatchItemCreatedAt = batchItemCreatedAt;
        }

        public PermitRequestFortHillsSAPImportData(long batchId, DateTime batchItemCreatedAt, long? id, Date endDate,
            string description, string company) :
                base(id, endDate, description, description, company, DataSource.SAP,
                    null, null, null, null, null, DateTime.MinValue, null, DateTime.MinValue)
        {
            BatchId = batchId;
            BatchItemCreatedAt = batchItemCreatedAt;
        }

        public long BatchId { get; set; }
        public DateTime BatchItemCreatedAt { get; set; }

        public override List<PermitRequestWorkOrderSource> WorkOrderSourceList
        {
            get
            {
                return new List<PermitRequestWorkOrderSource>
                {
                    new PermitRequestWorkOrderSource(WorkOrderNumber, OperationNumber, SubOperationNumber)
                };
            }
        }

        public PermitKeyData WorkOrderSource
        {
            get { return new PermitKeyData(this); }
        }

        public Date CalculatedStartDate
        {
            get { return RequestedStartDate; }
        }

        public bool IsSubOperation
        {
            get { return SubOperationNumber != null; }
        }

        public void SetCreatedInfo(User user, DateTime dateTime)
        {
            CreatedBy = user;
            CreatedDateTime = dateTime;
            LastModifiedBy = user;
            LastModifiedDateTime = dateTime;
            LastImportedByUser = user;
            LastImportedDateTime = dateTime;
        }

        public override void AddWorkOrderSource(string workOrderNumber, string operationNumber,
            string subOperationNumber)
        {
            WorkOrderNumber = workOrderNumber;
            OperationNumber = operationNumber;
            SubOperationNumber = subOperationNumber;
        }

        public override void AddWorkOrderSource(PermitRequestWorkOrderSource workOrderSource)
        {
            WorkOrderNumber = workOrderSource.WorkOrderNumber;
            OperationNumber = workOrderSource.OperationNumber;
            SubOperationNumber = workOrderSource.SubOperationNumber;
        }

        public static List<PermitRequestFortHillsSAPImportData> RemoveDuplicateTurnaroundImports(
            List<PermitRequestFortHillsSAPImportData> data)
        {
            var map = new Dictionary<PermitKeyData, PermitRequestFortHillsSAPImportData>();

            foreach (var item in data)
            {
                var key = new PermitKeyData(item);

                if (!map.ContainsKey(key))
                {
                    map.Add(key, item);
                }
            }

            var result = new List<PermitRequestFortHillsSAPImportData>();

            foreach (var key in map.Keys)
            {
                result.Add(map[key]);
            }

            return result;
        }
    }
}