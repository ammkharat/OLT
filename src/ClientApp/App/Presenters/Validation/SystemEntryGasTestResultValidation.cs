using System.Collections.Generic;
using Com.Suncor.Olt.Client.Presenters.Validation.ValidationError;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Client.Presenters.Validation
{
    public class SystemEntryGasTestResultValidation : IValidation<WorkPermit>
    {
        private readonly GasTestElement element;
        private readonly List<GasTestElementInfo> standardGasTestElementInfoList;

        public SystemEntryGasTestResultValidation(GasTestElement element,
                                                    List<GasTestElementInfo> standardGasTestElementInfoList)
        {
            this.element = element;
            this.standardGasTestElementInfoList = standardGasTestElementInfoList;
        }

        public bool Evaluate(WorkPermit workPermit)
        {
            bool result = false;

            GasTestElementInfo elementInfo = element.ElementInfo;

            if (elementInfo.IsStandard && !element.SystemEntryTestNotApplicable)
            {
                GasTestElementInfo standardInfo = standardGasTestElementInfoList.FindById(elementInfo.Id);
                GasLimitRange range = standardInfo.GetLimitRange(workPermit.WorkPermitType, workPermit.Attributes);
                double? systemEntryResult = element.SystemEntryTestResult;
                if (systemEntryResult.OutsideOf(range))
                {
                    result = true;
                }
            }

            return result;
        }

        public IValidationIssue ValidationIssue
        {
            get { return new SystemEntryGasTestResultOutOrRangeValidationError(element.ElementInfo); }
        }
    }
}