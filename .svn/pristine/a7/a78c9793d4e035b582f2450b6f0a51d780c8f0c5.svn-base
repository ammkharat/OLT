using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Services;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class WorkPermitCommentFormPresenter : AbstractWorkPermitCloseCommentPresenter
    {

        public WorkPermitCommentFormPresenter(IWorkPermitCloseFormView view, List<WorkPermit> workPermits): this(
            view, 
            workPermits,
            ClientServiceRegistry.Instance.GetService<IWorkPermitService>())
        {
        }

        public WorkPermitCommentFormPresenter(IWorkPermitCloseFormView view, WorkPermit workPermit)
            : this(
                view,
                new List<WorkPermit> {workPermit},
                ClientServiceRegistry.Instance.GetService<IWorkPermitService>())
        {
        }

        public WorkPermitCommentFormPresenter(
            IWorkPermitCloseFormView view,
            List<WorkPermit> workPermits,
            IWorkPermitService workPermitService)
            : base(view, workPermits, workPermitService)
        {
        }

        public override void LoadForm(object sender, EventArgs e)
        {            
            base.LoadForm(null, null);
            view.FormTitle = StringResources.WorkPermitCommentFormTitle;
            view.CreateLogChecked = true;
            
            view.EnableLogCreatedWithComments();
            
            view.CreateLogEnabled = false;

            if(ClientSession.GetUserContext().SiteConfiguration.CreateOperatingEngineerLogs)
            {
                view.EnableMakingAnOperatingEngineerLog();
            }
            else
            {
                view.HideOperatingEngineerLogCheckbox();
            }            
        }

        protected override void Save(WorkPermit workPermit)
        {
            InsertLog(BuildLogMessage(string.Empty, workPermit), workPermit);
            shouldSkipConfirmWhenClosingForm = true;
        }
    }
}