using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Presenters.History
{
    public class EditFormGN75AHistoryFormPresenter : EditHistoryFormPresenter
    {
        private readonly FormGN75A form;

        public EditFormGN75AHistoryFormPresenter(FormGN75A form) : base(form)
        {
            this.form = form;
        }

        protected override string DomainObjectTypeName
        {
            get { return StringResources.DomainObjectName_FormGN75A; }
        }

        protected override string DomainObjectName
        {
            get { return StringResources.DomainObjectName_FormGN75A; }
        }

        protected override List<DomainObjectChangeSet> GetChangeSets()
        {
            return editHistoryService.GetEditHistoryForFormGN75A(form.IdValue);
        }
    }
}
