using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class WorkPermitCloseFormPresenter : AbstractWorkPermitCloseCommentPresenter
    {
        public WorkPermitCloseFormPresenter(IWorkPermitCloseFormView view, List<WorkPermit> workPermits) : this(
            view, 
            workPermits,
            ClientServiceRegistry.Instance.GetService<IWorkPermitService>())
        {
        }

        public WorkPermitCloseFormPresenter(
            IWorkPermitCloseFormView view,
            List<WorkPermit> workPermits,
            IWorkPermitService workPermitService)
            : base(view, workPermits, workPermitService)
        {
        }

        public override void LoadForm(object sender, EventArgs e)
        {
            base.LoadForm(sender, e);
            view.FormTitle = StringResources.WorkPermitCloseFormTitle;
            view.CreateLogChecked = false;
            view.CreateLogEnabled = true;
        }

        protected override void Save(WorkPermit workPermit)
        {
            if (view.CreateLogChecked)
            {
                SaveWithLog(workPermit);
            }
            else
            {
                SaveWithoutLog(workPermit);
            }

            shouldSkipConfirmWhenClosingForm = true;
        }

        private static void ModifyWorkPermit(WorkPermit workPermit)
        {
            workPermit.SetWorkPermitStatus(WorkPermitStatus.Complete);
            workPermit.LastModifiedBy = ClientSession.GetUserContext().User;
            workPermit.LastModifiedDate = Clock.Now;
        }

        private void SaveWithLog(WorkPermit workPermit)
        {
            WorkPermitStatus originalStatus = workPermit.WorkPermitStatus;
            ModifyWorkPermit(workPermit);
            ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(workPermitService.Update, workPermit);
            InsertLog(BuildLogMessage(CreateStatusChangeMessage(originalStatus), workPermit), workPermit);
        }

        private static string CreateStatusChangeMessage(WorkPermitStatus originalStatus)
        {           
            string message = string.Format(StringResources.CloseWorkPermitLogMessage, originalStatus, WorkPermitStatus.Complete);
            return message + Environment.NewLine;
        }

        private void SaveWithoutLog(WorkPermit workPermit)
        {
            ModifyWorkPermit(workPermit);
            ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(workPermitService.Update, workPermit);
        }
    }
}