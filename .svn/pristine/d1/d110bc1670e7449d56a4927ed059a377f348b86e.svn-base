using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Presenters.History
{
    public class EditWorkPermitHistoryFormPresenter : EditHistoryFormPresenter
    {
        private readonly WorkPermit workPermit;

        public EditWorkPermitHistoryFormPresenter(WorkPermit workPermit) : base(workPermit)
        {
            this.workPermit = workPermit;
        }

        protected override string DomainObjectTypeName
        {
            get { return StringResources.DomainObjectName_WorkPermit; }
        }

        protected override string DomainObjectName
        {
            get { return StringResources.NotApplicable; }
        }

        protected override List<DomainObjectChangeSet> GetChangeSets()
        {
            return editHistoryService.GetEditHistoryForWorkPermit(workPermit.IdValue);
        }
    }
}
