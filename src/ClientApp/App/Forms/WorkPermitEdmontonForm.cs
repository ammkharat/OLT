﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.Controls;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Client.Presenters;
using Com.Suncor.Olt.Client.Utilities;
using Com.Suncor.Olt.Client.Validation.Edmonton;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.Form;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Common.Utility;
using DevExpress.Charts.Native;

namespace Com.Suncor.Olt.Client.Forms
{
    public partial class WorkPermitEdmontonForm : BaseForm, IWorkPermitEdmontonView
    {
        private SingleSelectFunctionalLocationSelectionForm functionalLocationSelectorForm;
        private readonly WorkPermitEdmontonBusinessLogic workPermitEdmontonBusinessLogic;


        public event EventHandler SaveButtonClicked;
        public event Action SaveAndIssueButtonClicked;
        public event EventHandler CancelButtonClicked;
        public event Action ValidateButtonClicked;
        public event Action PrintPreferencesButtonClicked;

        public event Action FunctionalLocationBrowseClicked;
        public event Action FormLoad;
        public event Action SelectFormGN6ButtonClicked;
        public event Action SelectFormGN7ButtonClicked;
        public event Action SelectFormGN59ButtonClicked;
        public event Action SelectFormGN24ButtonClicked;
        public event Action SelectFormGN75AButtonClicked;
        public event Action SelectFormGN1ButtonClicked;
        public event Action FormGN1CheckBoxCheckChanged;
        public event Action ViewConfiguredDocumentLinkClicked;
        public event Action GroupChanged;
        public event Action ExpireTimeChangedByUser;
        public WorkPermitEdmontonForm()
        {
            InitializeComponent();

            rescuePlanFormNumberTextBox.EnabledChanged += HandleEnabledChanged;

            workPermitEdmontonBusinessLogic = new WorkPermitEdmontonBusinessLogic(this);

            otherAreasAffectedYesRadioButton.CheckedChanged += OtherAreasAffectedOnCheckedChanged;
            otherAreasAffectedNoRadioButton.CheckedChanged += OtherAreasAffectedOnCheckedChanged;

            issuedToContractorCheckBox.CheckedChanged += IssuedToContractorOnCheckedChanged;

            selectFormGN6Button.Click += HandleSelectFormGN6ButtonClick;
            selectFormGN7Button.Click += HandleSelectFormGN7ButtonClick;
            selectFormGN59Button.Click += HandleSelectFormGN59ButtonClick;
            selectFormGN24Button.Click += HandleSelectFormGN24ButtonClick;
            selectFormGN75AButton.Click += HandleSelectFormGN75AButtonClick;
            selectFormGN1Button.Click += HandleSelectFormGN1ButtonClick;

            gn75ACheckBox.CheckedChanged += HandleGN75CheckboxChanged;
            gn1CheckBox.CheckedChanged += HandleGN1CheckBoxChanged;

            viewConfiguredDocumentLinkButton.Click += HandleViewConfiguredDocumentLinkButtonClick;

            alkylationEntryCheckBox.CheckedChanged += PermitFormHelper.CheckBoxCheckChanged;
            
            flarePitEntryCheckBox.CheckedChanged += PermitFormHelper.CheckBoxCheckChanged;
            
            confinedSpaceCheckBox.CheckedChanged += PermitFormHelper.CheckBoxCheckChanged;
            rescuePlanCheckBox.CheckedChanged += PermitFormHelper.CheckBoxCheckChanged;
            vehicleEntryCheckBox.CheckedChanged += PermitFormHelper.CheckBoxCheckChanged;
            specialWorkCheckBox.CheckedChanged += PermitFormHelper.CheckBoxCheckChanged;

            //Dharmesh - DMND0009363-OLT - Edmonton Enhancements 2018 - #950322732 - unique and special circumstances - 29-Oct-2018 start
            workersMonitorNumberCheckBox.CheckedChanged += PermitFormHelper.CheckBoxCheckChanged;            //temp seco
            workersMonitorNumberCheckBox.CheckedChanged += HandleworkersMonitorNumberCheckBoxCheckChanged;
            //Dharmesh - DMND0009363-OLT - Edmonton Enhancements 2018 - #950322732 - unique and special circumstances - 29-Oct-2018 start

            radioChannelNumberCheckBox.CheckedChanged += PermitFormHelper.CheckBoxCheckChanged;
            other1CheckBox.CheckedChanged += PermitFormHelper.CheckBoxCheckChanged;
            other2CheckBox.CheckedChanged += PermitFormHelper.CheckBoxCheckChanged;
            other3CheckBox.CheckedChanged += PermitFormHelper.CheckBoxCheckChanged;
            other4CheckBox.CheckedChanged += PermitFormHelper.CheckBoxCheckChanged;
            useCurrentWorkPermitNumberCheckBox.CheckedChanged += HandleUseCurrentWorkPermitNumberCheckBoxCheckChanged;
            roadAccessOnPermitCheckBox.CheckedChanged += PermitFormHelper.CheckBoxCheckChanged;

            permitTypeComboBox.SelectedValueChanged += HandlePermitTypeSelectedValueChanged;
            groupComboBox.SelectedValueChanged += HandlePermitTypeSelectedValueChanged;

            specialWorkCheckBox.CheckedChanged += HandleSpecialWorkTypeChanged;
            //specialWorkTypeComboBox.SelectedValueChanged += HandleSpecialWorkTypeChanged;
            specialWorkComboBox.SelectedValueChanged += HandleSpecialWorkTypeChanged;
            SpecialWorkTypeChangedByUserEventsEnabled = true;

            confinedSpaceClassComboBox.SelectedValueChanged += HandleConfinedSpaceClassChanged;
            confinedSpaceCheckBox.CheckedChanged += HandleConfinedSpaceClassChanged;
            //sarika---DMND0005325-Test2-Scenario3----1/6/2017
            vehicleEntryCheckBox.CheckedChanged += HandleVehicleEntryCheckBoxCheckChanged;
            //sarika ---vehicleEntryCheckBox.CheckedChanged += HandleVehicleEntryCheckBoxCheckChanged;
            continuousGasMonitorCheckBox.CheckedChanged += HandleContinuousGasMonitorCheckBoxCheckChanged;

            //Dharmesh
           
            //Dharmesh
            confinedSpaceCheckBox.CheckedChanged += HandleConfinedSpaceCheckBoxCheckChanged;

            WorkerToProvideGasTestDataChangedByUserEventsEnabled = true;

            PermitFormHelper.SetupSectionNotApplicableToJob(statusOfPipingSectionNotApplicableToJobCheckBox, statusOfPipingEquipmentPanel);
            PermitFormHelper.SetupSectionNotApplicableToJob(confinedSpaceWorkSectionNotApplicableToJobCheckBox, confinedSpaceWorkPanel);
            PermitFormHelper.SetupSectionNotApplicableToJob(gasTestsSectionNotApplicableToJobCheckBox, gasTestsPanel);
            PermitFormHelper.SetupSectionNotApplicableToJob(workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox,
                workersMinimumSafetyRequirementsPanel);

            workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox.CheckedChanged += HandleWorkersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBoxCheckChanged;
            gasTestsSectionNotApplicableToJobCheckBox.CheckedChanged += HandleGasTestsSectionNotApplicableToJobCheckBoxCheckChanged;
            statusOfPipingSectionNotApplicableToJobCheckBox.CheckedChanged += HandleStatusOfPipingSectionNotApplicableToJobCheckBoxCheckChanged;

            //////confinedSpaceWorkSectionNotApplicableToJobCheckBox.CheckedChanged +=
            //    HandleGasTestsSectionNotApplicableToJobCheckBoxCheckChanged;
            validateButton.Click += HandleValidateButtonClicked;
            printPreferencesButton.Click += HandlePrintPreferencesButtonClicked;
            saveAndIssueButton.Click += HandleSaveAndIssueButtonClicked;
            GroupComboBoxChangedByUserEventsEnabled = true;

            expiredTimePicker.ValueChanged += HandleExpiredTimeChanged;
            Disposed += HandleDisposed;

            //mangesh - to enter only numeric character
            //commented as per adity's mail Feb 6,2016- to remove validation
            #region Gas Test section
            //gasTestDataLine1CombustibleGasTextBox.KeyPress += GasTextBox_KeyPress;
            //gasTestDataLine1OxygenTextBox.KeyPress += GasTextBox_KeyPress;
            //gasTestDataLine1ToxicGasTextBox.KeyPress += GasTextBox_KeyPress;

            //gasTestDataLine2CombustibleGasTextBox.KeyPress += GasTextBox_KeyPress;
            //gasTestDataLine2OxygenTextBox.KeyPress += GasTextBox_KeyPress;
            //gasTestDataLine2ToxicGasTextBox.KeyPress += GasTextBox_KeyPress;

            //gasTestDataLine3CombustibleGasTextBox.KeyPress += GasTextBox_KeyPress;
            //gasTestDataLine3OxygenTextBox.KeyPress += GasTextBox_KeyPress;
            //gasTestDataLine3ToxicGasTextBox.KeyPress += GasTextBox_KeyPress;

            //gasTestDataLine4CombustibleGasTextBox.KeyPress += GasTextBox_KeyPress;
            //gasTestDataLine4OxygenTextBox.KeyPress += GasTextBox_KeyPress;
            //gasTestDataLine4ToxicGasTextBox.KeyPress += GasTextBox_KeyPress;
            #endregion

        }

        private void HandleEnabledChanged(object sender, EventArgs e)
        {
            ;
        }

        public bool ConfinedSpaceCheckBoxEnabled
        {
            set { confinedSpaceCheckBox.Enabled = value; }
        }

        public bool RescuePlanCheckBoxEnabled
        {
            set { rescuePlanCheckBox.Enabled = value; }
        }

        private void HandleGroupChanged(object sender, EventArgs e)
        {
            if (GroupChanged != null) GroupChanged();
        }

        private void HandleExpiredTimeChanged(object sender, EventArgs e)
        {
            if (ExpireTimeChangedByUser != null) ExpireTimeChangedByUser();
        }




        private void HandleUseCurrentWorkPermitNumberCheckBoxCheckChanged(object sender, EventArgs e)
        {
            workPermitEdmontonBusinessLogic.HandleUseCurrentWorkPermitNumberCheckBoxCheckChanged();
        }

        public bool AllowEventsToOverrideUserSelectedCheckboxes
        {
            set { workPermitEdmontonBusinessLogic.AllowEventsToOverrideUserSelectedCheckboxes = value; }
        }

