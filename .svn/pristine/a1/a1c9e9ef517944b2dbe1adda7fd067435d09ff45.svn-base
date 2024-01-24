using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Remote.Utilities
{
    public static class WorkOrderWorkPermitMontrealTypeConverter
    {
        private const string COLD_SAP_CODE = "1";
        private const string HOT_MODERATE_RISK_SAP_CODE = "3";
        private const string HOT_HIGH_RISK_SAP_CODE = "4";
        private const string VEHICLE_ENTRY_SAP_CODE = "5";
        private const string FRESH_AIR_SAP_CODE = "6";

        public static WorkPermitMontrealType ToWorkPermitMontrealType(string workOrderOperationWorkPermitType)
        {
            if (workOrderOperationWorkPermitType.HasValue())
            {
                workOrderOperationWorkPermitType = workOrderOperationWorkPermitType.Trim().Trim('\\').Trim();
            }

            WorkPermitMontrealType permitType;

            switch (workOrderOperationWorkPermitType)
            {
                case COLD_SAP_CODE:
                    permitType = WorkPermitMontrealType.COLD;
                    break;
                case HOT_MODERATE_RISK_SAP_CODE:
                    permitType = WorkPermitMontrealType.MODERATE_HOT;
                    break;
                case HOT_HIGH_RISK_SAP_CODE:
                    permitType = WorkPermitMontrealType.ELEVATED_HOT;
                    break;
                case VEHICLE_ENTRY_SAP_CODE:
                    permitType = WorkPermitMontrealType.VEHICLE_ENTRY;
                    break;
                case FRESH_AIR_SAP_CODE:
                    permitType = WorkPermitMontrealType.FRESH_AIR_MASK;
                    break;
                default:
                    permitType = null;
                    break;
            }

            return permitType;
        }
    }
}