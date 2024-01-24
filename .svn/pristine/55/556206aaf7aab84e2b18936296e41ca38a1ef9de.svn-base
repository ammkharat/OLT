using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Presenters.History
{
    class EditWorkPermitSignHistoryPresenter:EditHistoryFormPresenter
    {
        private readonly WorkPermitSign form;

         public EditWorkPermitSignHistoryPresenter(WorkPermitSign form)
             : base(form)
        {
            this.form = form;
        }

        protected override string DomainObjectTypeName
        {
            get { return "WorkPermit Signature History";// StringResources.DomainObjectName_FormOP14; 
            }
        }

        protected override string DomainObjectName
        {
            get
            {
                return "WorkPermit Signature History";
            }
        }

        protected override List<DomainObjectChangeSet> GetChangeSets()
        {
            return editHistoryService.GetEditHistoryForWorkPermitSign(form.WorkPermitId);
        }
    }
}
