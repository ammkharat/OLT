using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Presenters.History
{
    public class EditFormEdmontonOvertimeFormHistoryPresenter : EditHistoryFormPresenter
    {
        private readonly OvertimeForm form;

        public EditFormEdmontonOvertimeFormHistoryPresenter(OvertimeForm form)
            : base(form)
        {
            this.form = form;
        }

        protected override string DomainObjectTypeName
        {
            get { return StringResources.DomainObjectName_OvertimeForm; }
        }

        protected override string DomainObjectName
        {
            get
            {
                return StringResources.DomainObjectName_OvertimeForm;
            }
        }

        protected override List<DomainObjectChangeSet> GetChangeSets()
        {
            return editHistoryService.GetEditHistoryForOvertimeForm(form.IdValue);
        }
    }
}
