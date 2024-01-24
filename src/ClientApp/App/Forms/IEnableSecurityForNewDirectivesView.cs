using System;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface IEnableSecurityForNewDirectivesView : IBaseForm
    {
        bool ContinueButtonEnabled { set; }
        bool AcceptChecked { get; }
        string SiteName { set; }
        event Action FormLoad;
        event Action AcceptCheckboxChanged;
        event Action ContinueClicked;
    }
}