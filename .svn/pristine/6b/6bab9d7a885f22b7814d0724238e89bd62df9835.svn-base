using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Presenters.History
{
    public class PermitAssessmentHistoryFormPresenter : EditHistoryFormPresenter
    {
        private readonly PermitAssessment form;

        public PermitAssessmentHistoryFormPresenter(PermitAssessment form)
            : base(form)
        {
            this.form = form;
        }

        protected override string DomainObjectTypeName
        {
            get { return StringResources.DomainObjectName_OilsandsPermitAssessmentForm; }
        }

        protected override string DomainObjectName
        {
            get { return StringResources.DomainObjectName_OilsandsPermitAssessmentForm; }
        }

        protected override List<DomainObjectChangeSet> GetChangeSets()
        {
            return editHistoryService.GetEditHistoryForOilsandsPermitAssessmentForm(form.IdValue);
        }
    }
}