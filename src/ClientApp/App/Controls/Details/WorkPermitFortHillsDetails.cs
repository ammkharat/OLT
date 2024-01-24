using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;
using log4net.Appender;

namespace Com.Suncor.Olt.Client.Controls.Details
{
    public partial class WorkPermitFortHillsDetails : AbstractDetails, IWorkPermitFortHillsDetails
    {
        public event EventHandler ExportAll;
        public event EventHandler Edit;
        public event EventHandler ViewEditHistory;
        public event EventHandler Delete;
        public event EventHandler CloseWorkPermit;
        public event EventHandler Clone;
        public event EventHandler Extension;
        public event EventHandler Revalidation;
        public event EventHandler ViewAssociatedLogs;
        public event EventHandler Merge;        

        public event EventHandler Print;
        public event EventHandler PrintPreview;

        private readonly Dictionary<Control, int> originalControlHeights = new Dictionary<Control, int>();

        public WorkPermitFortHillsDetails()
        {
            InitializeComponent();

            cloneButton.Click += CloneButtonClicked;
            ExtensionButton.Click += ExtensionButtonClicked;
            closeButton.Click += CloseButtonClicked;
            printButton.Click += PrintButtonClicked;
            printPreviewButton.Click += PrintPreviewButtonClicked;
            historyButton.Click += HistoryButtonClicked;
            deleteButton.Click += DeleteButtonClicked;
            viewAssociatedLogsButton.Click += ViewAssociatedLogsButtonClicked;
            viewAssociatedLogsButton.Click += ViewAssociatedLogsButtonClicked;
            mergeButton.Click += MergeClicked;
            exportAllButton.Click += ExportButtonClicked;
            detailsPanel.Layout += HandleMainPanelLayout;
            revalidationButton.Click += RevalidationButtonClicked;
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

        private void ExtensionButtonClicked(object sender, EventArgs e)
        {
            if (Extension != null)
            {
                Extension(this, e);
            }
        }
            
        private void RevalidationButtonClicked(object sender, EventArgs e)
        {
            if (Revalidation != null)
            {
                Revalidation(this, e);
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
        public bool ViewAssociatedLogsVisible
        {
            set { viewAssociatedLogsButton.Visible = value; }
        }
        public bool ExtensionEnable
        {
            set { ExtensionButton.Enabled = value; }
        }
        public bool RevalidationButtonEnable
        {
            set { revalidationButton.Enabled = value; }
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

        public void SetDetails(WorkPermitFortHills permit)
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
                //durationPermitCheckBox.Checked = false;
                functionalLocationDataLabel.Text = string.Empty;
                locationOfWorkDataLabel.Text = string.Empty;

                confinedSpaceClassDataLabel.Text = string.Empty;
               
                requestedStartDataLabel.Text = string.Empty;                
                expiredDataLabel.Text = string.Empty;
                issuedDataLabel.Text = string.Empty;

                workOrderNumberDataLabel.Text = string.Empty;
                operationNumberDataLabel.Text = string.Empty;
                subOperationDataLabel.Text = string.Empty;

                taskDescriptionTextBox.Text = string.Empty;
                hazardsAndOrRequirementsTextBox.Text = string.Empty;

                //confinedSpaceCardNumberDataLabel.Text = string.Empty;
                //rescuePlanFormNumberDataLabel.Text = string.Empty;
                //specialWorkTypeDataLabel.Text = string.Empty;
                //specialWorkFormNumber.Text = string.Empty;
                //roadAccessOnPermitType.Text = string.Empty;
                //roadAccessOnPermitFormNo.Text = string.Empty;
                //vehicleEntryTotalNumber.Text = string.Empty;
                //vehicleEntryTypeDataLabel.Text = string.Empty;
                //gn59FormNumberDataLabel.Text = string.Empty;
                //gn6FormNumberDataLabel.Text = string.Empty;
                //gn7FormNumberDataLabel.Text = string.Empty;
                //gn24FormNumberDataLabel.Text = string.Empty;
                //gn75AFormNumberDataLabel.Text = string.Empty;
                //gn11DataLabel.Text = string.Empty;
                //gn27DataLabel.Text = string.Empty;
                //classOfClothingDataLabel.Text = string.Empty;
                //flarePitEntryTypeDataLabel.Text = string.Empty;
                //otherAreasAffectedNoRadioButton.Checked = false;
                //otherAreasAffectedYesRadioButton.Checked = false;
                //otherAreasAndOrUnitsAffectedAreaDataLabel.Text = string.Empty;
                //otherAreasAndOrUnitsAffectedPersonNotifiedDataLabel.Text = string.Empty;
                //statusOfPipingEquipmentSectionNotApplicableToJobCheckBox.Checked = false;
                //productNormallyInPipingEquipmentDataLabel.Text = string.Empty;
                //isolationValvesLockedDataLabel.Text = string.Empty;
                //depressuredDrainedDataLabel.Text = string.Empty;
                //ventilatedDataLabel.Text = string.Empty;
                //purgedDataLabel.Text = string.Empty;
                //blindedAndTaggedDataLabel.Text = string.Empty;
                //doubleBlockAndBleedDataLabel.Text = string.Empty;
                //electricalLockoutDataLabel.Text = string.Empty;
                //mechanicalLockoutDataLabel.Text = string.Empty;
                //blindSchematicAvailableDataLabel.Text = string.Empty;
                //zeroEnergyFormNumberDataLabel.Text = string.Empty;
                //lockBoxNumberDataLabel.Text = string.Empty;
                //jobsiteEquipmentInspectedAndVerifiedReadyForWorkDataLabel.Text = string.Empty;
                //confinedSpaceWorkSectionNotApplicableToJobCheckBox.Checked = false;
                //questionOneDataLabel.Text = string.Empty;
                //questionTwoDataLabel.Text = string.Empty;
                //questionTwoADataLabel.Text = string.Empty;
                //questionTwoBDataLabel.Text = string.Empty;
                //questionThreeDataLabel.Text = string.Empty;
                //questionFourDataLabel.Text = string.Empty;
                //gasTestsSectionNotApplicableToJobCheckBox.Checked = false;
                //operatorGasDetectorNumberDataLabel.Text = string.Empty;
                //gasTestsDataLine1CombustibleGasDataLabel.Text = string.Empty;
                //gasTestsDataLine1OxygenDataLabel.Text = string.Empty;
                //gasTestsDataLine1ToxicGasDataLabel.Text = string.Empty;
                //gasTestsDataLine1TimeDataLabel.Text = string.Empty;
                //gasTestsDataLine2CombustibleGasDataLabel.Text = string.Empty;
                //gasTestsDataLine2OxygenDataLabel.Text = string.Empty;
                //gasTestsDataLine2ToxicGasDataLabel.Text = string.Empty;
                //gasTestsDataLine2TimeDataLabel.Text = string.Empty;
                //gasTestsDataLine3CombustibleGasDataLabel.Text = string.Empty;
                //gasTestsDataLine3OxygenDataLabel.Text = string.Empty;
                //gasTestsDataLine3ToxicGasDataLabel.Text = string.Empty;
                //gasTestsDataLine3TimeDataLabel.Text = string.Empty;
                //gasTestsDataLine4CombustibleGasDataLabel.Text = string.Empty;
                //gasTestsDataLine4OxygenDataLabel.Text = string.Empty;
                //gasTestsDataLine4ToxicGasDataLabel.Text = string.Empty;
                //gasTestsDataLine4TimeDataLabel.Text = string.Empty;    

                documentLinksControl.DataSource = new List<DocumentLink>();
                permitAcceptorDataLabel.Text = string.Empty;
                shiftSupervisorDataLabel.Text = string.Empty;
                areaLabelDataLabel.Text = string.Empty;
            }
            else
            {
                lastModifiedAuthorDataLabel.Text = permit.LastModifiedBy.FullNameWithUserName;
                lastModifiedDateDataLabel.Text = permit.LastModifiedDateTime.ToLongDateAndTimeString();
                //lastSubmittedDateDataLabel.Text = permit.LastSubmittedByUser.NullableToString();
                //lastSubmittedDateDataLabel.Text = permit.LastSubmittedDateTime.ToLongDateAndTimeStringOrEmptyString();

                contractorCheckBox.Checked = !permit.Company.IsNullOrEmptyOrWhitespace();
                contractorCheckBox.Text = string.Format(StringResources.WorkPermitEdmonton_ContractorDetailLabel,
                    permit.Company);
                suncorEnergyCheckBox.Checked = permit.IssuedToSuncor;
                occupationDataLabel.Text = permit.Occupation;
                numberOfWorkersDataLabel.Text = permit.NumberOfWorkers.NullableToString();
                groupDataLabel.Text = permit.Group.NullableToString();

                priorityDataLabel.Text = permit.Prioritydata.GetName();
                workPermitTypeDataLabel.Text = permit.WorkPermitType.ToString();

                functionalLocationDataLabel.Text = permit.FunctionalLocation.FullHierarchyWithDescription;
                locationOfWorkDataLabel.Text = permit.Location;

                vehicleEntryCheckBox.Checked = permit.VehicleEntry;

                requestedStartDataLabel.Text = Convert.ToString(permit.RequestedStartDateTime);
                expiredDataLabel.Text = permit.ExpiredDateTime.ToString();
                if (permit.RevalidationDateTime != DateTime.MinValue || permit.RevalidationDateTime != null)
                {  revalidationDateLabelData.Text = permit.RevalidationDateTime.ToString(); }
                 else { revalidationDateLabelData.Text = string.Empty; }

                if (permit.ExtensionDateTime != DateTime.MinValue || permit.ExtensionDateTime != null)
                {  extensionDateLabelData.Text = permit.ExtensionDateTime.ToString(); }
                else { extensionDateLabelData.Text = string.Empty; }

                jobCoordinatorLabelData.Text = permit.JobCoordinator;
                CoOrdContactNoLabelData.Text = permit.CoOrdContactNumber;
                EmergencyAssemblyAreaLabelData.Text = permit.EmergencyAssemblyArea;
                EmergencyMeetingPointLabelData.Text = permit.EmergencyMeetingPoint;
                emergencyContactNoLabelData.Text = permit.EmergencyContactNo;
                equipomentNoLabelData.Text = permit.EquipmentNo;
                if (permit.LockBoxnumberChecked)
                {LockBoxnumberCheckedLabelData.Text = StringResources.Yes;}
                else
                {LockBoxnumberCheckedLabelData.Text = StringResources.No;}
                
                if (!string.IsNullOrEmpty(permit.LockBoxNumber))
                    lockBoxNumberLabelData.Text = permit.LockBoxNumber;
                else
                    LockBoxnumberCheckedLabelData.Text = string.Empty;

                if (!string.IsNullOrEmpty(permit.IsolationNo))
                    isolationNoLabelData.Text = permit.IsolationNo;
                else
                    isolationNoLabelData.Text = string.Empty;

                workOrderNumberDataLabel.Text = permit.WorkOrderNumber;
                operationNumberDataLabel.Text = permit.OperationNumber;
                toolTip.SetToolTip(operationNumberGroupBox, permit.OperationNumber);
                subOperationDataLabel.Text = permit.SubOperationNumber;
                toolTip.SetToolTip(subOperationNumberGroupBox, permit.SubOperationNumber);

                taskDescriptionTextBox.Text = permit.TaskDescription;
                //currentSapDescriptionTextBox.Text = permit.SapDescription;
                hazardsAndOrRequirementsTextBox.Text = permit.HazardsAndOrRequirements;

                //ShowSapDescription = permit.IsSAPDescriptionAvailableForDisplay;
                //ShowSapDescription = permit.DataSource.Id == DataSource.SAP.Id &&
                //                     permit.Description != permit.SapDescription;

                flameResistantWorkWearCheckBox.Checked = permit.FlameResistantWorkWear;
                chemicalSuitCheckBox.Checked = permit.ChemicalSuit;
                fireBlanketCheckBox.Checked = permit.FireBlanket;
                fireWatchCheckBox.Checked = permit.FireWatch;
                suppliedBreathingAir.Checked = permit.SuppliedBreathingAir;
                airMoverCheckBox.Checked = permit.AirMover;
                personalFlotationDeviceCheckBox.Checked = permit.PersonalFlotationDevice;
                hearingProtectionCheckBox.Checked = permit.HearingProtection;
                other1CheckBox.Checked = !permit.Other1.IsNullOrEmptyOrWhitespace();
                other1ValueDataLabel.Text = permit.Other1;

                MonoGogglesCheckBox.Checked = permit.MonoGoggles;
                confinedSpaceMoniterCheckBox.Checked = permit.ConfinedSpaceMoniter;
                fireExtinguisherCheckBox.Checked = permit.FireExtinguisher;
                sparkContainmentCheckBox.Checked = permit.SparkContainment;
                BottleWatchCheckBox.Checked = permit.BottleWatch;
                standbyPersonCheckBox.Checked = permit.StandbyPerson;
                WorkingAloneCheckBox.Checked = permit.WorkingAlone;
                safetyGlovesCheckBox.Checked = permit.SafetyGloves;
                other2CheckBox.Checked = !permit.Other2.IsNullOrEmptyOrWhitespace();
                other2ValueDataLabel.Text = permit.Other2;

                faceShieldCheckBox.Checked = permit.FaceShield;
                fallProtectionCheckBox.Checked = permit.FallProtection;
                chargedFireHouseCheckBox.Checked = permit.ChargedFireHouse;
                coveredSewerCheckBox.Checked = permit.CoveredSewer;
                airPurifyingRespiratorCheckBox.Checked = permit.AirPurifyingRespirator;
                singalPersonCheckBox.Checked = permit.SingalPerson;
                communicationDeviceCheckBox.Checked = permit.CommunicationDevice;
                reflectiveStripsCheckBox.Checked = permit.ReflectiveStrips;
                other3CheckBox.Checked = !permit.Other3.IsNullOrEmptyOrWhitespace();
                other3ValueDataLabel.Text = permit.Other3;

                confinedSpaceCheckBox.Checked = permit.ConfinedSpace;
                confinedSpaceClassDataLabel.Text = permit.ConfinedSpaceClass;
                groundDisturbanceCheckBox.Checked = permit.GroundDisturbance;
                fireProtectionAuthorizationCheckBox.Checked = permit.FireProtectionAuthorization;
                criticalOrSeriousLiftsCheckBox.Checked = permit.CriticalOrSeriousLifts;
                vehicleEntryCheckBox.Checked = permit.VehicleEntry;
                industrialRadiographyCheckBox.Checked = permit.IndustrialRadiography;
                electricalEncroachmentCheckBox.Checked = permit.ElectricalEncroachment;
                mSDSCheckBox.Checked = permit.MSDS;
                othersPartECheckBox.Checked = !permit.Other3.IsNullOrEmptyOrWhitespace();
                OthersPartEValueDataLabel.Text = permit.Other3;

                documentLinksControl.DataSource = permit.DocumentLinks;
                permitNumberDataValue.Text = permit.PermitNumber.HasValue ? Convert.ToString(permit.PermitNumber.Value) : string.Empty;
                //shiftSupervisorDataLabel.Text = permit.ShiftSupervisor;
                permitAcceptorDataLabel.Text = permit.PermitAcceptor;
                issuedDataLabel.Text = permit.IssuedDateTime == null ? string.Empty : permit.IssuedDateTime.ToLongDateAndTimeStringOrEmptyString();

               /* lastModifiedAuthorDataLabel.Text = permit.LastModifiedBy.FullNameWithUserName;
                lastModifiedDateDataLabel.Text = permit.LastModifiedDateTime.ToShortDateAndTimeString();

                permitNumberDataValue.Text = permit.PermitNumber.HasValue ? Convert.ToString(permit.PermitNumber.Value) : string.Empty;

                suncorEnergyCheckBox.Checked = permit.IssuedToSuncor;

                contractorCheckBox.Checked = permit.IssuedToCompany;
                contractorCheckBox.Text = string.Format(StringResources.WorkPermitEdmonton_ContractorDetailLabel, permit.Company);

                occupationDataLabel.Text = permit.Occupation;
                numberOfWorkersDataLabel.Text = permit.NumberOfWorkers.NullableToString();
                groupDataLabel.Text = permit.Group.NullableToString();

                workPermitTypeDataLabel.Text = permit.WorkPermitType.ToString();
                priorityDataLabel.Text = permit.Prioritydata.GetName();
               // durationPermitCheckBox.Checked = permit.DurationPermit;
                functionalLocationDataLabel.Text = permit.FunctionalLocation.FullHierarchyWithDescription;
                locationOfWorkDataLabel.Text = permit.Location;
                confinedSpaceCheckBox.Checked = permit.ConfinedSpace;
                confinedSpaceClassDataLabel.Text = permit.ConfinedSpaceClass;
                vehicleEntryCheckBox.Checked = permit.VehicleEntry;

                               

                requestedStartDataLabel.Text = permit.RequestedStartDateTime.ToLongDateAndTimeString();                
                expiredDataLabel.Text = permit.ExpiredDateTime.ToLongDateAndTimeString();
                

                workOrderNumberDataLabel.Text = permit.WorkOrderNumber;
                operationNumberDataLabel.Text = permit.OperationNumber;
                toolTip.SetToolTip(operationNumberGroupBox, permit.OperationNumber);
                subOperationDataLabel.Text = permit.SubOperationNumber;
                toolTip.SetToolTip(subOperationNumberGroupBox, permit.SubOperationNumber);

                taskDescriptionTextBox.Text = permit.TaskDescription;
                hazardsAndOrRequirementsTextBox.Text = permit.HazardsAndOrRequirements;
                */
                //if (permit.OtherAreasAndOrUnitsAffected)
                //{
                //    otherAreasAffectedNoRadioButton.Checked = false;
                //    otherAreasAffectedYesRadioButton.Checked = true;
                //    otherAreasAndOrUnitsAffectedAreaDataLabel.Text = permit.OtherAreasAndOrUnitsAffectedArea;
                //    otherAreasAndOrUnitsAffectedPersonNotifiedDataLabel.Text = permit.OtherAreasAndOrUnitsAffectedPersonNotified;
                //}
                //else
                //{
                    //otherAreasAffectedNoRadioButton.Checked = true;
                    //otherAreasAffectedYesRadioButton.Checked = false;
                    //otherAreasAndOrUnitsAffectedAreaDataLabel.Text = string.Empty;
                    //otherAreasAndOrUnitsAffectedPersonNotifiedDataLabel.Text = string.Empty;
                //}

              //  workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox.Checked = permit.WorkersMinimumSafetyRequirementsSectionNotApplicableToJob;

                //faceShieldCheckBox.Checked = permit.FaceShield;
                //gogglesCheckBox.Checked = permit.ChemicalSuit;
                //rubberBootsCheckBox.Checked = permit.BottleWatch;
                //rubberGlovesCheckBox.Checked = permit.ConfinedSpaceMoniter;//**RubberGloves= ConfinedSpaceMoniter
                //rubberSuitCheckBox.Checked = permit.SuppliedBreathingAir;// rubberSuitCheckBox = SuppliedBreathingAir
                //safetyHarnessLifelineCheckBox.Checked = permit.AirMover;
                //highVoltagePPECheckBox.Checked = permit.PersonalFlotationDevice;
                //other1CheckBox.Checked = permit.Other1Checked;
                //other1ValueDataLabel.Text = permit.Other1;

                //equipmentGroundedCheckBox.Checked = permit.MonoGoggles;// equipmentGroundedCheckBox = MonoGoggles
                //fireBlanketCheckBox.Checked = permit.FireBlanket;
                //fireExtinguisherCheckBox.Checked = permit.FireExtinguisher;
                //fireMonitorMannedCheckBox.Checked = permit.SparkContainment;
                //fireWatchCheckBox.Checked = permit.FireWatch;
                //sewersDrainsCoveredCheckBox.Checked = permit.StandbyPerson;
                //steamHoseCheckBox.Checked = permit.WorkingAlone;
                //other2CheckBox.Checked = permit.Other2Checked;
                //other2ValueDataLabel.Text = permit.Other2;

                //airPurifyingRespiratorCheckBox.Checked = permit.AirPurifyingRespirator;
                //breathingAirApparatusCheckBox.Checked = permit.FallProtection;
                //dustMaskCheckBox.Checked = permit.ChargedFireHouse;
                //lifeSupportSystemCheckBox.Checked = permit.CoveredSewer;
                //safetyWatchCheckBox.Checked = permit.AirPurifyingRespirator;
                //continuousGasMonitorCheckBox.Checked = permit.SingalPerson;
                //workersMonitorNumberCheckBox.Checked = permit.CommunicationDevice;
                //workersMonitorNumberDataLabel.Text = permit.WorkersMonitorNumber;
                //bumpTestMonitorPriorToUseCheckBox.Checked = permit.ReflectiveStrips;
                //other3CheckBox.Checked = permit.Other3Checked;
                //other3ValueDataLabel.Text = permit.Other3;

                //airMoverCheckBox.Checked = permit.AirMover;
                //barriersSignsCheckBox.Checked = permit.GoundDisturbance;
                //radioCheckBox.Checked = permit.FireProtectionAuthorization;
                //airHornCheckBox.Checked = permit.CriticalOrSeriousLifts;
                //mechVentilationComfortOnlyCheckBox.Checked = permit.VehicleEntry;
                //asbestosMmfPrecautionsCheckBox.Checked = permit.IndustrialRadiography;
                //other4CheckBox.Checked = permit.OthersPartEChecked;
                //other4ValueDataLabel.Text = permit.OthersPartE;
                //lockBoxNumberDataLabel.Text = permit.LockBoxNumber;

                //alkylationEntryCheckBox.Checked = permit.AlkylationEntry;
                //classOfClothingDataLabel.Text = permit.AlkylationEntryClassOfClothing;
                //flarePitEntryCheckBox.Checked = permit.FlarePitEntry;
                //flarePitEntryTypeDataLabel.Text = permit.FlarePitEntryType;
                //confinedSpaceCardNumberDataLabel.Text = permit.ConfinedSpaceCardNumber;
                //rescuePlanCheckBox.Checked = permit.RescuePlan;
                //rescuePlanFormNumberDataLabel.Text = permit.RescuePlanFormNumber;
                //specialWorkCheckBox.Checked = permit.SpecialWork;
                //specialWorkTypeDataLabel.Text = permit.SpecialWorkType != null ? permit.SpecialWorkType.Name : string.Empty;
                //specialWorkTypeDataLabel.Text = permit.SpecialWorkName;
                //specialWorkFormNumber.Text = permit.SpecialWorkFormNumber;
                ////mangesh for RoadAccessOnPermit 
                //roadAccessOnPermitCheckBox.Checked = permit.RoadAccessOnPermit;
                //roadAccessOnPermitType.Text = permit.RoadAccessOnPermitType;
                //roadAccessOnPermitFormNo.Text = permit.RoadAccessOnPermitFormNumber;
                //vehicleEntryTotalNumber.Text = permit.VehicleEntryTotal.HasValue ? Convert.ToString(permit.VehicleEntryTotal.Value) : string.Empty;
                //vehicleEntryTypeDataLabel.Text = permit.VehicleEntryType;
                //gn59CheckBox.Checked = permit.GN59;
                //gn59FormNumberDataLabel.Text = permit.FormGN59 == null ? string.Empty : permit.FormGN59.FormNumber.ToString();
                //gn7CheckBox.Checked = permit.GN7;
                //gn7FormNumberDataLabel.Text = permit.FormGN7 == null ? string.Empty : permit.FormGN7.FormNumber.ToString();
                //gn24CheckBox.Checked = permit.GN24;
                //gn24FormNumberDataLabel.Text = permit.FormGN24 == null ? string.Empty : permit.FormGN24.FormNumber.ToString();
                //gn6CheckBox.Checked = permit.GN6;
                //gn6FormNumberDataLabel.Text = permit.FormGN6 == null ? string.Empty : permit.FormGN6.FormNumber.ToString();
                //gn75ACheckBox.Checked = permit.GN75A;
                //gn75AFormNumberDataLabel.Text = permit.FormGN75A == null ? string.Empty : permit.FormGN75A.FormNumber.ToString();
                //gn1CheckBox.Checked = permit.GN1;
                //gn1FormNumberDataLabel.Text = permit.FormGN1 == null ? string.Empty : permit.FormGN1TradeChecklistDisplayNumber;
                //gn11DataLabel.Text = permit.GN11.Name;
                //gn27DataLabel.Text = permit.GN27.Name;
                //statusOfPipingEquipmentSectionNotApplicableToJobCheckBox.Checked = permit.StatusOfPipingEquipmentSectionNotApplicableToJob;
                //productNormallyInPipingEquipmentDataLabel.Text = permit.ProductNormallyInPipingEquipment;
                //isolationValvesLockedDataLabel.Text = YesNoNotApplicable.ToString(permit.IsolationValvesLocked);
                //depressuredDrainedDataLabel.Text = YesNoNotApplicable.ToString(permit.DepressuredDrained);
                //ventilatedDataLabel.Text = YesNoNotApplicable.ToString(permit.Ventilated);
                //purgedDataLabel.Text = YesNoNotApplicable.ToString(permit.Purged);
                //blindedAndTaggedDataLabel.Text = YesNoNotApplicable.ToString(permit.BlindedAndTagged);
                //doubleBlockAndBleedDataLabel.Text = YesNoNotApplicable.ToString(permit.DoubleBlockAndBleed);
                //electricalLockoutDataLabel.Text = YesNoNotApplicable.ToString(permit.ElectricalLockout);
                //mechanicalLockoutDataLabel.Text = YesNoNotApplicable.ToString(permit.MechanicalLockout);
                //blindSchematicAvailableDataLabel.Text = YesNoNotApplicable.ToString(permit.BlindSchematicAvailable);
                //zeroEnergyFormNumberDataLabel.Text = permit.ZeroEnergyFormNumber;
                //jobsiteEquipmentInspectedAndVerifiedReadyForWorkDataLabel.Text = permit.JobsiteEquipmentInspected.BooleanToYesNoString();
                //confinedSpaceWorkSectionNotApplicableToJobCheckBox.Checked = permit.ConfinedSpaceWorkSectionNotApplicableToJob;
                //questionOneDataLabel.Text = permit.QuestionOneResponse.BoolValue == null ? YesNoNotApplicable.BLANK.ToString() : YesNoNotApplicable.ToString(permit.QuestionOneResponse);
                //questionTwoDataLabel.Text = YesNoNotApplicable.ToString(permit.QuestionTwoResponse);
                //questionTwoADataLabel.Text = YesNoNotApplicable.ToString(permit.QuestionTwoAResponse);
                //questionTwoBDataLabel.Text = YesNoNotApplicable.ToString(permit.QuestionTwoBResponse);
                //questionThreeDataLabel.Text = YesNoNotApplicable.ToString(permit.QuestionThreeResponse);
                //questionFourDataLabel.Text = YesNoNotApplicable.ToString(permit.QuestionFourResponse);
                //gasTestsSectionNotApplicableToJobCheckBox.Checked = permit.GasTestsSectionNotApplicableToJob;
                //operatorGasDetectorNumberDataLabel.Text = permit.OperatorGasDetectorNumber;
                //gasTestsDataLine1CombustibleGasDataLabel.Text = permit.GasTestDataLine1CombustibleGas;
                //gasTestsDataLine1OxygenDataLabel.Text = permit.GasTestDataLine1Oxygen;
                //gasTestsDataLine1ToxicGasDataLabel.Text = permit.GasTestDataLine1ToxicGas;
                //gasTestsDataLine1TimeDataLabel.Text = permit.GasTestDataLine1Time == null ? string.Empty : permit.GasTestDataLine1Time.ToString();
                //gasTestsDataLine2CombustibleGasDataLabel.Text = permit.GasTestDataLine2CombustibleGas;
                //gasTestsDataLine2OxygenDataLabel.Text = permit.GasTestDataLine2Oxygen;
                //gasTestsDataLine2ToxicGasDataLabel.Text = permit.GasTestDataLine2ToxicGas;
                //gasTestsDataLine2TimeDataLabel.Text = permit.GasTestDataLine2Time == null ? string.Empty : permit.GasTestDataLine2Time.ToString();
                //gasTestsDataLine3CombustibleGasDataLabel.Text = permit.GasTestDataLine3CombustibleGas;
                //gasTestsDataLine3OxygenDataLabel.Text = permit.GasTestDataLine3Oxygen;
                //gasTestsDataLine3ToxicGasDataLabel.Text = permit.GasTestDataLine3ToxicGas;
                //gasTestsDataLine3TimeDataLabel.Text = permit.GasTestDataLine3Time == null ? string.Empty : permit.GasTestDataLine3Time.ToString();
                //gasTestsDataLine4CombustibleGasDataLabel.Text = permit.GasTestDataLine4CombustibleGas;
                //gasTestsDataLine4OxygenDataLabel.Text = permit.GasTestDataLine4Oxygen;
                //gasTestsDataLine4ToxicGasDataLabel.Text = permit.GasTestDataLine4ToxicGas;
                //gasTestsDataLine4TimeDataLabel.Text = permit.GasTestDataLine4Time == null ? string.Empty : permit.GasTestDataLine4Time.ToString();

               
               
               // areaLabelDataLabel.Text = permit.AreaLabel == null ? string.Empty : permit.AreaLabel.Name;
            }

            AdjustTextBoxHeights();
        }
    }
}