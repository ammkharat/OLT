using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface IFormDropdownsConfigurationView : IBaseForm
    {
        List<FormDropdown> Dropdowns { set; }
        FormDropdown SelectedItem { get; }
        void SelectFirstRow();
        void Disable();
        void Enable();
        void LaunchEditForm(List<DropdownValue> formDropdownValues, string key, string nameAlreadyExistsErrorMessage);
    }
}