using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Client.Presenters.Validation.ValidationError;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Client.Presenters.Validation
{
    public class ConfinedSpaceGasTestResultValidation : IValidation<WorkPermit>
    {
        private readonly GasTestElement element;
        private readonly List<GasTestElementInfo> standardGasTestElementInfoList;
        private readonly Site site;
            

        public ConfinedSpaceGasTestResultValidation(Site site, GasTestElement element,
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
                ((site.Id == Site.SARNIA_ID && element.ConfinedSpaceTestRequired) || site.Id == Site.DENVER_ID) || // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia 
                ((site.Id == Site.USPipeline_ID && element.ConfinedSpaceTestRequired) || site.Id == Site.USPipeline_ID) ||           //ayman USPipeline workpermit
                ((site.Id == Site.SELC_ID && element.ConfinedSpaceTestRequired) || site.Id == Site.SELC_ID)) //mangesh uspipeline to selc
            {
                GasTestElementInfo standardInfo = standardGasTestElementInfoList.FindById(elementInfo.Id);
                if (standardInfo == null)
                    return false;
                    
                
                GasLimitRange range = standardInfo.GetLimitRange(workPermit.WorkPermitType, workPermit.Attributes);

                double? confinedSpaceResult = element.ConfinedSpaceTestResult;
                if (confinedSpaceResult.OutsideOf(range))
                {
                    result = true;
                }
            }

//DMND0010814 / RITM0422801 : Added By Vibhor - Sarnia SWP New Changes
            if (!elementInfo.IsStandard &&
                ((site.Id == Site.SARNIA_ID && element.ConfinedSpaceTestRequired) || site.Id == Site.DENVER_ID) || // RITM0422801 : Added By Vibhor - Changes in work permit for Sarnia 
                ((site.Id == Site.USPipeline_ID && element.ConfinedSpaceTestRequired) || site.Id == Site.USPipeline_ID) ||
                ((site.Id == Site.SELC_ID && element.ConfinedSpaceTestRequired) || site.Id == Site.SELC_ID)) // mangesh uspipeline to selc
            {
                
                string confinedSpaceResult = element.ElementInfo.OtherLimits;

                //if (Convert.ToInt64(confinedSpaceResult) < Convert.ToInt64(element.ConfinedSpaceTestResult))
                //{
                //    result = true;
                //}
                
                try
                {
                    if (Convert.ToDecimal(confinedSpaceResult) < Convert.ToDecimal(element.ConfinedSpaceTestResult))
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
                if ((element.ElementInfo.Name == "Oxygen" || element.ElementInfo.Name == "LEL") )
                {
                    if ((!element.ConfinedSpaceTestResult.HasValue) && element.ConfinedSpaceTestRequired && workPermit.Attributes.IsConfinedSpaceEntry)
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
            get { return new ConfinedSpaceGasTestResultOutOfRangeValidationError(element.ElementInfo); }
        }
    }
}