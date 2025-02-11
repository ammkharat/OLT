﻿using System;
using System.Collections.Generic;
using System.IO;
using Com.Suncor.Olt.Client.Excel;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Forms.Reporting;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.FlocSet;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Client.Presenters
{
    public  class MarkAsNotReadFormPresenter
    {

        private readonly IMarkedAsNotReadForm view;
        private readonly IDirectiveService directiveService;
        private readonly Directive directive;
        public MarkAsNotReadFormPresenter(long directiveId,IMarkedAsNotReadForm view)
        {
            this.view = view;
            directiveService = ClientServiceRegistry.Instance.GetService<IDirectiveService>();
            directive = directiveService.QueryById(directiveId);
        }

        public void Form_Load(object sender, EventArgs e)
        {
           
            view.MarkedAsNotReadBy = directiveService.UsersThatMarkedDirectiveAsNotRead(directive.IdValue,new  RootFlocSet(new List<FunctionalLocation>(directive.FunctionalLocations)));

        }
    }
   
}
