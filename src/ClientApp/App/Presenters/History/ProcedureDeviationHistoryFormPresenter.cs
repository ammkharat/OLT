using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Presenters.History
{
    public class ProcedureDeviationHistoryFormPresenter : EditHistoryFormPresenter
    {
        private readonly ProcedureDeviation form;

        public ProcedureDeviationHistoryFormPresenter(ProcedureDeviation form)
            : base(form)
        {
            this.form = form;
        }

        protected override string DomainObjectTypeName
        {
            get { return StringResources.DomainObjectName_ProcedureDeviationForm; }
        }

        protected override string DomainObjectName
        {
            get { return StringResources.DomainObjectName_ProcedureDeviationForm; }
        }

        protected override List<DomainObjectChangeSet> GetChangeSets()
        {
            return editHistoryService.GetEditHistoryForProcedureDeviation(form.IdValue);
        }
    }
}