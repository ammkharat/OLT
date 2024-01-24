using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Presenters.History
{
    public class EditGasTestElementInfoConfigurationHistoryFormPresenter : EditHistoryFormPresenter
    {
        private readonly Site site;

        public EditGasTestElementInfoConfigurationHistoryFormPresenter(Site site) : base(site)
        {
            this.site = site;
        }

        protected override string DomainObjectTypeName
        {
            get { return StringResources.DomainObjectName_GasTestElementInfoConfiguration; }
        }

        protected override string DomainObjectName
        {
            get { return StringResources.NotApplicable; }
        }

        protected override List<DomainObjectChangeSet> GetChangeSets()
        {
            return editHistoryService.GetEditHistory(site);
        }
    }
}
