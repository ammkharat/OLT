using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Presenters.History
{
    public class EditActionItemDefinitionHistoryFormPresenter : EditHistoryFormPresenter
    {
        private readonly ActionItemDefinition actionItemDefinition;

        public EditActionItemDefinitionHistoryFormPresenter(ActionItemDefinition actionItemDefinition) : base(actionItemDefinition)
        {
            this.actionItemDefinition = actionItemDefinition;
        }

        protected override string DomainObjectTypeName
        {
            get { return StringResources.DomainObjectName_ActionItemDefinition; }
        }

        protected override string DomainObjectName
        {
            get { return actionItemDefinition.Name; }
        }

        protected override List<DomainObjectChangeSet> GetChangeSets()
        {
            return editHistoryService.GetEditHistoryForActionItemDefinition(actionItemDefinition.IdValue);
        }
    }
}
