using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Presenters.History
{
    public class EditWorkPermitMudsHistoryFormPresenter : EditHistoryFormPresenter
    {
        private readonly WorkPermitMuds workPermit;

        public EditWorkPermitMudsHistoryFormPresenter(WorkPermitMuds workPermit)
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
            return editHistoryService.GetEditHistoryForMudsWorkPermit(workPermit.IdValue);
        }
    }
}
