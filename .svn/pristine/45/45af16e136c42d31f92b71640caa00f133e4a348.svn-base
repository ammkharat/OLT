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
using Com.Suncor.Olt.Common.Utility;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class PermitRequestLubesForm : BaseForm, IPermitRequestLubesView
    {
        public event EventHandler SaveButtonClicked;
        public event EventHandler CancelButtonClicked;
        public event Action FormLoad;
        public event Action FormIsClosing;
        public event Action FunctionalLocationBrowse;
        public event Action ValidateForm;
        public event Action ViewHistory;

        private SingleSelectFunctionalLocationSelectionForm functionalLocationSelectorForm;

        public PermitRequestLubesForm()
        {
            InitializeComponent();

            issuedToContractorCheckBox.CheckedChanged += HandleIssuedToContractorCheckedChanged;
            saveAndCloseButton.Click += HandleSaveAndCloseButtonClicked;
            functionalLocationBrowseButton.Click += HandleFunctionalLocationBrowseClicked;
            validateButton.Click += HandleValidateButtonClicked;
            viewEditHistoryButton.Click += HandleViewHistoryButtonClicked;

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
            
            toolTip.SetToolTip(energizedElectricalLabel, StringResources.WorkPermitLubes_EnergizedElectricalToolTip);
        }

        private void HandlePermitTypeChanged(object sender, EventArgs e)
        {
            vehicleEntryCheckBox.Enabled = hotWorkRadioButton.Checked;            
        }

        private void HandleViewHistoryButtonClicked(object sender, EventArgs e)
        {
            if (ViewHistory != null)
            {
                ViewHistory();
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

        private void HandleSaveAndCloseButtonClicked(object sender, EventArgs e)
        {
            if (SaveButtonClicked != null)
            {
                SaveButtonClicked(sender, e);
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

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (FormIsClosing != null)
            {
                FormIsClosing();
            }
        }

        private void HandleDisposed(object sender, EventArgs eventArgs)
        {
            if (functionalLocationSelectorForm != null && !functionalLocationSelectorForm.IsDisposed)
            {
                functionalLocationSelectorForm.Dispose();
            }
        }

        public void ClearErrorProviders()
        {
            errorProvider.Clear();
            warningProvider.Clear();
        }

        public bool HistoryButtonEnabled
        {
            set { viewEditHistoryButton.Enabled = value; }
        }

        public bool WorkOrderNumberReadOnly { set { workOrderNumberTextBox.ReadOnly = value; } }
        public bool OperationNumberReadOnly { set { operationNumberTextBox.ReadOnly = value; } }
        public bool SubOperationNumberReadOnly { set { subOperationNumberTextBox.ReadOnly = value; } }

        public void PopulateFunctionalLocationSelector(List<FunctionalLocation> functionalLocations)
        {
            functionalLocationSelectorForm = new SingleSelectFunctionalLocationSelectionForm(
                FunctionalLocationMode.GetLevelTwoAndBelow(ClientSession.GetUserContext().SiteConfiguration),
                new FunctionalLocationIsSelectedByUserFilter(FunctionalLocationType.Level2, functionalLocations));
        }

        public FunctionalLocation ShowSecondLevelOrLowerFunctionalLocationSelector()
        {
            DialogResult result = functionalLocationSelectorForm.ShowDialog(this);
            return result == DialogResult.OK ? functionalLocationSelectorForm.SelectedFunctionalLocation : null;
        }

        private void HandleIssuedToContractorCheckedChanged(object sender, EventArgs eventArgs)
        {
            contractorComboBox.Enabled = issuedToContractorCheckBox.Checked;
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

        public WorkPermitSafetyFormState EnergyControlPlan
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
            get { return (WorkPermitLubesGroup) groupComboBox.SelectedItem; }
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
        
        public List<WorkPermitSafetyFormState> HighEnergyValues { set { highEnergyComboBox.DataSource = value; } }
        public List<WorkPermitSafetyFormState> CriticalLiftValues { set { criticalLiftComboBox.DataSource = value; } }
        public List<WorkPermitSafetyFormState> ExcavationValues { set { excavationComboBox.DataSource = value; } }
        public List<WorkPermitSafetyFormState> EnergyControlPlanValues { set { energyControlPlanComboBox.DataSource = value; } }
        public List<WorkPermitSafetyFormState> EquivalencyProcValues { set { equivalencyProcComboBox.DataSource = value; } }
        public List<WorkPermitSafetyFormState> TestPneumaticValues { set { testPneumaticComboBox.DataSource = value; } }
        public List<WorkPermitSafetyFormState> LiveFlareWorkValues { set { liveFlareWorkComboBox.DataSource = value; } }
        public List<WorkPermitSafetyFormState> EntryAndControlPlanValues { set { entryAndControlPlanComboBox.DataSource = value; } }
        public List<WorkPermitSafetyFormState> EnergizedElectricalValues { set { energizedElectricalComboBox.DataSource = value; } }

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
            set { PermitFormHelper.SetTimePickerValue(value, Clock.Now.ToTime(), requestedStartTimeDayPicker, requestedStartDayCheckBox); }
        }

        public Time RequestedStartTimeNight
        {
            get { return PermitFormHelper.GetTimePickerValue(requestedStartTimeNightPicker, requestedStartNightCheckBox); }
            set { PermitFormHelper.SetTimePickerValue(value, new Time(19, 30), requestedStartTimeNightPicker, requestedStartNightCheckBox); }
        }

        public string TaskDescription
        {
            get { return descriptionTextBox.Text.EmptyToNull(); }
            set { descriptionTextBox.Text = value; }
        }

        public string SapDescription
        {
            get { return sapDescriptionTextBox.Text.EmptyToNull(); }
            set { sapDescriptionTextBox.Text = value; }
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

        public User LastSubmittedBy
        {
            set { lastSubmittedByLabel.Text = value == null ? StringResources.NotApplicable : value.FullNameWithUserName; }
        }
        public DateTime? LastSubmittedDateTime
        {
            set { lastSubmittedDateTimeLabel.Text = value == null ? StringResources.NotApplicable : value.ToShortDateAndTimeStringOrEmptyString(); }
        }

        public void HideSapDescription()
        {
            int sapDescriptionRow = mainTableLayoutPanel.GetRow(sapDescriptionPanel);
            float sapDescriptionRowHeight = mainTableLayoutPanel.RowStyles[sapDescriptionRow].Height;
            mainTableLayoutPanel.RowStyles[sapDescriptionRow].Height = 0;
            mainTableLayoutPanel.Height = (int) (mainTableLayoutPanel.Height - Math.Floor(sapDescriptionRowHeight));
        }

        public void SetErrorForNumberOfWorkersLessThanOrEqualToZero()
        {
            warningProvider.SetError(numberOfWorkersTextBox, StringResources.WorkPermitLubes_NumberOfWorkersIsLessThanOrEqualtoZero);
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

        public void SetErrorForNoDescription()
        {
            errorProvider.SetError(descriptionTextBox, StringResources.WorkPermit_Description_Empty);
        }

        public void SetErrorForNoPermitType()
        {
            errorProvider.SetError(hotWorkRadioButton, StringResources.WorkPermit_PermitType_Not_Selected);
        }

        public void ShowSaveAndCloseMessageForErrors()
        {
            string message = StringResources.PermitRequestLubes_Validation_ErrorsOnlyMessage;
            string title = StringResources.PermitRequestLubes_IncompletePermitRequest;

            OltMessageBox.Show(this, message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public DialogResult ShowSaveAndCloseMessageForWarnings(PermitRequestLubesOtherWarnings otherWarnings, bool hasValidationWarnings)
        {
            string messageOne = StringResources.WorkPermitLubes_Warnings_MessageOne;
            string messageTwo = StringResources.WorkPermitLubes_Warnings_MessageTwo;

            List<string> warnings = otherWarnings.Warnings(hasValidationWarnings);
            return OltListMessageBox.Show(this, messageOne, messageTwo, warnings, StringResources.WorkPermitLubes_Warnings_Title,
                                          MessageBoxIcon.Warning, false);
        }

        public void ShowSaveAndCloseMessageForWarningsAndErrors()
        {
            string message = StringResources.PermitRequestLubes_Validation_WarningsAndErrorsMessage;
            string title = StringResources.PermitRequestLubes_IncompletePermitRequest;

            OltMessageBox.Show(this, message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void ShowIsValidMessageBox()
        {
            string title = StringResources.PermitRequestLubes_Validation_IsValidTitle;
            string message = StringResources.PermitRequestLubes_Validation_IsValid;
            OltMessageBox.Show(this, message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void ValidationMessageForWarnings()
        {
            string message = StringResources.PermitRequestLubes_SubmitAndClose_WarningsOnlyMessage;
            string title = StringResources.PermitRequestLubes_IncompletePermitRequest;

            OltMessageBox.Show(this, message, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        public void SetErrorForNoSpecialWorkType()
        {
            errorProvider.SetError(specialWorkTypeComboBox, StringResources.WorkPermit_FieldEmptyButChecked);
        }

        public void SetErrorForInvalidHighEnergyValue()
        {
            warningProvider.SetError(highEnergyComboBox, StringResources.PermitRequestLubes_FieldMustBeSetToNAOrApproved);
        }

        public void SetErrorForInvalidCriticalLiftValue()
        {
            warningProvider.SetError(criticalLiftComboBox, StringResources.PermitRequestLubes_FieldMustBeSetToNAOrApproved);
        }

        public void SetErrorForInvalidExcavationValue()
        {
            warningProvider.SetError(excavationComboBox, StringResources.PermitRequestLubes_FieldMustBeSetToNAOrApproved);
        }

        public void SetErrorForInvalidEnergyControlPlanValue()
        {
            warningProvider.SetError(energyControlPlanComboBox, StringResources.PermitRequestLubes_FieldMustBeSetToNAOrApproved);
        }

        public void SetErrorForInvalidEquivalencyProcValue()
        {
            warningProvider.SetError(equivalencyProcComboBox, StringResources.PermitRequestLubes_FieldMustBeSetToNAOrApproved);
        }

        public void SetErrorForInvalidTestPneumaticValue()
        {
            warningProvider.SetError(testPneumaticComboBox, StringResources.PermitRequestLubes_FieldMustBeSetToNAOrApproved);
        }

        public void SetErrorForInvalidLiveFlareWorkValue()
        {
            warningProvider.SetError(liveFlareWorkComboBox, StringResources.PermitRequestLubes_FieldMustBeSetToNAOrApproved);
        }

        public void SetErrorForInvalidEntryAndControlPlanValue()
        {
            warningProvider.SetError(entryAndControlPlanComboBox, StringResources.PermitRequestLubes_FieldMustBeSetToNAOrApproved);
        }

        public void SetErrorForInvalidEnergizedElectricalValue()
        {
            warningProvider.SetError(energizedElectricalComboBox, StringResources.PermitRequestLubes_FieldMustBeSetToNAOrApproved);
        }

        public void SetErrorForDesignateHotOrColdCutCheckedWithNoValue()
        {
            warningProvider.SetError(designateHotOrColdCutTextBox, StringResources.PermitRequestLubes_RequiredForSubmission);
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

        public void SetErrorForStartDateNotBeforeEndDate()
        {
            errorProvider.SetError(requestedEndDatePicker, StringResources.PermitRequestLubes_StartDateCannotBeAfterEndDate);
        }

        public void SetErrorForEndDateInThePast()
        {
            errorProvider.SetError(requestedEndDatePicker, StringResources.DateCannotBeInThePast);
        }

        public void SetErrorForNoStartTime()
        {
            errorProvider.SetError(requestedStartTimeDayPicker, StringResources.PermitRequestLubes_NoStartTime);
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

    }
}
