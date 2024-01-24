using System.Collections.Generic;
using Com.Suncor.Olt.Client.Controls.GridRenderer;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface IShiftHandoverEmailConfigurationAddEditFormView : IAddEditBaseFormView
    {
        List<WorkAssignmentMultiSelectGridRenderer.DisplayAdapter> Assignments { get; set; }        
        List<ShiftPattern> Shifts { set; }

        ShiftPattern SelectedShift { get; set; }
        Time Time { get; set; }
        string EmailAddressList { get; set; }        

        void SetNoShiftSelectedError();
        void SetEmailAddressListError();
        void SetNoWorkAssignmentSelectedError();
    }
}
