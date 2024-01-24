using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Remote.Utilities
{
    public static class WorkOrderWorkPermitEdmontonTypeConverter
    {
        public const string ROUTINE_MAINTENANCE = "7";
        public const string COLD_WORK = "8";
        public const string NORMAL_HOT_WORK = "9";
        public const string HIGH_ENERGY_HOT_WORK = "10";
        
        public static WorkPermitEdmontonType ToWorkPermitType(string permitTypeFromSAP)
        {
            if (permitTypeFromSAP.HasValue())
            {
                permitTypeFromSAP = permitTypeFromSAP.Trim().Trim('\\').Trim();
            }

            WorkPermitEdmontonType permitType = null;

            if (permitTypeFromSAP == ROUTINE_MAINTENANCE)
            {
                permitType = WorkPermitEdmontonType.ROUTINE_MAINTENANCE;
            }
            else if (permitTypeFromSAP == COLD_WORK)
            {
                permitType = WorkPermitEdmontonType.COLD_WORK;
            }
            else if (permitTypeFromSAP == NORMAL_HOT_WORK)
            {
                permitType = WorkPermitEdmontonType.HOT_WORK;
            }
            else if (permitTypeFromSAP == HIGH_ENERGY_HOT_WORK)
            {
                permitType = WorkPermitEdmontonType.HIGH_ENERGY_HOT_WORK;
            }
        
            return permitType;           
        }
    }
}