using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Com.Suncor.Olt.Client.OltControls;
using Com.Suncor.Olt.Client.Utilities;
using Com.Suncor.Olt.Common.Domain;
using Com.Suncor.Olt.Common.Domain.WorkPermit;
using Com.Suncor.Olt.Common.Extension;
using Com.Suncor.Olt.Common.Localization;

namespace Com.Suncor.Olt.Client.Controls.Details
{
    public partial class PermitRequestEdmontonDetails : AbstractDetails, IPermitRequestEdmontonDetails
    {
        private readonly Dictionary<Control, int> originalControlHeights = new Dictionary<Control, int>();

        public event EventHandler RefreshAll;
        public event EventHandler EditTemplate;
            
        public PermitRequestEdmontonDetails()
        {
            InitializeComponent();

            deleteButton.Click += DeleteButton_Click;
            importButton.Click += ImportButton_Click;
            cloneButton.Click += CloneButton_Click;
            editHistoryButton.Click += HistoryButton_Click;
            exportAllButton.Click += ExportAllButton_Click;

            editButton.Click += EditButton_Click;
            submitButton.Click += SubmitButton_Click;
            marktemplateButton.Click += marktemplateButton_Click;

            editTemplateButon.Click += editTemplate_Click;

            mainPanel.Layout += HandleMainPanelLayout;
            Disposed += HandleDisposed;
        }

        protected override Panel Details
        {
            get { return mainPanel; }
        }

        protected override ToolStripButton ToggleDateRangeButton
        {
            get { return dateRangeToggleButton; }
        }

        public override ToolStripButton SaveGridLayoutButton
        {
            get { return saveGridLayoutButton; }
        }

        protected bool ShowSapDescription
        {
            set
            {
                currentSAPDescriptionGroupBox.Visible = value;
                currentSapDescriptionTextBox.Visible = value;
            }
        }

        protected bool ShowLastImportData
        {
            set
            {
                //lastImportedDateTimeLabelPanel.Visible = value;
                //lastImportedTableLayoutPanel.Visible = value;
            }
        }

        public event EventHandler Delete;
        public event EventHandler Clone;
        public event EventHandler Edit;
        public event EventHandler ExportAll;
        public event EventHandler ViewEditHistory;
        public event EventHandler Submit;
        public event EventHandler Import;

        public event EventHandler MarkAsTemplate;

        public bool CloneEnabled
        {
            set { cloneButton.Enabled = value; }
        }

        public bool DeleteEnabled
        {
            set { deleteButton.Enabled = value; }
        }

        public bool EditEnabled
        {
            set { editButton.Enabled = value; }
        }

        public bool ViewEditHistoryEnabled
        {
            set { editHistoryButton.Enabled = value; }
        }

        public bool SubmitEnabled
        {
            set { submitButton.Enabled = value; }
        }

        public bool ImportEnabled
        {
            set { importButton.Enabled = value; }
        }

        public void CallDefaultButton()
        {
            if (editButton.Enabled)
            {
                EditButton_Click(this, new EventArgs());
            }
        }

