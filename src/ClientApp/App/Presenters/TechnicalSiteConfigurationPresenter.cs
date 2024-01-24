using System;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Services;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class TechnicalSiteConfigurationPresenter : BaseFormPresenter<ITechnicalSiteConfigurationView>
    {
        private readonly ISiteConfigurationService siteConfigurationService;

        public TechnicalSiteConfigurationPresenter(ITechnicalSiteConfigurationView view) : base(view)
        {
            siteConfigurationService = ClientServiceRegistry.Instance.GetService<ISiteConfigurationService>();

            view.Load += HandleViewLoad;
            view.Save += HandleSave;
        }

        private void HandleSave()
        {
            SiteConfiguration siteConfiguration = view.SiteConfiguration;
            siteConfigurationService.Update(siteConfiguration);
            view.Close();
        }

        private void HandleViewLoad(object sender, EventArgs eventArgs)
        {
            SiteConfiguration siteConfiguration = siteConfigurationService.QueryBySiteIdWithNoCaching(ClientSession.GetUserContext().SiteId);

            view.SiteConfiguration = siteConfiguration;
        }

        public static string CreateLockIdentifier(Site site)
        {
            return String.Format("Technical Site Configuration - {0}", site.IdValue);
        }
    }
}
