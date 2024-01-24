using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Presenters.History
{
    public class EditFormOP14HistoryFormPresenter : EditHistoryFormPresenter
    {
        private readonly FormOP14 form;

        public EditFormOP14HistoryFormPresenter(FormOP14 form) : base(form)
        {
            this.form = form;
        }

        protected override string DomainObjectTypeName
        {
            get { return StringResources.DomainObjectName_FormOP14; }
        }

        protected override string DomainObjectName
        {
            get
            {
                return StringResources.DomainObjectName_FormOP14;
            }
        }

        protected override List<DomainObjectChangeSet> GetChangeSets()
        {
            return editHistoryService.GetEditHistoryForFormOp14(form.IdValue);
        }
    }
}
