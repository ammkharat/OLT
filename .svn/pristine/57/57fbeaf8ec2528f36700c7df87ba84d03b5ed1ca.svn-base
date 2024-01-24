using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Restriction;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Presenters.History
{
    public class EditRestrictionDefinitionHistoryFormPresenter : EditHistoryFormPresenter
    {
        private readonly RestrictionDefinition definition;

        public EditRestrictionDefinitionHistoryFormPresenter(RestrictionDefinition definition) : base(definition)
        {
            this.definition = definition;
        }

        protected override string DomainObjectTypeName
        {
            get { return StringResources.DomainObjectName_RestrictionDefinition; }
        }

        protected override string DomainObjectName
        {
            get { return definition.Name; }
        }

        protected override List<DomainObjectChangeSet> GetChangeSets()
        {
            return editHistoryService.GetEditHistoryForRestrictionDefinition(definition.IdValue);
        }
    }
}
