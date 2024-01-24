using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Common.Domain.CokerCard;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface ICokerCardConfigurationSelectionView
    {
        DialogResult ShowDialog(IWin32Window form);
        CokerCardConfiguration SelectedCokerCardConfiguration { get; }
        List<CokerCardConfiguration> CokerCardConfigurationsToAddToListView { set; }
        void LaunchUnSelectedSiteMessage();
        void CloseForm(DialogResult ok);
    }
}