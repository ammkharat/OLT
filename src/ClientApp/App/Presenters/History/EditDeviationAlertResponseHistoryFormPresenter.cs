using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Restriction;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Presenters.History
{
    public class EditDeviationAlertResponseHistoryFormPresenter : EditHistoryFormPresenter
    {
        private readonly DeviationAlert alert;

        public EditDeviationAlertResponseHistoryFormPresenter(DeviationAlert alert) : base(alert)
        {
            this.alert = alert;
        }

        protected override string DomainObjectTypeName
        {
            get { return StringResources.DomainObjectName_DeviationAlertResponse; }
        }

        protected override string DomainObjectName
        {
            get { return alert.RestrictionDefinitionName; }
        }

        protected override List<DomainObjectChangeSet> GetChangeSets()
        {
            if (alert.DeviationAlertResponse != null)
            {
                return editHistoryService.GetEditHistoryForDeviationAlertResponse(alert.DeviationAlertResponse.IdValue);
            }
            return new List<DomainObjectChangeSet>();
        }
    }
}
