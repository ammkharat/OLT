
using System;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class ConfiguredDocumentLinkConfigurationFormPresenter : BaseFormPresenter<IConfiguredDocumentLinkConfigurationView>
    {
        public ConfiguredDocumentLinkConfigurationFormPresenter() : base(new ConfiguredDocumentLinkConfigurationForm())
        {
            SubscribeToEvents();
        }

        private void SubscribeToEvents()
        {
            view.Load += ViewOnLoad;
            view.EditButtonClicked += EditButtonClicked;
        }

        private void EditButtonClicked(ConfiguredDocumentLinkLocation configuredDocumentLinkLocation)
        {
            if (configuredDocumentLinkLocation != null)            //ayman USPipeline workpermit (not related really to workpermit for USpipeline but I found this as a bug and cause crash)
            {
                new EditConfiguredDocumentLinksFormPresenter(configuredDocumentLinkLocation).Run(view);
            }
        }

        private void ViewOnLoad(object sender, EventArgs eventArgs)
        {
            view.Locations = ConfiguredDocumentLinkLocation.AllLocationsForSite(ClientSession.GetUserContext().SiteId);
            view.SelectFirstRow();
        }

        public static string CreateLockIdentifier(Site site)
        {
            return string.Format("Configured Document Link Configuration Form - {0}", site.Id);
        }

    }

}
