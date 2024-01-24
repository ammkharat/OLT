using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Presenters.History
{
    public class EditLogHistoryFormPresenter : EditHistoryFormPresenter
    {
        private readonly Log log;
        private readonly string domainObjectTypeName;

        public EditLogHistoryFormPresenter(Log log) : base(log)
        {
            this.log = log;
            if (log.LogType == LogType.DailyDirective)
            {
                domainObjectTypeName = StringResources.DomainObjectName_DailyDirective;
            }
            else
            {
                domainObjectTypeName = StringResources.DomainObjectName_Log;
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
            return editHistoryService.GetEditHistoryForLog(log.IdValue);
        }
    }
}
