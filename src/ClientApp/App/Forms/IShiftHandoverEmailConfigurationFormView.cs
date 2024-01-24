using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Common.Domain.ShiftHandover;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface IShiftHandoverEmailConfigurationFormView : IBaseForm
    {
        event Action AddButtonClicked;
        event Action EditButtonClicked;
        event Action DeleteButtonClicked;
        event Action CloseButtonClicked;

        List<ShiftHandoverEmailConfiguration> ShiftHandoverEmailConfigurations { set; }
        ShiftHandoverEmailConfiguration SelectedConfiguration { get; set; }

        DialogResult ConfirmDeleteDialog();
        void SelectFirstItem();
    }
}