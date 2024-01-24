using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Client.Presenters;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Client.Presenters.Page;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls.Details;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class ActionItemDefinationView : BaseForm
    {
        //public ActionItemDefinationView()
        //{
        //    InitializeComponent();
        //}

        public ActionItemDefinationView(ActionItem actionitem, ActionItemStatus[] statusList,
            ActionItemStatus defaultStatus)
        {
            InitializeComponent();
            ActionItemDefinitionPagePresenter presenter = new ActionItemDefinitionPagePresenter();

            //presenter.LoadAd(actionitem);
            RegisterEventHandlersOnPresenter(presenter, actionitem);
        }

        private void RegisterEventHandlersOnPresenter(ActionItemDefinitionPagePresenter presenter, ActionItem a)
        {
            Load += presenter.HandleFormLoad;
            
            //Invoke(new MethodInvoker(delegate
            //{
                
            //    SetDetailData(a,a.Id);
            //    //this.ShowDetails();
            //}));
        }

        
    }
}
