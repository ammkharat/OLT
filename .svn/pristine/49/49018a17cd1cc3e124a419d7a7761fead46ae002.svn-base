using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Client.Controls.Page
{
    // Multi grid todo: This should probably be renamed. It's turning into the main non-generic interface. Or, a side interface could maybe be created for the stuff below under the "Moved from IDomainPage" label.
    public interface IItemSelectablePage : IPage, IHasPageKey
    {        
        string TabText { get; }
        Type PageDtoType { get; }

        bool CanSelectItemFromAnotherPage { get; }
        bool IsItemSelected();
        void SelectSingleItemById(long? id);
        void ClearSelectionsAndSelectItemsById(List<long> ids);
        void SelectSingleItemByIndex(int index);
        bool ContainsItemById(long? id);

        IMainForm MainParentForm { get; }
        
        DialogResultAndOutput<Range<Date>> DisplayDateRangeDialog();
        bool ShowOKCancelDialog(string dialogText, string title);
        void DeleteSuccessfulMessage();
        List<DomainObject> SelectedDTOs { get; }
        void LoadGridLayout(string xml);
    }
}