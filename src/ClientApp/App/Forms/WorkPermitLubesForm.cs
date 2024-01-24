using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Client.Presenters;
using Com.Suncor.Olt.Client.Utilities;
using Com.Suncor.Olt.Client.Validation.Lubes;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class WorkPermitLubesForm : BaseForm, IWorkPermitLubesView
    {
        public event EventHandler SaveButtonClicked;
        public event EventHandler CancelButtonClicked;

        public event Action SaveAndIssue;
        public event Action FormLoad;
        public event Action FormIsClosing;
        public event Action FunctionalLocationBrowse;
        public event Action ValidateForm;
        public event Action ViewConfiguredDocumentLink;
        public event Action ConfinedSpaceCheckedChanged;
        public event Action PermitTypeChanged;
        public event Action ViewHistory;

        private SingleSelectFunctionalLocationSelectionForm functionalLocationSelectorForm;

        public WorkPermitLubesForm()
        {
            InitializeComponent();

            issuedToContractorCheckBox.CheckedChanged += HandleIssuedToContractorCheckedChanged;
            saveButton.Click += HandleSaveButtonClicked;
            saveAndIssueButton.Click += HandleSaveAndIssueButtonClicked;
            validateButton.Click += HandleValidateButtonClicked;
            functionalLocationBrowseButton.Click += HandleFunctionalLocationBrowseClicked;
            viewConfiguredDocumentLinkButton.Click += HandleViewConfiguredDocumentLinkClicked;
            confinedSpaceCheckBox.CheckedChanged += HandleConfinedSpaceCheckedChanged;
            historyButton.Click += HandleHistoryButtonClicked;

            Disposed += HandleDisposed;

            other1CheckBox.CheckedChanged += PermitFormHelper.CheckBoxCheckChanged;
            other2CheckBox.CheckedChanged += PermitFormHelper.CheckBoxCheckChanged;
            other3CheckBox.CheckedChanged += PermitFormHelper.CheckBoxCheckChanged;
            designateHotOrColdCutCheckBox.CheckedChanged += PermitFormHelper.CheckBoxCheckChanged;
            confinedSpaceCheckBox.CheckedChanged += PermitFormHelper.CheckBoxCheckChanged;
            specialWorkCheckBox.CheckedChanged += PermitFormHelper.CheckBoxCheckChanged;

            otherAreasAffectedYesRadioButton.CheckedChanged += OtherAreasAffectedOnCheckedChanged;
            otherAreasAffectedNoRadioButton.CheckedChanged += OtherAreasAffectedOnCheckedChanged;

            hazardousColdWorkRadioButton.CheckedChanged += HandlePermitTypeChanged;
            hotWorkRadioButton.CheckedChanged += HandlePermitTypeChanged;
            vehicleEntryCheckBox.Enabled = hotWorkRadioButton.Checked;

            PermitFormHelper.SetupSectionNotApplicableToJob(specificRequirementsSectionNotApplicableToJobCheckBox, specificRequirementsGroupBox);
            PermitFormHelper.SetupSectionNotApplicableToJob(workPreparationsCompletedSectionNotApplicableToJobCheckBox, workPreparationsCompletedPanel);

            toolTip.SetToolTip(energizedElectricalLabel, StringResources.WorkPermitLubes_EnergizedElectricalToolTip);
        }

        private void HandlePermitTypeChanged(object sender, EventArgs e)
        {
            vehicleEntryCheckBox.Enabled = hotWorkRadioButton.Checked;

            if (PermitTypeChanged != null)
            {
                PermitTypeChanged();
            }
        }

        private void HandleHistoryButtonClicked(object sender, EventArgs e)
        {
            if (ViewHistory != null)
            {
                ViewHistory();
            }
        }

        private void HandleConfinedSpaceCheckedChanged(object sender, EventArgs e)
        {
            if (ConfinedSpaceCheckedChanged != null)
            {
                ConfinedSpaceCheckedChanged();
            }
        }

        private void HandleViewConfiguredDocumentLinkClicked(object sender, EventArgs e)
        {
            if (ViewConfiguredDocumentLink != null)
            {
                ViewConfiguredDocumentLink();
            }
        }

        private void HandleValidateButtonClicked(object sender, EventArgs e)
        {
            if (ValidateForm != null)
            {
                ValidateForm();
            }
        }

        private void HandleFunctionalLocationBrowseClicked(object sender, EventArgs e)
        {
            if (FunctionalLocationBrowse != null)
            {
                FunctionalLocationBrowse();
            }
        }

        private void HandleSaveButtonClicked(object sender, EventArgs eventArgs)
        {
            if (SaveButtonClicked != null)
            {
                SaveButtonClicked(sender, eventArgs);
            }
        }

        private void HandleSaveAndIssueButtonClicked(object sender, EventArgs eventArgs)
        {
            if (SaveAndIssue != null)
            {
                SaveAndIssue();
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            confinedSpaceClassComboBox.DataSource = PermitFormHelper.GetLubesConfinedSpaceClassList();

            if (FormLoad != null)
            {
                FormLoad();
            }
        }

        public void PopulateWorkPreparationsComboBoxes(List<YesNoNotApplicable> values)
        {
            List<ComboBox> comboBoxes = new List<ComboBox>
                {
                    depressuredDrainedComboBox,
                    waterWashedComboBox,
                    chemicallyWashedComboBox,
                    steamedComboBox,
                    purgedComboBox,
                    disconnectedComboBox,
                    depressuredAndVentedComboBox,
                    ventilatedComboBox,
                    blankedComboBox,
                    drainsCoveredComboBox,
                    areaBarricadedComboBox,
                    energySourcesLockedOutTaggedOutComboBox
                };

            foreach (ComboBox comboBox in comboBoxes)
            {
                comboBox.DataSource = new List<YesNoNotApplicable>(values);
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (FormIsClosing != null)
            {
                FormIsClosing();
            }
        }

        public void ClearErrorProviders()
        {
            errorProvider.Clear();
            warningProvider.Clear();
        }

        public void PopulateFunctionalLocationSelector(List<FunctionalLocation> functionalLocations)
        {
            functionalLocationSelectorForm = new SingleSelectFunctionalLocationSelectionForm(
                FunctionalLocationMode.GetLevelTwoAndBelow(ClientSession.GetUserContext().SiteConfiguration),
                new FunctionalLocationIsSelectedByUserFilter(FunctionalLocationType.Level2, functionalLocations));
        }

        private void HandleDisposed(object sender, EventArgs eventArgs)
        {
            if (functionalLocationSelectorForm != null && !functionalLocationSelectorForm.IsDisposed)
            {
                functionalLocationSelectorForm.Dispose();
            }
        }

        public FunctionalLocation ShowSecondLevelOrLowerFunctionalLocationSelector()
        {
            DialogResult result = functionalLocationSelectorForm.ShowDialog(this);
            return result == DialogResult.OK ? functionalLocationSelectorForm.SelectedFunctionalLocation : null;
        }

        public List<CraftOrTrade> CraftOrTrades
        {
            set
            {
                tradeComboBox.DataSource = value;
                tradeComboBox.DisplayMember = "ListDisplayText";
            }
        }

        public List<Contractor> Contractors
        {
            set
            {
                contractorComboBox.DataSource = value;
                contractorComboBox.DisplayMember = "CompanyName";
            }
        }

        public List<ConfiguredDocumentLink> ConfiguredDocumentLinks
        {
            set
            {
                configuredDocumentLinkComboBox.Items.Clear();
                value.ForEach(link => configuredDocumentLinkComboBox.Items.Add(link));
                configuredDocumentLinkComboBox.SelectedIndex = 0;
            }
        }

        public ConfiguredDocumentLink SelectedConfiguredDocumentLink
        {
            get { return (ConfiguredDocumentLink)configuredDocumentLinkComboBox.SelectedItem; }
        }

        public void OpenFileOrDirectoryOrWebsite(string path)
        {
            FileUtility.OpenFileOrDirectoryOrWebsite(path);
        }

        public bool IsTheUserWantingToSelectAMoreSpecificFunctionalLocation()
        {
            DialogResult result = OltMessageBox.Show(this, StringResources.WorkPermitLubes_SelectedFunctionalLocationIsBroadMessage, StringResources.WorkPermitLubes_SelectedFunctionalLocationIsBroadTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                return true;
            }

            return false;
        }

        public List<WorkPermitLubesGroup> RequestedByGroups
        {
            set
            {                
                groupComboBox.DataSource = value;
                groupComboBox.SelectedIndex = -1;
            }
        }

        public List<string> SpecialWorkTypes
        {
            set
            {
                specialWorkTypeComboBox.DataSource = value;
                specialWorkTypeComboBox.SelectedIndex = -1;
            }
        }

        public void DisableConfiguredDocumentLinks()
        {
            configuredDocumentLinkComboBox.Enabled = false;
            viewConfiguredDocumentLinkButton.Enabled = false;
        }

        public bool IssuedToSuncor
        {
            get { return issuedToSuncorCheckBox.Checked; }
            set { issuedToSuncorCheckBox.Checked = value; }
        }

        public bool IssuedToCompany
        {
            get { return issuedToContractorCheckBox.Checked; }
            set { issuedToContractorCheckBox.Checked = value; }
        }

        public int? NumberOfWorkers
        {
            get { return numberOfWorkersTextBox.IntegerValue; }
            set { numberOfWorkersTextBox.IntegerValue = value; }
        }

        public string Company
        {
            get { return PermitFormHelper.GetTextComboBoxValue(contractorComboBox, issuedToContractorCheckBox); }
            set { contractorComboBox.Text = value; }
        }

        public new string Location
        {
            get { return locationTextBox.Text.EmptyToNull(); }
            set { locationTextBox.Text = value; }
        }

        public List<DocumentLink> DocumentLinks
        {
            get { return documentLinksControl.DataSource as List<DocumentLink>; }
            set { documentLinksControl.DataSource = value; }
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
            }
        }

        public string SubOperationNumber
        {
            get { return subOperationNumberTextBox.Text.EmptyToNull(); }
            set
            {
                subOperationNumberTextBox.Text = value;
            }
        }

        public DateTime StartDateTime
        {
            get
            {
                Date date = startDatePicker.Value;
                Time time = startTimePicker.Value;

                return date.CreateDateTime(time);
            }

            set
            {
                startDatePicker.Value = new Date(value);
                startTimePicker.Value = new Time(value);
            }
        }

        public DateTime ExpireDateTime
        {
            get
            {
                Date date = expireDatePicker.Value;
                Time time = expireTimePicker.Value;

                return date.CreateDateTime(time);
            }
            set
            {
                expireDatePicker.Value = new Date(value);
                expireTimePicker.Value = new Time(value);
            }
        }
        
        public bool ConfinedSpace
        {
            get { return confinedSpaceCheckBox.Checked; }
            set { confinedSpaceCheckBox.Checked = value; }
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

        public bool ConfinedSpaceSafetyWatchCheckList
        {
            get { return confinedSpaceSafetyWatchChecklistCheckBox.Checked; }
            set { confinedSpaceSafetyWatchChecklistCheckBox.Checked = value; }
        }

        public bool SpecialWork
        {
            get { return specialWorkCheckBox.Checked; }
            set { specialWorkCheckBox.Checked = value; }
        }

        public string SpecialWorkType
        {
            get { return PermitFormHelper.GetTextComboBoxValue(specialWorkTypeComboBox, specialWorkCheckBox); }
            set { PermitFormHelper.SetTextComboBoxValue(value, specialWorkTypeComboBox, specialWorkCheckBox); }
        }

        public bool HazardousWorkApproverAdvised
        {
            get { return hazardousWorkApproverAdvisedCheckBox.Checked; }
            set { hazardousWorkApproverAdvisedCheckBox.Checked = value; }
        }

        public bool AdditionalFollowupRequired
        {
            get { return additionalFollowupRequiredCheckBox.Checked; }
            set { additionalFollowupRequiredCheckBox.Checked = value; }
        }

        public WorkPermitSafetyFormState HighEnergy
        {
            get { return (WorkPermitSafetyFormState)highEnergyComboBox.SelectedItem; }
            set { highEnergyComboBox.SelectedItem = value; }
        }

        public WorkPermitSafetyFormState CriticalLift
        {
            get { return (WorkPermitSafetyFormState)criticalLiftComboBox.SelectedItem; }
            set { criticalLiftComboBox.SelectedItem = value; }
        }

        public WorkPermitSafetyFormState Excavation
        {
            get { return (WorkPermitSafetyFormState)excavationComboBox.SelectedItem; }
            set { excavationComboBox.SelectedItem = value; }
        }

        public WorkPermitSafetyFormState EnergyControlPlanFormRequirement
        {
            get { return (WorkPermitSafetyFormState)energyControlPlanComboBox.SelectedItem; }
            set { energyControlPlanComboBox.SelectedItem = value; }
        }

        public WorkPermitSafetyFormState EquivalencyProc
        {
            get { return (WorkPermitSafetyFormState)equivalencyProcComboBox.SelectedItem; }
            set { equivalencyProcComboBox.SelectedItem = value; }
        }

        public WorkPermitSafetyFormState TestPneumatic
        {
            get { return (WorkPermitSafetyFormState)testPneumaticComboBox.SelectedItem; }
            set { testPneumaticComboBox.SelectedItem = value; }
        }

        public WorkPermitSafetyFormState LiveFlareWork
        {
            get { return (WorkPermitSafetyFormState)liveFlareWorkComboBox.SelectedItem; }
            set { liveFlareWorkComboBox.SelectedItem = value; }
        }

        public WorkPermitSafetyFormState EntryAndControlPlan
        {
            get { return (WorkPermitSafetyFormState)entryAndControlPlanComboBox.SelectedItem; }
            set { entryAndControlPlanComboBox.SelectedItem = value; }
        }

        public WorkPermitSafetyFormState EnergizedElectrical
        {
            get { return (WorkPermitSafetyFormState)energizedElectricalComboBox.SelectedItem; }
            set { energizedElectricalComboBox.SelectedItem = value; }
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

        public string Trade
        {
            get { return tradeComboBox.Text.EmptyToNull(); }
            set { tradeComboBox.Text = value; }
        }

        public WorkPermitLubesGroup RequestedByGroup
        {
            get { return (WorkPermitLubesGroup)groupComboBox.SelectedItem; }
            set { groupComboBox.SelectedItem = value; }
        }

        public WorkPermitLubesType WorkPermitType
        {
            get
            {
                if (hazardousColdWorkRadioButton.Checked)
                {
                    return WorkPermitLubesType.HAZARDOUS_COLD_WORK;
                }

                if (hotWorkRadioButton.Checked)
                {
                    return WorkPermitLubesType.HOT_WORK;
                }
                
                return null;
            }

            set
            {
                if (WorkPermitLubesType.HAZARDOUS_COLD_WORK.Equals(value))
                {
                    hazardousColdWorkRadioButton.Checked = true;
                }

                if (WorkPermitLubesType.HOT_WORK.Equals(value))
                {
                    hotWorkRadioButton.Checked = true;
                }               
            }
        }

        public bool IsVehicleEntry
        {
            get { return vehicleEntryCheckBox.Checked; }
            set { vehicleEntryCheckBox.Checked = value; }
        }

        private void HandleIssuedToContractorCheckedChanged(object sender, EventArgs e)
        {
            contractorComboBox.Enabled = issuedToContractorCheckBox.Checked;
        }

        public List<WorkPermitSafetyFormState> HighEnergyValues { set { highEnergyComboBox.DataSource = value; } }
        public List<WorkPermitSafetyFormState> CriticalLiftValues { set { criticalLiftComboBox.DataSource = value; } }
        public List<WorkPermitSafetyFormState> ExcavationValues { set { excavationComboBox.DataSource = value; } }
        public List<WorkPermitSafetyFormState> EnergyControlPlanValues { set { energyControlPlanComboBox.DataSource = value; } }
        public List<WorkPermitSafetyFormState> EquivalencyProcValues { set { equivalencyProcComboBox.DataSource = value; } }
        public List<WorkPermitSafetyFormState> TestPneumaticValues { set { testPneumaticComboBox.DataSource = value; } }
        public List<WorkPermitSafetyFormState> LiveFlareWorkValues { set { liveFlareWorkComboBox.DataSource = value; } }
        public List<WorkPermitSafetyFormState> EntryAndControlPlanValues { set { entryAndControlPlanComboBox.DataSource = value; } }
        public List<WorkPermitSafetyFormState> EnergizedElectricalValues { set { energizedElectricalComboBox.DataSource = value; } }
        
        public string TaskDescription
        {
            get { return descriptionTextBox.Text.EmptyToNull(); }
            set { descriptionTextBox.Text = value; }
        }

        public bool HazardHydrocarbonGas
        {
            get { return hazardHydrocarbonGasCheckbox.Checked; }
            set { hazardHydrocarbonGasCheckbox.Checked = value; }
        }

        public bool HazardHydrocarbonLiquid
        {
            get { return hazardHydrocarbonLiquidCheckBox.Checked; }
            set { hazardHydrocarbonLiquidCheckBox.Checked = value; }
        }

        public bool HazardHydrogenSulphide
        {
            get { return hazardHydrogenSulphideCheckBox.Checked; }
            set { hazardHydrogenSulphideCheckBox.Checked = value; }
        }

        public bool HazardInertGasAtmosphere
        {
            get { return hazardInertGasAtmosphere.Checked; }
            set { hazardInertGasAtmosphere.Checked = value; }
        }

        public bool HazardOxygenDeficiency
        {
            get { return hazardOxygenDeficiencyCheckBox.Checked; }
            set { hazardOxygenDeficiencyCheckBox.Checked = value; }
        }

        public bool HazardRadioactiveSources
        {
            get { return hazardRadioactiveSourcesCheckbox.Checked; }
            set { hazardRadioactiveSourcesCheckbox.Checked = value; }
        }

        public bool HazardUndergroundOverheadHazards
        {
            get { return hazardUndergroundOverheadCheckBox.Checked; }
            set { hazardUndergroundOverheadCheckBox.Checked = value; }
        }

        public bool HazardDesignatedSubstance
        {
            get { return hazardDesignatedSubstanceCheckBox.Checked; }
            set { hazardDesignatedSubstanceCheckBox.Checked = value; }
        }

        public string OtherHazardsAndOrRequirements
        {
            get { return otherHazardsTextBox.Text.EmptyToNull(); }
            set { otherHazardsTextBox.Text = value; }
        }

        public bool OtherAreasAndOrUnitsAffected
        {
            get { return otherAreasAffectedYesRadioButton.Checked; }
        }

        public string ProductNormallyInPipingEquipment
        {
            get { return PermitFormHelper.GetTextBoxValueForSection(productNormallyInPipingEquipmentTextBox, workPreparationsCompletedSectionNotApplicableToJobCheckBox); }
            set { PermitFormHelper.SetTextBoxValueForSection(value, productNormallyInPipingEquipmentTextBox, workPreparationsCompletedSectionNotApplicableToJobCheckBox); }
        }

        public YesNoNotApplicable DepressuredDrained
        {
            get { return PermitFormHelper.GetYesNoNotApplicableComboBoxValueForSection(depressuredDrainedComboBox, workPreparationsCompletedSectionNotApplicableToJobCheckBox); }
            set { PermitFormHelper.SetYesNoNotApplicableComboBoxValueForSection(value, depressuredDrainedComboBox, workPreparationsCompletedSectionNotApplicableToJobCheckBox); }
        }

        public YesNoNotApplicable WaterWashed
        {
            get { return PermitFormHelper.GetYesNoNotApplicableComboBoxValueForSection(waterWashedComboBox, workPreparationsCompletedSectionNotApplicableToJobCheckBox); }
            set { PermitFormHelper.SetYesNoNotApplicableComboBoxValueForSection(value, waterWashedComboBox, workPreparationsCompletedSectionNotApplicableToJobCheckBox); }
        }

        public YesNoNotApplicable ChemicallyWashed
        {
            get { return PermitFormHelper.GetYesNoNotApplicableComboBoxValueForSection(chemicallyWashedComboBox, workPreparationsCompletedSectionNotApplicableToJobCheckBox); }
            set { PermitFormHelper.SetYesNoNotApplicableComboBoxValueForSection(value, chemicallyWashedComboBox, workPreparationsCompletedSectionNotApplicableToJobCheckBox); }
        }

        public YesNoNotApplicable Steamed
        {
            get { return PermitFormHelper.GetYesNoNotApplicableComboBoxValueForSection(steamedComboBox, workPreparationsCompletedSectionNotApplicableToJobCheckBox); }
            set { PermitFormHelper.SetYesNoNotApplicableComboBoxValueForSection(value, steamedComboBox, workPreparationsCompletedSectionNotApplicableToJobCheckBox); }
        }

        public YesNoNotApplicable Purged
        {
            get { return PermitFormHelper.GetYesNoNotApplicableComboBoxValueForSection(purgedComboBox, workPreparationsCompletedSectionNotApplicableToJobCheckBox); }
            set { PermitFormHelper.SetYesNoNotApplicableComboBoxValueForSection(value, purgedComboBox, workPreparationsCompletedSectionNotApplicableToJobCheckBox); }
        }

        public YesNoNotApplicable Disconnected
        {
            get { return PermitFormHelper.GetYesNoNotApplicableComboBoxValueForSection(disconnectedComboBox, workPreparationsCompletedSectionNotApplicableToJobCheckBox); }
            set { PermitFormHelper.SetYesNoNotApplicableComboBoxValueForSection(value, disconnectedComboBox, workPreparationsCompletedSectionNotApplicableToJobCheckBox); }
        }

        public YesNoNotApplicable DepressuredAndVented
        {
            get { return PermitFormHelper.GetYesNoNotApplicableComboBoxValueForSection(depressuredAndVentedComboBox, workPreparationsCompletedSectionNotApplicableToJobCheckBox); }
            set { PermitFormHelper.SetYesNoNotApplicableComboBoxValueForSection(value, depressuredAndVentedComboBox, workPreparationsCompletedSectionNotApplicableToJobCheckBox); }
        }

        public YesNoNotApplicable Ventilated
        {
            get { return PermitFormHelper.GetYesNoNotApplicableComboBoxValueForSection(ventilatedComboBox, workPreparationsCompletedSectionNotApplicableToJobCheckBox); }
            set { PermitFormHelper.SetYesNoNotApplicableComboBoxValueForSection(value, ventilatedComboBox, workPreparationsCompletedSectionNotApplicableToJobCheckBox); }
        }

        public YesNoNotApplicable Blanked
        {
            get { return PermitFormHelper.GetYesNoNotApplicableComboBoxValueForSection(blankedComboBox, workPreparationsCompletedSectionNotApplicableToJobCheckBox); }
            set { PermitFormHelper.SetYesNoNotApplicableComboBoxValueForSection(value, blankedComboBox, workPreparationsCompletedSectionNotApplicableToJobCheckBox); }
        }

        public YesNoNotApplicable DrainsCovered
        {
            get { return PermitFormHelper.GetYesNoNotApplicableComboBoxValueForSection(drainsCoveredComboBox, workPreparationsCompletedSectionNotApplicableToJobCheckBox); }
            set { PermitFormHelper.SetYesNoNotApplicableComboBoxValueForSection(value, drainsCoveredComboBox, workPreparationsCompletedSectionNotApplicableToJobCheckBox); }
        }

        public YesNoNotApplicable AreaBarricaded
        {
            get { return PermitFormHelper.GetYesNoNotApplicableComboBoxValueForSection(areaBarricadedComboBox, workPreparationsCompletedSectionNotApplicableToJobCheckBox); }
            set { PermitFormHelper.SetYesNoNotApplicableComboBoxValueForSection(value, areaBarricadedComboBox, workPreparationsCompletedSectionNotApplicableToJobCheckBox); }
        }

        public YesNoNotApplicable EnergySourcesLockedOutTaggedOut
        {
            get { return PermitFormHelper.GetYesNoNotApplicableComboBoxValueForSection(energySourcesLockedOutTaggedOutComboBox, workPreparationsCompletedSectionNotApplicableToJobCheckBox); }
            set { PermitFormHelper.SetYesNoNotApplicableComboBoxValueForSection(value, energySourcesLockedOutTaggedOutComboBox, workPreparationsCompletedSectionNotApplicableToJobCheckBox); }
        }

        public string EnergyControlPlan
        {
            get { return PermitFormHelper.GetTextBoxValueForSection(energyControlPlanTextBox, workPreparationsCompletedSectionNotApplicableToJobCheckBox); }
            set { PermitFormHelper.SetTextBoxValueForSection(value, energyControlPlanTextBox, workPreparationsCompletedSectionNotApplicableToJobCheckBox); }
        }

        public string LockBoxNumber
        {
            get { return PermitFormHelper.GetTextBoxValueForSection(lockBoxNumberTextBox, workPreparationsCompletedSectionNotApplicableToJobCheckBox); }
            set { PermitFormHelper.SetTextBoxValueForSection(value, lockBoxNumberTextBox, workPreparationsCompletedSectionNotApplicableToJobCheckBox); }
        }

        public string OtherPreparations
        {
            get { return PermitFormHelper.GetTextBoxValueForSection(otherPreparationsTextBox, workPreparationsCompletedSectionNotApplicableToJobCheckBox); }
            set { PermitFormHelper.SetTextBoxValueForSection(value, otherPreparationsTextBox, workPreparationsCompletedSectionNotApplicableToJobCheckBox); }
        }

        public bool WorkPreparationsCompletedSectionNotApplicableToJob
        {
            get { return workPreparationsCompletedSectionNotApplicableToJobCheckBox.Checked; }
            set { workPreparationsCompletedSectionNotApplicableToJobCheckBox.Checked = value; }
        }

        public bool WorkPreparationsCompletedSectionNotApplicableToJobEnabled
        {
            set { workPreparationsCompletedSectionNotApplicableToJobCheckBox.Enabled = value; }
        }

        public bool SpecificRequirementsSectionNotApplicableToJob
        {
            get { return specificRequirementsSectionNotApplicableToJobCheckBox.Checked; }
            set { specificRequirementsSectionNotApplicableToJobCheckBox.Checked = value; }
        }

        public bool AttendedAtAllTimes
        {
            get { return PermitFormHelper.GetCheckBoxValueForSection(attendedAtAllTimesCheckBox, specificRequirementsSectionNotApplicableToJobCheckBox); }
            set { PermitFormHelper.SetCheckBoxValueForSection(value, attendedAtAllTimesCheckBox, specificRequirementsSectionNotApplicableToJobCheckBox); }
        }

        public bool EyeProtection
        {
            get { return PermitFormHelper.GetCheckBoxValueForSection(eyeProtectionCheckBox, specificRequirementsSectionNotApplicableToJobCheckBox); }
            set { PermitFormHelper.SetCheckBoxValueForSection(value, eyeProtectionCheckBox, specificRequirementsSectionNotApplicableToJobCheckBox); }
        }

        public bool FallProtectionEquipment
        {
            get { return PermitFormHelper.GetCheckBoxValueForSection(fallProtectionEquipmentCheckBox, specificRequirementsSectionNotApplicableToJobCheckBox); }
            set { PermitFormHelper.SetCheckBoxValueForSection(value, fallProtectionEquipmentCheckBox, specificRequirementsSectionNotApplicableToJobCheckBox); }
        }

        public bool FullBodyHarnessRetrieval
        {
            get { return PermitFormHelper.GetCheckBoxValueForSection(fullBodyHarnessRetrievalCheckBox, specificRequirementsSectionNotApplicableToJobCheckBox); }
            set { PermitFormHelper.SetCheckBoxValueForSection(value, fullBodyHarnessRetrievalCheckBox, specificRequirementsSectionNotApplicableToJobCheckBox); }
        }

        public bool HearingProtection
        {
            get { return PermitFormHelper.GetCheckBoxValueForSection(hearingProtectionCheckBox, specificRequirementsSectionNotApplicableToJobCheckBox); }
            set { PermitFormHelper.SetCheckBoxValueForSection(value, hearingProtectionCheckBox, specificRequirementsSectionNotApplicableToJobCheckBox); }
        }

        public bool ProtectiveClothing
        {
            get { return PermitFormHelper.GetCheckBoxValueForSection(protectiveClothingCheckBox, specificRequirementsSectionNotApplicableToJobCheckBox); }
            set { PermitFormHelper.SetCheckBoxValueForSection(value, protectiveClothingCheckBox, specificRequirementsSectionNotApplicableToJobCheckBox); }
        }

        public bool Other1Checked
        {
            get { return PermitFormHelper.GetCheckBoxValueForSection(other1CheckBox, specificRequirementsSectionNotApplicableToJobCheckBox); }
            set { PermitFormHelper.SetCheckBoxValueForSection(value, other1CheckBox, specificRequirementsSectionNotApplicableToJobCheckBox); }
        }

        public string Other1Value
        {
            get { return PermitFormHelper.GetTextBoxValueForSection(other1TextBox, other1CheckBox, specificRequirementsSectionNotApplicableToJobCheckBox); }
            set { PermitFormHelper.SetTextBoxValueForSection(value, other1TextBox, other1CheckBox, specificRequirementsSectionNotApplicableToJobCheckBox); }
        }

        public bool EquipmentBondedGrounded
        {
            get { return PermitFormHelper.GetCheckBoxValueForSection(equipmentBondedGroundedCheckBox, specificRequirementsSectionNotApplicableToJobCheckBox); }
            set { PermitFormHelper.SetCheckBoxValueForSection(value, equipmentBondedGroundedCheckBox, specificRequirementsSectionNotApplicableToJobCheckBox); }
        }

        public bool FireBlanket
        {
            get { return PermitFormHelper.GetCheckBoxValueForSection(fireBlanketCheckBox, specificRequirementsSectionNotApplicableToJobCheckBox); }
            set { PermitFormHelper.SetCheckBoxValueForSection(value, fireBlanketCheckBox, specificRequirementsSectionNotApplicableToJobCheckBox); }
        }

        public bool FireFightingEquipment
        {
            get { return PermitFormHelper.GetCheckBoxValueForSection(fireFightingEquipmentCheckBox, specificRequirementsSectionNotApplicableToJobCheckBox); }
            set { PermitFormHelper.SetCheckBoxValueForSection(value, fireFightingEquipmentCheckBox, specificRequirementsSectionNotApplicableToJobCheckBox); }
        }

        public bool FireWatch
        {
            get { return PermitFormHelper.GetCheckBoxValueForSection(fireWatchCheckBox, specificRequirementsSectionNotApplicableToJobCheckBox); }
            set { PermitFormHelper.SetCheckBoxValueForSection(value, fireWatchCheckBox, specificRequirementsSectionNotApplicableToJobCheckBox); }
        }

        public bool HydrantPermit
        {
            get { return PermitFormHelper.GetCheckBoxValueForSection(hydrantPermitCheckBox, specificRequirementsSectionNotApplicableToJobCheckBox); }
            set { PermitFormHelper.SetCheckBoxValueForSection(value, hydrantPermitCheckBox, specificRequirementsSectionNotApplicableToJobCheckBox); }
        }

        public bool WaterHose
        {
            get { return PermitFormHelper.GetCheckBoxValueForSection(waterHoseCheckBox, specificRequirementsSectionNotApplicableToJobCheckBox); }
            set { PermitFormHelper.SetCheckBoxValueForSection(value, waterHoseCheckBox, specificRequirementsSectionNotApplicableToJobCheckBox); }
        }

        public bool SteamHose
        {
            get { return PermitFormHelper.GetCheckBoxValueForSection(steamHoseCheckBox, specificRequirementsSectionNotApplicableToJobCheckBox); }
            set { PermitFormHelper.SetCheckBoxValueForSection(value, steamHoseCheckBox, specificRequirementsSectionNotApplicableToJobCheckBox); }
        }

        public bool Other2Checked
        {
            get { return PermitFormHelper.GetCheckBoxValueForSection(other2CheckBox, specificRequirementsSectionNotApplicableToJobCheckBox); }
            set { PermitFormHelper.SetCheckBoxValueForSection(value, other2CheckBox, specificRequirementsSectionNotApplicableToJobCheckBox); }
        }

        public string Other2Value
        {
            get { return PermitFormHelper.GetTextBoxValueForSection(other2TextBox, other2CheckBox, specificRequirementsSectionNotApplicableToJobCheckBox); }
            set { PermitFormHelper.SetTextBoxValueForSection(value, other2TextBox, other2CheckBox, specificRequirementsSectionNotApplicableToJobCheckBox); }
        }

        public bool AirMover
        {
            get { return PermitFormHelper.GetCheckBoxValueForSection(airMoverCheckBox, specificRequirementsSectionNotApplicableToJobCheckBox); }
            set { PermitFormHelper.SetCheckBoxValueForSection(value, airMoverCheckBox, specificRequirementsSectionNotApplicableToJobCheckBox); }
        }

        public bool ContinuousGasMonitor
        {
            get { return PermitFormHelper.GetCheckBoxValueForSection(continuousGasMonitorCheckBox, specificRequirementsSectionNotApplicableToJobCheckBox); }
            set { PermitFormHelper.SetCheckBoxValueForSection(value, continuousGasMonitorCheckBox, specificRequirementsSectionNotApplicableToJobCheckBox); }
        }

        public bool DrowningProtection
        {
            get { return PermitFormHelper.GetCheckBoxValueForSection(drowningProtectionCheckBox, specificRequirementsSectionNotApplicableToJobCheckBox); }
            set { PermitFormHelper.SetCheckBoxValueForSection(value, drowningProtectionCheckBox, specificRequirementsSectionNotApplicableToJobCheckBox); }
        }

        public bool RespiratoryProtection
        {
            get { return PermitFormHelper.GetCheckBoxValueForSection(respiratoryProtectionCheckBox, specificRequirementsSectionNotApplicableToJobCheckBox); }
            set { PermitFormHelper.SetCheckBoxValueForSection(value, respiratoryProtectionCheckBox, specificRequirementsSectionNotApplicableToJobCheckBox); }
        }

        public bool Other3Checked
        {
            get { return PermitFormHelper.GetCheckBoxValueForSection(other3CheckBox, specificRequirementsSectionNotApplicableToJobCheckBox); }
            set { PermitFormHelper.SetCheckBoxValueForSection(value, other3CheckBox, specificRequirementsSectionNotApplicableToJobCheckBox); }
        }

        public string Other3Value
        {
            get { return PermitFormHelper.GetTextBoxValueForSection(other3TextBox, other3CheckBox, specificRequirementsSectionNotApplicableToJobCheckBox); }
            set { PermitFormHelper.SetTextBoxValueForSection(value, other3TextBox, other3CheckBox, specificRequirementsSectionNotApplicableToJobCheckBox); }
        }

        public bool AdditionalLighting
        {
            get { return PermitFormHelper.GetCheckBoxValueForSection(additionalLightingCheckBox, specificRequirementsSectionNotApplicableToJobCheckBox); }
            set { PermitFormHelper.SetCheckBoxValueForSection(value, additionalLightingCheckBox, specificRequirementsSectionNotApplicableToJobCheckBox); }
        }

        public bool DesignateHotOrColdCutChecked
        {
            get { return PermitFormHelper.GetCheckBoxValueForSection(designateHotOrColdCutCheckBox, specificRequirementsSectionNotApplicableToJobCheckBox); }
            set { PermitFormHelper.SetCheckBoxValueForSection(value, designateHotOrColdCutCheckBox, specificRequirementsSectionNotApplicableToJobCheckBox); }
        }

        public string DesignateHotOrColdCutValue
        {
            get { return PermitFormHelper.GetTextBoxValueForSection(designateHotOrColdCutTextBox, designateHotOrColdCutCheckBox, specificRequirementsSectionNotApplicableToJobCheckBox); }
            set { PermitFormHelper.SetTextBoxValueForSection(value, designateHotOrColdCutTextBox, designateHotOrColdCutCheckBox, specificRequirementsSectionNotApplicableToJobCheckBox); }
        }

        public bool HoistingEquipment
        {
            get { return PermitFormHelper.GetCheckBoxValueForSection(hoistingEquipmentCheckBox, specificRequirementsSectionNotApplicableToJobCheckBox); }
            set { PermitFormHelper.SetCheckBoxValueForSection(value, hoistingEquipmentCheckBox, specificRequirementsSectionNotApplicableToJobCheckBox); }
        }

        public bool Ladder
        {
            get { return PermitFormHelper.GetCheckBoxValueForSection(ladderCheckBox, specificRequirementsSectionNotApplicableToJobCheckBox); }
            set { PermitFormHelper.SetCheckBoxValueForSection(value, ladderCheckBox, specificRequirementsSectionNotApplicableToJobCheckBox); }
        }

        public bool MotorizedEquipment
        {
            get { return PermitFormHelper.GetCheckBoxValueForSection(motorizedEquipmentCheckBox, specificRequirementsSectionNotApplicableToJobCheckBox); }
            set { PermitFormHelper.SetCheckBoxValueForSection(value, motorizedEquipmentCheckBox, specificRequirementsSectionNotApplicableToJobCheckBox); }
        }

        public bool Scaffold
        {
            get { return PermitFormHelper.GetCheckBoxValueForSection(scaffoldCheckBox, specificRequirementsSectionNotApplicableToJobCheckBox); }
            set { PermitFormHelper.SetCheckBoxValueForSection(value, scaffoldCheckBox, specificRequirementsSectionNotApplicableToJobCheckBox); }
        }

        public bool ReferToTipsProcedure
        {
            get { return PermitFormHelper.GetCheckBoxValueForSection(referToTipsProcedureCheckBox, specificRequirementsSectionNotApplicableToJobCheckBox); }
            set { PermitFormHelper.SetCheckBoxValueForSection(value, referToTipsProcedureCheckBox, specificRequirementsSectionNotApplicableToJobCheckBox); }
        }

        public bool GasDetectorBumpTested
        {
            get { return gasDetectorBumpTestedCheckBox.Checked; }
            set { gasDetectorBumpTestedCheckBox.Checked = value; }
        }

        public bool AtmosphericGasTestRequired
        {
            get { return atmosphericGasTestRequiredCheckBox.Checked; }
            set { atmosphericGasTestRequiredCheckBox.Checked = value; }
        }

        public string OtherAreasAndOrUnitsAffectedArea
        {
            get
            {
                if (OtherAreasAndOrUnitsAffected)
                {
                    return areaTextBox.Text.EmptyToNull();
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

        private void OtherAreasAffectedOnCheckedChanged(object sender, EventArgs eventArgs)
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

        private bool AreaAffectedEnabled
        {
            set { areaTextBox.Enabled = value; }
        }

        private bool PersonNotifiedEnabled
        {
            set { personNotifiedTextBox.Enabled = value; }
        }

        public string PermitNumber
        {
            set { permitNumberValue.Text = value; }
        }

        public bool HistoryButtonEnabled
        {
            set { historyButton.Enabled = value; }
        }

        public bool WorkOrderNumberReadOnly
        {
            set { workOrderNumberTextBox.ReadOnly = value; }
        }

        public bool OperationNumberReadOnly
        {
            set { operationNumberTextBox.ReadOnly = value; }
        }

        public bool SubOperationNumberReadOnly
        {
            set { subOperationNumberTextBox.ReadOnly = value; }
        }

        public void SetOtherAreasAndOrUnitsAffected(bool otherAreasAndOrUnitsAffected, string area, string personNotified)
        {
            if (otherAreasAndOrUnitsAffected)
            {
                otherAreasAffectedYesRadioButton.Checked = true;
                otherAreasAffectedNoRadioButton.Checked = false;

                areaTextBox.Text = area;
                personNotifiedTextBox.Text = personNotified;
            }
            else
            {
                otherAreasAffectedYesRadioButton.Checked = false;
                otherAreasAffectedNoRadioButton.Checked = true;

                areaTextBox.Text = null;
                personNotifiedTextBox.Text = null;
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

        public void TurnOnAutosetIndicatorsForDateTimes()
        {
            infoProvider.SetError(expireTimePicker, StringResources.AutosetWorkPermitDateTimesInfoMessage);
        }

        public void ClearAutosetIndicatorsForDateTimes()
        {
            infoProvider.Clear();
        }

        public void DisableSaveAndIssueButton()
        {
            saveAndIssueButton.Enabled = false;
        }

        public bool AtmosphericGasTestRequiredEnabled
        {
            set { atmosphericGasTestRequiredCheckBox.Enabled = value; }
        }

        public void SetWarningForTaskDescriptionDoesNotFitPrintout()
        {
            infoProvider.SetError(descriptionTextBox, StringResources.WorkPermit_TaskDescriptionTooLong);
        }

        public void SetWarningForHazardsDoesNotFitPrintout()
        {
            infoProvider.SetError(otherHazardsTextBox, StringResources.WorkPermit_HazardsTooLong);
        }

        public void SetWarningForStartAndEndNotWithinCurrentShiftOrFutureShift()
        {
            warningProvider.SetError(startDatePicker, StringResources.WorkPermitLubes_StartAndEndNotWithinCurrentShiftOrFutureShift);
        }

        public void SetWarningForGasDetectorBumpTestedRequired()
        {
            warningProvider.SetError(gasDetectorBumpTestedCheckBox, StringResources.WorkPermitLubes_GasDetectorBumpTestedRequired);
        }

        public void ShowHasValidationErrorsMessageBox()
        {
            string title = StringResources.WorkPermit_IncompleteWorkPermit;
            string message = StringResources.WorkPermit_Validation_ErrorsOnlyMessage;
            OltMessageBox.Show(this, message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void ShowHasValidationWarningsMessageBox()
        {
            string title = StringResources.WorkPermit_IncompleteWorkPermit;
            string message = StringResources.WorkPermit_Validation_WarningsOnlyMessage;
            OltMessageBox.Show(this, message, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public void ShowIsValidMessageBox()
        {
            string title = StringResources.WorkPermitLubes_Validation_IsValidTitle;
            string message = StringResources.WorkPermitLubes_Validation_IsValid;
            OltMessageBox.Show(this, message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void ShowHasValidationWarningsAndErrorsMessageBox()
        {
            string title = StringResources.WorkPermit_IncompleteWorkPermit;
            string message = StringResources.WorkPermit_Validation_WarningsAndErrorsMessage;
            OltMessageBox.Show(this, message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public DialogResult ShowWarnings(WorkPermitLubesOtherWarnings otherWarnings, bool validationWarning)
        {
            string messageOne = StringResources.WorkPermitLubes_Warnings_MessageOne;
            string messageTwo = StringResources.WorkPermitLubes_Warnings_MessageTwo;

            List<string> warnings = otherWarnings.Warnings(validationWarning);
            return OltListMessageBox.Show(this, messageOne, messageTwo, warnings, StringResources.WorkPermitLubes_Warnings_Title, MessageBoxIcon.Warning, false);
        }

        public void SetErrorForNumberOfWorkersLessThanOrEqualToZero()
        {
            errorProvider.SetError(numberOfWorkersTextBox, StringResources.WorkPermitLubes_NumberOfWorkersIsLessThanOrEqualtoZero);
        }

        public void SetWarningForNoNumberOfWorkers()
        {
            warningProvider.SetError(numberOfWorkersTextBox, StringResources.WorkPermitLubes_NoNumberOfWorkers);
        }

        public void SetErrorForNoTrade()
        {
            errorProvider.SetError(tradeComboBox, StringResources.WorkPermitLubes_TradeEmpty);
        }

        public void SetErrorForNoLocation()
        {
            errorProvider.SetError(locationTextBox, StringResources.WorkPermit_LocationEmpty);
        }

        public void SetErrorForNoFunctionalLocation()
        {
            errorProvider.SetError(functionalLocationBrowseButton, StringResources.WorkPermitLubes_FunctionalLocationEmpty);
        }

        public void SetErrorForNoContractor()
        {
            warningProvider.SetError(contractorComboBox, StringResources.WorkPermitLubes_ContractorEmpty);
        }

        public void SetErrorForNoIssuedTo()
        {
            warningProvider.SetError(contractorComboBox, StringResources.WorkPermitLubes_NoIssuedTo);
        }

        public void SetErrorForNoDescription()
        {
            errorProvider.SetError(descriptionTextBox, StringResources.WorkPermit_Description_Empty);
        }

        public void SetErrorForNoPermitType()
        {
            errorProvider.SetError(hotWorkRadioButton, StringResources.WorkPermit_PermitType_Not_Selected);
        }

        public void SetErrorForStartDateTimeNotBeforeEndDateTime()
        {
            ClearAutosetIndicatorsForDateTimes(); // This is because the two icons conflict
            errorProvider.SetError(expireTimePicker, StringResources.WorkPermitLubes_StartDateTimeMustBeBeforeExpireDateTime);
        }

        public void SetErrorForExpireDateTimeInThePast()
        {
            ClearAutosetIndicatorsForDateTimes(); // This is because the two icons conflict
            errorProvider.SetError(expireTimePicker, StringResources.DateCannotBeInThePast);
        }

        public void SetErrorForNoRequestedByGroup()
        {
            errorProvider.SetError(groupComboBox, StringResources.WorkPermitLubes_RequestByGroupEmpty);
        }

        public void SetErrorForNoAreaAffected()
        {
            errorProvider.SetError(areaTextBox, StringResources.WorkPermitLubes_AreaAffectedEmpty);
        }

        public void SetErrorForNoPersonNotified()
        {
            errorProvider.SetError(personNotifiedTextBox, StringResources.WorkPermitLubes_PersonNotifiedEmpty);
        }

        public void SetErrorForNoConfinedSpaceClass()
        {
            warningProvider.SetError(confinedSpaceClassComboBox, StringResources.WorkPermit_FieldEmptyButChecked);
        }

        public void SetErrorForNoSpecialWorkType()
        {
            errorProvider.SetError(specialWorkTypeComboBox, StringResources.WorkPermit_FieldEmptyButChecked);
        }

        public void SetErrorForInvalidHighEnergyValue()
        {
            warningProvider.SetError(highEnergyComboBox, StringResources.WorkPermitLubes_FieldMustBeSetToNAOrApproved);
        }

        public void SetErrorForInvalidCriticalLiftValue()
        {
            warningProvider.SetError(criticalLiftComboBox, StringResources.WorkPermitLubes_FieldMustBeSetToNAOrApproved);
        }

        public void SetErrorForInvalidExcavationValue()
        {
            warningProvider.SetError(excavationComboBox, StringResources.WorkPermitLubes_FieldMustBeSetToNAOrApproved);
        }

        public void SetErrorForInvalidEnergyControlPlanValue()
        {
            warningProvider.SetError(energyControlPlanComboBox, StringResources.WorkPermitLubes_FieldMustBeSetToNAOrApproved);
        }

        public void SetErrorForInvalidEquivalencyProcValue()
        {
            warningProvider.SetError(equivalencyProcComboBox, StringResources.WorkPermitLubes_FieldMustBeSetToNAOrApproved);
        }

        public void SetErrorForInvalidTestPneumaticValue()
        {
            warningProvider.SetError(testPneumaticComboBox, StringResources.WorkPermitLubes_FieldMustBeSetToNAOrApproved);
        }

        public void SetErrorForInvalidLiveFlareWorkValue()
        {
            warningProvider.SetError(liveFlareWorkComboBox, StringResources.WorkPermitLubes_FieldMustBeSetToNAOrApproved);
        }

        public void SetErrorForInvalidEntryAndControlPlanValue()
        {
            warningProvider.SetError(entryAndControlPlanComboBox, StringResources.WorkPermitLubes_FieldMustBeSetToNAOrApproved);
        }

        public void SetErrorForInvalidEnergizedElectricalValue()
        {
            warningProvider.SetError(energizedElectricalComboBox, StringResources.WorkPermitLubes_FieldMustBeSetToNAOrApproved);
        }

        public void SetErrorForNoOtherHazards()
        {
            warningProvider.SetError(otherHazardsTextBox, StringResources.WorkPermitLubes_HazardsAndOrRequirementsEmpty);
        }

        public void SetErrorForDesignateHotOrColdCutCheckedWithNoValue()
        {
            warningProvider.SetError(designateHotOrColdCutTextBox, StringResources.WorkPermitLubes_RequiredForIssuing);
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

        public void SetErrorForSpecificRequirementsSectionEnabledButNothingChecked()
        {
            warningProvider.SetError(specificRequirementsTableLayoutPanel, StringResources.WorkPermitLubes_SpecificRequirementsSectionEnabledButNothingSelected);
        }

        public void SetErrorForAtmosphericGasTestRequiredMustBeCheckedIfHotOrConfinedSpace()
        {
            errorProvider.SetError(atmosphericGasTestRequiredCheckBox, StringResources.WorkPermitLubes_AtmosphericGasTestRequiredIfHotOrConfinedSpace);
        }

        public void SetErrorForNoProductNormallyInPipingEquipment()
        {
            warningProvider.SetError(productNormallyInPipingEquipmentTextBox, StringResources.WorkPermitLubes_NoProductNormallyInPipingEquipment);
        }

        public void SetErrorForNoEnergyControlPlan()
        {
            warningProvider.SetError(energyControlPlanTextBox, StringResources.WorkPermitLubes_NoEnergyControlPlan);
        }

        public void SetErrorForNoLockBoxNumber()
        {
            warningProvider.SetError(lockBoxNumberTextBox, StringResources.WorkPermitLubes_NoLockBoxNumber);
        }
    }
}
