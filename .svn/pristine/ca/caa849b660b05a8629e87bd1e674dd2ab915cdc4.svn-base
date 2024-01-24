using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Remote.Utilities
{
    public static class WorkOrderWorkPermitLubesTypeConverter
    {
        public const string HAZARDOUS_COLD_WORK = "11";
        public const string HOT_WORK = "12";
        public const string VEHICLE_ENTRY = "13";        
        
        public static void SetWorkPermitTypeInformation(string permitTypeFromSAP, PermitRequestLubes permitRequest)
        {
            if (permitTypeFromSAP.HasValue())
            {
                permitTypeFromSAP = permitTypeFromSAP.Trim().Trim('\\').Trim();
            }

            WorkPermitLubesType permitType = null;
            bool isVehicleEntry = false;

            if (permitTypeFromSAP == HAZARDOUS_COLD_WORK)
            {
                permitType = WorkPermitLubesType.HAZARDOUS_COLD_WORK;
            }
            else if (permitTypeFromSAP == HOT_WORK)
            {
                permitType = WorkPermitLubesType.HOT_WORK;
            }
            else if (permitTypeFromSAP == VEHICLE_ENTRY)
            {
                permitType = WorkPermitLubesType.HOT_WORK;
                isVehicleEntry = true;
            }

            permitRequest.WorkPermitType = permitType;
            permitRequest.IsVehicleEntry = isVehicleEntry;
        }
    }
}