using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface IWorkPermitDropdownsConfigurationView : IBaseForm
    {
        List<WorkPermitDropdown> Dropdowns { set; }
        WorkPermitDropdown SelectedItem { get; }
        void SelectFirstRow();
        void Disable();
        void Enable();
        void LaunchEditForm(List<DropdownValue> workPermitDropdownValues, string key);
    }
}
