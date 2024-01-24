using System;
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
    public partial class WorkPermitLubesDetails : AbstractDetails, IWorkPermitLubesDetails
    {
        public event EventHandler Edit;
        public event EventHandler ViewEditHistory;
        public event EventHandler ExportAll;
        public event EventHandler Delete;
        public event Action Print;
        public event Action Preview;
        public event Action Close;
        public event Action ViewAssociatedLogs;
        public event Action Clone;

        private readonly Dictionary<Control, int> originalControlHeights = new Dictionary<Control, int>();

        public WorkPermitLubesDetails()
        {
            InitializeComponent();

            editButton.Click += HandleEditButtonClick;
            exportAllButton.Click += HandleExportButtonClick;
            historyButton.Click += HandleHistoryButtonClick;
            deleteButton.Click += HandleDeleteButtonClick;
            printButton.Click += HandlePrintButtonClick;
            printPreviewButton.Click += HandlePreviewButtonClick;
            closeButton.Click += HandleCloseButtonClick;
            viewAssociatedLogsButton.Click += HandleViewAssociatedLogsButtonClick;
            cloneButton.Click += HandleCloneButtonClick;

            Disposed += HandleDisposed;
            detailsPanel.Layout += HandleMainPanelLayout;
        }

        private void HandleCloneButtonClick(object sender, EventArgs e)
        {
            if (Clone != null)
            {
                Clone();
            }
        }

        private void HandleViewAssociatedLogsButtonClick(object sender, EventArgs e)
        {
            if (ViewAssociatedLogs != null)
            {
                ViewAssociatedLogs();
            }
        }

        private void HandleCloseButtonClick(object sender, EventArgs e)
        {
            if (Close != null)
            {
                Close();
            }
        }

        private void HandlePreviewButtonClick(object sender, EventArgs e)
        {
            if (Preview != null)
            {
                Preview();
            }
        }

        private void HandlePrintButtonClick(object sender, EventArgs e)
        {
            if (Print != null)
            {
                Print();
            }
        }

        private void HandleDeleteButtonClick(object sender, EventArgs e)
        {
            if (Delete != null)
            {
                Delete(this, EventArgs.Empty);
            }
        }

        private void HandleHistoryButtonClick(object sender, EventArgs e)
        {
            if (ViewEditHistory != null)
            {
                ViewEditHistory(this, e);
            }
        }

        private void HandleMainPanelLayout(object sender, LayoutEventArgs e)
        {
            invisibleLabel.Width = detailsPanel.Width - 25;
        }

        private void HandleDisposed(object sender, EventArgs e)
        {
            originalControlHeights.Clear();
        }

        protected override Panel Details
        {
            get { return detailsPanel; }
        }

        public void CallDefaultButton()
        {
            if (editButton.Enabled)
            {
                HandleEditButtonClick(this, EventArgs.Empty);
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

        public bool EditEnabled
        {
            set { editButton.Enabled = value; }
        }

        public bool ViewEditHistoryEnabled
        {
            set { historyButton.Enabled = value; }
        }

        public bool ViewAssociatedLogsEnabled
        {
            set { viewAssociatedLogsButton.Enabled = value; }
        }

        public bool DeleteEnabled
        {
            set { deleteButton.Enabled = value; }
        }

        public bool CloneEnabled
        {
            set { cloneButton.Enabled = value; }    
        }

        public bool PrintEnabled
        {
            set { printButton.Enabled = value; }
        }

        public bool PrintPreviewEnabled
        {
            set { printPreviewButton.Enabled = value; }
        }

        public bool CloseEnabled
        {
            set { closeButton.Enabled = value; }
        }

        protected override ToolStripButton ToggleDateRangeButton
        {
            get { return dateRangeToggleButton; }
        }

        public void MakeAllButtonsInvisible()
        {
            foreach (ToolStripItem item in toolStrip.Items)
            {
                item.Visible = false;
            }
        }

        public bool EditButtonVisible
        {
            set { editButton.Visible = value; }
        }

        public bool CloseButtonVisible
        {
            set { closeButton.Visible = value; }
        }

        public override ToolStripButton SaveGridLayoutButton
        {
            get { return saveLayoutToolStripButton; }
        }

        public void SetDetails(WorkPermitLubes permit)
        {
            if (permit == null)
            {
                lastModifiedAuthorDataLabel.Text = string.Empty;
                lastModifiedDateDataLabel.Text = string.Empty;
                permitNumberDataValue.Text = string.Empty;

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

                startDateDataLabel.Text = string.Empty;
                expiredDataLabel.Text = string.Empty;
                issuedDataLabel.Text = string.Empty;

                confinedSpaceCheckBox.Checked = false;
                confinedSpaceClassDataLabel.Text = string.Empty;
                rescuePlanCheckBox.Checked = false;
                confinedSpaceSafetyWatchChecklistCheckBox.Checked = false;
                specialWorkCheckBox.Checked = false;
                specialWorkTypeDataLabel.Text = string.Empty;
                hazardousWorkApproverAdvisedCheckBox.Checked = false;
                additionalFollowupRequiredCheckBox.Checked = false;

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

                workPreparationsSectionNotApplicableToJobCheckBox.Checked = false;
                productNormallyInPipingEquipmentDataLabel.Text = string.Empty;

                depressuredDrainedDataLabel.Text = string.Empty;
                waterWashedDataLabel.Text = string.Empty;
                chemicallyWashedDataLabel.Text = string.Empty;
                steamedDataLabel.Text = string.Empty;
                purgedDataLabel.Text = string.Empty;
                disconnectedDataLabel.Text = string.Empty;

                depressuredAndVentedDataLabel.Text = string.Empty;
                ventilatedDataLabel.Text = string.Empty;
                blankedDataLabel.Text = string.Empty;
                drainsCoveredDataLabel.Text = string.Empty;
                areaBarricadedDataLabel.Text = string.Empty;

                energySourcesLockedOutTaggedOutDataLabel.Text = string.Empty;
                energyControlPlanWorkPreparationDataLabel.Text = string.Empty;
                lockBoxNumberDataLabel.Text = string.Empty;
                otherWorkPreparationDataLabel.Text = string.Empty;

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
                atmosphericGasTestRequiredCheckBox.Checked = false;
            }
            else
            {
                lastModifiedAuthorDataLabel.Text = permit.LastModifiedBy.FullNameWithUserName;
                lastModifiedDateDataLabel.Text = permit.LastModifiedDateTime.ToShortDateAndTimeString();
                permitNumberDataValue.Text = permit.PermitNumberDisplayValue;

                suncorEnergyCheckBox.Checked = permit.IssuedToSuncor;
                contractorCheckBox.Checked = permit.IssuedToCompany;
                contractorCheckBox.Text = string.Format(StringResources.WorkPermitLubes_ContractorDetailLabel, permit.Company);

                tradeDataLabel.Text = permit.Trade;
                numberOfWorkersDataLabel.Text = permit.NumberOfWorkers.NullableToString();
                requestedByGroupDataLabel.Text = permit.RequestedByGroup.NullableToString();
                workPermitTypeDataLabel.Text = workPermitTypeDataLabel.Text = WorkPermitLubesType.GetPermitTypeLabel(permit.WorkPermitType, permit.IsVehicleEntry); 

                functionalLocationDataLabel.Text = permit.FunctionalLocation.FullHierarchyWithDescription;
                locationOfWorkDataLabel.Text = permit.Location;

                documentLinksControl.DataSource = permit.DocumentLinks;

                workOrderNumberDataLabel.Text = permit.WorkOrderNumber;
                operationNumberDataLabel.Text = permit.OperationNumber;
                subOperationDataLabel.Text = permit.SubOperationNumber;

                startDateDataLabel.Text = permit.StartDateTime.ToLongDateAndTimeString();
                expiredDataLabel.Text = permit.ExpireDateTime.ToLongDateAndTimeString();
                issuedDataLabel.Text = permit.IssuedDateTime == null ? string.Empty : permit.IssuedDateTime.ToLongDateAndTimeStringOrEmptyString();

                confinedSpaceCheckBox.Checked = permit.ConfinedSpace;
                confinedSpaceClassDataLabel.Text = permit.ConfinedSpaceClass;
                rescuePlanCheckBox.Checked = permit.RescuePlan;
                confinedSpaceSafetyWatchChecklistCheckBox.Checked = permit.ConfinedSpaceSafetyWatchChecklist;
                specialWorkCheckBox.Checked = permit.SpecialWork;
                specialWorkTypeDataLabel.Text = permit.SpecialWorkType ?? string.Empty;
                hazardousWorkApproverAdvisedCheckBox.Checked = permit.HazardousWorkApproverAdvised;
                additionalFollowupRequiredCheckBox.Checked = permit.AdditionalFollowupRequired;

                highEnergyDataLabel.Text = permit.HighEnergy.Name;
                criticalLiftDataLabel.Text = permit.CriticalLift.Name;
                excavationDataLabel.Text = permit.Excavation.Name;
                energyControlPlanDataLabel.Text = permit.EnergyControlPlanFormRequirement.Name;
                equivalencyProcDataLabel.Text = permit.EquivalencyProc.Name;
                testPneumaticDataLabel.Text = permit.TestPneumatic.Name;
                liveFlareWorkDataLabel.Text = permit.LiveFlareWork.Name;
                entryAndControlPlanDataLabel.Text = permit.EntryAndControlPlan.Name;
                energizedElectricalDataLabel.Text = permit.EnergizedElectrical.Name;

                taskDescriptionTextBox.Text = permit.TaskDescription;

                hazardHydrocarbonGasCheckbox.Checked = permit.HazardHydrocarbonGas;
                hazardHydrocarbonLiquidCheckBox.Checked = permit.HazardHydrocarbonLiquid;
                hazardHydrogenSulphideCheckBox.Checked = permit.HazardHydrogenSulphide;
                hazardInertGasAtmosphere.Checked = permit.HazardInertGasAtmosphere;
                hazardOxygenDeficiencyCheckBox.Checked = permit.HazardOxygenDeficiency;
                hazardRadioactiveSourcesCheckbox.Checked = permit.HazardRadioactiveSources;
                hazardUndergroundOverheadCheckBox.Checked = permit.HazardUndergroundOverheadHazards;
                hazardDesignatedSubstanceCheckBox.Checked = permit.HazardDesignatedSubstance;

                hazardsAndOrRequirementsTextBox.Text = permit.OtherHazardsAndOrRequirements;

                if (permit.OtherAreasAndOrUnitsAffected)
                {
                    otherAreasAffectedNoRadioButton.Checked = false;
                    otherAreasAffectedYesRadioButton.Checked = true;
                    otherAreasAndOrUnitsAffectedAreaDataLabel.Text = permit.OtherAreasAndOrUnitsAffectedArea;
                    otherAreasAndOrUnitsAffectedPersonNotifiedDataLabel.Text = permit.OtherAreasAndOrUnitsAffectedPersonNotified;
                }
                else
                {
                    otherAreasAffectedNoRadioButton.Checked = true;
                    otherAreasAffectedYesRadioButton.Checked = false;
                    otherAreasAndOrUnitsAffectedAreaDataLabel.Text = string.Empty;
                    otherAreasAndOrUnitsAffectedPersonNotifiedDataLabel.Text = string.Empty;
                }

                workPreparationsSectionNotApplicableToJobCheckBox.Checked = permit.WorkPreparationsCompletedSectionNotApplicableToJob;
                productNormallyInPipingEquipmentDataLabel.Text = permit.ProductNormallyInPipingEquipment;

                depressuredDrainedDataLabel.Text = YesNoNotApplicable.ToString(permit.DepressuredDrained);
                waterWashedDataLabel.Text = YesNoNotApplicable.ToString(permit.WaterWashed);
                chemicallyWashedDataLabel.Text = YesNoNotApplicable.ToString(permit.ChemicallyWashed);
                steamedDataLabel.Text = YesNoNotApplicable.ToString(permit.Steamed);
                purgedDataLabel.Text = YesNoNotApplicable.ToString(permit.Purged);
                disconnectedDataLabel.Text = YesNoNotApplicable.ToString(permit.Disconnected);

                depressuredAndVentedDataLabel.Text = YesNoNotApplicable.ToString(permit.DepressuredAndVented);
                ventilatedDataLabel.Text = YesNoNotApplicable.ToString(permit.Ventilated);
                blankedDataLabel.Text = YesNoNotApplicable.ToString(permit.Blanked);
                drainsCoveredDataLabel.Text = YesNoNotApplicable.ToString(permit.DrainsCovered);
                areaBarricadedDataLabel.Text = YesNoNotApplicable.ToString(permit.AreaBarricaded);

                energySourcesLockedOutTaggedOutDataLabel.Text = YesNoNotApplicable.ToString(permit.EnergySourcesLockedOutTaggedOut);
                energyControlPlanWorkPreparationDataLabel.Text = permit.EnergyControlPlan;
                lockBoxNumberDataLabel.Text = permit.LockBoxNumber;
                otherWorkPreparationDataLabel.Text = permit.OtherPreparations;

                specificRequirementsSectionNotApplicableToJobCheckBox.Checked = permit.SpecificRequirementsSectionNotApplicableToJob;

                attendedAtAllTimesCheckBox.Checked = permit.AttendedAtAllTimes;
                eyeProtectionCheckBox.Checked = permit.EyeProtection;
                fallProtectionEquipmentCheckBox.Checked = permit.FallProtectionEquipment;
                fullBodyHarnessRetrievalCheckBox.Checked = permit.FullBodyHarnessRetrieval;
                hearingProtectionCheckBox.Checked = permit.HearingProtection;
                protectiveClothingCheckBox.Checked = permit.ProtectiveClothing;
                other1CheckBox.Checked = permit.Other1Checked;
                other1TextBox.Text = permit.Other1Value;

                equipmentBondedGroundedCheckBox.Checked = permit.EquipmentBondedGrounded;
                fireBlanketCheckBox.Checked = permit.FireBlanket;
                fireFightingEquipmentCheckBox.Checked = permit.FireFightingEquipment;
                fireWatchCheckBox.Checked = permit.FireWatch;
                hydrantPermitCheckBox.Checked = permit.HydrantPermit;
                waterHoseCheckBox.Checked = permit.WaterHose;
                steamHoseCheckBox.Checked = permit.SteamHose;
                other2CheckBox.Checked = permit.Other2Checked;
                other2TextBox.Text = permit.Other2Value;

                airMoverCheckBox.Checked = permit.AirMover;
                continuousGasMonitorCheckBox.Checked = permit.ContinuousGasMonitor;
                drowningProtectionCheckBox.Checked = permit.DrowningProtection;
                respiratoryProtectionCheckBox.Checked = permit.RespiratoryProtection;
                other3CheckBox.Checked = permit.Other3Checked;
                other3TextBox.Text = permit.Other3Value;

                additionalLightingCheckBox.Checked = permit.AdditionalLighting;
                designateHotOrColdCutCheckBox.Checked = permit.DesignateHotOrColdCutChecked;
                designateHotOrColdCutTextBox.Text = permit.DesignateHotOrColdCutValue;
                hoistingEquipmentCheckBox.Checked = permit.HoistingEquipment;
                ladderCheckBox.Checked = permit.Ladder;
                motorizedEquipmentCheckBox.Checked = permit.MotorizedEquipment;
                scaffoldCheckBox.Checked = permit.Scaffold;
                referToTipsProcedureCheckBox.Checked = permit.ReferToTipsProcedure;

                gasDetectorBumpTestedCheckBox.Checked = permit.GasDetectorBumpTested;
                atmosphericGasTestRequiredCheckBox.Checked = permit.AtmosphericGasTestRequired;
            }

            AdjustTextBoxHeights();
        }

        private void AdjustTextBoxHeights()
        {
            StoreOriginalHeight(taskDescriptionGroupBox);
            StoreOriginalHeight(hazardsAndOrRequirementsGroupBox);

            taskDescriptionGroupBox.Height = originalControlHeights[taskDescriptionGroupBox];
            hazardsAndOrRequirementsGroupBox.Height = originalControlHeights[hazardsAndOrRequirementsGroupBox];

            AdjustTextBoxHeightToFitText(taskDescriptionTextBox, taskDescriptionGroupBox);
            AdjustTextBoxHeightToFitText(hazardsAndOrRequirementsTextBox, hazardsAndOrRequirementsGroupBox);
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

    }
}
