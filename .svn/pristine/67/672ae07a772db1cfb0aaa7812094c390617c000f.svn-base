using Com.Suncor.Olt.Common.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Com.Suncor.Olt.Client.Presenters.History
{
   public  class EditConfinedSpaceSignHistoryPresenter : EditHistoryFormPresenter
    {
       private readonly ConfinedSpaceMudSign form;
       public EditConfinedSpaceSignHistoryPresenter(ConfinedSpaceMudSign form)
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
           return editHistoryService.GetEditHistoryForConfinedSpaceMudsSign(form.ConfinedSpaceId);
       }

    }
}
