using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Presenters.History
{
    public class LubesCsdHistoryFormPresenter : EditHistoryFormPresenter
    {
        private readonly LubesCsdForm form;

        public LubesCsdHistoryFormPresenter(LubesCsdForm form)
            : base(form)
        {
            this.form = form;
        }

        protected override string DomainObjectTypeName
        {
            get { return StringResources.DomainObjectName_LubesCsdForm; }
        }

        protected override string DomainObjectName
        {
            get
            {
                return StringResources.DomainObjectName_LubesCsdForm;
            }
        }

        protected override List<DomainObjectChangeSet> GetChangeSets()
        {
            return editHistoryService.GetEditHistoryForLubesCsdForm(form.IdValue);
        }
    }
}
