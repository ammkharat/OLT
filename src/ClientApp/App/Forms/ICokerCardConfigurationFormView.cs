using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.CokerCard;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface ICokerCardConfigurationFormView : IBaseForm
    {
        List<CokerCardConfiguration> CokerCardConfigurations { set; }
        CokerCardConfiguration SelectedItem { get; }
        void LaunchEditConfigurationForm(CokerCardConfiguration cokerCardConfiguration);
        void SelectFirstRow();
        bool UserIsSure();
    }
}