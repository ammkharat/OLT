using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;

namespace Com.Suncor.Olt.Client.Presenters.Validation.ValidationError
{
    public class SectionValidationError : IValidationIssue
    {
        private readonly WorkPermitSection section;

        public ProblemLevel ProblemLevel { get; private set; }

        public WorkPermitSection WorkPermitSection
        {
            get
            {
                return section;
            }
        }

        public SectionValidationError(WorkPermitSection section, ProblemLevel problemLevel)
        {
            this.section = section;
            ProblemLevel = problemLevel;
        }

        public void Bind(IWorkPermitFormView view)
        {
            view.IndicateProblemOnSection(section, ProblemLevel);
        }
    }
}