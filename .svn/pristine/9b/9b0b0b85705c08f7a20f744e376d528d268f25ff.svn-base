using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Presenters.History
{
    public class EditFormOilsandsTrainingHistoryFormPresenter : EditHistoryFormPresenter
    {
        private readonly FormOilsandsTraining form;

        public EditFormOilsandsTrainingHistoryFormPresenter(FormOilsandsTraining form)
            : base(form)
        {
            this.form = form;
        }

        protected override string DomainObjectTypeName
        {
            get { return StringResources.DomainObjectName_FormOilsandsTraining; }
        }

        protected override string DomainObjectName
        {
            get
            {
                return StringResources.DomainObjectName_FormOilsandsTraining;
            }
        }

        protected override List<DomainObjectChangeSet> GetChangeSets()
        {
            return editHistoryService.GetEditHistoryForOilsandsTrainingForm(form.IdValue);
        }
    }
}
