using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Client.Presenters;
using Com.Suncor.Olt.Client.Utilities;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class PermitRequestEdmontonForm : BaseForm, IPermitRequestEdmontonFormView
    {
        private SingleSelectFunctionalLocationSelectionForm functionalLocationSelectorForm;

        public event EventHandler SaveButtonClicked;
        public event EventHandler CancelButtonClicked;
        public event Action ViewEditHistoryButtonClicked;
        public event Action FunctionalLocationButtonClicked;
        public event Action SubmitAndCloseButtonClicked;
        public event Action ValidateButtonClicked;
        public event Action SelectFormGN1ButtonClicked;
        public event Action SelectFormGN6ButtonClicked;
        public event Action SelectFormGN7ButtonClicked;
        public event Action SelectFormGN59ButtonClicked;
        public event Action SelectFormGN24ButtonClicked;
        public event Action SelectFormGN75AButtonClicked;
        public event Action FormGN1CheckBoxCheckChanged;

        public PermitRequestEdmontonForm()
        {
            InitializeComponent();
            issuedToContractorCheckBox.CheckedChanged += HandleIssuedToContractorCheckedChanged;

            otherAreasAffectedNoRadioButton.CheckedChanged += HandleOtherAreasAffectedRadioButtonCheckChanged;

            saveAndCloseButton.Click += HandleSaveAndCloseButtonClick;
            cancelButton.Click += HandleCancelButtonClick;
            viewEditHistoryButton.Click += HandleViewEditHistoryButtonClick;
            functionalLocationBrowseButton.Click += HandleFunctionalLocationButtonClick;
            submitAndCloseButton.Click += HandleSubmitAndCloseButtonClick;
            validateButton.Click += HandleValidateButtonClick;
            selectFormGN1Button.Click += HandleSelectFormGN1ButtonClick;
            selectFormGN6Button.Click += HandleSelectFormGN6ButtonClick;
            selectFormGN7Button.Click += HandleSelectFormGN7ButtonClick;
            selectFormGN59Button.Click += HandleSelectFormGN59ButtonClick;
            selectFormGN24Button.Click += HandleSelectFormGN24ButtonClick;
            selectFormGN75AButton.Click += HandleSelectFormGN75AButtonClick;

            gn1CheckBox.CheckedChanged += HandleGN1CheckBoxChanged;

            alkylationEntryCheckBox.CheckedChanged += PermitFormHelper.CheckBoxCheckChanged;
            flarePitEntryCheckBox.CheckedChanged += PermitFormHelper.CheckBoxCheckChanged;
            confinedSpaceCheckBox.CheckedChanged += HandleConfinedSpaceCheckBoxChanged;
            confinedSpaceClassComboBox.SelectedValueChanged += HandleConfinedSpaceClassChanged;
            rescuePlanCheckBox.CheckedChanged += PermitFormHelper.CheckBoxCheckChanged;
            vehicleEntryCheckBox.CheckedChanged += PermitFormHelper.CheckBoxCheckChanged;
            specialWorkCheckBox.CheckedChanged += PermitFormHelper.CheckBoxCheckChanged;
            roadAccessOnPermitCheckBox.CheckedChanged += PermitFormHelper.CheckBoxCheckChanged;

            workersMonitorNumberCheckBox.CheckedChanged += PermitFormHelper.CheckBoxCheckChanged;
            radioChannelNumberCheckBox.CheckedChanged += PermitFormHelper.CheckBoxCheckChanged;
            other1CheckBox.CheckedChanged += PermitFormHelper.CheckBoxCheckChanged;
            other2CheckBox.CheckedChanged += PermitFormHelper.CheckBoxCheckChanged;
            other3CheckBox.CheckedChanged += PermitFormHelper.CheckBoxCheckChanged;
            other4CheckBox.CheckedChanged += PermitFormHelper.CheckBoxCheckChanged;

            PermitFormHelper.SetupSectionNotApplicableToJob(
                workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox,
                workersMinimumSafetyRequirementsGroupBox);

            permitTypeComboBox.SelectedValueChanged += HandlePermitTypeSelectedValueChanged;
            groupComboBox.SelectedValueChanged += HandlePermitTypeSelectedValueChanged;

            requestedStartDayCheckBox.CheckedChanged += HandleRequestedStartDayCheckBoxCheckedChanged;
            requestedStartNightCheckBox.CheckedChanged += HandleRequestedStartNightCheckBoxCheckedChanged;

            Disposed += HandleDisposed;
        }

        private void HandleGN1CheckBoxChanged(object sender, EventArgs e)
        {
            FormGN1CheckBoxCheckChanged();
        }

        public bool ConfinedSpaceCheckBoxEnabled
        {
            set { confinedSpaceCheckBox.Enabled = value; }
        }

        public bool RescuePlanCheckBoxEnabled
        {
            set { rescuePlanCheckBox.Enabled = value; }
        }

        private void HandleDisposed(object sender, EventArgs eventArgs)
        {
            if (functionalLocationSelectorForm != null)
            {
                functionalLocationSelectorForm.Dispose();
            }
        }

        public void PopulateFunctionalLocationSelector(List<FunctionalLocation> functionalLocations)
        {
            functionalLocationSelectorForm = new SingleSelectFunctionalLocationSelectionForm(
                FunctionalLocationMode.GetLevelTwoAndBelow(ClientSession.GetUserContext().SiteConfiguration),
                new FunctionalLocationIsSelectedByUserFilter(FunctionalLocationType.Level2, functionalLocations));
        }

        private void HandleRequestedStartDayCheckBoxCheckedChanged(object sender, EventArgs e)
        {
            requestedStartTimeDayPicker.Enabled = requestedStartDayCheckBox.Checked;
        }

        private void HandleRequestedStartNightCheckBoxCheckedChanged(object sender, EventArgs e)
        {
            requestedStartTimeNightPicker.Enabled = requestedStartNightCheckBox.Checked;
        }

        public bool RequestedStartDayTimeCheckboxChecked
        {
            set { requestedStartDayCheckBox.Checked = value; }
        }

        public bool RequestedStartNightTimeCheckboxChecked
        {
            set { requestedStartNightCheckBox.Checked = value; }
        }

        public bool RequestedStartTimeNightPickerEnabled
        {
            set { requestedStartTimeNightPicker.Enabled = value; }
        }

        public bool RequestedStartTimeDayPickerEnabled
        {
            set { requestedStartTimeDayPicker.Enabled = value; }
        }

        public List<AreaLabel> AreaLabels
        {
            set
            {
                areaLabelComboBox.DisplayMember = "Name";
                areaLabelComboBox.ValueMember = "Id";
                areaLabelComboBox.DataSource = value;
            }
        }

        public AreaLabel AreaLabel
        {
            get { return (AreaLabel) areaLabelComboBox.SelectedItem; }
            set { areaLabelComboBox.SelectedItem = value; }
        }

        public List<DocumentLink> DocumentLinks
        {
            get { return documentLinksControl.DataSource as List<DocumentLink>; }
            set { documentLinksControl.DataSource = value; }
        }

        //public void ResetDocumentLinks()
        //{
        //    documentLinksControl.DataSource.
        //}

        public List<Priority> Priorities
        {
            set { priorityComboBox.DataSource = value; }
        }

        public Priority Priority
        {
            get { return (Priority) priorityComboBox.SelectedItem; }
            set { priorityComboBox.SelectedItem = value; }
        }

        private void HandlePermitTypeSelectedValueChanged(object sender, EventArgs e)
        {
            PermitFormHelper.HandlePermitTypeSelectedValueChanged(permitTypeComboBox, gn59CheckBox,
                gn59FormNumberTextBox, groupComboBox);
        }

        public List<string> AlkylationEntryClassOfClothingSelectionList
        {
            set { classOfClothingComboBox.DataSource = value; }
        }

        public List<string> FlarePitEntryTypeSelectionList
        {
            set { flarePitEntryTypeComboBox.DataSource = value; }
        }

        public List<string> ConfinedSpaceClassSelectionList
        {
            set { confinedSpaceClassComboBox.DataSource = value; }
        }

        public List<EdmontonPermitSpecialWorkType> SpecialWorkTypeSelectionList
        {
            set
            {
                specialWorkTypeComboBox.DataSource = value;
                specialWorkTypeComboBox.DisplayMember = EdmontonPermitSpecialWorkType.DisplayMemberField;
            }
        }

        public List<SpecialWork> AllSpecialWorkType
        {
            set
            {
                specialWorkComboBox.DataSource = value;
                specialWorkComboBox.DisplayMember = "CompanyName";
            }
            get { return (List<SpecialWork>)specialWorkComboBox.DataSource; }
        }

        //mangesh for SpecialWork
        public string SpecialWorkName
        {
            //get { return specialWorkComboBox.Text; }
            //set { specialWorkComboBox.Text = value; }
            get { return PermitFormHelper.GetTextComboBoxValue(specialWorkComboBox, specialWorkCheckBox); }
            set { PermitFormHelper.SetTextComboBoxValue(value, specialWorkComboBox, specialWorkCheckBox); }
        }

        //mangesh for SpecialWork
        public SpecialWork specialworktype
        {
            get { return specialWorkComboBox.SelectedItem as SpecialWork; }
            set
            {
                specialWorkComboBox.SelectedItem = specialWorkCheckBox.Checked == true ? value : null;
            }
        }
       

        private void HandleConfinedSpaceCheckBoxChanged(object sender, EventArgs e)
        {
            PermitFormHelper.CheckBoxCheckChanged(sender, e);

            HandleConfinedSpaceClassChanged(null, null);
                // because enabling/disabling the checkbox is essentially like changing the class
        }

        public void ApplyConfinedSpaceClassFormRules()
        {
            var confinedSpaceCheckBoxIsChecked = confinedSpaceCheckBox.Checked;
            var confinedSpaceClass = ConfinedSpaceClass;

            if (confinedSpaceCheckBoxIsChecked &&
                (WorkPermitEdmonton.ConfinedSpaceLevel1.Equals(confinedSpaceClass) ||
                 WorkPermitEdmonton.ConfinedSpaceLevel2.Equals(confinedSpaceClass)))
            {
                rescuePlanCheckBox.Checked = true;
                rescuePlanCheckBox.Enabled = false;
            }
            else if (confinedSpaceCheckBoxIsChecked && WorkPermitEdmonton.ConfinedSpaceLevel3.Equals(confinedSpaceClass))
            {
                rescuePlanCheckBox.Enabled = false;
                rescuePlanCheckBox.Checked = false;
                RescuePlanFormNumber = null;
            }
            else
            {
                if (confinedSpaceClass != null)
                {
                    rescuePlanCheckBox.Checked = false;
                }
                rescuePlanCheckBox.Enabled = true;
            }
        }

        private void HandleConfinedSpaceClassChanged(object sender, EventArgs e)
        {
            ApplyConfinedSpaceClassFormRules();
        }

        private void HandleOtherAreasAffectedRadioButtonCheckChanged(object sender, EventArgs e)
        {
            if (OtherAreasAndOrUnitsAffected)
            {
                AreaAffectedEnabled = true;
                PersonNotifiedEnabled = true;
            }
            else
            {
                AreaAffectedEnabled = false;
                PersonNotifiedEnabled = false;
            }
        }

        private void HandleIssuedToContractorCheckedChanged(object sender, EventArgs e)
        {
            contractorComboBox.Enabled = issuedToContractorCheckBox.Checked;
        }

        private void HandleSaveAndCloseButtonClick(object sender, EventArgs e)
        {
            if (SaveButtonClicked != null)
            {
                SaveButtonClicked(sender, e);
            }
        }

        private void HandleCancelButtonClick(object sender, EventArgs e)
        {
            if (CancelButtonClicked != null)
            {
                CancelButtonClicked(sender, e);
            }
        }

        private void HandleViewEditHistoryButtonClick(object sender, EventArgs e)
        {
            if (ViewEditHistoryButtonClicked != null)
            {
                ViewEditHistoryButtonClicked();
            }
        }

        private void HandleFunctionalLocationButtonClick(object sender, EventArgs e)
        {
            if (FunctionalLocationButtonClicked != null)
            {
                FunctionalLocationButtonClicked();
            }
        }

        private void HandleSubmitAndCloseButtonClick(object sender, EventArgs e)
        {
            if (SubmitAndCloseButtonClicked != null)
            {
                SubmitAndCloseButtonClicked();
            }
        }

        private void HandleValidateButtonClick(object sender, EventArgs e)
        {
            if (ValidateButtonClicked != null)
            {
                ValidateButtonClicked();
            }
        }

        private void HandleSelectFormGN1ButtonClick(object sender, EventArgs e)
        {
            if (SelectFormGN1ButtonClicked != null)
            {
                SelectFormGN1ButtonClicked();
            }
        }

        private void HandleSelectFormGN6ButtonClick(object sender, EventArgs e)
        {
            if (SelectFormGN6ButtonClicked != null)
            {
                SelectFormGN6ButtonClicked();
            }
        }

        private void HandleSelectFormGN7ButtonClick(object sender, EventArgs e)
        {
            if (SelectFormGN7ButtonClicked != null)
            {
                SelectFormGN7ButtonClicked();
            }
        }

        private void HandleSelectFormGN59ButtonClick(object sender, EventArgs e)
        {
            if (SelectFormGN59ButtonClicked != null)
            {
                SelectFormGN59ButtonClicked();
            }
        }

        private void HandleSelectFormGN24ButtonClick(object sender, EventArgs e)
        {
            if (SelectFormGN24ButtonClicked != null)
            {
                SelectFormGN24ButtonClicked();
            }
        }

        private void HandleSelectFormGN75AButtonClick(object sender, EventArgs e)
        {
            if (SelectFormGN75AButtonClicked != null)
            {
                SelectFormGN75AButtonClicked();
            }
        }

        public void SetOtherAreasAndOrUnitsAffected(string area, string personNotified)
        {
            PermitFormHelper.SetOtherAreasAndOrUnitsAffected(area, personNotified,
                otherAreasAffectedNoRadioButton, otherAreasAffectedYesRadioButton, areaComboBox, personNotifiedTextBox);
        }

        public DateTime LastModifiedDateTime
        {
            set { lastModifiedDateAuthorHeader.LastModifiedDate = value; }
        }

        public User LastModifiedBy
        {
            set { lastModifiedDateAuthorHeader.LastModifiedUser = value; }
        }

        public bool IssuedToSuncor
        {
            get { return issuedToSuncorCheckBox.Checked; }
            set { issuedToSuncorCheckBox.Checked = value; }
        }

        public bool IssuedToContractor
        {
            get { return issuedToContractorCheckBox.Checked; }
        }

        public string Company
        {
            get { return PermitFormHelper.GetTextComboBoxValue(contractorComboBox, issuedToContractorCheckBox); }
            set { PermitFormHelper.SetTextComboBoxValue(value, contractorComboBox, issuedToContractorCheckBox); }
        }

        public string Occupation
        {
            get { return occupationComboBox.Text; }
            set { occupationComboBox.Text = value; }
        }

        public int? NumberOfWorkers
        {
            get { return numberOfWorkersTextBox.IntegerValue; }
            set { numberOfWorkersTextBox.IntegerValue = value; }
        }

        public WorkPermitEdmontonGroup Group
        {
            get { return (WorkPermitEdmontonGroup) groupComboBox.SelectedItem; }
            set { groupComboBox.SelectedItem = value; }
        }

        public WorkPermitEdmontonType WorkPermitType
        {
            get { return (WorkPermitEdmontonType) permitTypeComboBox.SelectedItem; }
            set { permitTypeComboBox.SelectedItem = value; }
        }

        public FunctionalLocation FunctionalLocation
        {
            get { return functionalLocationTextBox.Tag as FunctionalLocation; }
            set
            {
                if (value != null)
                {
                    functionalLocationTextBox.Text = value.FullHierarchyWithDescription;
                    functionalLocationTextBox.Tag = value;
                }
                else
                {
                    functionalLocationTextBox.Text = string.Empty;
                    functionalLocationTextBox.Tag = null;
                }
            }
        }

        public string Location
        {
            get { return locationTextBox.Text.EmptyToNull(); }
            set { locationTextBox.Text = value; }
        }

        public Date RequestedStartDate
        {
            get { return requestedStartDatePicker.Value; }
            set { requestedStartDatePicker.Value = value; }
        }

        public Date RequestedEndDate
        {
            get { return requestedEndDatePicker.Value; }
            set { requestedEndDatePicker.Value = value; }
        }

        public Time RequestedStartTimeDay
        {
            get { return PermitFormHelper.GetTimePickerValue(requestedStartTimeDayPicker, requestedStartDayCheckBox); }
            set
            {
                PermitFormHelper.SetTimePickerValue(value, WorkPermitEdmonton.PermitDefaultDayStart,
                    requestedStartTimeDayPicker, requestedStartDayCheckBox);
            }
        }

        public Time RequestedStartTimeNight
        {
            get
            {
                return PermitFormHelper.GetTimePickerValue(requestedStartTimeNightPicker, requestedStartNightCheckBox);
            }
            set
            {
                PermitFormHelper.SetTimePickerValue(value, WorkPermitEdmonton.PermitDefaultNightStart,
                    requestedStartTimeNightPicker, requestedStartNightCheckBox);
            }
        }

        public string WorkOrderNumber
        {
            get { return workOrderNumberTextBox.Text.EmptyToNull(); }
            set { workOrderNumberTextBox.Text = value; }
        }

        public string OperationNumber
        {
            get { return operationNumberTextBox.Text.EmptyToNull(); }
            set
            {
                operationNumberTextBox.Text = value;
                toolTip.SetToolTip(operationNumberTextBox, value);
            }
        }

        public string SubOperationNumber
        {
            get { return subOperationNumberTextBox.Text.EmptyToNull(); }
            set
            {
                subOperationNumberTextBox.Text = value;
                toolTip.SetToolTip(subOperationNumberTextBox, value);
            }
        }

        public string Description
        {
            get { return descriptionTextBox.Text.EmptyToNull(); }
            set { descriptionTextBox.Text = value; }
        }

        public string SapDescription
        {
            get { return sapDescriptionTextBox.Text.EmptyToNull(); }
            set { sapDescriptionTextBox.Text = value; }
        }

        public bool SapDescriptionVisible
        {
            set { currentSAPDescriptionGroupBox.Visible = value; }
        }

        public string HazardsAndOrRequirements
        {
            get { return hazardsAndOrRequirementsTextBox.Text.EmptyToNull(); }
            set { hazardsAndOrRequirementsTextBox.Text = value; }
        }

        public bool OtherAreasAndOrUnitsAffected
        {
            get { return otherAreasAffectedYesRadioButton.Checked; }
        }

        public string OtherAreasAndOrUnitsAffectedArea
        {
            get
            {
                if (OtherAreasAndOrUnitsAffected)
                {
                    return areaComboBox.Text.EmptyToNull();
                }

                return null;
            }
        }

        public string OtherAreasAndOrUnitsAffectedPersonNotified
        {
            get
            {
                if (OtherAreasAndOrUnitsAffected)
                {
                    return personNotifiedTextBox.Text.EmptyToNull();
                }
                return null;
            }
        }

        public bool AreaAffectedEnabled
        {
            set { areaComboBox.Enabled = value; }
        }

        public bool PersonNotifiedEnabled
        {
            set { personNotifiedTextBox.Enabled = value; }
        }

        public void ClearErrorProviders()
        {
            errorProvider.Clear();
            warningProvider.Clear();
        }

        public List<WorkPermitEdmontonType> AllPermitTypes
        {
            set
            {
                permitTypeComboBox.DataSource = value;
                permitTypeComboBox.DisplayMember = "Name";
            }
        }

        public List<string> AllAffectedAreas
        {
            set { areaComboBox.DataSource = value; }
        }

        public List<CraftOrTrade> AllCraftOrTrades
        {
            set
            {
                occupationComboBox.DataSource = value;
                occupationComboBox.DisplayMember = "ListDisplayText";
            }
        }

        public List<CraftOrTrade> AllRoadAccessOnPermitType
        {
            set
            {
                roadAccessOnPermitComboBox.DataSource = value;
                roadAccessOnPermitComboBox.DisplayMember = "ListDisplayText";
            }
        }

        public List<Contractor> AllCompanies
        {
            set
            {
                contractorComboBox.DataSource = value;
                contractorComboBox.DisplayMember = "CompanyName";
            }
        }

        public List<WorkPermitEdmontonGroup> AllGroups
        {
            set { groupComboBox.DataSource = value; }
        }

        public FunctionalLocation ShowFunctionalLocationSelector()
        {
            var result = functionalLocationSelectorForm.ShowDialog(this);
            return result == DialogResult.OK ? functionalLocationSelectorForm.SelectedFunctionalLocation : null;
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

        public bool SubOperationNumberEnabled
        {
            set { subOperationNumberTextBox.ReadOnly = !value; }
        }

        public void ShowSaveAndCloseMessageForErrors()
        {
            var message = StringResources.PermitRequestEdmonton_Validation_ErrorsOnlyMessage;
            var title = StringResources.PermitRequestEdmonton_IncompletePermitRequest;

            OltMessageBox.Show(this, message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public DialogResult ShowSaveAndCloseMessageForWarnings_NonTurnaroundCase()
        {
            var message = StringResources.PermitRequestEdmonton_SaveAndClose_WarningsOnlyMessage_NonTurnaround;
            var title = StringResources.PermitRequestEdmonton_IncompletePermitRequest;

            return OltMessageBox.Show(this, message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        }

        public DialogResult ShowSaveAndCloseMessageForWarnings_TurnaroundCase()
        {
            var message = StringResources.PermitRequestEdmonton_SaveAndClose_WarningsOnlyMessage_Turnaround;
            var title = StringResources.PermitRequestEdmonton_IncompletePermitRequest;

            return OltMessageBox.Show(this, message, title, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        }

        public void ShowSaveAndCloseMessageForWarningsAndErrors_NonTurnaroundCase()
        {
            var message = StringResources.PermitRequestEdmonton_Validation_WarningsAndErrorsMessage_NonTurnaround;
            var title = StringResources.PermitRequestEdmonton_IncompletePermitRequest;

            OltMessageBox.Show(this, message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void ShowSaveAndCloseMessageForWarningsAndErrors_TurnaroundCase()
        {
            var message = StringResources.PermitRequestEdmonton_Validation_WarningsAndErrorsMessage_Turnaround;
            var title = StringResources.PermitRequestEdmonton_IncompletePermitRequest;

            OltMessageBox.Show(this, message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void ShowSubmitAndCloseMessageForErrors()
        {
            ShowSubmitAndCloseMessageBox(StringResources.PermitRequestEdmonton_Validation_ErrorsOnlyMessage);
        }

        public void ShowSubmitAndCloseMessageForWarnings()
        {
            ShowSubmitAndCloseMessageBox(StringResources.PermitRequestEdmonton_SubmitAndClose_WarningsOnlyMessage);
        }

        public void ShowSubmitAndCloseMessageForWarningsAndErrors_NonTurnaroundCase()
        {
            ShowSubmitAndCloseMessageBox(
                StringResources.PermitRequestEdmonton_Validation_WarningsAndErrorsMessage_NonTurnaround);
        }

        public void ShowSubmitAndCloseMessageForWarningsAndErrors_TurnaroundCase()
        {
            ShowSubmitAndCloseMessageBox(
                StringResources.PermitRequestEdmonton_Validation_WarningsAndErrorsMessage_Turnaround);
        }

        public void ShowValidationMessageForTurnaroundWarnings()
        {
            ShowSubmitAndCloseMessageBox(StringResources.PermitRequestEdmonton_Validation_WarningsOnlyMessage_Turnaround);
        }

        private void ShowSubmitAndCloseMessageBox(string message)
        {
            var title = StringResources.PermitRequestEdmonton_IncompletePermitRequest;
            OltMessageBox.Show(this, message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void ShowIsValidMessageBox()
        {
            var title = StringResources.PermitRequestEdmonton_Validation_IsValidTitle;
            var message = StringResources.PermitRequestEdmonton_Validation_IsValid;
            OltMessageBox.Show(this, message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #region Type of Work Section

        public bool AlkylationEntryClassOfClothingEnabled
        {
            set { classOfClothingComboBox.Enabled = value; }
        }

        public bool FlarePitEntryTypeEnabled
        {
            set { flarePitEntryTypeComboBox.Enabled = value; }
        }

        public bool ConfinedSpaceClassEnabled
        {
            set { confinedSpaceClassComboBox.Enabled = value; }
        }

        public bool ConfinedSpaceCardNumberEnabled
        {
            set { confinedSpaceCardNumberTextBox.ReadOnly = !value; }
        }

        public bool RescuePlanFormNumberEnabled
        {
            set { rescuePlanFormNumberTextBox.ReadOnly = !value; }
        }

        public bool VehicleEntryTotalEnabled
        {
            set { vehicleEntryTotalNumberTextBox.ReadOnly = !value; }
        }

        public bool VehicleEntryTypeEnabled
        {
            set { vehicleEntryTypeTextBox.ReadOnly = !value; }
        }

        public bool SpecialWorkTypeEnabled
        {
            //set { specialWorkTypeComboBox.Enabled = value; }
            set { specialWorkComboBox.Enabled = value; }
        }

        public bool SpecialWorkFormNumberEnabled
        {
            set { specialWorkFormNumberTextBox.ReadOnly = !value; }
        }

        public bool AlkylationEntry
        {
            get { return alkylationEntryCheckBox.Checked; }
            set { alkylationEntryCheckBox.Checked = value; }
        }

        public string AlkylationEntryClassOfClothing
        {
            get { return PermitFormHelper.GetTextComboBoxValue(classOfClothingComboBox, alkylationEntryCheckBox); }
            set { PermitFormHelper.SetTextComboBoxValue(value, classOfClothingComboBox, alkylationEntryCheckBox); }
        }

        public bool FlarePitEntry
        {
            get { return flarePitEntryCheckBox.Checked; }
            set { flarePitEntryCheckBox.Checked = value; }
        }

        public string FlarePitEntryType
        {
            get { return PermitFormHelper.GetTextComboBoxValue(flarePitEntryTypeComboBox, flarePitEntryCheckBox); }
            set { PermitFormHelper.SetTextComboBoxValue(value, flarePitEntryTypeComboBox, flarePitEntryCheckBox); }
        }

        public bool ConfinedSpace
        {
            get { return confinedSpaceCheckBox.Checked; }
            set { confinedSpaceCheckBox.Checked = value; }
        }

        public string ConfinedSpaceCardNumber
        {
            get { return PermitFormHelper.GetTextBoxValue(confinedSpaceCardNumberTextBox, confinedSpaceCheckBox); }
            set { PermitFormHelper.SetTextBoxValue(value, confinedSpaceCardNumberTextBox, confinedSpaceCheckBox); }
        }

        public string ConfinedSpaceClass
        {
            get { return PermitFormHelper.GetTextComboBoxValue(confinedSpaceClassComboBox, confinedSpaceCheckBox); }
            set { PermitFormHelper.SetTextComboBoxValue(value, confinedSpaceClassComboBox, confinedSpaceCheckBox); }
        }

        public bool RescuePlan
        {
            get { return rescuePlanCheckBox.Checked; }
            set { rescuePlanCheckBox.Checked = value; }
        }

        public string RescuePlanFormNumber
        {
            get { return PermitFormHelper.GetTextBoxValue(rescuePlanFormNumberTextBox, rescuePlanCheckBox); }
            set { PermitFormHelper.SetTextBoxValue(value, rescuePlanFormNumberTextBox, rescuePlanCheckBox); }
        }

        public bool VehicleEntry
        {
            get { return vehicleEntryCheckBox.Checked; }
            set { vehicleEntryCheckBox.Checked = value; }
        }

        public int? VehicleEntryTotal
        {
            get
            {
                return PermitFormHelper.GetIntegerTextBoxValue(vehicleEntryTotalNumberTextBox, vehicleEntryCheckBox);
            }
            set
            {
                PermitFormHelper.SetIntegerTextBoxValue(value, vehicleEntryTotalNumberTextBox, vehicleEntryCheckBox);
            }
        }

        public string VehicleEntryType
        {
            get { return PermitFormHelper.GetTextBoxValue(vehicleEntryTypeTextBox, vehicleEntryCheckBox); }
            set { PermitFormHelper.SetTextBoxValue(value, vehicleEntryTypeTextBox, vehicleEntryCheckBox); }
        }

        public bool SpecialWork
        {
            get { return specialWorkCheckBox.Checked; }
            set { specialWorkCheckBox.Checked = value; }
        }

        public string SpecialWorkFormNumber
        {
            get { return PermitFormHelper.GetTextBoxValue(specialWorkFormNumberTextBox, specialWorkCheckBox); }
            set { PermitFormHelper.SetTextBoxValue(value, specialWorkFormNumberTextBox, specialWorkCheckBox); }
        }

        public EdmontonPermitSpecialWorkType SpecialWorkType
        {
            get
            {
                return PermitFormHelper.GetSpecialWorkTypeComboBoxValue(specialWorkTypeComboBox, specialWorkCheckBox);
            }
            set
            {
                PermitFormHelper.SetSpecialWorkTypeComboBoxValue(value, specialWorkTypeComboBox, specialWorkCheckBox);
            }
        }

        public bool RoadAccessOnPermit
        {
            get { return roadAccessOnPermitCheckBox.Checked; }
            set
            {
                roadAccessOnPermitCheckBox.Checked = value;
            }
        }
        public string RoadAccessOnPermitFormNumber
        {
            get { return PermitFormHelper.GetTextBoxValue(roadAccessOnPermitFormNumberTextBox, roadAccessOnPermitCheckBox); }
            set { PermitFormHelper.SetTextBoxValue(value, roadAccessOnPermitFormNumberTextBox, roadAccessOnPermitCheckBox); }
        }

        public string RoadAccessOnPermitType
        {
            get { return roadAccessOnPermitComboBox.Text; }
            set { roadAccessOnPermitComboBox.Text = value; }
        }

        public bool GN59
        {
            get { return gn59CheckBox.Checked; }
            set { gn59CheckBox.Checked = value; }
        }

        public FormGN59 FormGN59
        {
            get
            {
                var textBoxValue = PermitFormHelper.GetTextBoxValue(gn59FormNumberTextBox, gn59CheckBox);
                if (textBoxValue == null)
                {
                    return null;
                }

                return (FormGN59) gn59FormNumberTextBox.Tag;
            }
            set
            {
                PermitFormHelper.SetTextBoxValue(value == null ? null : value.Id.ToString(), gn59FormNumberTextBox,
                    gn59CheckBox);
                gn59FormNumberTextBox.Tag = value;
            }
        }

        public bool GN59CheckBoxEnabled
        {
            set { gn59CheckBox.Enabled = value; }
        }

        public bool GN6
        {
            get { return gn6CheckBox.Checked; }
            set { gn6CheckBox.Checked = value; }
        }

        public FormGN6 FormGN6
        {
            get
            {
                var textBoxValue = PermitFormHelper.GetTextBoxValue(gn6FormNumberTextBox, gn6CheckBox);
                if (textBoxValue == null)
                {
                    return null;
                }

                return (FormGN6) gn6FormNumberTextBox.Tag;
            }
            set
            {
                PermitFormHelper.SetTextBoxValue(value == null ? null : value.Id.ToString(), gn6FormNumberTextBox,
                    gn6CheckBox);
                gn6FormNumberTextBox.Tag = value;
            }
        }

        public bool GN7
        {
            get { return gn7CheckBox.Checked; }
            set { gn7CheckBox.Checked = value; }
        }

        public FormGN7 FormGN7
        {
            get
            {
                var textBoxValue = PermitFormHelper.GetTextBoxValue(gn7FormNumberTextBox, gn7CheckBox);
                if (textBoxValue == null)
                {
                    return null;
                }

                return (FormGN7) gn7FormNumberTextBox.Tag;
            }
            set
            {
                PermitFormHelper.SetTextBoxValue(value == null ? null : value.Id.ToString(), gn7FormNumberTextBox,
                    gn7CheckBox);
                gn7FormNumberTextBox.Tag = value;
            }
        }

        public bool GN24
        {
            get { return gn24CheckBox.Checked; }
            set { gn24CheckBox.Checked = value; }
        }

        public FormGN24 FormGN24
        {
            get
            {
                var textBoxValue = PermitFormHelper.GetTextBoxValue(gn24FormNumberTextBox, gn24CheckBox);
                if (textBoxValue == null)
                {
                    return null;
                }

                return (FormGN24) gn24FormNumberTextBox.Tag;
            }
            set
            {
                PermitFormHelper.SetTextBoxValue(value == null ? null : value.Id.ToString(), gn24FormNumberTextBox,
                    gn24CheckBox);
                gn24FormNumberTextBox.Tag = value;
            }
        }

        public bool GN75A
        {
            get { return gn75ACheckBox.Checked; }
            set { gn75ACheckBox.Checked = value; }
        }

        public FormGN75A FormGN75A
        {
            get
            {
                var textBoxValue = PermitFormHelper.GetTextBoxValue(gn75AFormNumberTextBox, gn75ACheckBox);
                if (textBoxValue == null)
                {
                    return null;
                }

                return (FormGN75A) gn75AFormNumberTextBox.Tag;
            }
            set
            {
                PermitFormHelper.SetTextBoxValue(value == null ? null : value.Id.ToString(), gn75AFormNumberTextBox,
                    gn75ACheckBox);
                gn75AFormNumberTextBox.Tag = value;
            }
        }

        public bool GN1
        {
            get { return gn1CheckBox.Checked; }
            set { gn1CheckBox.Checked = value; }
        }

        public FormGN1 FormGN1
        {
            get
            {
                var textBoxValue = PermitFormHelper.GetTextBoxValue(gn1FormNumberTextBox, gn1CheckBox);
                if (textBoxValue == null)
                {
                    return null;
                }

                return (FormGN1) gn1FormNumberTextBox.Tag;
            }
            set { gn1FormNumberTextBox.Tag = value; }
        }

        public string FormGN1TradeChecklistNumber
        {
            get { return PermitFormHelper.GetTextBoxValue(gn1FormNumberTextBox, gn1CheckBox); }
            set { PermitFormHelper.SetTextBoxValue(value, gn1FormNumberTextBox, gn1CheckBox); }
        }

        public long? FormGN1TradeChecklistId { get; set; }

        public WorkPermitSafetyFormState GN11
        {
            get { return (WorkPermitSafetyFormState) gn11ComboBox.SelectedItem; }
            set { gn11ComboBox.SelectedItem = value; }
        }

        public WorkPermitSafetyFormState GN27
        {
            get { return (WorkPermitSafetyFormState) gn27ComboBox.SelectedItem; }
            set { gn27ComboBox.SelectedItem = value; }
        }

        public List<WorkPermitSafetyFormState> GN11Values
        {
            set { gn11ComboBox.DataSource = value; }
        }

        public List<WorkPermitSafetyFormState> GN27Values
        {
            set { gn27ComboBox.DataSource = value; }
        }

        #endregion

        #region Workers Minimum Safety Requirements

        public bool WorkersMinimumSafetyRequirementsSectionNotApplicableToJob
        {
            get { return workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox.Checked; }
            set { workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox.Checked = value; }
        }

        public bool FaceShield
        {
            get
            {
                return PermitFormHelper.GetCheckBoxValueForSection(faceShieldCheckBox,
                    workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox);
            }
            set
            {
                PermitFormHelper.SetCheckBoxValueForSection(value, faceShieldCheckBox,
                    workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox);
            }
        }

        public bool Goggles
        {
            get
            {
                return PermitFormHelper.GetCheckBoxValueForSection(gogglesCheckBox,
                    workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox);
            }
            set
            {
                PermitFormHelper.SetCheckBoxValueForSection(value, gogglesCheckBox,
                    workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox);
            }
        }

        public bool RubberBoots
        {
            get
            {
                return PermitFormHelper.GetCheckBoxValueForSection(rubberBootsCheckBox,
                    workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox);
            }
            set
            {
                PermitFormHelper.SetCheckBoxValueForSection(value, rubberBootsCheckBox,
                    workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox);
            }
        }

        public bool RubberGloves
        {
            get
            {
                return PermitFormHelper.GetCheckBoxValueForSection(rubberGlovesCheckBox,
                    workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox);
            }
            set
            {
                PermitFormHelper.SetCheckBoxValueForSection(value, rubberGlovesCheckBox,
                    workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox);
            }
        }

        public bool RubberSuit
        {
            get
            {
                return PermitFormHelper.GetCheckBoxValueForSection(rubberSuitCheckBox,
                    workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox);
            }
            set
            {
                PermitFormHelper.SetCheckBoxValueForSection(value, rubberSuitCheckBox,
                    workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox);
            }
        }

        public bool SafetyHarnessLifeline
        {
            get
            {
                return PermitFormHelper.GetCheckBoxValueForSection(safetyHarnessLifelineCheckBox,
                    workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox);
            }
            set
            {
                PermitFormHelper.SetCheckBoxValueForSection(value, safetyHarnessLifelineCheckBox,
                    workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox);
            }
        }

        public bool HighVoltagePPE
        {
            get
            {
                return PermitFormHelper.GetCheckBoxValueForSection(highVoltagePPECheckBox,
                    workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox);
            }
            set
            {
                PermitFormHelper.SetCheckBoxValueForSection(value, highVoltagePPECheckBox,
                    workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox);
            }
        }

        public bool Other1
        {
            get
            {
                return PermitFormHelper.GetCheckBoxValueForSection(other1CheckBox,
                    workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox);
            }
            set { }
        }

        public String Other1Value
        {
            get
            {
                return PermitFormHelper.GetTextBoxValueForSection(other1TextBox, other1CheckBox,
                    workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox);
            }
            set
            {
                PermitFormHelper.SetTextBoxValueForSection(value, other1TextBox, other1CheckBox,
                    workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox);
            }
        }

        public bool EquipmentGrounded
        {
            get
            {
                return PermitFormHelper.GetCheckBoxValueForSection(equipmentGroundedCheckBox,
                    workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox);
            }
            set
            {
                PermitFormHelper.SetCheckBoxValueForSection(value, equipmentGroundedCheckBox,
                    workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox);
            }
        }

        public bool FireBlanket
        {
            get
            {
                return PermitFormHelper.GetCheckBoxValueForSection(fireBlanketCheckBox,
                    workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox);
            }
            set
            {
                PermitFormHelper.SetCheckBoxValueForSection(value, fireBlanketCheckBox,
                    workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox);
            }
        }

        public bool FireExtinguisher
        {
            get
            {
                return PermitFormHelper.GetCheckBoxValueForSection(fireExtinguisherCheckBox,
                    workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox);
            }
            set
            {
                PermitFormHelper.SetCheckBoxValueForSection(value, fireExtinguisherCheckBox,
                    workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox);
            }
        }

        public bool FireMonitorManned
        {
            get
            {
                return PermitFormHelper.GetCheckBoxValueForSection(fireMonitorMannedCheckBox,
                    workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox);
            }
            set
            {
                PermitFormHelper.SetCheckBoxValueForSection(value, fireMonitorMannedCheckBox,
                    workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox);
            }
        }

        public bool FireWatch
        {
            get
            {
                return PermitFormHelper.GetCheckBoxValueForSection(fireWatchCheckBox,
                    workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox);
            }
            set
            {
                PermitFormHelper.SetCheckBoxValueForSection(value, fireWatchCheckBox,
                    workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox);
            }
        }

        public bool SewersDrainsCovered
        {
            get
            {
                return PermitFormHelper.GetCheckBoxValueForSection(sewersDrainsCoveredCheckBox,
                    workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox);
            }
            set
            {
                PermitFormHelper.SetCheckBoxValueForSection(value, sewersDrainsCoveredCheckBox,
                    workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox);
            }
        }

        public bool SteamHose
        {
            get
            {
                return PermitFormHelper.GetCheckBoxValueForSection(steamHoseCheckBox,
                    workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox);
            }
            set
            {
                PermitFormHelper.SetCheckBoxValueForSection(value, steamHoseCheckBox,
                    workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox);
            }
        }

        public bool Other2
        {
            get
            {
                return PermitFormHelper.GetCheckBoxValueForSection(other2CheckBox,
                    workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox);
            }
            set { }
        }

        public String Other2Value
        {
            get
            {
                return PermitFormHelper.GetTextBoxValueForSection(other2TextBox, other2CheckBox,
                    workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox);
            }
            set
            {
                PermitFormHelper.SetTextBoxValueForSection(value, other2TextBox, other2CheckBox,
                    workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox);
            }
        }

        public bool AirPurifyingRespirator
        {
            get
            {
                return PermitFormHelper.GetCheckBoxValueForSection(airPurifyingRespiratorCheckBox,
                    workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox);
            }
            set
            {
                PermitFormHelper.SetCheckBoxValueForSection(value, airPurifyingRespiratorCheckBox,
                    workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox);
            }
        }

        public bool BreathingAirApparatus
        {
            get
            {
                return PermitFormHelper.GetCheckBoxValueForSection(breathingAirApparatusCheckBox,
                    workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox);
            }
            set
            {
                PermitFormHelper.SetCheckBoxValueForSection(value, breathingAirApparatusCheckBox,
                    workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox);
            }
        }

        public bool DustMask
        {
            get
            {
                return PermitFormHelper.GetCheckBoxValueForSection(dustMaskCheckBox,
                    workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox);
            }
            set
            {
                PermitFormHelper.SetCheckBoxValueForSection(value, dustMaskCheckBox,
                    workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox);
            }
        }

        public bool LifeSupportSystem
        {
            get
            {
                return PermitFormHelper.GetCheckBoxValueForSection(lifeSupportSystemCheckBox,
                    workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox);
            }
            set
            {
                PermitFormHelper.SetCheckBoxValueForSection(value, lifeSupportSystemCheckBox,
                    workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox);
            }
        }

        public bool SafetyWatch
        {
            get
            {
                return PermitFormHelper.GetCheckBoxValueForSection(safetyWatchCheckBox,
                    workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox);
            }
            set
            {
                PermitFormHelper.SetCheckBoxValueForSection(value, safetyWatchCheckBox,
                    workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox);
            }
        }

        public bool ContinuousGasMonitor
        {
            get
            {
                return PermitFormHelper.GetCheckBoxValueForSection(continuousGasMonitorCheckBox,
                    workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox);
            }
            set
            {
                PermitFormHelper.SetCheckBoxValueForSection(value, continuousGasMonitorCheckBox,
                    workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox);
            }
        }

        public bool WorkersMonitor
        {
            get
            {
                return PermitFormHelper.GetCheckBoxValueForSection(workersMonitorNumberCheckBox,
                    workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox);
            }
            set
            {
                PermitFormHelper.SetCheckBoxValueForSection(value, workersMonitorNumberCheckBox,
                    workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox);
            }
        }

        public string WorkersMonitorNumber
        {
            get
            {
                return PermitFormHelper.GetTextBoxValueForSection(workersMonitorNumberTextBox,
                    workersMonitorNumberCheckBox, workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox);
            }
            set
            {
                PermitFormHelper.SetTextBoxValueForSection(value, workersMonitorNumberTextBox,
                    workersMonitorNumberCheckBox, workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox);
            }
        }

        public bool BumpTestMonitorPriorToUse
        {
            get
            {
                return PermitFormHelper.GetCheckBoxValueForSection(bumpTestMonitorPriorToUseCheckBox,
                    workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox);
            }
            set
            {
                PermitFormHelper.SetCheckBoxValueForSection(value, bumpTestMonitorPriorToUseCheckBox,
                    workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox);
            }
        }

        public bool Other3
        {
            get
            {
                return PermitFormHelper.GetCheckBoxValueForSection(other3CheckBox,
                    workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox);
            }
            set { }
        }

        public String Other3Value
        {
            get
            {
                return PermitFormHelper.GetTextBoxValueForSection(other3TextBox, other3CheckBox,
                    workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox);
            }
            set
            {
                PermitFormHelper.SetTextBoxValueForSection(value, other3TextBox, other3CheckBox,
                    workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox);
            }
        }

        public bool AirMover
        {
            get
            {
                return PermitFormHelper.GetCheckBoxValueForSection(airMoverCheckBox,
                    workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox);
            }
            set
            {
                PermitFormHelper.SetCheckBoxValueForSection(value, airMoverCheckBox,
                    workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox);
            }
        }

        public bool BarriersSigns
        {
            get
            {
                return PermitFormHelper.GetCheckBoxValueForSection(barriersSignsCheckBox,
                    workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox);
            }
            set
            {
                PermitFormHelper.SetCheckBoxValueForSection(value, barriersSignsCheckBox,
                    workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox);
            }
        }

        public bool RadioChannel
        {
            get
            {
                return PermitFormHelper.GetCheckBoxValueForSection(radioChannelNumberCheckBox,
                    workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox);
            }
            set
            {
                PermitFormHelper.SetCheckBoxValueForSection(value, radioChannelNumberCheckBox,
                    workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox);
            }
        }

        public string RadioChannelNumber
        {
            get
            {
                return PermitFormHelper.GetTextBoxValueForSection(radioChannelNumberTextBox, radioChannelNumberCheckBox,
                    workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox);
            }
            set
            {
                PermitFormHelper.SetTextBoxValueForSection(value, radioChannelNumberTextBox, radioChannelNumberCheckBox,
                    workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox);
            }
        }

        public bool AirHorn
        {
            get
            {
                return PermitFormHelper.GetCheckBoxValueForSection(airHornCheckBox,
                    workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox);
            }
            set
            {
                PermitFormHelper.SetCheckBoxValueForSection(value, airHornCheckBox,
                    workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox);
            }
        }

        public bool MechVentilationComfortOnly
        {
            get
            {
                return PermitFormHelper.GetCheckBoxValueForSection(mechVentilationComfortOnlyCheckBox,
                    workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox);
            }
            set
            {
                PermitFormHelper.SetCheckBoxValueForSection(value, mechVentilationComfortOnlyCheckBox,
                    workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox);
            }
        }

        public bool AsbestosMMCPrecautions
        {
            get
            {
                return PermitFormHelper.GetCheckBoxValueForSection(asbestosMmfPrecautionsCheckBox,
                    workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox);
            }
            set
            {
                PermitFormHelper.SetCheckBoxValueForSection(value, asbestosMmfPrecautionsCheckBox,
                    workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox);
            }
        }

        public bool Other4
        {
            get
            {
                return PermitFormHelper.GetCheckBoxValueForSection(other4CheckBox,
                    workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox);
            }
            set { }
        }

        public String Other4Value
        {
            get
            {
                return PermitFormHelper.GetTextBoxValueForSection(other4TextBox, other4CheckBox,
                    workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox);
            }
            set
            {
                PermitFormHelper.SetTextBoxValueForSection(value, other4TextBox, other4CheckBox,
                    workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox);
            }
        }

        #endregion

        #region Error Setters

        public void SetErrorForEndDateMustBeOnOrAfterToday()
        {
            errorProvider.SetError(requestedStartDatePicker, "ESWPTODO");
        }

        public void SetErrorForNoStartTime()
        {
            errorProvider.SetError(requestedStartTimeDayPicker, StringResources.WorkPermitEdmonton_NoStartTime);
        }

        public void SetErrorForNoFunctionalLocation()
        {
            errorProvider.SetError(functionalLocationBrowseButton, StringResources.FlocEmptyError);
        }

        public void SetErrorForNoPermitType()
        {
            errorProvider.SetError(permitTypeComboBox, StringResources.WorkPermit_PermitType_Not_Selected);
        }

        public void SetErrorForNoDescription()
        {
            errorProvider.SetError(descriptionTextBox, StringResources.WorkPermit_Description_Empty);
        }

        //mangesh - for numeric field
        public void SetErrorForNoAlphaNumeric(string name)
        {
            //errorProvider.SetError(descriptionTextBox, StringResources.WorkPermit_OnlyNumeric);
        }

        public void SetErrorForNoContractor()
        {
            errorProvider.SetError(contractorComboBox, StringResources.WorkPermitEdmonton_ContractorEmpty);
        }

        public void SetErrorForNumberOfWorkersLessThanOrEqualToZero()
        {
            errorProvider.SetError(numberOfWorkersTextBox,
                StringResources.WorkPermitEdmonton_NumberOfWorkersIsLessThanOrEqualtoZero);
        }

        public void SetErrorForNoAreaAffected()
        {
            errorProvider.SetError(areaComboBox, StringResources.WorkPermitEdmonton_AreaAffectedEmpty);
        }

        public void SetErrorForNoPersonNotified()
        {
            errorProvider.SetError(personNotifiedTextBox, StringResources.WorkPermitEdmonton_PersonNotifiedEmpty);
        }

        public void SetErrorForStartDateTimeNotBeforeEndDateTime()
        {
            errorProvider.SetError(requestedEndDatePicker, StringResources.EndDateBeforeStartDate);
        }

        public void SetErrorForNoOccupation()
        {
            errorProvider.SetError(occupationComboBox, StringResources.WorkPermitEdmonton_OccupationEmpty);
        }

        public void SetErrorForNoGroup()
        {
            errorProvider.SetError(groupComboBox, StringResources.WorkPermit_GroupEmpty);
        }

        public void SetErrorForNoLocation()
        {
            errorProvider.SetError(locationTextBox, StringResources.WorkPermit_LocationEmpty);
        }

        public void SetErrorForNoClassOfClothing()
        {
            errorProvider.SetError(classOfClothingComboBox, StringResources.WorkPermit_FieldEmptyButChecked);
        }

        public void SetErrorForNoFlarePitEntryType()
        {
            errorProvider.SetError(flarePitEntryTypeComboBox, StringResources.WorkPermit_FieldEmptyButChecked);
        }


        public void SetErrorForNoConfinedSpaceCardNumber(string message)
        {
            warningProvider.SetError(confinedSpaceCardNumberTextBox, message);
        }

        public void SetErrorForNoConfinedSpaceClass(string message)
        {
            warningProvider.SetError(confinedSpaceClassComboBox, message);
        }

        public void SetErrorForNoRescuePlanFormNumber(string message)
        {
            warningProvider.SetError(rescuePlanFormNumberTextBox, message);
        }

        public void SetErrorForNoVehicleEntryTotalNumber()
        {
            warningProvider.SetError(vehicleEntryTotalNumberTextBox, StringResources.WorkPermit_FieldEmptyButChecked);
        }

        public void SetErrorForNoVehicleEntryType()
        {
            warningProvider.SetError(vehicleEntryTypeTextBox, StringResources.WorkPermit_FieldEmptyButChecked);
        }

        public void SetErrorForNoSpecialWorkFormNumber()
        {
            warningProvider.SetError(specialWorkFormNumberTextBox, StringResources.WorkPermit_FieldEmptyButChecked);
        }

        public void SetErrorForNoSpecialWorkType()
        {
            //warningProvider.SetError(specialWorkTypeComboBox, StringResources.WorkPermit_FieldEmptyButChecked);
            warningProvider.SetError(specialWorkComboBox, StringResources.WorkPermit_FieldEmptyButChecked);
        }

        public void SetErrorForNoRoadAccessOnPermitFormNumber()
        {
            warningProvider.SetError(roadAccessOnPermitFormNumberTextBox, StringResources.WorkPermit_FieldEmptyButChecked);
        }
        public void SetErrorForNoRoadAccessOnPermit()
        {
            warningProvider.SetError(roadAccessOnPermitComboBox, StringResources.WorkPermit_FieldEmptyButChecked);
        }


        public void SetErrorForNoApprovedGN59Form(string message)
        {
            warningProvider.SetError(selectFormGN59Button, message);
        }

        public void SetErrorForNoApprovedGN6Form(string message)
        {
            warningProvider.SetError(selectFormGN6Button, message);
        }

        public void SetErrorForNoApprovedGN7Form(string message)
        {
            warningProvider.SetError(selectFormGN7Button, message);
        }

        public void SetErrorForNoApprovedGN24Form(string message)
        {
            warningProvider.SetError(selectFormGN24Button, message);
        }

        public void SetErrorForNoApprovedGN75AForm(string message)
        {
            warningProvider.SetError(selectFormGN75AButton, message);
        }

        public void SetErrorForNoApprovedGN1Form(string message)
        {
            warningProvider.SetError(selectFormGN1Button, message);
        }

        //Start Minlge Story #3323, Change By : Swapnil, Changed On : 14 Apr 2016
        public void ActionForValidTradeCheckGN1Form(string message) 
        {
            warningProvider.SetError(selectFormGN1Button, message);
        }
        //End Minlge Story #3323, Change By : Swapnil, Changed On : 14 Apr 2016

        public void SetErrorForInvalidGN11Value(string message)
        {
            warningProvider.SetError(gn11ComboBox, message);
        }

        public void SetErrorForInvalidGN27Value(string message)
        {
            warningProvider.SetError(gn27ComboBox, message);
        }

        public void SetErrorForNoAreaLabel()
        {
            errorProvider.SetError(areaLabelComboBox, StringResources.PermitRequestEdmonton_AreaLabelRequired);
        }

        public void SetErrorForOther1CheckedWithNoValue()
        {
            errorProvider.SetError(other1TextBox, StringResources.WorkPermit_FieldEmptyButChecked);
        }

        public void SetErrorForOther2CheckedWithNoValue()
        {
            errorProvider.SetError(other2TextBox, StringResources.WorkPermit_FieldEmptyButChecked);
        }

        public void SetErrorForOther3CheckedWithNoValue()
        {
            errorProvider.SetError(other3TextBox, StringResources.WorkPermit_FieldEmptyButChecked);
        }

        public void SetErrorForOther4CheckedWithNoValue()
        {
            errorProvider.SetError(other4TextBox, StringResources.WorkPermit_FieldEmptyButChecked);
        }

        public void SetErrorForNoSafetyRequirementChosen()
        {
            errorProvider.SetError(workersMinimumSafetyRequirementsGroupBox,
                StringResources.WorkPermitEdmonton_NoSafetyRequirementChosen);
        }

        public void SetErrorForNoWorkersMonitorNumber()
        {
            errorProvider.SetError(workersMonitorNumberTextBox, StringResources.WorkPermit_FieldEmptyButChecked);
        }

        #endregion

        public void SetFormGN1ToolTip(string tip)
        {
            toolTip.SetToolTip(gn1CheckBox, tip);
        }

        public void SetFormGN7ToolTip(string tip)
        {
            toolTip.SetToolTip(gn7CheckBox, tip);
        }

        public void SetFormGN59ToolTip(string tip)
        {
            toolTip.SetToolTip(gn59CheckBox, tip);
        }

        public void SetFormGN11ToolTip(string tip)
        {
            toolTip.SetToolTip(gn11Label, tip);
        }

        public void SetFormGN24ToolTip(string tip)
        {
            toolTip.SetToolTip(gn24CheckBox, tip);
        }

        public void SetFormGN27ToolTip(string tip)
        {
            toolTip.SetToolTip(gn27Label, tip);
        }

        public void SetFormGN6ToolTip(string tip)
        {
            toolTip.SetToolTip(gn6CheckBox, tip);
        }

        public void SetFormGN75ToolTip(string tip)
        {
            toolTip.SetToolTip(gn75ACheckBox, tip);
        }
    }
}