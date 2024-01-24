using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Excursions;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Presenters.History
{
    public class ExcursionResponseHistoryPresenter : EditHistoryFormPresenter
    {
        private readonly OpmExcursionResponse excursionResponse;

        public ExcursionResponseHistoryPresenter(OpmExcursionResponse excursionResponse)
            : base(excursionResponse)
        {
            this.excursionResponse = excursionResponse;
        }

        protected override string DomainObjectTypeName
        {
            get { return StringResources.DomainObjectName_ExcursionResponse; }
        }

        protected override string DomainObjectName
        {
            get { return excursionResponse.HistorianTag; }
        }

        protected override List<DomainObjectChangeSet> GetChangeSets()
        {
            return editHistoryService.GetEditHistoryForExcursionResponse(excursionResponse.OltExcursionId);
        }
    }
}