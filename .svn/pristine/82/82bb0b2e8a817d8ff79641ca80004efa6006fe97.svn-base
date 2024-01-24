using System.Collections.Generic;
using Com.Suncor.Olt.Client.Presenters.Validation.ValidationError;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;
using System;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.OltControls;

namespace Com.Suncor.Olt.Client.Presenters.Validation
{
    public class ImmediateAreaGasTestResultValidation : IValidation<WorkPermit>
    {
        private readonly Site site;
        private readonly GasTestElement element;
        private readonly List<GasTestElementInfo> standardGasTestElementInfoList;

        public ImmediateAreaGasTestResultValidation(Site site, GasTestElement element,
                                                    List<GasTestElementInfo> standardGasTestElementInfoList)
        {
            this.site = site;
            this.element = element;
            this.standardGasTestElementInfoList = standardGasTestElementInfoList;
        }

        public bool Evaluate(WorkPermit workPermit)
        {
            bool result = false;
            bool resultError = false;

            GasTestElementInfo elementInfo = element.ElementInfo;

            if (elementInfo.IsStandard &&
                ((site.Id == Site.SARNIA_ID && element.ImmediateAreaTestRequired) || site.Id == Site.DENVER_ID) ||  // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia 
                ((site.Id == Site.USPipeline_ID && element.ImmediateAreaTestRequired) || site.Id == Site.USPipeline_ID) ||       //ayman USPipeline workpermit
                ((site.Id == Site.SELC_ID && element.ImmediateAreaTestRequired) || site.Id == Site.SELC_ID)) // mangesh uspipeline to selc
            {
                GasTestElementInfo standardInfo = standardGasTestElementInfoList.FindById(elementInfo);
                if (standardInfo == null)
                    return false;
                GasLimitRange range = standardInfo.GetLimitRange(workPermit.WorkPermitType, workPermit.Attributes);
                double? immediateAreaResult = element.ImmediateAreaTestResult;
                if (immediateAreaResult.OutsideOf(range))
                {
                    result = true;
                }
            }
//DMND0010814 / RITM0422801 : Added By Vibhor - Sarnia SWP New Changes
            if (!elementInfo.IsStandard &&
                ((site.Id == Site.SARNIA_ID && element.ImmediateAreaTestRequired) || site.Id == Site.DENVER_ID) ||  // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia 
                ((site.Id == Site.USPipeline_ID && element.ImmediateAreaTestRequired) || site.Id == Site.USPipeline_ID) ||       //ayman USPipeline workpermit
                ((site.Id == Site.SELC_ID && element.ImmediateAreaTestRequired) || site.Id == Site.SELC_ID)) // mangesh uspipeline to selc
            {
                string immediateAreaResult = element.ElementInfo.OtherLimits;

                try
                {
                    if (Convert.ToDecimal(immediateAreaResult) < Convert.ToDecimal(element.ImmediateAreaTestResult))
                    {
                        result = true;
                    }
                }
                catch (Exception e)
                {
                    
                    
                }
            }

//end
            if (site.Id == Site.SARNIA_ID)
            {
                if (element.ElementInfo.Name == "LEL")
                {
                    if (!element.ImmediateAreaTestResult.HasValue && element.ImmediateAreaTestRequired && workPermit.Attributes.IsBurnOrOpenFlame)
                    {
                        resultError = true;
                    }
                }
            }

            bool returnResult = result || resultError;

            return returnResult;
        }

        public IValidationIssue ValidationIssue
        {
            get { return new ImmediateAreaGasTestResultOutOrRangeValidationError(element.ElementInfo); }
        }
    }
}