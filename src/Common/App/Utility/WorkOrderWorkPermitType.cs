using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Common.Utility
{
    public static class WorkOrderWorkPermitType
    {
        public const string HOT_SAP_CODE_OBSOLETE = "HOT";
        public const string COLD_SAP_CODE_OBSOLETE = "COLD";

        public const string HOT_SAP_CODE = "2";
        public const string COLD_SAP_CODE = "1";

        public static WorkPermitType ToWorkPermitType(string workPermitTypeString)
        {
            if (workPermitTypeString.HasValue())
                workPermitTypeString = workPermitTypeString.ToUpper();

            WorkPermitType permitType = null;

            if (HOT_SAP_CODE.Equals(workPermitTypeString))
            {
                permitType = WorkPermitType.HOT;
            }
            else if (COLD_SAP_CODE.Equals(workPermitTypeString))
            {
                permitType = WorkPermitType.COLD;
            }
            else
            {
                if (HOT_SAP_CODE_OBSOLETE == workPermitTypeString)
                {
                    permitType = WorkPermitType.HOT;
                }
                else if (COLD_SAP_CODE_OBSOLETE == workPermitTypeString)
                {
                    permitType = WorkPermitType.COLD;
                }
            }

            return permitType;
        }
    }
}