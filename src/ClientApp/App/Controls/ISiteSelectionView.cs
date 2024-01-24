using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Client.Controls
{
    public interface ISiteSelectionView
    {
        List<Site> SiteToAddToListListView { set; }

        Site SelectedSite { get; }

        DialogResult ShowDialog();
        void CloseForm(DialogResult result);
        void LaunchUnSelectedSiteMessage();
    }
}
