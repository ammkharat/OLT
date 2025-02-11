﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using Com.Suncor.Olt.Client.Forms;

namespace Com.Suncor.Olt.Client.Controls.Details
{
    public partial class WorkPermitEdmontonDetails : AbstractDetails, IWorkPermitEdmontonDetails
    {
        public event EventHandler ExportAll;
        public event EventHandler Edit;
        public event EventHandler ViewEditHistory;
        public event EventHandler Delete;
        public event EventHandler CloseWorkPermit;
        public event EventHandler Clone;
        public event EventHandler ViewAssociatedLogs;
        public event EventHandler Merge;        

        public event EventHandler Print;
        public event EventHandler PrintPreview;

        public event EventHandler ViewAttachment;

        public event EventHandler EditTemplate;

//Added By Vibhor : DMND0010779 : OLT - Templateeasy clone
        public event EventHandler MarkAsTemplate;
        public event EventHandler UnMarkTemplate;
        public event EventHandler RefreshAll;

        private readonly Dictionary<Control, int> originalControlHeights = new Dictionary<Control, int>();

        public WorkPermitEdmontonDetails()
        {
            InitializeComponent();

            cloneButton.Click += CloneButtonClicked;
            closeButton.Click += CloseButtonClicked;
            printButton.Click += PrintButtonClicked;
            printPreviewButton.Click += PrintPreviewButtonClicked;
            historyButton.Click += HistoryButtonClicked;
            deleteButton.Click += DeleteButtonClicked;
            viewAssociatedLogsButton.Click += ViewAssociatedLogsButtonClicked;
            mergeButton.Click += MergeClicked;
            exportAllButton.Click += ExportButtonClicked;

            editTemplateButon.Click += editTemplate_Click;

//Added By Vibhor : DMND0010779 : OLT - Templateeasy clone
            marktemplateButton.Click += marktemplateButton_Click;
            

            detailsPanel.Layout += HandleMainPanelLayout;

            Disposed += HandleDisposed;
        }

        private void ExportButtonClicked(object sender, EventArgs e)
        {
            if (ExportAll != null)
            {
                ExportAll(this, e);
            }            
        }

        private void MergeClicked(object sender, EventArgs e)
        {
            if (Merge != null)
            {
                Merge(this, e);
            }
        }

        private void ViewAssociatedLogsButtonClicked(object sender, EventArgs e)
        {
            if (ViewAssociatedLogs != null)
            {
                ViewAssociatedLogs(this, e);
            }
        }

