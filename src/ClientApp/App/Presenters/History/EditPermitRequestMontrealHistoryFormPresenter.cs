using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Presenters.History
{
    public class EditPermitRequestMontrealHistoryFormPresenter : EditHistoryFormPresenter 
    {
        private readonly PermitRequestMontreal request;

        public EditPermitRequestMontrealHistoryFormPresenter(PermitRequestMontreal request) : base(request)
        {
            this.request = request;
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
            return editHistoryService.GetEditHistoryForMontrealPermitRequest(request.IdValue);
        }
    }
}
