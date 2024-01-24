using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface IConfigureSiteCommunicationsView : IBaseForm
    {
        event Action AddSiteCommunication;
        event Action EditSiteCommunication;
        event Action DeleteSiteCommunication;
        event Action SelectedSiteCommunicationChanged;

        List<SiteCommunication> SiteCommunications { set; }
        SiteCommunication SelectedSiteCommunication { get; set; }
        bool EditButtonEnabled { set; }
        bool DeleteButtonEnabled { set; }
        bool DeleteAllChecked { get; set; } //ayman site communication
        bool UserIsSureTheyWantToDelete();
        void SelectFirstValue();
    }
}
