using System.Collections.Generic;
using Com.Suncor.Olt.Client.Presenters.Validation;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;

namespace Com.Suncor.Olt.Client.Validation
{
    public class NewGasTestElementValidator : AbstractNewWorkPermitValidator
    {
        private readonly List<GasTestElement> elementsList;
        private readonly List<GasTestElementInfo> standardGasTestElementInfoList;
        private readonly Site site;

        public NewGasTestElementValidator(WorkPermit workPermit, List<GasTestElementInfo> standardGasTestElementInfoList) : base(workPermit)
        {
            elementsList = workPermit.GasTests.Elements;
            this.standardGasTestElementInfoList = standardGasTestElementInfoList;

            site = ClientSession.GetUserContext().Site;
        }

        protected override List<IValidation<WorkPermit>> BuildValidationRules()
        {
            var result = new List<IValidation<WorkPermit>>();

            elementsList.ForEach(element =>
                                     {
                                         result.Add(new ConfinedSpaceGasTestResultValidation(site, element,
                                                                                             standardGasTestElementInfoList));
                                         result.Add(new ImmediateAreaGasTestResultValidation(site, element,
                                                                                             standardGasTestElementInfoList));
                                         result.Add(new SystemEntryGasTestResultValidation(element,
                                                                                             standardGasTestElementInfoList));

                                     });

            return result;
        }
    }
}