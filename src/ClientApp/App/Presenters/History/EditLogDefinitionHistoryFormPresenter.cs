using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Presenters.History
{
    public class EditLogDefinitionHistoryFormPresenter : EditHistoryFormPresenter
    {
        private readonly LogDefinition logDefinition;
        private readonly string domainObjectTypeName;

        public EditLogDefinitionHistoryFormPresenter(LogDefinition logDefinition) : base(logDefinition)
        {
            this.logDefinition = logDefinition;
            if (logDefinition.LogType == LogType.DailyDirective)
            {
                domainObjectTypeName = StringResources.DomainObjectName_StandingOrder;
            }
            else
            {
                domainObjectTypeName = StringResources.DomainObjectName_LogDefinition;
            }
        }

        protected override string DomainObjectTypeName
        {
            get { return domainObjectTypeName; }
        }

        protected override string DomainObjectName
        {
            get { return StringResources.NotApplicable; }
        }

        protected override List<DomainObjectChangeSet> GetChangeSets()
        {
            return editHistoryService.GetEditHistoryForLogDefinition(logDefinition.IdValue);
        }
    }
}
