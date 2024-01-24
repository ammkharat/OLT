using System;
using System.Collections.Generic;
using Com.Suncor.Olt.Client.Presenters;
using Com.Suncor.Olt.Common.Domain.Restriction;

namespace Com.Suncor.Olt.Client.Forms
{
    public interface IDeviationReasonCodeAssignmentView : IBaseForm
    {        
        List<RestrictionLocationItemReasonCodeAssociation> RestrictionReasonCodes { set; }
        RestrictionLocationItemReasonCodeAssociation SelectedReasonCodeAssociation { get; set; }
        string AssignedAmount { get; set; }
        string Comments { get; set; }
        string AmountRemainingToAllocate { get; set; }
        
        bool DeviationIsPositive { set;  }
        LocationItemTreeItem SelectedLocationItem { get; set; }
        LocationItemTreeItem SelectItemAndExpand { set; }
        List<LocationItemTreeItem> LocationItems { set; }
        List<string> PlantStates { set; }
        string SelectedPlantState { set; get; }
        string FindNextText { get; }
        List<RestrictionLocationItem> GetFlatList();

        void ClearErrors();
        void SetErrorOnAssignedAmountField(string message);
        void SetErrorOnReasonCodeComboBox(string message);
        void SetErrorOnNoPlantStateSelected(string message);
        void DisableSelection();
        void EnableSelection();
        void ClearReasonCodeAssociationSelection();        
    }
}