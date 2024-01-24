using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Target;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Presenters.History
{
    public class EditTargetDefinitionHistoryFormPresenter : EditHistoryFormPresenter
    {
        private readonly TargetDefinition targetDefinition;

        public EditTargetDefinitionHistoryFormPresenter(TargetDefinition targetDefinition) : base(targetDefinition)
        {
            this.targetDefinition = targetDefinition;
        }

        protected override string DomainObjectTypeName
        {
            get { return StringResources.DomainObjectName_TargetDefinition; }
        }

        protected override string DomainObjectName
        {
            get { return targetDefinition.Name; }
        }

        protected override List<DomainObjectChangeSet> GetChangeSets()
        {
            return editHistoryService.GetEditHistoryForTargetDefinition(targetDefinition.IdValue);
        }
    }
}
