using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Client.Presenters
{
    public abstract class AbstractWorkPermitCloseCommentPresenter
    {
        protected readonly IWorkPermitCloseFormView view;
        private readonly List<WorkPermit> workPermits;
        protected bool shouldSkipConfirmWhenClosingForm;
        protected readonly IWorkPermitService workPermitService;
        private readonly UserContext userContext;

        protected AbstractWorkPermitCloseCommentPresenter(
            IWorkPermitCloseFormView view, 
            List<WorkPermit> workPermits,
            IWorkPermitService workPermitService)
        {
            this.view = view;
            this.workPermits = workPermits;
            this.workPermitService = workPermitService;
            userContext = ClientSession.GetUserContext();
            SubscribeToViewEvents();
        }

        public virtual void LoadForm(object sender, EventArgs e)
        {
            view.Author = userContext.User;
            view.CreateDateTime = Clock.Now;
            view.Shift = userContext.UserShift.ShiftPatternName;

            if (workPermits.Count == 1)
            {
                view.Description = workPermits[0].Description();
            }
            else
            {
                view.HideDescription();
            }
            
            view.IsLogAnOperatingEngineeringLog = false;

            SiteConfiguration siteConfiguration = userContext.SiteConfiguration;

            view.OperatingEngineerLogDisplayText = siteConfiguration.OperatingEngineerLogDisplayName;

            if (!siteConfiguration.CreateOperatingEngineerLogs)
            {
                view.HideOperatingEngineerLogCheckbox();
            }            
        }

        private void SubscribeToViewEvents()
        {
            view.FormClosing += FormClosing;
            view.Load += LoadForm;
            view.SubmitButtonClick += Submit;
            view.CancelButtonClick += Cancel;
            view.CreateLogCheckedChanged += CreateLogCheckedChanged;
        }

        protected void InsertLog(string logMessage, WorkPermit workPermit)
        {
            User currentUser = userContext.User;
            
            ServiceEventDispatcher.CallServiceAndDispatchImmediateEventNotification(
                workPermitService.InsertLog,
                workPermit, 
                currentUser, 
                logMessage, 
                userContext.UserShift.ShiftPattern,
                view.IsLogAnOperatingEngineeringLog,
                userContext.Assignment,
                userContext.Role);
        }

        protected abstract void Save(WorkPermit workPermit);
        
        public void Submit(object sender, EventArgs e)
        {
            try
            {
                workPermits.ForEach(Save);
                view.SaveSucceededMessage();
            }
            catch (Exception)
            {
                shouldSkipConfirmWhenClosingForm = true;
                view.SaveFailedMessage();
            }            
        }

        public void CreateLogCheckedChanged(object sender, EventArgs e)
        {            
            if (userContext.SiteConfiguration.CreateOperatingEngineerLogs)
            {
                view.EnableMakingAnOperatingEngineerLog(); 
            }
           
            if (view.CreateLogChecked)
            {
                view.EnableLogCreatedWithComments();                
            }
            else
            {
                view.DisableLogCreatedWithComments();                
            }
        }

        private void Cancel(object sender, EventArgs e)
        {
            view.Close();
        }

        private void FormClosing(object sender, FormClosingEventArgs eventArgs)
        {
            if (!ClientSession.GetInstance().ForceLogoff && !shouldSkipConfirmWhenClosingForm && !view.ConfirmCancelDialog())
            {
                eventArgs.Cancel = true;
            }
        }

        protected string BuildLogMessage(string statusChangeMessage, WorkPermit workPermit)
        {
            var builder = new StringBuilder();

            builder.AppendLine(String.Format(StringResources.WorkPermitCloseCommentForLogPrefix, view.Comment));
            builder.AppendLine();
            
            if (!statusChangeMessage.IsNullOrEmptyOrWhitespace())
            {
                builder.AppendLine(statusChangeMessage);    
            }
            
            builder.Append(workPermit.Description());

            return builder.ToString();
        }

    }
}

