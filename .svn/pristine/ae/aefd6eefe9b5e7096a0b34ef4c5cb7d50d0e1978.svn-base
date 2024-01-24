using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Services;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class SiteSelectionPresenter
    {
        private readonly ISiteSelectionView view;
        private readonly List<Site> siteList;
     
        public SiteSelectionPresenter(ISiteSelectionView view)
        {
            this.view = view;
            siteList = new List<Site>(ClientSession.GetUserContext().User.AvailableSites);
        }

        public void InitializeView(object sender, EventArgs e)
        {
            view.SiteToAddToListListView = siteList;
        }

        public void HandleAccept(object sender, EventArgs e)
        {
            Site selectedSite = view.SelectedSite;
            if (selectedSite == null)
            {
                view.LaunchUnSelectedSiteMessage();
            }
            else
            {
                UserContext userContext = ClientSession.GetUserContext();
                SiteConfiguration siteConfiguration =
                    ClientServiceRegistry.Instance.GetService<ISiteConfigurationService>().QueryBySiteId(
                        selectedSite.IdValue);
                userContext.SetSite(selectedSite, siteConfiguration);

                view.CloseForm(DialogResult.OK);
            }
        }

        public void HandleCancel(object sender, EventArgs e)
        {
            view.CloseForm(DialogResult.Cancel);
        }
    }
}
