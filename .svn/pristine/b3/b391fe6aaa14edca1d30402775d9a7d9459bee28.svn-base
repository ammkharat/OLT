using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Presenters.History
{
    public class LubesAlarmDisableHistoryFormPresenter : EditHistoryFormPresenter
    {
        private readonly LubesAlarmDisableForm form;

        public LubesAlarmDisableHistoryFormPresenter(LubesAlarmDisableForm form)
            : base(form)
        {
            this.form = form;
        }

        protected override string DomainObjectTypeName
        {
            get { return StringResources.DomainObjectName_LubesAlarmDisableForm; }
        }

        protected override string DomainObjectName
        {
            get { return StringResources.DomainObjectName_LubesAlarmDisableForm; }
        }

        protected override List<DomainObjectChangeSet> GetChangeSets()
        {
            return editHistoryService.GetEditHistoryForLubesAlarmDisableForm(form.IdValue);
        }
    }
}