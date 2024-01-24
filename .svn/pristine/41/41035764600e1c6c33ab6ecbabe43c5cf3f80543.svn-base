using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Common.Domain.WorkPermit;

namespace Com.Suncor.Olt.Client.Presenters.Validation.ValidationError
{
    public class ImmediateAreaGasTestResultOutOrRangeValidationError : IValidationIssue
    {
        private readonly GasTestElementInfo gasTestElementInfo;

        public ImmediateAreaGasTestResultOutOrRangeValidationError(GasTestElementInfo gasTestElementInfo)
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
            view.ShowImmediateAreaGasTestResultOutOfRangeWarning(gasTestElementInfo);
        }
    }
}