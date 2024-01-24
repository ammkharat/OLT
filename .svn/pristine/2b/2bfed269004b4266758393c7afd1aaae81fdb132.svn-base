using System;
using System.ComponentModel;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Services;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class ConfigureDORCutoffTimeFormPresenter
    {
        private readonly IConfigureDORCutoffTimeFormView view;
        private readonly ISiteConfigurationService service;
        private bool isSaving;
        
        public ConfigureDORCutoffTimeFormPresenter(IConfigureDORCutoffTimeFormView view)
        {
            this.view = view;
            service = ClientServiceRegistry.Instance.GetService<ISiteConfigurationService>();
        }

        public void LoadForm(object sender, EventArgs e)
        {
            UserContext userContext = ClientSession.GetUserContext();
            view.SiteName = userContext.Site.Name;
            SiteConfiguration siteConfiguration = service.QueryBySiteId(userContext.SiteId);
            view.CutoffTime = siteConfiguration.DorEditCutoffTime;
        }

        public void HandleSaveButtonClick(object sender, EventArgs e)
        {
            if (IsValid)
            {
                isSaving = true;
                long siteId = ClientSession.GetUserContext().SiteId;
                service.UpdateDORCutoffTime(siteId, view.CutoffTime);
                view.CloseForm();
            }
        }


        private bool IsValid
        {
            get
            {
                view.ClearErrors();
                bool isValid = true;

                if (view.CutoffTime == null)
                {
                    view.SetTimeLmitError(StringResources.DORCutoffTimeValueMustBeGreaterThanZeroError);
                    isValid = false;
                }

                return isValid;
            }
        }

        public void HandleCancelButtonClick(object sender, EventArgs e)
        {
            view.CloseForm();
        }

        public void FormClosing(object sender, CancelEventArgs e)
        {
            if (!isSaving)
            {
                return;
            }
        }
    }
}