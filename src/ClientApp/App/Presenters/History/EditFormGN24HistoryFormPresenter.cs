using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Presenters.History
{
    public class EditFormGN24HistoryFormPresenter : EditHistoryFormPresenter
    {
        private readonly FormGN24 form;

        public EditFormGN24HistoryFormPresenter(FormGN24 form)
            : base(form)
        {
            this.form = form;
        }

        protected override string DomainObjectTypeName
        {
            get { return StringResources.DomainObjectName_FormGN24; }
        }

        protected override string DomainObjectName
        {
            get
            {
                return StringResources.DomainObjectName_FormGN24;
            }
        }

        protected override List<DomainObjectChangeSet> GetChangeSets()
        {
            return editHistoryService.GetEditHistoryForFormGn24(form.IdValue);
        }
    }
}
