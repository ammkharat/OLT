using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Castle.Core.Internal;
using Com.Suncor.Olt.Client.Forms;
using Com.Suncor.Olt.Client.Services;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Restriction;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Services;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Client.Presenters
{
    public class DeviationReasonCodeAssignmentPresenter
    {
        private readonly IDeviationReasonCodeAssignmentView view;
        
        private readonly DeviationAlert deviationAlert;
        private DeviationAlertResponseReasonCodeAssignment assignment;
        private readonly bool isNewAssignmentMode;
        private readonly int amountRemainingToBeAllocated;
        private readonly RestrictionLocation restrictionLocation;
        private readonly RestrictionLocationItem lastSelectedLocationItem;

        private readonly IDropdownValueService dropdownValueService;

        public DeviationReasonCodeAssignmentPresenter(IDeviationReasonCodeAssignmentView view, 
            DeviationAlert deviationAlert,
            DeviationAlertResponseReasonCodeAssignment assignment,
            int amountRemainingToBeAllocated,
            RestrictionLocation restrictionLocation,
            RestrictionLocationItem lastSelectedLocationItem)
        {
            this.view = view;
            this.amountRemainingToBeAllocated = amountRemainingToBeAllocated;
            this.restrictionLocation = restrictionLocation;
            this.lastSelectedLocationItem = lastSelectedLocationItem;

            this.deviationAlert = deviationAlert;
            this.assignment = assignment;
            isNewAssignmentMode = assignment == null;

            dropdownValueService = ClientServiceRegistry.Instance.GetService<IDropdownValueService>();
        }

        private bool isLoading;

        public void HandleLoad(object sender, EventArgs e)
        {
            isLoading = true;
            SetLocationItemTree();
            List<DropdownValue> dropdownValues = dropdownValueService.QueryByKey(ClientSession.GetUserContext().SiteId, DeviationResponseDropDownValueKeys.PlantStateTypes);
            view.PlantStates = dropdownValues.ConvertAll(d => d.Value);

            SetAmountRemainingToAssignOnView(amountRemainingToBeAllocated);

            if (isNewAssignmentMode)
            {
                if (lastSelectedLocationItem != null)
                {
                    LocationItemTreeItem locationItem = new LocationItemTreeItem(lastSelectedLocationItem);
                    view.SelectedLocationItem = locationItem;
                    SetReasonCodesForLocationItem(locationItem);
                }
                else
                {
                    view.DisableSelection();                    
                }
                SetAssignedAmountOnView(amountRemainingToBeAllocated);
            }
            else
            {
                LocationItemTreeItem locationItem = new LocationItemTreeItem(assignment.RestrictionLocationItem);
                view.SelectedLocationItem = locationItem;
                SetReasonCodesForLocationItem(locationItem);

                RestrictionLocationItemReasonCodeAssociation selectedReasonCode = assignment.RestrictionLocationItem.ReasonCodes.Find(rc => rc.RestrictionReasonCodeId == assignment.RestrictionReasonCode.IdValue);
                view.SelectedReasonCodeAssociation = selectedReasonCode;

                view.SelectedPlantState = assignment.PlantState;
                view.Comments = assignment.Comments;

                SetAssignedAmountOnView(assignment.AssignedAmount);
            }
            isLoading = false;
        }

        private void SetReasonCodesForLocationItem(LocationItemTreeItem item)
        {
            List<RestrictionLocationItemReasonCodeAssociation> associations = item != null ? item.ReasonCodes : new List<RestrictionLocationItemReasonCodeAssociation>(0);
            view.RestrictionReasonCodes = associations;
        }

        private void SetLocationItemTree()
        {
            // make up a fake Root Node for each loading the tree, and easy adding later.
            LocationItemTreeItem rootTreeItem = LocationItemTreeItem.CreateFakeRoot(restrictionLocation.Name);

            List<LocationItemTreeItem> locationItems =
                restrictionLocation.LocationItems.ConvertAll(item => new LocationItemTreeItem(item));

            // Insert the root item at the beginning to make it quick to find later.
            locationItems.Insert(0, rootTreeItem);

            view.LocationItems = locationItems;
        }

        private void SetAssignedAmountOnView(int value)
        {
            view.DeviationIsPositive = value >= 0;
            view.AssignedAmount = GetAbsoluteValueString(value);            
        }

        private void SetAmountRemainingToAssignOnView(int value)
        {
            view.DeviationIsPositive = value >= 0;
            view.AmountRemainingToAllocate = GetAbsoluteValueString(value);
        }

        public void HandleLocationItemSelected(object sender, TreeViewEventArgs e)
        {
            if (isLoading)
                return;

            LocationItemTreeItem locationItemTreeItem = view.SelectedLocationItem;
            
            if (locationItemTreeItem.IsFakeRoot || !locationItemTreeItem.HasReasonCodes || locationItemTreeItem.FunctionalLocation == null)
            {
                // disable all the other stuff since we don't want a user selecting a node with no reason codes
                view.DisableSelection();
            }
            else
            {
                // get the currently selected ReasonCode in the drop-down. If the new List item doesn't contain it, then de-select it from the drop-down. Otherwise, leave it as is.
                RestrictionLocationItemReasonCodeAssociation selectedReasonCodeAssociation = view.SelectedReasonCodeAssociation;
                
                SetReasonCodesForLocationItem(locationItemTreeItem);

                if (selectedReasonCodeAssociation != null && locationItemTreeItem.ReasonCodes.Exists(assoc => assoc.RestrictionReasonCodeId == selectedReasonCodeAssociation.RestrictionReasonCodeId))
                {
                    RestrictionLocationItemReasonCodeAssociation assocToSelect = locationItemTreeItem.ReasonCodes.Find(assoc => assoc.RestrictionReasonCodeId == selectedReasonCodeAssociation.RestrictionReasonCodeId);
                    view.SelectedReasonCodeAssociation = assocToSelect;
                }
                else 
                {
                    view.ClearReasonCodeAssociationSelection();                    
                }

                view.EnableSelection();
            }
        }

        private int? AssignedAmount
        {
            get
            {
                int? result = RawAssignedAmountFromView;

                if (result == null)
                {
                    return result;
                }

                // the result should always be positive, because we validate for that.
                if (deviationAlert.DeviationValue < 0)
                {
                    result = result*-1;
                }

                return result;
            }
        }

        private int? RawAssignedAmountFromView
        {
            get
            {
                string amountString = view.AssignedAmount;
                int result;

                if (!Int32.TryParse(amountString, out result)) // This is probably redundant. The control shouldn't allow anything that doesn't parse
                {
                    return null;
                }

                return Convert.ToInt32(result);
            }
        }

        public void OkButton_Clicked(object sender, EventArgs e)
        {
            if(ValidationSucceeded())
            {
                RestrictionLocationItemReasonCodeAssociation association = view.SelectedReasonCodeAssociation;
                int assignedAmount = AssignedAmount.Value;
                string comments = view.Comments;
                User user = ClientSession.GetUserContext().User;

                RestrictionLocationItem restrictionLocationItem = view.SelectedLocationItem.RestrictionLocationItem;

                assignment = new DeviationAlertResponseReasonCodeAssignment(restrictionLocationItem,
                        association.RestrictionReasonCode, view.SelectedPlantState, assignedAmount, comments, user, Clock.Now, Clock.Now);
                
                view.DialogResult = DialogResult.OK;
            }
            else
            {
                return;
            }
        }

        public DeviationAlertResponseReasonCodeAssignment Assignment
        {
            get { return assignment; }
        }

        private bool ValidationSucceeded()
        {
            view.ClearErrors();

            int? assignedAmount = RawAssignedAmountFromView;

            bool validationSuccessful = true;

            if (assignedAmount == null)
            {
                view.SetErrorOnAssignedAmountField(StringResources.DeviationReasonCodeAssignment_NoAmountError);
                validationSuccessful = false;
            }
            else if (assignedAmount < 0)
            {
                view.SetErrorOnAssignedAmountField(StringResources.DeviationReasonCodeAssignment_AmountIsNegativeError);
                validationSuccessful = false;
            }

            RestrictionLocationItemReasonCodeAssociation selectedAssociation = view.SelectedReasonCodeAssociation;

            if (selectedAssociation == null)
            {
                view.SetErrorOnReasonCodeComboBox(StringResources.DeviationReasonCodeAssignment_NoReasonCodeSelectedError);
                validationSuccessful = false;
            }
            else
            {
                if (assignedAmount != null && selectedAssociation.Limit != null)
                {
                    int assignedAmountAbsoluteValue = Math.Abs(assignedAmount.Value);
                    int limit = selectedAssociation.Limit.Value;

                    if (assignedAmountAbsoluteValue > limit)
                    {
                        string message =
                            String.Format(
                                StringResources.DeviationReasonCodeAssignment_AmountEnteredGreaterThanLimitError,
                                limit);

                        view.SetErrorOnAssignedAmountField(message);
                        validationSuccessful = false;
                    }
                }
            }

            if (view.SelectedPlantState.IsNullOrEmpty())
            {
                view.SetErrorOnNoPlantStateSelected(StringResources.DeviationReasonCodeAssignment_NoPlantState);
                validationSuccessful = false;
            }

            return validationSuccessful;
        }

        public void CancelButton_Clicked(object sender, EventArgs e)
        {            
            view.Close();            
        }

        private string GetAbsoluteValueString(int value)
        {
            return Convert.ToString(Math.Abs(value));
        }
        
        private string mostRecentSearchTerm;
        private int mostRecentSearchIndex;
        private List<RestrictionLocationItem> searchList = null; 

        public void FindNextButton_Clicked(object sender, EventArgs e)
        {            
            string searchText = view.FindNextText;

            if (string.IsNullOrEmpty(searchText))
            {
                mostRecentSearchTerm = null;
                return;
            }

            if(searchList == null)
            {
                searchList = view.GetFlatList();
            }
           
            int resultIndex;
            
            if (searchText.Equals(mostRecentSearchTerm))
            {               
                mostRecentSearchIndex = (mostRecentSearchIndex + 1 > searchList.Count - 1) ? 0 : mostRecentSearchIndex + 1;
                resultIndex = searchList.FindIndex(mostRecentSearchIndex, item => item != null && item.Name.ToUpper().Contains(searchText.ToUpper()));
            }
            else
            {
                mostRecentSearchTerm = searchText;
                mostRecentSearchIndex = 0;
                resultIndex = searchList.FindIndex(mostRecentSearchIndex, item => item != null && item.Name.ToUpper().Contains(searchText.ToUpper()));
            }

            if (resultIndex != -1)
            {                
                RestrictionLocationItem foundItem = searchList[resultIndex];
                view.SelectItemAndExpand = new LocationItemTreeItem(foundItem);

                // This is so that the algorithm knows that if 
                int lastIndex = searchList.FindLastIndex(item => item != null && item.Name.ToUpper().Contains(searchText.ToUpper()));

                if (resultIndex == lastIndex)
                {
                    mostRecentSearchIndex = -1;
                }
                else
                {
                    mostRecentSearchIndex = resultIndex;    
                }                
            }
            else
            {
                mostRecentSearchIndex = -1; // because it will increment this back to 0
            }
        }
    }
}