﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Controls.Details
{
    public partial class PermitRequestLubesDetails : AbstractDetails, IPermitRequestLubesDetails
    {
        public event EventHandler ExportAll;
        public event EventHandler Edit;
        public event EventHandler ViewEditHistory;
        public event EventHandler Delete;
        public event EventHandler Submit;
        public event EventHandler Import;
        public event Action Clone;

        private readonly Dictionary<Control, int> originalControlHeights = new Dictionary<Control, int>();

        public event EventHandler RefreshAll;

        public PermitRequestLubesDetails()
        {
            InitializeComponent();

            editButton.Click += HandleEditButtonClick;
            exportAllButton.Click += HandleExportButtonClick;
            editHistoryButton.Click += HandleHistoryButtonClick;
            importButton.Click += HandleImportButtonClick;
            submitButton.Click += HandleSubmitButtonClick;
            cloneButton.Click += HandleCloneButtonClick;
            deleteButton.Click += HandleDeleteButtonClick;

            Disposed += HandleDisposed;
            detailsPanel.Layout += HandleMainPanelLayout;
        }

        private void HandleDeleteButtonClick(object sender, EventArgs e)
        {
            if (Delete != null)
            {
                Delete(sender, e);
            }
        }

        private void HandleCloneButtonClick(object sender, EventArgs e)
        {
            if (Clone != null)
            {
                Clone();
            }
        }

        private void HandleSubmitButtonClick(object sender, EventArgs e)
        {
            if (Submit != null)
            {
                Submit(sender, e);
            }
        }

        private void HandleMainPanelLayout(object sender, LayoutEventArgs e)
        {
            invisibleLabel.Width = detailsPanel.Width - 25;
        }

        private void HandleHistoryButtonClick(object sender, EventArgs e)
        {
            if (ViewEditHistory != null)
            {
                ViewEditHistory(this, e);
            }
        }

        private void HandleEditButtonClick(object sender, EventArgs e)
        {
            if (Edit != null)
            {
                Edit(sender, e);
            }
        }

        private void HandleExportButtonClick(object sender, EventArgs e)
        {
            if (ExportAll != null)
            {
                ExportAll(this, e);
            }
        }

        private void HandleImportButtonClick(object sender, EventArgs e)
        {
            if (Import != null)
            {                
                Import(this, EventArgs.Empty);
            }
        }

        private void HandleDisposed(object sender, EventArgs e)
        {
            originalControlHeights.Clear();
        }

        public void CallDefaultButton()
        {
            if (editButton.Enabled)
            {
                HandleEditButtonClick(this, EventArgs.Empty);
            }
        }

        public bool EditEnabled
        {
            set { editButton.Enabled = value; }
        }

        public bool CloneEnabled
        {
            set { cloneButton.Enabled = value; }
        }

        public bool ViewEditHistoryEnabled { set { editHistoryButton.Enabled = value; } }
        public bool DeleteEnabled { set { deleteButton.Enabled = value; } }
        public bool SubmitEnabled { set { submitButton.Enabled = value; } }
        public bool ImportEnabled { set { importButton.Enabled = value; } }

        protected override Panel Details
        {
            get { return detailsPanel; }
        }

        protected override ToolStripButton ToggleDateRangeButton
        {
            get { return dateRangeToggleButton; }
        }

        public override ToolStripButton SaveGridLayoutButton
        {
            get { return saveGridLayoutButton; }
        }

        public void SetDetails(PermitRequestLubes permitRequest)
        {
            if (permitRequest == null)
            {
                lastModifiedAuthorDataLabel.Text = string.Empty;
                lastModifiedDateDataLabel.Text = string.Empty;
                lastSubmittedDateDataLabel.Text = string.Empty;
                lastSubmittedUserDataLabel.Text = string.Empty;

                suncorEnergyCheckBox.Checked = false;
                contractorCheckBox.Checked = false;
                contractorCheckBox.Text = string.Empty;

                tradeDataLabel.Text = string.Empty;
                numberOfWorkersDataLabel.Text = string.Empty;
                requestedByGroupDataLabel.Text = string.Empty;
                workPermitTypeDataLabel.Text = string.Empty;

                functionalLocationDataLabel.Text = string.Empty;
                locationOfWorkDataLabel.Text = string.Empty;

                documentLinksControl.DataSource = new List<DocumentLink>();

                workOrderNumberDataLabel.Text = string.Empty;
                operationNumberDataLabel.Text = string.Empty;
                subOperationDataLabel.Text = string.Empty;

                requestedStartDataLabel.Text = string.Empty;
                requestedStartDayCheckBox.Checked = false;
                requestedStartTimeDayDataLabel.Text = string.Empty;

                requestedStartNightCheckBox.Checked = false;
                requestedStartTimeNightDataLabel.Text = string.Empty;

                requestedEndDataLabel.Text = string.Empty;

                confinedSpaceCheckBox.Checked = false;
                confinedSpaceClassDataLabel.Text = string.Empty;
                rescuePlanCheckBox.Checked = false;
                confinedSpaceSafetyWatchChecklistCheckBox.Checked = false;
                specialWorkCheckBox.Checked = false;
                specialWorkTypeDataLabel.Text = string.Empty;

                highEnergyDataLabel.Text = string.Empty;
                criticalLiftDataLabel.Text = string.Empty;
                excavationDataLabel.Text = string.Empty;
                energyControlPlanDataLabel.Text = string.Empty;
                equivalencyProcDataLabel.Text = string.Empty;
                testPneumaticDataLabel.Text = string.Empty;
                liveFlareWorkDataLabel.Text = string.Empty;
                entryAndControlPlanDataLabel.Text = string.Empty;
                energizedElectricalDataLabel.Text = string.Empty;

                taskDescriptionTextBox.Text = string.Empty;
                currentSapDescriptionTextBox.Text = string.Empty;

                hazardHydrocarbonGasCheckbox.Checked = false;
                hazardHydrocarbonLiquidCheckBox.Checked = false;
                hazardHydrogenSulphideCheckBox.Checked = false;
                hazardInertGasAtmosphere.Checked = false;
                hazardOxygenDeficiencyCheckBox.Checked = false;
                hazardRadioactiveSourcesCheckbox.Checked = false;
                hazardUndergroundOverheadCheckBox.Checked = false;
                hazardDesignatedSubstanceCheckBox.Checked = false;

                hazardsAndOrRequirementsTextBox.Text = string.Empty;

                otherAreasAffectedNoRadioButton.Checked = false;
                otherAreasAffectedYesRadioButton.Checked = false;
                otherAreasAndOrUnitsAffectedAreaDataLabel.Text = string.Empty;
                otherAreasAndOrUnitsAffectedPersonNotifiedDataLabel.Text = string.Empty;

                specificRequirementsSectionNotApplicableToJobCheckBox.Checked = false;

                attendedAtAllTimesCheckBox.Checked = false;
                eyeProtectionCheckBox.Checked = false;
                fallProtectionEquipmentCheckBox.Checked = false;
                fullBodyHarnessRetrievalCheckBox.Checked = false;
                hearingProtectionCheckBox.Checked = false;
                protectiveClothingCheckBox.Checked = false;
                other1CheckBox.Checked = false;
                other1TextBox.Text = string.Empty;

                equipmentBondedGroundedCheckBox.Checked = false;
                fireBlanketCheckBox.Checked = false;
                fireFightingEquipmentCheckBox.Checked = false;
                fireWatchCheckBox.Checked = false;
                hydrantPermitCheckBox.Checked = false;
                waterHoseCheckBox.Checked = false;
                steamHoseCheckBox.Checked = false;
                other2CheckBox.Checked = false;
                other2TextBox.Text = string.Empty;

                airMoverCheckBox.Checked = false;
                continuousGasMonitorCheckBox.Checked = false;
                drowningProtectionCheckBox.Checked = false;
                respiratoryProtectionCheckBox.Checked = false;
                other3CheckBox.Checked = false;
                other3TextBox.Text = string.Empty;

                additionalLightingCheckBox.Checked = false;
                designateHotOrColdCutCheckBox.Checked = false;
                designateHotOrColdCutTextBox.Text = string.Empty;
                hoistingEquipmentCheckBox.Checked = false;
                ladderCheckBox.Checked = false;
                motorizedEquipmentCheckBox.Checked = false;
                scaffoldCheckBox.Checked = false;
                referToTipsProcedureCheckBox.Checked = false;

                gasDetectorBumpTestedCheckBox.Checked = false;
            }
            else
            {
                lastModifiedAuthorDataLabel.Text = permitRequest.LastModifiedBy.FullNameWithUserName;
                lastModifiedDateDataLabel.Text = permitRequest.LastModifiedDateTime.ToShortDateAndTimeString();
                lastSubmittedUserDataLabel.Text = permitRequest.LastSubmittedByUser == null ? string.Empty : permitRequest.LastSubmittedByUser.FullNameWithUserName;
                lastSubmittedDateDataLabel.Text = permitRequest.LastSubmittedDateTime.ToShortDateAndTimeStringOrEmptyString();

                suncorEnergyCheckBox.Checked = permitRequest.IssuedToSuncor;
                contractorCheckBox.Checked = permitRequest.IssuedToCompany;
                contractorCheckBox.Text = string.Format(StringResources.WorkPermitLubes_ContractorDetailLabel, permitRequest.Company);

                tradeDataLabel.Text = permitRequest.Trade;
                numberOfWorkersDataLabel.Text = permitRequest.NumberOfWorkers.NullableToString();
                requestedByGroupDataLabel.Text = permitRequest.RequestedByGroup.NullableToString();
                workPermitTypeDataLabel.Text = WorkPermitLubesType.GetPermitTypeLabel(permitRequest.WorkPermitType, permitRequest.IsVehicleEntry); 

                functionalLocationDataLabel.Text = permitRequest.FunctionalLocation.FullHierarchyWithDescription;
                locationOfWorkDataLabel.Text = permitRequest.Location;

                documentLinksControl.DataSource = permitRequest.DocumentLinks;

                workOrderNumberDataLabel.Text = permitRequest.WorkOrderNumber;
                operationNumberDataLabel.Text = permitRequest.OperationNumberListAsString;
                subOperationDataLabel.Text = permitRequest.SubOperationNumberListAsString;

                requestedStartDataLabel.Text = permitRequest.RequestedStartDate.ToString();
                requestedStartDayCheckBox.Checked = permitRequest.RequestedStartTimeDay != null;
                requestedStartTimeDayDataLabel.Text = permitRequest.RequestedStartTimeDay != null
                                                          ? permitRequest.RequestedStartTimeDay.ToString()
                                                          : string.Empty;

                requestedStartNightCheckBox.Checked = permitRequest.RequestedStartTimeNight != null;
                requestedStartTimeNightDataLabel.Text = permitRequest.RequestedStartTimeNight != null
                                          ? permitRequest.RequestedStartTimeNight.ToString()
                                          : string.Empty;

                requestedEndDataLabel.Text = permitRequest.EndDate.ToString();

                confinedSpaceCheckBox.Checked = permitRequest.ConfinedSpace;
                confinedSpaceClassDataLabel.Text = permitRequest.ConfinedSpaceClass;
                rescuePlanCheckBox.Checked = permitRequest.RescuePlan;
                confinedSpaceSafetyWatchChecklistCheckBox.Checked = permitRequest.ConfinedSpaceSafetyWatchChecklist;
                specialWorkCheckBox.Checked = permitRequest.SpecialWork;
                specialWorkTypeDataLabel.Text = permitRequest.SpecialWorkType ?? string.Empty;

                highEnergyDataLabel.Text = permitRequest.HighEnergy.Name;
                criticalLiftDataLabel.Text = permitRequest.CriticalLift.Name;
                excavationDataLabel.Text = permitRequest.Excavation.Name;
                energyControlPlanDataLabel.Text = permitRequest.EnergyControlPlan.Name;
                equivalencyProcDataLabel.Text = permitRequest.EquivalencyProc.Name;
                testPneumaticDataLabel.Text = permitRequest.TestPneumatic.Name;
                liveFlareWorkDataLabel.Text = permitRequest.LiveFlareWork.Name;
                entryAndControlPlanDataLabel.Text = permitRequest.EntryAndControlPlan.Name;
                energizedElectricalDataLabel.Text = permitRequest.EnergizedElectrical.Name;

                taskDescriptionTextBox.Text = permitRequest.Description;
                ShowSapDescription = permitRequest.IsSapDescriptionAvailableForDisplay;
                currentSapDescriptionTextBox.Text = permitRequest.SapDescription;

                hazardHydrocarbonGasCheckbox.Checked = permitRequest.HazardHydrocarbonGas;
                hazardHydrocarbonLiquidCheckBox.Checked = permitRequest.HazardHydrocarbonLiquid;
                hazardHydrogenSulphideCheckBox.Checked = permitRequest.HazardHydrogenSulphide;
                hazardInertGasAtmosphere.Checked = permitRequest.HazardInertGasAtmosphere;
                hazardOxygenDeficiencyCheckBox.Checked = permitRequest.HazardOxygenDeficiency;
                hazardRadioactiveSourcesCheckbox.Checked = permitRequest.HazardRadioactiveSources;
                hazardUndergroundOverheadCheckBox.Checked = permitRequest.HazardUndergroundOverheadHazards;
                hazardDesignatedSubstanceCheckBox.Checked = permitRequest.HazardDesignatedSubstance;

                hazardsAndOrRequirementsTextBox.Text = permitRequest.OtherHazardsAndOrRequirements;

                if (permitRequest.OtherAreasAndOrUnitsAffected)
                {
                    otherAreasAffectedNoRadioButton.Checked = false;
                    otherAreasAffectedYesRadioButton.Checked = true;
                    otherAreasAndOrUnitsAffectedAreaDataLabel.Text = permitRequest.OtherAreasAndOrUnitsAffectedArea;
                    otherAreasAndOrUnitsAffectedPersonNotifiedDataLabel.Text = permitRequest.OtherAreasAndOrUnitsAffectedPersonNotified;
                }
                else
                {
                    otherAreasAffectedNoRadioButton.Checked = true;
                    otherAreasAffectedYesRadioButton.Checked = false;
                    otherAreasAndOrUnitsAffectedAreaDataLabel.Text = string.Empty;
                    otherAreasAndOrUnitsAffectedPersonNotifiedDataLabel.Text = string.Empty;
                }

                specificRequirementsSectionNotApplicableToJobCheckBox.Checked = permitRequest.SpecificRequirementsSectionNotApplicableToJob;

                attendedAtAllTimesCheckBox.Checked = permitRequest.AttendedAtAllTimes;
                eyeProtectionCheckBox.Checked = permitRequest.EyeProtection;
                fallProtectionEquipmentCheckBox.Checked = permitRequest.FallProtectionEquipment;
                fullBodyHarnessRetrievalCheckBox.Checked = permitRequest.FullBodyHarnessRetrieval;
                hearingProtectionCheckBox.Checked = permitRequest.HearingProtection;
                protectiveClothingCheckBox.Checked = permitRequest.ProtectiveClothing;
                other1CheckBox.Checked = permitRequest.Other1Checked;
                other1TextBox.Text = permitRequest.Other1Value;

                equipmentBondedGroundedCheckBox.Checked = permitRequest.EquipmentBondedGrounded;
                fireBlanketCheckBox.Checked = permitRequest.FireBlanket;
                fireFightingEquipmentCheckBox.Checked = permitRequest.FireFightingEquipment;
                fireWatchCheckBox.Checked = permitRequest.FireWatch;
                hydrantPermitCheckBox.Checked = permitRequest.HydrantPermit;
                waterHoseCheckBox.Checked = permitRequest.WaterHose;
                steamHoseCheckBox.Checked = permitRequest.SteamHose;
                other2CheckBox.Checked = permitRequest.Other2Checked;
                other2TextBox.Text = permitRequest.Other2Value;

                airMoverCheckBox.Checked = permitRequest.AirMover;
                continuousGasMonitorCheckBox.Checked = permitRequest.ContinuousGasMonitor;
                drowningProtectionCheckBox.Checked = permitRequest.DrowningProtection;
                respiratoryProtectionCheckBox.Checked = permitRequest.RespiratoryProtection;
                other3CheckBox.Checked = permitRequest.Other3Checked;
                other3TextBox.Text = permitRequest.Other3Value;

                additionalLightingCheckBox.Checked = permitRequest.AdditionalLighting;
                designateHotOrColdCutCheckBox.Checked = permitRequest.DesignateHotOrColdCutChecked;
                designateHotOrColdCutTextBox.Text = permitRequest.DesignateHotOrColdCutValue;
                hoistingEquipmentCheckBox.Checked = permitRequest.HoistingEquipment;
                ladderCheckBox.Checked = permitRequest.Ladder;
                motorizedEquipmentCheckBox.Checked = permitRequest.MotorizedEquipment;
                scaffoldCheckBox.Checked = permitRequest.Scaffold;
                referToTipsProcedureCheckBox.Checked = permitRequest.ReferToTipsProcedure;

                gasDetectorBumpTestedCheckBox.Checked = permitRequest.GasDetectorBumpTested;
            }

            AdjustTextBoxHeights();
        }
     
        private void AdjustTextBoxHeights()
        {
            StoreOriginalHeight(taskDescriptionGroupBox);
            StoreOriginalHeight(hazardsAndOrRequirementsGroupBox);
            StoreOriginalHeight(currentSAPDescriptionGroupBox);

            taskDescriptionGroupBox.Height = originalControlHeights[taskDescriptionGroupBox];
            hazardsAndOrRequirementsGroupBox.Height = originalControlHeights[hazardsAndOrRequirementsGroupBox];
            currentSAPDescriptionGroupBox.Height = originalControlHeights[currentSAPDescriptionGroupBox];

            AdjustTextBoxHeightToFitText(taskDescriptionTextBox, taskDescriptionGroupBox);
            AdjustTextBoxHeightToFitText(hazardsAndOrRequirementsTextBox, hazardsAndOrRequirementsGroupBox);
            AdjustTextBoxHeightToFitText(currentSapDescriptionTextBox, currentSAPDescriptionGroupBox);
        }

        private void StoreOriginalHeight(OltGroupBox control)
        {
            if (!originalControlHeights.ContainsKey(control))
            {
                originalControlHeights.Add(control, control.Height);
            }
        }

        private void AdjustTextBoxHeightToFitText(TextBox textBox, GroupBox containerGroupBox)
        {
            int oldContainerHeight = containerGroupBox.Height;
            Size size = TextRenderer.MeasureText(textBox.Text, textBox.Font, new Size(textBox.Width, Int32.MaxValue), TextFormatFlags.WordBreak);
            int heightRequired = size.Height + 30;
            if (heightRequired > oldContainerHeight)
            {
                containerGroupBox.Height = heightRequired;
            }
        }

        protected bool ShowSapDescription
        {
            set
            {
                currentSAPDescriptionGroupBox.Visible = value;
                currentSapDescriptionTextBox.Visible = value;
            }
        }

//Added By Vibhor : DMND0010779 : OLT - Templateeasy clone
        public event EventHandler MarkAsTemplate;

        public bool MarkTemplateEnabled
        {
            set {  }
        }


        public bool DeleteVisible
        {
            set { }
        }

        public bool editVisible
        {
            set { }
        }

        public bool editHistoryButtonVisible
        {
            set { }
        }

        public bool submitButtonVisible
        {
            set { }
        }
        public bool editTemplateVisible
        {
            set { }
        }

        public event EventHandler EditTemplate;
    }
}
