using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Presenters.History
{
    public class EditFormGenericTemplateFormPresenter : EditHistoryFormPresenter
    {
        private readonly FormGenericTemplate form;

        public EditFormGenericTemplateFormPresenter(FormGenericTemplate form)
            : base(form)
        {
            this.form = form;
        }

        protected override string DomainObjectTypeName
        {
            get { return form.FormType.Name; } //TODO
        }

        protected override string DomainObjectName
        {
            get
            {
                return form.FormType.Name;    //todo
            }
        }

        protected override List<DomainObjectChangeSet> GetChangeSets()
        {
            return editHistoryService.GetEditHistoryForFormGenericTemplate(form.IdValue);
        }
    }
}
