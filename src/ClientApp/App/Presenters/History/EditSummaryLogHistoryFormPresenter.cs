using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Presenters.History
{
    public class EditSummaryLogHistoryFormPresenter : EditHistoryFormPresenter
    {
        private readonly SummaryLog log;

        public EditSummaryLogHistoryFormPresenter(SummaryLog log) : base(log)
        {
            this.log = log;
        }

        protected override string DomainObjectTypeName
        {
            get { return StringResources.DomainObjectName_SummaryLog; }
        }

        protected override string DomainObjectName
        {
            get { return StringResources.NotApplicable; }
        }

        protected override List<DomainObjectChangeSet> GetChangeSets()
        {
            return editHistoryService.GetEditHistoryForSummaryLog(log.IdValue);
        }
    }
}
