using Com.Suncor.Olt.Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Com.Suncor.Olt.Client.Presenters.History
{
   public class EditWorkPermitMudsSignHistoryPresenter : EditHistoryFormPresenter
    {
        private readonly WorkPermitMudSign form;

        public EditWorkPermitMudsSignHistoryPresenter(WorkPermitMudSign form)
             : base(form)
        {
            this.form = form;
        }

        protected override string DomainObjectTypeName
        {
            get
            {
                return "Histoire";// StringResources.DomainObjectName_FormOP14; 
            }
        }

        protected override string DomainObjectName
        {
            get
            {
                return "Histoire";
            }
        }

        protected override List<DomainObjectChangeSet> GetChangeSets()
        {
            return editHistoryService.GetEditHistoryForWorkPermitMudsSign(form.WorkPermitId);
        }
    }
}
