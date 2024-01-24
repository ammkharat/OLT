using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Common.Domain.WorkPermit;

namespace Com.Suncor.Olt.Client.Presenters.Validation.ValidationError
{
    public class SystemEntryGasTestResultOutOrRangeValidationError : IValidationIssue
    {
        private readonly GasTestElementInfo gasTestElementInfo;

        public SystemEntryGasTestResultOutOrRangeValidationError(GasTestElementInfo gasTestElementInfo)
        {
            this.gasTestElementInfo = gasTestElementInfo;
        }

        public ProblemLevel ProblemLevel
        {
            get;
            private set;
        }

        public void Bind(IWorkPermitFormView view)
        {
            view.ShowSystemEntryGasTestResultOutOfRangeWarning(gasTestElementInfo);
        }

    }
}
