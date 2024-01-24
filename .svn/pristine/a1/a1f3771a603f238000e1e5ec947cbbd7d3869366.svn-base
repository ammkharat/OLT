using System.Collections.Generic;
using Com.Suncor.Olt.Client.Presenters.Validation;
using Com.Suncor.Olt.Client.Presenters.Validation.ValidationError;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Validation
{
    public class NewCoreWorkPermitValidator : AbstractNewWorkPermitValidator
    {
        public NewCoreWorkPermitValidator(WorkPermit workPermit) : base(workPermit)
        {
        }

        protected override List<IValidation<WorkPermit>> BuildValidationRules()
        {
            return new List<IValidation<WorkPermit>>
                       {
                           BuildRequiredForSaveValidator("workPermitTypeHotRadioButton", wp => wp.WorkPermitType == null),
                           // Classification gone
                           BuildRequiredForSaveValidator(StringResources.FlocEmptyError,
                                                         "functionalLocationTextBox",
                                                         wp => wp.FunctionalLocation == null),
                           new AllTrueValidator<WorkPermit>(
                               new FieldValidationError(StringResources.WorkOrderAndJobStepDescriptionEmptyError,
                                                        ProblemLevel.RequiredForSave,
                                                        "workOrderDescriptionTextBox", "jobStepDescriptionTextBox"),
                               new Rule<WorkPermit>(wp => wp.WorkOrderDescription.IsNullOrEmptyOrWhitespace()),
                               new Rule<WorkPermit>(wp => string.IsNullOrEmpty(wp.Specifics.JobStepDescription))),
                           BuildRequiredForSaveValidator("workPermitContractorNameControl",
                                                         wp => wp.Specifics.ContractorCompanyName.IsNullOrEmptyOrWhitespace()),
                           BuildRequiredForSaveValidator("workPermitCraftOrTradeControl",
                                                         wp => wp.Specifics.CraftOrTradeName.IsNullOrEmptyOrWhitespace()),                                                    
                       };
        }
    }
}