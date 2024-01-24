using System.Collections.Generic;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Common.Domain;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface IShiftSelectionForm
    {
        ShiftPattern SelectedShiftPattern { set; get; }
        DomainListView<ShiftPattern> ShiftPatternListView { get; }
        int ListViewItemCount { get; }
        List<ShiftPattern> ShiftPatternToAddToListView { set; get; }
        bool SetNoShiftSelectedError { set; }
        bool SetSelectedShiftWasOutsideOfAllowedTimeRangeError { set; }
        void CloseForm();
        void SelectItem(DomainObject selected);
        bool ShiftWasSelected();
    }
}