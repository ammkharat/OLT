using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Remote.Utilities
{
    public static class WorkOrderWorkPermitFortHillsTypeConverter
    {
        /* DMND0009632 - Fort Hills OLT - E-Permit Development Need to change the numbers here*/
        public const string SPECIFIC_HOT_SAP_CODE = "14";
        public const string SPECIFIC_COLD_SAP_CODE = "15";
        public const string BLANKET_HOT_SAP_CODE = "16";
        public const string BLANKET_COLD_SAP_CODE = "17";
        
        public static WorkPermitFortHillsType ToWorkPermitType(string permitTypeFromSAP)
        {
            if (permitTypeFromSAP.HasValue())
            {
                permitTypeFromSAP = permitTypeFromSAP.Trim().Trim('\\').Trim();
            }

            WorkPermitFortHillsType permitType = null;

            if (permitTypeFromSAP == SPECIFIC_HOT_SAP_CODE)
            {
                permitType = WorkPermitFortHillsType.SPECIFIC_HOT;
            }
            else if (permitTypeFromSAP == BLANKET_HOT_SAP_CODE)
            {
                permitType = WorkPermitFortHillsType.BLANKET_HOT;
            }
            else if (permitTypeFromSAP == SPECIFIC_COLD_SAP_CODE)
            {
                permitType = WorkPermitFortHillsType.SPECIFIC_COLD;
            }
            else if (permitTypeFromSAP == BLANKET_COLD_SAP_CODE)
            {
                permitType = WorkPermitFortHillsType.BLANKET_COLD;
            }
            
        
            return permitType;           
        }
    }
}