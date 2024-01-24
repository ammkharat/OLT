using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Utility;
using Com.Suncor.Olt.Integration.Handlers.Adapters;
using Com.Suncor.Olt.Integration.Handlers.MessageObjects;

namespace Com.Suncor.Olt.Integration.Handlers.Fixtures
{
    public class WorkOrderDetailFixture
    {
        private const char Delimiter = '|';

        public static Operations[] GetOperationsArrayFromItems(Operations operation)
        {
            return new[] {operation};
        }

        public static Operations[] GetOperationsArrayFromItems(Operations operation1, Operations operation2)
        {
            return new[] {operation1, operation2};
        }

        public static WorkOrderDetails GetWorkOrderWithOneOperationForActionItemDefinition()
        {
            var workOrderDetail = GetWorkOrderDetailBase();
            workOrderDetail.Operations[0].WorkPermitType = ""; //for now this means it is an action item
            workOrderDetail.Operations[0].WorkCenterName = WorkCentreName.OPER; //now this means action item
            return workOrderDetail;
        }

        public static WorkOrderDetails GetWorkOrderWithOneOperationForWorkPermit()
        {
            var workOrderDetail = GetWorkOrderDetailBase();

            return workOrderDetail;
        }

        public static WorkOrderDetails GetWorkOrderWithNullOperations()
        {
            var workOrderDetail = GetWorkOrderDetailBase();
            workOrderDetail.Operations = null;
            return workOrderDetail;
        }

        public static WorkOrderDetails GetWorkOrderWith0Operations()
        {
            var workOrderDetail = GetWorkOrderDetailBase();
            workOrderDetail.Operations = new Operations[0];
            return workOrderDetail;
        }

        public static WorkOrderDetails GetWorkOrderWithNoFunctionalLocation()
        {
            var workOrderDetail = GetWorkOrderDetailBase();

            workOrderDetail.FunctionalLocation = "";

            return workOrderDetail;
        }

        public static WorkOrderDetails GetWorkOrderithOneOperationHOT2006_1_15_90510_2006_1_16_90000()
        {
            var workOrderDetail = GetWorkOrderDetailBase();
            workOrderDetail.Operations[0].WorkPermitType = WorkOrderWorkPermitType.HOT_SAP_CODE;
            return workOrderDetail;
        }

        public static WorkOrderDetails GetWorkOrderWithOneOperation()
        {
            var workOrderDetails = GetWorkOrderDetailBase();
            workOrderDetails.Operations[0].WorkPermitType = WorkOrderWorkPermitType.HOT_SAP_CODE;
            return workOrderDetails;
        }

        public static WorkOrderDetails GetWorkOrderWithTwoOperationsForWorkPermit()
        {
            var workOrderDetail = GetWorkOrderDetailBase();

            workOrderDetail.Operations = GetOperationsArrayFromItems(GetOperationBase(), GetOperationBase());

            return workOrderDetail;
        }

        public static WorkOrderDetails GetWorkOrderWithOneOperation(string earliestStartDate,
            string earliestStartTime,
            string earliestFinishDate,
            string earliestFinishTime)
        {
            var workOrderDetail = GetWorkOrderithOneOperationHOT2006_1_15_90510_2006_1_16_90000();
            var workPermitOperation = workOrderDetail.Operations[0];
            workPermitOperation.WorkPermitAttrib = ToStringOfAttributes(WorkOrderWorkPermitAttribute.IsExcavation);

            workPermitOperation.EarliestStartDate = earliestStartDate;
            workPermitOperation.EarliestFinishDate = earliestFinishDate;
            workPermitOperation.EarliestStartTime = earliestStartTime;
            workPermitOperation.EarliestFinishTime = earliestFinishTime;

            return workOrderDetail;
        }

        public static string ToStringOfAttributes(params string[] workOrderWorkPermitAttribute)
        {
            return workOrderWorkPermitAttribute.ToDelimitedString(Delimiter) + Delimiter;
        }

        private static WorkOrderDetails GetWorkOrderDetailBase()
        {
            var workOrderDetail = new WorkOrderDetails
            {
                EquipmentNumber = "EN111111",
                FunctionalLocation = "SR1-PL3-HYDU-SMP",
                PlantID = "SR1",
                ShortText = "This is the short text",
                WorkOrderNumber = "WO11111",
                Operations = GetOperationsArrayFromItems(GetOperationBase())
            };

            return workOrderDetail;
        }

        private static Operations GetOperationBase()
        {
            var operation = new Operations
            {
                EarliestFinishDate = "2006-1-16",
                EarliestStartDate = "2006-1-15",
                EarliestFinishTime = "09:05:10",
                EarliestStartTime = "09:00:00",
                LongText = "This is the long text",
                OperationNumber = "OP111111",
                Suboperation = string.Empty,
                WorkCenterID = "11111",
                WorkCenterText = "Plumber",
                WorkCenterName = "PLUM",
                WorkPermitType = WorkOrderWorkPermitType.HOT_SAP_CODE_OBSOLETE,
                WorkPermitAttrib =
                    ToStringOfAttributes(WorkOrderWorkPermitAttribute.IsBurnOrOpenFlame,
                        WorkOrderWorkPermitAttribute.NotSpecified)
            };

            return operation;
        }
    }
}