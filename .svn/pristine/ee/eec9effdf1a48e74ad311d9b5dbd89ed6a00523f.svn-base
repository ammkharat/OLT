namespace Com.Suncor.Olt.Common.Domain.WorkPermit
{
    public class WorkOrderDataMergeWrapper_Deleteme //: ISAPImportData // mergetodo delete this class
    {
        public WorkOrderDataMergeWrapper_Deleteme(WorkOrderImportData workOrderImportData)
        {
            InnerWorkOrderImportData = workOrderImportData;
        }

        public WorkOrderImportData InnerWorkOrderImportData { get; private set; }

        public bool IsSubOperation
        {
            get { return SubOperationNumber != null; }
        }

        public bool DoNotMerge { get; private set; }

        public Date CalculatedStartDate
        {
            get { return null; }
        }

        public Date RequestedStartDate { get; private set; }

        public string WorkOrderNumber
        {
            get { return InnerWorkOrderImportData.WorkOrderNumber; }
        }

        public string OperationNumber
        {
            get { return InnerWorkOrderImportData.OperationNumber; }
        }

        public string SubOperationNumber
        {
            get { return InnerWorkOrderImportData.SubOperationNumber; }
        }

        public string SAPWorkCentre
        {
            get { return InnerWorkOrderImportData.WorkCenterName; }
        }
    }
}