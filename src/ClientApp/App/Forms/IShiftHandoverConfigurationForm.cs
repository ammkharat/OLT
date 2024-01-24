using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain.ShiftHandover;
using Com.Suncor.Olt.Common.DTO;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface IShiftHandoverConfigurationForm : IBaseForm
    {
        List<ShiftHandoverConfigurationDTO> ShiftHandoverConfigurationDTOs { set; }
        ShiftHandoverConfigurationDTO SelectedItem { get; }
        void LaunchEditShiftHandoverConfigurationForm(ShiftHandoverConfiguration selected);
        void SelectFirstRow();
        bool UserIsSure();
    }
}