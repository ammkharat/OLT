using System.Collections.Generic;
using Com.Suncor.Olt.Common.DTO;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface IManageOpModeForUnitLevelFLOCView
    {
        string Site { set; }
        List<FunctionalLocationOperationalModeDTO> Items { set; }

        FunctionalLocationOperationalModeDTO SelectedItem { get; }

        FunctionalLocationOperationalModeDTO OpenEditOperationalModeDialog(
            FunctionalLocationOperationalModeDTO selectedItem);

        void CloseForm();
        void DisplayOKDialog(string message);
    }
}