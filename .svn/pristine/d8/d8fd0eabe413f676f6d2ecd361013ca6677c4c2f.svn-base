using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Presenters.History
{
    public class TradeChecklistHistoryFormPresenter : EditHistoryFormPresenter
    {
        private readonly TradeChecklist form;

        public TradeChecklistHistoryFormPresenter(TradeChecklist form) : base(form)
        {
            this.form = form;
        }

        protected override string DomainObjectTypeName
        {
            get { return StringResources.DomainObjectName_TradeChecklist; }
        }

        protected override string DomainObjectName
        {
            get { return StringResources.DomainObjectName_TradeChecklist; }
        }

        protected override List<DomainObjectChangeSet> GetChangeSets()
        {
            return editHistoryService.GetEditHistoryForTradeChecklist(form.IdValue);
        }
    }
}
