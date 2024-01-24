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
    public class ConfigureRestrictionReportingLimitsFormPresenter
    {
        private readonly IConfigureRestrictionReportingLimitsFormView view;
        private readonly ISiteConfigurationService service;
        private bool isSaving;
     
        public ConfigureRestrictionReportingLimitsFormPresenter(IConfigureRestrictionReportingLimitsFormView view)
        {
            this.view = view;
            service = ClientServiceRegistry.Instance.GetService<ISiteConfigurationService>();
        }

        public void LoadForm(object sender, EventArgs e)
        {
            UserContext userContext = ClientSession.GetUserContext();
            view.SiteName = userContext.Site.Name;
            SiteConfiguration siteConfiguration = service.QueryBySiteId(userContext.SiteId);
            view.DaysToEditDeviationAlerts = siteConfiguration.DaysToEditDeviationAlerts.ToString();
        }

        public void HandleSaveButtonClick(object sender, EventArgs e)
        {
            if (IsValid)
            {
                isSaving = true;
                long siteId = ClientSession.GetUserContext().SiteId;
                service.UpdateRestrictionReportingLimits(siteId, DaysToEditDeviationAlerts);
                view.CloseForm();
            }
        }

        public void HandleCancelButtonClick(object sender, EventArgs e)
        {
            view.CloseForm();
        }

        public void DaysToEditDeviationAlertsTextBox_Validating(object sender, CancelEventArgs e)
        {
            Validate();
        }

        private void Validate()
        {
            view.ClearErrors();
            if (!IsValid)
            {
                view.SetErrorForDaysToEditDeviationAlerts(StringResources.DaysToEditDeviationAlertsMustBeGreaterThanZeroError);
                view.DaysToEditDeviationAlerts = "0";
            }
        }

        public void FormClosing(object sender, CancelEventArgs e)
        {
            if (!isSaving)
            {
                return;
            }
        }

        private int DaysToEditDeviationAlerts
        {
            get
            {
                if (view.DaysToEditDeviationAlerts.IsNullOrEmptyOrWhitespace())
                {
                    return 0;
                }
                int daysToDisplay;
                view.DaysToEditDeviationAlerts.TryParse(out daysToDisplay);
                return daysToDisplay;
            }
        }

        private bool IsValid
        {
            get { return DaysToEditDeviationAlerts > 0; }
        }
    }
}