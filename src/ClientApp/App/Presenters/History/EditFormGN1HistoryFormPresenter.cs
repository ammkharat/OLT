using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Presenters.History
{
    public class EditFormGN1HistoryFormPresenter : EditHistoryFormPresenter
    {
        private readonly FormGN1 form;

        public EditFormGN1HistoryFormPresenter(FormGN1 form) : base(form)
        {
            this.form = form;
        }

        protected override string DomainObjectTypeName
        {
            get { return StringResources.DomainObjectName_FormGN1; }
        }

        protected override string DomainObjectName
        {
            get { return StringResources.DomainObjectName_FormGN1; }
        }

        protected override List<DomainObjectChangeSet> GetChangeSets()
        {
            return editHistoryService.GetEditHistoryForFormGN1(form.IdValue);
        }
    }
}