        public void ForceExecutionOfBusinessLogic(PermitRequestBasedWorkPermitStatus status)
        {

            workPermitEdmontonBusinessLogic.ForceExecutionOfBusinessLogic();
            HandleSpecialWorkTypeChangedByUser(false);

            if (status == PermitRequestBasedWorkPermitStatus.Requested && EdmontonPermitSpecialWorkType.HighVoltageElectricalWork.Equals(SpecialWorkType))
            {
                CheckHighVoltagePPE();
            }
        }
        public List<Priority> Priorities
        {
            set { priorityComboBox.DataSource = value; }
        }

        public Priority Priority
        {
            get { return (Priority)priorityComboBox.SelectedItem; }
            set { priorityComboBox.SelectedItem = value; }
        }

        private void CheckHighVoltagePPE()
        {
            workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox.Checked = false;
            highVoltagePPECheckBox.Checked = true;
        }

        private void HandleSaveAndIssueButtonClicked(object sender, EventArgs e)
        {
            if (SaveAndIssueButtonClicked != null)
            {
                SaveAndIssueButtonClicked();
            }
        }

        private void HandleValidateButtonClicked(object sender, EventArgs e)
        {
            if (ValidateButtonClicked != null)
            {
                ValidateButtonClicked();
            }
        }

        private void HandleViewConfiguredDocumentLinkButtonClick(object sender, EventArgs e)
        {
            if (ViewConfiguredDocumentLinkClicked != null)
            {
                ViewConfiguredDocumentLinkClicked();
            }
        }