        private void HandleDisposed(object sender, EventArgs e)
        {            
            originalControlHeights.Clear();
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

        protected override ToolStripButton ToggleDateRangeButton
        {
            get { return dateRangeToggleButton; }
        }

        public override ToolStripButton SaveGridLayoutButton
        {
            get { return saveLayoutToolStripButton; }
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

        private static void AdjustTextBoxHeightToFitText(TextBox textBox, GroupBox containerGroupBox)
        {
            int oldContainerHeight = containerGroupBox.Height;
            Size size = TextRenderer.MeasureText(textBox.Text, textBox.Font, new Size(textBox.Width, Int32.MaxValue), TextFormatFlags.WordBreak);
            int heightRequired = size.Height + 30;
            if (heightRequired > oldContainerHeight)
            {
                containerGroupBox.Height = heightRequired;
            }
        }
        
        private void HandleMainPanelLayout(object sender, LayoutEventArgs e)
        {
             invisibleLabel.Width = detailsPanel.Width - 25;
        }

        private void HistoryButtonClicked(object sender, EventArgs e)
        {
            if (ViewEditHistory != null)
            {
                ViewEditHistory(this, e);
            }
        }

        private void CloneButtonClicked(object sender, EventArgs e)
        {
            if (Clone != null)
            {
                Clone(this, e);
            }
        }

        private void CloseButtonClicked(object sender, EventArgs e)
        {
            if (CloseWorkPermit != null)
            {
                CloseWorkPermit(this, e);
            }
        }

        private void PrintButtonClicked(object sender, EventArgs e)
        {
            if (Print != null)
            {
                Print(sender, e);
            }
        }

        private void PrintPreviewButtonClicked(object sender, EventArgs e)
        {
            if (PrintPreview != null)
            {
                PrintPreview(sender, e);
            }
        }

        private void DeleteButtonClicked(object sender, EventArgs e)
        {
            if (Delete != null)
            {
                Delete(sender, e);
            }
        }

        protected override Panel Details
        {
            get { return detailsPanel; }
        }
        
        public void CallDefaultButton()
        {
            if (editButton.Enabled)
            {
                editButton_Click(this, new EventArgs());
            }
        }

        public bool PrintEnabled
        {
            set { printButton.Enabled = value; }
        }

        public bool PrintPreviewEnabled
        {
            set { printPreviewButton.Enabled = value; }
        }

        public bool ViewAssociatedLogsEnabled
        {
            set { viewAssociatedLogsButton.Enabled = value; }
        }

        public bool MergeEnabled
        {
            set { mergeButton.Enabled = value; }
        }

        public bool EditEnabled
        {
            set { editButton.Enabled = value; }
        }

        public bool ViewEditHistoryEnabled
        {
            set { historyButton.Enabled = value; }
        }

        public bool DeleteEnabled
        {
            set { deleteButton.Enabled = value; }
        }

        public bool CloseEnabled
        {
            set { closeButton.Enabled = value; }
        }

        public bool CloneEnabled
        {
            set { cloneButton.Enabled = value; }
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            if (Edit != null)
            {
                Edit(sender, e);
            }
        }

        public void SetDetails(WorkPermitEdmonton permit)
        {
            if (permit == null)
            {
                lastModifiedAuthorDataLabel.Text = string.Empty;
                lastModifiedDateDataLabel.Text = string.Empty;

                permitNumberDataValue.Text = string.Empty;

                suncorEnergyCheckBox.Checked = false;

                contractorCheckBox.Checked = false;
                contractorCheckBox.Text = string.Empty;

                occupationDataLabel.Text = string.Empty;
                numberOfWorkersDataLabel.Text = string.Empty;
                groupDataLabel.Text = string.Empty;

                workPermitTypeDataLabel.Text = string.Empty;
                priorityDataLabel.Text = string.Empty;
                durationPermitCheckBox.Checked = false;
                functionalLocationDataLabel.Text = string.Empty;
                locationOfWorkDataLabel.Text = string.Empty;

                classOfClothingDataLabel.Text = string.Empty;

                flarePitEntryTypeDataLabel.Text = string.Empty;

                confinedSpaceClassDataLabel.Text = string.Empty;
                confinedSpaceCardNumberDataLabel.Text = string.Empty;

                rescuePlanFormNumberDataLabel.Text = string.Empty;

                specialWorkTypeDataLabel.Text = string.Empty;
                specialWorkFormNumber.Text = string.Empty;

                roadAccessOnPermitType.Text = string.Empty;
                roadAccessOnPermitFormNo.Text = string.Empty;

                vehicleEntryTotalNumber.Text = string.Empty;
                vehicleEntryTypeDataLabel.Text = string.Empty;

                gn59FormNumberDataLabel.Text = string.Empty;
                gn6FormNumberDataLabel.Text = string.Empty;
                gn7FormNumberDataLabel.Text = string.Empty;
                gn24FormNumberDataLabel.Text = string.Empty;
                gn75AFormNumberDataLabel.Text = string.Empty;

                gn11DataLabel.Text = string.Empty;
                gn27DataLabel.Text = string.Empty;

                requestedStartDataLabel.Text = string.Empty;                
                expiredDataLabel.Text = string.Empty;
                issuedDataLabel.Text = string.Empty;

                workOrderNumberDataLabel.Text = string.Empty;
                operationNumberDataLabel.Text = string.Empty;
                subOperationDataLabel.Text = string.Empty;

                taskDescriptionTextBox.Text = string.Empty;
                hazardsAndOrRequirementsTextBox.Text = string.Empty;

                otherAreasAffectedNoRadioButton.Checked = false;
                otherAreasAffectedYesRadioButton.Checked = false;
                otherAreasAndOrUnitsAffectedAreaDataLabel.Text = string.Empty;
                otherAreasAndOrUnitsAffectedPersonNotifiedDataLabel.Text = string.Empty;

                statusOfPipingEquipmentSectionNotApplicableToJobCheckBox.Checked = false;
                productNormallyInPipingEquipmentDataLabel.Text = string.Empty;
                isolationValvesLockedDataLabel.Text = string.Empty;
                depressuredDrainedDataLabel.Text = string.Empty;
                ventilatedDataLabel.Text = string.Empty;
                purgedDataLabel.Text = string.Empty;
                blindedAndTaggedDataLabel.Text = string.Empty;
                doubleBlockAndBleedDataLabel.Text = string.Empty;
                electricalLockoutDataLabel.Text = string.Empty;
                mechanicalLockoutDataLabel.Text = string.Empty;
                blindSchematicAvailableDataLabel.Text = string.Empty;
                zeroEnergyFormNumberDataLabel.Text = string.Empty;
                lockBoxNumberDataLabel.Text = string.Empty;
                jobsiteEquipmentInspectedAndVerifiedReadyForWorkDataLabel.Text = string.Empty;

                confinedSpaceWorkSectionNotApplicableToJobCheckBox.Checked = false;
                questionOneDataLabel.Text = string.Empty;
                questionTwoDataLabel.Text = string.Empty;
                questionTwoADataLabel.Text = string.Empty;
                questionTwoBDataLabel.Text = string.Empty;
                questionThreeDataLabel.Text = string.Empty;
                questionFourDataLabel.Text = string.Empty;

                gasTestsSectionNotApplicableToJobCheckBox.Checked = false;
                operatorGasDetectorNumberDataLabel.Text = string.Empty;

                gasTestsDataLine1CombustibleGasDataLabel.Text = string.Empty;
                gasTestsDataLine1OxygenDataLabel.Text = string.Empty;
                gasTestsDataLine1ToxicGasDataLabel.Text = string.Empty;
                gasTestsDataLine1TimeDataLabel.Text = string.Empty;

                gasTestsDataLine2CombustibleGasDataLabel.Text = string.Empty;
                gasTestsDataLine2OxygenDataLabel.Text = string.Empty;
                gasTestsDataLine2ToxicGasDataLabel.Text = string.Empty;
                gasTestsDataLine2TimeDataLabel.Text = string.Empty;

                gasTestsDataLine3CombustibleGasDataLabel.Text = string.Empty;
                gasTestsDataLine3OxygenDataLabel.Text = string.Empty;
                gasTestsDataLine3ToxicGasDataLabel.Text = string.Empty;
                gasTestsDataLine3TimeDataLabel.Text = string.Empty;

                gasTestsDataLine4CombustibleGasDataLabel.Text = string.Empty;
                gasTestsDataLine4OxygenDataLabel.Text = string.Empty;
                gasTestsDataLine4ToxicGasDataLabel.Text = string.Empty;
                gasTestsDataLine4TimeDataLabel.Text = string.Empty;    

                documentLinksControl.DataSource = new List<DocumentLink>();
                permitAcceptorDataLabel.Text = string.Empty;
                shiftSupervisorDataLabel.Text = string.Empty;
                areaLabelDataLabel.Text = string.Empty;
            }
            else
            {
                lastModifiedAuthorDataLabel.Text = permit.LastModifiedBy.FullNameWithUserName;
                lastModifiedDateDataLabel.Text = permit.LastModifiedDateTime.ToShortDateAndTimeString();

                permitNumberDataValue.Text = permit.PermitNumber.HasValue ? Convert.ToString(permit.PermitNumber.Value) : string.Empty;

                suncorEnergyCheckBox.Checked = permit.IssuedToSuncor;

                contractorCheckBox.Checked = permit.IssuedToCompany;
                contractorCheckBox.Text = string.Format(StringResources.WorkPermitEdmonton_ContractorDetailLabel, permit.Company);

                occupationDataLabel.Text = permit.Occupation;
                numberOfWorkersDataLabel.Text = permit.NumberOfWorkers.NullableToString();
                groupDataLabel.Text = permit.Group.NullableToString();

                workPermitTypeDataLabel.Text = permit.WorkPermitType.ToString();
                priorityDataLabel.Text = permit.Priority.GetName();
                durationPermitCheckBox.Checked = permit.DurationPermit;
                functionalLocationDataLabel.Text = permit.FunctionalLocation.FullHierarchyWithDescription;
                locationOfWorkDataLabel.Text = permit.Location;

                alkylationEntryCheckBox.Checked = permit.AlkylationEntry;
                classOfClothingDataLabel.Text = permit.AlkylationEntryClassOfClothing;

                flarePitEntryCheckBox.Checked = permit.FlarePitEntry;
                flarePitEntryTypeDataLabel.Text = permit.FlarePitEntryType;

                confinedSpaceCheckBox.Checked = permit.ConfinedSpace;
                confinedSpaceClassDataLabel.Text = permit.ConfinedSpaceClass;
                confinedSpaceCardNumberDataLabel.Text = permit.ConfinedSpaceCardNumber;

                rescuePlanCheckBox.Checked = permit.RescuePlan;
                rescuePlanFormNumberDataLabel.Text = permit.RescuePlanFormNumber;

                specialWorkCheckBox.Checked = permit.SpecialWork;
                //specialWorkTypeDataLabel.Text = permit.SpecialWorkType != null ? permit.SpecialWorkType.Name : string.Empty;
                specialWorkTypeDataLabel.Text = permit.SpecialWorkName;
                specialWorkFormNumber.Text = permit.SpecialWorkFormNumber;

                //mangesh for RoadAccessOnPermit 
                roadAccessOnPermitCheckBox.Checked = permit.RoadAccessOnPermit;
                roadAccessOnPermitType.Text = permit.RoadAccessOnPermitType;
                roadAccessOnPermitFormNo.Text = permit.RoadAccessOnPermitFormNumber;

                vehicleEntryCheckBox.Checked = permit.VehicleEntry;
                vehicleEntryTotalNumber.Text = permit.VehicleEntryTotal.HasValue ? Convert.ToString(permit.VehicleEntryTotal.Value) : string.Empty;
                vehicleEntryTypeDataLabel.Text = permit.VehicleEntryType;

                gn59CheckBox.Checked = permit.GN59;
                gn59FormNumberDataLabel.Text = permit.FormGN59 == null ? string.Empty : permit.FormGN59.FormNumber.ToString();

                gn7CheckBox.Checked = permit.GN7;
                gn7FormNumberDataLabel.Text = permit.FormGN7 == null ? string.Empty : permit.FormGN7.FormNumber.ToString();

                gn24CheckBox.Checked = permit.GN24;
                gn24FormNumberDataLabel.Text = permit.FormGN24 == null ? string.Empty : permit.FormGN24.FormNumber.ToString();

                gn6CheckBox.Checked = permit.GN6;
                gn6FormNumberDataLabel.Text = permit.FormGN6 == null ? string.Empty : permit.FormGN6.FormNumber.ToString();

                gn75ACheckBox.Checked = permit.GN75A;
                gn75AFormNumberDataLabel.Text = permit.FormGN75A == null ? string.Empty : permit.FormGN75A.FormNumber.ToString();

                gn1CheckBox.Checked = permit.GN1;
                gn1FormNumberDataLabel.Text = permit.FormGN1 == null ? string.Empty : permit.FormGN1TradeChecklistDisplayNumber;

                gn11DataLabel.Text = permit.GN11.Name;
                gn27DataLabel.Text = permit.GN27.Name;                

                requestedStartDataLabel.Text = permit.RequestedStartDateTime.ToLongDateAndTimeString();                
                expiredDataLabel.Text = permit.ExpiredDateTime.ToLongDateAndTimeString();
                issuedDataLabel.Text = permit.IssuedDateTime == null ? string.Empty : permit.IssuedDateTime.ToLongDateAndTimeStringOrEmptyString();

                workOrderNumberDataLabel.Text = permit.WorkOrderNumber;
                operationNumberDataLabel.Text = permit.OperationNumber;
                toolTip.SetToolTip(operationNumberGroupBox, permit.OperationNumber);
                subOperationDataLabel.Text = permit.SubOperationNumber;
                toolTip.SetToolTip(subOperationNumberGroupBox, permit.SubOperationNumber);

                taskDescriptionTextBox.Text = permit.TaskDescription;
                hazardsAndOrRequirementsTextBox.Text = permit.HazardsAndOrRequirements;

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

                workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox.Checked = permit.WorkersMinimumSafetyRequirementsSectionNotApplicableToJob;

                faceShieldCheckBox.Checked = permit.FaceShield;
                gogglesCheckBox.Checked = permit.Goggles;
                rubberBootsCheckBox.Checked = permit.RubberBoots;
                rubberGlovesCheckBox.Checked = permit.RubberGloves;
                rubberSuitCheckBox.Checked = permit.RubberSuit;
                safetyHarnessLifelineCheckBox.Checked = permit.SafetyHarnessLifeline;
                highVoltagePPECheckBox.Checked = permit.HighVoltagePPE;
                other1CheckBox.Checked = permit.Other1Checked;
                other1ValueDataLabel.Text = permit.Other1;

                equipmentGroundedCheckBox.Checked = permit.EquipmentGrounded;
                fireBlanketCheckBox.Checked = permit.FireBlanket;
                fireExtinguisherCheckBox.Checked = permit.FireExtinguisher;
                fireMonitorMannedCheckBox.Checked = permit.FireMonitorManned;
                fireWatchCheckBox.Checked = permit.FireWatch;
                sewersDrainsCoveredCheckBox.Checked = permit.SewersDrainsCovered;
                steamHoseCheckBox.Checked = permit.SteamHose;
                other2CheckBox.Checked = permit.Other2Checked;
                other2ValueDataLabel.Text = permit.Other2;

                airPurifyingRespiratorCheckBox.Checked = permit.AirPurifyingRespirator;
                breathingAirApparatusCheckBox.Checked = permit.BreathingAirApparatus;
                dustMaskCheckBox.Checked = permit.DustMask;
                lifeSupportSystemCheckBox.Checked = permit.LifeSupportSystem;
                safetyWatchCheckBox.Checked = permit.SafetyWatch;
                continuousGasMonitorCheckBox.Checked = permit.ContinuousGasMonitor;
                workersMonitorNumberCheckBox.Checked = permit.WorkersMonitor;
                workersMonitorNumberDataLabel.Text = permit.WorkersMonitorNumber;
                bumpTestMonitorPriorToUseCheckBox.Checked = permit.BumpTestMonitorPriorToUse;
                other3CheckBox.Checked = permit.Other3Checked;
                other3ValueDataLabel.Text = permit.Other3;

                airMoverCheckBox.Checked = permit.AirMover;
                barriersSignsCheckBox.Checked = permit.BarriersSigns;
                radioCheckBox.Checked = permit.RadioChannel;
                radioChannelNumberDataLabel.Text = permit.RadioChannelNumber;
                airHornCheckBox.Checked = permit.AirHorn;
                mechVentilationComfortOnlyCheckBox.Checked = permit.MechVentilationComfortOnly;
                asbestosMmfPrecautionsCheckBox.Checked = permit.AsbestosMMCPrecautions;
                other4CheckBox.Checked = permit.Other4Checked;
                other4ValueDataLabel.Text = permit.Other4;

                statusOfPipingEquipmentSectionNotApplicableToJobCheckBox.Checked = permit.StatusOfPipingEquipmentSectionNotApplicableToJob;
                productNormallyInPipingEquipmentDataLabel.Text = permit.ProductNormallyInPipingEquipment;
                isolationValvesLockedDataLabel.Text = YesNoNotApplicable.ToString(permit.IsolationValvesLocked);
                depressuredDrainedDataLabel.Text = YesNoNotApplicable.ToString(permit.DepressuredDrained);
                ventilatedDataLabel.Text = YesNoNotApplicable.ToString(permit.Ventilated);
                purgedDataLabel.Text = YesNoNotApplicable.ToString(permit.Purged);
                blindedAndTaggedDataLabel.Text = YesNoNotApplicable.ToString(permit.BlindedAndTagged);
                doubleBlockAndBleedDataLabel.Text = YesNoNotApplicable.ToString(permit.DoubleBlockAndBleed);
                electricalLockoutDataLabel.Text = YesNoNotApplicable.ToString(permit.ElectricalLockout);
                mechanicalLockoutDataLabel.Text = YesNoNotApplicable.ToString(permit.MechanicalLockout);
                blindSchematicAvailableDataLabel.Text = YesNoNotApplicable.ToString(permit.BlindSchematicAvailable);
                zeroEnergyFormNumberDataLabel.Text = permit.ZeroEnergyFormNumber;
                lockBoxNumberDataLabel.Text = permit.LockBoxNumber;
                jobsiteEquipmentInspectedAndVerifiedReadyForWorkDataLabel.Text = permit.JobsiteEquipmentInspected.BooleanToYesNoString();

                confinedSpaceWorkSectionNotApplicableToJobCheckBox.Checked = permit.ConfinedSpaceWorkSectionNotApplicableToJob;
                questionOneDataLabel.Text = permit.QuestionOneResponse.BoolValue == null ? YesNoNotApplicable.BLANK.ToString() : YesNoNotApplicable.ToString(permit.QuestionOneResponse);
                questionTwoDataLabel.Text = YesNoNotApplicable.ToString(permit.QuestionTwoResponse);
                questionTwoADataLabel.Text = YesNoNotApplicable.ToString(permit.QuestionTwoAResponse);
                questionTwoBDataLabel.Text = YesNoNotApplicable.ToString(permit.QuestionTwoBResponse);
                questionThreeDataLabel.Text = YesNoNotApplicable.ToString(permit.QuestionThreeResponse);
                questionFourDataLabel.Text = YesNoNotApplicable.ToString(permit.QuestionFourResponse);

                gasTestsSectionNotApplicableToJobCheckBox.Checked = permit.GasTestsSectionNotApplicableToJob;
                operatorGasDetectorNumberDataLabel.Text = permit.OperatorGasDetectorNumber;

                gasTestsDataLine1CombustibleGasDataLabel.Text = permit.GasTestDataLine1CombustibleGas;
                gasTestsDataLine1OxygenDataLabel.Text = permit.GasTestDataLine1Oxygen;
                gasTestsDataLine1ToxicGasDataLabel.Text = permit.GasTestDataLine1ToxicGas;
                gasTestsDataLine1TimeDataLabel.Text = permit.GasTestDataLine1Time == null ? string.Empty : permit.GasTestDataLine1Time.ToString();

                gasTestsDataLine2CombustibleGasDataLabel.Text = permit.GasTestDataLine2CombustibleGas;
                gasTestsDataLine2OxygenDataLabel.Text = permit.GasTestDataLine2Oxygen;
                gasTestsDataLine2ToxicGasDataLabel.Text = permit.GasTestDataLine2ToxicGas;
                gasTestsDataLine2TimeDataLabel.Text = permit.GasTestDataLine2Time == null ? string.Empty : permit.GasTestDataLine2Time.ToString();

                gasTestsDataLine3CombustibleGasDataLabel.Text = permit.GasTestDataLine3CombustibleGas;
                gasTestsDataLine3OxygenDataLabel.Text = permit.GasTestDataLine3Oxygen;
                gasTestsDataLine3ToxicGasDataLabel.Text = permit.GasTestDataLine3ToxicGas;
                gasTestsDataLine3TimeDataLabel.Text = permit.GasTestDataLine3Time == null ? string.Empty : permit.GasTestDataLine3Time.ToString();

                gasTestsDataLine4CombustibleGasDataLabel.Text = permit.GasTestDataLine4CombustibleGas;
                gasTestsDataLine4OxygenDataLabel.Text = permit.GasTestDataLine4Oxygen;
                gasTestsDataLine4ToxicGasDataLabel.Text = permit.GasTestDataLine4ToxicGas;
                gasTestsDataLine4TimeDataLabel.Text = permit.GasTestDataLine4Time == null ? string.Empty : permit.GasTestDataLine4Time.ToString();

                documentLinksControl.DataSource = permit.DocumentLinks;
                permitAcceptorDataLabel.Text = permit.PermitAcceptor;
                shiftSupervisorDataLabel.Text = permit.ShiftSupervisor;
                areaLabelDataLabel.Text = permit.AreaLabel == null ? string.Empty : permit.AreaLabel.Name;
            }

            AdjustTextBoxHeights();
        }

       

        // DMND0010609-OLT - Edmonton Work permit Scan
        private void Scanbutton_Click(object sender, EventArgs e)
        {
            if (Convert.ToString((sender as System.Windows.Forms.ToolStripButton).Tag) == "Scan")
            {
                string permitNumber = permitNumberDataValue.Text;
                ScanWorkPermit Scanform = new ScanWorkPermit(permitNumber);
                Scanform.ShowDialog();
            }
            else
            {
                ScanWorkPermit Scanform = new ScanWorkPermit();
                Scanform.ShowDialog();
            }
        }

        private void viewAttachementbutton_Click(object sender, EventArgs e)
        {
            if (ViewAttachment != null)
            {
                ViewAttachment(this, e);
            }
        }
        public bool ViewAttachEnabled
        {
            set { viewAttachementbutton.Enabled = value; }
        }

        public bool ViewScanEnabled
        {
            set { Scanbutton.Enabled = value;}
        }

       public void MakeSeachWindowRequiredButtonsvisibleonly()
        {
            
            mergeButton.Visible = false;
            dateRangeToggleButton.Visible = false;
            exportAllButton.Visible = false;
           saveLayoutToolStripButton.Visible=false;
        }
//Added By Vibhor : DMND0010779 : OLT - Templateeasy clone

       private void marktemplateButton_Click(object sender, EventArgs e)
       {
           if (MarkAsTemplate != null)
           {
               MarkAsTemplate(this, e);
           }
       }
       private void unmarktemplateButton_Click(object sender, EventArgs e)
       {
           if (UnMarkTemplate != null)
           {
               UnMarkTemplate(this, e);
           }
       }

       private void editTemplate_Click(object sender, EventArgs e)
       {
           if (EditTemplate != null)
           {
               EditTemplate(this, e);
           }
       }

       public bool editTemplateVisible
       {
           set { editTemplateButon.Visible = value; }
       }

       public bool MarkTemplateEnabled
       {
           set { marktemplateButton.Visible = value; }
       }
       



       public string TemplateName { get; set; }
       public bool IsTemplate { get; set; }
       public bool IsActiveTemplate { get; set; }

       public bool DeleteVisible
       {
           set { deleteButton.Visible = value; }
       }
       public bool editVisible
       {
           set { editButton.Visible = value; }
       }
       public bool closeButtonVisible
       {
           set { closeButton.Visible = value; }
       }
       public bool printButtonVisible
       {
           set { printButton.Visible = value; }
       }
       public bool printPreviewButtonVisible
       {
           set { printPreviewButton.Visible = value; }
       }
       public bool mergeButtonVisible
       {
           set { mergeButton.Visible = value; }
       }
       public bool viewAssociatedLogsButtonVisible
       {
           set { viewAssociatedLogsButton.Visible = value; }
       }
       public bool historyButtonVisible
       {
           set { historyButton.Visible = value; }
       }
       public bool viewAttachementbuttonVisible
       {
           set { viewAttachementbutton.Visible = value; }
       }
       public bool ScanbuttonVisible
       {
           set { Scanbutton.Visible = value; }
       }
        public bool UnMarkTemplateEnabled
       {
           set {  }
       }

        private void refreshAllButton_Click(object sender, EventArgs e)
        {
            if (RefreshAll != null)
            {
                RefreshAll(this, e);
            }
        }

       
    }
}