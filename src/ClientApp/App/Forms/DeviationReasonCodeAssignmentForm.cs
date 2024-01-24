using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Presenters;
using Com.Suncor.Olt.Common.Domain.Restriction;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class DeviationReasonCodeAssignmentForm : BaseForm, IDeviationReasonCodeAssignmentView
    {
        private DeviationReasonCodeAssignmentPresenter presenter;

        private const string PositiveSign = "(+)";
        private const string NegativeSign = "(-)";

        public DeviationReasonCodeAssignmentForm(
            DeviationAlertResponseReasonCodeAssignment editObject, 
            DeviationAlert deviationAlert, 
            int amountRemainingToBeAllocated,
            RestrictionLocation restrictionLocation,
            RestrictionLocationItem lastSelectedLocationItem)
        {
            InitializeComponent();
            InitializePresenter(editObject, deviationAlert, amountRemainingToBeAllocated, restrictionLocation, lastSelectedLocationItem);


            restrictionReasonCodeComboBox.DisplayMember = RestrictionLocationItemReasonCodeAssociation.ComboBoxDisplayMember;
        }

        private void InitializePresenter(
            DeviationAlertResponseReasonCodeAssignment editObject, 
            DeviationAlert deviationAlert,
            int amountRemainingToBeAllocated,
            RestrictionLocation restrictionLocation,
            RestrictionLocationItem lastSelectedLocationItem)
        {
            presenter = new DeviationReasonCodeAssignmentPresenter(
                this, 
                deviationAlert, 
                editObject, 
                amountRemainingToBeAllocated,
                restrictionLocation,
                lastSelectedLocationItem);
            Load += presenter.HandleLoad;          

            okButton.Click += presenter.OkButton_Clicked;
            cancelButton.Click += presenter.CancelButton_Clicked;
            findNextButton.Click += presenter.FindNextButton_Clicked;
            findNextTextBox.KeyPress += searchTextBox_KeyPress;
            locationItemTreeView.AfterSelect += presenter.HandleLocationItemSelected;
        }

        private void searchTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (!string.IsNullOrEmpty(findNextTextBox.Text))
                {
                    presenter.FindNextButton_Clicked(null, EventArgs.Empty);
                    e.Handled = true;
                }
            }
        }

        public List<string> PlantStates
        {
            set
            {
                plantStateComboBox.Items.Clear();
                if (value != null)
                {
                    plantStateComboBox.Items.AddRange(value.ToArray());
                }
            }
        }

        public string SelectedPlantState
        {
            set { plantStateComboBox.SelectedItem = value; }
            get { return plantStateComboBox.SelectedItem as string; }
        }

        public string FindNextText { get { return findNextTextBox.Text; } }

        public RestrictionLocationItemReasonCodeAssociation SelectedReasonCodeAssociation
        {
            get { return restrictionReasonCodeComboBox.SelectedItem as RestrictionLocationItemReasonCodeAssociation; }
            set
            {
                int indexOf = restrictionReasonCodeComboBox.Items.IndexOf(value);
                if (indexOf != -1)
                {
                    restrictionReasonCodeComboBox.SelectedIndex = indexOf;
                }
            }
        }

        public void ClearReasonCodeAssociationSelection()
        {
            restrictionReasonCodeComboBox.SelectedIndex = -1;
        }

        public List<LocationItemTreeItem> LocationItems
        {
            set
            {
                locationItemTreeView.LoadItems(value);
            }
        }

        public LocationItemTreeItem SelectedLocationItem
        {
            get { return locationItemTreeView.SelectedItem; }
            set { locationItemTreeView.SelectedItem = value; }
        }

        public LocationItemTreeItem SelectItemAndExpand
        {
            set { locationItemTreeView.SelectItemAndExpand = value; }
        }

        public List<RestrictionLocationItemReasonCodeAssociation> RestrictionReasonCodes
        {
            set
            {
                restrictionReasonCodeComboBox.Items.Clear();
                if (value != null)
                {
                    restrictionReasonCodeComboBox.Items.AddRange(value.ToArray());
                }
            }
        }

        public string AssignedAmount
        {
            get { return amountToAllocateTextBox.Text; }
            set { amountToAllocateTextBox.Text = value; }
        }

        public string Comments
        {
            get { return commentsTextBox.Text; }
            set { commentsTextBox.Text = value; }
        }

        public string AmountRemainingToAllocate
        {
            get { return amountRemainingTextBox.Text; }
            set { amountRemainingTextBox.Text = value; }
        }

        public bool DeviationIsPositive
        {
            set
            {
                string signText = value ? PositiveSign : NegativeSign;
                amountRemainingSignLabel.Text = signText;
                amountToAssignSignLabel.Text = signText;                
            }
        }

        public void ClearErrors()
        {
            errorProvider.Clear();
        }

        public void SetErrorOnAssignedAmountField(string message)
        {            
            errorProvider.SetError(amountToAllocateTextBox, message);
        }

        public void SetErrorOnReasonCodeComboBox(string message)
        {
            errorProvider.SetError(restrictionReasonCodeComboBox, message);
        }

        public void SetErrorOnNoPlantStateSelected(string message)
        {
            errorProvider.SetError(plantStateComboBox, message);
        }

        public void DisableSelection()
        {
            SetEnabled(false);
        }

        public void EnableSelection()
        {
            SetEnabled(true);
        }

        private void SetEnabled(bool enabled)
        {
            plantStateComboBox.Enabled = enabled;
            restrictionReasonCodeComboBox.Enabled = enabled;
            amountToAllocateTextBox.Enabled = enabled;
            commentsTextBox.Enabled = enabled;
            okButton.Enabled = enabled;
        }

        public DeviationAlertResponseReasonCodeAssignment Assignment
        {
            get { return presenter.Assignment; }
        }

        public List<RestrictionLocationItem> GetFlatList()
        {
            return locationItemTreeView.GetFlatList();
        }       
    }
}
