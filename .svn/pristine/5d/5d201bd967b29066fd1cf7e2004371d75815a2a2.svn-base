using System;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Services;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class FlocLevelSettingForAdminPresenter : BaseFormPresenter<IAdminFlocLevelSiteConfigurationView>
    {
        private readonly ISiteConfigurationService siteConfigurationService;

        public FlocLevelSettingForAdminPresenter(IAdminFlocLevelSiteConfigurationView view) : base(view)
        {
            siteConfigurationService = ClientServiceRegistry.Instance.GetService<ISiteConfigurationService>();

            view.Load += HandleViewLoad;
            view.Save += HandleSave;
            
        }


        private void HandleSave()
        {
            siteConfigurationService.UPDATESiteConfigurationByAdministrator(Convert.ToInt64(ClientSession.GetUserContext().SiteId),view.ActionItemFlocLevel, view.ShiftLogFlocLevel, view.ShiftHandoverFlocLevel);
            view.Close();
        }

        private void HandleViewLoad(object sender, EventArgs e)
        {
            //ayman floc level from site configuration
            var siteConfigurationService = ClientServiceRegistry.Instance.GetService<ISiteConfigurationService>();
            var siteConfiguration = siteConfigurationService.QueryBySiteId(ClientSession.GetUserContext().SiteId);
            view.ActionItemFlocLevel = siteConfiguration.ActionItemFlocLevel;
            view.ShiftLogFlocLevel = siteConfiguration.ShiftLogFlocLevel;
            view.ShiftHandoverFlocLevel = siteConfiguration.ShiftHandoverFlocLevel;

        }


        public static string CreateLockIdentifier(Site site)
        {
            return String.Format("Administrator Floc level Site Configuration - {0}", site.IdValue);
        }
    }
}