
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Presenters.History
{
    public class EditPermitRequestFortHillsHistoryFormPresenter : EditHistoryFormPresenter
    {
        private readonly PermitRequestFortHills request;

        public EditPermitRequestFortHillsHistoryFormPresenter(PermitRequestFortHills request)
            : base(request)
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
            return editHistoryService.GetEditHistoryForEdmontonPermitRequest(request.IdValue);
        }
    }
}
