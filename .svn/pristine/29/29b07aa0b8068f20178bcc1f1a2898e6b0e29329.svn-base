using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Presenters.History
{
    public class EditPermitRequestLubesHistoryFormPresenter : EditHistoryFormPresenter
    {
        private readonly PermitRequestLubes permitRequest;

        public EditPermitRequestLubesHistoryFormPresenter(PermitRequestLubes permitRequest)
            : base(permitRequest)
        {
            this.permitRequest = permitRequest;
        }

        protected override string DomainObjectTypeName
        {
            get { return StringResources.DomainObjectName_PermitRequest; }
        }

        protected override string DomainObjectName
        {
            get { return StringResources.NotApplicable; }
        }

        protected override List<DomainObjectChangeSet> GetChangeSets()
        {
            return editHistoryService.GetEditHistoryForLubesPermitRequest(permitRequest.IdValue);
        }
    }
}