        public void DisableConfiguredDocumentLinks()
        {
            configuredDocumentLinkComboBox.Enabled = false;
            viewConfiguredDocumentLinkButton.Enabled = false;
        }
      public static bool job;
        private void HandlePrintPreferencesButtonClicked(object sender, EventArgs e)
        {

            if (PrintPreferencesButtonClicked != null)
            {
                 job = JobsiteEquipmentInspected;
                PrintPreferencesButtonClicked();
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

        private void HandleSelectFormGN1ButtonClick(object sender, EventArgs e)
        {
            SelectFormGN1ButtonClicked();
        }



        private bool GroupComboBoxChangedByUserEventsEnabled
        {
            set
            {
                if (value)
                {
                    groupComboBox.SelectedValueChanged += HandleGroupChanged;
                }
                else
                {
                    groupComboBox.SelectedValueChanged -= HandleGroupChanged;
                }
            }
        }

        private bool SpecialWorkTypeChangedByUserEventsEnabled
        {
            set
            {
                if (value)
                {
                    specialWorkCheckBox.CheckedChanged += HandleSpecialWorkTypeChangedByUser;
                    //specialWorkTypeComboBox.SelectedValueChanged += HandleSpecialWorkTypeChangedByUser;
                    specialWorkComboBox.SelectedValueChanged += HandleSpecialWorkTypeChangedByUser;
                }
                else
                {
                    specialWorkCheckBox.CheckedChanged -= HandleSpecialWorkTypeChangedByUser;
                    //specialWorkTypeComboBox.SelectedValueChanged -= HandleSpecialWorkTypeChangedByUser;
                    specialWorkComboBox.SelectedValueChanged -= HandleSpecialWorkTypeChangedByUser;
                }
            }
        }

        private bool WorkerToProvideGasTestDataChangedByUserEventsEnabled
        {
            set
            {
                if (value)
                {
                    workerToProvideGasTestDataCheckBox.CheckedChanged += HandleWorkerToProvideGasTestDataCheckChangedByUser;
                }
                else
                {
                    workerToProvideGasTestDataCheckBox.CheckedChanged -= HandleWorkerToProvideGasTestDataCheckChangedByUser;
                }
            }
        }

        public List<DocumentLink> DocumentLinks
        {
            get { return documentLinksControl.DataSource as List<DocumentLink>; }
            set { documentLinksControl.DataSource = value; }
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

        private void HandlePermitTypeSelectedValueChanged(object sender, EventArgs e)
        {
            PermitFormHelper.HandlePermitTypeSelectedValueChanged(permitTypeComboBox, gn59CheckBox, gn59FormNumberTextBox, groupComboBox);
            workPermitEdmontonBusinessLogic.HandlePermitTypeSelectedValueChanged();

        }


        private void HandleGN75CheckboxChanged(object sender, EventArgs e)
        {
            workPermitEdmontonBusinessLogic.HandleGn75SelectedValueChanged();
        }

        private void HandleGN1CheckBoxChanged(object sender, EventArgs e)
        {
            //ConfinedSpaceWorkSectionNotApplicableToJobEnabled =! gn1CheckBox.Checked;
            //ConfinedSpaceWorkSectionNotApplicableToJob  =! gn1CheckBox.Checked;;
            FormGN1CheckBoxCheckChanged();
        }

        private void HandleConfinedSpaceClassChanged(object sender, EventArgs e)
        {
            workPermitEdmontonBusinessLogic.HandleConfinedSpaceClassChanged();
        }

        private void HandleSpecialWorkTypeChangedByUser(object sender, EventArgs e)
        {
            HandleSpecialWorkTypeChangedByUser(true);
        }

        public void HandleSpecialWorkTypeChangedByUser(bool showPopupIfNecessary)
        {
            //EdmontonPermitSpecialWorkType specialWorkType = (EdmontonPermitSpecialWorkType)specialWorkTypeComboBox.SelectedItem;
            //if (specialWorkCheckBox.Checked && EdmontonPermitSpecialWorkType.HighVoltageElectricalWork.Equals(specialWorkType))//TODO
            if (specialWorkCheckBox.Checked && specialWorkComboBox.Text.Equals("High Voltage Electrical Work"))
            {
                workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox.Checked = false;
                continuousGasMonitorCheckBox.Checked = true;

                if (!highVoltagePPECheckBox.Checked && showPopupIfNecessary)
                {
                    DialogResult result = OltMessageBox.Show(
                        ParentForm,
                        StringResources.WorkPermitEdmonton_IsHighVoltagePPEElectricalRequired,
                        StringResources.WorkPermitEdmonton_IsHighVoltagePPEElectricalRequired_Title,
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (result.Equals(DialogResult.Yes))
                    {
                        CheckHighVoltagePPE();
                    }
                }
            }
        }

        private void HandleSpecialWorkTypeChanged(object sender, EventArgs e)
        {
            workPermitEdmontonBusinessLogic.HandleSpecialWorkTypeChanged();
        }

        private void HandleRoadAccessOnPermitChanged(object sender, EventArgs e)
        {
            workPermitEdmontonBusinessLogic.HandleRoadAccessOnPermitChanged();
        }

        private void HandleVehicleEntryCheckBoxCheckChanged(object sender, EventArgs e)
        {
            workPermitEdmontonBusinessLogic.HandleVehicleEntryCheckBoxCheckChanged();
        }

        private void HandleContinuousGasMonitorCheckBoxCheckChanged(object sender, EventArgs e)
        {
            workPermitEdmontonBusinessLogic.HandleContinuousGasMonitorCheckBoxCheckChanged();
        }
        //Dharmesh - DMND0009363-OLT - Edmonton Enhancements 2018 - #950322732 - unique and special circumstances - 29-Oct-2018 start
        private void HandleworkersMonitorNumberCheckBoxCheckChanged(object sender, EventArgs e)
        {
            workPermitEdmontonBusinessLogic.HandleworkersMonitorNumberCheckBoxCheckChanged();
        }
        //Dharmesh - DMND0009363-OLT - Edmonton Enhancements 2018 - #950322732 - unique and special circumstances - 29-Oct-2018 start
        private void HandleConfinedSpaceCheckBoxCheckChanged(object sender, EventArgs e)
        {
            workPermitEdmontonBusinessLogic.HandleConfinedSpaceCheckBoxCheckChanged();
        }

        private void HandleWorkersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBoxCheckChanged(object sender, EventArgs e)
        {
            workPermitEdmontonBusinessLogic.HandleWorkersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBoxCheckChanged();
        }

        private void HandleGasTestsSectionNotApplicableToJobCheckBoxCheckChanged(object sender, EventArgs e)
        {
            workPermitEdmontonBusinessLogic.HandleGasTestsSectionNotApplicableToJobCheckBoxCheckChanged();
        }

        private void HandleStatusOfPipingSectionNotApplicableToJobCheckBoxCheckChanged(object sender, EventArgs e)
        {
            workPermitEdmontonBusinessLogic.HandleStatusOfPipingEquipmentNotApplicabletoJobCheckBoxCheckChanged(!permitNumberValue.Text.IsNullOrEmptyOrWhitespace());
            //ayman edmonton work permit
            if (statusOfPipingSectionNotApplicableToJobCheckBox.Checked)
            {
                jobsiteEquipmentInspectedNoRadioButton.Checked = true;
                jobsiteEquipmentInspectedYesRadioButton.Checked = false;
            }
            else
            {
                jobsiteEquipmentInspectedNoRadioButton.Checked = false;
                jobsiteEquipmentInspectedYesRadioButton.Checked = true;
            }


        }

        private void HandleWorkerToProvideGasTestDataCheckChangedByUser(object sender, EventArgs eventArgs)
        {
            if (workerToProvideGasTestDataCheckBox.Checked)
            {
                operatorGasDetectorNumberTextBox.Text = StringResources.WorkerToProvideGasTest;
            }
            else if (operatorGasDetectorNumberTextBox.Text == StringResources.WorkerToProvideGasTest)
            {
                operatorGasDetectorNumberTextBox.Text = null;
            }
        }

        public List<string> AlkylationEntryClassOfClothingSelectionList
        {
            set { classOfClothingComboBox.DataSource = value; }
        }

        public List<string> FlarePitEntryTypeSelectionList
        {
            set
            {
                flarePitEntryTypeComboBox.DataSource = value;
            }
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

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            PopulateYesNoNotApplicableDropDowns();
            PopulateYesNotApplicableDropDowns();
            PopulateConfinedSpaceWorkDropDowns();

            if (FormLoad != null)
            {
                FormLoad();
            }
            //Dharmesh - DMND0009363-OLT - Edmonton Enhancements 2018 - #950322732 - Remove -- gas testing - 17-Oct-2018 start
            gasTestDataLine3CombustibleGasTextBox.Visible = false;
            gasTestDataLine3OxygenTextBox.Visible = false;
            gasTestDataLine3ToxicGasTextBox.Visible = false;
            gasTestDataLine3TimePicker.Visible = false;
            //Dharmesh - DMND0009363-OLT - Edmonton Enhancements 2018 - #950322732 - Remove -- gas testing - 17-Oct-2018 end

        }

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

        private void IssuedToContractorOnCheckedChanged(object sender, EventArgs e)
        {
            contractorComboBox.Enabled = issuedToContractorCheckBox.Checked;
        }

        public List<WorkPermitEdmontonType> AllPermitTypes
        {
            set
            {
                permitTypeComboBox.DataSource = value;
                permitTypeComboBox.DisplayMember = "Name";
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
            set
            {
                GroupComboBoxChangedByUserEventsEnabled = false;
                groupComboBox.DataSource = value;
                GroupComboBoxChangedByUserEventsEnabled = true;
            }
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

        public List<SpecialWork> AllSpecialWorkType
        {
            set
            {
                specialWorkComboBox.DataSource = value;
                specialWorkComboBox.DisplayMember = "CompanyName";
                SpecialWorkTypeChangedByUserEventsEnabled = true;
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


        public List<string> AllAffectedAreas
        {
            set
            {
                areaComboBox.DataSource = value;
            }
        }

        public bool SaveAndIssueButtonEnabled
        {
            set { saveAndIssueButton.Enabled = value; }
        }

        public WorkPermitEdmontonGroup Group
        {
            get { return (WorkPermitEdmontonGroup)groupComboBox.SelectedItem; }
            set
            {
                GroupComboBoxChangedByUserEventsEnabled = false;
                groupComboBox.SelectedItem = value;
                GroupComboBoxChangedByUserEventsEnabled = true;
            }
        }

        public WorkPermitEdmontonType WorkPermitType
        {
            get { return (WorkPermitEdmontonType)permitTypeComboBox.SelectedItem; }
            set { permitTypeComboBox.SelectedItem = value; }
        }

        public bool DurationPermit
        {
            get { return durationPermitCheckBox.Checked; }
            set { durationPermitCheckBox.Checked = value; }
        }

        public string Description
        {
            get { return descriptionTextBox.Text; }
            set { descriptionTextBox.Text = value; }
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

        public YesNoNotApplicable QuestionOneResponse
        {
            get { return (YesNoNotApplicable)questionOneResponseComboBox.SelectedItem; }
            set { questionOneResponseComboBox.SelectedItem = value; }
        }

        public YesNoNotApplicable QuestionTwoResponse
        {
            get { return (YesNoNotApplicable)questionTwoResponseComboBox.SelectedItem; }
            set { questionTwoResponseComboBox.SelectedItem = value; }

        }

        public YesNoNotApplicable QuestionTwoAResponse
        {
            get { return (YesNoNotApplicable)questionTwoAResponseComboBox.SelectedItem; }
            set { questionTwoAResponseComboBox.SelectedItem = value; }
        }

        public YesNoNotApplicable QuestionTwoBResponse
        {
            get { return (YesNoNotApplicable)questionTwoBResponseComboBox.SelectedItem; }
            set { questionTwoBResponseComboBox.SelectedItem = value; }
        }

        public YesNoNotApplicable QuestionThreeResponse
        {
            get { return (YesNoNotApplicable)questionThreeResponseComboBox.SelectedItem; }
            set { questionThreeResponseComboBox.SelectedItem = value; }
        }

        public YesNoNotApplicable QuestionFourResponse
        {
            get { return (YesNoNotApplicable)questionFourResponseComboBox.SelectedItem; }
            set { questionFourResponseComboBox.SelectedItem = value; }
        }

        public YesNoNotApplicable DepressuredDrained
        {
            get
            {
                return GetYesNoNotApplicableComboBoxValueForSection(depressuredDrainedComboBox, statusOfPipingSectionNotApplicableToJobCheckBox);
            }
            set { SetYesNoNotApplicableComboBoxValueForSection(value, depressuredDrainedComboBox, statusOfPipingSectionNotApplicableToJobCheckBox); }
        }

        public YesNoNotApplicable Ventilated
        {
            get { return GetYesNoNotApplicableComboBoxValueForSection(ventilatedComboBox, statusOfPipingSectionNotApplicableToJobCheckBox); }
            set { SetYesNoNotApplicableComboBoxValueForSection(value, ventilatedComboBox, statusOfPipingSectionNotApplicableToJobCheckBox); }
        }

        public YesNoNotApplicable Purged
        {
            get { return GetYesNoNotApplicableComboBoxValueForSection(purgedComboBox, statusOfPipingSectionNotApplicableToJobCheckBox); }
            set { SetYesNoNotApplicableComboBoxValueForSection(value, purgedComboBox, statusOfPipingSectionNotApplicableToJobCheckBox); }
        }

        public YesNoNotApplicable BlindedAndTagged
        {
            get { return GetYesNoNotApplicableComboBoxValueForSection(blindedAndTaggedComboBox, statusOfPipingSectionNotApplicableToJobCheckBox); }
            set { SetYesNoNotApplicableComboBoxValueForSection(value, blindedAndTaggedComboBox, statusOfPipingSectionNotApplicableToJobCheckBox); }
        }

        public YesNoNotApplicable DoubleBlockAndBleed
        {
            get { return GetYesNoNotApplicableComboBoxValueForSection(doubleBlockAndBleedComboBox, statusOfPipingSectionNotApplicableToJobCheckBox); }
            set { SetYesNoNotApplicableComboBoxValueForSection(value, doubleBlockAndBleedComboBox, statusOfPipingSectionNotApplicableToJobCheckBox); }
        }

        public YesNoNotApplicable ElectricalLockout
        {
            get { return GetYesNoNotApplicableComboBoxValueForSection(electricalLockoutComboBox, statusOfPipingSectionNotApplicableToJobCheckBox); }
            set { SetYesNoNotApplicableComboBoxValueForSection(value, electricalLockoutComboBox, statusOfPipingSectionNotApplicableToJobCheckBox); }
        }

        public YesNoNotApplicable MechanicalLockout
        {
            get { return GetYesNoNotApplicableComboBoxValueForSection(mechanicalLockoutComboBox, statusOfPipingSectionNotApplicableToJobCheckBox); }
            set { SetYesNoNotApplicableComboBoxValueForSection(value, mechanicalLockoutComboBox, statusOfPipingSectionNotApplicableToJobCheckBox); }
        }

        public YesNoNotApplicable BlindSchematicAvailable
        {
            get { return GetYesNoNotApplicableComboBoxValueForSection(blindSchematicAvailableComboBox, statusOfPipingSectionNotApplicableToJobCheckBox); }
            set { SetYesNoNotApplicableComboBoxValueForSection(value, blindSchematicAvailableComboBox, statusOfPipingSectionNotApplicableToJobCheckBox); }
        }

        public string ZeroEnergyFormNumber
        {
            get
            {
                return GetTextBoxValueForSection(zeroEnergyFormNumberTextBox, statusOfPipingSectionNotApplicableToJobCheckBox);
            }
            set { SetTextBoxValueForSection(value, zeroEnergyFormNumberTextBox, statusOfPipingSectionNotApplicableToJobCheckBox); }
        }

        public bool UseCurrentPermitNumberForZeroEnergyFormNumber
        {
            get { return PermitFormHelper.GetCheckBoxValueForSection(useCurrentWorkPermitNumberCheckBox, statusOfPipingSectionNotApplicableToJobCheckBox); }
            set { PermitFormHelper.SetCheckBoxValueForSection(value, useCurrentWorkPermitNumberCheckBox, statusOfPipingSectionNotApplicableToJobCheckBox); }
        }

        public string LockBoxNumber
        {
            get { return GetTextBoxValueForSection(lockBoxNumberTextBox, statusOfPipingSectionNotApplicableToJobCheckBox); }
            set { SetTextBoxValueForSection(value, lockBoxNumberTextBox, statusOfPipingSectionNotApplicableToJobCheckBox); }
        }

        public bool JobsiteEquipmentInspected
        {
            get { return jobsiteEquipmentInspectedYesRadioButton.Checked; }
            set
            {
                jobsiteEquipmentInspectedYesRadioButton.Checked = value;
                jobsiteEquipmentInspectedNoRadioButton.Checked = !value;
            }
        }

        public string OperatorGasDetectorNumber
        {
            get
            {
                return GetTextBoxValueForSection(operatorGasDetectorNumberTextBox, gasTestsSectionNotApplicableToJobCheckBox);
            }
            set { SetTextBoxValueForSection(value, operatorGasDetectorNumberTextBox, gasTestsSectionNotApplicableToJobCheckBox); }
        }

        private bool AreaAffectedEnabled
        {
            set { areaComboBox.Enabled = value; }
        }

        private bool PersonNotifiedEnabled
        {
            set { personNotifiedTextBox.Enabled = value; }
        }

        public DateTime ExpiryDateTime
        {
            get
            {
                Date date = expiredDatePicker.Value;
                Time time = expiredTimePicker.Value;

                return date.CreateDateTime(time);
            }
            set
            {
                expiredDatePicker.Value = new Date(value);
                expiredTimePicker.ValueChanged -= HandleExpiredTimeChanged;
                expiredTimePicker.Value = new Time(value);
                expiredTimePicker.ValueChanged += HandleExpiredTimeChanged;
            }
        }

        public bool IssuedToSuncor
        {
            get { return issuedToSuncorCheckBox.Checked; }
            set { issuedToSuncorCheckBox.Checked = value; }
        }

        public bool IssuedToContractor
        {
            get { return issuedToContractorCheckBox.Checked; }
            set { issuedToContractorCheckBox.Checked = value; }
        }

        public int? NumberOfWorkers
        {
            get { return numberOfWorkersTextBox.IntegerValue; }
            set { numberOfWorkersTextBox.IntegerValue = value; }
        }

        public bool AlkylationEntry
        {
            get { return alkylationEntryCheckBox.Checked; }
            set { alkylationEntryCheckBox.Checked = value; }
        }

        public string Occupation
        {
            get { return occupationComboBox.Text; }
            set { occupationComboBox.Text = value; }
        }

        public string AlkylationEntryClassOfClothing
        {
            get { return PermitFormHelper.GetTextComboBoxValue(classOfClothingComboBox, alkylationEntryCheckBox); }
            set { classOfClothingComboBox.Text = value; }
        }

        public string ProductNormallyInPipingEquipment
        {
            get
            {
                return GetTextBoxValueForSection(productNormallyInPipingEquipmentTextBox,
                                              statusOfPipingSectionNotApplicableToJobCheckBox);
            }
            set
            {
                SetTextBoxValueForSection(value, productNormallyInPipingEquipmentTextBox,
                                          statusOfPipingSectionNotApplicableToJobCheckBox);
            }
        }

        public YesNoNotApplicable IsolationValvesLocked
        {
            get
            {
                return GetYesNoNotApplicableComboBoxValueForSection(isolationValvesLockedComboBox,
                                               statusOfPipingSectionNotApplicableToJobCheckBox);
            }
            set
            {
                SetYesNoNotApplicableComboBoxValueForSection(value, isolationValvesLockedComboBox,
                                           statusOfPipingSectionNotApplicableToJobCheckBox);
            }
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

        public bool FlarePitEntry
        {
            get { return flarePitEntryCheckBox.Checked; }
            set { flarePitEntryCheckBox.Checked = value; }
        }

        public string FlarePitEntryType
        {
            get { return PermitFormHelper.GetTextComboBoxValue(flarePitEntryTypeComboBox, flarePitEntryCheckBox); }
            set { flarePitEntryTypeComboBox.Text = value; }
        }
        
        public DateTime RequestedStartDateTime
        {
            get
            {
                Date date = requestedStartDatePicker.Value;
                Time time = requestedStartTimePicker.Value;

                return date.CreateDateTime(time);
            }

            set
            {
                requestedStartDatePicker.Value = new Date(value);
                requestedStartTimePicker.Value = new Time(value);
            }
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

        public bool RescuePlanFormNumberEnabled
        {
            set { rescuePlanFormNumberTextBox.ReadOnly = !value; }
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
                if (!vehicleEntryCheckBox.Checked)
                {
                    return null;
                }

                return vehicleEntryTotalNumberTextBox.IntegerValue;
            }
            set
            {
                if (value != null)
                {
                    vehicleEntryCheckBox.Checked = true;
                }

                vehicleEntryTotalNumberTextBox.IntegerValue = value;
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
            set
            {
                SpecialWorkTypeChangedByUserEventsEnabled = false;
                specialWorkCheckBox.Checked = value;
                SpecialWorkTypeChangedByUserEventsEnabled = true;
            }
        }

        public string SpecialWorkFormNumber
        {
            get { return PermitFormHelper.GetTextBoxValue(specialWorkFormNumberTextBox, specialWorkCheckBox); }
            set { PermitFormHelper.SetTextBoxValue(value, specialWorkFormNumberTextBox, specialWorkCheckBox); }
        }

        public EdmontonPermitSpecialWorkType SpecialWorkType
        {
            get { return PermitFormHelper.GetSpecialWorkTypeComboBoxValue(specialWorkTypeComboBox, specialWorkCheckBox); }
            set
            {
                SpecialWorkTypeChangedByUserEventsEnabled = false;
                PermitFormHelper.SetSpecialWorkTypeComboBoxValue(value, specialWorkTypeComboBox, specialWorkCheckBox);
                SpecialWorkTypeChangedByUserEventsEnabled = true;
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

        public bool GN7
        {
            get { return gn7CheckBox.Checked; }
            set { gn7CheckBox.Checked = value; }
        }

        public bool GN6
        {
            get { return gn6CheckBox.Checked; }
            set { gn6CheckBox.Checked = value; }
        }

        public bool GN24
        {
            get { return gn24CheckBox.Checked; }
            set { gn24CheckBox.Checked = value; }
        }

        public bool GN75A
        {
            get { return gn75ACheckBox.Checked; }
            set { gn75ACheckBox.Checked = value; }
        }

        public FormGN59 FormGN59
        {
            get
            {
                string textBoxValue = PermitFormHelper.GetTextBoxValue(gn59FormNumberTextBox, gn59CheckBox);
                if (textBoxValue == null)
                {
                    return null;
                }

                return (FormGN59)gn59FormNumberTextBox.Tag;
            }
            set
            {
                PermitFormHelper.SetTextBoxValue(value == null ? null : value.Id.ToString(), gn59FormNumberTextBox, gn59CheckBox);
                gn59FormNumberTextBox.Tag = value;
            }
        }

        public FormGN6 FormGN6
        {
            get
            {
                string textBoxValue = PermitFormHelper.GetTextBoxValue(gn6FormNumberTextBox, gn6CheckBox);
                if (textBoxValue == null)
                {
                    return null;
                }

                return (FormGN6)gn6FormNumberTextBox.Tag;
            }
            set
            {
                PermitFormHelper.SetTextBoxValue(value == null ? null : value.Id.ToString(), gn6FormNumberTextBox, gn6CheckBox);
                gn6FormNumberTextBox.Tag = value;
            }
        }

        public FormGN7 FormGN7
        {
            get
            {
                string textBoxValue = PermitFormHelper.GetTextBoxValue(gn7FormNumberTextBox, gn7CheckBox);
                if (textBoxValue == null)
                {
                    return null;
                }

                return (FormGN7)gn7FormNumberTextBox.Tag;
            }
            set
            {
                PermitFormHelper.SetTextBoxValue(value == null ? null : value.Id.ToString(), gn7FormNumberTextBox, gn7CheckBox);
                gn7FormNumberTextBox.Tag = value;
            }
        }

        public FormGN24 FormGN24
        {
            get
            {
                string textBoxValue = PermitFormHelper.GetTextBoxValue(gn24FormNumberTextBox, gn24CheckBox);
                if (textBoxValue == null)
                {
                    return null;
                }

                return (FormGN24)gn24FormNumberTextBox.Tag;
            }
            set
            {
                PermitFormHelper.SetTextBoxValue(value == null ? null : value.Id.ToString(), gn24FormNumberTextBox, gn24CheckBox);
                gn24FormNumberTextBox.Tag = value;
            }
        }

        public FormGN75A FormGN75A
        {
            get
            {
                string textBoxValue = PermitFormHelper.GetTextBoxValue(gn75AFormNumberTextBox, gn75ACheckBox);
                if (textBoxValue == null)
                {
                    return null;
                }

                return (FormGN75A)gn75AFormNumberTextBox.Tag;
            }
            set
            {
                PermitFormHelper.SetTextBoxValue(value == null ? null : value.Id.ToString(), gn75AFormNumberTextBox, gn75ACheckBox);
                gn75AFormNumberTextBox.Tag = value;
            }
        }

        public bool GN1
        {
            get { return gn1CheckBox.Checked; }
            set
            {
                gn1CheckBox.Checked = value;
                ConfinedSpaceWorkSectionNotApplicableToJobEnabled = !value;
                ConfinedSpaceWorkSectionNotApplicableToJob = !value;

            }
        }

        public FormGN1 FormGN1
        {
            get
            {
                string textBoxValue = PermitFormHelper.GetTextBoxValue(gn1FormNumberTextBox, gn1CheckBox);
                if (textBoxValue == null)
                {
                    return null;
                }

                return (FormGN1)gn1FormNumberTextBox.Tag;
            }
            set
            {
                gn1FormNumberTextBox.Tag = value;
            }
        }

        public string FormGN1TradeChecklistNumber
        {
            get { return PermitFormHelper.GetTextBoxValue(gn1FormNumberTextBox, gn1CheckBox); }
            set { PermitFormHelper.SetTextBoxValue(value, gn1FormNumberTextBox, gn1CheckBox); }
        }

        public long? FormGN1TradeChecklistId { get; set; }

        public WorkPermitSafetyFormState GN11
        {
            get { return (WorkPermitSafetyFormState)gn11ComboBox.SelectedItem; }
            set { gn11ComboBox.SelectedItem = value; }
        }

        public WorkPermitSafetyFormState GN27
        {
            get { return (WorkPermitSafetyFormState)gn27ComboBox.SelectedItem; }
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

        public void SetOtherAreasAndOrUnitsAffected(bool otherAreasAndOrUnitsAffected, string area, string personNotified)
        {
            if (otherAreasAndOrUnitsAffected)
            {
                otherAreasAffectedYesRadioButton.Checked = true;
                otherAreasAffectedNoRadioButton.Checked = false;

                areaComboBox.Text = area;
                personNotifiedTextBox.Text = personNotified;
            }
            else
            {
                otherAreasAffectedYesRadioButton.Checked = false;
                otherAreasAffectedNoRadioButton.Checked = true;

                areaComboBox.Text = null;
                personNotifiedTextBox.Text = null;
            }
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

        private void SetTextBoxValueForSection(string value, TextBox textBox, CheckBox sectionNotApplicableToJobCheckBox)
        {
            PermitFormHelper.SetTextBoxValueForSection(value, textBox, sectionNotApplicableToJobCheckBox);
        }

        private Time GetTimeValueForSection(OltTimePicker timePicker, CheckBox sectionNotApplicableToJobCheckBox)
        {
            if (sectionNotApplicableToJobCheckBox.Checked)
            {
                return null;
            }
            return timePicker.Value;
        }

        private void SetTimeValueForSection(Time value, OltTimePicker timePicker, CheckBox sectionNotApplicableToJobCheckBox)
        {
            timePicker.Value = value;
            if (value != null)
            {
                sectionNotApplicableToJobCheckBox.Checked = false;
            }
        }

        private string GetTextBoxValueForSection(TextBox textBox, CheckBox sectionNotApplicableToJobCheckBox)
        {
            return PermitFormHelper.GetTextBoxValueForSection(textBox, sectionNotApplicableToJobCheckBox);
        }

        public string GasTestDataLine1CombustibleGas
        {
            get { return GetTextBoxValueForSection(gasTestDataLine1CombustibleGasTextBox, gasTestsSectionNotApplicableToJobCheckBox); }
            set { SetTextBoxValueForSection(value, gasTestDataLine1CombustibleGasTextBox, gasTestsSectionNotApplicableToJobCheckBox); }
        }

        public string GasTestDataLine1Oxygen
        {
            get { return GetTextBoxValueForSection(gasTestDataLine1OxygenTextBox, gasTestsSectionNotApplicableToJobCheckBox); }
            set { SetTextBoxValueForSection(value, gasTestDataLine1OxygenTextBox, gasTestsSectionNotApplicableToJobCheckBox); }
        }

        public string GasTestDataLine1ToxicGas
        {
            get { return GetTextBoxValueForSection(gasTestDataLine1ToxicGasTextBox, gasTestsSectionNotApplicableToJobCheckBox); }
            set { SetTextBoxValueForSection(value, gasTestDataLine1ToxicGasTextBox, gasTestsSectionNotApplicableToJobCheckBox); }
        }

        public Time GasTestDataLine1Time
        {
            get { return GetTimeValueForSection(gasTestDataLine1TimePicker, gasTestsSectionNotApplicableToJobCheckBox); }
            set { SetTimeValueForSection(value, gasTestDataLine1TimePicker, gasTestsSectionNotApplicableToJobCheckBox); }
        }

        public string GasTestDataLine2CombustibleGas
        {
            get { return GetTextBoxValueForSection(gasTestDataLine2CombustibleGasTextBox, gasTestsSectionNotApplicableToJobCheckBox); }
            set { SetTextBoxValueForSection(value, gasTestDataLine2CombustibleGasTextBox, gasTestsSectionNotApplicableToJobCheckBox); }
        }

        public string GasTestDataLine2Oxygen
        {
            get { return GetTextBoxValueForSection(gasTestDataLine2OxygenTextBox, gasTestsSectionNotApplicableToJobCheckBox); }
            set { SetTextBoxValueForSection(value, gasTestDataLine2OxygenTextBox, gasTestsSectionNotApplicableToJobCheckBox); }
        }

        public string GasTestDataLine2ToxicGas
        {
            get { return GetTextBoxValueForSection(gasTestDataLine2ToxicGasTextBox, gasTestsSectionNotApplicableToJobCheckBox); }
            set { SetTextBoxValueForSection(value, gasTestDataLine2ToxicGasTextBox, gasTestsSectionNotApplicableToJobCheckBox); }
        }

        public Time GasTestDataLine2Time
        {
            get { return GetTimeValueForSection(gasTestDataLine2TimePicker, gasTestsSectionNotApplicableToJobCheckBox); }
            set { SetTimeValueForSection(value, gasTestDataLine2TimePicker, gasTestsSectionNotApplicableToJobCheckBox); }
        }

        public string GasTestDataLine3CombustibleGas
        {
            get { return GetTextBoxValueForSection(gasTestDataLine3CombustibleGasTextBox, gasTestsSectionNotApplicableToJobCheckBox); }
            set { SetTextBoxValueForSection(value, gasTestDataLine3CombustibleGasTextBox, gasTestsSectionNotApplicableToJobCheckBox); }
        }

        public string GasTestDataLine3Oxygen
        {
            get { return GetTextBoxValueForSection(gasTestDataLine3OxygenTextBox, gasTestsSectionNotApplicableToJobCheckBox); }
            set { SetTextBoxValueForSection(value, gasTestDataLine3OxygenTextBox, gasTestsSectionNotApplicableToJobCheckBox); }
        }

        public string GasTestDataLine3ToxicGas
        {
            get { return GetTextBoxValueForSection(gasTestDataLine3ToxicGasTextBox, gasTestsSectionNotApplicableToJobCheckBox); }
            set { SetTextBoxValueForSection(value, gasTestDataLine3ToxicGasTextBox, gasTestsSectionNotApplicableToJobCheckBox); }
        }

        public Time GasTestDataLine3Time
        {
            get { return GetTimeValueForSection(gasTestDataLine3TimePicker, gasTestsSectionNotApplicableToJobCheckBox); }
            set { SetTimeValueForSection(value, gasTestDataLine3TimePicker, gasTestsSectionNotApplicableToJobCheckBox); }
        }

        public string GasTestDataLine4CombustibleGas
        {
            get { return GetTextBoxValueForSection(gasTestDataLine4CombustibleGasTextBox, gasTestsSectionNotApplicableToJobCheckBox); }
            set { SetTextBoxValueForSection(value, gasTestDataLine4CombustibleGasTextBox, gasTestsSectionNotApplicableToJobCheckBox); }
        }

        public string GasTestDataLine4Oxygen
        {
            get { return GetTextBoxValueForSection(gasTestDataLine4OxygenTextBox, gasTestsSectionNotApplicableToJobCheckBox); }
            set { SetTextBoxValueForSection(value, gasTestDataLine4OxygenTextBox, gasTestsSectionNotApplicableToJobCheckBox); }
        }

        public string GasTestDataLine4ToxicGas
        {
            get { return GetTextBoxValueForSection(gasTestDataLine4ToxicGasTextBox, gasTestsSectionNotApplicableToJobCheckBox); }
            set { SetTextBoxValueForSection(value, gasTestDataLine4ToxicGasTextBox, gasTestsSectionNotApplicableToJobCheckBox); }
        }

        public Time GasTestDataLine4Time
        {
            get { return GetTimeValueForSection(gasTestDataLine4TimePicker, gasTestsSectionNotApplicableToJobCheckBox); }
            set { SetTimeValueForSection(value, gasTestDataLine4TimePicker, gasTestsSectionNotApplicableToJobCheckBox); }
        }

        public bool FaceShield
        {
            get { return PermitFormHelper.GetCheckBoxValueForSection(faceShieldCheckBox, workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox); }
            set { PermitFormHelper.SetCheckBoxValueForSection(value, faceShieldCheckBox, workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox); }
        }

        public bool Goggles
        {
            get { return PermitFormHelper.GetCheckBoxValueForSection(gogglesCheckBox, workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox); }
            set { PermitFormHelper.SetCheckBoxValueForSection(value, gogglesCheckBox, workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox); }
        }

        public bool RubberBoots
        {
            get { return PermitFormHelper.GetCheckBoxValueForSection(rubberBootsCheckBox, workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox); }
            set { PermitFormHelper.SetCheckBoxValueForSection(value, rubberBootsCheckBox, workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox); }
        }

        public bool RubberGloves
        {
            get { return PermitFormHelper.GetCheckBoxValueForSection(rubberGlovesCheckBox, workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox); }
            set { PermitFormHelper.SetCheckBoxValueForSection(value, rubberGlovesCheckBox, workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox); }
        }

        public bool RubberSuit
        {
            get { return PermitFormHelper.GetCheckBoxValueForSection(rubberSuitCheckBox, workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox); }
            set { PermitFormHelper.SetCheckBoxValueForSection(value, rubberSuitCheckBox, workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox); }
        }

        public bool SafetyHarnessLifeline
        {
            get { return PermitFormHelper.GetCheckBoxValueForSection(safetyHarnessLifelineCheckBox, workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox); }
            set { PermitFormHelper.SetCheckBoxValueForSection(value, safetyHarnessLifelineCheckBox, workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox); }
        }

        public bool HighVoltagePPE
        {
            get { return PermitFormHelper.GetCheckBoxValueForSection(highVoltagePPECheckBox, workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox); }
            set { PermitFormHelper.SetCheckBoxValueForSection(value, highVoltagePPECheckBox, workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox); }
        }

        public bool Other1
        {
            get { return PermitFormHelper.GetCheckBoxValueForSection(other1CheckBox, workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox); }
            set { PermitFormHelper.SetCheckBoxValueForSection(value, other1CheckBox, workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox); }
        }

        public String Other1Value
        {
            get
            {
                return PermitFormHelper.GetTextBoxValueForSection(other1TextBox, other1CheckBox,
                                                                  workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox);
            }
            set { PermitFormHelper.SetTextBoxValueForSection(value, other1TextBox, other1CheckBox, workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox); }
        }

        public bool EquipmentGrounded
        {
            get { return PermitFormHelper.GetCheckBoxValueForSection(equipmentGroundedCheckBox, workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox); }
            set { PermitFormHelper.SetCheckBoxValueForSection(value, equipmentGroundedCheckBox, workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox); }
        }

        public bool FireBlanket
        {
            get { return PermitFormHelper.GetCheckBoxValueForSection(fireBlanketCheckBox, workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox); }
            set { PermitFormHelper.SetCheckBoxValueForSection(value, fireBlanketCheckBox, workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox); }
        }

        public bool FireExtinguisher
        {
            get { return PermitFormHelper.GetCheckBoxValueForSection(fireExtinguisherCheckBox, workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox); }
            set { PermitFormHelper.SetCheckBoxValueForSection(value, fireExtinguisherCheckBox, workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox); }
        }

        public bool FireMonitorManned
        {
            get { return PermitFormHelper.GetCheckBoxValueForSection(fireMonitorMannedCheckBox, workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox); }
            set { PermitFormHelper.SetCheckBoxValueForSection(value, fireMonitorMannedCheckBox, workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox); }
        }

        public bool FireWatch
        {
            get { return PermitFormHelper.GetCheckBoxValueForSection(fireWatchCheckBox, workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox); }
            set { PermitFormHelper.SetCheckBoxValueForSection(value, fireWatchCheckBox, workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox); }
        }

        public bool SewersDrainsCovered
        {
            get { return PermitFormHelper.GetCheckBoxValueForSection(sewersDrainsCoveredCheckBox, workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox); }
            set { PermitFormHelper.SetCheckBoxValueForSection(value, sewersDrainsCoveredCheckBox, workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox); }
        }

        public bool SteamHose
        {
            get { return PermitFormHelper.GetCheckBoxValueForSection(steamHoseCheckBox, workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox); }
            set { PermitFormHelper.SetCheckBoxValueForSection(value, steamHoseCheckBox, workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox); }
        }

        public bool Other2
        {
            get { return PermitFormHelper.GetCheckBoxValueForSection(other2CheckBox, workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox); }
            set { PermitFormHelper.SetCheckBoxValueForSection(value, other2CheckBox, workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox); }
        }

        public String Other2Value
        {
            get { return PermitFormHelper.GetTextBoxValueForSection(other2TextBox, other2CheckBox, workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox); }
            set { PermitFormHelper.SetTextBoxValueForSection(value, other2TextBox, other2CheckBox, workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox); }
        }

        public bool AirPurifyingRespirator
        {
            get { return PermitFormHelper.GetCheckBoxValueForSection(airPurifyingRespiratorCheckBox, workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox); }
            set { PermitFormHelper.SetCheckBoxValueForSection(value, airPurifyingRespiratorCheckBox, workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox); }
        }

        public bool BreathingAirApparatus
        {
            get { return PermitFormHelper.GetCheckBoxValueForSection(breathingAirApparatusCheckBox, workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox); }
            set { PermitFormHelper.SetCheckBoxValueForSection(value, breathingAirApparatusCheckBox, workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox); }
        }

        public bool DustMask
        {
            get { return PermitFormHelper.GetCheckBoxValueForSection(dustMaskCheckBox, workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox); }
            set { PermitFormHelper.SetCheckBoxValueForSection(value, dustMaskCheckBox, workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox); }
        }

        public bool LifeSupportSystem
        {
            get { return PermitFormHelper.GetCheckBoxValueForSection(lifeSupportSystemCheckBox, workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox); }
            set { PermitFormHelper.SetCheckBoxValueForSection(value, lifeSupportSystemCheckBox, workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox); }
        }

        public bool SafetyWatch
        {
            get { return PermitFormHelper.GetCheckBoxValueForSection(safetyWatchCheckBox, workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox); }
            set { PermitFormHelper.SetCheckBoxValueForSection(value, safetyWatchCheckBox, workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox); }
        }

        public bool ContinuousGasMonitor
        {
            get { return PermitFormHelper.GetCheckBoxValueForSection(continuousGasMonitorCheckBox, workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox); }
            set { PermitFormHelper.SetCheckBoxValueForSection(value, continuousGasMonitorCheckBox, workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox); }
        }

        public bool WorkersMonitor
        {
            get { return PermitFormHelper.GetCheckBoxValueForSection(workersMonitorNumberCheckBox, workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox); }
            set { PermitFormHelper.SetCheckBoxValueForSection(value, workersMonitorNumberCheckBox, workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox); }
        }

        public string WorkersMonitorNumber
        {
            get { return PermitFormHelper.GetTextBoxValueForSection(workersMonitorNumberTextBox, workersMonitorNumberCheckBox, workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox); }
            set { PermitFormHelper.SetTextBoxValueForSection(value, workersMonitorNumberTextBox, workersMonitorNumberCheckBox, workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox); }
        }

        public bool BumpTestMonitorPriorToUse
        {
            get { return PermitFormHelper.GetCheckBoxValueForSection(bumpTestMonitorPriorToUseCheckBox, workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox); }
            set { PermitFormHelper.SetCheckBoxValueForSection(value, bumpTestMonitorPriorToUseCheckBox, workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox); }
        }

        public bool Other3
        {
            get { return PermitFormHelper.GetCheckBoxValueForSection(other3CheckBox, workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox); }
            set { PermitFormHelper.SetCheckBoxValueForSection(value, other3CheckBox, workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox); }
        }

        public String Other3Value
        {
            get { return PermitFormHelper.GetTextBoxValueForSection(other3TextBox, other3CheckBox, workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox); }
            set { PermitFormHelper.SetTextBoxValueForSection(value, other3TextBox, other3CheckBox, workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox); }
        }

        public bool AirMover
        {
            get { return PermitFormHelper.GetCheckBoxValueForSection(airMoverCheckBox, workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox); }
            set { PermitFormHelper.SetCheckBoxValueForSection(value, airMoverCheckBox, workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox); }
        }

        public bool BarriersSigns
        {
            get { return PermitFormHelper.GetCheckBoxValueForSection(barriersSignsCheckBox, workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox); }
            set { PermitFormHelper.SetCheckBoxValueForSection(value, barriersSignsCheckBox, workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox); }
        }

        public bool RadioChannel
        {
            get { return PermitFormHelper.GetCheckBoxValueForSection(radioChannelNumberCheckBox, workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox); }
            set { PermitFormHelper.SetCheckBoxValueForSection(value, radioChannelNumberCheckBox, workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox); }
        }

        public string RadioChannelNumber
        {
            get
            {
                return PermitFormHelper.GetTextBoxValueForSection(radioChannelNumberTextBox, radioChannelNumberCheckBox, workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox);
            }
            set
            {
                PermitFormHelper.SetTextBoxValueForSection(value, radioChannelNumberTextBox, radioChannelNumberCheckBox, workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox);
            }
        }

        public bool AirHorn
        {
            get { return PermitFormHelper.GetCheckBoxValueForSection(airHornCheckBox, workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox); }
            set { PermitFormHelper.SetCheckBoxValueForSection(value, airHornCheckBox, workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox); }
        }

        public bool MechVentilationComfortOnly
        {
            get { return PermitFormHelper.GetCheckBoxValueForSection(mechVentilationComfortOnlyCheckBox, workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox); }
            set { PermitFormHelper.SetCheckBoxValueForSection(value, mechVentilationComfortOnlyCheckBox, workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox); }
        }

        public bool AsbestosMMCPrecautions
        {
            get { return PermitFormHelper.GetCheckBoxValueForSection(asbestosMmfPrecautionsCheckBox, workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox); }
            set { PermitFormHelper.SetCheckBoxValueForSection(value, asbestosMmfPrecautionsCheckBox, workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox); }
        }

        public bool Other4
        {
            get { return PermitFormHelper.GetCheckBoxValueForSection(other4CheckBox, workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox); }
            set { PermitFormHelper.SetCheckBoxValueForSection(value, other4CheckBox, workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox); }
        }

        public String Other4Value
        {
            get { return PermitFormHelper.GetTextBoxValueForSection(other4TextBox, other4CheckBox, workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox); }
            set { PermitFormHelper.SetTextBoxValueForSection(value, other4TextBox, other4CheckBox, workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox); }
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

        public bool StatusOfPipingEquipmentSectionNotApplicableToJob
        {
            get { return statusOfPipingSectionNotApplicableToJobCheckBox.Checked; }
            set { statusOfPipingSectionNotApplicableToJobCheckBox.Checked = value; }
        }

        public bool ConfinedSpaceWorkSectionNotApplicableToJob
        {
            get { return confinedSpaceWorkSectionNotApplicableToJobCheckBox.Checked; }
            set { confinedSpaceWorkSectionNotApplicableToJobCheckBox.Checked = value; }
        }

        public bool GasTestsSectionNotApplicableToJob
        {
            get { return gasTestsSectionNotApplicableToJobCheckBox.Checked; }
            set { gasTestsSectionNotApplicableToJobCheckBox.Checked = value; }
        }

        public bool WorkerToProvideGasTestData
        {
            get { return PermitFormHelper.GetCheckBoxValueForSection(workerToProvideGasTestDataCheckBox, gasTestsSectionNotApplicableToJobCheckBox); }
            set
            {
                WorkerToProvideGasTestDataChangedByUserEventsEnabled = false;
                PermitFormHelper.SetCheckBoxValueForSection(value, workerToProvideGasTestDataCheckBox, gasTestsSectionNotApplicableToJobCheckBox);
                WorkerToProvideGasTestDataChangedByUserEventsEnabled = true;
            }
        }

        public bool WorkerToProvideGasTestDataEnabled
        {
            get { return workerToProvideGasTestDataCheckBox.Enabled; }
            set { workerToProvideGasTestDataCheckBox.Enabled = value; }
        }

        public bool WorkersMinimumSafetyRequirementsSectionNotApplicableToJob
        {
            get { return workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox.Checked; }
            set { workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox.Checked = value; }
        }

        public DateTime LastModifiedDateTime
        {
            set { oltLastModifiedDateAuthorHeader1.LastModifiedDate = value; }
        }

        public User LastModifiedBy
        {
            set { oltLastModifiedDateAuthorHeader1.LastModifiedUser = value; }
        }

        private void PopulateYesNoNotApplicableDropDowns()
        {
            List<ComboBox> comboBoxes = new List<ComboBox> { 
                isolationValvesLockedComboBox,
                depressuredDrainedComboBox,
                ventilatedComboBox,
                purgedComboBox,
                blindedAndTaggedComboBox,
                doubleBlockAndBleedComboBox,
                electricalLockoutComboBox,
                mechanicalLockoutComboBox
            };

            List<YesNoNotApplicable> values = new List<YesNoNotApplicable> { YesNoNotApplicable.NOT_APPLICABLE, YesNoNotApplicable.YES, YesNoNotApplicable.NO };
            foreach (ComboBox comboBox in comboBoxes)
            {
                comboBox.DataSource = new List<YesNoNotApplicable>(values);
            }
        }

        private void PopulateYesNotApplicableDropDowns()
        {
            List<YesNoNotApplicable> values = new List<YesNoNotApplicable> { YesNoNotApplicable.NOT_APPLICABLE, YesNoNotApplicable.YES };
            blindSchematicAvailableComboBox.DataSource = new List<YesNoNotApplicable>(values);
        }

        private void PopulateConfinedSpaceWorkDropDowns()
        {
            List<YesNoNotApplicable> yesNotApplicable = new List<YesNoNotApplicable> { YesNoNotApplicable.NOT_APPLICABLE, YesNoNotApplicable.YES };
            List<YesNoNotApplicable> yesNoNotApplicable = new List<YesNoNotApplicable> { YesNoNotApplicable.NOT_APPLICABLE, YesNoNotApplicable.YES, YesNoNotApplicable.NO };
            List<YesNoNotApplicable> yesBlank = new List<YesNoNotApplicable> { YesNoNotApplicable.BLANK, YesNoNotApplicable.YES };

            questionOneResponseComboBox.DataSource = new List<YesNoNotApplicable>(yesBlank);
            questionTwoResponseComboBox.DataSource = new List<YesNoNotApplicable>(yesNoNotApplicable);
            questionTwoAResponseComboBox.DataSource = new List<YesNoNotApplicable>(yesNotApplicable);
            questionTwoBResponseComboBox.DataSource = new List<YesNoNotApplicable>(yesNotApplicable);
            questionThreeResponseComboBox.DataSource = new List<YesNoNotApplicable>(yesNotApplicable);
            questionFourResponseComboBox.DataSource = new List<YesNoNotApplicable>(yesNoNotApplicable);
        }

        public void ShowIsValidMessageBox()
        {
            string title = StringResources.WorkPermitEdmonton_Validation_IsValidTitle;
            string message = StringResources.WorkPermitEdmonton_Validation_IsValid;
            OltMessageBox.Show(this, message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        public void ShowHasValidationWarningsAndErrorsMessageBox()
        {
            string title = StringResources.WorkPermit_IncompleteWorkPermit;
            string message = StringResources.WorkPermit_Validation_WarningsAndErrorsMessage;
            OltMessageBox.Show(this, message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public DialogResult ShowWarnings(WorkPermitEdmontonOtherWarnings otherWarnings, bool validationWarning)
        {
            string messageOne = StringResources.WarningsListBox_MessageOne;
            string messageTwo = StringResources.WarningsListBox_MessageTwo;

            List<string> warnings = otherWarnings.Warnings(validationWarning);
            return OltListMessageBox.Show(this, messageOne, messageTwo, warnings, StringResources.WarningsListBox_Title,
                                          MessageBoxIcon.Warning, false);
        }

        public void ShowFlocNeedsToBeSelectedMessage()
        {
            OltMessageBox.Show(
                this,
                StringResources.WorkPermitEdmonton_NeedToChooseFlocInOrderToViewHazards);
        }

        public void SetErrorForNoContractor()
        {
            warningProvider.SetError(contractorComboBox, StringResources.WorkPermitEdmonton_ContractorEmpty);
        }

        public void SetErrorForNumberOfWorkersLessThanOrEqualToZero()
        {
            warningProvider.SetError(numberOfWorkersTextBox, StringResources.WorkPermitEdmonton_NumberOfWorkersIsLessThanOrEqualtoZero);
        }

        public void SetErrorForNoAreaAffected()
        {
            warningProvider.SetError(areaComboBox, StringResources.WorkPermitEdmonton_AreaAffectedEmpty);
        }

        public void SetErrorForNoPersonNotified()
        {
            warningProvider.SetError(personNotifiedTextBox, StringResources.WorkPermitEdmonton_PersonNotifiedEmpty);
        }

        public void SetErrorForStartDateTimeNotBeforeEndDateTime()
        {
            ClearAutosetIndicatorsForDateTimes(); // This is because the two icons conflict
            warningProvider.SetError(expiredTimePicker, StringResources.RequestedStartDateBeforeExpiredDate);
        }

        public void SetErrorForExpiryDateTimeInThePast()
        {
            ClearAutosetIndicatorsForDateTimes(); // This is because the two icons conflict
            warningProvider.SetError(expiredTimePicker, StringResources.DateCannotBeInThePast);
        }

        public void SetErrorForNoIssuedToOptionSelected()
        {
            warningProvider.SetError(contractorComboBox, StringResources.WorkPermitEdmonton_NoIssuedToOptionChosen);
        }

        public void SetErrorForNoHazardsAndOrRequirements()
        {
            warningProvider.SetError(hazardsAndOrRequirementsTextBox, StringResources.WorkPermitEdmonton_HazardsAndOrRequirementsEmpty);
        }

        public void SetErrorForNoFireProtectiveMeasuresChosenButTypeIsHighEnergyHotWork()
        {
            warningProvider.SetError(workersMinimumSafetyRequirementsGroupBox, StringResources.WorkPermitEdmonton_FireProtectiveMeasureItemNotSelectedButTypeIsHighEnergyHotWork);
        }

        public void SetErrorForQuestionOneNotSetToYes()
        {
            warningProvider.SetError(questionOneResponseComboBox, StringResources.WorkPermitEdmonton_QuestionNotAnsweredYes);
        }

        public void SetErrorForHazardsTooLong()
        {
            warningProvider.SetError(hazardsAndOrRequirementsTextBox, StringResources.WorkPermit_HazardsTooLong);
        }
        //Start Minlge Story #4002, Change By : Swapnil, Changed On : 30 Mar 2016
        public string oltlabel43
        {
            get { return oltLabel43.ToString(); }
            set { oltLabel43.Text = value; }
        }
        // End Minlge Story #4002, Change By : Swapnil, Changed On : 30 Mar 2016

        //Changes for SNOW Incident # INC0025434 On 18Aug2016 by Dharmesh_s
        public bool IsEdit
        {
            get;
            set;
        }
        public bool IsClone
        {
            get;
            set;
        }
        //Changes for SNOW Incident # INC0025434 On 18Aug2016 by Dharmesh_s


        public bool RadioChannelChecked
        {
            get { return radioChannelNumberCheckBox.Checked; }
            set { radioChannelNumberCheckBox.Checked = value; }
        }

        public bool RadioChannelEnabled
        {
            get { return radioChannelNumberCheckBox.Enabled; }
            set { radioChannelNumberCheckBox.Enabled = value; }
        }

        public bool SafetyWatchEnabled
        {
            get { return safetyWatchCheckBox.Enabled; }
            set { safetyWatchCheckBox.Enabled = value; }
        }

        public bool BarriersSignsEnabled
        {
            get { return barriersSignsCheckBox.Enabled; }
            set { barriersSignsCheckBox.Enabled = value; }
        }
        /// <summary>
        /// Mingle # 4001, Added on April 1, 2016 by mangesh
        /// </summary>
        public bool ContinuousGasMonitorChecked
        {
            get { return continuousGasMonitorCheckBox.Checked; }
            set { continuousGasMonitorCheckBox.Checked = value; }
        }

        public bool ContinuousGasMonitorEnabled
        {
            get { return continuousGasMonitorCheckBox.Enabled; }
            set { continuousGasMonitorCheckBox.Enabled = value; }
        }

        public bool GasTestsSectionNotApplicableToJobEnabled
        {
            get { return gasTestsSectionNotApplicableToJobCheckBox.Enabled; }
            set { gasTestsSectionNotApplicableToJobCheckBox.Enabled = value; }
        }

        public bool WorkersMinimumSafetyRequirementsSectionNotApplicableToJobEnabled
        {
            get { return workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox.Enabled; }
            set { workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox.Enabled = value; }
        }

        public bool WorkersMonitorEnabled
        {
            get { return workersMonitorNumberCheckBox.Enabled; }
            set { workersMonitorNumberCheckBox.Enabled = value; }
        }

        public bool BumpTestMonitorPriorToUseEnabled
        {
            get { return bumpTestMonitorPriorToUseCheckBox.Enabled; }
            set { bumpTestMonitorPriorToUseCheckBox.Enabled = value; }
        }

        public bool ConfinedSpaceWorkSectionNotApplicableToJobEnabled
        {
            get { return confinedSpaceWorkSectionNotApplicableToJobCheckBox.Enabled; }
            set { confinedSpaceWorkSectionNotApplicableToJobCheckBox.Enabled = value; }
        }

        public bool RescuePlanEnabled
        {
            get { return rescuePlanCheckBox.Enabled; }
            set { rescuePlanCheckBox.Enabled = value; }
        }

        public bool BreathingAirApparatusEnabled
        {
            get { return breathingAirApparatusCheckBox.Enabled; }
            set { breathingAirApparatusCheckBox.Enabled = value; }
        }

        public bool StatusOfPipingEquipmentSectionNotApplicableToJobEnabled
        {
            get { return statusOfPipingSectionNotApplicableToJobCheckBox.Enabled; }
            set { statusOfPipingSectionNotApplicableToJobCheckBox.Enabled = value; }
        }

        public bool AirHornEnabled
        {
            get { return airHornCheckBox.Enabled; }
            set { airHornCheckBox.Enabled = value; }
        }

        public void SetErrorForNoOccupation()
        {
            warningProvider.SetError(occupationComboBox, StringResources.WorkPermitEdmonton_OccupationEmpty);
        }

        public void SetErrorForNoGroup()
        {
            warningProvider.SetError(groupComboBox, StringResources.WorkPermit_GroupEmpty);
        }

        public void SetErrorForNoLocation()
        {
            warningProvider.SetError(locationTextBox, StringResources.WorkPermit_LocationEmpty);
        }

        public void SetErrorForNoProductNormallyInPipingEquipment()
        {
            warningProvider.SetError(productNormallyInPipingEquipmentTextBox, StringResources.WorkPermitEdmonton_FieldEmptyButSectionApplicableToJob);
        }

        public void SetErrorForNoSafetyRequirementChosen()
        {
            warningProvider.SetError(workersMinimumSafetyRequirementsGroupBox, StringResources.WorkPermitEdmonton_NoSafetyRequirementChosen);
        }

        public void SetErrorForNoWorkersMonitorNumber()
        {
            warningProvider.SetError(workersMonitorNumberTextBox, StringResources.WorkPermit_FieldEmptyButChecked);
        }

        public void SetErrorForNoRadioChannelNumber()
        {
            warningProvider.SetError(radioChannelNumberTextBox, StringResources.WorkPermit_FieldEmptyButChecked);
        }

        public void SetErrorForOther1CheckedWithNoValue()
        {
            warningProvider.SetError(other1TextBox, StringResources.WorkPermit_FieldEmptyButChecked);
        }

        public void SetErrorForOther2CheckedWithNoValue()
        {
            warningProvider.SetError(other2TextBox, StringResources.WorkPermit_FieldEmptyButChecked);
        }

        public void SetErrorForOther3CheckedWithNoValue()
        {
            warningProvider.SetError(other3TextBox, StringResources.WorkPermit_FieldEmptyButChecked);
        }

        public void SetErrorForOther4CheckedWithNoValue()
        {
            warningProvider.SetError(other4TextBox, StringResources.WorkPermit_FieldEmptyButChecked);
        }

        public void SetErrorForAtLeastOneGasTestsTableLineMustBeFilledOut()
        {
            warningProvider.SetError(gasTestsTimeHeaderPanel, StringResources.WorkPermitEdmonton_AtLeastOneGasTestLineMustBeFilledOut);
        }

        public void SetErrorForGasTestsTableLine1IsInvalid()
        {
            warningProvider.SetError(gasTestDataLine1TimePicker, StringResources.WorkPermitEdmonton_AllGasTestsValuesMustBeFilledOut);
        }

        public void SetErrorForGasTestsTableLine2IsInvalid()
        {
            warningProvider.SetError(gasTestDataLine2TimePicker, StringResources.WorkPermitEdmonton_AllGasTestsValuesMustBeFilledOut);
        }

        public void SetErrorForGasTestsTableLine3IsInvalid()
        {
            warningProvider.SetError(gasTestDataLine3TimePicker, StringResources.WorkPermitEdmonton_AllGasTestsValuesMustBeFilledOut);
        }

        public void SetErrorForGasTestsTableLine4IsInvalid()
        {
            warningProvider.SetError(gasTestDataLine4TimePicker, StringResources.WorkPermitEdmonton_AllGasTestsValuesMustBeFilledOut);
        }

        public void SetErrorForNoOperatorGasDetectorNumber()
        {
            warningProvider.SetError(operatorGasDetectorNumberTextBox, StringResources.WorkPermitEdmonton_NoOperatorGasDetectorNumber);
        }

        public void SetErrorForNoClassOfClothing()
        {
            warningProvider.SetError(classOfClothingComboBox, StringResources.WorkPermit_FieldEmptyButChecked);
        }

        public void SetErrorForNoFlarePitEntryType()
        {
            warningProvider.SetError(flarePitEntryTypeComboBox, StringResources.WorkPermit_FieldEmptyButChecked);
        }
        

        public void SetErrorForNoConfinedSpaceCardNumber()
        {
            warningProvider.SetError(confinedSpaceCardNumberTextBox, StringResources.WorkPermit_FieldEmptyButChecked);
        }

        public void SetErrorForNoConfinedSpaceClass()
        {
            warningProvider.SetError(confinedSpaceClassComboBox, StringResources.WorkPermit_FieldEmptyButChecked);
        }

        public void SetErrorForNoRescuePlanFormNumber()
        {
            warningProvider.SetError(rescuePlanFormNumberTextBox, StringResources.WorkPermit_FieldEmptyButChecked);
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


        public void SetErrorForNoVehicleEntryTotalNumber()
        {
            warningProvider.SetError(vehicleEntryTotalNumberTextBox, StringResources.WorkPermit_FieldEmptyButChecked);
        }

        public void SetErrorForInvalidGN11Value()
        {
            warningProvider.SetError(gn11ComboBox, StringResources.WorkPermitEdmonton_FormFieldMustBeApprovedOrNotApplicable);
        }

        public void SetErrorForInvalidGN27Value()
        {
            warningProvider.SetError(gn27ComboBox, StringResources.WorkPermitEdmonton_FormFieldMustBeApprovedOrNotApplicable);
        }

        public void SetErrorForNoApprovedGN59Form()
        {
            warningProvider.SetError(selectFormGN59Button, StringResources.WorkPermitEdmonton_GN59NeedsApproval);
        }

        public void SetErrorForNoApprovedGN6Form()
        {
            warningProvider.SetError(selectFormGN6Button, StringResources.WorkPermitEdmonton_GN6NeedsApproval);
        }

        public void SetErrorForNoApprovedGN7Form()
        {
            warningProvider.SetError(selectFormGN7Button, StringResources.WorkPermitEdmonton_GN7NeedsApproval);
        }

        public void SetErrorForNoApprovedGN24Form()
        {
            warningProvider.SetError(selectFormGN24Button, StringResources.WorkPermitEdmonton_GN24NeedsApproval);
        }

        public void SetErrorForNoApprovedGN75AForm()
        {
            warningProvider.SetError(selectFormGN75AButton, StringResources.WorkPermitEdmonton_GN75ANeedsApproval);
        }

        public void SetErrorForNoApprovedGN1Form()
        {
            warningProvider.SetError(selectFormGN1Button, StringResources.WorkPermitEdmonton_GN1NeedsApproval);
        }

        //Start Minlge Story #3323, Change By : Swapnil, Changed On : 14 Apr 2016
        public void ActionForValidTradeCheckGN1Form()
        {
            warningProvider.SetError(selectFormGN1Button, StringResources.WorkPermitEdmonton_GN1NeedsValidTradeCheckList);
        }
        //End Minlge Story #3323, Change By : Swapnil, Changed On : 14 Apr 2016

        public void ActionForGroupMaintenance() // Swapnil Patki For DMND0005325 Point Number 9
        {
            errorProvider.SetError(shiftSupervisorComboBox, StringResources.WorkPermitEdmonton_AuthorizationForSupervisorOrApprover);//mangesh - message changed
        }

        public void ClearErrorProviders()
        {
            errorProvider.Clear();
            warningProvider.Clear();
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

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (SaveButtonClicked != null)
            {
                SaveButtonClicked(sender, e);
            }
        }

        private void functionalLocationBrowseButton_Click(object sender, EventArgs e)
        {
            if (FunctionalLocationBrowseClicked != null)
            {
                FunctionalLocationBrowseClicked();
            }
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

        public FunctionalLocation ShowSecondLevelOrLowerFunctionalLocationSelector()
        {
            DialogResult result = functionalLocationSelectorForm.ShowDialog(this);
            return result == DialogResult.OK ? functionalLocationSelectorForm.SelectedFunctionalLocation : null;
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

        public string ConfinedSpaceCardNumber
        {
            get { return PermitFormHelper.GetTextBoxValue(confinedSpaceCardNumberTextBox, confinedSpaceCheckBox); }
            set { PermitFormHelper.SetTextBoxValue(value, confinedSpaceCardNumberTextBox, confinedSpaceCheckBox); }
        }

        public bool ConfinedSpaceClassEnabled
        {
            set { confinedSpaceClassComboBox.Enabled = value; }
        }

        public bool ConfinedSpaceCardNumberEnabled
        {
            set { confinedSpaceCardNumberTextBox.ReadOnly = !value; }
        }

        public string PermitNumber
        {
            get { return permitNumberValue.Text.EmptyToNull(); }
            set { permitNumberValue.Text = value.NullToEmpty(); }
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

        public bool ZeroEnergyFormNumberEnabled
        {
            get { return zeroEnergyFormNumberTextBox.Enabled; }
            set { zeroEnergyFormNumberTextBox.Enabled = value; }
        }

        public bool UseCurrentWorkPermitNumberEnabled
        {
            get { return useCurrentWorkPermitNumberCheckBox.Enabled; }
            set { useCurrentWorkPermitNumberCheckBox.Enabled = value; }
        }

        public void OpenFileOrDirectoryOrWebsite(string path)
        {
            FileUtility.OpenFileOrDirectoryOrWebsite(path);
        }

        public string PermitAcceptor
        {
            get { return permitAcceptorField.Text.EmptyToNull(); }
            set { permitAcceptorField.Text = value; }
        }

        public string ShiftSupervisor
        {
            get { return shiftSupervisorComboBox.Text.EmptyToNull(); }
            set { shiftSupervisorComboBox.Text = value; }
        }

        public List<string> ShiftSupervisorSelectionList
        {
            set { shiftSupervisorComboBox.DataSource = value; }
        }

        private void WorkPermitEdmontonForm_ResizeEnd(object sender, EventArgs e)
        {
            UpdateMaximumSize();
        }

        private void WorkPermitEdmontonForm_Shown(object sender, EventArgs e)
        {
            UpdateMaximumSize();
        }

        private void UpdateMaximumSize()
        {
            Screen screen = Screen.FromControl(this);
            Size size = screen.WorkingArea.Size;
            if (size.Height > size.Width)
            {
                // Screen is turned size-ways, re-set the maximums.
                MaximumSize = new Size(MaximumSize.Width, size.Height);
            }
            else
            {
                MaximumSize = new Size(MaximumSize.Width, size.Height);
            }
        }

        public void TurnOnAutosetIndicatorsForDateTimes()
        {
            infoProvider.SetError(expiredTimePicker, StringResources.AutosetWorkPermitDateTimesInfoMessage);
        }

        public void ClearAutosetIndicatorsForDateTimes()
        {
            infoProvider.Clear();
        }

        public void DisplayInvalidPrintMessage(string message)
        {
            OltMessageBox.Show(ActiveForm, message, StringResources.WorkPermitPrintFailureMessageBoxCaption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        public void DisplayErrorMessageDialog(string message, string title)
        {
            OltMessageBox.Show(ActiveForm, message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            get { return (AreaLabel)areaLabelComboBox.SelectedItem; }
            set { areaLabelComboBox.SelectedItem = value; }
        }

        private YesNoNotApplicable GetYesNoNotApplicableComboBoxValueForSection(ComboBox comboBox, CheckBox sectionNotApplicableToJobCheckBox)
        {
            return PermitFormHelper.GetYesNoNotApplicableComboBoxValueForSection(comboBox, sectionNotApplicableToJobCheckBox);
        }

        private void SetYesNoNotApplicableComboBoxValueForSection(YesNoNotApplicable value, ComboBox comboBox, CheckBox sectionNotApplicableToJobCheckBox)
        {
            PermitFormHelper.SetYesNoNotApplicableComboBoxValueForSection(value, comboBox, sectionNotApplicableToJobCheckBox);
        }

        //mangesh - to enter only numeric character
        void GasTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                OltMessageBox.Show(this, "Please enter only numbers.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (e.KeyChar == 22)
                e.Handled = true;
            if (sender != null)
            {
                // only allow one decimal point
                if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
                {
                    e.Handled = true;
                }
            }
        }

        //mangesh - for numeric field
        public void SetErrorForNoAlphaNumeric(string name)
        {
            if (name == "GasTestDataLine1CombustibleGas") errorProvider.SetError(gasTestDataLine1CombustibleGasTextBox, StringResources.WorkPermit_OnlyNumeric);
            if (name == "GasTestDataLine2CombustibleGas") errorProvider.SetError(gasTestDataLine2CombustibleGasTextBox, StringResources.WorkPermit_OnlyNumeric);
            if (name == "GasTestDataLine3CombustibleGas") errorProvider.SetError(gasTestDataLine3CombustibleGasTextBox, StringResources.WorkPermit_OnlyNumeric);
            if (name == "GasTestDataLine4CombustibleGas") errorProvider.SetError(gasTestDataLine4CombustibleGasTextBox, StringResources.WorkPermit_OnlyNumeric);

            if (name == "GasTestDataLine1Oxygen") errorProvider.SetError(gasTestDataLine1OxygenTextBox, StringResources.WorkPermit_OnlyNumeric);
            if (name == "GasTestDataLine2Oxygen") errorProvider.SetError(gasTestDataLine2OxygenTextBox, StringResources.WorkPermit_OnlyNumeric);
            if (name == "GasTestDataLine3Oxygen") errorProvider.SetError(gasTestDataLine3OxygenTextBox, StringResources.WorkPermit_OnlyNumeric);
            if (name == "GasTestDataLine4Oxygen") errorProvider.SetError(gasTestDataLine4OxygenTextBox, StringResources.WorkPermit_OnlyNumeric);

            if (name == "GasTestDataLine1ToxicGas") errorProvider.SetError(gasTestDataLine1ToxicGasTextBox, StringResources.WorkPermit_OnlyNumeric);
            if (name == "GasTestDataLine2ToxicGas") errorProvider.SetError(gasTestDataLine2ToxicGasTextBox, StringResources.WorkPermit_OnlyNumeric);
            if (name == "GasTestDataLine3ToxicGas") errorProvider.SetError(gasTestDataLine3ToxicGasTextBox, StringResources.WorkPermit_OnlyNumeric);
            if (name == "GasTestDataLine4ToxicGas") errorProvider.SetError(gasTestDataLine4ToxicGasTextBox, StringResources.WorkPermit_OnlyNumeric);
        }


        public string ClonedFormDetailEdmonton { get; set; } // Added by Vibhor : DMND0011077 - Work Permit Clone History

//Added By Vibhor : DMND0010779 : OLT - Templateeasy clone
        public string TemplateName { get; set; }
        public bool IsTemplate { get; set; }
        public bool IsActiveTemplate { get; set; }
    }
}