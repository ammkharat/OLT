using System.Collections.Generic;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface IEditWorkPermitDropdownsConfigurationForm : IBaseForm
    {
        List<DropdownValue> DropdownValues { set; }
        string DropdownName { set; }
        DropdownValue SelectedValue { get; set; }
        void SelectFirstValue();
        void ClearErrors();
        void SetAtLeastOneValueRequiredError();
        bool UserIsSure();
        void Disable();
        void Enable();
        DropdownValue LaunchAddEditValueForm(WorkPermitDropdown dropdown, DropdownValue editObject);
    }
}
