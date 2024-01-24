using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Presenters.History
{
    public class GenericCsdHistoryPresenter : EditHistoryFormPresenter
    {
        private readonly GenericCsd form;

        public GenericCsdHistoryPresenter(GenericCsd form)
            : base(form)
        {
            this.form = form;
        }

        protected override string DomainObjectTypeName
        {
            get { return StringResources.DomainObjectName_FormMontrealCsd; }
        }

        protected override string DomainObjectName
        {
            get
            {
                return StringResources.DomainObjectName_FormMontrealCsd;
            }
        }

        protected override List<DomainObjectChangeSet> GetChangeSets()
        {
            return editHistoryService.GetEditHistoryForMontrealCsd(form.IdValue);
        }
    }
}
