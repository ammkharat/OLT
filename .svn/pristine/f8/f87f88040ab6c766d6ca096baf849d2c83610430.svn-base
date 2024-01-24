using System.Collections.Generic;
using Com.Suncor.Olt.Client.Presenters.Validation;
using Com.Suncor.Olt.Client.Presenters.Validation.ValidationError;
using Com.Suncor.Olt.Client.Security;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;

namespace Com.Suncor.Olt.Client.Validation
{
    public class WorkPermitApprovableValidator
    {
        private readonly List<WorkPermit> workPermits;
        private readonly IAuthorized authorized;
        private readonly List<GasTestElementInfo> standardGasTestElementInfoList;

        public WorkPermitApprovableValidator(List<WorkPermit> workPermits, IAuthorized authorized, List<GasTestElementInfo> standardGasTestElementInfoList)
        {
            this.workPermits = workPermits;
            this.authorized = authorized;
            this.standardGasTestElementInfoList = standardGasTestElementInfoList;
        }

        public bool PermitsAreValidEnoughToBeApproved()
        {
            return workPermits.TrueForAll(IsValidEnoughToBeApproved);
        }

        private bool IsValidEnoughToBeApproved(WorkPermit permit)
        {
            var sectionsValidator = new WorkPermitSectionsValidator(permit, authorized);
            List<IValidationIssue> sectionsErrors = sectionsValidator.Validate();

            var fullValidator = new FullWorkPermitValidator(permit);
            List<IValidationIssue> fullValidationErrors = fullValidator.Validate();

            var gastTestValidator = new NewGasTestElementValidator(permit, standardGasTestElementInfoList);
            List<IValidationIssue> gasTestErrors = gastTestValidator.Validate();

            return sectionsErrors.DoesNotHave(error => error.ProblemLevel > ProblemLevel.Warning) &&
                   gasTestErrors.DoesNotHave(error => error.ProblemLevel > ProblemLevel.Warning) &&
                   fullValidationErrors.DoesNotHave(error => error.ProblemLevel > ProblemLevel.Warning);
        }

    }
}