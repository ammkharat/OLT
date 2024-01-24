using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.LabAlert;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Presenters.History
{
    public class EditLabAlertDefinitionHistoryFormPresenter : EditHistoryFormPresenter 
    {
        private readonly LabAlertDefinition definition;

        public EditLabAlertDefinitionHistoryFormPresenter(LabAlertDefinition definition) : base(definition)
        {
            this.definition = definition;
        }

        protected override string DomainObjectTypeName
        {
            get { return StringResources.DomainObjectName_LabAlertDefinition; }
        }

        protected override string DomainObjectName
        {
            get { return definition.Name; }
        }

        protected override List<DomainObjectChangeSet> GetChangeSets()
        {
            return editHistoryService.GetEditHistoryForLabAlertDefinition(definition.IdValue);
        }
    }
}
