using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Presenters.History
{
    public class ConfinedSpaceMudsHistoryFormPresenter : EditHistoryFormPresenter
    {
        private readonly ConfinedSpaceMuds confinedSpace;

        public ConfinedSpaceMudsHistoryFormPresenter(ConfinedSpaceMuds confinedSpace)
            : base(confinedSpace)
        {
            this.confinedSpace = confinedSpace;
        }

        protected override string DomainObjectTypeName
        {
            get { return StringResources.DomainObjectName_ConfinedSpace; }
        }

        protected override string DomainObjectName
        {
            get { return StringResources.DomainObjectName_ConfinedSpace; }
        }

        protected override List<DomainObjectChangeSet> GetChangeSets()
        {
            return editHistoryService.GetEditHistoryForConfinedSpaceMuds(confinedSpace.IdValue);
        }

    }
}