        public void SetDetails(PermitRequestEdmonton request)
        {
            if (request == null)
            {
                lastSubmittedDateDataLabel.Text = string.Empty;
                lastSubmittedByDataLabel.Text = string.Empty;

                lastModifiedByDataLabel.Text = string.Empty;
                lastModifiedDateDataLabel.Text = string.Empty;

                priorityDataLabel.Text = string.Empty;
                contractorCheckBox.Checked = false;
                suncorEnergyCheckBox.Checked = false;
                occupationDataLabel.Text = string.Empty;
                numberOfWorkersDataLabel.Text = string.Empty;
                groupDataLabel.Text = string.Empty;

                workPermitTypeDataLabel.Text = string.Empty;
                functionalLocationDataLabel.Text = string.Empty;
                locationOfWorkDataLabel.Text = string.Empty;

                classOfClothingDataLabel.Text = string.Empty;

                flarePitEntryTypeDataLabel.Text = string.Empty;

                confinedSpaceClassDataLabel.Text = string.Empty;
                confinedSpaceCardNumberDataLabel.Text = string.Empty;

                rescuePlanFormNumberDataLabel.Text = string.Empty;

                specialWorkTypeDataLabel.Text = string.Empty;
                specialWorkFormNumber.Text = string.Empty;

                roadAccessOnPermitType.Text = string.Empty;//mangesh for RoadAccessOnPermit 
                roadAccessOnPermitFormNo.Text = string.Empty;

                gn1FormNumberDataLabel.Text = string.Empty;
                gn59FormNumberDataLabel.Text = string.Empty;
                gn6FormNumberDataLabel.Text = string.Empty;
                gn7FormNumberDataLabel.Text = string.Empty;
                gn24FormNumberDataLabel.Text = string.Empty;
                gn75AFormNumberDataLabel.Text = string.Empty;

                gn11DataLabel.Text = string.Empty;
                gn27DataLabel.Text = string.Empty;

                requestedStartDataLabel.Text = string.Empty;
                requestedStartTimeDayDataLabel.Text = string.Empty;
                requestedStartTimeNightDataLabel.Text = string.Empty;

                workOrderNumberDataLabel.Text = string.Empty;
                operationNumberDataLabel.Text = string.Empty;
                subOperationDataLabel.Text = string.Empty;

                taskDescriptionTextBox.Text = string.Empty;
                currentSapDescriptionTextBox.Text = string.Empty;
                hazardsAndOrRequirementsTextBox.Text = string.Empty;

                ShowSapDescription = false;

                otherAreasAffectedNoRadioButton.Checked = false;
                otherAreasAffectedYesRadioButton.Checked = false;
                otherAreasAndOrUnitsAffectedAreaDataLabel.Text = string.Empty;
                otherAreasAndOrUnitsAffectedPersonNotifiedDataLabel.Text = string.Empty;

                documentLinksControl.DataSource = new List<DocumentLink>();
                ShowLastImportData = true;
                areaLabelDataLabel.Text = string.Empty;
            }
            else
            {
                lastModifiedByDataLabel.Text = request.LastModifiedBy.NullableToString();
                lastModifiedDateDataLabel.Text = request.LastModifiedDateTime.ToLongDateAndTimeString();

                lastSubmittedByDataLabel.Text = request.LastSubmittedByUser.NullableToString();
                lastSubmittedDateDataLabel.Text = request.LastSubmittedDateTime.ToLongDateAndTimeStringOrEmptyString();

                priorityDataLabel.Text = request.Priority.GetName();
                contractorCheckBox.Checked = !request.Company.IsNullOrEmptyOrWhitespace();
                contractorCheckBox.Text = string.Format(StringResources.WorkPermitEdmonton_ContractorDetailLabel,
                    request.Company);

                suncorEnergyCheckBox.Checked = request.IssuedToSuncor;

                occupationDataLabel.Text = request.Occupation;
                numberOfWorkersDataLabel.Text = request.NumberOfWorkers.NullableToString();
                groupDataLabel.Text = request.Group.NullableToString();

                workPermitTypeDataLabel.Text = request.WorkPermitType.ToString();
                functionalLocationDataLabel.Text = request.FunctionalLocation.FullHierarchyWithDescription;
                locationOfWorkDataLabel.Text = request.Location;

                alkylationEntryCheckBox.Checked = request.AlkylationEntry;
                classOfClothingDataLabel.Text = request.AlkylationEntryClassOfClothing;

                flarePitEntryCheckBox.Checked = request.FlarePitEntry;
                flarePitEntryTypeDataLabel.Text = request.FlarePitEntryType;

                confinedSpaceCheckBox.Checked = request.ConfinedSpace;
                confinedSpaceClassDataLabel.Text = request.ConfinedSpaceClass;
                confinedSpaceCardNumberDataLabel.Text = request.ConfinedSpaceCardNumber;

                rescuePlanCheckBox.Checked = request.RescuePlan;
                rescuePlanFormNumberDataLabel.Text = request.RescuePlanFormNumber;

                vehicleEntryCheckBox.Checked = request.VehicleEntry;
                vehicleEntryTotalNumber.Text = request.VehicleEntryTotal.NullableToString();
                vehicleEntryTypeDataLabel.Text = request.VehicleEntryType;

                specialWorkCheckBox.Checked = request.SpecialWork;
                //specialWorkTypeDataLabel.Text = request.SpecialWorkType != null ? request.SpecialWorkType.Name : null;
                specialWorkTypeDataLabel.Text = request.SpecialWorkName;
                specialWorkFormNumber.Text = request.SpecialWorkFormNumber;

                roadAccessOnPermitCheckBox.Checked = request.RoadAccessOnPermit; //mangesh for RoadAccessOnPermit
                roadAccessOnPermitType.Text = request.RoadAccessOnPermitType;
                roadAccessOnPermitFormNo.Text = request.RoadAccessOnPermitFormNumber;

                gn1CheckBox.Checked = request.GN1;
                gn1FormNumberDataLabel.Text = request.FormGN1 == null
                    ? null
                    : request.FormGN1TradeChecklistDisplayNumber;

                gn59CheckBox.Checked = request.GN59;
                gn59FormNumberDataLabel.Text = request.FormGN59 == null ? null : request.FormGN59.FormNumber.ToString();

                gn7CheckBox.Checked = request.GN7;
                gn7FormNumberDataLabel.Text = request.FormGN7 == null ? null : request.FormGN7.FormNumber.ToString();

                gn24CheckBox.Checked = request.GN24;
                gn24FormNumberDataLabel.Text = request.FormGN24 == null ? null : request.FormGN24.FormNumber.ToString();

                gn6CheckBox.Checked = request.GN6;
                gn6FormNumberDataLabel.Text = request.FormGN6 == null ? null : request.FormGN6.FormNumber.ToString();

                gn75ACheckBox.Checked = request.GN75A;
                gn75AFormNumberDataLabel.Text = request.FormGN75A == null
                    ? null
                    : request.FormGN75A.FormNumber.ToString();

                gn11DataLabel.Text = request.GN11.Name;
                gn27DataLabel.Text = request.GN27.Name;

                requestedStartDataLabel.Text = request.RequestedStartDate.ToString();
                requestedStartDayCheckBox.Checked = request.RequestedStartTimeDay != null;
                requestedStartTimeDayDataLabel.Text = request.RequestedStartTimeDay != null
                    ? request.RequestedStartTimeDay.ToString()
                    : string.Empty;

                requestedStartNightCheckBox.Checked = request.RequestedStartTimeNight != null;
                requestedStartTimeNightDataLabel.Text = request.RequestedStartTimeNight != null
                    ? request.RequestedStartTimeNight.ToString()
                    : string.Empty;

                requestedEndDataLabel.Text = request.EndDate.ToString();

                workOrderNumberDataLabel.Text = request.WorkOrderNumber;
                operationNumberDataLabel.Text = request.OperationNumberListAsString;
                toolTip.SetToolTip(operationNumberGroupBox, request.OperationNumberListAsString);
                subOperationDataLabel.Text = request.SubOperationNumberListAsString;
                toolTip.SetToolTip(subOperationNumberGroupBox, request.SubOperationNumberListAsString);

                taskDescriptionTextBox.Text = request.Description;
                currentSapDescriptionTextBox.Text = request.SapDescription;
                hazardsAndOrRequirementsTextBox.Text = request.HazardsAndOrRequirements;

                ShowSapDescription = request.IsSAPDescriptionAvailableForDisplay;

                PermitFormHelper.SetOtherAreasAndOrUnitsAffected(request.OtherAreasAndOrUnitsAffectedArea,
                    request.OtherAreasAndOrUnitsAffectedPersonNotified,
                    otherAreasAffectedNoRadioButton,
                    otherAreasAffectedYesRadioButton,
                    otherAreasAndOrUnitsAffectedAreaDataLabel,
                    otherAreasAndOrUnitsAffectedPersonNotifiedDataLabel);

                workersMinimumSafetyRequirementsSectionNotApplicableToJobCheckBox.Checked =
                    request.WorkersMinimumSafetyRequirementsSectionNotApplicableToJob;

                faceShieldCheckBox.Checked = request.FaceShield;
                gogglesCheckBox.Checked = request.Goggles;
                rubberBootsCheckBox.Checked = request.RubberBoots;
                rubberGlovesCheckBox.Checked = request.RubberGloves;
                rubberSuitCheckBox.Checked = request.RubberSuit;
                safetyHarnessLifelineCheckBox.Checked = request.SafetyHarnessLifeline;
                highVoltagePPECheckBox.Checked = request.HighVoltagePPE;
                other1CheckBox.Checked = !request.Other1.IsNullOrEmptyOrWhitespace();
                other1ValueDataLabel.Text = request.Other1;

                equipmentGroundedCheckBox.Checked = request.EquipmentGrounded;
                fireBlanketCheckBox.Checked = request.FireBlanket;
                fireExtinguisherCheckBox.Checked = request.FireExtinguisher;
                fireMonitorMannedCheckBox.Checked = request.FireMonitorManned;
                fireWatchCheckBox.Checked = request.FireWatch;
                sewersDrainsCoveredCheckBox.Checked = request.SewersDrainsCovered;
                steamHoseCheckBox.Checked = request.SteamHose;
                other2CheckBox.Checked = !request.Other2.IsNullOrEmptyOrWhitespace();
                other2ValueDataLabel.Text = request.Other2;

                airPurifyingRespiratorCheckBox.Checked = request.AirPurifyingRespirator;
                breathingAirApparatusCheckBox.Checked = request.BreathingAirApparatus;
                dustMaskCheckBox.Checked = request.DustMask;
                lifeSupportSystemCheckBox.Checked = request.LifeSupportSystem;
                safetyWatchCheckBox.Checked = request.SafetyWatch;
                continuousGasMonitorCheckBox.Checked = request.ContinuousGasMonitor;

                workersMonitorNumberCheckBox.Checked = request.WorkersMonitor;
                workersMonitorNumberDataLabel.Text = request.WorkersMonitorNumber;

                bumpTestMonitorPriorToUseCheckBox.Checked = request.BumpTestMonitorPriorToUse;
                other3CheckBox.Checked = !request.Other3.IsNullOrEmptyOrWhitespace();
                other3ValueDataLabel.Text = request.Other3;

                airMoverCheckBox.Checked = request.AirMover;
                barriersSignsCheckBox.Checked = request.BarriersSigns;
                radioCheckBox.Checked = request.RadioChannel;
                radioChannelNumberDataLabel.Text = request.RadioChannelNumber;
                airHornCheckBox.Checked = request.AirHorn;
                mechVentilationComfortOnlyCheckBox.Checked = request.MechVentilationComfortOnly;
                asbestosMmfPrecautionsCheckBox.Checked = request.AsbestosMMCPrecautions;
                other4CheckBox.Checked = !request.Other4.IsNullOrEmptyOrWhitespace();
                other4ValueDataLabel.Text = request.Other4;

                ShowLastImportData = request.DataSource.Id == DataSource.SAP.Id;
                ShowSapDescription = request.DataSource.Id == DataSource.SAP.Id &&
                                     request.Description != request.SapDescription;

                documentLinksControl.DataSource = request.DocumentLinks;
                areaLabelDataLabel.Text = request.AreaLabel == null ? string.Empty : request.AreaLabel.Name;

                AdjustTextBoxHeights();
            }
        }

