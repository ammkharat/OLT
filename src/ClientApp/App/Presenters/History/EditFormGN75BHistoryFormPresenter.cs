﻿using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Presenters.History
{
    public class EditFormGN75BHistoryFormPresenter : EditHistoryFormPresenter
    {
        private readonly FormGN75B form;

        public EditFormGN75BHistoryFormPresenter(FormGN75B form) : base(form)
        {
            this.form = form;
        }

        protected override string DomainObjectTypeName
        {
            get { return StringResources.DomainObjectName_FormGN75B; }
        }

        protected override string DomainObjectName
        {
            get { return StringResources.DomainObjectName_FormGN75B; }
        }

        //Aarti INC0548411
        protected override List<DomainObjectChangeSet> GetChangeSets()
        {
            return editHistoryService.GetEditHistoryForFormGN75B(form.IdValue,form.SiteID);
        }
    }
}