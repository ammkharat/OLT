using System;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface ISwitchFromLogBasedDirectivesView : IBaseForm
    {
        event Action FormLoad;
        event Action AcceptCheckboxChanged;
        event Action ContinueClicked;

        bool ContinueButtonEnabled { set; }
        bool AcceptChecked { get; }
        string SiteName { set; }
    }
}