        private void HandleDisposed(object sender, EventArgs e)
        {
            originalControlHeights.Clear();
        }

        private void HandleMainPanelLayout(object sender, LayoutEventArgs e)
        {
            invisibleLabel.Width = mainPanel.Width - 25;
        }

        private void CloneButton_Click(object sender, EventArgs e)
        {
            if (Clone != null)
            {
                Clone(this, e);
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (Delete != null)
            {
                Delete(this, e);
            }
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            if (Edit != null)
            {
                Edit(this, e);
            }
        }

        private void HistoryButton_Click(object sender, EventArgs e)
        {
            if (ViewEditHistory != null)
            {
                ViewEditHistory(this, e);
            }
        }

        private void ExportAllButton_Click(object sender, EventArgs e)
        {
            if (ExportAll != null)
            {
                ExportAll(this, e);
            }
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            if (Submit != null)
            {
                Submit(this, e);
            }
        }

        private void ImportButton_Click(object sender, EventArgs e)
        {
            if (Import != null)
            {
                Import(this, e);
            }
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
            var oldContainerHeight = containerGroupBox.Height;
            var size = TextRenderer.MeasureText(textBox.Text, textBox.Font, new Size(textBox.Width, Int32.MaxValue),
                TextFormatFlags.WordBreak);
            var heightRequired = size.Height + 30;
            if (heightRequired > oldContainerHeight)
            {
                containerGroupBox.Height = heightRequired;
            }
        }
//Added By Vibhor : DMND0010779 : OLT - Templateeasy clone

        private void marktemplateButton_Click(object sender, EventArgs e)
        {
            if (MarkAsTemplate != null)
            {
                MarkAsTemplate(this, e);
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


        public bool DeleteVisible
        {
            set { deleteButton.Visible = value; }
        }
        public bool editVisible
        {
            set { editButton.Visible = value; }
        }
        public bool submitButtonVisible
        {
            set { submitButton.Visible = value; }
        }

        public bool editHistoryButtonVisible
        {
            set { editHistoryButton.Visible = value; }
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