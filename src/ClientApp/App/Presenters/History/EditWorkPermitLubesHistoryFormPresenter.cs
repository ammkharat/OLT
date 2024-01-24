using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Presenters.History
{
    public class EditWorkPermitLubesHistoryFormPresenter : EditHistoryFormPresenter
    {
        private readonly WorkPermitLubes workPermit;

        public EditWorkPermitLubesHistoryFormPresenter(WorkPermitLubes workPermit)
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
            get
            {
                if (workPermit.WorkOrderNumber != null)
                {
                    return StringResources.WorkPermitDescription_WorkOrderNumberLabel + workPermit.WorkOrderNumber;
                }

                return StringResources.DomainObjectName_WorkPermit;
            }
        }

        protected override List<DomainObjectChangeSet> GetChangeSets()
        {
            return editHistoryService.GetEditHistoryForLubesWorkPermit(workPermit.IdValue);
        }
    }
}
