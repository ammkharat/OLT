using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class GasTestElementLimitFormatter
    {
        public string ToLimitWithUnits(GasTestElement element, WorkPermit permit)
        {
            return ToLimitWithUnits(element, permit.WorkPermitType, permit.Attributes);
        }
        
        public string ToLimitWithUnits(GasTestElement element, 
                                       WorkPermitType workPermitType, WorkPermitAttributes attributes)
        {
            GasTestElementInfo elementInfo = element.ElementInfo;
            return ToLimitWithUnits(elementInfo, workPermitType, attributes);
        }

        private string ToLimitWithUnits(GasTestElementInfo elementInfo,
                                       WorkPermitType workPermitType, WorkPermitAttributes attributes)
        {
            if (elementInfo.IsStandard)
            {
                GasLimitRange limitRange = elementInfo.GetLimitRange(workPermitType, attributes);
                return limitRange.ToLimitStringWithUnit(elementInfo.IsRangedLimit, elementInfo.DecimalPlaceCount, elementInfo.Unit);
            }
            return elementInfo.OtherLimits;
        }
    }
}
