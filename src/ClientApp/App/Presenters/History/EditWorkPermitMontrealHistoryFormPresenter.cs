using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Presenters.History
{
    public class EditWorkPermitMontrealHistoryFormPresenter : EditHistoryFormPresenter
    {
        private readonly WorkPermitMontreal workPermit;

        public EditWorkPermitMontrealHistoryFormPresenter(WorkPermitMontreal workPermit)
            : base(workPermit)
        {
            this.workPermit = workPermit;
        }

        protected override string DomainObjectTypeName
        {
            get { return StringResources.DomainObjectName_WorkPermit; }
        }

        protected override string DomainObjectName
        {
            get { return StringResources.DomainObjectName_WorkPermit; }
        }

        protected override List<DomainObjectChangeSet> GetChangeSets()
        {
            return editHistoryService.GetEditHistoryForMontrealWorkPermit(workPermit.IdValue);
        }
    }
}
