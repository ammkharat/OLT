using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Client.Presenters;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class PermitRequestMontrealForm : BaseForm, IPermitRequestMontrealFormView
    {
        private readonly IMultiSelectFunctionalLocationSelectionForm functionalLocationSelectorForm;

        public event EventHandler SaveButtonClicked;
        public event EventHandler CancelButtonClicked;
        public event Action ViewEditHistoryButtonClicked;
        public event Action FunctionalLocationButtonClicked;
        public event Action SubmitAndCloseButtonClicked;

        public PermitRequestMontrealForm()
        {
            InitializeComponent();

            functionalLocationSelectorForm = new MultiSelectFunctionalLocationSelectionForm(
                FunctionalLocationMode.GetLevelThreeAndBelow(ClientSession.GetUserContext().SiteConfiguration),
                new FunctionalLocationIsSelectedByUserFilter(FunctionalLocationType.Level3),
                true);

            saveAndCloseButton.Click += SaveAndCloseButton_Click;
            cancelButton.Click += CancelButton_Click;
            viewEditHistoryButton.Click += ViewEditHistoryButton_Click;
            functionalLocationButton.Click += FunctionalLocationButton_Click;
            submitAndCloseButton.Click += SubmitAndCloseButton_Click;

            permitAttributesControl.AutoScroll = false;
        }

        private void SaveAndCloseButton_Click(object sender, EventArgs e)
        {
            if (SaveButtonClicked != null)
            {
                SaveButtonClicked(sender, e);
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            if (CancelButtonClicked != null)
            {
                CancelButtonClicked(sender, e);
            }
        }

        private void ViewEditHistoryButton_Click(object sender, EventArgs e)
        {
            if (ViewEditHistoryButtonClicked != null)
            {
                ViewEditHistoryButtonClicked();
            }
        }

        private void FunctionalLocationButton_Click(object sender, EventArgs e)
        {
            if (FunctionalLocationButtonClicked != null)
            {
                FunctionalLocationButtonClicked();
            }
        }

        private void SubmitAndCloseButton_Click(object sender, EventArgs e)
        {
            if (SubmitAndCloseButtonClicked != null)
            {
                SubmitAndCloseButtonClicked();
            }
        }

        public DateTime LastModifiedDateTime
        {
            set { lastModifiedDateAuthorHeader.LastModifiedDate = value; }
        }

        public User LastModifiedBy
        {
            set { lastModifiedDateAuthorHeader.LastModifiedUser = value; }
        }

        public WorkPermitMontrealType WorkPermitType
        {
            get { return (WorkPermitMontrealType)permitTypeComboBox.SelectedItem; }
            set { permitTypeComboBox.SelectedItem = value; }
        }

        public List<FunctionalLocation> FunctionalLocations
        {
            get { return functionalLocationTextBox.Tag as List<FunctionalLocation>; }
            set
            {
                if (value != null)
                {
                    string flocString = value.FullHierarchyListToString(false, false);
                    functionalLocationTextBox.TextWithEllipsis = flocString;
                    toolTip.SetToolTip(functionalLocationTextBox, flocString);
                    functionalLocationTextBox.Tag = new List<FunctionalLocation>(value);
                }
                else
                {
                    toolTip.RemoveAll();
                    functionalLocationTextBox.Text = string.Empty;
                    functionalLocationTextBox.Tag = value;
                }
            }
        }

        public List<DocumentLink> DocumentLinks
        {
            get { return documentLinksControl.DataSource as List<DocumentLink>; }
            set { documentLinksControl.DataSource = value; }
        }

        public Date StartDate
        {
            get { return startDatePicker.Value; }
            set { startDatePicker.Value = value; }
        }

        public Date EndDate
        {
            get { return endDatePicker.Value; }
            set { endDatePicker.Value = value; }
        }

        public string Trade
        {
            get { return tradeComboBox.Text.Trim(); }
            set { tradeComboBox.Text = value; }
        }

        public WorkPermitMontrealGroup RequestedByGroup
        {
            get { return (WorkPermitMontrealGroup) requestedByComboBox.SelectedItem; }
            set { requestedByComboBox.SelectedItem = value; }
        }

        public string WorkOrderNumber
        {
            get { return workOrderNumberTextBox.Text.Trim(); }
            set { workOrderNumberTextBox.Text = value; }
        }

        public string OperationNumber
        {
            get { return operationNumberTextBox.Text.Trim(); }
            set { operationNumberTextBox.Text = value; }
        }

        public string Description
        {
            get { return descriptionTextBox.Text.Trim(); }
            set { descriptionTextBox.Text = value; }
        }
        
        public string SapDescription
        {
            set { sapDescriptionTextBox.Text = value; }
        }

        public bool SapDescriptionVisible
        {
            set { sapGroupBox.Visible = value; }
        }

        public string Company
        {
            get { return companyComboBox.Text.EmptyToNull(); }
            set { companyComboBox.Text = value; }
        }

        public string Supervisor
        {
            get { return supervisorTextBox.Text.EmptyToNull(); }
            set { supervisorTextBox.Text = value; }
        }

        public string ExcavationNumber
        {
            get { return excavationNumberTextBox.Text.Trim(); }
            set { excavationNumberTextBox.Text = value; }
        }

        public List<PermitAttribute> SelectedAttributes
        {
            get { return permitAttributesControl.SelectedAttributes;}
            set { permitAttributesControl.SelectedAttributes = value; }
        }

        public void ClearErrorProviders()
        {
            errorProvider.Clear();
        }

        public void ShowNoWorkPermitTypeSelectedError()
        {
            errorProvider.SetError(permitTypeComboBox, StringResources.WorkPermit_PermitType_Not_Selected);
        }

        public void ShowNoFunctionalLocationsSelectedError()
        {
            errorProvider.SetError(functionalLocationTextBox, StringResources.FieldEmptyError);
        }

        public void ShowStartDateMustBeBeforeEndDateError()
        {
            errorProvider.SetError(startDatePicker, StringResources.StartDateBeforeEndDate);
        }

        public void ShowEndDateMustBeOnOrAfterTodayError()
        {
            errorProvider.SetError(endDatePicker, StringResources.DateCannotBeInThePast);
        }

        public void ShowTradeIsEmptyError()
        {
            errorProvider.SetError(tradeComboBox, StringResources.MontrealWorkPermit_Trade_Not_Selected);
        }

        public void ShowDescriptionIsEmptyError()
        {
            errorProvider.SetError(descriptionTextBox, StringResources.DescriptionEmptyError);
        }

        public void ShowNoRequestedByGroupSelectedError()
        {
            errorProvider.SetError(requestedByComboBox, StringResources.WorkPermit_GroupEmpty);
        }

        public List<WorkPermitMontrealType> AllPermitTypes
        {
            set
            {
                permitTypeComboBox.DataSource = value;
                permitTypeComboBox.DisplayMember = "Name";
            }
        }

        public List<CraftOrTrade> AllCraftOrTrades
        {
            set
            {
                tradeComboBox.DataSource = value;
                tradeComboBox.DisplayMember = "Name";
            }
        }

        public List<Contractor> AllCompanies
        {
            set
            {
                companyComboBox.DataSource = value;
                companyComboBox.DisplayMember = "CompanyName";
            }
        }

        public List<WorkPermitMontrealGroup> AllRequestedByGroups
        {
            set
            {
                requestedByComboBox.DataSource = value;
                requestedByComboBox.DisplayMember = "Name";
            }
        }

        public List<PermitAttribute> AllAttributes
        {
            set { permitAttributesControl.AllAttributes = value; }
        }

        public List<FunctionalLocation> ShowFunctionalLocationSelector(List<FunctionalLocation> selectedFlocs)
        {
            DialogResult result = functionalLocationSelectorForm.ShowDialog(this, selectedFlocs);
            return result == DialogResult.OK ? new List<FunctionalLocation>(functionalLocationSelectorForm.UserSelectedFunctionalLocations) : null;
        }

        public bool ViewEditHistoryEnabled
        {
            set { viewEditHistoryButton.Enabled = value; }
        }

        public bool WorkOrderNumberEnabled
        {
            set { workOrderNumberTextBox.ReadOnly = !value; }
        }

        public bool OperationNumberEnabled
        {
            set { operationNumberTextBox.ReadOnly = !value; }
        }

       
    }
}