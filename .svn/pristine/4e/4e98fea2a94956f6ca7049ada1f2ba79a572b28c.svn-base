using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.CokerCard;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Presenters.History
{
    public class EditCokerCardHistoryFormPresenter : EditHistoryFormPresenter
    {
        private readonly CokerCard cokerCard;

        public EditCokerCardHistoryFormPresenter(CokerCard cokerCard) : base(cokerCard)
        {
            this.cokerCard = cokerCard;
        }

        protected override string DomainObjectTypeName
        {
            get { return StringResources.DomainObjectName_CokerCard; }
        }

        protected override string DomainObjectName
        {
            get { return cokerCard.ConfigurationName; }
        }

        protected override List<DomainObjectChangeSet> GetChangeSets()
        {
            return editHistoryService.GetEditHistoryForCokerCard(cokerCard.IdValue);
        }
    }
}