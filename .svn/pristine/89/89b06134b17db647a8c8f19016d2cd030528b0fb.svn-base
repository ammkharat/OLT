using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Presenters.History
{
    public class EditFormGN7HistoryFormPresenter : EditHistoryFormPresenter
    {
        private readonly FormGN7 form;

        public EditFormGN7HistoryFormPresenter(FormGN7 form)
            : base(form)
        {
            this.form = form;
        }

        protected override string DomainObjectTypeName
        {
            get { return StringResources.DomainObjectName_FormGN7; }
        }

        protected override string DomainObjectName
        {
            get
            {
                return StringResources.DomainObjectName_FormGN7;
            }
        }

        protected override List<DomainObjectChangeSet> GetChangeSets()
        {
            return editHistoryService.GetEditHistoryFormGn7(form.IdValue);
        }
    }
}
