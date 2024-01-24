using System.Collections.Generic;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Remote.Integration;
using log4net;

namespace Com.Suncor.Olt.Remote.Wcf
{
    public class WorkOrderImportFilter
    {
        private static readonly ILog logger = GenericLogManager.GetLogger<WorkOrderImportFilter>();

        public List<WorkOrderRecordList> FilterResults(List<WorkOrderRecordList> inputRecords, string workOrderNumber)
        {
            List<WorkOrderRecordList> recordListList = new List<WorkOrderRecordList>();

            if (workOrderNumber.IsNullOrEmptyOrWhitespace())
            {
                recordListList.AddRange(inputRecords);
                return recordListList;
            }

            foreach (WorkOrderRecordList workOrderRecordList in inputRecords)
            {
                WorkOrderDetails[] details = workOrderRecordList.WorkOrderDetails;

                if (details.Length == 0)
                {
                    logger.Error("There were no 'WorkOrderDetails' messages in a 'WorkOrderRecordList'. One record is expected." + workOrderRecordList.header);
                    continue;
                }

                if (details.Length > 1)
                {
                    logger.Error("There were multiple 'WorkOrderDetails' messages in a 'WorkOrderRecordList'. Only one is expected. Using the first one.");
                }

                WorkOrderDetails detail = details[0];

                if (detail.WONumber != null && detail.WONumber.EndsWith(workOrderNumber))
                {
                    recordListList.Add(workOrderRecordList);
                }
            }

            return recordListList;
        }

    }
}
