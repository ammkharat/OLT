using System;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Services;
using log4net;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class ConfigureWorkPermitArchivalProcessFormPresenter
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(ConfigureWorkPermitArchivalProcessFormPresenter));
        protected bool shouldSkipConfirm = true;
        private readonly IConfigureWorkPermitArchivalProcessForm view;
        private readonly ISiteConfigurationService service;
        
        public ConfigureWorkPermitArchivalProcessFormPresenter(IConfigureWorkPermitArchivalProcessForm view) : this(
            view,
            ClientServiceRegistry.Instance.GetService<ISiteConfigurationService>())
        {
        }

        public ConfigureWorkPermitArchivalProcessFormPresenter(
            IConfigureWorkPermitArchivalProcessForm view,
            ISiteConfigurationService service)
        {
            this.view = view;
            this.service = service;
        }

        public void LoadForm(object o, EventArgs empty)
        {
            UserContext userContext = ClientSession.GetUserContext();
            SiteConfiguration configuration = service.QueryBySiteId(userContext.SiteId);

            view.SiteName = userContext.Site.Name;
            view.DaysBeforeArchivingClosedWorkPermits = configuration.DaysBeforeArchivingClosedWorkPermits;
            view.DaysBeforeClosingIssuedWorkPermits = configuration.DaysBeforeClosingIssuedWorkPermits;
            view.DaysBeforeDeletingPendingWorkPermits = configuration.DaysBeforeDeletingPendingWorkPermits;
        }

        public void HandleSaveButtonClick(object sender, EventArgs args)
        {
            try
            {
                int daysBeforeArchivingClosedWorkPermits = view.DaysBeforeArchivingClosedWorkPermits;
                int daysBeforeClosingIssuedWorkPermits = view.DaysBeforeClosingIssuedWorkPermits;
                int daysBeforeDeletingPendingWorkPermits = view.DaysBeforeDeletingPendingWorkPermits;

                view.ClearErrorMessages();

                bool shouldUpdate = ValidateValues(daysBeforeArchivingClosedWorkPermits, 
                                                   daysBeforeClosingIssuedWorkPermits, 
                                                   daysBeforeDeletingPendingWorkPermits);

                if (shouldUpdate)
                {
                    long siteId = ClientSession.GetUserContext().SiteId;
                    service.UpdateWorkPermitArchivalProcess(siteId,
                                                            daysBeforeArchivingClosedWorkPermits,
                                                            daysBeforeDeletingPendingWorkPermits,
                                                            daysBeforeClosingIssuedWorkPermits);
                    view.Close();
                }
                    
            }
            catch (Exception e)
            {
                view.SaveFailedMessage();
                logger.Error(StringResources.ServerSaveUpdateError, e);
            }
        }

        public void HandleCancelButtonClick(object sender, EventArgs args)
        {
            view.Close();
        }

        public static string CreateLockIdentifier(Site site)
        {
            return "WorkPermitArchivalProcess Form " + site.Id.Value;
        }

        public void FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!ClientSession.GetInstance().ForceLogoff && !shouldSkipConfirm && !view.ConfirmCancelDialog())
            {
                e.Cancel = true;
            }
        }

        private bool ValidateValues(int daysBeforeArchivingClosedWorkPermits,
                                    int daysBeforeClosingIssuedWorkPermits,
                                    int daysBeforeDeletingPendingWorkPermits)
        {
            bool shouldUpdate = true;

            if (daysBeforeArchivingClosedWorkPermits == 0)
            {
                shouldUpdate = false;
                view.ShowDaysBeforeArchivingClosedWorkPermitsError(StringResources.WorkPermitArchivalProcessDaysError);
            }

            if (daysBeforeClosingIssuedWorkPermits == 0)
            {
                shouldUpdate = false;
                view.ShowDaysBeforeClosingIssuedWorkPermitsError(StringResources.WorkPermitArchivalProcessDaysError);
            }

            if (daysBeforeDeletingPendingWorkPermits == 0)
            {
                shouldUpdate = false;
                view.ShowDaysBeforeDeletingPendingWorkPermitsError(StringResources.WorkPermitArchivalProcessDaysError);
            }

            return shouldUpdate;
        }
}
}
