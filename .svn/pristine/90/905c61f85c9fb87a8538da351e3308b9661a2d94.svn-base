using System;
using System.ComponentModel;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Services;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class LabAlertConfigurationFormPresenter
    {      
        private readonly ILabAlertConfigurationFormView view;
        private readonly ISiteConfigurationService service;
        private bool isSaving;
        private readonly UserContext userContext;
        
        public LabAlertConfigurationFormPresenter(ILabAlertConfigurationFormView view) : this(
            view,
            ClientServiceRegistry.Instance.GetService<ISiteConfigurationService>())
        {
        }

        public LabAlertConfigurationFormPresenter(ILabAlertConfigurationFormView view, ISiteConfigurationService service)
        {
            this.view = view;
            this.service = service;
            userContext = ClientSession.GetUserContext();
        }

        public void LoadForm(object sender, EventArgs e)
        {
            view.SiteName = userContext.Site.Name;
            SiteConfiguration siteConfiguration = service.QueryBySiteIdWithNoCaching(userContext.SiteId);
            view.RetryAttempts = siteConfiguration.LabAlertRetryAttemptLimit.ToString();           
        }

        public void HandleSaveButtonClick(object sender, EventArgs e)
        {
            long siteId = userContext.SiteId;

            if (RetryAttemptsIsValid)
            {
                isSaving = true;
                service.UpdateLabAlertRetryAttemptLimit(siteId, RetryAttempts);              
                view.CloseForm();
            }
        }

        public void HandleCancelButtonClick(object sender, EventArgs e)
        {
            view.CloseForm();
        }

        public void HandleValidatingForRetryAttempts(object sender, CancelEventArgs e)
        {
            Validate();
        }

        private void Validate()
        {
            view.ClearErrors();

            if (!RetryAttemptsIsValid)
            {
                view.SetErrorForRetryAttempts(StringResources.LabAlertConfigurationInvalidError);               
            }           
        }

        public void FormClosing(object sender, CancelEventArgs e)
        {
            if (!isSaving)
                return;
        }

        private int RetryAttempts
        {
            get
            {
                int daysToDisplay = 0;

                string retryAttemptsString = view.RetryAttempts;

                if(retryAttemptsString != null)
                {
                    retryAttemptsString.TryParse(out daysToDisplay);
                }

                return daysToDisplay;
            }
        }
       
        private bool RetryAttemptsIsValid
        {
            get { return RetryAttempts >= 0 && RetryAttempts <= 12; }
        }        
    }
}