using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Presenters.History
{
    public class EditFormGN59HistoryFormPresenter : EditHistoryFormPresenter
    {
        private readonly FormGN59 form;

        public EditFormGN59HistoryFormPresenter(FormGN59 form) : base(form)
        {
            this.form = form;
        }

        protected override string DomainObjectTypeName
        {
            get { return StringResources.DomainObjectName_FormGN59; }
        }

        protected override string DomainObjectName
        {
            get
            {
                return StringResources.DomainObjectName_FormGN59;
            }
        }

        protected override List<DomainObjectChangeSet> GetChangeSets()
        {
            return editHistoryService.GetEditHistoryForFormGn59(form.IdValue);
        }
    }
}
